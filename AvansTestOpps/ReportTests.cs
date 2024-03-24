using AvansDevOps.ReportStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvansTestOpps
{
    public class ReportTests
    {
        [Fact]
        public void GenerateReport_Should_Generate_PDF_Report()
        {
            // Arrange
            var report = new Report
            {
                Header = "Test Header",
                Content = "Test Content",
                Footer = "Test Footer"
            };
            var pdf = new Pdf();

            // Act
            bool response = pdf.GenerateReport(report);

            // Assert
            Assert.True(response);
        }

        [Fact]
        public void GenerateReport_Should_Generate_PNG_Report()
        {
            // Arrange
            var report = new Report
            {
                Header = "Test Header",
                Content = "Test Content",
                Footer = "Test Footer"
            };
            var png = new Png();

            // Act
            bool response = png.GenerateReport(report);

            // Assert
            Assert.True(response);
        }

        [Fact]
        public void GenerateReport_Should_Generate_PDF_Report_With_Empty_Header()
        {
            // Arrange
            var report = new Report
            {
                Header = "",
                Content = "Test Content",
                Footer = "Test Footer"
            };
            var pdf = new Pdf();

            // Act
            bool response = pdf.GenerateReport(report);

            // Assert
            Assert.True(response);
        }

        [Fact]
        public void GenerateReport_Should_Generate_PNG_Report_With_Empty_Header()
        {
            // Arrange
            var report = new Report
            {
                Header = "",
                Content = "Test Content",
                Footer = "Test Footer"
            };
            var png = new Png();

            // Act
            bool response = png.GenerateReport(report);

            // Assert
            Assert.True(response);
        }
    }
}
