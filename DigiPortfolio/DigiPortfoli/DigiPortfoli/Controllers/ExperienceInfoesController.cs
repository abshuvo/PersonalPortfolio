using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DigiPortfoli.Models;
using DigiPortfoli.Models.Entities;
using DigiPortfoli.Services;
using System.Text.Json;

namespace DigiPortfoli.Controllers
{
    public class ExperienceInfoesController : Controller
    {
        private readonly DBConfiguration _context;
        ExperienceManager _experienceManager = new ExperienceManager();

        public ExperienceInfoesController(DBConfiguration context)
        {
            _context = context;
        }

        // GET: ExperienceInfoes
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<string> GetAllExperience()
        {
            return JsonSerializer.Serialize(await _experienceManager.GetExperienceInfoList(_context));
        }

        [HttpGet]
        public async Task<string> GetExperience(int id)
        {
            return JsonSerializer.Serialize(await _experienceManager.GetExperienceInfo(_context, id));
        }

        [HttpPost]
        public async Task<string> AddOrUpdate(ExperienceInfo model)
        {
            Result result = new Result();
            if (model == null)
            {
                result.Msg = "Nothing to update. Please insert valid data";
                result.Status = "Error";
                return JsonSerializer.Serialize(result);
            }
            else
            {
                result = await _experienceManager.AddOrUpdate(_context, model);
                return JsonSerializer.Serialize(result);

            }
        }
        [HttpPost]
        public async Task<string> DeleteExperience(int Id)
        {
            Result result = new Result();
            if (Id == 0)
            {
                result.Msg = "Nothing to delete. Please select valid data";
                result.Status = "Error";
                return JsonSerializer.Serialize(result);
            }
            else
            {
                result = await _experienceManager.DeleteExperience(_context, Id);
                return JsonSerializer.Serialize(result);

            }
        }
    }
}
