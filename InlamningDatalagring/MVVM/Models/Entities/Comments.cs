using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlamningDatalagring.MVVM.Models.Entities
{
    internal class Comments
    {
        public int Id { get; set; }
        public string Comment { get; set; } = null!;
        public virtual ICollection<Errand> Errands { get; } = new List<Errand>();
    }

}
