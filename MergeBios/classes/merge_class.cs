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
        // standard command line options
        private string _sbios_use;
        private string _merge_use;
        private string _preboot_use;

        // non standard command line options
        public bool opt_production;
        public bool opt_hybrid;
        public bool opt_mipi;
        public bool opt_lpc;

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

        public Merge ()
        {
            // TBD
        }

        public void mergeBios (string mergeExe, string sBIOS, string preBoot)
        {
            string prod = string.Empty;

            if ( opt_production )
            {
                prod = "PROD";
            }

            if ( opt_hybrid )
            {
            }

            if ( opt_mipi )
            {
            }

            if ( opt_lpc )
            {
            }

            // copy if not present the needed copy_files
            // if (Directory.Exists(path_to_project + sbios_to_use))
            // copy_files (path_to_sbios+ _sbios_use,path_of_workfolder + _sbios_use);
            // if (Directory.Exists(path_to_project + preboot))
            // copy_files (path_to_preboot + _preboot_use, path_of_workfolder + _sbios_use);

            // if (File.Exist(path_to_project + _merge_use))
            // copy_files (path_to_server + project + _merge_use, path_to_project + _merge_use);

            // Put instrucctions to start merge

        }

        public void mergeBios (string mergeExe, string sBIOS, string preBoot, string VBTFile)
        {
            string prod = string.Empty;

            if ( opt_production )
            {
                prod = "PROD";
            }

            if ( opt_hybrid )
            {
            }

            if ( opt_mipi )
            {
            }

            if ( opt_lpc )
            {
            }

            // copy if not present the needed copy_files
            // if (Directory.Exists(path_to_project + sbios_to_use))
            // copy_files (path_to_sbios+ _sbios_use,path_of_workfolder + _sbios_use);
            // if (Directory.Exists(path_to_project + preboot))
            // copy_files (path_to_preboot + _preboot_use, path_of_workfolder + _sbios_use);

            // if (File.Exist(path_to_project + _merge_use))
            // copy_files (path_to_server + project + _merge_use, path_to_project + _merge_use);

            // Put instrucctions to start merge

        }

        public void copy_files (string source, string destiny)
        {
            // TODO : copy instructions here
        }


        private void execute_command (string exename, string folderpath)
        {
            // Put process instrucions to execute programs
        }

        private bool copy_required(string path)
        {
			bool state = false;

			return state;
        }

        private bool check_changes(string path)
        {
			bool state = false;
			return state;
        }

    }
}
