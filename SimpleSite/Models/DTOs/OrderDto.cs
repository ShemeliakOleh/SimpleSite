using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimpleSite.Models.DTOs
{
    public class OrderDto
    {
        public Guid? Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Number { get; set; }

        [Required]
        public decimal Amount { get; set; }
    }
}