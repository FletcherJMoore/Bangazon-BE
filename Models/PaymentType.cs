﻿using System.ComponentModel.DataAnnotations;

namespace Bangazon_BE.Models
{
    public class PaymentType
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
