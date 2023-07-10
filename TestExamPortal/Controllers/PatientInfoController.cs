using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TestExamApi.Controllers;
using TestExamApi.Data;
using TestExamApi.Entites;
using TestExamPortal.Models;

namespace TestExamPortal.Controllers
{
    public class PatientInfoController : Controller
    {
        private readonly HttpClient _client;
        private IConfiguration _configuration;

        public PatientInfoController(IConfiguration configuration)
        {
            _configuration = configuration;
            _client = new HttpClient();
            _client.BaseAddress = new Uri(_configuration["APIURL"]);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePatientInfo([FromBody]PatientInfoViewModel model)
        {
            try
            {
                
                HttpResponseMessage httpResponseMessage = await _client.PostAsJsonAsync("PatientInfo", model);
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

