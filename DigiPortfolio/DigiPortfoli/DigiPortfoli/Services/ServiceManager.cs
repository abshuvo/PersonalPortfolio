using DigiPortfoli.Models.Entities;
using DigiPortfoli.Models;
using Microsoft.EntityFrameworkCore;

namespace DigiPortfoli.Services
{
    public class ServiceManager
    {

        public async Task<ServiceInfo> GetServiceInfo(DBConfiguration _context, int id)
        {
            return await _context.ServiceInfo.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<List<ServiceInfo>> GetServiceInfoList(DBConfiguration _context)
        {
            return await _context.ServiceInfo.ToListAsync();
        }

        public async Task<Result> AddOrUpdate(DBConfiguration _context, ServiceInfo model)
        {
            Result result = new Result();

            try
            {
                if (model.Id == 0)
                {
                    _context.Add(model);
                    _context.SaveChanges();
                    result.Msg = "Data inserted successfully!";
                    result.Status = "success";
                }
                else
                {
                    ServiceInfo updateModel = await GetServiceInfo(_context, model.Id);
                    updateModel.Title = model.Title;
                    updateModel.description = model.description;
                    updateModel.Icon=model.Icon;
                    _context.Update(updateModel);
                    _context.SaveChanges();
                    result.Msg = "Data updated successfully!";
                    result.Status = "success";
                }
            }
            catch (Exception ex)
            {
                result.Msg = ex.Message;
                result.Status = "error";
            }
            return result;

        }
        public async Task<Result> DeleteService(DBConfiguration _context, int id)
        {
            ServiceInfo cat = await GetServiceInfo(_context, id);
            _context.ServiceInfo.Remove(cat);
            _context.SaveChanges();
            Result result = new Result();
            result.Status = "success";
            result.Msg = "Data Deleted Successfully!";
            return result;
        }
    }
}
