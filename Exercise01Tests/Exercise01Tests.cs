using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exercise01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Exercise01.Tests
{
    [TestClass()]
    public class Exercise01Tests
    {
        [TestMethod()]
        public void TowardsTest1()
        {
            string input = "18000000";

            string expected = "eighteen million";

            string actual = Convert.ToDouble(input).Towards();

            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void TowardsTest2()
        {
            string input = "18456002032011000007";

            string expected = "eighteen quintillion, four hundred and fifty-six quadrillion, two trillion, thirty-two billion, eleven million,  seven";

            BigInteger number;

            BigInteger.TryParse(input, out number);

            string actual = number.Towards();

            Assert.AreEqual(expected, actual);
            
        }
    }
}