﻿using System.Linq;
using BorrowerUtility;
using CalculatorUtility;
using CalculatorUtility.PaymentUtility;
using CalculatorUtility.RateUtility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.SemanticComparison;

namespace UnitTests.CalculatorUtilityTests
{
    [TestClass]
    public class RateCalculatorByMonthTests
    {
        private RateCalculatorByMonth _calculator = new RateCalculatorByMonth();

        [TestMethod]
        public void TestGetRateGivenPayment()
        {
            var payment = new PaymentByMonth()
            {
                Instalments = 36,
                TotalAmt = 1111.57m,
            };
            var rateContract1000Loan = _calculator.GetRateByPayment(payment, 1000, 3);
            var rateContract1000LoanExpected = new Likeness<IRateContract, IRateContract>(new RateContract()
            {
                AnnualRate = 0.070m,
                DurationInMonth = 36
            });
            Assert.AreEqual(rateContract1000LoanExpected, rateContract1000Loan);
            //Assert.AreEqual(rateContract1000LoanExpected.AnnualRate, rateContract1000Loan.AnnualRate);
            //Assert.AreEqual(rateContract1000LoanExpected.DurationInMonth, rateContract1000Loan.DurationInMonth);
        }

        //[TestMethod]
        //public void TestBuilPolynomial()
        //{
        //    var coefficients = Enumerable.Range(1, 37).Select(x => -30.78m).ToArray();
        //    coefficients[0] = 1000;
        //    var func = _calculator.BuildPolynomial(coefficients);
        //    Assert.AreEqual(-108.08m, func(1));
        //}

    }
}