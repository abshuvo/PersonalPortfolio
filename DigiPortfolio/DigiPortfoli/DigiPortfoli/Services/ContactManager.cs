using DigiPortfoli.Models;
using DigiPortfoli.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DigiPortfoli.Services
{
    public class ContactManager
    {

        public async Task<ContactMessage> GetContactInfo(DBConfiguration _context, int id)
        {
            return await _context.ContactMessage.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<List<ContactMessage>> GetContactInfoList(DBConfiguration _context)
        {
            return await _context.ContactMessage.ToListAsync();
        }

        public async Task<Result> AddOrUpdate(DBConfiguration _context, ContactMessage model)
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
                    ContactMessage updateModel = await GetContactInfo(_context, model.Id);
                    updateModel.Name = model.Name;
                    updateModel.Email = model.Email;
                    updateModel.Subject = model.Subject;
                    updateModel.Message = model.Message;
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
        public async Task<Result> DeleteContact(DBConfiguration _context, int id)
        {
            ContactMessage cat = await GetContactInfo(_context, id);
            _context.ContactMessage.Remove(cat);
            _context.SaveChanges();
            Result result = new Result();
            result.Status = "success";
            result.Msg = "Data Deleted Successfully!";
            return result;
        }

    }
}
