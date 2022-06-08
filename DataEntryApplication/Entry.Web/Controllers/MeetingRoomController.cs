using Entry.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Entry.Web.Controllers
{
    public class MeetingRoomController : Controller
    {
        // GET: MeetingRoom
        public ActionResult Index()
        {
            var model = new MeetingRoomViewModel();
            return View(model.Get());
            
        }

        // GET: MeetingRoom/Details/5
        public ActionResult Details(int id)
        {
            var model = new MeetingRoomViewModel();
            return View(model.GetSingle(id));
        }

        // GET: MeetingRoom/Create
        public ActionResult Create()
        {
            return View(new MeetingRoomViewModel());
        }

        // POST: MeetingRoom/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, MeetingRoomViewModel meetingroomViewModel)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    meetingroomViewModel.Save();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MeetingRoom/Edit/5
        public ActionResult Edit(int id)
        {
            var model = new MeetingRoomViewModel();

            return View(model.GetSingle(id));
        }

        // POST: MeetingRoom/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection, MeetingRoomViewModel meetingRoomViewModel)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    meetingRoomViewModel.Save();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MeetingRoom/Delete/5
        public ActionResult Delete(int id)
        {
            var model = new MeetingRoomViewModel();
            var meetingRoommViewModel = model.GetSingle(id);

            return View(meetingRoommViewModel);
        }

        // POST: MeetingRoom/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection,MeetingRoomViewModel model)
        {
            try
            {
                // TODO: Add delete logic here
                model.DeleteMeetingRoom(id);
                return RedirectToAction("Index");
            }
            catch
            {
                var meetingRoomViewModel = model.GetSingle(id);
                return View(meetingRoomViewModel);
            }
        }
    }
}
