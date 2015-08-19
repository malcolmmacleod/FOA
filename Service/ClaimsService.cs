using FAO.Claims.Repository;
using FAO.Claims.Repository.InMemory;
using FAO.Claims.Repository.Interfaces;
using FOA.Claims.Domain;
using FOA.Claims.Repository;
using FOA.Claims.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FOA.Claims.Service
{
    /// <summary>
    /// Services claims
    /// </summary>
    public class ClaimsService : IClaimsService
    {
        private IClaimsRepository claimsRepository;
             
        public ClaimsService()
        {
            claimsRepository = new ClaimsRepository();
        }

        public List<string> AcceptClaim(Claim claim)
        {
            var errors = claim.Validate();

            if (!errors.Any())
            {
                claimsRepository.AddClaim(claim);
                return null;
            }

            return errors;
        }

        public List<Claim> GetClaims()
        {
            var claims = claimsRepository.GetClaims();

            return claims.ToList();
        }
    }
}
