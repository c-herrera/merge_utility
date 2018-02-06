using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeBios
{
    class Merge
    {
        // normal merge attributes
        public string sbios_ver;
        public string sbios_path;
        public string preboot_ver;
        public string preboot_path;
        public string modvbt;
        public string modvbt_path;

        public string customvbt;
        public string merge_final_name;
        
        // standard command line options
        private string _sbios_use;
        private string _merge_use;
        private string _preboot_use;
        // non standard command line options
        private bool arg_production;
        private bool arg_hybrid;
        private bool arg_mipi;
        private bool arg_lpc;



        public Merge ()
        {
            // TBD
            sbios_ver = string.Empty;
            sbios_path = string.Empty;
            preboot_path = string.Empty;
            preboot_ver = string.Empty;

            modvbt = string.Empty;
            modvbt_path = string.Empty;

            merge_final_name = string.Empty;
            customvbt = string.Empty;

        }

        /// <summary>
        /// MergeBios routine, with and without modified vbt
        /// </summary>
        /// <param name="mergeExe"></param>
        /// <param name="sBIOS"></param>
        /// <param name="preBoot"></param>
        public void mergeBios (string mergeExe, string sBIOS, string preBoot)
        {

            // Put instrucctions to start merge

        }

        /// <summary>
        /// MergeBios routine, with and without modified vbt
        /// </summary>
        /// <param name="mergeExe"></param>
        /// <param name="sBIOS"></param>
        /// <param name="preBoot"></param>
        /// <param name="VBTFile"></param>
        public void mergeBios (string mergeExe, string sBIOS, string preBoot, string VBTFile)
        {

            // Put instrucctions to start merge

        }

        /// <summary>
        /// Auxiliary method, Copy files recursive
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destiny"></param>
        public void copy_files (string source, string destiny)
        {
            // TODO : copy instructions here
        }

        /// <summary>
        /// Auxiliary method, execute a process
        /// </summary>
        /// <param name="exename"></param>
        /// <param name="folderpath"></param>
        private void execute_command (string exename, string folderpath)
        {
            // Put process instrucions to execute programs
        }





        #region Accesors

        public string sbios_to_use
        {
            set
            {
                _sbios_use = value;
            }
        }

        public string merge_to_use
        {
            set
            {
                _merge_use = value;
            }
        }

        public string preboot_to_use
        {
            set
            {
                _preboot_use = value;
            }
        }


        #endregion

    }
}
