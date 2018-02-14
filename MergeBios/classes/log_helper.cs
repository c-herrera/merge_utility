using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeBios
{
    /// <summary>
    /// Class: LogHelper; Type: Helper class
    /// </summary>
    class Log_helper
    {
        string logFile;
        string logText;
        string[] logTextLines;
        bool is_started;
        bool is_written;
        bool is_clear;
        int additions;


        /// <summary>
        /// Log Helper public contructor
        /// </summary>
        public Log_helper()
        {
            logFile = string.Empty;
            logText = string.Empty;

            logTextLines = new string[1];         

            is_started = true;
            additions = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Add_to_log(string Ltext)
        {
            // Check if log is allowed
            if (is_started == true)
            {
                // Add the text to the text line
                logText += Ltext + Environment.NewLine;
                additions++;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Save_to_log()
        {
            // Check if log is allowed
            if (is_started == true)
            {
                logTextLines = logText.Split('\r');
                File.AppendAllText(logFile, logText);
                is_written = true;
            }
        }

        public void Clear_Log_lines()
        {
            if (is_started == true)
            {
                if (logText != string.Empty || logText != null)
                {
                    logText = string.Empty;
                    for (int i = 0; i < logTextLines.Length; i++)
                    {
                        logTextLines[i] = string.Empty;
                    }
                    is_clear = true;
                }
            }
        }



        #region Public accesors

        /// <summary>
        /// Set or gets the full/relative path and name of the log
        /// </summary>
        public string theLogFilePath
        {
            get
            {
                return logFile;
            }
            set
            {
                logFile = value;
            }
        }

        /// <summary>
        /// Set or Gets the status of the log to start logging
        /// </summary>
        public bool LogStart
        {
            get
            {
                return is_started;
            }
            set
            {
                is_started = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string[] loglines_Str
        {
            get
            {
                return logTextLines;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool writtenLogStat
        {
            get
            {
                return is_written;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool ClearedlogStat
        {
            get
            {
                return is_clear;
            }
        }

        #endregion

    }
}
