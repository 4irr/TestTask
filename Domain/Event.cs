using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Speaker { get; set; } = null!;
        public DateTime dateTime { get; set; }
        public string Place { get; set; } = null!;
    }
}
