using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansDevOps.ReportStrategy
{
    public interface IExportStrategy
    {
        void GenerateReport(Report report);
    }
}
