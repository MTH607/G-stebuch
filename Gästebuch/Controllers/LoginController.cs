namespace Gästebuch.Controllers
    {
    using System.Linq;
    using System.Web.Mvc;

    using Gästebuch.Models;

    /// <summary>
    /// Defines the <see cref="LoginController" />.
    /// </summary>
    public class LoginController : Controller
        {
        /// <summary>
        /// Defines the db.
        /// </summary>
        private GästebuchEntities db = new GästebuchEntities();

        /// <summary>
        /// The Index.
        /// </summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult Index()
            {
            return View();
            }

        /// <summary>
        /// The Authorise.
        /// </summary>
        /// <param name="Login">The Login<see cref="tbl_Admin"/>.</param>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [HttpPost]
        public ActionResult Authorise(tbl_Admin Login)
            {
            using(GästebuchEntities db = new GästebuchEntities())
                {
                var userDetails = db.tbl_Admin.Where(x => x.Username == Login.Username && x.Passwort == Login.Passwort).FirstOrDefault();
                if(userDetails == null)
                    {
                    Login.LoginErrorMsg = "Invalid Username or Password";
                    return View("Index", Login);
                    }
                else
                    {
                    Session["rowguid"] = Login.rowguid;
                    return RedirectToAction("Index", "EintragAdmin");
                    }
                }
            }

        /// <summary>
        /// The LogOut.
        /// </summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult LogOut()
            {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
            }
        }
    }