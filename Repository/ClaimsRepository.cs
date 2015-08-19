using FAO.Claims.Repository.Interfaces;
using FOA.Claims.Domain;
using FOA.Claims.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FAO.Claims.Repository
{
    public class ClaimsRepository : IClaimsRepository
    {
        public void AddClaim(Claim claim)
        {
            using (var claimsContext = new ClaimsContext())
            {
                var claims = claimsContext.Claims;
                claims.Add(claim);
                claimsContext.SaveChanges();
            }
        }

        public List<Claim> GetClaims()
        {
            using (var claimsContext = new ClaimsContext())
            {
                var claims = claimsContext.Claims;

                return claims.ToList();
            }
        }
    }
}
