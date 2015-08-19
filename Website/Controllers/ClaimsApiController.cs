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
    public class ClaimsApiController : ApiController
    {
        private IClaimsService claimsService;

        public ClaimsApiController()
        {
            claimsService = new ClaimsService();
        }

        public IEnumerable<Claim> Get()
        {
            return claimsService.GetClaims();
        }

        // POST api/<controller>
        public void Post([FromBody]Claim claim)
        {
            var errors = claimsService.AcceptClaim(claim);
        }
    }
}