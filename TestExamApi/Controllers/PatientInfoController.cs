using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using TestExamApi.AppData;
using TestExamApi.Entites;

namespace TestExamApi.Controllers
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
        public IActionResult Index()
        {
            return View();
        }



        [Route("PatientInfo/AddUpdatePatientInfo/")]
        [HttpPost]
        public async Task<ActionResult> AddUpdatePatientInfo(PatientInfo patientInfo,IEnumerable<NCD> nCDList, IEnumerable<Allergies> allergyList)
        {
            try
            {
                return Json(new { Status = "success", Message = "Save Successful." });
            }
            catch (Exception ex)
            {
                return Json(new { Status = "error", Message = ex.Message.ToString() });
            }
        }

    }
}
