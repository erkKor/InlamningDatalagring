using InlamningDatalagring.Contexts;
using InlamningDatalagring.MVVM.Models;
using InlamningDatalagring.MVVM.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlamningDatalagring.Services
{
    public class DataService
    {
        private static DataContext _context = new DataContext();
        private static ObservableCollection<ErrandModel> errands;

        public DataService()
        {
            _context = new DataContext();
        }

        public static async Task AddErrandAsync(ErrandModel model)
        {   
            var _errand = new Errand
            {
                Description = model.Description,
                TimeStamp = model.TimeStamp,
                StatusId = 1,
            };

            var _contact = await _context.Contacts.FirstOrDefaultAsync(x => x.Email == model.Email);
            if (_contact != null)
                _errand.ContactId = _contact.Id;
            else
                _errand.Contact = new Contact
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                };

            _context.Add(_errand);
            await _context.SaveChangesAsync();
        }




        public static async Task<ObservableCollection<ErrandModel>> GetAllErrandsAsync()
        {
            errands = new ObservableCollection<ErrandModel>();

            foreach (var _errands in await _context.Errands.Include(x => x.Contact).Include(s => s.Status).Include(c => c.Comments).ToListAsync())
                errands.Add(new ErrandModel
                {
                    Id = _errands.Id,
                    FirstName = _errands.Contact.FirstName,
                    LastName = _errands.Contact.LastName,
                    Email = _errands.Contact.Email,
                    PhoneNumber = _errands.Contact.PhoneNumber,
                    Description = _errands.Description,
                    TimeStamp = _errands.TimeStamp,
                    Status = _errands.Status.StatusType,
                    Comments = _errands.Comments,
                    CommentId = _errands.CommentsId,
                    ContactId = _errands.ContactId

                });
            StaticDataService.ErrandsList = errands;
            return errands;
        }

        public static async Task UpdateStatusAsync(ErrandModel model, string status)
        {   
            var _errand = await _context.Errands.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (_errand != null)
            {
                switch(status)
                {
                    case "Ej Påbörjad":
                        _errand.StatusId = 1;
                        _context.Update(_errand);
                        await _context.SaveChangesAsync();
                        break;
                    case "Pågående":
                        _errand.StatusId = 2;
                        _context.Update(_errand);
                        await _context.SaveChangesAsync();
                        break;
                    case "Avslutad":
                        _errand.StatusId = 3;
                        _context.Update(_errand);
                        await _context.SaveChangesAsync();
                        break;
                }
            }
        }


        public async Task AddCommentAsync(string comment, int commentId)
        {
            var _errand = await _context.Errands.FirstOrDefaultAsync(x => x.Id == commentId);
            if (_errand != null)
                if (_errand.CommentsId == 0)
                {
                    _errand.CommentsId = commentId;
                    _context.Update(_errand);
                }

            var _comment = new Comments
            {
                ErrandId = commentId,
                Comment = comment,
                TimeStamp = DateTime.UtcNow.ToString("yyyy-MM-dd hh:mm")
            };

            _context.Add(_comment);
            await _context.SaveChangesAsync();
        }

    }
}
