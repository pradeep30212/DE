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
        private ApplicationDbContext applicationDbContext;

        [Key]

        public int MeetingRoomId { get; set; }
        [Required(ErrorMessage = "Meeting room name is mandatory.")]
        public string MeetingRoomName { get; set; }


        public MeetingRoomViewModel() : this(new ApplicationDbContext())
        {
            //x = 200;
            // constant - you can not intialize anywhere. YOu need to intialize at the time declaration.
            // readonly - at the time of declaration and another inside a constructor.
        }

        public MeetingRoomViewModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public MeetingRoomViewModel Get()
        {
            MeetingRooms = GetMeetingRooms();
            return this;
        
        }

        private IEnumerable<MeetingRoomViewModel> GetMeetingRooms()
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
            var meetingRoom = _dbContext.MeetingRooms.FirstOrDefault(x => x.MeetingRoomId == id);

            _dbContext.MeetingRooms.Remove(meetingRoom);

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

       // internal MeetingRoomViewModel Get()

        //{
           // MeetingRooms = GetMeetingRoom();
           // return this;
            
       // }

        /*private IEnumerable<MeetingRoomViewModel> GetMeetingRoom()
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
        }*/

        public IEnumerable<MeetingRoomViewModel> MeetingRooms { get; set; }
    }
}