using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Entry.Web.Entities
{
    public class MeetingRoom
    {
        [Key]
        
        public int MeetingRoomId { get; set; }
        public string MeetingRoomName { get; set; }
    }
}