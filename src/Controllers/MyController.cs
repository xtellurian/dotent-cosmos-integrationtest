using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace src.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class MyController: Controller
    {
        private readonly MyContext context;

        public MyController(MyContext context)
        {
            this.context = context;
            context.Database.EnsureCreated();
        }

        [HttpGet("api/model")]
        public async Task<IActionResult> CreateModel()
        {
            var model = new Model();
            var related = new Related();
            await context.Models.AddAsync(model);
            await context.Related.AddAsync(related);
            model.RelatedModels.Add(related);
            await context.SaveChangesAsync();
            return Ok(model.Id);
        }

        [HttpDelete("api/model")]
        public async Task<IActionResult> DeleteModel(string id)
        {
            var model = await context.Models.SingleOrDefaultAsync(m => m.Id == id);
            context.Models.Remove(model);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("api/token")]
        [AllowAnonymous]
        public IActionResult GetToken()
        {
            string token;
            var claim = new[]
            {
                new Claim(ClaimTypes.Name, "user"),
                new Claim(ClaimTypes.NameIdentifier, System.Guid.NewGuid().ToString())
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Secrets.JwtKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwtToken = new JwtSecurityToken(
                Secrets.Issuer,
                Secrets.Audience,
                claim,
                expires: System.DateTime.Now.AddMinutes(10),
                signingCredentials: credentials
            );
            token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return Ok(token);
        }
    }
}