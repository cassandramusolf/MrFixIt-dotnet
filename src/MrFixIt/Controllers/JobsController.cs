using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MrFixIt.Models;
using Microsoft.EntityFrameworkCore;

namespace MrFixIt.Controllers
{
    public class JobsController : Controller
    {
        private MrFixItContext db = new MrFixItContext();

        //Return the Index view with a list of jobs including the worker if the job is claimed.
        public IActionResult Index()
        {
            return View(db.Jobs.Include(i => i.Worker).ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        //Create a new job and save to the database.
        [HttpPost]
        public IActionResult Create(Job job)
        {
            db.Jobs.Add(job);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Return view of the job that was clicked on
        public IActionResult Claim(int id)
        {
            var thisItem = db.Jobs.FirstOrDefault(items => items.JobId == id);
            return View(thisItem);
        }

        //Add claimed job to specific worker and save
        [HttpPost]
        public IActionResult Claim(Job job)
        {
            job.Worker = db.Workers.FirstOrDefault(i => i.UserName == User.Identity.Name);
            db.Entry(job).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Completed(int id)
        {
            var thisItem = db.Jobs.FirstOrDefault(items => items.JobId == id);
            return Content("Hello from the controller!", "text/plain");
        }


        public IActionResult Edit(int id)
        {
            Job thisJob = db.Jobs.FirstOrDefault(items => items.JobId == id);
            return View(thisJob);
        }


    }
}
