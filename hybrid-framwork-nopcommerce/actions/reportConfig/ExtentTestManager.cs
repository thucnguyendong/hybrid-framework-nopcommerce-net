using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace hybrid_framwork_nopcommerce.actions.reportConfig
{
    public class ExtentTestManager
    {
        private static ThreadLocal<ExtentTest> test;
        private static ExtentReports report = ExtentManager.CreateInstance();

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ExtentTest GetTest()
        {
            return test.Value;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ExtentTest CreateTest(string name)
        {
            if (test == null)
                test = new ThreadLocal<ExtentTest>();

            ExtentTest t = report.CreateTest(name);
            test.Value = t;

            return t;
        }
    }
}
