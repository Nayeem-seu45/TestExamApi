using deseaseId.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using TestExamApi.AppData;
using TestExamApi.Data;
using TestExamApi.Entites;

namespace TestExamApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientInfoController : BaseController<PatientInfo>
    {
      
        public PatientInfoController(IRepository<PatientInfo> repository) : base(repository)
        {
            
        }

        //[Route("PatientInfo/AddUpdatePatientInfo/")]
        //[HttpPost]
        //public async Task<ActionResult> AddUpdatePatientInfo(PatientInfo patientInfo,IEnumerable<NCD> nCDList, IEnumerable<Allergies> allergyList)
        //{
        //    try
        //    {
        //        return Json(new { Status = "success", Message = "Save Successful." });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Status = "error", Message = ex.Message.ToString() });
        //    }
        //}

    }
}
