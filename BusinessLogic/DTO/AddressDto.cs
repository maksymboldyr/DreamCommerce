﻿namespace BusinessLogic.DTO
{
    public class AddressDto
    {
        public string? Id { get; set; }
        public string? UserId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public string Apartment { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
    }
}
