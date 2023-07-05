using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HManagement.Models
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }

        [Required]
        [Display(Name = "Room Number")]
        public int RoomNo { get; set; }

        [Required]
        [Display(Name = "Room Type")]
        public string RoomType { get; set; }

        [Required]
        [Display(Name = "Room Capacity")]
        public int Capacity { get; set; }
        
        [Required]
        public int Price { get; set; }
        
        public string Availability { get; set; }
    }
}