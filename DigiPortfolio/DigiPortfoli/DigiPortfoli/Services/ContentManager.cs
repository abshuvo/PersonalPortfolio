using DigiPortfoli.Models.Entities;
using DigiPortfoli.Models;
using Microsoft.EntityFrameworkCore;
namespace DigiPortfoli.Services
{
    public class ContentManager
    {
        public async Task<Content> GetContentInfo(DBConfiguration _context, int id)
        {
            return await _context.Content.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<List<Content>> GetContentInfoList(DBConfiguration _context)
        {
            return await _context.Content.ToListAsync();
        }

        public async Task<Result> AddOrUpdate(DBConfiguration _context, Content model)
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
                    Content updateModel = await GetContentInfo(_context, model.Id);
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
        public async Task<Result> DeleteContent(DBConfiguration _context, int id)
        {
            Content cat = await GetContentInfo(_context, id);
            _context.Content.Remove(cat);
            _context.SaveChanges();
            Result result = new Result();
            result.Status = "success";
            result.Msg = "Data Deleted Successfully!";
            return result;
        }
    }
}
