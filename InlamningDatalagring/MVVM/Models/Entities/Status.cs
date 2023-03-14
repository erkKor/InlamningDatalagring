using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlamningDatalagring.MVVM.Models.Entities
{
    public class Status
    {
        public int Id { get; set; }
        public string StatusType { get; set; } = null!;

        public virtual ICollection<Errand> Errands { get; } = new List<Errand>();
    }
}
