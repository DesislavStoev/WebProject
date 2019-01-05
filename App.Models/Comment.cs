using System;

namespace App.Models
{
    public class Comment : BaseModel<int>
    {
        public DateTime Date { get; set; }

        public string Content { get; set; }

        public virtual Recipe Recipe { get; set; }
    }
}
