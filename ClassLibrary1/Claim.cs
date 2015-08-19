using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace FOA.Claims.Domain
{
    public class Claim
    {
        private List<Func<string>> validationRules;

        public Claim()
        {
            validationRules = new List<Func<string>>();

            validationRules.Add(ValidatePolicyReferenceIsValid);
            validationRules.Add(ValidateStartDateIsValid);
            validationRules.Add(ValidatePolicyNotClosedForOverSixMonths);
            validationRules.Add(ValidateClaimsAreNotOverTwiceInsuredAmount);
            validationRules.Add(ValidateClaimIsNotPaidToHolderIfSubmittedByWebsite);
            validationRules.Add(ValidateClaimAmountLessThanOrEqualToInsuredAmount);
        }

        [Key]
        public int Id { get; set; }

        public virtual Policy Policy { get; set; }

        public DateTime Issued { get; set; }

        public string Narrative { get; set; }

        public decimal Amount { get; set; }

        public DateTime? Paid { get; set; }

        public ClaimSource Source { get; set; }

        public void AddRule(Func<string> validationRule)
        {
            validationRules.Add(validationRule);
        }

        public List<string> Validate()
        {
            var errorList = new List<string>();

            foreach (var func in validationRules)
            {
                var result = func();
                if (result != null)
                {
                    errorList.Add(result);
                }
            }

            return errorList;
        }

        private string ValidatePolicyReferenceIsValid()
        {
            if (Policy == null)
            {
                return "Policy reference is invalid";
            }

            return null;
        }

        private string ValidateStartDateIsValid()
        {
            if (Policy != null && Policy.StartDate > this.Issued.AddMonths(-2))
            {
                return "Claim is made within 2 months of policy start date";
            }

            return null;
        }

        private string ValidatePolicyNotClosedForOverSixMonths()
        {
            if (Policy != null && Policy.Closed.HasValue && Policy.Closed < DateTime.Today.AddMonths(-6))
            {
                return "Policy has been closed for over six months";
            }

            return null;
        }

        private string ValidateClaimAmountLessThanOrEqualToInsuredAmount()
        {
            if (Policy != null && Policy.InsuredAmount < this.Amount)
            {
                return "Claim is over insured amount on policy";
            }

            return null;
        }

        private string ValidateClaimsAreNotOverTwiceInsuredAmount()
        {
            if (Policy != null && Policy.InsuredAmount * 2 < Policy.TotalClaimsToDate())
            {
                return "Total claims to date should not exceed twice insured amount";
            }

            return null;
        }

        private string ValidateClaimIsNotPaidToHolderIfSubmittedByWebsite()
        {
            if (Source == ClaimSource.WebSite && Paid.HasValue)
            {
                return "Claims made by website should not be paid";
            }

            return null;
        }
    }
}
