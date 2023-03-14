using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlamningDatalagring.MVVM.Models.Entities
{
    public class Comments
    {
        public int Id { get; set; }
        public string Comment { get; set; } = null!;
        public int ErrandId { get; set; }
        public virtual Errand Errand { get; set; } = null!;
    }

}
