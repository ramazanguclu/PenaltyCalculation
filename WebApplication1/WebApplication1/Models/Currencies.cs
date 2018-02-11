using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Currencies
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sybmol { get; set; }
        public int CountryId { get; set; }
    }
}