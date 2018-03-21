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
        private string vbt_name;       // default VBT file
        private string vbt_path;       // default VBT file path        
        private string merge_final_name; // name composite from selection on the ui
        private string Tools_Path;

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
		
		
		enum MERGE_ARCH { NOARCH, x32,x64  };

        enum LFP_OPTIONS { eDP,MIPI  };


        /// <summary>
        /// Public constructro, no overloaded.
        /// </summary>
        public Merge ()
        {
            // TBD
            sbios_path = string.Empty;
            sbios_ver = string.Empty;

            preboot_ver = string.Empty;
            preboot_path = string.Empty;

            vbt_name = string.Empty;
            vbt_path = string.Empty;

            merge_final_name = string.Empty;

            custom_vbt_name = string.Empty;
            custom_vbt_path = string.Empty;
        }

        /// <summary>
        /// MergeBios routine, with and without modified vbt
        /// </summary>
        /// <param name="mergeExe"></param>
        /// <param name="sBIOS"></param>
        /// <param name="preBoot"></param>
        public void SC_Create_merged_Bios (string mergeScript, string sBIOS, string preBoot)
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
        public void SC_Create_merged_Bios (string mergeScript, string sBIOS, string preBoot, string VBTFile)
        {

            // Put instrucctions to start merge

        }


        /// <summary>
        /// No Script Create and merge BIOS
        /// </summary>
        /// <param name="Gen"> Generation of platform</param>
        /// <param name="Preboot_type">GOP or VBIOS type</param>
        public void NS_Create_BIOS(int Gen, int Preboot_type )
        {
            // Placeholder
        }

        /// <summary>
        /// No Script Create and merge BIOS
        /// </summary>
        /// <param name="Gen"> Generation of platform</param>
        /// <param name="Preboot_type">GOP or VBIOS type</param>       
        public void NS_Create_BIOS_nC(int Gen, int Preboot_type)
        {
            // Placeholder
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

        /// <summary>
        /// Gets or set the new path to IFWI files
        /// </summary>
        public string IFWI_Path
        {
            get { return sbios_path;  }
            set { sbios_path = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string IFWI_label
        {
            get { return sbios_ver; }
            set { sbios_ver = value; }
        }

        /// <summary>
        /// Gets or set the preboot path for merge
        /// </summary>
        public string PreBoot_Path
        {
            get { return preboot_path;  }
            set { preboot_path = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string PreBoot_label
        {
            get { return preboot_ver; }
            set { preboot_ver = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string DefaultVBT_Path
        {
            get { return vbt_path; }
            set { vbt_path = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string DefaultVBT_label
        {
            get { return vbt_name; }
            set { vbt_name = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string CustomVBT_Mod_Path
        {
            get { return custom_vbt_path; }
            set { custom_vbt_path = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string CustomVBT_Mod_label
        {
            get { return custom_vbt_name; }
            set { custom_vbt_name = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string MergeBIOS_label
        {
            get { return merge_final_name; }
            set { merge_final_name = value; }
        }

        #endregion

    }
}
