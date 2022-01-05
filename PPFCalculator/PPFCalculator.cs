using PPFCalculator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPFCalculator
{
    public class PPFCalculator
    {
        private int depositeAmount;
        private int duration;
        private double rateInterest;
        DateTime dateTime = new DateTime();

        public PPFCalculator(int deposite, int duration, double rate)
        {
            depositeAmount = deposite;
            this.duration = duration;
            rateInterest = rate;
            dateTime = DateTime.Now;
        }

        public Maturity CalcMaturityAmount()
        {
            
            double openingAmount = 0;
            double interestAmount;
            double closingAmount = 0;
            int years = 0;
             while (years < duration)
            {
                interestAmount = (openingAmount + depositeAmount) * (rateInterest / 100);
                closingAmount = openingAmount + depositeAmount + interestAmount;
                openingAmount = closingAmount;
                years += 1;
            }
            //Console.WriteLine("\n Total Amount Deposited: Rs.{0:0.0}\n Total Interest:\t Rs.{1:0.0} \n Maturity Amount:\t Rs.{2:0.0}", (depositeAmount * duration), (closingAmount - depositeAmount * duration), closingAmount);
            Maturity maturity = new Maturity()
            {
                TotalDeposit = (depositeAmount * duration),
                TotalInterest = (closingAmount - depositeAmount * duration),
                MaturityAmount = closingAmount
            };
            return maturity;
        }

        public List<Data> getCompleteDetails()
        {
            List<Data> datas = new List<Data>();
            double openingAmount = 0;
            double interestAmount;
            double closingAmount = 0;
            int years = 0;
            while (years < duration)
            {
                interestAmount = (openingAmount + depositeAmount) * (rateInterest / 100);
                closingAmount = openingAmount + depositeAmount + interestAmount;
                //Console.WriteLine(" {0:00}\t {1:d}\t {2:0000000.0}\t {3:000000.0}\t {4:000000.0}\t {5:0000000.0}", (years + 1), dateTime.AddYears(years), openingAmount, depositeAmount, interestAmount, closingAmount);
                openingAmount = closingAmount;
                years += 1;
                Data data = new()
                {
                    Year = years + 1,
                    Date = dateTime.AddYears(years),
                    Opening = openingAmount,
                    Closing = closingAmount,
                    Deposite = depositeAmount,
                    Interest = interestAmount
                };
                datas.Add(data);
            }
            //Console.WriteLine("\n Total Amount Deposited: Rs.{0:0.0}\n Total Interest:\t Rs.{1:0.0} \n Maturity Amount:\t Rs.{2:0.0}", (depositeAmount * duration), (closingAmount - depositeAmount * duration), closingAmount);

            return datas;
        }

    }
}
