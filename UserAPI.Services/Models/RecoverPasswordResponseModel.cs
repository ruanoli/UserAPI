﻿namespace UserAPI.Services.Models
{
    public class RecoverPasswordResponseModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public DateTime RecoverPasswordDateTime { get; set; }
    }
}
