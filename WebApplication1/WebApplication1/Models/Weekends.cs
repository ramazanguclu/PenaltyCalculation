using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Weekends
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OrderOfDay { get; set; }
        public int CountryId { get; set; }
    }
}