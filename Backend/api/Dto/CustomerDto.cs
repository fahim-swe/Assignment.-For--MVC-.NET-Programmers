using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dto
{
    public class CustomerDto
    {

        [Required, MaxLength(100)]
        public string CustomerName {get; set;} = null!;

         [Required, MaxLength(100)]
        public string FatherName {get;set;} = null!;

         [Required, MaxLength(100)]
        public string MotherName {get;set;} = null!;

        [Required, Range(0,2)]
        public int MaritalStatus {get;set;}

        [Required]
        public int CountryId {get; set;}

        [Required]
        public IFormFile Photo {get;set;} = null!;

        [Required]
        public List<string> Addresss {get; set;} = null!;
    }
}