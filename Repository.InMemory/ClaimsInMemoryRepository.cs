using FAO.Claims.Repository.Interfaces;
using FOA.Claims.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FAO.Claims.Repository.InMemory
{
    public class ClaimsInMemoryRepository : IClaimsRepository
    {
        private static List<Claim> claims = new List<Claim>();

        public ClaimsInMemoryRepository()
        { 
            var policy = new Policy
            {
                ContactInfo = "Test Name",
                Closed = null,
                Description = "Test Description",
                HolderName = "Test Holder",
                InsuredAmount = 1000M,
                PaidToDate = 500M,
                PolicyType = Coverage.Extended,
                Premium = 30M,
                StartDate = DateTime.Today.AddYears(-1)
            };


            var claim = new Claim
            {
                Amount = 100M,
                Issued = DateTime.Today,
                Narrative = "test narrative",
                Paid = null,
                Policy = policy
            };

            claims.Add(claim);
        }

        public void AddClaim(Claim claim)
        {
            claims.Add(claim);
        }

        public List<Claim> GetClaims()
        {
            return claims;
        }
    }
}
