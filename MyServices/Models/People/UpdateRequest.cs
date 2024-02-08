using System.ComponentModel.DataAnnotations;

namespace MyServices.Models.People
{
    public class UpdateRequest
    {
        [Required]
        public string? Nombres { get; set; }

        [Required]
        public string? ApellidoPaterno { get; set; }
        [Required]
        public string? ApellidoMaterno { get; set; }
        [Required]
        public int TipoDOI { get; set; }
        [Required]
        public string? CodigoDOI { get; set; }
        public string? NumeroTelefono { get; set; }
        [EmailAddress]
        public string? CorreoElectronico { get; set; }
        public string? Direccion { get; set; }
    }

}

