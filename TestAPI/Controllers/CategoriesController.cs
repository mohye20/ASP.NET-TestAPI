using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestAPI.Data;

namespace TestAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		private readonly AppDbContext _dB;

		public CategoriesController(AppDbContext DB)
		{
			_dB = DB;
		}

		[HttpGet]
		public async Task<IActionResult> GetCategories()
		{
			var Catsegories = await _dB.Categories.ToListAsync();
			return Ok(Catsegories);
		}
	}
}