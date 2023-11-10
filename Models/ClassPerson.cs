using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace netMauiEjercicio1_4.Models
{
    public class ClassPerson
    {

        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }

        public byte[] classFhoto { get; set; }
    }
}
