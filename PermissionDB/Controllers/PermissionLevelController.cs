using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PermissionDB.Controllers
{
    public class PermissionLevelController
    {
        [HttpGet("/permission/{userUuid}/{companyId}")]
        public async Task<IActionResult> GetCompanyPermissionLevel(string userUuid, string companyId)
        {
            
        }
    }
}