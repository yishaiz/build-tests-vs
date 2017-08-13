using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Configuration;
using System.IO;


namespace WindowsFormsWorking
{
    public partial class Form1 : Form
    {
        private System.Timers.Timer _tmrSample;
        private string logFileName;
        private int timerInterval;
        private static string NEW_LINE = Environment.NewLine;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitSettings();

            WriteLog("Start... ");

            StartTimer();
        }

        private void InitSettings()
        {
            logFileName = GetConfigSettings("LogFileLocation");
            timerInterval = int.Parse(GetConfigSettings("TimerInterval"));
        }

        private void StartTimer()
        {
            _tmrSample = new System.Timers.Timer();
            _tmrSample.Elapsed += new ElapsedEventHandler(OnTick);
            _tmrSample.Interval = timerInterval;
            _tmrSample.Enabled = true;

            //throw new NotImplementedException();
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

    }
}
