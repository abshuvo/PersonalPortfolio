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
    public class ContentsController : Controller
    {
        private readonly DBConfiguration _context;
        ContentManager _contentManager = new ContentManager();

        public ContentsController(DBConfiguration context)
        {
            _context = context;
        }

        // GET: CatagoryInfoes
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<string> GetAllContent()
        {
            return JsonSerializer.Serialize(await _contentManager.GetContentInfoList(_context));
        }

        [HttpGet]
        public async Task<string> GetContent(int id)
        {
            return JsonSerializer.Serialize(await _contentManager.GetContentInfo(_context, id));
        }

        [HttpPost]
    
        public async Task<string> AddOrUpdate(Content model)
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
                result = await _contentManager.AddOrUpdate(_context, model);
                return JsonSerializer.Serialize(result);

            }
        }
        [HttpPost]
        public async Task<string> DeleteContent(int Id)
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
                result = await _contentManager.DeleteContent(_context, Id);
                return JsonSerializer.Serialize(result);

            }
        }
    }
}
