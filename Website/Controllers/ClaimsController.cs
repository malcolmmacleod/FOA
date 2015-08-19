using FOA.Claims.Domain;
using FOA.Claims.Service;
using FOA.Claims.Service.Interfaces;
using FOA.Claims.Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Website.Controllers
{
    public class ClaimsController : Controller
    {
        private IClaimsService claimsService;
        private IPolicyService policyService;


        public ClaimsController()
        {
            policyService = new PolicyService();
            claimsService = new ClaimsService();
        }

        //
        // GET: /Claims/

        public ActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public ActionResult New()
        {
            var claim = new Claim();

            return View(claim);
        }

        [HttpPost]
        public ActionResult New(ClaimViewModel claim)
        {
            return View(claim);
        }
    }
}
