using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HManagement.Models;

namespace HManagement.Models
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; }

        [Required]
        [Display(Name = "Room Number")]
        [UniqueRoomNo]
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

        [Display(Name = "Choose Image")]
        public string image_path { get; set; }
        
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}