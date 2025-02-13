using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Food
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [Column(TypeName = "decimal(6,2)")]
        public decimal Price { get; set; }

        public int? RestaurantId { get; set; }

        public string Image { get; set; } = string.Empty;

        public Restaurant? Restaurant { get; set; }
    }
}