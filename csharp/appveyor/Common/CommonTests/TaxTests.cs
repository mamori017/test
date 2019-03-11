using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Common.Tests
{
    [TestClass()]
    public class TaxTests
    {
        DateTime dateTime;
        Tax tax;

        private void SetBeforeStartDate()
        {
            dateTime = new DateTime(2018, 8, 21, 0, 0, 0);
            tax = new Tax(dateTime);
        }

        [TestMethod()]
        public void TaxInPriceTestBeforeStartDate_1()
        {
            SetBeforeStartDate();
            Assert.AreEqual(116, tax.TaxInPrice(108, Tax.ItemType.Alchol));
        }

        [TestMethod()]
        public void TaxInPriceTestBeforeStartDate_2()
        {
            SetBeforeStartDate();
            Assert.AreEqual(116, tax.TaxInPrice(108, Tax.ItemType.Food));
        }

        [TestMethod()]
        public void TaxInPriceTestBeforeStartDate_3()
        {
            SetBeforeStartDate();
            Assert.AreEqual(116, tax.TaxInPrice(108, Tax.ItemType.FoodWithEatOut));
        }

        [TestMethod()]
        public void TaxInPriceTestBeforeStartDate_4()
        {
            SetBeforeStartDate();
            Assert.AreEqual(116, tax.TaxInPrice(108, Tax.ItemType.NewsPaper));
        }

        [TestMethod()]
        public void TaxInPriceTestBeforeStartDate_5()
        {
            SetBeforeStartDate();
            Assert.AreEqual(116, tax.TaxInPrice(108, Tax.ItemType.Other));
        }

        private void SetAfterStartDate()
        {
            dateTime = new DateTime(2019, 10, 1, 0, 0, 0);
            tax = new Tax(dateTime);
        }

        [TestMethod()]
        public void TaxInPriceTestAfterStartDate_1()
        {
            SetAfterStartDate();
            Assert.AreEqual(118, tax.TaxInPrice(108, Tax.ItemType.Alchol));
        }

        [TestMethod()]
        public void TaxInPriceTestAfterStartDate_2()
        {
            SetAfterStartDate();
            Assert.AreEqual(116, tax.TaxInPrice(108, Tax.ItemType.Food));
        }

        [TestMethod()]
        public void TaxInPriceTestAfterStartDate_3()
        {
            SetAfterStartDate();
            Assert.AreEqual(118, tax.TaxInPrice(108, Tax.ItemType.FoodWithEatOut));
        }

        [TestMethod()]
        public void TaxInPriceTestAfterStartDate_4()
        {
            SetAfterStartDate();
            Assert.AreEqual(118, tax.TaxInPrice(108, Tax.ItemType.NewsPaper));
        }

        [TestMethod()]
        public void TaxInPriceTestAfterStartDate_5()
        {
            SetAfterStartDate();
            Assert.AreEqual(118, tax.TaxInPrice(108, Tax.ItemType.NewsPaper, 1));
        }

        [TestMethod()]
        public void TaxInPriceTestAfterStartDate_6()
        {
            SetAfterStartDate();
            Assert.AreEqual(116, tax.TaxInPrice(108, Tax.ItemType.NewsPaper, 2));
        }

        [TestMethod()]
        public void TaxInPriceTestAfterStartDate_7()
        {
            SetAfterStartDate();
            Assert.AreEqual(118, tax.TaxInPrice(108, Tax.ItemType.Other));
        }

    }
}