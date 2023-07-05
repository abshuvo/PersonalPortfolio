using DigiPortfoli.Models;
using DigiPortfoli.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DigiPortfoli.Services
{
    public class CategoryManagement
    {

        public async Task<CatagoryInfo> GetCatagoryInfo(DBConfiguration _context, int id)
        {
            return await _context.CatagoryInfo.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<List<CatagoryInfo>> GetCatagoryInfoList(DBConfiguration _context)
        {
            return await _context.CatagoryInfo.ToListAsync();
        }

        public async Task<Result> AddOrUpdate(DBConfiguration _context, CatagoryInfo model)
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
                    CatagoryInfo updateModel = await GetCatagoryInfo(_context, model.Id);
                    updateModel.Name = model.Name;
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
        public async Task<Result> DeleteCategory(DBConfiguration _context, int id)
        {
            CatagoryInfo cat = await GetCatagoryInfo(_context, id);
            _context.CatagoryInfo.Remove(cat);
            _context.SaveChanges();
            Result result = new Result();
            result.Status = "success";
            result.Msg = "Data Deleted Successfully!";
            return result;
        }

    }
}
