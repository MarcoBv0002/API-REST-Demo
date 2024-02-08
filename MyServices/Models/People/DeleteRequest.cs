using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyServices.Models.People
{
    public class DeleteRequest
    {
        [Required]
        public int nTipoDOI { get; set; }

        [Required]
        public string cNumeroDOI { get; set; }


    }

}

