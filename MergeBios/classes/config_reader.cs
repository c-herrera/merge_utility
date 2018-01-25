using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MergeBios
{

    public static class IniFileHelper // Use these instead of above
    {
        public static int capacity = 512;


        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        private static extern int GetPrivateProfileString (string section, string key, string defaultValue, StringBuilder value, int size, string filePath);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        static extern int GetPrivateProfileString (string section, string key, string defaultValue, [In, Out] char[] value, int size, string filePath);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern int GetPrivateProfileSection (string section, IntPtr keyValue, int size, string filePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool WritePrivateProfileString (string section, string key, string value, string filePath);

        public static bool WriteValue (string section, string key, string value, string filePath)
        {
            bool result = WritePrivateProfileString(section, key, value, filePath);
            return result;
        }

        public static bool DeleteSection (string section, string filepath)
        {
            bool result = WritePrivateProfileString(section, null, null, filepath);
            return result;
        }

        public static bool DeleteKey (string section, string key, string filepath)
        {
            bool result = WritePrivateProfileString(section, key, null, filepath);
            return result;
        }

        public static string ReadValue (string section, string key, string filePath, string defaultValue = "")
        {
            var value = new StringBuilder(capacity);
            GetPrivateProfileString(section, key, defaultValue, value, value.Capacity, filePath);
            return value.ToString();
        }

        public static string[] ReadSections (string filePath)
        {
            // first line will not recognize if ini file is saved in UTF-8 with BOM
            while ( true )
            {
                char[] chars = new char[capacity];
                int size = GetPrivateProfileString(null, null, "", chars, capacity, filePath);

                if ( size == 0 )
                {
                    return null;
                }

                if ( size < capacity - 2 )
                {
                    string result = new String(chars, 0, size);
                    string[] sections = result.Split(new char[] { '\0' }, StringSplitOptions.RemoveEmptyEntries);
                    return sections;
                }

                capacity = capacity * 2;
            }
        }

        public static string[] ReadKeys (string section, string filePath)
        {
            // first line will not recognize if ini file is saved in UTF-8 with BOM
            while ( true )
            {
                char[] chars = new char[capacity];
                int size = GetPrivateProfileString(section, null, "", chars, capacity, filePath);

                if ( size == 0 )
                {
                    return null;
                }

                if ( size < capacity - 2 )
                {
                    string result = new String(chars, 0, size);
                    string[] keys = result.Split(new char[] { '\0' }, StringSplitOptions.RemoveEmptyEntries);
                    return keys;
                }

                capacity = capacity * 2;
            }
        }

        public static string[] ReadKeyValuePairs (string section, string filePath)
        {
            while ( true )
            {
                IntPtr returnedString = Marshal.AllocCoTaskMem(capacity * sizeof(char));
                int size = GetPrivateProfileSection(section, returnedString, capacity, filePath);

                if ( size == 0 )
                {
                    Marshal.FreeCoTaskMem(returnedString);
                    return null;
                }

                if ( size < capacity - 2 )
                {
                    string result = Marshal.PtrToStringAuto(returnedString, size - 1);
                    Marshal.FreeCoTaskMem(returnedString);
                    string[] keyValuePairs = result.Split('\0');
                    return keyValuePairs;
                }

                Marshal.FreeCoTaskMem(returnedString);
                capacity = capacity * 2;
            }
        }
    }



    /// <summary>
    /// ToolConf contains all the preferences the user can set on the ui
    /// </summary>
    struct MainPrefs
    {
        // user prefs
        public bool skip_remote_folder_check;
        public bool skip_remote_folder_tools;
        public bool always_auto_flash;
        public bool always_ask_save;
        public string default_save_folder_path;
        public string default_working_folder_path;
        public string active_working_folder_path;
        public string active_save_folder_path;
        public int default_flash_tool;
        // tool prefs
        public string default_srv_flash_path;
        public string default_srv_tool_path;
        public string default_srv_ssf_path;
    };

    enum FlashToolSelection
    {
        none, Dediprog, TTK
    };

    enum ConfigSections
    {
        user,
        tool
    };

    enum ToolConfOptions
    {
        skip_remote_folder,
        skip_remote_tool_folder,
        always_flash,
        always_ask_to_save,
        default_save_folder,
        default_working_folder,
        active_working_folder,
        active_save_folder,
        default_flash_tool,
        default_flashfolders_path,
        default_common_tool_path,
        default_ssf_path
    };


    class Tool_Config
    {
        MainPrefs options;
        public string[] flash_tool_names;
        string userconf_filepath;
        string def_flashfolder_path;
        string def_flashfolder_cmm_path;
        string def_ssf_path;
        string[] MainOptionSText;
        string[] ConfigSectionsText;
        string default_work_folder;

        bool valueGnr;
        string OptMeessage;


        /// <summary>
        /// Class constructor, no overloaded.
        /// </summary>
        public Tool_Config ()
        {
            MainPrefs options = new MainPrefs();
            OptMeessage = string.Empty;

            flash_tool_names = new string[] { "None", "Dediprog", "TTK" };
            userconf_filepath = Environment.CurrentDirectory + "\\" + "options.cfg";
            def_flashfolder_path = @"\\amr\ec\proj\gm\GSTC\FlashFolders";
            def_flashfolder_cmm_path = @"\\amr\ec\proj\gm\GSTC\FlashFolders\CommonTools";
            def_ssf_path = @"\\amr\ec\proj\gm\GSTC\DebugTeam\CreaM\SSF";

            // options are shared between user preferences and tool preferences
            MainOptionSText = new string[]
            {
                "skip_folder_check",
                "skip_folder_tools",
                "always_auto_flash_enabled",
                "always_ask_to_save_enabled",
                "default_save_dir",
                "default_working_dir",
                "active_working_dir",
                "active_save_dir",
                "default_flash_tool",
                "default_remote_flashfolder_path",
                "default_remote_coomon_tools_path",
                "default_remote_ssf_files_path",
            };

            ConfigSectionsText = new string[]
            {
                "user",
                "tool"
            };

            default_work_folder = "C:\\TEMP";

            if ( File.Exists(userconf_filepath) == false )
            {
                MessageBox.Show("Config file with default values will be created", " Missing Config File", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                CreateDefaultConfig();
            }

            OptMeessage = "Conf instance started";

        }

        /// <summary>
        /// Creates a file with the default preferences, used by tool and user 
        /// </summary>
        public void CreateDefaultConfig ()
        {
            // USer : Remote folder check
            valueGnr = false;
            IniFileHelper.WriteValue(ConfigSectionsText[( int ) ConfigSections.user], MainOptionSText[( int ) ToolConfOptions.skip_remote_folder], valueGnr.ToString().ToLower(), userconf_filepath);
            IniFileHelper.WriteValue(ConfigSectionsText[( int ) ConfigSections.user], MainOptionSText[( int ) ToolConfOptions.skip_remote_tool_folder], valueGnr.ToString(), userconf_filepath);

            // User : Always on options
            valueGnr = true;
            IniFileHelper.WriteValue(ConfigSectionsText[( int ) ConfigSections.user], MainOptionSText[( int ) ToolConfOptions.always_flash], valueGnr.ToString().ToLower(), userconf_filepath);
            IniFileHelper.WriteValue(ConfigSectionsText[( int ) ConfigSections.user], MainOptionSText[( int ) ToolConfOptions.always_ask_to_save], valueGnr.ToString(), userconf_filepath);

            // User : default folder options
            IniFileHelper.WriteValue(ConfigSectionsText[( int ) ConfigSections.user], MainOptionSText[( int ) ToolConfOptions.default_save_folder], Environment.GetFolderPath(Environment.SpecialFolder.Desktop).ToLower(), userconf_filepath);
            IniFileHelper.WriteValue(ConfigSectionsText[( int ) ConfigSections.user], MainOptionSText[( int ) ToolConfOptions.default_working_folder], default_work_folder.ToLower(), userconf_filepath);

            // User : Current work folder options
            IniFileHelper.WriteValue(ConfigSectionsText[( int ) ConfigSections.user], MainOptionSText[( int ) ToolConfOptions.active_working_folder], default_work_folder.ToLower(), userconf_filepath);
            IniFileHelper.WriteValue(ConfigSectionsText[( int ) ConfigSections.user], MainOptionSText[( int ) ToolConfOptions.active_save_folder], Environment.GetFolderPath(Environment.SpecialFolder.Desktop).ToLower(), userconf_filepath);

            // User  :Flash tool options
            IniFileHelper.WriteValue(ConfigSectionsText[( int ) ConfigSections.user], MainOptionSText[( int ) ToolConfOptions.default_flash_tool], flash_tool_names[( int ) FlashToolSelection.Dediprog].ToLower(), userconf_filepath);

            // Tool : default remote paths
            IniFileHelper.WriteValue(ConfigSectionsText[( int ) ConfigSections.tool], MainOptionSText[( int ) ToolConfOptions.default_flashfolders_path], def_flashfolder_path.ToLower(), userconf_filepath);
            IniFileHelper.WriteValue(ConfigSectionsText[( int ) ConfigSections.tool], MainOptionSText[( int ) ToolConfOptions.default_common_tool_path], def_flashfolder_cmm_path.ToLower(), userconf_filepath);
            IniFileHelper.WriteValue(ConfigSectionsText[( int ) ConfigSections.tool], MainOptionSText[( int ) ToolConfOptions.default_ssf_path], def_ssf_path.ToLower(), userconf_filepath);

            OptMeessage = "Default config file was created";

        }


        /// <summary>
        /// Loads the configuration parameters from the config file
        /// </summary>
        public void LoadConfiguration ()
        {
            string value = string.Empty;

            // Check for folder at startup
            value = IniFileHelper.ReadValue(ConfigSectionsText[( int ) ConfigSections.user], MainOptionSText[( int ) ToolConfOptions.skip_remote_folder], userconf_filepath).ToLower();
            if ( value.Contains("true") )
                options.skip_remote_folder_check = true;


            // check for Tools 
            value = IniFileHelper.ReadValue(ConfigSectionsText[( int ) ConfigSections.user], MainOptionSText[( int ) ToolConfOptions.skip_remote_tool_folder], userconf_filepath).ToLower();
            if ( value.Contains("true") )
                options.skip_remote_folder_tools = true;

            // Set to auto flash
            value = IniFileHelper.ReadValue(ConfigSectionsText[( int ) ConfigSections.user], MainOptionSText[( int ) ToolConfOptions.always_flash], userconf_filepath).ToLower();
            if ( value.Contains("true") )
                options.always_auto_flash = true;

            // Sets to ask to save always or not
            value = IniFileHelper.ReadValue(ConfigSectionsText[( int ) ConfigSections.user], MainOptionSText[( int ) ToolConfOptions.always_ask_to_save], userconf_filepath).ToLower();
            if ( value.Contains("true") )
                options.always_ask_save = true;

            // Set the default save dir
            value = IniFileHelper.ReadValue(ConfigSectionsText[( int ) ConfigSections.user], MainOptionSText[( int ) ToolConfOptions.default_save_folder], userconf_filepath).ToLower();
            if ( value != string.Empty || value != null )
            {
                options.default_save_folder_path = value;
            }

            // Set the default work folder
            value = IniFileHelper.ReadValue(ConfigSectionsText[( int ) ConfigSections.user], MainOptionSText[( int ) ToolConfOptions.default_working_folder], userconf_filepath).ToLower();
            if ( value != string.Empty || value != null )
                options.default_working_folder_path = value;

            // Get the active dir
            value = IniFileHelper.ReadValue(ConfigSectionsText[( int ) ConfigSections.user], MainOptionSText[( int ) ToolConfOptions.active_working_folder], userconf_filepath).ToLower();
            if ( value != string.Empty || value != null )
                options.active_working_folder_path = value;

            // Get active save dir
            value = IniFileHelper.ReadValue(ConfigSectionsText[( int ) ConfigSections.user], MainOptionSText[( int ) ToolConfOptions.active_save_folder], userconf_filepath).ToLower();
            if ( value != string.Empty || value != null )
                options.active_save_folder_path = value;

            // Get the Flashing tool to use always
            value = IniFileHelper.ReadValue(ConfigSectionsText[( int ) ConfigSections.user], MainOptionSText[( int ) ToolConfOptions.default_flash_tool], userconf_filepath).ToLower();
            for ( int i = 0 ; i < flash_tool_names.Length ; i++ )
            {
                if ( value.Contains(flash_tool_names[i].ToLower()) )
                    options.default_flash_tool = i;
            }

            // Tool : default remote paths
            value = IniFileHelper.ReadValue(ConfigSectionsText[( int ) ConfigSections.tool], MainOptionSText[( int ) ToolConfOptions.default_flashfolders_path], userconf_filepath).ToLower();
            if ( value != string.Empty || value != null )
                options.default_srv_flash_path = value;

            value = IniFileHelper.ReadValue(ConfigSectionsText[( int ) ConfigSections.tool], MainOptionSText[( int ) ToolConfOptions.default_common_tool_path], userconf_filepath).ToLower();
            if ( value != string.Empty || value != null )
                options.default_srv_tool_path = value;

            value = IniFileHelper.ReadValue(ConfigSectionsText[( int ) ConfigSections.tool], MainOptionSText[( int ) ToolConfOptions.default_ssf_path], userconf_filepath).ToLower();
            if ( value != string.Empty || value != null )
                options.default_srv_ssf_path = value;


            OptMeessage = "Load Configuration from file";
        }

        /// <summary>
        /// Saves all parameters from UI to a file
        /// </summary>
        public void SaveConfiguration ()
        {

            // Remote folder check            
            IniFileHelper.WriteValue(ConfigSectionsText[( int ) ConfigSections.user], MainOptionSText[( int ) ToolConfOptions.skip_remote_folder], options.skip_remote_folder_check.ToString().ToLower(), userconf_filepath);
            IniFileHelper.WriteValue(ConfigSectionsText[( int ) ConfigSections.user], MainOptionSText[( int ) ToolConfOptions.skip_remote_tool_folder], options.skip_remote_folder_tools.ToString().ToLower(), userconf_filepath);

            // Always on options
            IniFileHelper.WriteValue(ConfigSectionsText[( int ) ConfigSections.user], MainOptionSText[( int ) ToolConfOptions.always_flash], options.always_auto_flash.ToString().ToLower(), userconf_filepath);
            IniFileHelper.WriteValue(ConfigSectionsText[( int ) ConfigSections.user], MainOptionSText[( int ) ToolConfOptions.always_ask_to_save], options.always_ask_save.ToString().ToLower(), userconf_filepath);

            // default folder options
            IniFileHelper.WriteValue(ConfigSectionsText[( int ) ConfigSections.user], MainOptionSText[( int ) ToolConfOptions.default_save_folder], options.default_save_folder_path.ToLower(), userconf_filepath);
            IniFileHelper.WriteValue(ConfigSectionsText[( int ) ConfigSections.user], MainOptionSText[( int ) ToolConfOptions.default_working_folder], options.default_working_folder_path.ToLower(), userconf_filepath);

            // Current work folder options
            IniFileHelper.WriteValue(ConfigSectionsText[( int ) ConfigSections.user], MainOptionSText[( int ) ToolConfOptions.active_working_folder], options.active_working_folder_path.ToLower(), userconf_filepath);
            IniFileHelper.WriteValue(ConfigSectionsText[( int ) ConfigSections.user], MainOptionSText[( int ) ToolConfOptions.active_save_folder], options.active_save_folder_path.ToLower(), userconf_filepath);

            // Flash tool options
            IniFileHelper.WriteValue(ConfigSectionsText[( int ) ConfigSections.user], MainOptionSText[( int ) ToolConfOptions.default_flash_tool], flash_tool_names[options.default_flash_tool].ToLower(), userconf_filepath);

            OptMeessage = "Configuration was saved";
        }

        #region Accesors


        /// <summary>
        /// SEt or gets the "Check for Remote Folder" at startup
        /// </summary>
        public bool opt_remote_folder_check
        {
            get
            {
                return options.skip_remote_folder_check;
            }
            set
            {
                options.skip_remote_folder_check = value;
            }
        }

        /// <summary>
        /// Sets or gets the "Check for Remote Tool Folders" at startup
        /// </summary>
        public bool opt_remote_tool_check
        {
            get
            {
                return options.skip_remote_folder_tools;
            }
            set
            {
                options.skip_remote_folder_tools = value;
            }
        }

        /// <summary>
        /// Sets or gets the preference of "Auto Flash"
        /// </summary>
        public bool opt_auto_flash
        {
            get
            {
                return options.always_auto_flash;
            }
            set
            {
                options.always_auto_flash = value;
            }
        }

        /// <summary>
        /// Set or gets preference of "Always ask to save in"
        /// </summary>
        public bool opt_ask_for_save
        {
            get
            {
                return options.always_ask_save;
            }

            set
            {
                options.always_ask_save = value;
            }
        }


        /// <summary>
        /// Gets the path to the default save folder, User Desktop
        /// </summary>
        public string opt_default_save_path
        {
            get
            {
                return options.default_save_folder_path;
            }
        }

        /// <summary>
        /// Gets the default path of merge files and tools
        /// </summary>
        public string opt_default_working_folder
        {
            get
            {
                return options.default_working_folder_path;
            }
        }

        /// <summary>
        /// Sets or get current Working folder path (Not C:\Temp)
        /// </summary>
        public string opt_active_working_path
        {
            get
            {
                return options.active_working_folder_path;
            }
            set
            {
                options.active_working_folder_path = value;
            }
        }

        /// <summary>
        /// Sets or gets the Current save folder path
        /// </summary>
        public string opt_active_save_path
        {
            get
            {
                return options.active_save_folder_path;
            }
            set
            {
                options.active_save_folder_path = value;
            }
        }

        /// <summary>
        /// Set or gets the Default flashing tool name
        /// </summary>
        public int opt_default_flash_tool
        {
            get
            {
                return options.default_flash_tool;
            }
            set
            {
                options.default_flash_tool = value;
            }
        }

        /// <summary>
        /// Sets or gets the remote path of the flashfolder files
        /// </summary>
        public string opt_default_tool_server_flashfolder_path
        {
            get
            {
                return options.default_srv_flash_path;
            }
            set
            {
                options.default_srv_flash_path = value;
            }
        }

        /// <summary>
        /// Sets or gets the remote path of the flashfolder common tool path
        /// </summary>
        public string opt_default_tool_server_common_tool_path
        {
            get
            {
                return options.default_srv_tool_path;
            }
            set
            {
                options.default_srv_tool_path = value;
            }
        }

        /// <summary>
        /// Sets or gets the default ssf server path 
        /// </summary>
        public string opt_default_tool_server_ssf_path
        {
            get
            {
                return options.default_srv_ssf_path;
            }
            set
            {
                options.default_srv_ssf_path = value;
            }
        }

        /// <summary>
        /// Gets the mesasge from class actions
        /// </summary>
        public string Message
        {
            get
            {
                return OptMeessage;
            }
        }

        #endregion


    }

}
