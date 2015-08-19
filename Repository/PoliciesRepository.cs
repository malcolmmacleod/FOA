using FAO.Claims.Repository.Interfaces;
using FOA.Claims.Domain;
using FOA.Claims.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class PoliciesRepository : IPoliciesRepository
    {
        public List<Policy> GetPolicies()
        {
            using (var claimsContext = new ClaimsContext())
            {
                var policies = claimsContext.Policies;

                return policies.ToList();
            }
        }

        public void AddPolicy(Policy policy)
        {
            using (var claimsContext = new ClaimsContext())
            {
                claimsContext.Policies.Add(policy);
                claimsContext.SaveChanges();

            }
        }
    }
}
