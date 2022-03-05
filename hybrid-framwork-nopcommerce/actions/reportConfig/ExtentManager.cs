using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using hybrid_framwork_nopcommerce.actions.commons;
using System;
using System.Globalization;
using System.IO;

namespace hybrid_framwork_nopcommerce.actions.reportConfig
{
    public class ExtentManager
    {
        private static ExtentReports extent;

        public static ExtentReports CreateInstance()
        {
            if (extent == null)
            {
                string currentDate = DateTime.Now.ToString("ddMMyyyy");
                ExtentV3HtmlReporter htmlReporter = new ExtentV3HtmlReporter(GlobalConstants.PROJECT_DIR + Path.DirectorySeparatorChar + "extentReport" + Path.DirectorySeparatorChar + "Extent" + currentDate + ".html");
                htmlReporter.Config.DocumentTitle = "Nopcommerce HTML Report";
                htmlReporter.Config.ReportName = "Nopcommerce HTML Report";
                htmlReporter.Config.Theme = Theme.Standard;
                htmlReporter.Config.Encoding = "utf-8";
                extent = new ExtentReports();
                extent.AttachReporter(htmlReporter);
                return extent;
            }
            else return extent;
        }
	}
}
