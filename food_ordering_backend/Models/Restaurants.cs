using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Restaurant
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Contact { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string Image { get; set; } = string.Empty;


        public List<Food> Foods { get; set; } = new List<Food>();
    }
}