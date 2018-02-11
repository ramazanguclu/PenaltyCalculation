using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class PanelizedAmount
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public decimal Price { get; set; }
    }
}