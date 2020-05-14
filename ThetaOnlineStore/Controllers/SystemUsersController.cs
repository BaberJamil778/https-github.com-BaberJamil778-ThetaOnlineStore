using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using ThetaOnlineStore.Models;

namespace ThetaOnlineStore.Controllers
{
    public class SystemUsersController : Controller
    {
        data01Context orm= null;

        public SystemUsersController(data01Context _orm)
        {

            orm = _orm;

        }




        [HttpGet]
        public IActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public async   Task<IActionResult> Register(SystemUser s)
        {
            orm.SystemUser.Add(s);
             await  orm.SaveChangesAsync();

            ViewBag.Message = s.Username + " System User Successfully Register in the Database";
            return View();
        }

        public IActionResult AllSystemUsers()
        {
            IList<SystemUser> IL = orm.SystemUser.ToList<SystemUser>();


            return View(IL);
        }
        public async Task<IActionResult> Details(int Id)
        {
            SystemUser s1 = await orm.SystemUser.FindAsync(Id);

            return View(s1);

        }
        public async Task<IActionResult> Delete(int Id)
        {

            SystemUser s2 = await orm.SystemUser.FindAsync(Id);
            if (s2 != null)
            {
                orm.SystemUser.Remove(s2);
                orm.SaveChanges();
                return RedirectToAction("AllSystemUsers");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            return View(await orm.SystemUser.FindAsync(Id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(SystemUser s)
        {
            orm.SystemUser.Update(s);
            await  orm.SaveChangesAsync();
            return RedirectToAction("AllSystemUsers");
        }

    }
}