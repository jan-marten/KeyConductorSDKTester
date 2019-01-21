using System;
using System.Windows.Forms;

namespace KeyConductorSDKTester
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            //Application.Run(new SpecialCharEditor());
            //Application.Run(new FormMatrixTester());
        }
        public static void TestDateTimeToKCTime()
        {
            var dtTemp = DateTime.Now;

            for(int i = 0; i < 100; i++)
            {
                var dt2 = dtTemp.AddSeconds(i);
                System.Diagnostics.Debug.Print(TestDateTimeToKCTimeFunction(dt2));

            }
        }

        public static string TestDateTimeToKCTimeFunction(DateTime input)
        {
            //var unixTime = (ulong)(EndDatetime - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
            UInt32 unixTime = (UInt32)(input - new DateTime(1970, 1, 1)).TotalSeconds;

            var tmpData = BitConverter.GetBytes((Int32)unixTime);
            Array.Reverse(tmpData);
            //Array.Copy(tmpData, 0, data, 232, 4);
            return input.ToString() + "->" + BitConverter.ToString(tmpData);
        }
    }


}
