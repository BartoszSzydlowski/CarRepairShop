﻿namespace CarRepairShop.Application.Identity.Requests
{
    public class RegisterRequest
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string PhoneNumber { get; set; }
    }
}
