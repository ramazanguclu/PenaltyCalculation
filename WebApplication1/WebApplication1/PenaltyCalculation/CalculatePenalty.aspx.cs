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
    public partial class CalculatePenalty : System.Web.UI.Page
    {
        PenaltyCalculationContext context = new PenaltyCalculationContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            string checkOutDate = Request.QueryString["checkOutDate"];
            string returnDate = Request.QueryString["returnDate"];
            string countryCode = Request.QueryString["countryCode"];
            int cCode = Convert.ToInt32(countryCode);

            DateTime dt1 = Convert.ToDateTime(checkOutDate);
            DateTime dt2 = Convert.ToDateTime(returnDate);

            int dayCount = getDayDifference(dt1, dt2, cCode);

            WriteData w = new WriteData
            {
                Total = getTotalPenalty(dayCount, cCode),
                Currency = getCurrency(cCode),
                BusinessDay = dayCount
            };

            write(w);
        }

        public int getDayDifference(DateTime dt1, DateTime dt2, int cCode)
        {
            int dayCount = 0;
            while (DateTime.Compare(dt1, dt2) != 0)
            {
                dt1 = dt1.AddDays(1);
                if (!isWeekend(dt1, cCode))
                {
                    if (!isHoliday(dt1, cCode))
                    {
                        dayCount++;
                    }
                }
            }

            return dayCount;
        }

        public string getCurrency(int cCode)
        {
            var currency = (from c in context.Currencies
                            where c.CountryId == cCode
                            select c.Sybmol).Single();

            return currency;
        }

        public decimal getTotalPenalty(int dayCount, int cCode)
        {
            decimal total = 0;

            if (dayCount > 10)
            {
                var amount = (from c in context.PanelizedAmount
                              where c.CountryId == cCode
                              select c.Price).Single();
                total = dayCount * amount;
            }
            return total;
        }

        public bool isWeekend(DateTime day, int cCode)
        {
            List<int> orderWeekends = new List<int>();
            var weekends = (from c in context.Weekends
                            where c.CountryId == cCode
                            select c).ToList();

            foreach (var item in weekends)
            {
                orderWeekends.Add(item.OrderOfDay);
            }

            var dayOfWeek = (int)day.DayOfWeek;
            return orderWeekends.IndexOf(dayOfWeek) != -1;
        }

        public bool isHoliday(DateTime day, int cCode)
        {
            bool holiday = false;

            var holidays = (from c in context.Holidays
                            where c.CountryId == cCode
                            select c).ToList();

            foreach (var item in holidays)
            {
                var holidayDate = item.Holiday;
                if (DateTime.Compare(day, holidayDate) == 0)
                {
                    holiday = true;
                    break;
                }
            }

            return holiday;
        }

        public void write(WriteData w)
        {
            var json = JsonConvert.SerializeObject(w);
            Response.Clear();
            Response.ContentType = "application/json; charset=utf-8";
            Response.Write(json);
            Response.End();
        }
    }
}