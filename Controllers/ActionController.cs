using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ActivityCenter.Models;

namespace ActivityCenter.Controllers
{
    public class ActionController : Controller
    {
        private MyContext _context;
        public ActionController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("delete/{ActivityId}")]
        public RedirectToActionResult Delete(int ActivityId)
        {
            Activity toDelete = _context.Activities.FirstOrDefault(w => w.ActivityId == ActivityId);
            _context.Remove(toDelete);
            _context.SaveChanges();
            return RedirectToAction("Dashboard", "Home");
        }

        [HttpGet("join/{ActivityId}")]
        public RedirectToActionResult Join(int ActivityId)
        {
            int UserId = (int)HttpContext.Session.GetInt32("UserId");
            UserActivity ActivityList = _context.UserActivities.Include(b => b.Participant).FirstOrDefault(a => a.Participant.UserId == UserId && a.Activity.ActivityId == ActivityId);
            if (ActivityList == null)
            {
                UserActivity NewActivity = new UserActivity { };
                User ExistingUser = _context.Users.FirstOrDefault(u => u.UserId == UserId);
                Activity ExistingActivity = _context.Activities.FirstOrDefault(w => w.ActivityId == ActivityId);
                NewActivity.Participant = ExistingUser;
                NewActivity.Activity = ExistingActivity;
                _context.Add(NewActivity);
            }
            else
            {
                _context.Remove(ActivityList);
            }
            _context.SaveChanges();
            return RedirectToAction("Dashboard", "Home");
        }

        [HttpPost("new")]
        public IActionResult CreateActivity(Activity fromForm)
        {
            Activity Activity = new Activity { };
            if (ModelState.IsValid)
            {
                int UserId = (int)HttpContext.Session.GetInt32("UserId");

                User ExistingUser = _context.Users.FirstOrDefault(u => u.UserId == UserId);

                fromForm.Creator = ExistingUser;

                _context.Add(fromForm);
                _context.SaveChanges();

                UserActivity NewActivity = new UserActivity { };

                Activity ExistingActivity = _context.Activities.FirstOrDefault(w => w.ActivityId == fromForm.ActivityId);

                NewActivity.Participant = ExistingUser;

                NewActivity.Activity = ExistingActivity;
                _context.Add(NewActivity);
                _context.SaveChanges();
                int ActivityId = ExistingActivity.ActivityId;
                return RedirectToAction("Activity", "Home", new { ActivityId = ActivityId});
            }
            return View("NewActivity", Activity);
        }
    }
}