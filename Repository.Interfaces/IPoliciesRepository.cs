using FOA.Claims.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FAO.Claims.Repository.Interfaces
{
    public interface IPoliciesRepository
    {
        void AddPolicy(Policy policy);

        List<Policy> GetPolicies();
    }
}

