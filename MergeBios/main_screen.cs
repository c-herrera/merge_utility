using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MergeBios
{
    public partial class frm_mainScreen : Form
    {
        public frm_mainScreen()
        {
            InitializeComponent();
        }

        Platform_Info platform; // Platform data manager
        Display_info displays;  // Display Output manager
        Tool_Config optionsConf; // Tool Configration manager

        int arch;               // arch option
        int preboot;

        /// <summary>
        ///  Main form load event, setup code here only
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frm_mainScreen_Load(object sender , EventArgs e)
        {
            platform = new Platform_Info();            
            platform.Load_Platform_Data();

            displays = new Display_info();
            displays.Load_display_data();

            optionsConf = new Tool_Config();
            optionsConf.LoadConfiguration();


            toolStripStatus_Tool.Text += " : " + optionsConf.Message;


            arch = ( int ) ARCH_TYPE.noarch;

            int rows = platform.platform_list.GetUpperBound(0) + 1; // find the row depth

            //fill the platform combo
            // Add a skip logic in case the platform must not be listed
            for ( int i = 1 ; i < rows ; i++ )
                cmb_platform.Items.Add(platform.platform_list[i , 0]);

            // Disable not yet know configurations

            // Preboot section
            radio_gop.Enabled = false;
            radio_vbios.Enabled = false;
            radio_x32.Enabled = false;
            radio_x64.Enabled = false;

            cmb_sbios.Enabled = false;
            cmb_preboot.Enabled = false;
            cmb_stepping.Enabled = false;

            check_production.Enabled = false;
            check_custom_ports.Checked = false;
            check_custom_ports.Enabled = false;

            btn_flash_ksc.Enabled = false;
            btn_second_stage.Enabled = false;
            btn_dediprog.Enabled = false;
            btn_dnx.Enabled = false;

            // Display section
            cmb_display1.Enabled = false;
            cmb_display2.Enabled = false;
            cmb_display3.Enabled = false;
            cmb_display4.Enabled = false;
            cmb_lfp.Enabled = false;

            radio_lvds.Enabled = false;
            radio_edp.Enabled = false;

            this.Text += " " + Application.ProductVersion;


            toolStripStatus_Tool.Text += " : Ready";

            // Load configurations from "options.cfg"
            cmb_flashtools.Items.AddRange(optionsConf.flash_tool_names);

            chk_remote_folder.Checked = optionsConf.opt_remote_folder_check;
            chk_remote_tool.Checked = optionsConf.opt_remote_tool_check;

            chk_ask_flash.Checked = optionsConf.opt_auto_flash;
            chk_ask_save.Checked = optionsConf.opt_ask_for_save;

            cmb_flashtools.SelectedIndex = optionsConf.opt_default_flash_tool;

            txt_merge_name.Text = optionsConf.opt_active_working_path;
            txt_save_name.Text = optionsConf.opt_active_save_path;


        }

        /// <summary>
        /// Event for selecting a new platform project
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmb_platform_SelectedIndexChanged(object sender , EventArgs e)
        {            
            int num_cols1 = platform.platform_list.GetUpperBound(1) + 1;
            int platformselected_index = cmb_platform.SelectedIndex + 1;            

            cmb_plt_type.Items.Clear();


            // fill the type combo
            for ( int i = platformselected_index ; i <= platformselected_index ; i++ )
            {
                for ( int j = 1 ; j < num_cols1 ; j++ )
                {
                    if ( platform.platform_list[i , j].ToString() == "-" ) 
                        continue;
                    else
                        cmb_plt_type.Items.Add(platform.platform_list[i , j]);
                }
            }
            cmb_plt_type.Enabled = true;


            // Disable options for next platform
            radio_gop.Enabled = false;
            radio_gop.Checked = false;

            radio_vbios.Enabled = false;
            radio_vbios.Checked = false;

            radio_x32.Enabled = false;
            radio_x32.Checked = false;

            radio_x64.Enabled = false;
            radio_x64.Checked = false;


            cmb_sbios.Enabled = false;
            cmb_preboot.Enabled = false;
            cmb_stepping.Enabled = false;

            check_production.Enabled = false;
            check_production.Checked = false;

            check_f_connected_standby.Enabled = false;
            check_f_connected_standby.Checked = false;

            check_f_hybrid.Enabled = false;
            check_f_hybrid.Checked = false;

            check_f_mipi.Enabled = false;
            check_f_mipi.Checked = false;

            check_f_seq_mipi.Enabled = false;
            check_f_seq_mipi.Checked = false;

            check_production.Enabled = false;
            check_production.Checked = false;

            btn_flash_ksc.Enabled = false;
            btn_second_stage.Enabled = false;
            btn_dediprog.Enabled = false;
            btn_dnx.Enabled = false;

            group_output_ports.Enabled = true;

            check_custom_ports.Checked = false;
            cmb_display1.Enabled = false;
            cmb_display2.Enabled = false;
            cmb_display3.Enabled = false;
            cmb_display4.Enabled = false;
            cmb_lfp.Enabled = false;

            radio_lvds.Enabled = false;
            radio_lvds.Checked = false;

            radio_edp.Checked = false;
            radio_edp.Enabled = false;

            arch = (int)ARCH_TYPE.noarch;
            preboot = 255;

            for (int i = (int)MERGE_NAME_PARTS.custom_prefix; i <= (int)MERGE_NAME_PARTS.disp5; i++)
            {
                platform.platform_merge_name[i] = string.Empty;
            }


            // string for the merge name
            platform.platform_merge_name[(int)MERGE_NAME_PARTS.platform_name] = cmb_platform.Text;

            lbl_merge_name.Text = string.Join(" ", platform.platform_merge_name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmb_plt_type_SelectedIndexChanged(object sender , EventArgs e)
        {
            platform.find_platform_ui_config(cmb_platform.Text , cmb_plt_type.Text);

            // Disable previous options
            radio_gop.Checked = false;
            radio_vbios.Checked = false;

            radio_x32.Checked = false;
            radio_x64.Checked = false;

            cmb_sbios.Enabled = false;
            cmb_preboot.Enabled = false;
            cmb_stepping.Enabled = false;


            check_f_connected_standby.Enabled = false;
            check_f_connected_standby.Checked = false;

            check_f_hybrid.Enabled = false;
            check_f_hybrid.Checked = false;

            check_f_mipi.Enabled = false;
            check_f_mipi.Checked = false;

            check_f_seq_mipi.Enabled = false;
            check_f_seq_mipi.Checked = false;

            check_production.Enabled = false;
            check_production.Checked = false;

            cmb_stepping.Enabled = false;

            check_custom_ports.Checked = false;
            btn_flash_ksc.Enabled = false;
            btn_second_stage.Enabled = false;
            btn_dediprog.Enabled = false;
            btn_dnx.Enabled = false;
            

            // Enable UI options

            // Section :GOP-VBIOS
            switch ( platform.ui_branch )
            {
                case ( int ) PLATFORM_BRANCH_ID.client:
                    radio_gop.Enabled = platform.ui_enable_x64_gop;                    
                    radio_vbios.Enabled = platform.ui_enable_x64_vbios;

                    break;
                case ( int ) PLATFORM_BRANCH_ID.tablet:
                    radio_gop.Enabled = platform.ui_enable_x32_gop;
                    radio_gop.Enabled = platform.ui_enable_x64_gop;

                    radio_vbios.Enabled = platform.ui_enable_x32_vbios;
                    radio_vbios.Enabled = platform.ui_enable_x64_vbios;
                    break;
            }
            

            // Section :  CS-Hybrid-MIPI-Production-Stepping options
            check_f_connected_standby.Enabled = platform.ui_enable_cs;
            check_f_hybrid.Enabled = platform.ui_enable_hybrid;
            check_f_mipi.Enabled = platform.ui_enable_mipi;
            check_f_seq_mipi.Enabled = platform.ui_enable_seq;
            check_production.Enabled = platform.ui_enable_production;
            check_custom_ports.Enabled = platform.ui_enable_display_ports;

            cmb_stepping.Enabled = platform.ui_enable_stepping;

            // Section : Other Flash options
            btn_flash_ksc.Enabled = platform.ui_enable_ksc;
            btn_second_stage.Enabled = platform.ui_enable_secondstage;
            btn_dediprog.Enabled = platform.ui_enable_dediprog;
            btn_dnx.Enabled = platform.ui_enable_dnx_option;

            // string for the merge name
            platform.platform_merge_name[(int)MERGE_NAME_PARTS.type_name] = cmb_plt_type.Text;

            lbl_merge_name.Text = string.Join(" ", platform.platform_merge_name);
        }

        /// <summary>
        /// Quits the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_quit_Click(object sender , EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// radio button option to select x32 arch
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radio_x32_CheckedChanged(object sender , EventArgs e)
        {
            arch = ( radio_x32.Checked == true ) ? ( int ) ARCH_TYPE.x_32 : ( int ) ARCH_TYPE.noarch;

            switch ( platform.ui_branch )
            {
                case ( int ) PLATFORM_BRANCH_ID.client:
                    // Client platform never must fall here
                    break;
                case ( int ) PLATFORM_BRANCH_ID.tablet:
                    // Fill the system bios combo        
                                
                    // Fill stepping combo, if any
                    if ( platform.ui_enable_stepping )
                    {
                        cmb_stepping.Items.Clear();
                        platform.find_platform(cmb_platform.Text , cmb_plt_type.Text , ( ARCH_TYPE ) arch);

                        if ( platform.platform_Stepping.Length > 0 )
                        {
                            for ( int i = 0 ; i < platform.platform_Stepping.Length ; i++ )
                            {
                                cmb_stepping.Items.Add(platform.platform_Stepping[i]);
                            }
                        }

                    }                   

                    else
                    {
                        // Add code to case by skipword, special folder etc.
                        platform.find_platform(cmb_platform.Text , cmb_plt_type.Text , ( ARCH_TYPE ) arch);
                        cmb_sbios.DataSource = null;
                        cmb_sbios.Enabled = true;
                        cmb_sbios.Items.Clear();
                        platform.get_systembios_folders(platform.platform_Path_to_SBIOS);
                        cmb_sbios.DataSource = platform.bios_list;
                        cmb_sbios.SelectedIndex = cmb_sbios.Items.Count - 1;
                    }



                    if ( radio_x32.Checked == true)
                    {
                        platform.find_platform(cmb_platform.Text , cmb_plt_type.Text , ( ARCH_TYPE ) arch , ( PREBOOT_TYPES_ID ) preboot);
                        cmb_preboot.DataSource = null;
                        cmb_preboot.Enabled = true;
                        cmb_preboot.Items.Clear();
                        platform.get_preboot_folders(platform.platform_Path_to_Preboot);
                        cmb_preboot.DataSource = platform.preboot_list;
                        cmb_preboot.SelectedIndex = cmb_preboot.Items.Count - 1;
                    }
                    break;
            }
            //string to create the name of the merge
            platform.platform_merge_name[(int)MERGE_NAME_PARTS.arch_ver] = radio_x32.Text;

            lbl_merge_name.Text = string.Join(" ", platform.platform_merge_name);
        }

        /// <summary>
        /// radio button option to select x64 arch
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radio_x64_CheckedChanged(object sender , EventArgs e)
        {
            arch = ( radio_x64.Checked == true) ? ( int ) ARCH_TYPE.x_64 : ( int ) ARCH_TYPE.noarch ;

            switch ( platform.ui_branch )
            {
                case ( int ) PLATFORM_BRANCH_ID.client:
                    break;
                case ( int ) PLATFORM_BRANCH_ID.tablet:
                    // Fill the system bios combo                    
                    // Fill stepping combo, if any
                    if ( platform.ui_enable_stepping )
                    {
                        cmb_stepping.Items.Clear();
                        platform.find_platform(cmb_platform.Text , cmb_plt_type.Text , ( ARCH_TYPE ) arch);

                        if ( platform.platform_Stepping.Length > 0 )
                        {
                            for ( int i = 0 ; i < platform.platform_Stepping.Length ; i++ )
                            {
                                cmb_stepping.Items.Add(platform.platform_Stepping[i]);
                            }
                        }
                    }
                    else
                    {
                        platform.find_platform(cmb_platform.Text , cmb_plt_type.Text , ( ARCH_TYPE ) arch);
                        cmb_sbios.DataSource = null;
                        cmb_sbios.Enabled = true;
                        cmb_sbios.Items.Clear();
                        platform.get_systembios_folders(platform.platform_Path_to_SBIOS);
                        cmb_sbios.DataSource = platform.bios_list;
                        cmb_sbios.SelectedIndex = cmb_sbios.Items.Count - 1;
                    }

                    if ( radio_x64.Checked == true )
                    {
                        platform.find_platform(cmb_platform.Text , cmb_plt_type.Text , ( ARCH_TYPE ) arch , ( PREBOOT_TYPES_ID ) preboot);
                        cmb_preboot.DataSource = null;
                        cmb_preboot.Enabled = true;
                        cmb_preboot.Items.Clear();
                        platform.get_preboot_folders(platform.platform_Path_to_Preboot);
                        cmb_preboot.DataSource = platform.preboot_list;
                        cmb_preboot.SelectedIndex = cmb_preboot.Items.Count - 1;
                    }
                    break;
            }
            //string to create the name of the merge
            platform.platform_merge_name[(int)MERGE_NAME_PARTS.arch_ver] = radio_x64.Text;

            lbl_merge_name.Text = string.Join(" ", platform.platform_merge_name);
        }

        /// <summary>
        /// radio button to select preboot EFI-GOP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radio_gop_CheckedChanged(object sender , EventArgs e)
        {
            preboot = ( int ) PREBOOT_TYPES_ID.gop;

            switch ( platform.ui_branch )
            {
                case ( int ) PLATFORM_BRANCH_ID.client:                    
                    arch = ( int ) ARCH_TYPE.noarch;
                    if ( radio_gop.Checked == true )
                    {
                        platform.find_platform(cmb_platform.Text , cmb_plt_type.Text , ( ARCH_TYPE ) arch , ( PREBOOT_TYPES_ID ) preboot);
                        cmb_preboot.DataSource = null;
                        cmb_preboot.Enabled = true;
                        cmb_preboot.Items.Clear();
                        platform.get_preboot_folders(platform.platform_Path_to_Preboot);
                        cmb_preboot.DataSource = platform.preboot_list;
                        cmb_preboot.SelectedIndex = cmb_preboot.Items.Count - 1;
                    }
                    
                    // Fill the system bios combo                    
                    cmb_sbios.DataSource = null;
                    cmb_sbios.Enabled = true;
                    cmb_sbios.Items.Clear();
                    cmb_sbios.Update();
                    platform.get_systembios_folders(platform.platform_Path_to_SBIOS);
                    cmb_sbios.DataSource = platform.bios_list;
                    cmb_sbios.SelectedIndex = cmb_sbios.Items.Count - 1;

                    radio_lvds.Enabled = platform.ui_enable_edp_option;
                    radio_edp.Enabled = platform.ui_enable_lvds_option;

                    break;
                case ( int ) PLATFORM_BRANCH_ID.tablet:
                    radio_x32.Enabled = platform.ui_enable_x32_gop;
                    radio_x64.Enabled = platform.ui_enable_x64_gop;
                    break;
            }
            //string to create the merge bios filename
            platform.platform_merge_name[(int)MERGE_NAME_PARTS.preboot_prefix] = platform.preboot_names[(int)PREBOOT_TYPES_ID.gop];

            lbl_merge_name.Text = string.Join(" ", platform.platform_merge_name);
        }

        /// <summary>
        /// radio button to select preboot VBIOS-MBR
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radio_vbios_CheckedChanged(object sender , EventArgs e)
        {
            preboot = ( int ) PREBOOT_TYPES_ID.vbios;


            switch ( platform.ui_branch )
            {
                case ( int ) PLATFORM_BRANCH_ID.client:                    
                    arch = ( int ) ARCH_TYPE.noarch;

                    // Show Preboot list for client
                    if ( radio_vbios.Checked == true )
                    {
                        platform.find_platform(cmb_platform.Text , cmb_plt_type.Text , ( ARCH_TYPE ) arch , ( PREBOOT_TYPES_ID ) preboot);
                        cmb_preboot.DataSource = null;
                        cmb_preboot.Enabled = true;
                        cmb_preboot.Items.Clear();
                        platform.get_preboot_folders(platform.platform_Path_to_Preboot);
                        cmb_preboot.DataSource = platform.preboot_list;
                        cmb_preboot.SelectedIndex = cmb_preboot.Items.Count - 1;
                    }

                    // Fill the system bios combo                    
                    cmb_sbios.DataSource = null;
                    cmb_sbios.Enabled = true;
                    cmb_sbios.Items.Clear();
                    cmb_sbios.Update();
                    platform.get_systembios_folders(platform.platform_Path_to_SBIOS);
                    cmb_sbios.DataSource = platform.bios_list;
                    cmb_sbios.SelectedIndex = cmb_sbios.Items.Count - 1;

                    radio_lvds.Enabled = platform.ui_enable_lvds_option;
                    radio_edp.Enabled = platform.ui_enable_edp_option;

                    break;
                case ( int ) PLATFORM_BRANCH_ID.tablet:
                    // Only enable the options
                    radio_x32.Enabled = platform.ui_enable_x32_vbios;
                    radio_x64.Enabled = platform.ui_enable_x64_vbios;
                    break;
            }
            //string to create the bios marge name
            platform.platform_merge_name[(int)MERGE_NAME_PARTS.preboot_prefix] = platform.preboot_names[(int)PREBOOT_TYPES_ID.vbios];

            lbl_merge_name.Text = string.Join(" ", platform.platform_merge_name);
        }

        /// <summary>
        /// check button to enable custom selection of display output
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void check_custom_ports_CheckedChanged(object sender , EventArgs e)
        {
            displays.Find_display_config(cmb_platform.Text , cmb_plt_type.Text);

            for (int i = (int)MERGE_NAME_PARTS.disp_lfp; i < (int)MERGE_NAME_PARTS.disp5; i++)
            {
                platform.platform_merge_name[i] = string.Empty;
            }

            if ( check_custom_ports.Checked == true )
            {
                if ( platform.ui_enable_edp_option || platform.ui_enable_edp_option )
                {
                    cmb_display1.Enabled = false;
                    cmb_display2.Enabled = false;
                    cmb_display3.Enabled = false;
                    cmb_lfp.Enabled = false;
                }
                else if (platform.ui_enable_display_ports)
                {
                    cmb_lfp.Enabled = displays.enable_lfp_list;
                    cmb_display1.Enabled = displays.enable_display1b;
                    cmb_display2.Enabled = displays.enable_display2c;
                    cmb_display3.Enabled = displays.enable_display3d;
                    cmb_display4.Enabled = displays.enable_display4e;

                    if ( cmb_lfp.Enabled )
                    {
                        cmb_lfp.DataSource = null;
                        cmb_lfp.Items.Clear();

                        if ( check_f_mipi.Checked )
                            cmb_lfp.DataSource = displays.mipi_list;
                        else
                            cmb_lfp.DataSource = displays.edp_list;

                        cmb_lfp.SelectedItem = platform.platform_Default_Displays[0];

                        // string of the display part
                        platform.platform_merge_name[(int)MERGE_NAME_PARTS.disp_lfp] = cmb_lfp.Text;
                        lbl_merge_name.Text =  string.Join(" ", platform.platform_merge_name);
                    }

                    if ( cmb_display1.Enabled )
                    {
                        cmb_display1.DataSource = null;
                        cmb_display1.Items.Clear();
                        cmb_display1.DataSource = displays.port1b_displays;

                        cmb_display1.SelectedItem = platform.platform_Default_Displays[1];

                        //string of the display part
                        platform.platform_merge_name[(int)MERGE_NAME_PARTS.disp1] = cmb_display1.Text;
                        lbl_merge_name.Text = string.Join(" ", platform.platform_merge_name);
                    }

                    if ( cmb_display2.Enabled )
                    {
                        cmb_display2.DataSource = null;
                        cmb_display2.Items.Clear();
                        cmb_display2.DataSource = displays.port2c_displays;

                        cmb_display2.SelectedItem = platform.platform_Default_Displays[2];

                        //string of the display part
                        platform.platform_merge_name[(int)MERGE_NAME_PARTS.disp2] = cmb_display2.Text;
                        lbl_merge_name.Text = string.Join(" ", platform.platform_merge_name);
                    }

                    if ( cmb_display3.Enabled )
                    {
                        cmb_display3.DataSource = null;
                        cmb_display3.Items.Clear();
                        cmb_display3.DataSource = displays.port3d_displays;

                        cmb_display3.SelectedItem = platform.platform_Default_Displays[3];

                        //txt_display3.Text = cmb_display3.SelectedItem.ToString();
                        platform.platform_merge_name[(int)MERGE_NAME_PARTS.disp3] = cmb_display3.Text;
                        lbl_merge_name.Text = string.Join(" ", platform.platform_merge_name);
                    }

                    if ( cmb_display4.Enabled )
                    {
                        cmb_display4.DataSource = null;
                        cmb_display4.Items.Clear();
                        cmb_display4.DataSource = displays.port4e_displays;

                        cmb_display4.SelectedItem = platform.platform_Default_Displays[4];

                        //txt_display4.Text = cmb_display4.SelectedItem.ToString();
                        platform.platform_merge_name[(int)MERGE_NAME_PARTS.disp4] = cmb_display4.Text;
                        lbl_merge_name.Text = string.Join(" ", platform.platform_merge_name);
                    }
                }
                lbl_merge_name.Text = string.Join(" ", platform.platform_merge_name);

            }
            else
            {                
                cmb_display1.Enabled = false;
                cmb_display1.DataSource = null;
                cmb_display1.Items.Clear();

                cmb_display2.Enabled = false;
                cmb_display2.DataSource = null;
                cmb_display2.Items.Clear();

                cmb_display3.Enabled = false;
                cmb_display3.DataSource = null;
                cmb_display3.Items.Clear();

                cmb_display4.Enabled = false;
                cmb_display4.DataSource = null;
                cmb_display4.Items.Clear();

                cmb_lfp.Enabled = false;
                cmb_lfp.DataSource = null;
                cmb_lfp.Items.Clear();


                for (int i = (int)MERGE_NAME_PARTS.disp_lfp; i < (int) MERGE_NAME_PARTS.disp5; i++ )
                {
                    platform.platform_merge_name[i] = string.Empty;
                }
                lbl_merge_name.Text = string.Join(" ", platform.platform_merge_name);
            }


        }

        /// <summary>
        /// Event from combo sbios, here
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmb_sbios_SelectedIndexChanged (object sender, EventArgs e)
        {

            //txt_ifwi_name.Text = cmb_sbios.Text;
            platform.platform_merge_name[(int)MERGE_NAME_PARTS.sbiosver] = cmb_sbios.Text;
            lbl_merge_name.Text = string.Join(" ", platform.platform_merge_name);
        }

        /// <summary>
        /// Event from combo preboot, here
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmb_preboot_SelectedIndexChanged (object sender, EventArgs e)
        {
            //txt_preboot_name.Text = cmb_preboot.Text;
            platform.platform_merge_name[(int)MERGE_NAME_PARTS.preboot_ver] = cmb_preboot.Text;
            lbl_merge_name.Text = string.Join(" ", platform.platform_merge_name);
        }

        /// <summary>
        /// Event from combo local flat panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmb_lfp_SelectedIndexChanged (object sender, EventArgs e)
        {
            //txt_lfp.Text = cmb_lfp.Text;
            platform.platform_merge_name[(int)MERGE_NAME_PARTS.disp_lfp] = cmb_lfp.Text;
            lbl_merge_name.Text = string.Join(" ", platform.platform_merge_name);
        }

        /// <summary>
        /// Event from combo display 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmb_display1_SelectedIndexChanged (object sender, EventArgs e)
        {
            //txt_display1.Text = cmb_display1.Text;
            platform.platform_merge_name[(int)MERGE_NAME_PARTS.disp1] = cmb_display1.Text;
            lbl_merge_name.Text = string.Join(" ", platform.platform_merge_name);
        }

        /// <summary>
        /// Event from combo display 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmb_display2_SelectedIndexChanged (object sender, EventArgs e)
        {
            //txt_display2.Text = cmb_display2.Text;
            platform.platform_merge_name[(int)MERGE_NAME_PARTS.disp2] = cmb_display2.Text;
            lbl_merge_name.Text = string.Join(" ", platform.platform_merge_name);
        }

        /// <summary>
        /// Event from combo display 3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmb_display3_SelectedIndexChanged (object sender, EventArgs e)
        {
            //txt_display3.Text = cmb_display3.Text;
            platform.platform_merge_name[(int)MERGE_NAME_PARTS.disp3] = cmb_display3.Text;
            lbl_merge_name.Text = string.Join(" ", platform.platform_merge_name);
        }

        /// <summary>
        /// Event from combo display 4
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmb_display4_SelectedIndexChanged (object sender, EventArgs e)
        {
            //txt_display4.Text = cmb_display4.Text;
            platform.platform_merge_name[(int)MERGE_NAME_PARTS.disp4] = cmb_display4.Text;
            lbl_merge_name.Text = string.Join(" ", platform.platform_merge_name);
        }


        /// <summary>
        /// Button event to save the tool options
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_new_save_folder_Click (object sender, EventArgs e)
        {
            // Set new default directory            
            using ( FolderBrowserDialog dialog = new FolderBrowserDialog() )
            {
                dialog.Description = "Select the new path to save BIOS files from on:";
                StartPosition = FormStartPosition.WindowsDefaultLocation;
                dialog.ShowNewFolderButton = true;
                dialog.RootFolder = Environment.SpecialFolder.Desktop;
                if ( dialog.ShowDialog() == DialogResult.OK )
                {
                    dialog.SelectedPath = dialog.SelectedPath.ToString() + "\\";
                    optionsConf.opt_active_save_path = dialog.SelectedPath;
                    txt_save_name.Text = dialog.SelectedPath;
                }
            }
        }

        /// <summary>
        /// Select new merge binary files folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_new_merge_folder_Click (object sender, EventArgs e)
        {
            // set new merge folder
            using ( FolderBrowserDialog dialog = new FolderBrowserDialog() )
            {
                dialog.Description = "Select the new path of Merge Tools and files";
                StartPosition = FormStartPosition.WindowsDefaultLocation;
                dialog.ShowNewFolderButton = true;
                dialog.RootFolder = Environment.SpecialFolder.Desktop;
                if ( dialog.ShowDialog() == DialogResult.OK )
                {
                    dialog.SelectedPath = dialog.SelectedPath.ToString() + "\\";
                    optionsConf.opt_active_working_path = dialog.SelectedPath;
                    txt_merge_name.Text = dialog.SelectedPath;
                }
            }
        }

        /// <summary>
        /// Apply the new settings, ui form option
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_apply_prefs_Click (object sender, EventArgs e)
        {            
            optionsConf.opt_ask_for_save = chk_ask_save.Checked; 
            optionsConf.opt_auto_flash = chk_ask_flash.Checked;
            optionsConf.opt_remote_folder_check = chk_remote_folder.Checked;
            optionsConf.opt_remote_tool_check = chk_remote_tool.Checked;

            optionsConf.opt_default_flash_tool = cmb_flashtools.SelectedIndex;
            optionsConf.SaveConfiguration();
        }
    }
}

// Are we cool yet?
