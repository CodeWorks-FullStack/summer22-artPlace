using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace art_place.Models
{
    public class Collection
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string CreatorId { get; set; }
    }
}