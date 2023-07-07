using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HManagement.Models
{
    public class Booking
    {
        private string _confirm = "not confirm";
        [Key]
        public int BookingId { get; set; }

        [Required]
        [Display(Name = "Nights")]
        public int Nights { get; set; }

        [Required]
        [Display(Name = "Checkin Date")]
        public DateTime CheckIn { get; set; }
        
        [Required]
        [Display(Name = "Checkout Date")]
        public DateTime CheckOut { get; set; }
        
        [Required]
        [Display(Name = "Room Type")]
        public string RoomType { get; set; }
        
        [Required]
        [Display(Name = "Room Number")]
        public int RoomNo { get; set; }


        [Required]
        public string Confirm 
        { 
            get { return _confirm; } 
            set { _confirm = value; } 
        }
        
        [Required]
        public string Payment { get; set; }
        
        [Required]
        [Display(Name = "Room Number")]
        public int Total { get; set; }
        
        [Required]
        public int UserId { get; set; }

        [Required]
        public string Image { get; set; }
    }
}