using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace FOA.Claims.Repository
{
    public class ClaimsDbInitializer : DropCreateDatabaseIfModelChanges<ClaimsContext>
    {
        protected override void Seed(ClaimsContext context)
        {
            base.Seed(context);

            context.Policies.Add(new Domain.Policy
            {
                ContactInfo = "Test Name",
                Closed = null,
                Description = "Test Description",
                HolderName = "Test Holder",
                InsuredAmount = 1000M,
                PaidToDate = 500M,
                PolicyType = Domain.Coverage.Extended,
                Premium = 30M,
                StartDate = DateTime.Today.AddYears(-1)
            });

            context.SaveChanges();
        }
    }
}
