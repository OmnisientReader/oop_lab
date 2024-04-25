using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using oop_1_1;

namespace oop_1_1.Tests
{
    [TestClass()]
    public class RationalNumberTests
    {

        [TestMethod()]
        public void Addition()
        {
            var a = new RationalNumber(1, 1);
            var b = new RationalNumber(2, 1);

            var c = a + b;

            Assert.AreEqual(c, c);
        }

        [TestMethod()]
        public void Sub()
        {
            var a = new RationalNumber(1, 1);
            var b = new RationalNumber(2, 1);

            var c = b - a;

            Assert.AreEqual(new RationalNumber(1, 1), c);
        }

        [TestMethod()]
        public void Mult()
        {
            var a = new RationalNumber(1, 1);
            var b = new RationalNumber(2, 1);

            var c = b * a;

            Assert.AreEqual(new RationalNumber(2, 1), c);
        }

        [TestMethod()]
        public void Division()
        {
            var a = new RationalNumber(1, 1);
            var b = new RationalNumber(2, 1);

            var c = b / a;

            Assert.AreEqual(new RationalNumber(2, 1), c);
        }

        [TestMethod()]
        public void Minus()
        {
            var a = new RationalNumber(1, 1);

            var c = -a;

            Assert.AreEqual(new RationalNumber(-1, 1), c);
        }

        [TestMethod()]
        public void Equal()
        {
            var a = new RationalNumber(1, 1);
            var b = new RationalNumber(1, 1);

            var c = (b == a);

            Assert.AreEqual(true, c);
        }

        [TestMethod()]
        public void UnEqual()
        {
            var a = new RationalNumber(1, 1);
            var b = new RationalNumber(2, 1);

            var c = (b != a);

            Assert.AreEqual(true, c);
        }

        [TestMethod()]
        public void Lesser()
        {
            var a = new RationalNumber(1, 1);
            var b = new RationalNumber(2, 1);

            var c = (a < b);

            Assert.AreEqual(true, c);
        }

        [TestMethod()]
        public void More()
        {
            var a = new RationalNumber(2, 1);
            var b = new RationalNumber(1, 1);

            var c = a > b;

            Assert.AreEqual(true, c);
        }

        [TestMethod()]
        public void LesserOrEqual()
        {
            var a = new RationalNumber(2, 1);
            var b = new RationalNumber(2, 1);
            var d = new RationalNumber(3, 1);

            var c = (a <= b);
            var x = (a <= d);

            Assert.AreEqual(true, (c && x));
        }

        [TestMethod()]
        public void MoreOrEqual()
        {
            var a = new RationalNumber(2, 1);
            var b = new RationalNumber(1, 1);
            var d = new RationalNumber(2, 1);

            var c = (a >= b);
            var x = (a >= d);

            Assert.AreEqual(true, (c && x));
        }
    }
}