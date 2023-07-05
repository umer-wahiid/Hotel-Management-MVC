using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HManagement.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Name")]
        public string UName { get; set; }

        [Required]
        [StringLength(30)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string UEmail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MaxLength(20, ErrorMessage = "Max 20 Characters Allowed"), MinLength(8, ErrorMessage = "Min 8 Characters Allowed")]
        public string Password { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [MaxLength(20, ErrorMessage = "Max 20 Characters Allowed"), MinLength(8, ErrorMessage = "Min 8 Characters Allowed")]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password Not Match")]
        public string CPassword { get; set; }
        
        public int Role { get; set; }
        
    }
}