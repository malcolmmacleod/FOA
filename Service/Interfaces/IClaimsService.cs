using FOA.Claims.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FOA.Claims.Service.Interfaces
{
    public interface IClaimsService 
    {
        List<Claim> GetClaims();

        List<string> AcceptClaim(Claim claim);
    }
}
