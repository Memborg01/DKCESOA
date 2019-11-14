using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public class Transaction
    {
            public int Id { get; set; }
            public int PacketId { get; set; }
            public string Routes { get; set; }
            public DateTime Date { get; set; }
    }
}