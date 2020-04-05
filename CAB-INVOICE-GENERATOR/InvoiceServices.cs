using Cab_Invoice_Generator;
using System;
using System.Collections.Generic;
using System.Text;

namespace CAB_INVOICE_GENERATOR
{
    public class InvoiceService
    {
        private readonly int costPerKilometre = 10;
        private readonly int minimumFare = 5;
        private readonly int costPerMinute = 1;
        private readonly int PremiumCostPerKilometre = 15;
        private readonly int PremiumMinimumFare = 20;
        private readonly int PremiumCostPerMinute = 2;
        private double totalCost = 0;
        private double totalFare = 0;
        private double averageFare = 0;
        private int numberOfRides = 0;

        /// <summary>
        /// Gets property of AverageFare
        /// </summary>
        public double AverageFare
        {
            get
            {
                return this.averageFare;
            }
        }

        /// <summary>
        /// Gets property of NumberOfRides
        /// </summary>
        public int NumberOfRides
        {
            get
            {
                return this.numberOfRides;
            }
        }

        /// <summary>
        /// CalculateFare method.
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public double CalculateFare(double distance, double time)
        {
            totalCost = distance * costPerKilometre + time * costPerMinute;
            if (totalCost > minimumFare)
            {
                return totalCost;
            }

            return minimumFare;
        }

        /// <summary>
        /// PreimumCalculateFare method.
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public double PreimumCalculateFare(double distance, double time)
        {
            totalCost = distance * PremiumCostPerKilometre + time * PremiumCostPerMinute;
            if (totalCost > PremiumMinimumFare)
            {
                return totalCost;
            }

            return PremiumMinimumFare;
        }

        /// <summary>
        /// Overloaded CalculateFare Class.
        /// </summary>
        /// <param name="ride"></param>
        /// <returns></returns>
        public double CalculateFare(Ride[] ride)
        {
            foreach (var item in ride)
            {
                totalFare = totalFare + CalculateFare(item.Distance, item.Time);
            }
            numberOfRides = ride.Length;
            averageFare = totalFare / numberOfRides;
            return totalFare;
        }

        /// <summary>
        /// TypeOfRide Method.
        /// </summary>
        /// <param name="Type"></param>
        /// <param name="distance"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public double TypeOfRide(int Type, double distance, double time)
        {
            InvoiceService invoiceService = new InvoiceService();
            double RideCost = 0;
            switch (Type)
            {
                case 1:
                    RideCost = invoiceService.CalculateFare(distance, time);
                    break;

                case 2:
                    RideCost = invoiceService.PreimumCalculateFare(distance, time);
                    break;
            }

            return RideCost;
        }
    }
}

