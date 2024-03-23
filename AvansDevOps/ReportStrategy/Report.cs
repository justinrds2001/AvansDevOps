using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.ReportStrategy
{
    public class Report
    {
        public string Content { get; set; } = "";
        public string? Footer { get; set; }
        public string? Header { get; set; }
        public ExportStrategy? ExportStrategy { get; set; } = null;
    }
}
