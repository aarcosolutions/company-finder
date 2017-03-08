using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class CompanySearchResponse
    {
        public IEnumerable<CompanySearch> Items { get; set; }
    }

    public class CompanySearch
    {
        public string title { get; set; }
        public string company_number { get; set; }
        public string date_of_creation { get; set; }
        public string company_status { get; set; }
        public string company_type { get; set; }
        public string address_snippet { get; set; }
    }
}
