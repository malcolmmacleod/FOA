using FOA.Claims.Domain;
using FOA.Claims.Repository;
using FOA.Claims.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repository;
using FAO.Claims.Repository.Interfaces;
using FAO.Claims.Repository.InMemory;

namespace FOA.Claims.Service
{
    public class PolicyService : IPolicyService
    {
        private IPoliciesRepository policiesRepository;

        public PolicyService()
        {
            // TODO : DI
            policiesRepository = new PoliciesRepository();
        }

        public List<Policy> GetPolicies()
        {
            return policiesRepository.GetPolicies();
        }

        public void AddPolicy(Policy policy)
        {
            policiesRepository.AddPolicy(policy);
        }

    }
}
