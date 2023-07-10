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
        public async Task<IActionResult> CreatePatientInfo([FromBody] PatientInfoViewModel model)
        {
            try
            {
                //var data = HttpContext.Request.Query["model"];


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

        public async Task<List<PatientInfoViewModel>> GetAllPatienInfo()
        {
            try
            {
                List<PatientInfoViewModel> list = new();
                HttpResponseMessage httpResponseMessage = await _client.GetAsync("PatientInfo");
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var jsonResult = await httpResponseMessage.Content.ReadAsStringAsync();
                    list = JsonConvert.DeserializeObject<List<PatientInfoViewModel>>(jsonResult);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

