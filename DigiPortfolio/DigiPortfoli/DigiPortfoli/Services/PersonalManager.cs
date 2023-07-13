using DigiPortfoli.Models.Entities;
using DigiPortfoli.Models;
using Microsoft.EntityFrameworkCore;

namespace DigiPortfoli.Services
{
    public class PersonalManager
    {

        public async Task<PersonalInfo> GetPersonalInfo(DBConfiguration _context, int id)
        {
            return await _context.PersonalInfo.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<List<PersonalInfo>> GetPersonalInfoList(DBConfiguration _context)
        {
            return await _context.PersonalInfo.ToListAsync();
        }

        public async Task<Result> AddOrUpdate(DBConfiguration _context, PersonalInfo model)
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
                    PersonalInfo updateModel = await GetPersonalInfo(_context, model.Id);
                    updateModel.Name = model.Name;
                    updateModel.Profession = model.Profession;
                    updateModel.Birthdate = model.Birthdate;
                    updateModel.Age = model.Age;
                    updateModel.Mobile = model.Mobile;
                    updateModel.Email = model.Email;
                    updateModel.Address = model.Address;
                    updateModel.Qualification = model.Qualification;
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
        public async Task<Result> DeletePersonal(DBConfiguration _context, int id)
        {
            PersonalInfo cat = await GetPersonalInfo(_context, id);
            _context.PersonalInfo.Remove(cat);
            _context.SaveChanges();
            Result result = new Result();
            result.Status = "success";
            result.Msg = "Data Deleted Successfully!";
            return result;
        }
    }
}
