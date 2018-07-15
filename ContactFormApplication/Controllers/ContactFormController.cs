using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using ContactFormApplication.Models;
using System.Data.Entity.Infrastructure;


namespace ContactFormApplication.Controllers
{
    public class contactControllerController : ApiController
    {
        contactFormDBEntities db = new contactFormDBEntities();
        List<sp_ContactProcedure_Result> cnctlist = new List<sp_ContactProcedure_Result>();


        [HttpGet]
        public List<contactDetail> Get()
        {
            List<contactDetail> cnctlist = new List<contactDetail>();


            var results = db.sp_ContactProcedure(0, "", "", "", "", 0, "Get").ToList();
            foreach (var item in results)
            {
                var contactdetail = new contactDetail()
                {
                    id = item.id,
                    firstName = item.firstName,
                    lastName = item.lastName,
                    email = item.email,
                    phoneNumber = item.phoneNumber,
                    status = item.status
                };
                cnctlist.Add(contactdetail);
            }
            return cnctlist;

        }

        public contactDetail Get(int id)
        {

            contactDetail obj_contactdetail = db.contactDetails.Find(id);
            if (obj_contactdetail == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return obj_contactdetail;

        }

        public HttpResponseMessage Post(contactDetail obj_contactdetail)
        {
            if (ModelState.IsValid)
            {
                var cntlist = db.sp_ContactProcedure(0, obj_contactdetail.firstName, obj_contactdetail.lastName, obj_contactdetail.email, obj_contactdetail.phoneNumber, obj_contactdetail.status, "Ins").ToList();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, cntlist);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        public HttpResponseMessage Put(contactDetail obj_contactdetail)
        {
            
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            try
            {
                cnctlist = db.sp_ContactProcedure(obj_contactdetail.id, obj_contactdetail.firstName, obj_contactdetail.lastName, obj_contactdetail.email, obj_contactdetail.phoneNumber, obj_contactdetail.status, "Upd").ToList();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, cnctlist);
        }

        public HttpResponseMessage Delete(int id)
        {
            
                var results = db.sp_ContactProcedure(id, "", "", "", "", 0, "GetById").ToList();
                if (results.Count == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                try
                {
                    cnctlist = db.sp_ContactProcedure(id, "", "", "", "", 0, "Del").ToList();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
                }
                return Request.CreateResponse(HttpStatusCode.OK, cnctlist);
         
        }

        protected override void Dispose(bool disposing)
        {          
            db.Dispose();
            base.Dispose(disposing);
        }  
    }
}
