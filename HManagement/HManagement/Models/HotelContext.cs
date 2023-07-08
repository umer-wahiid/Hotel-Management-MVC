using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HManagement.Models
{
    public class HotelContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        //public System.Data.Entity.DbSet<HManagement.Models.Booking> Bookings { get; set; }
    }
}