using NUnit_Cab_Invoice_Generator;
using NUnit.Framework;
using System;
using CAB_INVOICE_GENERATOR;
using CAB_INVOICE_GENERATOR.Cab_Invoice_Generator;
using Cab_Invoice_Generator;

namespace NUnit_Cab_Invoice_Generator
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Object of InvoiceService Class.
        /// </summary>
        InvoiceService invoiceService = new InvoiceService();


        /// <summary>
        /// Given Distance And Time When Check Should Return TotalFare.
        /// </summary>
        [Test]
        public void GivenDistanceAndTimeWhenCheck_ShouldReturnTotalFare()
        {
            double actual = invoiceService.CalculateFare(0.1, 1);
            Assert.AreEqual(5, actual);
        }

        /// <summary>
        /// InvoiceGenerator Should Take Multiple Rides When Calculate Return TotalFare.
        /// </summary>
        [Test]
        public void InvoiceGeneratorShouldTakeMultipleRides_WhenCalculate_ReturnTotalFare()
        {
            InvoiceService invoiceService = new InvoiceService();
            Ride[] ride = {
                new Ride(5,15),
                new Ride(10,25)
            };
            double actual = invoiceService.CalculateFare(ride);
            Assert.AreEqual(190, actual);
        }

        /// <summary>
        /// InvoiceGenerator Should Take MultipleRides When Analyze Return TotalFareNumberOfRides And AverageFare.
        /// </summary>
        [Test]
        public void InvoiceGeneratorShouldTakeMultipleRides_WhenAnalyze_ReturnTotalFareNumberOfRidesAndAverageFare()
        {
            InvoiceService invoiceService = new InvoiceService();
            Ride[] ride = {
                new Ride(5,15),
                new Ride(10,25),
                new Ride(15,40)
            };
            double totalFare = invoiceService.CalculateFare(ride);
            double averageFare = Math.Round(invoiceService.AverageFare, 2);
            int numberOfRides = invoiceService.NumberOfRides;
            Assert.AreEqual(380, totalFare);
            Assert.AreEqual(126.67, averageFare);
            Assert.AreEqual(3, numberOfRides);
        }

        /// <summary>
        /// GivenUserId_InvoiceServiceGetsListOfRidesFromRideRepository_ReturnInvoice.
        /// </summary>
        [Test]
        public void GivenUserId_InvoiceServiceGetsListOfRidesFromRideRepository_ReturnInvoice()
        {
            string userId = "saad@gmail.com";
            Ride[] ride = {
                new Ride(5,15),
                new Ride(10,25),
                new Ride(15,40)
            };
            RideRepo rideRepository = new RideRepo();
            rideRepository.AddRides(userId, ride);
            double totalFare = invoiceService.CalculateFare(rideRepository.GetRides(userId));
            Assert.AreEqual(380, totalFare);
        }

        /// <summary>
        /// Cab_Agency_Category_Of_Ride_When_Chosse_Return_Category_Fare.
        /// </summary>
        [Test]
        public void Cab_Agency_Category_Of_Ride_When_Chosse_Return_Category_Fare()
        {
            double actual = invoiceService.TypeOfRide(2, 4.2, 10);
            double expected = 83;
            Assert.AreEqual(expected, actual);
        }
    }
}
