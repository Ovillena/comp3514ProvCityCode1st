using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using provCityCode1st.Models;

namespace provCityCode1st.Data
{
    public class SampleData
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.EnsureCreated();

                // Look for any provinces.
                if (context.Provinces.Any())
                {
                    return;   // DB has already been seeded
                }

                var provinces = GetProvinces().ToArray();
                context.Provinces.AddRange(provinces);
                context.SaveChanges();

                var cities = GetCity(context).ToArray();
                context.City.AddRange(cities);
                context.SaveChanges();
            }
        }

        public static List<Provinces> GetProvinces()
        {
            List<Provinces> provinces = new List<Provinces>() {
            new Provinces() {
                ProvinceCode="BC",
                ProvinceName="British Columbia",
            },

        };

            return provinces;
        }

        public static List<City> GetCity(ApplicationDbContext context)
        {
            List<City> cities = new List<City>() {
            new City {
                CityName="Surrey",
                Population=10000000,
                ProvinceCode = context.Provinces.Find("BC").ProvinceCode,

            },
        };

            return cities;
        }

        // internal static void Initialize(IApplicationBuilder app)
        // {
        //     throw new NotImplementedException();
        // }
    }


}