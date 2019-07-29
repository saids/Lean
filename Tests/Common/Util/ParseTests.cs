﻿using System;
using System.Globalization;
using NUnit.Framework;

namespace QuantConnect.Tests.Common.Util
{
    [TestFixture]
    public class ParseTests
    {
        [Test]
        public void DoubleIsTheSameAs_DoubleDotParse_WithInvariantCulture()
        {
            var str = "1,123.45608";
            var expected = double.Parse(str, CultureInfo.InvariantCulture);
            var actual = Parse.Double(str);
            Assert.IsInstanceOf<double>(actual);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DecimalIsTheSameAs_DecimalDotParse_WithInvariantCulture()
        {
            var str = "1,123.45608";
            var expected = decimal.Parse(str, CultureInfo.InvariantCulture);
            var actual = Parse.Decimal(str);
            Assert.IsInstanceOf<decimal>(actual);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DecimalSupports_NumberStyles()
        {
            var str = "1e-3";
            var expected = 0.001m;
            var actual = Parse.Decimal(str, NumberStyles.AllowExponent);
            Assert.IsInstanceOf<decimal>(expected);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void LongIsTheSameAs_LongDotParse_WithInvariantCulture()
        {
            var str = "1123";
            var expected = long.Parse(str, CultureInfo.InvariantCulture);
            var actual = Parse.Long(str);
            Assert.IsInstanceOf<long>(actual);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void IntIsTheSameAs_IntDotParse_WithInvariantCulture()
        {
            var str = "1123";
            var expected = int.Parse(str, CultureInfo.InvariantCulture);
            var actual = Parse.Int(str);
            Assert.IsInstanceOf<int>(actual);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DateTimeIsTheSameAs_DateTimeDotParse_WithInvariantCulture()
        {
            var str = "7/29/2019";
            var expected = DateTime.Parse(str, CultureInfo.InvariantCulture);
            var actual = Parse.DateTime(str);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DateTimeWithFormat_IsTheSameAs_DateTimeDotParse_WithFormatAndInvariantCulture()
        {
            var str = "07+29+2019";
            var format = "MM+dd+2019";
            var expected = DateTime.ParseExact(str, format, CultureInfo.InvariantCulture);
            var actual = Parse.DateTimeExact(str, format);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DateTimeExact_IsTheSameAs_DateTimeDotParseExact_WithFormatAndInvariantCulture()
        {
            var str = "07/29-2019Q14.22";
            var format = "MM/dd-yyyyQHH.mm";
            var expected = DateTime.ParseExact(str, format, CultureInfo.InvariantCulture);
            var actual = Parse.DateTimeExact(str, format);
            Assert.AreEqual(expected, actual);
        }
    }
}