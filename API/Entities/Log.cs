using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Log
    {
        public Log(int id, int batchId, string change, string timeStamp)
        {
            Id = id;
            BatchId = batchId;
            Change = change;
            TimeStamp = timeStamp;
        }

        public int Id { get; set; }

        public int BatchId { get; set; }

        public string Change { get; set; }

        public string TimeStamp { get; set; }
    }
}