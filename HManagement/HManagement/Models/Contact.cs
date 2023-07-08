using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HManagement.Models
{
    public class Contact
    {

        [Key]
        public int ContactId { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Name")]
        public string UName { get; set; }

        [Required]
        [StringLength(30)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [MaxLength(600, ErrorMessage = "Max 600 Characters Allowed"), MinLength(8, ErrorMessage = "Min 8 Characters Allowed")]
        public string Message { get; set; }

    }
}