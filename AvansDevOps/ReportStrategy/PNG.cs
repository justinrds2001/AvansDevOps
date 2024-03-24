﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.ReportStrategy
{
    public class Png : IExportStrategy
    {
        public bool GenerateReport(Report report)
        {
            Console.WriteLine("Generating PNG report...");
            Console.WriteLine("Header: " + report.Header);
            Console.WriteLine("Content: " + report.Content);
            Console.WriteLine("Footer: " + report.Footer);
            Console.WriteLine("PNG report generated.");
            return true;
        }
    }
}
