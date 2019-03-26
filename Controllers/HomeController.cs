using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ukol9.DataObjects;
using ukol9.Models;
using Microsoft.Owin.Security;
using ukol9.Other;

namespace ukol9.Controllers
{
    public class HomeController : Controller
    {
        string txt;


        // GET: Home
        public async Task<ActionResult> Index()
        {
            List<CustomerOrderDO> orders =
                    await CustomerOrderDO.GetOrdersAsync(txt);

            ViewBag.Orders = orders;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(IndexModel model)
        {
            List<CustomerOrderDO> orders =
                await CustomerOrderDO.GetOrdersAsync(model.CustomerID);


            ViewBag.Orders = orders;
            return View();
        }

        [AllowAnonymous]
        public ActionResult LogOn(string returnAddress)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (Url.IsLocalUrl(returnAddress))
                {
                    return Redirect(returnAddress);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ViewBag.ReturnAddress = returnAddress;
                return View();
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LogOn(
            LogOnModel model,
            string returnAddress)
        {
            if (ModelState.IsValid)
            {
                UserManager<IdentityUser> userManager =
                    new UserManager<IdentityUser>(new UserStore());

                var user =
                    await userManager.FindAsync(model.UserName, model.Password);

                if (user != null)
                {
                    HttpContext.GetOwinContext().Authentication.SignOut(
                        DefaultAuthenticationTypes.ExternalCookie);

                    var identity = await userManager.CreateIdentityAsync(
                        user,
                        DefaultAuthenticationTypes.ApplicationCookie);

                    HttpContext.GetOwinContext().Authentication.SignIn(
                        new AuthenticationProperties()
                        {
                            IsPersistent = model.RememberMe
                        },
                        identity);

                    if (Url.IsLocalUrl(returnAddress))
                    {
                        return Redirect(returnAddress);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError(
                        string.Empty,
                        "Invalid user name or password.");
                }
            }

            return View(model);
        }

        public ActionResult LogOff()
        {
            HttpContext.GetOwinContext().Authentication.SignOut();
            return RedirectToAction("Index");
        }

        public ActionResult SecretPage()
        {
            return View();
        }

    }
}