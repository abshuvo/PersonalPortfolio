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
    public class ServiceInfoesController : Controller
    {
        private readonly DBConfiguration _context;
        ServiceManager _serviceManager = new ServiceManager();

        public ServiceInfoesController(DBConfiguration context)
        {
            _context = context;
        }

        // GET: ServiceInfoes
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<string> GetAllService()
        {
            return JsonSerializer.Serialize(await _serviceManager.GetServiceInfoList(_context));
        }

        [HttpGet]
        public async Task<string> GetCategory(int id)
        {
            return JsonSerializer.Serialize(await _serviceManager.GetServiceInfo(_context, id));
        }

        [HttpPost]
        public async Task<string> AddOrUpdate(ServiceInfo model)
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
                result = await _serviceManager.AddOrUpdate(_context, model);
                return JsonSerializer.Serialize(result);

            }
        }
        [HttpPost]
        public async Task<string> DeleteService(int Id)
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
                result = await _serviceManager.DeleteService(_context, Id);
                return JsonSerializer.Serialize(result);

            }
        }
    }
}
