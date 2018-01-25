using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeBios
{
    class Tool_Options
    {
		enum USER_PREFS
		{
			pref_current_work_folder, 	// folder to store flashfile
			pref_default_work_folder, // default flashfiles folder
			pref_startup_check,    // check for changes at startup
			pref_default_merge_folder, // folder to store the merge result
			pref_always_ask_merge_folder, // ask where to save
			pref_always_flash_bios        // flash bios auto
		};

		string[] pref_labels =
		{
			"currentWorkFolder=",
			"defaultWorkFolder=",
			"checkforChanges=",
			"defaultMergeFolder=",
			"AlwaysAsktoSave=",
			"AlwaysFlashBios=",
		};


        string folder_root_server;
        string folder_mydocuments;
        string folder_Desktop;


        public Tool_Options() // Constructor
        {            

        }

        public void save_preference(string pref_name, string value)
        {			
        }


        public void create_default_pref_files()
        {
            folder_root_server = @"\\amr\ec\proj\gm\GSTC\FlashFolders";
            folder_mydocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            folder_Desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);            

            string saveString = string.Empty;
            saveString += "[MBTU]" + Environment.NewLine;
            saveString += pref_labels[( int ) USER_PREFS.pref_current_work_folder] + @"C:\\TEMP" + Environment.NewLine;
            saveString += pref_labels[( int ) USER_PREFS.pref_default_work_folder] + @"C:\\TEMP" + Environment.NewLine;
            saveString += pref_labels[( int ) USER_PREFS.pref_startup_check] + "TRUE" + Environment.NewLine;
            saveString += pref_labels[( int ) USER_PREFS.pref_default_merge_folder] + folder_Desktop + Environment.NewLine;
            saveString += pref_labels[( int ) USER_PREFS.pref_always_ask_merge_folder] + "TRUE" + Environment.NewLine;
            saveString += pref_labels[( int ) USER_PREFS.pref_always_flash_bios] + "TRUE" + Environment.NewLine;


            File.WriteAllText("TEST.CFG" , saveString);

        }
    }
}
