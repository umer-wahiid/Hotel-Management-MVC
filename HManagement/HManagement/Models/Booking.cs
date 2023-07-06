using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HManagement.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }

        [Required]
        public int Nights { get; set; }

        [Required]
        public DateTime CheckIn { get; set; }
        
        [Required]
        public DateTime CheckOut { get; set; }
        
        [Required]
        public string RoomType { get; set; }
        
        [Required]
        public int RoomNo { get; set; }
        
        [Required]
        public int Total { get; set; }
    }
}