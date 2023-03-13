using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlamningDatalagring.MVVM.Models
{
    public class ErrandModel
    {
        public int Id { get; set; } 
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string TimeStamp { get; set; } = null!;
        public string Status { get; set; } = null!;
        public string Comment { get; set; } = null!;
        public int CommentId { get; set; }
    }
}
