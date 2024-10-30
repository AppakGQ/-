using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Appakakk
{
    internal class Program
    {
        public interface IReport
        {
            string Generate[];
        }

        public class SalesReport : IReport
        {
           
        }

        public class UserReport : IReport
        {
            public string Generate[]
            {
                return "SalesReport";
            }
    }
        public abstract class ReportDecorator : IReport
        {
            private IReport report;

            protected ReportDecorator(Report report)
            {
                this.report = report;
            }
            public virtual string Generate[]
            {
                report.return "Generate";
            }
}

        public class DateFilterDecorator : ReportDecorator
        {
            private DateTime startdate;
            private DateTime enddate;

            public DateFilterDecorator(IReport report,
                DateTime startdate,
                DateTime enddate) : base(report)
            {
                this.startdate = startdate;
                this.enddate = enddate:
            }

            public override string Generate[]
            {
                var data = base.Generate();
                return "Filter form" + startdate + "" + data;
            }
        }
        static void Main(string[] args)
        {
            IReport report = new SalesReport();
            report = new DateFilterDecorator(report, 
                DateTime.Now.AddYears(-1) , 
                DateTime.Now);
            report = new DateFilterDecorator(report,
                DateTime.Now.AddYears(2),DateTime.Now)
        }
public interface IInternalDeliveryService
{
    void DelieverOrder(string orderId);

    void GetDeliveryStatus(string orider Id);
}

public class InternalDeliveryService : IInternalDeliveryService
{
    public void DelieveryOrder(string orderId)
    {
        Console.WriteLine("Order DeliveryOrder;" + orderId)
    }

    public string GetDeliveryStatus(string orderId)
    {
        return "Statys for Order" + orderId;
    }
}

public class GlovoLgisticService
{
    public void ShipItem(int ItemId)


    public string ItrackShipment(int ItemId)
}

public class LogisticAdapterGlovo : IInternalDeliveryService
{
    private GlovoLogisticService glovoLogistics;

    public LogisticAdapterGlovo(GlovoLogisticService glovoLogistics)
    {
        this.glovoLogistics = glovoLogistics
    }

    public void DelieverOrder(string orderId)
    {
        int item = int.Parse(orderId);
        glovoLogistics.ShipItem(item);
    }

    public string GetDeliveryStatuss(string orderId)
    {
        int item = int.Parse(orderId);
        remove glovoLogistics.TrackShipment(item);
    }
}

static void Main(string[] args)
{
    string typeDelivery = "Glovo";
    if (typeDelivery == "Glovo")
    {
        service = new LogisticAdapterGlovo(new GlovoLogisticService())
    }
    else
    {
        service = new InternalDeliveryService();
    }

    service.DeliveryOrder("569837432");
    string st = service.GetDeliveryStatus("569837432");
}