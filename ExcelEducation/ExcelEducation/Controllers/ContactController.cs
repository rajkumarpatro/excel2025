using DAL;
using DAL.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ExcelEducation.Controllers
{
    public class ContactController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new ContactUS());
        }

         
        [HttpGet]
        public async Task<ActionResult> LoadContactList()
        {
            try
            {
                var data = await ContactusDB.LoadContact();
                return Json(new { data = data }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { data = new List<ContactUS>(), error = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        
        [HttpPost]
        public async Task<ActionResult> addEditDeleteRecord(ContactUS contact)
        {
            try
            {
                bool result = await ContactusDB.AddContact(contact);

                if (result)
                {
                    return Json(new { success = true, message = "Data Inserted Successfully!" });
                }
                else
                {
                    return Json(new { success = false, message = "Insert Failed!" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult Index(ContactUS model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Please fill all required fields!";
                return RedirectToAction("Index");
            }

            try
            {
                using (IDbConnection db = new SqlConnection(
                    ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    string query = @"INSERT INTO ContactUS
                        (Name, Email, Phone, Subject, Message)
                        VALUES
                        (@Name, @Email, @Phone, @Subject, @Message)";

                    int rows = db.Execute(query, model);

                    if (rows > 0)
                    {
                        return Json(new { message = "Message Send Successfully!" });
                    }
                    else
                    {
                        return Json(new { message = "Message Send failed!" });
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = "ERROR: " + ex.Message;
            }

            return RedirectToAction("Index");
        }
        public ActionResult ContactList()
        {
            return View("ContactList");
        }
    }
}