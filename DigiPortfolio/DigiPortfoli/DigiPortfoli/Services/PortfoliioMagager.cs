using DigiPortfoli.Models.Entities;
using DigiPortfoli.Models;
using Microsoft.EntityFrameworkCore;

namespace DigiPortfoli.Services
{
    public class PortfolioManager
    {

        public async Task<PortfolioInfo> GetPortfolioInfo(DBConfiguration _context, int id)
        {
            return await _context.PortfolioInfo.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<List<PortfolioInfo>> GetPortfolioInfoList(DBConfiguration _context)
        {
            return await _context.PortfolioInfo.ToListAsync();
        }

        public async Task<Result> AddOrUpdate(DBConfiguration _context, PortfolioInfo model)
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
                    PortfolioInfo updateModel = await GetPortfolioInfo(_context, model.Id);
                    updateModel.Title = model.Title;
                    updateModel.Description = model.Description;            
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
        public async Task<Result> DeletePortfolio(DBConfiguration _context, int id)
        {
            PortfolioInfo cat = await GetPortfolioInfo(_context, id);
            _context.PortfolioInfo.Remove(cat);
            _context.SaveChanges();
            Result result = new Result();
            result.Status = "success";
            result.Msg = "Data Deleted Successfully!";
            return result;
        }
    }
}
