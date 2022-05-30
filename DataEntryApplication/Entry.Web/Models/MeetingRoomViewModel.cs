using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Entry.Web.Models
{
    public class MeetingRoomViewModel

    {
        private readonly ApplicationDbContext _dbContext = new ApplicationDbContext();
        [Key]

        public int MeetingRoomId { get; set; }
        [Required(ErrorMessage = "Meeting room name is mandatory.")]
        public string MeetingRoomName { get; set; }

        internal void Save()
        {
            if (MeetingRoomId == 0)
            {
                _dbContext.MeetingRooms.Add(new Entities.MeetingRoom
                {
                    MeetingRoomName = MeetingRoomName,
                    MeetingRoomId = MeetingRoomId,
                    
                });
            }
            else
            {
                var meetingRoom = _dbContext.MeetingRooms.FirstOrDefault(x => x.MeetingRoomId == MeetingRoomId);

                meetingRoom.MeetingRoomId = MeetingRoomId;
                meetingRoom.MeetingRoomName = MeetingRoomName;
                
            }

            _dbContext.SaveChanges();
        }

        internal void DeleteMeetingRoom(int id)
        {
            var meetingRoom = _dbContext.Employees.FirstOrDefault(x => x.EmployeeId == id);

            _dbContext.Employees.Remove(meetingRoom);

            _dbContext.SaveChanges();
        }
        internal MeetingRoomViewModel GetSingle(int id)
        {
            var meetingRoom = _dbContext.MeetingRooms.FirstOrDefault(x => x.MeetingRoomId == id);

            
            MeetingRoomViewModel meetingRoomViewModel = null;

            if (meetingRoom != null)
            {
                meetingRoomViewModel = new MeetingRoomViewModel 
                {
                    MeetingRoomId = meetingRoom.MeetingRoomId,
                    MeetingRoomName= meetingRoom.MeetingRoomName
                    
                };
            }

            return meetingRoomViewModel;
        }

        internal MeetingRoomViewModel Get()

        {
            MeetingRooms = GetMeetingRoom();
            return this;
            
        }

        private IEnumerable<MeetingRoomViewModel> GetMeetingRoom()
        {
            var meetingRooms = new List<MeetingRoomViewModel>();

            var list = _dbContext.MeetingRooms.ToList();

            foreach (var meetingRoom in list)
            {
                meetingRooms.Add(new MeetingRoomViewModel
                {
                    MeetingRoomId = meetingRoom.MeetingRoomId,
                    MeetingRoomName = meetingRoom.MeetingRoomName,
                    
                });
            }

            return meetingRooms;
        }

        public IEnumerable<MeetingRoomViewModel> MeetingRooms { get; set; }
    }
}