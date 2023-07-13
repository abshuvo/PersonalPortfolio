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
    public class PersonalInfoesController : Controller
    {
        private readonly DBConfiguration _context;
        PersonalManager _personalManager = new PersonalManager();

        public PersonalInfoesController(DBConfiguration context)
        {
            _context = context;
        }

        // GET: PersonalInfoes
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<string> GetAllPersonal()
        {
            return JsonSerializer.Serialize(await _personalManager.GetPersonalInfoList(_context));
        }

        [HttpGet]
        public async Task<string> GetCategory(int id)
        {
            return JsonSerializer.Serialize(await _personalManager.GetPersonalInfo(_context, id));
        }

        [HttpPost]
        public async Task<string> AddOrUpdate(PersonalInfo model)
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
                result = await _personalManager.AddOrUpdate(_context, model);
                return JsonSerializer.Serialize(result);

            }
        }
        [HttpPost]
        public async Task<string> DeletePersonal(int Id)
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
                result = await _personalManager.DeletePersonal(_context, Id);
                return JsonSerializer.Serialize(result);

            }
        }
    }
}
