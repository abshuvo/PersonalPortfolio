using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DigiPortfoli.Models;
using DigiPortfoli.Models.Entities;
using System.Text.Json;
using DigiPortfoli.Services;

namespace DigiPortfoli.Controllers
{
    public class ContactMessagesController : Controller
    {
        private readonly DBConfiguration _context;
        ContactManager _contactManager = new ContactManager();

        public ContactMessagesController(DBConfiguration context)
        {
            _context = context;
        }

        // GET: CatagoryInfoes
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<string> GetAllContact()
        {
            return JsonSerializer.Serialize(await _contactManager.GetContactInfoList(_context));
        }

        [HttpGet]
        public async Task<string> GetContact(int id)
        {
            return JsonSerializer.Serialize(await _contactManager.GetContactInfo(_context, id));
        }

        [HttpPost]
        public async Task<string> AddOrUpdate(ContactMessage model)
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
                result = await _contactManager.AddOrUpdate(_context, model);
                return JsonSerializer.Serialize(result);

            }
        }
        [HttpPost]
        public async Task<string> DeleteContact(int Id)
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
                result = await _contactManager.DeleteContact(_context, Id);
                return JsonSerializer.Serialize(result);

            }
        }

    }
}

