using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.DAL;
using Newtonsoft.Json;
using WebApplication1.Models;

namespace WebApplication1.PenaltyCalculation
{
    public partial class GetCountries : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PenaltyCalculationContext context = new PenaltyCalculationContext();
            var c = context.Countries.ToList();


            List<Countries> listCountries = new List<Countries>();

            foreach (var item in c)
            {
                var country = new Countries
                {
                    Id = item.Id,
                    Name = item.Name
                };

                listCountries.Add(country);
            }

            var json = JsonConvert.SerializeObject(listCountries);


            Response.Clear();
            Response.ContentType = "application/json; charset=utf-8";
            Response.Write(json);
            Response.End();

        }
    }
}