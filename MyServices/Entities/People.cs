using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyServices.Entities
{
    [Table("Persona")]
    public class People
    {
        [Key]
        [Column("cPersonaId")]
        public int cPersonaId { get; set; }
        [Column("cNombres")]
        public string cNombres { get; set; }
        [Column("cApellidoPaterno")]
        public string cApellidoPaterno { get; set; }
        [Column("cApellidoMaterno")]
        public string cApellidoMaterno { get; set; }
        [Column("nTipoDOI")]
        public int nTipoDOI { get; set; }
        [Column("cNumeroDOI")]
        public string cNumeroDOI { get; set; }
        [Column("cNumeroTelefono")]
        public string cNumeroTelefono { get; set; }
        [Column("cCorreoElectronico")]
        //[EmailAddress]
        public string cCorreoElectronico { get; set; }
        [Column("cDireccion")]
        public string cDireccion { get; set; } 
    }
}
