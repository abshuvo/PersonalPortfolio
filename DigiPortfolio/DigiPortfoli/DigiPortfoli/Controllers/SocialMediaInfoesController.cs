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
    public class SocialMediaInfoesController : Controller
    {
        private readonly DBConfiguration _context;
        SocialMediaManager _socialMediaManager = new SocialMediaManager();

        public SocialMediaInfoesController(DBConfiguration context)
        {
            _context = context;
        }

        // GET: SocialMediaInfoes
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<string> GetAllSocialMedia()
        {
            return JsonSerializer.Serialize(await _socialMediaManager.GetSocialMediaInfoList(_context));
        }

        [HttpGet]
        public async Task<string> GetCategory(int id)
        {
            return JsonSerializer.Serialize(await _socialMediaManager.GetSocialMediaInfo(_context, id));
        }

        [HttpPost]
        public async Task<string> AddOrUpdate(SocialMediaInfo model)
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
                result = await _socialMediaManager.AddOrUpdate(_context, model);
                return JsonSerializer.Serialize(result);

            }
        }
        [HttpPost]
        public async Task<string> DeleteSocialMedia(int Id)
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
                result = await _socialMediaManager.DeleteSocialMedia(_context, Id);
                return JsonSerializer.Serialize(result);

            }
        }
    }
}
