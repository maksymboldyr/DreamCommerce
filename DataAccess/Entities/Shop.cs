﻿using DataAccess.Entities.Users;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class Shop : BaseEntity
    {
        [ForeignKey("User")]
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public User User { get; set; }
        public List<Product> Products { get; set; }
    }
}