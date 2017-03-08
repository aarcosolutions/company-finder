using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using api.Services;
using Newtonsoft.Json;
using api.Models;
using AutoMapper;
using System.Collections.Generic;

namespace api.Controllers
{
    [Route("api/[controller]")]
    public class SearchController : Controller
    {
        private ICompanyHouseApiService CompanyHouseApiService { get; }
        private IMapper Mapper { get; }
        public SearchController(ICompanyHouseApiService service, IMapper mapper)
        {
            CompanyHouseApiService = service;
            Mapper = mapper;
        }

        /// <summary>
        /// This endpoint search company house data for companies based in UK. It invokes company house API to retrieve company list,
        /// </summary>
        /// <param name="keyword">Name of the company to be searched</param>
        /// <returns>List of companies</returns>
        [HttpGet("{keyword}", Name ="SearchCompany")]
        public async Task<IActionResult> SearchCompany(string keyword)
        {
            try
            {
                var response = await this.CompanyHouseApiService.InvokeSearchCompanyApi(keyword);
                var d = JsonConvert.DeserializeObject<CompanySearchResponse>(response);
                var mappedData = Mapper.Map<IEnumerable<Company>>(d.Items);
                return Ok(mappedData);
            }
            catch 
            {
                return new StatusCodeResult(500);
            }
        }
    }
}