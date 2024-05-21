using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dtos
{
    public class CreateRestaurantRequestDto
    {

        public string Name { get; set; }

        public string Description { get; set; }

        public string Contact { get; set; }

        public string Image { get; set; }

        public string Address { get; set; }
    }
}