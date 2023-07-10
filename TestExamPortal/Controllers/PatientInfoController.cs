using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TestExamApi.Controllers;
using TestExamApi.Data;
using TestExamApi.Entites;
using TestExamPortal.Models;

namespace TestExamPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientInfoController : BaseController<PatientInfo>
    {
        private readonly ApplicationDbContext _context;

        public PatientInfoController(IRepository<PatientInfo> repository) : base(repository)
        {

        }

        [Route("PatientInfo/CreateAsync/")]
        [HttpPost]
        public override async Task<ActionResult<PatientInfo>> CreateAsync([FromBody] PatientInfo patientInfo)
        {
            using (var transection = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    foreach (NCD details in patientInfo.NCDs)
                    {
                        //
                    }
                    foreach (Allergies details in patientInfo.Allergies)
                    {
                        //
                    }
                    await _context.PatientInfos.AddAsync(patientInfo);
                    await _context.SaveChangesAsync();
                    await transection.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transection.RollbackAsync();
                    throw new Exception(ex.Message);
                }
            }
            return Ok();
        }

        [Route("PatientInfo/UpdateAsync/")]
        [HttpPost]
        public override async Task<ActionResult<PatientInfo>> UpdateAsync([FromRoute] int id, [FromBody] PatientInfo patientInfo)
        {
            if (id != patientInfo.ID)
            {
                return BadRequest();
            }
            else
            {
                using (var transection = await _context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        foreach (NCD details in patientInfo.NCDs)
                        {
                            //
                        }
                        foreach (Allergies details in patientInfo.Allergies)
                        {
                            //
                        }

                        _context.PatientInfos.Update(patientInfo);
                        await _context.SaveChangesAsync();
                        await transection.CommitAsync();
                    }
                    catch (Exception ex)
                    {
                        await transection.RollbackAsync();
                        throw new Exception(ex.Message);
                    }
                }
                return Ok();
            }




        }
    }
}

