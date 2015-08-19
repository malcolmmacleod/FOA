using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace FOA.Claims.Domain
{
    public class Policy
    {
        public Policy()
        {
            Claims = new List<Claim>();
        }

        [Key]
        public int Id { get; set; }

        public string Reference
        {
            get
            {
                return Id.ToString();
            }
        }

        public Coverage PolicyType { get; set; }

        public string Description { get; set; }

        public string HolderName { get; set; }

        public string ContactInfo { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? Closed { get; set; }

        public decimal InsuredAmount { get; set; }

        public decimal Premium { get; set; }

        public decimal PaidToDate { get; set; }

        public virtual List<Claim> Claims { get; set; }

        public void AddClaim(Claim claim)
        {
            this.Claims.Add(claim);
        }

        public decimal TotalClaimsToDate()
        {
            return this.Claims.Sum(claim => claim.Amount);
        }
    }
}
