using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PlantWateringAPI.Models;

namespace PlantWateringAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlantsController : Controller
    {
        private readonly AppDbContext _context;

        public PlantsController(AppDbContext plantsContext)
        {
            _context = plantsContext;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        [Route("getallplants")]
        public async Task<IActionResult> GetAllPlants()
        {
            var plants = await _context.Plants.ToListAsync();
            return Ok(plants);
        }


        [HttpPost]
        [Route("setplantstatus")]
        public async Task<IActionResult> UpdatePlantStatus(Plant plant, bool isWatering)
        {
            Plant? plantClicked;
            if (plant != null)
            {
                plantClicked = _context.Plants.Where(x => x.PlantId == plant.PlantId).FirstOrDefault();
                plantClicked.IsStatusWatering = isWatering; 
                plantClicked.LastWatered = DateTime.Now; 
            }

            var plants = await _context.Plants.ToListAsync();
            return Ok(plants);
        }
    }
}
