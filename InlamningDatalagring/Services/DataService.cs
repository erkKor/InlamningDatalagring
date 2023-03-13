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

        public static async Task SaveAsync(ErrandModel model)
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

            model.Comment = "Skapat";
            _errand.Comments = new Comments
            {
                Comment = model.Comment
            };

            _context.Add(_errand);
            await _context.SaveChangesAsync();
        }




        public static async Task<ObservableCollection<ErrandModel>> GetAllAsync()
        {
            errands = new ObservableCollection<ErrandModel>();

            foreach (var _errands in await _context.Errands.Include(x => x.Contact).Include(s => s.Status).Include(p => p.Comments).ToListAsync())
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
                    Comment = _errands.Comments.Comment,
                    CommentId = _errands.CommentsId
                });
            StaticDataService.ErrandsList = errands;
            return errands;
        }

        public static async Task UpdateStatus(ErrandModel model, string status)
        {   
            //.Include(c => c.Contact).Include(s => s.Status).Include(c => c.Comments).
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
                    

                //_errand.Status.StatusType = status;
                //_errand.Contact = _errand.Contact;



                //_context.Update(_errand);
                //await _context.SaveChangesAsync();
            }
        }


        public async Task AddCommentAsync(string comment, int commentId)
        {
            var _comment = new Comments
            {
                Id = commentId,
                Comment = comment
            };

            _context.Add(_comment);
            await _context.SaveChangesAsync();
        }


        //public static async Task UpdateAsync(CustomerModel model)
        //{
        //    var _customer = await _context.Customers.Include(x => x.Adress).FirstOrDefaultAsync(x => x.Id == model.Id);
        //    if (_customer != null)
        //    {
        //        if (!string.IsNullOrEmpty(model.StreetName) || !string.IsNullOrEmpty(model.PostalCode) || !string.IsNullOrEmpty(model.City))
        //        {
        //            var _adress = await _context.Adresses.FirstOrDefaultAsync(x => x.StreetName == model.StreetName && x.PostalCode == model.PostalCode && x.City == model.City);
        //            if (_adress != null)
        //                _customer.AdressId = _adress.Id;
        //            else
        //            {
        //                var adress = new Adress
        //                {
        //                    StreetName = model.StreetName,
        //                    PostalCode = model.PostalCode,
        //                    City = model.City,
        //                };
        //                _context.Add(adress);
        //                await _context.SaveChangesAsync();

        //                _customer.AdressId = adress.Id;
        //            }

        //        }



        //        if (!string.IsNullOrEmpty(model.FirstName))
        //            _customer.FirstName = model.FirstName;

        //        if (!string.IsNullOrEmpty(model.LastName))
        //            _customer.LastName = model.LastName;

        //        if (!string.IsNullOrEmpty(model.Email))
        //            _customer.Email = model.Email;

        //        if (!string.IsNullOrEmpty(model.PhoneNumber))
        //            _customer.PhoneNumber = model.PhoneNumber;




        //        _context.Update(_customer);
        //        await _context.SaveChangesAsync();
        //    }
        //}


        //public static async Task DeleteAsync(string email)
        //{
        //    var customer = await _context.Customers.Include(x => x.Adress).FirstOrDefaultAsync(x => x.Email == email);
        //    if (customer != null)
        //    {
        //        _context.Remove(customer);
        //        await _context.SaveChangesAsync();
        //    }
        //}




        //public static async Task<CustomerModel> GetAsync(string email)
        //{
        //    var _customer = await _context.Customers.Include(x => x.Adress).FirstOrDefaultAsync(x => x.Email == email);
        //    if (_customer != null)
        //        return new CustomerModel
        //        {
        //            Id = _customer.Id,
        //            FirstName = _customer.FirstName,
        //            LastName = _customer.LastName,
        //            Email = _customer.Email,
        //            PhoneNumber = _customer.PhoneNumber,
        //            StreetName = _customer.Adress.StreetName,
        //            PostalCode = _customer.Adress.PostalCode,
        //            City = _customer.Adress.City,
        //        };

        //    else
        //        return null!;
        //}

    }
}
