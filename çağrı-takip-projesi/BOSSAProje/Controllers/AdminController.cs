using BOSSAProje.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace BOSSAProje.Controllers
{
    [Authorize(Roles = "Admin")] // This ensures that only users with the "User" role can access this action.
    public class AdminController : Controller
    {
        public ActionResult AdminPage()
        {
            // Logic for the admin page goes here.
            return View();
        }
    }
}