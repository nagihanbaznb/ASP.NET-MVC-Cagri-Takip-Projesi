using BOSSAProje.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BOSSAProje.Controllers
{

    public class AccountController : Controller
    {
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            // Here, you should implement the logic to validate the username and password.
            // Replace the placeholder logic with your actual authentication logic.

            // For demonstration purposes, let's assume we have a variable "isUser" that
            // indicates if the user is an admin or not. You can replace this with your own logic.
            bool isUser = true; // Set it to "false" if the user is not an admin.

            // Assuming you have separate "UserPage" and "AdminPage" actions in other controllers,
            // you can redirect accordingly based on the user's status.
            if (isUser)
            {
                return RedirectToAction("Giris", "Home"); // Redirect to the user page.
            }
            else
            {
                return RedirectToAction("AdminPage", "Home"); // Redirect to the admin page.
            }
        }
    }

}