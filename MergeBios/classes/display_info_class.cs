﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MergeBios
{
    enum DISPLAY_TYPES
    {
        nodevice,
        edp,
        edp_ddrs,
        edp_4k,
        mipi,
        dp,
        dp_only,
        dvi,
        hdmi,
        usb_type_c,
        vga
    };

    /// <summary>
    /// Struct to hold all the display configs per platform
    /// </summary>
    struct display_Info_DB 
    {
        public string platform;
        public string type;
        public string[] lfp_mipi;
        public string[] lfp_edp;
        public string[] display1_portB;
        public string[] display2_portC;
        public string[] display3_portD;
        public string[] display4_portE;
        public string[] display5_portF;        

        public bool has_lfp;
        public bool has_edp;
        public bool has_mipi;
        public bool has_display1b;
        public bool has_display2c;
        public bool has_display3d;
        public bool has_display4e;
        public bool has_display5f;
        public bool has_mipi_selection;
    };

    /// <summary>
    /// Enum for CSV column selection for Output ports
    /// </summary>
    enum DISPLAY_DB_HEADER
    {
        platform,
        type,
        mipi_lfp,
        edp_lfp,
        display1B,
        display2C,
        display3D,
        display4E,
        select_mipi_option

    };

    /// <summary>
    /// enum for Column selection of display types
    /// </summary>
    enum DISPLAY_LABEL_ID
    {
        Nodevices, edp, edp_drrs, edp_4k, mipi, dp, dp_only, dvi, hdmi, usb_c_type, vga
    };

    /// <summary>
    /// enum for the Display selection comboBox
    /// </summary>
    enum DISPLAY_CMB_ID
    {
        no_device, lfp, display1, display2, display3, display4, display5
    };


    class Display_info
    {
        string[] display_type_names;  // names of devices
        string[,] display_names;      // array to hold all the info
        display_Info_DB[] display_db;   // display config db
        int display_index;
        int num_display_configs;

        string filenamedb;
        string ssf_filedb;
        string ssf_final_confg_file;     // Name or path of the final configuration file
        string[] display_lfp_conf_lines; // display edp or mipi BMP configuration
        string[] display1_conf_lines;    // display 1/A BMP lines
        string[] display2_conf_lines;    // display 2/B BMP lines
        string[] display3_conf_lines;    // display 3/C BMP lines
        string[] display4_conf_lines;    // display 4/D BMP lines
        string[] display5_conf_lines;    // display 5/E BMP lines

        string[] display_combo;

        LoadCSV display_file = new LoadCSV(); // load all the info from the file



        /// <summary>
        /// Class constructor, no overloaded
        /// </summary>
        public Display_info()
        {

            filenamedb = "platform_display_conf_db.csv";
            ssf_filedb = Environment.CurrentDirectory + "\\" + "ssf_config.cfg";

            display_type_names = new string[]
            {
                "No_Device" ,
                "eDP" ,
                "eDP_DDRS" ,
                "eDP_4K" ,
                "MIPI" ,
                "DP" ,
                "DP_Only" ,
                "DVI" ,
                "HDMI" ,
                "USB_TYPE_C" ,
                "VGA" ,
            };

            display_combo = new string[] { "null", "Display_LFP", "Display1", "Display2", "Display3", "Display4", "Display5" };


        }

        /// <summary>
        /// 
        /// </summary>
        public void Load_display_data()
        {            
            display_names = display_file.LoadCsv(Path.GetFullPath(Path.Combine(Application.StartupPath, "..\\..")) + "\\" + filenamedb);

            int num_rows = display_names.GetUpperBound(0) + 1;   // Max row of platform db
            int num_cols = display_names.GetUpperBound(1) + 1;

            display_index = 0;
            num_display_configs = num_rows;

            display_db = new display_Info_DB[num_rows];

            for ( int i = 1 ; i < num_rows ; i++ )
            {
                display_db[i].platform = display_names[i, ( int ) DISPLAY_DB_HEADER.platform];
                display_db[i].type = display_names[i, ( int ) DISPLAY_DB_HEADER.type];

                // PORT A MIPI
                if ( display_names[i, ( int ) DISPLAY_DB_HEADER.mipi_lfp] != "NA" )
                {
                    display_db[i].lfp_mipi = display_names[i, ( int ) DISPLAY_DB_HEADER.mipi_lfp].Split('-');
                    display_db[i].has_mipi = true;
                }
                else
                {
                    display_db[i].lfp_mipi = new string[1];
                    display_db[i].lfp_mipi[0] = display_names[i, ( int ) DISPLAY_DB_HEADER.mipi_lfp];
                    display_db[i].has_mipi = false;
                }
                // PORT A EDP
                if ( display_names[i, ( int ) DISPLAY_DB_HEADER.edp_lfp] != "NA" )
                {
                    display_db[i].lfp_edp = display_names[i, ( int ) DISPLAY_DB_HEADER.edp_lfp].Split('-');
                    display_db[i].has_edp = true;
                }
                else
                {
                    display_db[i].lfp_edp = new string[1];
                    display_db[i].lfp_edp[0] = display_names[i, ( int ) DISPLAY_DB_HEADER.edp_lfp];
                    display_db[i].has_edp = false;
                }

                if ( display_db[i].has_edp == true || display_db[i].has_mipi == true )
                    display_db[i].has_lfp = true;
                else
                    display_db[i].has_lfp = false;


                // PORT B or Display 1
                if ( display_names[i , ( int ) DISPLAY_DB_HEADER.display1B] != "NA" )
                {
                    display_db[i].display1_portB = display_names[i , ( int ) DISPLAY_DB_HEADER.display1B].Split('-');
                    display_db[i].has_display1b = true;
                }
                else
                {
                    display_db[i].display1_portB = new string[1];
                    display_db[i].display1_portB[0] = display_names[i , ( int ) DISPLAY_DB_HEADER.display1B];
                }

                // PORT C or Display 2
                if ( display_names[i , ( int ) DISPLAY_DB_HEADER.display2C] != "NA" )
                {
                    display_db[i].display2_portC = display_names[i , ( int ) DISPLAY_DB_HEADER.display2C].Split('-');
                    display_db[i].has_display2c = true;
                }
                else
                {
                    display_db[i].display2_portC = new string[1];
                    display_db[i].display2_portC[0] = display_names[i , ( int ) DISPLAY_DB_HEADER.display2C];
                }

                // PORT D or Display 3
                if ( display_names[i , ( int ) DISPLAY_DB_HEADER.display3D] != "NA" )
                {
                    display_db[i].display3_portD = display_names[i , ( int ) DISPLAY_DB_HEADER.display3D].Split('-');
                    display_db[i].has_display3d = true;
                }
                else
                {
                    display_db[i].display3_portD = new string[1];
                    display_db[i].display3_portD[0] = display_names[i , ( int ) DISPLAY_DB_HEADER.display3D];
                }

                // PORT E or Display 4
                if ( display_names[i , ( int ) DISPLAY_DB_HEADER.display4E] != "NA" )
                {
                    display_db[i].display4_portE = display_names[i , ( int ) DISPLAY_DB_HEADER.display4E].Split('-');
                    display_db[i].has_display4e = true;
                }
                else
                {
                    display_db[i].display4_portE = new string[1];
                    display_db[i].display4_portE[0] = display_names[i , ( int ) DISPLAY_DB_HEADER.display4E];
                }


                if (display_names[i, (int) DISPLAY_DB_HEADER.select_mipi_option] != "NO")
                {
                    display_db[i].has_mipi_selection = true;
                }

            }

        }

        /// <summary>
        /// Search the selected display combination as per platform project and type.
        /// </summary>
        /// <param name="platform">name of platform</param>
        /// <param name="type">name of the type</param>
        public void Find_display_config(string platform , string type)
        {
            for ( int i = 0 ; i < num_display_configs ; i++ )
            {
                if ( display_db[i].platform == platform && display_db[i].type == type )
                {
                    display_index = i;
                    break;
                }
            }

            //LoadDisplay_SSF_Config("SKL","EFI", "eDP",(int)DISPLAY_SELECTION.display1);
        }

        /// <summary>
        /// Load the SSF data from file
        /// </summary>
        /// <param name="platform">Platform name as string, mandatory</param>
        /// <param name="preboot">Preboot type, EFI or VBIOS, mandatory</param>
        /// <param name="display_output">Mandatory, must be eDP, DP, HDMI etc</param>
        /// <param name="displaynumber">Which display shall be used?</param>
        public void LoadDisplay_SSF_Config (string platform, string preboot, string display_output,int displaynumber)
        {
            string value;
            string[] ssf;

            switch( displaynumber)
            {
                case (int)DISPLAY_CMB_ID.no_device:                    
                    break;
                case (int)DISPLAY_CMB_ID.lfp:
                   // string temp = platform + "_" + preboot + " " +  display_combo[(int)DISPLAY_SELECTION.lfp] +  " " + display_type_names[(int)DISPLAY_TYPES.nodevice] + ssf_filedb;
                   //value = IniFileHelper.ReadValue(platform + "_" + preboot, "Display_LFP_No_Device", ssf_filedb);
                   // ssf = value.Split(',');
                    break;
                case (int)DISPLAY_CMB_ID.display1:
                    break;
                case (int)DISPLAY_CMB_ID.display2:
                    break;
                case (int)DISPLAY_CMB_ID.display3:
                    break;
                case (int)DISPLAY_CMB_ID.display4:
                    break;
                case (int)DISPLAY_CMB_ID.display5:
                    break;
            }



        }


        public void Make_SSF_File()
        {
            // TO DO : 
            // Write code to create the ssf here
            string temp = string.Empty;

        }

        #region Public accesors

        /// <summary>
        /// [UI] enables/disable lfp combo list
        /// </summary>
        public bool enable_lfp_list
        {
            get
            {
                return display_db[display_index].has_lfp;
            }
        }

        /// <summary>
        /// [UI] enable/disable display 1 port b combo list
        /// </summary>
        public bool enable_display1b
        {
            get
            {
                return display_db[display_index].has_display1b;
            }
        }

        /// <summary>
        /// [UI]  enable/disable display 2 port c combo list
        /// </summary>
        public bool enable_display2c
        {
            get
            {
                return display_db[display_index].has_display2c;
            }
        }

        /// <summary>
        /// [UI]  enable/disable display 3 port d combo list
        /// </summary>
        public bool enable_display3d
        {
            get
            {
                return display_db[display_index].has_display3d;
            }
        }

        /// <summary>
        /// [UI]  enable/disable display 4 port e combo list
        /// </summary>
        public bool enable_display4e
        {
            get
            {
                return display_db[display_index].has_display4e;
            }
        }

        /// <summary>
        /// [UI | Info] List of edp panels of platform
        /// </summary>
        public string[] edp_list
        {
            get
            {
                return display_db[display_index].lfp_edp;
            }
        }

        /// <summary>
        /// [UI | Info] List of MIPI panels of platform
        /// </summary>
        public string[] mipi_list
        {
            get
            {
                return display_db[display_index].lfp_mipi;
            }
        }

        /// <summary>
        /// [UI | Info] Contains the list of defined PORT B displays
        /// </summary>
        public string[] port1b_displays
        {
            get
            {
                return display_db[display_index].display1_portB;
            }
        }

        /// <summary>
        /// [UI | Info] Contains the list of defined PORT C displays
        /// </summary>
        public string[] port2c_displays
        {
            get
            {
                return display_db[display_index].display2_portC;
            }
        }

        /// <summary>
        /// [UI | Info] Contains the list of defined PORT D displays
        /// </summary>
        public string[] port3d_displays
        {
            get
            {
                return display_db[display_index].display3_portD;
            }
        }

        /// <summary>
        /// [UI | Info] Contains the list of defined PORT E displays
        /// </summary>
        public string[] port4e_displays
        {
            get
            {
                return display_db[display_index].display4_portE;
            }
        }

        /// <summary>
        /// [UI | Info] Contains the list of defined PORT E displays
        /// </summary>
        public string[] port5f_displays
        {
            get
            {
                return display_db[display_index].display5_portF;
            }
        }


        /// <summary>
        /// [UI | Info] Tells to select a MIPI Panel
        /// </summary>
        public bool select_mipi_option
        {
            get
            {
                return display_db[display_index].has_mipi_selection;
            }
        }

        #endregion
    }

}

//Are we cool yet?
