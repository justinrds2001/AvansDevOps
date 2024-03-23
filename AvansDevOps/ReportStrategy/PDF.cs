using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.ReportStrategy
{
    public class Pdf : IExportStrategy
    {

        public void GenerateReport(Report report)
        {
            Console.WriteLine("Generating PDF report...");
            Console.WriteLine("Header: " + report.Header);
            Console.WriteLine("Content: " + report.Content);
            Console.WriteLine("Footer: " + report.Footer);
            Console.WriteLine("PDF report generated.");
        }
    }
}
