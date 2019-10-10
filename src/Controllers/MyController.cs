using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace src.Controllers
{
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
    }
}