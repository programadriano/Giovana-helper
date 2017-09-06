using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerMachine.Models
{
    public class Machine
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public DateTime DtUpdate { get; set; }
    }
}
