using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Meetups.Queries.GetMeetupsList
{
    public class MeetupsListVm
    {
        public IList<MeetupLookupDto>? Meetups { get; set; }
    }
}
