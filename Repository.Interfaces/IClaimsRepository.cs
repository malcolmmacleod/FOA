using FOA.Claims.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FAO.Claims.Repository.Interfaces
{
    public interface IClaimsRepository
    {
        void AddClaim(Claim claim);

        List<Claim> GetClaims();
    }
}
