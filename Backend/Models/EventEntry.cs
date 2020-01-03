using System;
using System.ComponentModel.DataAnnotations;

namespace SBA.Expense.Models
{
    public class EventEntry
    {
        
        public Guid ID { get; set; }

        public string Payload { get; set; }
        
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}