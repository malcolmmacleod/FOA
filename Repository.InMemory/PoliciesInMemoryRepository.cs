using FAO.Claims.Repository.Interfaces;
using FOA.Claims.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FAO.Claims.Repository.InMemory
{
    public class PoliciesInMemoryRepository : IPoliciesRepository
    {
        private static List<Policy> policies = new List<Policy>();

        public PoliciesInMemoryRepository()
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

            policies.Add(policy);
        }

        public void AddPolicy(Policy policy)
        {
            policies.Add(policy);
        }

        public List<Policy> GetPolicies()
        {
            return policies;
        }
    }
}
