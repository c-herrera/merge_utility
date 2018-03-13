using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// No need to add anything else
// DO NOT CHANGE

namespace MergeBios
{
    /// <summary>
    /// Class LoadCSV; Type : Helper class
    /// </summary>
    class LoadCSV
    {
        private bool isCSVLoaded;
        private string theFileName;
        /// <summary>
        /// Public constructor, no overloaded
        /// </summary>
        public LoadCSV()
        {

        }

        // Load a CSV file into an array of rows and columns.
        // Assume there may be blank lines but every line has
        // the same number of fields.

        /// <summary>
        /// Load a CSV file into an array of row and columns.
        /// </summary>
        /// <param name="filename">Filename and path</param>
        /// <returns>A string array with all parsed data</returns>
        public string[,] LoadCsv(string filename)
        {
            // Get the file's text.
            string whole_file;
            try
            {
                whole_file = File.ReadAllText(filename);
            }
            catch (Exception excp)
            {
                throw excp;
            }
            theFileName = filename;
            // Split into lines.
            whole_file = whole_file.Replace('\n', '\r');
            string[] lines = whole_file.Split(new char[] { '\r' },
                StringSplitOptions.RemoveEmptyEntries);
            // See how many rows and columns there are.
            int num_rows = lines.Length;
            int num_cols = lines[0].Split(',').Length;
            // Allocate the data array.
            string[,] values = new string[num_rows, num_cols];
            // Load the array.
            for (int r = 0; r < num_rows; r++)
            {
                string[] line_r = lines[r].Split(',');
                for (int c = 0; c < num_cols; c++)
                {
                    values[r, c] = line_r[c];
                }
            }
            if (values.Length > 0)
                isCSVLoaded = true;
            // Return the values.
            return values;
        }

        /// <summary>
        /// Gets the estate of loaded or no loaded CSV file
        /// </summary>
        public bool CSVisLoaded
        {
            get { return isCSVLoaded; }
        }

        /// <summary>
        /// Get the CSVFilena only.
        /// </summary>
        public string CSVFilename
        {
            get { return theFileName; }
        }
    }
}


