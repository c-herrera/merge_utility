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
        private string sbios_ver;      // bios ver label
        private string sbios_path;     // bios file path
        private string preboot_ver;    // preboot ver label
        private string preboot_path;   // ptreboot file path
        private string modvbt_name     // VBT file
        private string modvbt_path;    // VBT file path        
        private string merge_final_name; // name composite from selection on the ui

        private string custom_vbt_name; // name of the custom vbt
        private string custom_vbt_path; // path ot the vbt

        private bool merge_folder_exist;   // folder must exist
        private bool preboot_folder_exist; // preboot folder must exist
        private bool is_dediprog_installed;// dediprog is installed
        private bool is_ttk_installed;

        //
        private bool use_lpc_ft;
        private bool use_prod_ft;
        private bool use_lfp_ft;

        public Merge ()
        {
            // TBD
        }

        /// <summary>
        /// MergeBios routine, with and without modified vbt
        /// </summary>
        /// <param name="mergeExe"></param>
        /// <param name="sBIOS"></param>
        /// <param name="preBoot"></param>
        public void Create_mergeBios (string mergeExe, string sBIOS, string preBoot)
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
        public void Create_mergeBios (string mergeExe, string sBIOS, string preBoot, string VBTFile)
        {

            // Put instrucctions to start merge

        }

        /// <summary>
        /// Auxiliary method, Copy files recursive
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destiny"></param>
        public void AuxM_copy_files (string source, string destiny)
        {
            // TODO : copy instructions here
        }

        /// <summary>
        /// Auxiliary method, execute a process
        /// </summary>
        /// <param name="exename"></param>
        /// <param name="folderpath"></param>
        private void AuxM_execute_command (string exename, string folderpath)
        {
            // Put process instructions to execute programs
        }



        #region Accesors




        #endregion

    }
}
