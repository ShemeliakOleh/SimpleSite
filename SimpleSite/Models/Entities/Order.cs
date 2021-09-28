namespace SimpleSite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        public Order()
        {
            OrderProduct = new HashSet<OrderProduct>();
        }

        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Number { get; set; }

        public decimal Amount { get; set; }

        public virtual ICollection<OrderProduct> OrderProduct { get; set; }
    }
}
