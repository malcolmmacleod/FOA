using FOA.Claims.Domain;
using FOA.Claims.Service;
using FOA.Claims.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Website
{
    public class PoliciesApiController : ApiController
    {
        private IPolicyService policyService;


        public PoliciesApiController()
        {
            policyService = new PolicyService();
        }

        public IEnumerable<Policy> Get()
        {
            return policyService.GetPolicies();
        }
    }
}