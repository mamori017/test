using System;

namespace Common
{
    public class Tax
    {
        private int OldTax { get; }
        private int NewTax { get; }
        private int ReducedTax { get; }
        public DateTime NewTaxStartDate { get; }
        public int ApplyTax { get; set; }
        public DateTime TargetDate { get; }

        public enum ItemType
        {
            Food,
            FoodWithEatOut,
            Alchol,
            NewsPaper,
            Other
        }

        public Tax(DateTime dateTime)
        {
            OldTax = 8;
            NewTax = 10;
            ReducedTax = 8;
            NewTaxStartDate = new DateTime(2019,10,1,0,0,0);
            TargetDate = dateTime;
        }

        public double TaxInPrice(int price,  ItemType itemType, int issuePerWeek = 0)
        {
            double ret = 0;

            if (itemType == ItemType.Food || itemType == ItemType.FoodWithEatOut || itemType == ItemType.Alchol || itemType == ItemType.Other)
            {
                ret = FoodTax(price, itemType);
            }
            else if(itemType == ItemType.NewsPaper)
            {
                ret = NewsPaperTax(price, issuePerWeek);
            }

            return ret;
        }

        public double FoodTax(int price, ItemType itemType)
        {
            return Math.Floor(price + (price * (FoodTax(itemType) / 100)));
        }

        public double FoodTax(ItemType itemType)
        {
            if (TargetDate >= NewTaxStartDate)
            {
                if (itemType == ItemType.FoodWithEatOut || itemType == ItemType.Alchol || itemType == ItemType.Other)
                {
                    ApplyTax = NewTax;
                }
                else
                {
                    ApplyTax = OldTax;
                }
            }
            else
            {
                ApplyTax = OldTax;
            }

            return ApplyTax;
        }

        public double NewsPaperTax(int price, int issuePerWeek)
        {
            return Math.Floor(price + (price * (NewsPaperTax(issuePerWeek) / 100)));
        }

        public double NewsPaperTax(int issuePerWeek)
        {
            if (TargetDate >= NewTaxStartDate)
            {
                if (issuePerWeek >= 2)
                {
                    ApplyTax = OldTax;
                }
                else
                {
                    ApplyTax = NewTax;
                }
            }
            else
            {
                ApplyTax = OldTax;
            }

            return ApplyTax;
        }
    }
}