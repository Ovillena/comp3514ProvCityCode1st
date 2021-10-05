using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace provCityCode1st.Models
{
    public class Provinces
    {
        [Key]
        public string ProvinceCode { get; set; }
        public string ProvinceName { get; set; }
        public IEnumerable<City> CityId { get; set; }

    }
}