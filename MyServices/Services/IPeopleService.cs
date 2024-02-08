using Microsoft.AspNetCore.Identity;
using MyServices.Entities;
using MyServices.Models.People;

namespace MyServices.Services
{
    public interface IPeopleService
    {
        IEnumerable<People> GetAll();
        People GetByDOI(int TipoDOI,string CodigoDOI);
        void Create(CreateRequest model);
        void Update(int TipoDOI, string CodigoDOI, UpdateRequest model);
        void Delete(int TipoDOI, string CodigoDOI);
    }
}
