using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HManagement.Models
{
    public class UniqueRoomNoAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var room = (Room)validationContext.ObjectInstance;
            var dbContext = new HotelContext(); // Replace YourDbContext with your actual DbContext class

            var existingRoom = dbContext.Rooms.FirstOrDefault(r => r.RoomId != room.RoomId && r.RoomNo == (int)value);

            if (existingRoom != null)
            {
                return new ValidationResult("The room number must be unique.");
            }

            return ValidationResult.Success;
        }
    }
}