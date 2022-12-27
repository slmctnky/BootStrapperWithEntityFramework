using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Data.nDatabaseService.nDatabase
{
    public class cBaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public cBaseEntity()
        {
            CreateDate = DateTime.Now;
            UpdateDate = DateTime.Now;
        }
    }
}
