﻿namespace Gästebuch.Controllers
    {
    using System.Web.Mvc;

    /// <summary>
    /// Defines the <see cref="HomeController" />.
    /// </summary>
    public class HomeController : Controller
        {
        /// <summary>
        /// The Index.
        /// </summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        public ActionResult Index()
            {
            return View();
            }
        }
    }
