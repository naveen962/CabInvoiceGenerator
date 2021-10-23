using CabInvoiceGenerator;
using NUnit.Framework;

namespace CabInvoiceGeneratorTest
{
    public class Tests
    {
        InvoiceGenerator invoiceGenerator = null;



        [Test]
        public void GivenDistanceAndTimeShouldReturntotalFare()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double distance = 2.0;
            int time = 5;


            double fare = invoiceGenerator.CalculateFare(distance, time);
            int expected = 25;
            Assert.AreEqual(expected, fare);
        }

        [Test]
        public void GivenMultipleRidesShouldReturnInvoiceSummary()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };

            InvoiceSummary invoiceSummary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 30.0);

            Assert.AreEqual(expectedSummary, invoiceSummary);


        }
        [Test]
        public void GivenInvoiceGenerator_WhenUsingInvoiceSummaryClass_ShouldReturnInvoiceSummary()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(30.0, 30), new Ride(25.0, 25) };
            InvoiceSummary invoicesummary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 605);
            Assert.AreEqual(expectedSummary, invoicesummary);
        }

        [Test]
        public void GivenUserId_WhenInvoivceService_ShouldReturnInvoice()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };
            invoiceGenerator.AddRides("101", rides);
            InvoiceSummary summary = invoiceGenerator.GetInvoiceSummary("101");
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 30.0);
            Assert.AreEqual(expectedSummary, summary);


        }


        [Test]
        public void GivenRides_ForPremiumUser_ShouldReturnTotalFare()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.PREMIUM);
            double distance = 3.0;
            int time = 10;
            //calculating fares
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 65;
            //Assert
            Assert.AreEqual(expected, fare);
        }
    }
}