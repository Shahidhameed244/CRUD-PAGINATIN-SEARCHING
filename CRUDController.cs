using PagedList;
using Session4.Models;
using System;
using PagedList.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Session4.Controllers
{
    public class CRUDController : Controller
    {
        Users users = new Users();
        DBACESS db = new DBACESS();
        // GET: CRUD
        public ActionResult AddNewUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddNewUser(Users u)
        {
            db.OpenCon();
            string query = "insert into USERS values ('"+u.name+"','"+u.email+"','"+u.password+"','"+u.role+"')";
            db.InsertUpdateDelete(query);
            db.CloseCon();
            return View();
        }
        public ActionResult ShowAllUsers(int? i)
        {           
            return View(users.GetAllUsers().ToList().ToPagedList(i ?? 1, 3));
        }
        public ActionResult searching(string search)
        {
            return View(users.SearchUser(search).ToList());
        }
        public ActionResult DeleteUser(int id)
        {
            db.OpenCon();
            String query = "Delete from USERS where id='" + id + "'";
            db.InsertUpdateDelete(query);
            return RedirectToAction("ShowAllUsers");
            db.CloseCon();

        }
        public ActionResult Details(int id)
        {
            return View(users.Detials(id));
        }
        public ActionResult EditUser(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult EditUser(Users u)
        {
            db.OpenCon();
            string q = "update USERS set NAME ='"+u.name+ "',EMAIL = '"+u.email+ "',PASSWORD='"+u.password+ "',ROLE='"+u.role+ "' where ID ='"+u.id+"' ";
            db.InsertUpdateDelete(q);
            db.CloseCon();
            return RedirectToAction("ShowAllUsers");
        }
    }
}