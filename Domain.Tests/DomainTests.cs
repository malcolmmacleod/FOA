using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FOA.Claims.Domain;

namespace Domain.Tests
{
    [TestClass]
    public class DomainTests
    {
        [TestMethod]
        public void CanAddValidClaimToPolicy()
        {
            var policy = new Policy
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

            var claim = new Claim
            {
                Amount = 100M,
                Issued = DateTime.Today,
                Narrative = "test narrative",
                Paid = null,
                Policy = policy
            };

            var validations = claim.Validate();

            Assert.IsTrue(validations.Count == 0);
        }

        [TestMethod]
        public void CannotAddValidClaimToPolicyWithoutPolicyReference()
        {
            var policy = new Policy
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

            var claim = new Claim
            {
                Amount = 100M,
                Issued = DateTime.Today,
                Narrative = "test narrative",
                Paid = null,
                Policy = null
            };

            var validations = claim.Validate();

            Assert.IsTrue(validations.Count == 1);
        }

        [TestMethod]
        public void CannotAddValidClaimToPolicyWithinTwoMonths()
        {
            var policy = new Policy
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

            var claim = new Claim
            {
                Amount = 100M,
                Issued = DateTime.Today.AddYears(-1).AddMonths(1),
                Narrative = "test narrative",
                Paid = null,
                Policy = policy
            };

            var validations = claim.Validate();

            Assert.IsTrue(validations.Count == 1);
        }

        [TestMethod]
        public void CannotAddValidClaimToPolicyThatHasBeenClosedForSixMonths()
        {
            var policy = new Policy
            {
                ContactInfo = "Test Name",
                Closed = DateTime.Today.AddMonths(-7),
                Description = "Test Description",
                HolderName = "Test Holder",
                InsuredAmount = 1000M,
                PaidToDate = 500M,
                PolicyType = Coverage.Extended,
                Premium = 30M,
                StartDate = DateTime.Today.AddYears(-1)
            };

            var claim = new Claim
            {
                Amount = 100M,
                Issued = DateTime.Today,
                Narrative = "test narrative",
                Paid = null,
                Policy = policy
            };

            var validations = claim.Validate();

            Assert.IsTrue(validations.Count == 1);
        }

        [TestMethod]
        public void CanAddValidClaimToPolicyThatHasBeenClosedForLessThanSixMonths()
        {
            var policy = new Policy
            {
                ContactInfo = "Test Name",
                Closed = DateTime.Today.AddMonths(-5),
                Description = "Test Description",
                HolderName = "Test Holder",
                InsuredAmount = 1000M,
                PaidToDate = 500M,
                PolicyType = Coverage.Extended,
                Premium = 30M,
                StartDate = DateTime.Today.AddYears(-1)
            };

            var claim = new Claim
            {
                Amount = 100M,
                Issued = DateTime.Today,
                Narrative = "test narrative",
                Paid = null,
                Policy = policy
            };

            var validations = claim.Validate();

            Assert.IsTrue(validations.Count == 0);
        }
    }
}
