using FOA.Claims.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FOA.Claims.Website.Models
{
    public class ClaimViewModel
    {
        public Policy Policy { get; set; }

        public string Narrative { get; set; }

        public decimal Amount { get; set; }

        public List<SelectListItem> PoliciesList { get; set; }
    }
}