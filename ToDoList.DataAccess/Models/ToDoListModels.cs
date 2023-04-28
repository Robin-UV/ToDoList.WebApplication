using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.DataAccess.Models
{
    public class ToDoListModels
    {
        public int TaskID { get; set; }
        public string TaskName { get; set; } = null!; 
        public string? TaskDescription { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime CompletedDate { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsArchived { get; set; }
    }
}
