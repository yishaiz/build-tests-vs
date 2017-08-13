using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace BuildWorkingService
{
    partial class Service1 : ServiceBase
    {
        private System.Timers.Timer _tmrSample;
        private string logFileName;
        private int timerInterval;
        private static string NEW_LINE = Environment.NewLine;


        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            // TODO: Add code here to start your service.

            InitSettings();

            WriteLog("Start... ");

            StartTimer();

            //write log
            //add timers
            //log on each tick
        }


        private void StartTimer()
        {
            _tmrSample = new System.Timers.Timer();
            _tmrSample.Elapsed += new ElapsedEventHandler(OnTick);
            _tmrSample.Interval = timerInterval;
            _tmrSample.Enabled = true;

            //throw new NotImplementedException();
        }

        private void InitSettings()
        {
            logFileName = GetConfigSettings("LogFileLocation");
            timerInterval = int.Parse(GetConfigSettings("TimerInterval"));
        }

        private void OnTick(object sender, ElapsedEventArgs e)
        {
            WriteLog("Tick...");
        }

        private void WriteLog(string textToWrite)
        {
            textToWrite =
                " *     *     *     *     *     *     *     *     *     *     *     *     " + NEW_LINE +
                DateTime.Now + NEW_LINE +
                textToWrite + NEW_LINE;


            using (FileStream fs = File.Open(logFileName, FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(textToWrite);
                }
            }

        }

        public static string GetConfigSettings(string key)
        {
            try
            {
                string value = ConfigurationManager.AppSettings[key].ToString();
                if (value.Length == 0)
                {
                    throw new ApplicationException("key is not exists in config file");
                }
                return (value);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error while trying to get value from config file - " + key + ". " + ex.Message);
            }
        }

        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down necessary to stop your service.
        }
    }
}
