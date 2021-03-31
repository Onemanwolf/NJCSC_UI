using NJCSC.App.UI.poc.DTO;
using NJCSC.App.UI.poc.Models;
using NJCSC.App.UI.poc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace NJCSC.App.UI.poc.Controllers
{
    public class EmploymentApplicationController : Controller
    {
        private EmploymentApplicationService _service;

        public EmploymentApplicationController()
        {
            _service = new EmploymentApplicationService();
        }

        // GET: EmploymentApplication
        public ActionResult Index()
        {
            var empApps = _service.GetAll();

            ViewBag.EmpApplications = empApps.Result.ToList();

            
            return View();
        }

        // GET: EmploymentApplication/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmploymentApplicationController/Create
        [HttpGet]
        public ActionResult Create()
        {
           
                        

            return View();

        }

        // POST: EmploymentApplicationController/Create
        [HttpPost]
        public async Task<ActionResult> Create([Bind(Include = "FirstName, LastName, EmailAddress, PhoneNumber, DateOfBirth")] EmpApplicationModel collection)
        {
            try
            {
                // TODO: Add insert logic here
                await _service.Save(collection);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
      
       public async Task<ActionResult> Edit(int? id)
        {
            if(id == null)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var empApp = await _service.GetById(id);
            return View(empApp);
            
        }

        // POST: EmploymentApplicationController/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit([Bind(Include= "ApplicationId, FirstName, LastName, EmailAddress, PhoneNumber, DateOfBirth, DateCreated")] EmploymentApplicatonDTO collection)
        {
            try
            {
                // TODO: Add update logic here
                await _service.Edit(collection);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

      
       
        // POST: EmploymentApplicationController/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(EmpApplicationModel empApplicaton)
        {
            try
            {
                // TODO: Add delete logic here

                await _service.Delete(empApplicaton);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
