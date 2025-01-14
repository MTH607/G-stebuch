﻿namespace Gästebuch
    {
    using System.Web.Optimization;

    /// <summary>
    /// Defines the <see cref="BundleConfig" />.
    /// </summary>
    public class BundleConfig
        {
        /// <summary>
        /// The RegisterBundles.
        /// </summary>
        /// <param name="bundles">The bundles<see cref="BundleCollection"/>.</param>
        public static void RegisterBundles(BundleCollection bundles)
            {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            }
        }
    }
