using AutoMapper;
using MyServices.Helpers;
using MyServices.Entities;
using MyServices.Models.People;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Identity;

namespace MyServices.Services
{
    public class PeopleService : IPeopleService
    {
        private DataContext _context;
        private readonly IMapper _mapper;

        public PeopleService(
            DataContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<People> GetAll()
        {
            return _context.Users;
        }

        public People GetByDOI(int TipoDOI,string CodigoDOI)
        {
            return getUser(TipoDOI,CodigoDOI);
        }

        public void Create(CreateRequest model )
        {
            try
            {
                // Validaciones de la solicitud - prevención de Bad Requests
                if (_context.Users.Any(x => x.nTipoDOI == model.TipoDOI && x.cNumeroDOI == model.CodigoDOI))
                    throw new AppException("400 Bad Request: La persona con documento número: '" + model.CodigoDOI + "' ya está registrada.");

                var user = _mapper.Map<People>(model);
                _context.Users.Add(user);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
            
        }

        public void Update(int TipoDOI, string CodigoDOI, UpdateRequest model)
        {
            try
            {
                var user = getUser(TipoDOI, CodigoDOI);
                // Validaciones de la solicitud - prevención de Bad Requests
                if (model.CorreoElectronico != user.cCorreoElectronico && _context.Users.Any(x => x.cCorreoElectronico == model.CorreoElectronico))
                    throw new AppException("400 Bad Request: Usuario con el correo'" + model.CorreoElectronico + "' ya existe. El correo es personal.");

                _mapper.Map(model, user);
                user.nTipoDOI = model.TipoDOI == 0 ? TipoDOI : model.TipoDOI;
                user.cNumeroDOI = String.IsNullOrEmpty(model.CodigoDOI) ? CodigoDOI : model.CodigoDOI;
                user.cNombres = String.IsNullOrEmpty(model.Nombres)? user.cNombres:model.Nombres.Trim();
                user.cCorreoElectronico = String.IsNullOrEmpty(model.CorreoElectronico) ? user.cCorreoElectronico : model.CorreoElectronico.Trim();
                user.cDireccion = String.IsNullOrEmpty(model.Direccion) ? user.cDireccion : model.Direccion.Trim();
                user.cApellidoMaterno = String.IsNullOrEmpty(model.ApellidoMaterno) ? user.cApellidoMaterno : model.ApellidoMaterno.Trim();
                user.cApellidoPaterno = String.IsNullOrEmpty(model.ApellidoPaterno) ? user.cApellidoPaterno : model.ApellidoPaterno.Trim();
                user.cNumeroTelefono = String.IsNullOrEmpty(model.NumeroTelefono) ? user.cNumeroTelefono :  model.NumeroTelefono.Trim();    

                _context.Users.Update(user);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }

        public void Delete(int TipoDOI, string CodigoDOI)
        {
            try
            {
                var user = getUser(TipoDOI, CodigoDOI);
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }

        // helper methods

        private People getUser(int TipoDOI, string CodigoDOI)
        {
            try
            {   
                var count = _context.Users.Where(u => u.nTipoDOI == TipoDOI && u.cNumeroDOI == CodigoDOI);

                if (count.Count() > 1) throw new KeyNotFoundException("501 Internal Server Error: Error en registros, persona duplicada.");

                var user = _context.Users.FirstOrDefault(u => u.nTipoDOI == TipoDOI && u.cNumeroDOI == CodigoDOI);

                if (user == null) throw new KeyNotFoundException("400 Bad Request: Persona no está registrada. Verifique los datos.");
            return user;
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }

    }
}
