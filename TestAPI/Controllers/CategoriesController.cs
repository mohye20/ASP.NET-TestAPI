using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestAPI.Data;
using TestAPI.Data.Models;

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

		[HttpPost]
		public async Task<IActionResult> AddCategory(string category)
		{
			Category c = new() { Name = category };
			await _dB.Categories.AddAsync(c);
			_dB.SaveChanges();
			return Ok(c);
		}

		[HttpPut]
		public async Task<IActionResult> EditCategory(Category category)
		{
			var C = await _dB.Categories.SingleOrDefaultAsync(x => x.Id == category.Id);

			if (C is null)
			{
				return NotFound($"Category Id {category.Id} is not Exist!");
			}

			C.Name = category.Name;
			_dB.SaveChanges();
			return Ok(C);
		}
	}
}