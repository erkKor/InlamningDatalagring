using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace InlamningDatalagring.MVVM.Models.Entities
{
    // 4 Olika tabeller,
    // 1. Description, timestamp
    // 2. Status
    // 3. Kontaktuppgifter
    // 4. Kommentarer
    internal class Errand
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int ContactId { get; set; }
        public string Description { get; set; } = null!;
        public string TimeStamp { get; set; } = null!;
        public int StatusId { get; set; }
        public int CommentsId { get; set; }
    }
}
