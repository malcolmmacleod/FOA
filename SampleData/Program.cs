using FOA.Claims.Domain;
using FOA.Claims.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleData
{
    class Program
    {
        static void Main(string[] args)
        {
            PopulatePolicies();
            PopulateClaims();
        }

        private static void PopulateClaims()
        {
            
        }

        private static void PopulatePolicies()
        {
            Policy policy = new Policy()
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

            var policyService = new PolicyService();
            policyService.AddPolicy(policy);

            var policies = policyService.GetPolicies();

            foreach (var p in policies)
            {
                Console.WriteLine(p.Description);
            }

            Console.ReadLine();
        }
    }
}
