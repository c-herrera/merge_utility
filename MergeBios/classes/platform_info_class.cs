using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MergeBios
{
    /// <summary>
    /// Platform full data ; loads from [platform_db.csv]
    /// </summary>
    struct platform_struct_db
    {
        public string platform_name;    // platform name from file
        public string platform_type;    // platform type from file
        public string platform_arch;    // platform arch
        public string preboot;          // preboot info
        public string merge_script;     // script used to merge
        public string server_path_project;  // the project path
        public string server_path_bios;     // the bios root path 
        public string server_path_bios_prod; // 
        public string server_path_preboot;    // path to gop / vbios
        public string server_path_ksc;      // path to ksc
        public string server_path_sff_files;// path to  the ssf files
        public string branch;           // tablet or client
        public string[] stepping;       // holds the stepping definition
        public string[] production_types;  // Holds the Production or preproduction label
        public string[] platform_features; // features of the stored platform
        public string[] default_displays;  // default display list
        public string dediprog_spi_vcc_arg;
        public string dediprog_ec_vcc_arg;
        // Search methods
        public bool search_stitch;
        public bool search_stepping;
        public bool search_prefix_folder;
        public bool search_suffixfolder;
        public bool search_skipword;
        public bool search_by_suffix_and_skip;

        public string bios_name_prefix;      // bios file prefix
        public string bios_name_ext;         // bios file extension
        public string merge_name_prefix;     // merge name prefix
        public string merge_name_ext;        // merge name ext
        public string[] prefix_folder;       // search by prefix folder
        public string flash_batch_cmd;       // command batch
        public string modfile_name;          // modfile name

        public string skip_folder_word;      // Skip a folder name
        public string stitch_path;

        public bool isx64;              // architecture is 64 bit
        public bool isx32;              // architecture is 32 bit
        public bool noarch;             // architecture is not defined
        public bool has_displays;       // set to true to enable display selection
        public int platform_id;         // TBD
        public int platform_type_id;    // TBD
        public int type_branch;         // Holds the branch type (client / tablet)
        public int default_arch;        // default architecture 32 or 64 bit
        public int isgop;               // the platform selected is gop based
        public int isvbios;             // the platform selected is legacy
        public int preboot_type;        // preboot type to support election
        public int release_sku_type;    // type of release cpu ( preproduction , production or both ) 

    };

    /// <summary>
    /// UI configuration data , loads from [platform_ui.csv]
    /// </summary>
    struct platform_ui_config
    {
        public string platform;
        public string type;
        public int branch;
        public bool enablex32gop;
        public bool enablex64gop;
        public bool enablex32vbios;
        public bool enablex64vbios;
        public bool enable_prod;
        public bool ui_mipi;
        public bool ui_seq;
        public bool ui_cs;
        public bool ui_hybrid;
        public bool ui_stepping;
        public bool ui_panel_lvds; // legacy platforms panels
        public bool ui_panel_edp;
        public bool port_option;
        public bool dnx_option;
        public bool ksc_option;
        public bool secondstage_option;
        public bool dediprog_option;
        public bool is_still_in_use;
    };

    /// <summary>
    /// enum to select the column data from [platform_db.csv] 
    /// </summary>
    enum PLATFORM_DB_HEADER
    {
        Platform_name, 
        Type,
        Arch,
        Preboot,
        Batch,
        Project_Path,
        PathBIOS,
        Path_Preboot,
        Path_KSC,
        PathSSF,
        Branch,
        CPU_Stepping,
        Production,
        PlatformFeatures,
        Default_Displays,
        dediprog_spi_arg,
        dediprog_ec_arg,
        search_ifwi_opt,
        BIOS_Normal_Prefix,
        BIOS_Normal_Ext,
        Merge_File_prefix,
        Merge_File_Ext,
        Search_Folder_suffix,
        Flash_Command,
        modfile,
        SkipWordinFolder

    };

    /// <summary>
    /// enum to select the column data from [platform_ui.csv] 
    /// </summary>
    enum PLATFORM_UI_HEADER
    {
        platform,
        type,
        branch_type,
        enable_x32gop,        
        enable_x32_vbios,
        enable_x64gop,
        enable_x64_vbios,
        enable_production,
        enable_ui_features,
        enable_ports,
        enable_dnx,
        enable_ksc,
        enable_secondstage,
        enable_dediprog,
        enable_platform
    };


    /// <summary>
    /// enum selector for the branch 
    /// </summary>
    enum PLATFORM_BRANCH_ID
    {
        tablet, client
    };

    /// <summary>
    /// ID for platform projects TBD 
    /// </summary>
    enum PLATFORM_PROJECTS_ID
    {
        CNL, GLK, KBL, BXT, SKL, BDW, HSW, HSW_BDW, CHV, IVB, SNB, VLV
    };

    /// <summary>
    /// ID for platform types TBD
    /// </summary>
    enum PLATFORM_TYPES_ID
    {
        RVP1, RVP3, RVP7, RVP8, RVP10, RVP11, MD, DT, ULT, ULX, DT8 ,DT10, DT11, REFRESH, HALO, ULT_REFRESH
    };

    /// <summary>
    /// ID for display types 
    /// </summary>
    enum DISPLAY_TYPES_ID
    {
        edp, mipi, dp, hdmi, lspcon ,usb_c, lvds
    };

    /// <summary>
    /// ID for preboot types
    /// </summary>
    enum PREBOOT_TYPES_ID
    {
        vbios, gop
    };

    /// <summary>
    /// ID for architeture types
    /// </summary>
    enum ARCH_TYPE
    {
        noarch, x_32 = 32, x_64 = 64
    };

    /// <summary>
    /// ID for production IFWI types
    /// </summary>
    enum PRODUCTION_ID
    {
        preproduction, production, both
    };

    /// <summary>
    /// Platform features 
    /// </summary>
    enum PLATFORM_FEATURES_ID
    {
        f_mipi, f_seq_mipi, f_cs, f_hybrid, f_prod
    };

    /// <summary>
    /// Type of IFWI search
    /// </summary>
    enum SEARCH_WORDS
    {
        by_stitch, stepping, prefixfolder, suffixfolder, skipfoldername
    }
    

    class Platform_Info
    {
        LoadCSV PlatformCSV = new LoadCSV();       // Read all attributes from csv file
        platform_struct_db[] pt_db;            // Platform DB
        platform_ui_config[] pt_ui;                   // Platform ui config

        public string[,] platform_data;         // contains all the info about the platform type, bios, gop, etc
        public string[,] platform_ui_config;    // contains all the ui options
        public string[,] platform_list;         // contains al platform and types on a list

        private int num_platforms_db;
        private int num_platforms_ui;

        public string[] bios_list;              // system bios list
        public string[] preboot_list;           // preboot list

        private int data_index = 0;
        private int ui_index = 0;

        const string filename_platform_db = "platform_main_conf_db.csv";
        const string filename_platform_ui = "platform_ui_conf.csv";
        const string filename_platform_menu = "platform_menu_conf.csv";

        public string[] preboot_names = { "VBIOS", "EFI" };

        #region Platform  attribute accessors

        // Platform  attribute accessors

        /// <summary>
        ///  Returns the current name of platform project
        /// </summary>
        public string platform_Name
        {
            get
            {
                return pt_db[data_index].platform_name;
            }
        }

        /// <summary>
        /// Return the name of the platform type
        /// </summary>
        public string platform_Type
        {
            get
            {
                return pt_db[data_index].platform_type;
            }
        }

        /// <summary>
        /// Return the platform architecture
        /// </summary>
        public string platform_Arch
        {
            get
            {
                return pt_db[data_index].platform_arch;
            }
        }

        /// <summary>
        /// Return the platform preboot [label]
        /// </summary>
        public string platform_Preboot
        {
            get
            {
                return pt_db[data_index].preboot;
            }
        }

        /// <summary>
        /// Return the platform Merge script
        /// </summary>
        public string platform_MergeScript
        {
            get
            {
                return pt_db[data_index].merge_script;
            }
        }

        /// <summary>
        ///  Contains the full path to the project
        /// </summary>
        public string platform_ProjectPath
        {
            get
            {
                return pt_db[data_index].server_path_project;
            }
        }

        /// <summary>
        /// Return the platform path to system bios
        /// </summary>
        public string platform_Path_to_SBIOS
        {
            get
            {
                return pt_db[data_index].server_path_bios;
            }
        }

        /// <summary>
        /// Return the platform path to preboot files
        /// </summary>
        public string platform_Path_to_Preboot
        {
            get
            {
                return pt_db[data_index].server_path_preboot;
            }
        }

        /// <summary>
        /// Returns the full path to KSC .bin files
        /// </summary>
        public string platform_path_to_ksc
        {
            get
            {
                return pt_db[data_index].server_path_ksc;
            }
        }

        /// <summary>
        /// Return the platform path to custom ssf files
        /// </summary>
        public string platform_Path_to_SSF
        {
            get
            {
                return pt_db[data_index].server_path_sff_files;
            }
        }

        /// <summary>
        /// Return the platform branch type [label]
        /// </summary>
        public string platform_Branch_Type
        {
            get
            {
                return pt_db[data_index].branch;
            }
        }

        /// <summary>
        /// Return the platform stepping [label]
        /// </summary>
        public string[] platform_Stepping
        {
            get
            {
                return pt_db[data_index].stepping;
            }
        }

        /// <summary>
        /// Return the platform has production type [label]
        /// </summary>
        public string[] platform_Productiontype
        {
            get
            {
                return pt_db[data_index].production_types;
            }
        }

        /// <summary>
        /// Return the platform feature [MIPI-SEQ-CS] [label]
        /// </summary>
        public string[] platform_Features
        {
            get
            {
                return pt_db[data_index].platform_features;
            }
        }

        /// <summary>
        /// Return the platform default displays [not label]
        /// </summary>
        public string[] platform_Default_Displays
        {
            get
            {
                return pt_db[data_index].default_displays;
            }
        }

        /// <summary>
        /// Returns the argument send to dediprog command line for spi flashing
        /// </summary>
        public string platform_dediprog_spi_vcc_arg
        {
            get
            {
                return pt_db[data_index].dediprog_spi_vcc_arg;
            }
        }

        /// <summary>
        /// Returns the argument send to dediprog command line for ec flashing
        /// </summary>
        public string platform_dediprog_ec_vcc_arg
        {
            get
            {
                return pt_db[data_index].dediprog_ec_vcc_arg;
            }
        }

        /// <summary>
        /// Return the platform architecture is X64
        /// </summary>
        public bool platform_is_x64
        {
            get
            {
                return pt_db[data_index].isx64;
            }
        }

        /// <summary>
        /// Return the platform architecture is X32
        /// </summary>
        public bool platform_is_x32
        {
            get
            {
                return pt_db[data_index].isx32;
            }
        }

        /// <summary>
        /// Return the platform is NA [client]
        /// </summary>
        public bool platform_noArch
        {
            get
            {
                return pt_db[data_index].noarch;
            }
        }

        /// <summary>
        /// Return the platform ID [TBD]
        /// </summary>
        public int platformID
        {
            get
            {
                return pt_db[data_index].platform_id;
            }
        }

        /// <summary>
        /// Return the platform typeID [TBD]
        /// </summary>
        public int platformTypeID
        {
            get
            {
                return pt_db[data_index].platform_type_id;
            }
        }

        /// <summary>
        /// Return the platform branch [tablet|client]
        /// </summary>
        public int platform_TypeBranch
        {
            get
            {
                return pt_db[data_index].type_branch;
            }
        }

        /// <summary>
        /// Return the platform default architecture
        /// </summary>
        public int platform_DefaultArch
        {
            get
            {
                return pt_db[data_index].default_arch;
            }
        }

        /// <summary>
        /// Return if type has GOP
        /// </summary>
        public int platformHasGOP
        {
            get
            {
                return pt_db[data_index].isgop;
            }
        }

        /// <summary>
        /// Return if type has VBIOS
        /// </summary>
        public int platformHasVBIOS
        {
            get
            {
                return pt_db[data_index].isvbios;
            }
        }

        /// <summary>
        /// Return the platform preboot [enum]
        /// </summary>
        public int platformPrebootType
        {
            get
            {
                return pt_db[data_index].preboot_type;
            }
        }

        /// <summary>
        /// Contains the bios filename prefix
        /// </summary>
        public string platform_bios_file_prefix
        {
            get
            {
                return pt_db[data_index].bios_name_prefix;
            }
        }

        /// <summary>
        /// Contains the bios file extension
        /// </summary>
        public string platform_bios_file_ext
        {
            get
            {
                return pt_db[data_index].bios_name_ext;
            }
        }

        /// <summary>
        /// Contains the merge bios result filename prefix
        /// </summary>
        public string platform_merge_bios_prefix
        {
            get
            {
                return pt_db[data_index].merge_name_prefix;
            }
        }

        /// <summary>
        /// Contains the merge bios file extension
        /// </summary>
        public string platform_merge_bios_ext
        {
            get
            {
                return pt_db[data_index].merge_name_ext;
            }
        }

        /// <summary>
        /// Contains the prefix folder to search the bios [only selected platforms]
        /// </summary>
        public string[] platform_prefix_folder
        {
            get
            {
                return pt_db[data_index].prefix_folder;
            }
        }

        /// <summary>
        /// Contains the flash command of the platform
        /// </summary>
        public string platform_flash_command
        {
            get
            {
                return pt_db[data_index].flash_batch_cmd;
            }
        }

        /// <summary>
        /// Has the name of the designed modfile (from the bmp program)
        /// </summary>
        public string platform_bmp_modfile_name
        {
            get
            {
                return pt_db[data_index].modfile_name;
            }
        }

        /// <summary>
        /// Has the name to skip on certain projects
        /// </summary>
        public string platform_folder_to_skip
        {
            get
            {
                return pt_db[data_index].skip_folder_word;
            }
        }

        /// <summary>
        /// Holds the platform release sku type (PROD | PREPROD | BOTH )
        /// </summary>
        public int platform_release_type
        {
            get
            {
                return pt_db[data_index].release_sku_type;
            }
        }

        /// <summary>
        /// Defines bios search by stepping
        /// </summary>
        public bool search_by_stepping
        {
            get
            {
                return pt_db[data_index].search_stepping;
            }
        }

        /// <summary>
        /// Define bios search by folder prefix
        /// </summary>
        public bool search_by_prefix
        {
            get
            {
                return pt_db[data_index].search_prefix_folder;
            }
        }

        /// <summary>
        /// Define if a bios search will skip a certain folder
        /// </summary>
        public bool search_and_skip
        {
            get
            {
                return pt_db[data_index].search_skipword;
            }
        }

        /// <summary>
        /// Define if a bios search will be focused on the folder suffix (last part)
        /// </summary>
        public bool search_by_suffix
        {
            get
            {
                return pt_db[data_index].search_suffixfolder;
            }
        }

        /// <summary>
        /// Define search by skipword and suffix combo
        /// </summary>
        public bool search_by_suffix_and_skipword
        {
            get
            {
                return pt_db[data_index].search_by_suffix_and_skip;
            }
        }


        #endregion

        #region Platform ui attribute accessors
        /// <summary>
        /// [UI] Get the platform name
        /// </summary>
        public string ui_plt_name
        {
            get
            {
                return pt_ui[ui_index].platform;
            }
        }

        /// <summary>
        /// [UI] Get the platform type
        /// </summary>
        public string ui_plt_type
        {
            get
            {
                return pt_ui[ui_index].type;
            }
        }

        /// <summary>
        ///  Get the platform branch, aid in the UI
        /// </summary>
        public int ui_branch
        {
            get
            {
                return pt_ui[ui_index].branch;

            }
        }

        /// <summary>
        /// [UI] Get the platform arch, to enable 32 bit GOP
        /// </summary>
        public bool ui_enable_x32_gop
        {
            get
            {
                return pt_ui[ui_index].enablex32gop;
            }
        }

        /// <summary>
        /// [UI] Get the platform arch, to enable 32 bit VBIOS
        /// </summary>
        public bool ui_enable_x32_vbios
        {
            get
            {
                return pt_ui[ui_index].enablex32vbios;
            }
        }

        /// <summary>
        /// [UI] Get the platform arch, to enable 64 bit GOP
        /// </summary>
        public bool ui_enable_x64_gop
        {
            get
            {
                return pt_ui[ui_index].enablex64gop;
            }
        }

        /// <summary>
        /// [UI] Get the platform arch, to enable 64 VBIOS
        /// </summary>
        public bool ui_enable_x64_vbios
        {
            get
            {
                return pt_ui[ui_index].enablex64vbios;
            }
        }

        /// <summary>
        /// [UI] Get the platform production option
        /// </summary>
        public bool ui_enable_production
        {
            get
            {
                return pt_ui[ui_index].enable_prod;
            }
        }

        /// <summary>
        /// [UI] Get the platform MIPI option
        /// </summary>
        public bool ui_enable_mipi
        {
            get
            {
                return pt_ui[ui_index].ui_mipi;
            }
        }

        /// <summary>
        /// [UI] Get the platform MIPI sequence option
        /// </summary>
        public bool ui_enable_seq
        {
            get
            {
                return pt_ui[ui_index].ui_seq;
            }
        }

        /// <summary>
        /// [UI] Get the platform Connected Stanby (if any)
        /// </summary>
        public bool ui_enable_cs
        {
            get
            {
                return pt_ui[ui_index].ui_cs;
            }
        }
        /// <summary>
        /// [UI] Get the platform Switchable Graphics
        /// </summary>
        public bool ui_enable_hybrid
        {
            get
            {
                return pt_ui[ui_index].ui_hybrid;
            }
        }

        /// <summary>
        /// [UI] Get the platform stepping option
        /// </summary>
        public bool ui_enable_stepping
        {
            get
            {
                return pt_ui[ui_index].ui_stepping;
            }
        }

        /// <summary>
        /// [UI] Get the platform Display options
        /// </summary>
        public bool ui_enable_display_ports
        {
            get
            {
                return pt_ui[ui_index].port_option;
            }
        }

        /// <summary>
        /// [UI] Get the platform DNX option
        /// </summary>
        public bool ui_enable_dnx_option
        {
            get
            {
                return pt_ui[ui_index].dnx_option;
            }
        }


        /// <summary>
        /// [UI] Get the KSC option
        /// </summary>
        public bool ui_enable_ksc
        {
            get
            {
                return pt_ui[ui_index].ksc_option;
            }
        }

        /// <summary>
        /// [UI] Get the Second Stage option
        /// </summary>
        public bool ui_enable_secondstage
        {
            get
            {
                return pt_ui[ui_index].secondstage_option;
            }

        }

        /// <summary>
        /// [UI] Get the Dediprog option
        /// </summary>
        public bool ui_enable_dediprog
        {
            get
            {
                return pt_ui[ui_index].dediprog_option;
            }
        }

        /// <summary>
        /// [UI] Get the config status to enable LVDS on ui
        /// </summary>
        public bool ui_enable_lvds_option
        {
            get
            {
                return pt_ui[ui_index].ui_panel_lvds;
            }
        }

        /// <summary>
        /// [UI] Get the config status to enable EDP on ui
        /// </summary>
        public bool ui_enable_edp_option
        {

            get
            {
                return pt_ui[ui_index].ui_panel_edp;
            }
        }

        /// <summary>
        /// Platform will be visible [TBD]
        /// </summary>
        public bool ui_platform_visible
        {
            get
            {
                return pt_ui[ui_index].is_still_in_use;
            }
        }

        #endregion


        public Platform_Info()
        {
        // Constructor [no overloaded, TBD]
        }
        #region class methods

        /// <summary>
        /// Load all the config for UI and DB
        /// </summary>
        public void Load_Platform_Data()
        {
            platform_data = PlatformCSV.LoadCsv(Path.GetFullPath(Path.Combine(Application.StartupPath, "..\\..")) + "\\" + filename_platform_db);
            platform_ui_config = PlatformCSV.LoadCsv(Path.GetFullPath(Path.Combine(Application.StartupPath, "..\\..")) + "\\" + filename_platform_ui);
            platform_list = PlatformCSV.LoadCsv(Path.GetFullPath(Path.Combine(Application.StartupPath, "..\\..")) + "\\" + filename_platform_menu);


            int num_rows = platform_data.GetUpperBound(0) + 1;   // Max row of platform db
            int num_cols = platform_data.GetUpperBound(1) + 1;

            int num_r = platform_ui_config.GetUpperBound(0) + 1; // max row of platform ui db
            int num_c = platform_ui_config.GetUpperBound(1) + 1;

            num_platforms_db = num_rows;
            num_platforms_ui = num_r;

            // create enough space for all config
            pt_db = new platform_struct_db[num_platforms_db];
            pt_ui = new platform_ui_config[num_platforms_ui];


            for ( int i = 1 ; i < num_rows ; i++ )
            {
                // Platform name and type
                pt_db[i].platform_name = platform_data[i , ( int ) PLATFORM_DB_HEADER.Platform_name];
                pt_db[i].platform_type = platform_data[i , ( int ) PLATFORM_DB_HEADER.Type];

                // Arch is NA if not defined
                pt_db[i].platform_arch = platform_data[i , ( int ) PLATFORM_DB_HEADER.Arch];

                if ( pt_db[i].platform_arch.Equals("NA") )
                {
                    pt_db[i].noarch = true;
                    pt_db[i].default_arch = ( int ) ARCH_TYPE.noarch;
                }

                // Arch x32
                if ( pt_db[i].platform_arch.Equals("X32") )
                {
                    pt_db[i].isx32 = true;
                    pt_db[i].default_arch = ( int ) ARCH_TYPE.x_32;
                }
                // arch x64
                if ( pt_db[i].platform_arch.Equals("X64") )
                {
                    pt_db[i].isx64 = true;
                    pt_db[i].default_arch = ( int ) ARCH_TYPE.x_64;
                }


                // Preboot info
                pt_db[i].preboot = platform_data[i , ( int ) PLATFORM_DB_HEADER.Preboot];
                if ( platform_data[i , ( int ) PLATFORM_DB_HEADER.Preboot] == "GOP" )
                {
                    pt_db[i].isgop = ( int ) PREBOOT_TYPES_ID.gop;
                    pt_db[i].preboot_type = ( int ) PREBOOT_TYPES_ID.gop;
                }

                if ( platform_data[i , ( int ) PLATFORM_DB_HEADER.Preboot] == "VBIOS" )
                {
                    pt_db[i].isvbios = ( int ) PREBOOT_TYPES_ID.vbios;
                    pt_db[i].preboot_type = ( int ) PREBOOT_TYPES_ID.vbios;
                }

                // Path info
                // Merge name
                pt_db[i].merge_script = platform_data[i , ( int ) PLATFORM_DB_HEADER.Batch];


                // Project path
                pt_db[i].server_path_project = platform_data[i, ( int ) PLATFORM_DB_HEADER.Project_Path];
                // Project path bios
                pt_db[i].server_path_bios = platform_data[i , ( int ) PLATFORM_DB_HEADER.PathBIOS];
                // Project path to preboot files
                pt_db[i].server_path_preboot = platform_data[i , ( int ) PLATFORM_DB_HEADER.Path_Preboot];
                // Path to KSC
                if ( platform_data[i, ( int ) PLATFORM_DB_HEADER.Path_KSC] != "NA")
                {
                    pt_db[i].server_path_ksc = platform_data[i, ( int ) PLATFORM_DB_HEADER.Path_KSC];
                }
                else
                {
                    pt_db[i].server_path_ksc = string.Empty;
                }


                // Path to custom non display ssf files
                pt_db[i].server_path_sff_files = platform_data[i , ( int ) PLATFORM_DB_HEADER.PathSSF];

                // Branch info
                pt_db[i].branch = platform_data[i , ( int ) PLATFORM_DB_HEADER.Branch];
                if ( pt_db[i].branch.Equals("TABLET") )
                    pt_db[i].type_branch = ( int ) PLATFORM_BRANCH_ID.tablet;
                if ( pt_db[i].branch.Equals("CLIENT") )
                    pt_db[i].type_branch = ( int ) PLATFORM_BRANCH_ID.client;

                // Stepping info
                if ( platform_data[i , ( int ) PLATFORM_DB_HEADER.CPU_Stepping] != "NA" )
                {
                    pt_db[i].stepping = platform_data[i , ( int ) PLATFORM_DB_HEADER.CPU_Stepping].Split('-');
                }
                else
                {
                    pt_db[i].stepping = new string[1];
                    pt_db[i].stepping[0] = platform_data[i , ( int ) PLATFORM_DB_HEADER.CPU_Stepping];
                }

                // Production bios info
                pt_db[i].production_types = platform_data[i, ( int ) PLATFORM_DB_HEADER.Production].Split('-');
                for (int j = 0 ; j < pt_db[i].production_types.Length ; j++ )
                {
                    if ( pt_db[i].production_types[j] == "BOTH" )
                        pt_db[i].release_sku_type = ( int ) PRODUCTION_ID.both;
                    else if ( pt_db[i].production_types[j] == "PROD" )
                        pt_db[i].release_sku_type = ( int ) PRODUCTION_ID.production;
                    else if ( pt_db[i].production_types[j] == "PREPROD" )
                        pt_db[i].release_sku_type = ( int ) PRODUCTION_ID.preproduction;
                }

                // Platform features
                if ( platform_data[i , ( int ) PLATFORM_DB_HEADER.PlatformFeatures] != "NA" )
                {
                    pt_db[i].platform_features = platform_data[i , ( int ) PLATFORM_DB_HEADER.PlatformFeatures].Split('-');
                }
                else
                {
                    pt_db[i].platform_features = new string[1];
                    pt_db[i].platform_features[0] = platform_data[i , ( int ) PLATFORM_DB_HEADER.PlatformFeatures];
                }


                // Default displays
                if ( platform_data[i , ( int ) PLATFORM_DB_HEADER.Default_Displays] != "NA" )
                {
                    pt_db[i].default_displays = platform_data[i , ( int ) PLATFORM_DB_HEADER.Default_Displays].Split('-');
                }
                else
                {
                    pt_db[i].default_displays = new string[1];
                    pt_db[i].default_displays[0] = platform_data[i , ( int ) PLATFORM_DB_HEADER.Default_Displays];
                }

                // VCC SPI
                if ( platform_data[i,(int) PLATFORM_DB_HEADER.dediprog_spi_arg] != "NA")
                {
                    pt_db[i].dediprog_spi_vcc_arg = platform_data[i, ( int ) PLATFORM_DB_HEADER.dediprog_spi_arg];
                }
                else
                {
                    pt_db[i].dediprog_spi_vcc_arg = string.Empty;
                }

                // VCC EC
                if ( platform_data[i, ( int ) PLATFORM_DB_HEADER.dediprog_ec_arg] != "NA" )
                {
                    pt_db[i].dediprog_ec_vcc_arg = platform_data[i, ( int ) PLATFORM_DB_HEADER.dediprog_ec_arg];
                }
                else
                {
                    pt_db[i].dediprog_ec_vcc_arg = string.Empty;
                }

                // BIOS filename prefixes
                pt_db[i].bios_name_prefix = platform_data[i, ( int ) PLATFORM_DB_HEADER.BIOS_Normal_Prefix];
                pt_db[i].bios_name_ext = platform_data[i, ( int ) PLATFORM_DB_HEADER.BIOS_Normal_Ext];
                // Merge BIOS filename prefixes
                pt_db[i].merge_name_prefix = platform_data[i, ( int ) PLATFORM_DB_HEADER.Merge_File_prefix];
                pt_db[i].merge_name_ext = platform_data[i, ( int ) PLATFORM_DB_HEADER.Merge_File_Ext];

                pt_db[i].flash_batch_cmd = platform_data[i, ( int ) PLATFORM_DB_HEADER.Flash_Command];
                pt_db[i].modfile_name = platform_data[i, ( int ) PLATFORM_DB_HEADER.modfile];



                if ( platform_data[i, ( int ) PLATFORM_DB_HEADER.search_ifwi_opt] != "NA")
                {
                    if ( platform_data[i, ( int ) PLATFORM_DB_HEADER.search_ifwi_opt] == "STEPPING" )
                    {
                        // stepping is already assigned
                        pt_db[i].search_stepping = true;
                    }

                    if ( platform_data[i, ( int ) PLATFORM_DB_HEADER.search_ifwi_opt] == "PREFIXFOLDER" )
                    {
                        pt_db[i].search_prefix_folder = true;
                        pt_db[i].prefix_folder = platform_data[i, ( int ) PLATFORM_DB_HEADER.Search_Folder_suffix].Split('-');
                    }

                    if ( platform_data[i, ( int ) PLATFORM_DB_HEADER.search_ifwi_opt] == "SKIPWORD")
                    {
                        pt_db[i].search_skipword = true;
                        pt_db[i].skip_folder_word = platform_data[i, ( int ) PLATFORM_DB_HEADER.SkipWordinFolder];
                    }

                    if ( platform_data[i, ( int ) PLATFORM_DB_HEADER.search_ifwi_opt]  == "SUFFIXFOLDER")
                    {
                        pt_db[i].search_suffixfolder = true;
                        pt_db[i].prefix_folder = platform_data[i, ( int ) PLATFORM_DB_HEADER.Search_Folder_suffix].Split('-');
                    }

                    if ( platform_data[i, ( int ) PLATFORM_DB_HEADER.search_ifwi_opt] == "SKIPWORD_SUFFIXFOLDER" )
                    {
                        pt_db[i].search_skipword = true;
                        pt_db[i].search_suffixfolder = true;

                        pt_db[i].search_by_suffix_and_skip = true;

                        pt_db[i].prefix_folder = platform_data[i, ( int ) PLATFORM_DB_HEADER.Search_Folder_suffix].Split('-');
                        pt_db[i].skip_folder_word = platform_data[i, ( int ) PLATFORM_DB_HEADER.SkipWordinFolder];

                    }
                    else
                    {
                        pt_db[i].prefix_folder = new string[1];
                        pt_db[i].prefix_folder[0] = string.Empty;
                    }

                    if (platform_data[i, ( int ) PLATFORM_DB_HEADER.search_ifwi_opt] == "STITCH")
                    {
                        pt_db[i].search_stitch = true;
                        pt_db[i].stitch_path = "\\Stitch\\Stitch";
                    }


                }


            }


            // Set the platform's ui data into the struct[var] defined
            for ( int i = 1 ; i < num_platforms_ui ; i++ )
            {
                pt_ui[i].platform = platform_ui_config[i , ( int ) PLATFORM_UI_HEADER.platform];
                pt_ui[i].type = platform_ui_config[i , ( int ) PLATFORM_UI_HEADER.type];

                if ( platform_ui_config[i , ( int ) PLATFORM_UI_HEADER.branch_type] == "CLIENT" )
                {
                    pt_ui[i].branch = ( int ) PLATFORM_BRANCH_ID.client;
                }
                else
                {
                    pt_ui[i].branch = ( int ) PLATFORM_BRANCH_ID.tablet;
                }

                if ( platform_ui_config[i , ( int ) PLATFORM_UI_HEADER.enable_x32gop] == "YES" )
                {
                    pt_ui[i].enablex32gop = true;
                }

                if ( platform_ui_config[i , ( int ) PLATFORM_UI_HEADER.enable_x32_vbios] == "YES" )
                {
                    pt_ui[i].enablex32vbios = true;
                }

                if ( platform_ui_config[i , ( int ) PLATFORM_UI_HEADER.enable_x64gop] == "YES" )
                {
                    pt_ui[i].enablex64gop = true;
                }

                if ( platform_ui_config[i , ( int ) PLATFORM_UI_HEADER.enable_x64_vbios] == "YES" )
                {
                    pt_ui[i].enablex64vbios = true;
                }

                if ( platform_ui_config[i , ( int ) PLATFORM_UI_HEADER.enable_production] == "PROD" )
                {
                    pt_ui[i].enable_prod = true;
                }

                if ( platform_ui_config[i , ( int ) PLATFORM_UI_HEADER.enable_ui_features ] != "NA" )
                {
                    string[] temp = platform_ui_config[i , ( int ) PLATFORM_UI_HEADER.enable_ui_features].Split('-');
                    for ( int j = 0 ; j < temp.Length ; j++ )
                    {
                        if ( temp[j].Equals("MIPI") )
                        {
                            pt_ui[i].ui_mipi = true;

                        }

                        if ( temp[j].Equals("SEQ") )
                        {
                            pt_ui[i].ui_seq = true;
                        }

                        if ( temp[j].Equals("CS") )
                        {
                            pt_ui[i].ui_cs = true;
                        }

                        if ( temp[j].Equals("HYBRID") )
                        {
                            pt_ui[i].ui_hybrid = true;
                        }

                        if ( temp[j].Equals("STEPPING") )
                        {
                            pt_ui[i].ui_stepping = true;
                        }

                        if ( temp[j].Equals("EDP") )
                        {
                            pt_ui[i].ui_panel_edp = true;
                        }

                        if ( temp[j].Equals("LVDS") )
                        {
                            pt_ui[i].ui_panel_lvds= true;
                        }
                    }
                }

                if ( platform_ui_config[i , ( int ) PLATFORM_UI_HEADER.enable_ports] != "NO" )
                {
                    pt_ui[i].port_option = true;
                }

                if ( platform_ui_config[i, (int) PLATFORM_UI_HEADER.enable_dnx] != "NO")
                {
                    pt_ui[i].dnx_option = true;
                }

                if ( platform_ui_config[i , ( int ) PLATFORM_UI_HEADER.enable_ksc] != "NO" )
                {
                    pt_ui[i].ksc_option = true;
                }

                if ( platform_ui_config[i , ( int ) PLATFORM_UI_HEADER.enable_secondstage] != "NO" )
                {
                    pt_ui[i].secondstage_option = true;
                }

                if ( platform_ui_config[i , ( int ) PLATFORM_UI_HEADER.enable_dediprog] != "NO" )
                {
                    pt_ui[i].dediprog_option = true;
                }

                if ( platform_ui_config[i , ( int ) PLATFORM_UI_HEADER.enable_platform] != "NO" )
                {
                    pt_ui[i].is_still_in_use = true;
                }

            }

        }

        /// <summary>
        /// Resets all the data inside the structs
        /// </summary>
        private void Reload_Platform_Data()
		{
			// Reset all data again [TBD]
            Load_Platform_Data();
        }

        /// <summary>
        /// Finds and Set the index to find a platform in the struct
        /// </summary>
        /// <param name="plt_id"> name to search</param>
        /// <param name="type_id"> a type to search </param>
        /// <param name="arch"> enumerated value of the architecture </param>
        /// <returns> Return a debug value</returns>
        public int find_platform(string plt_id, string type_id, ARCH_TYPE arch)
        {
            int index = 0;

            for ( int i = 0 ; i < num_platforms_db ; i++ )
            {
                if ( pt_db[i].platform_name == plt_id  && pt_db[i].platform_type == type_id )
                {
                    if ( pt_db[i].default_arch == (int )arch )
                    {
                        index = i;
                        data_index = i;
                        break;
                    }
                }
            }

            return index;
        }

        /// <summary>
        /// Finds and Set the index to find a platform in the struct
        /// </summary>
        /// <param name="plt_id"> name to search</param>
        /// <param name="type_id"> a type to search</param>
        /// <param name="arch"> enumerated value of the architecture</param>
        /// <param name="preboot"> the enumerated preboot to load </param>
        /// <returns> Return a debug value</returns>
        public int find_platform(string plt_id , string type_id , ARCH_TYPE arch, PREBOOT_TYPES_ID preboot)
        {
            int index = 0;

            for ( int i = 0 ; i < num_platforms_db ; i++ )
            {
                if ( pt_db[i].platform_name == plt_id && pt_db[i].platform_type == type_id  && pt_db[i].preboot_type == (int) preboot)
                {
                    if ( pt_db[i].default_arch == ( int ) arch )
                    {
                        index = i;
                        data_index = i;
                        break;
                    }
                }
            }

            return index;
        }

        /// <summary>
        /// Find and gets all the UI config for the tool, needs name and type
        /// </summary>
        /// <param name="name"> name of the project </param>
        /// <param name="type"> type of the project </param>
        /// <returns> Returned value is only for debug</returns>
        public int find_platform_ui_config(string name , string type)
        {
            int index = 0;
            for ( int i = 0 ; i < num_platforms_ui ; i++ )
            {
                if ( pt_ui[i].platform == name )
                {
                    if ( pt_ui[i].type == type )
                    {
                        index = i;
                        ui_index = i;
                        break;
                    }
                }
            }
            return index;
        }

        /// <summary>
        /// Gets all the folders names for the preboot UI list
        /// </summary>
        /// <param name="path_to_preboot"> the path of the preboot selecteed</param>
        /// <returns> Returned value is for debug only</returns>
        public int get_preboot_folders(string path_to_preboot)
        {
            string[] folders = Directory.GetDirectories(path_to_preboot , "*" , SearchOption.TopDirectoryOnly);
            preboot_list = new string[folders.Length];
            for ( int i = 0 ; i < folders.Length ; i++ )
            {
				// Seeks for last name of EFI path not be == SSF
                if ( Path.GetFullPath(folders[i]).Split('\\').LastOrDefault() != "SSF" )
                {
                    preboot_list[i] = Path.GetFullPath(folders[i]).Split('\\').LastOrDefault();

                }
            }

            return 1;
        }


        /// <summary>
        /// Retrieves all systembios folder names, a pattern (optional) can be set
        /// </summary>
        /// <param name="path_to_ifwi"> string path to the ifwi folder </param>
        /// <param name="pattern_in_folders"> pattern to search in the sbios folder path</param>
        /// <returns></returns>
        public int get_systembios_folders(string path_to_ifwi, string pattern_in_folders = "")
        {
            string[] folders = Directory.GetDirectories(path_to_ifwi , "*" + pattern_in_folders , SearchOption.TopDirectoryOnly);
            bios_list = new string[folders.Length];
            for ( int i = 0 ; i < folders.Length ; i++ )
            {
                bios_list[i] = Path.GetFullPath(folders[i]).Split('\\').LastOrDefault();
            }
            return 1;
        }

        /// <summary>
        /// Retrieves all systembios folder names, a pattern (optional) can bet set and a skipword can be used
        /// </summary>
        /// <param name="path_to_ifwi"></param>
        /// <param name="pattern_in_folders"></param>
        /// <param name="skipfoldername"></param>
        /// <returns></returns>
        public int get_systembios_folders(string path_to_ifwi, string pattern_in_folders, string skipfoldername)
        {
            string[] folders = Directory.GetDirectories(path_to_ifwi, "*" + pattern_in_folders, SearchOption.TopDirectoryOnly);
            bios_list = new string[folders.Length];
            int index = 0;
            for ( int i = 0 ; i < folders.Length ; i++ )
            {
                if ( Path.GetFullPath(folders[i]).Split('\\').LastOrDefault() != skipfoldername)
                    bios_list[index++] = Path.GetFullPath(folders[i]).Split('\\').LastOrDefault();
            }
            return 1;
        }
    }
    #endregion
}

// Are we cool yet?

