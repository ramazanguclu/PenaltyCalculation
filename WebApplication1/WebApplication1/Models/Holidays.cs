using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Holidays
    {
        public int Id { get; set; }
        public DateTime Holiday { get; set; }
        public int CountryId { get; set; }
    }
}