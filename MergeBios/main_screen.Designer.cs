namespace MergeBios
{
    partial class frm_mainScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_mainScreen));
            this.cmb_plt_type = new System.Windows.Forms.ComboBox();
            this.cmb_platform = new System.Windows.Forms.ComboBox();
            this.group_platforms = new System.Windows.Forms.GroupBox();
            this.group_preboot = new System.Windows.Forms.GroupBox();
            this.radio_vbios = new System.Windows.Forms.RadioButton();
            this.radio_gop = new System.Windows.Forms.RadioButton();
            this.group_arch = new System.Windows.Forms.GroupBox();
            this.radio_x64 = new System.Windows.Forms.RadioButton();
            this.radio_x32 = new System.Windows.Forms.RadioButton();
            this.group_SBIOS_list = new System.Windows.Forms.GroupBox();
            this.lbl_stepping = new System.Windows.Forms.Label();
            this.cmb_stepping = new System.Windows.Forms.ComboBox();
            this.check_production = new System.Windows.Forms.CheckBox();
            this.cmb_sbios = new System.Windows.Forms.ComboBox();
            this.group_preboot_list = new System.Windows.Forms.GroupBox();
            this.cmb_preboot = new System.Windows.Forms.ComboBox();
            this.group_plt_features = new System.Windows.Forms.GroupBox();
            this.check_f_connected_standby = new System.Windows.Forms.CheckBox();
            this.check_f_hybrid = new System.Windows.Forms.CheckBox();
            this.check_f_seq_mipi = new System.Windows.Forms.CheckBox();
            this.check_f_mipi = new System.Windows.Forms.CheckBox();
            this.group_other_flash = new System.Windows.Forms.GroupBox();
            this.btn_dnx = new System.Windows.Forms.Button();
            this.btn_dediprog = new System.Windows.Forms.Button();
            this.btn_second_stage = new System.Windows.Forms.Button();
            this.btn_flash_ksc = new System.Windows.Forms.Button();
            this.btn_quit = new System.Windows.Forms.Button();
            this.group_output_ports = new System.Windows.Forms.GroupBox();
            this.lbl_display4 = new System.Windows.Forms.Label();
            this.cmb_display4 = new System.Windows.Forms.ComboBox();
            this.check_custom_ports = new System.Windows.Forms.CheckBox();
            this.radio_edp = new System.Windows.Forms.RadioButton();
            this.radio_lvds = new System.Windows.Forms.RadioButton();
            this.lbl_display3 = new System.Windows.Forms.Label();
            this.lbl_display2 = new System.Windows.Forms.Label();
            this.lbl_display1 = new System.Windows.Forms.Label();
            this.lbl_local_flat_panel = new System.Windows.Forms.Label();
            this.cmb_display3 = new System.Windows.Forms.ComboBox();
            this.cmb_display2 = new System.Windows.Forms.ComboBox();
            this.cmb_display1 = new System.Windows.Forms.ComboBox();
            this.cmb_lfp = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatus_Tool = new System.Windows.Forms.ToolStripStatusLabel();
            this.tab1Main = new System.Windows.Forms.TabControl();
            this.tabMainScr = new System.Windows.Forms.TabPage();
            this.lbl_merge_name = new System.Windows.Forms.Label();
            this.txt_merge_ctm_prefix = new System.Windows.Forms.TextBox();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_merge_name = new System.Windows.Forms.TextBox();
            this.txt_save_name = new System.Windows.Forms.TextBox();
            this.btn_apply_prefs = new System.Windows.Forms.Button();
            this.btn_new_merge_folder = new System.Windows.Forms.Button();
            this.btn_new_save_folder = new System.Windows.Forms.Button();
            this.lbl_flash_tool = new System.Windows.Forms.Label();
            this.cmb_flashtools = new System.Windows.Forms.ComboBox();
            this.chk_ask_save = new System.Windows.Forms.CheckBox();
            this.chk_ask_flash = new System.Windows.Forms.CheckBox();
            this.chk_remote_tool = new System.Windows.Forms.CheckBox();
            this.chk_remote_folder = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btn_Create = new System.Windows.Forms.Button();
            this.group_platforms.SuspendLayout();
            this.group_preboot.SuspendLayout();
            this.group_arch.SuspendLayout();
            this.group_SBIOS_list.SuspendLayout();
            this.group_preboot_list.SuspendLayout();
            this.group_plt_features.SuspendLayout();
            this.group_other_flash.SuspendLayout();
            this.group_output_ports.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tab1Main.SuspendLayout();
            this.tabMainScr.SuspendLayout();
            this.tabSettings.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmb_plt_type
            // 
            this.cmb_plt_type.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmb_plt_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_plt_type.Enabled = false;
            this.cmb_plt_type.FormattingEnabled = true;
            this.cmb_plt_type.Location = new System.Drawing.Point(6, 56);
            this.cmb_plt_type.Name = "cmb_plt_type";
            this.cmb_plt_type.Size = new System.Drawing.Size(121, 21);
            this.cmb_plt_type.TabIndex = 0;
            this.cmb_plt_type.SelectedIndexChanged += new System.EventHandler(this.cmb_plt_type_SelectedIndexChanged);
            // 
            // cmb_platform
            // 
            this.cmb_platform.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmb_platform.FormattingEnabled = true;
            this.cmb_platform.Location = new System.Drawing.Point(6, 19);
            this.cmb_platform.Name = "cmb_platform";
            this.cmb_platform.Size = new System.Drawing.Size(190, 21);
            this.cmb_platform.TabIndex = 1;
            this.cmb_platform.SelectedIndexChanged += new System.EventHandler(this.cmb_platform_SelectedIndexChanged);
            // 
            // group_platforms
            // 
            this.group_platforms.Controls.Add(this.cmb_platform);
            this.group_platforms.Controls.Add(this.cmb_plt_type);
            this.group_platforms.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.group_platforms.Location = new System.Drawing.Point(19, 18);
            this.group_platforms.Name = "group_platforms";
            this.group_platforms.Size = new System.Drawing.Size(207, 95);
            this.group_platforms.TabIndex = 2;
            this.group_platforms.TabStop = false;
            this.group_platforms.Text = "Platform and  types";
            // 
            // group_preboot
            // 
            this.group_preboot.Controls.Add(this.radio_vbios);
            this.group_preboot.Controls.Add(this.radio_gop);
            this.group_preboot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.group_preboot.Location = new System.Drawing.Point(242, 18);
            this.group_preboot.Name = "group_preboot";
            this.group_preboot.Size = new System.Drawing.Size(207, 46);
            this.group_preboot.TabIndex = 2;
            this.group_preboot.TabStop = false;
            this.group_preboot.Text = "Preboot";
            // 
            // radio_vbios
            // 
            this.radio_vbios.AutoSize = true;
            this.radio_vbios.Enabled = false;
            this.radio_vbios.Location = new System.Drawing.Point(111, 19);
            this.radio_vbios.Name = "radio_vbios";
            this.radio_vbios.Size = new System.Drawing.Size(62, 17);
            this.radio_vbios.TabIndex = 1;
            this.radio_vbios.TabStop = true;
            this.radio_vbios.Text = "VBIOS";
            this.radio_vbios.UseVisualStyleBackColor = true;
            this.radio_vbios.Click += new System.EventHandler(this.radio_vbios_Click);
            // 
            // radio_gop
            // 
            this.radio_gop.AutoSize = true;
            this.radio_gop.Enabled = false;
            this.radio_gop.Location = new System.Drawing.Point(6, 19);
            this.radio_gop.Name = "radio_gop";
            this.radio_gop.Size = new System.Drawing.Size(51, 17);
            this.radio_gop.TabIndex = 0;
            this.radio_gop.TabStop = true;
            this.radio_gop.Text = "GOP";
            this.radio_gop.UseVisualStyleBackColor = true;
            this.radio_gop.Click += new System.EventHandler(this.radio_gop_Click);
            // 
            // group_arch
            // 
            this.group_arch.Controls.Add(this.radio_x64);
            this.group_arch.Controls.Add(this.radio_x32);
            this.group_arch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.group_arch.Location = new System.Drawing.Point(242, 70);
            this.group_arch.Name = "group_arch";
            this.group_arch.Size = new System.Drawing.Size(207, 47);
            this.group_arch.TabIndex = 3;
            this.group_arch.TabStop = false;
            this.group_arch.Text = "Architecture";
            // 
            // radio_x64
            // 
            this.radio_x64.AutoSize = true;
            this.radio_x64.Enabled = false;
            this.radio_x64.Location = new System.Drawing.Point(111, 19);
            this.radio_x64.Name = "radio_x64";
            this.radio_x64.Size = new System.Drawing.Size(45, 17);
            this.radio_x64.TabIndex = 1;
            this.radio_x64.TabStop = true;
            this.radio_x64.Text = "x64";
            this.radio_x64.UseVisualStyleBackColor = true;
            this.radio_x64.Click += new System.EventHandler(this.radio_x64_Click);
            // 
            // radio_x32
            // 
            this.radio_x32.AutoSize = true;
            this.radio_x32.Enabled = false;
            this.radio_x32.Location = new System.Drawing.Point(6, 19);
            this.radio_x32.Name = "radio_x32";
            this.radio_x32.Size = new System.Drawing.Size(45, 17);
            this.radio_x32.TabIndex = 0;
            this.radio_x32.TabStop = true;
            this.radio_x32.Text = "x32";
            this.radio_x32.UseVisualStyleBackColor = true;
            this.radio_x32.Click += new System.EventHandler(this.radio_x32_Click);
            // 
            // group_SBIOS_list
            // 
            this.group_SBIOS_list.Controls.Add(this.lbl_stepping);
            this.group_SBIOS_list.Controls.Add(this.cmb_stepping);
            this.group_SBIOS_list.Controls.Add(this.check_production);
            this.group_SBIOS_list.Controls.Add(this.cmb_sbios);
            this.group_SBIOS_list.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.group_SBIOS_list.Location = new System.Drawing.Point(455, 18);
            this.group_SBIOS_list.Name = "group_SBIOS_list";
            this.group_SBIOS_list.Size = new System.Drawing.Size(207, 121);
            this.group_SBIOS_list.TabIndex = 4;
            this.group_SBIOS_list.TabStop = false;
            this.group_SBIOS_list.Text = "SystemBIOS";
            // 
            // lbl_stepping
            // 
            this.lbl_stepping.AutoSize = true;
            this.lbl_stepping.Location = new System.Drawing.Point(69, 87);
            this.lbl_stepping.Name = "lbl_stepping";
            this.lbl_stepping.Size = new System.Drawing.Size(57, 13);
            this.lbl_stepping.TabIndex = 3;
            this.lbl_stepping.Text = "Steeping";
            // 
            // cmb_stepping
            // 
            this.cmb_stepping.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmb_stepping.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_stepping.FormattingEnabled = true;
            this.cmb_stepping.Location = new System.Drawing.Point(131, 79);
            this.cmb_stepping.Name = "cmb_stepping";
            this.cmb_stepping.Size = new System.Drawing.Size(59, 21);
            this.cmb_stepping.TabIndex = 2;
            // 
            // check_production
            // 
            this.check_production.AutoSize = true;
            this.check_production.Location = new System.Drawing.Point(10, 53);
            this.check_production.Name = "check_production";
            this.check_production.Size = new System.Drawing.Size(87, 17);
            this.check_production.TabIndex = 1;
            this.check_production.Text = "Production";
            this.check_production.UseVisualStyleBackColor = true;
            this.check_production.Click += new System.EventHandler(this.check_production_Click);
            // 
            // cmb_sbios
            // 
            this.cmb_sbios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmb_sbios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_sbios.FormattingEnabled = true;
            this.cmb_sbios.Location = new System.Drawing.Point(6, 19);
            this.cmb_sbios.Name = "cmb_sbios";
            this.cmb_sbios.Size = new System.Drawing.Size(184, 21);
            this.cmb_sbios.TabIndex = 0;
            this.cmb_sbios.SelectedIndexChanged += new System.EventHandler(this.cmb_sbios_SelectedIndexChanged);
            // 
            // group_preboot_list
            // 
            this.group_preboot_list.Controls.Add(this.cmb_preboot);
            this.group_preboot_list.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.group_preboot_list.Location = new System.Drawing.Point(455, 145);
            this.group_preboot_list.Name = "group_preboot_list";
            this.group_preboot_list.Size = new System.Drawing.Size(207, 54);
            this.group_preboot_list.TabIndex = 0;
            this.group_preboot_list.TabStop = false;
            this.group_preboot_list.Text = "Preboot";
            // 
            // cmb_preboot
            // 
            this.cmb_preboot.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmb_preboot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_preboot.FormattingEnabled = true;
            this.cmb_preboot.Location = new System.Drawing.Point(6, 19);
            this.cmb_preboot.Name = "cmb_preboot";
            this.cmb_preboot.Size = new System.Drawing.Size(146, 21);
            this.cmb_preboot.TabIndex = 0;
            this.cmb_preboot.SelectedIndexChanged += new System.EventHandler(this.cmb_preboot_SelectedIndexChanged);
            // 
            // group_plt_features
            // 
            this.group_plt_features.Controls.Add(this.check_f_connected_standby);
            this.group_plt_features.Controls.Add(this.check_f_hybrid);
            this.group_plt_features.Controls.Add(this.check_f_seq_mipi);
            this.group_plt_features.Controls.Add(this.check_f_mipi);
            this.group_plt_features.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.group_plt_features.Location = new System.Drawing.Point(25, 142);
            this.group_plt_features.Name = "group_plt_features";
            this.group_plt_features.Size = new System.Drawing.Size(276, 48);
            this.group_plt_features.TabIndex = 5;
            this.group_plt_features.TabStop = false;
            this.group_plt_features.Text = "Features Available";
            // 
            // check_f_connected_standby
            // 
            this.check_f_connected_standby.AutoSize = true;
            this.check_f_connected_standby.Enabled = false;
            this.check_f_connected_standby.Location = new System.Drawing.Point(210, 19);
            this.check_f_connected_standby.Name = "check_f_connected_standby";
            this.check_f_connected_standby.Size = new System.Drawing.Size(42, 17);
            this.check_f_connected_standby.TabIndex = 3;
            this.check_f_connected_standby.Text = "CS";
            this.check_f_connected_standby.UseVisualStyleBackColor = true;
            // 
            // check_f_hybrid
            // 
            this.check_f_hybrid.AutoSize = true;
            this.check_f_hybrid.Enabled = false;
            this.check_f_hybrid.Location = new System.Drawing.Point(140, 19);
            this.check_f_hybrid.Name = "check_f_hybrid";
            this.check_f_hybrid.Size = new System.Drawing.Size(62, 17);
            this.check_f_hybrid.TabIndex = 2;
            this.check_f_hybrid.Text = "Hybrid";
            this.check_f_hybrid.UseVisualStyleBackColor = true;
            // 
            // check_f_seq_mipi
            // 
            this.check_f_seq_mipi.AutoSize = true;
            this.check_f_seq_mipi.Enabled = false;
            this.check_f_seq_mipi.Location = new System.Drawing.Point(79, 19);
            this.check_f_seq_mipi.Name = "check_f_seq_mipi";
            this.check_f_seq_mipi.Size = new System.Drawing.Size(51, 17);
            this.check_f_seq_mipi.TabIndex = 1;
            this.check_f_seq_mipi.Text = "SEQ";
            this.check_f_seq_mipi.UseVisualStyleBackColor = true;
            // 
            // check_f_mipi
            // 
            this.check_f_mipi.AutoSize = true;
            this.check_f_mipi.Enabled = false;
            this.check_f_mipi.Location = new System.Drawing.Point(12, 19);
            this.check_f_mipi.Name = "check_f_mipi";
            this.check_f_mipi.Size = new System.Drawing.Size(52, 17);
            this.check_f_mipi.TabIndex = 0;
            this.check_f_mipi.Text = "MIPI";
            this.check_f_mipi.UseVisualStyleBackColor = true;
            // 
            // group_other_flash
            // 
            this.group_other_flash.Controls.Add(this.btn_dnx);
            this.group_other_flash.Controls.Add(this.btn_dediprog);
            this.group_other_flash.Controls.Add(this.btn_second_stage);
            this.group_other_flash.Controls.Add(this.btn_flash_ksc);
            this.group_other_flash.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.group_other_flash.Location = new System.Drawing.Point(681, 18);
            this.group_other_flash.Name = "group_other_flash";
            this.group_other_flash.Size = new System.Drawing.Size(152, 209);
            this.group_other_flash.TabIndex = 4;
            this.group_other_flash.TabStop = false;
            this.group_other_flash.Text = "Secondary Flash Options";
            // 
            // btn_dnx
            // 
            this.btn_dnx.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_dnx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_dnx.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_dnx.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_dnx.ImageIndex = 11;
            this.btn_dnx.ImageList = this.imageList1;
            this.btn_dnx.Location = new System.Drawing.Point(34, 101);
            this.btn_dnx.Name = "btn_dnx";
            this.btn_dnx.Size = new System.Drawing.Size(109, 28);
            this.btn_dnx.TabIndex = 3;
            this.btn_dnx.Text = "Flash DNX";
            this.btn_dnx.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_dnx.UseVisualStyleBackColor = true;
            // 
            // btn_dediprog
            // 
            this.btn_dediprog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_dediprog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_dediprog.Image = ((System.Drawing.Image)(resources.GetObject("btn_dediprog.Image")));
            this.btn_dediprog.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_dediprog.Location = new System.Drawing.Point(34, 144);
            this.btn_dediprog.Name = "btn_dediprog";
            this.btn_dediprog.Size = new System.Drawing.Size(109, 28);
            this.btn_dediprog.TabIndex = 2;
            this.btn_dediprog.Text = "Use Dediprog";
            this.btn_dediprog.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_dediprog.UseVisualStyleBackColor = true;
            // 
            // btn_second_stage
            // 
            this.btn_second_stage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_second_stage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_second_stage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_second_stage.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_second_stage.ImageIndex = 11;
            this.btn_second_stage.ImageList = this.imageList1;
            this.btn_second_stage.Location = new System.Drawing.Point(34, 60);
            this.btn_second_stage.Name = "btn_second_stage";
            this.btn_second_stage.Size = new System.Drawing.Size(109, 28);
            this.btn_second_stage.TabIndex = 1;
            this.btn_second_stage.Text = "Flash S.Stage";
            this.btn_second_stage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_second_stage.UseVisualStyleBackColor = true;
            // 
            // btn_flash_ksc
            // 
            this.btn_flash_ksc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_flash_ksc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_flash_ksc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_flash_ksc.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_flash_ksc.ImageIndex = 11;
            this.btn_flash_ksc.ImageList = this.imageList1;
            this.btn_flash_ksc.Location = new System.Drawing.Point(34, 21);
            this.btn_flash_ksc.Name = "btn_flash_ksc";
            this.btn_flash_ksc.Size = new System.Drawing.Size(109, 28);
            this.btn_flash_ksc.TabIndex = 0;
            this.btn_flash_ksc.Text = "Flash KSC";
            this.btn_flash_ksc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_flash_ksc.UseVisualStyleBackColor = true;
            // 
            // btn_quit
            // 
            this.btn_quit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_quit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_quit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_quit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_quit.ImageIndex = 7;
            this.btn_quit.ImageList = this.imageList1;
            this.btn_quit.Location = new System.Drawing.Point(734, 449);
            this.btn_quit.Name = "btn_quit";
            this.btn_quit.Size = new System.Drawing.Size(103, 29);
            this.btn_quit.TabIndex = 2;
            this.btn_quit.Text = "Quit";
            this.btn_quit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_quit.UseVisualStyleBackColor = true;
            this.btn_quit.Click += new System.EventHandler(this.btn_quit_Click);
            // 
            // group_output_ports
            // 
            this.group_output_ports.Controls.Add(this.lbl_display4);
            this.group_output_ports.Controls.Add(this.cmb_display4);
            this.group_output_ports.Controls.Add(this.check_custom_ports);
            this.group_output_ports.Controls.Add(this.radio_edp);
            this.group_output_ports.Controls.Add(this.radio_lvds);
            this.group_output_ports.Controls.Add(this.lbl_display3);
            this.group_output_ports.Controls.Add(this.lbl_display2);
            this.group_output_ports.Controls.Add(this.lbl_display1);
            this.group_output_ports.Controls.Add(this.lbl_local_flat_panel);
            this.group_output_ports.Controls.Add(this.cmb_display3);
            this.group_output_ports.Controls.Add(this.cmb_display2);
            this.group_output_ports.Controls.Add(this.cmb_display1);
            this.group_output_ports.Controls.Add(this.cmb_lfp);
            this.group_output_ports.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.group_output_ports.Location = new System.Drawing.Point(25, 196);
            this.group_output_ports.Name = "group_output_ports";
            this.group_output_ports.Size = new System.Drawing.Size(475, 127);
            this.group_output_ports.TabIndex = 6;
            this.group_output_ports.TabStop = false;
            this.group_output_ports.Text = "Output Ports";
            // 
            // lbl_display4
            // 
            this.lbl_display4.AutoSize = true;
            this.lbl_display4.Location = new System.Drawing.Point(385, 38);
            this.lbl_display4.Name = "lbl_display4";
            this.lbl_display4.Size = new System.Drawing.Size(79, 13);
            this.lbl_display4.TabIndex = 12;
            this.lbl_display4.Text = "Display 4 (E)";
            // 
            // cmb_display4
            // 
            this.cmb_display4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmb_display4.FormattingEnabled = true;
            this.cmb_display4.Location = new System.Drawing.Point(388, 59);
            this.cmb_display4.Name = "cmb_display4";
            this.cmb_display4.Size = new System.Drawing.Size(77, 21);
            this.cmb_display4.TabIndex = 11;
            this.cmb_display4.SelectedIndexChanged += new System.EventHandler(this.cmb_display4_SelectedIndexChanged);
            // 
            // check_custom_ports
            // 
            this.check_custom_ports.AutoSize = true;
            this.check_custom_ports.Location = new System.Drawing.Point(82, 14);
            this.check_custom_ports.Name = "check_custom_ports";
            this.check_custom_ports.Size = new System.Drawing.Size(194, 17);
            this.check_custom_ports.TabIndex = 10;
            this.check_custom_ports.Text = "Enable Custom Port Selection";
            this.check_custom_ports.UseVisualStyleBackColor = true;
            this.check_custom_ports.Click += new System.EventHandler(this.check_custom_ports_Click);
            // 
            // radio_edp
            // 
            this.radio_edp.AutoSize = true;
            this.radio_edp.Location = new System.Drawing.Point(106, 93);
            this.radio_edp.Name = "radio_edp";
            this.radio_edp.Size = new System.Drawing.Size(49, 17);
            this.radio_edp.TabIndex = 9;
            this.radio_edp.TabStop = true;
            this.radio_edp.Text = "eDP";
            this.radio_edp.UseVisualStyleBackColor = true;
            // 
            // radio_lvds
            // 
            this.radio_lvds.AutoSize = true;
            this.radio_lvds.Location = new System.Drawing.Point(15, 95);
            this.radio_lvds.Name = "radio_lvds";
            this.radio_lvds.Size = new System.Drawing.Size(57, 17);
            this.radio_lvds.TabIndex = 8;
            this.radio_lvds.TabStop = true;
            this.radio_lvds.Text = "LVDS";
            this.radio_lvds.UseVisualStyleBackColor = true;
            // 
            // lbl_display3
            // 
            this.lbl_display3.AutoSize = true;
            this.lbl_display3.Location = new System.Drawing.Point(296, 38);
            this.lbl_display3.Name = "lbl_display3";
            this.lbl_display3.Size = new System.Drawing.Size(80, 13);
            this.lbl_display3.TabIndex = 7;
            this.lbl_display3.Text = "Display 3 (D)";
            // 
            // lbl_display2
            // 
            this.lbl_display2.AutoSize = true;
            this.lbl_display2.Location = new System.Drawing.Point(196, 38);
            this.lbl_display2.Name = "lbl_display2";
            this.lbl_display2.Size = new System.Drawing.Size(79, 13);
            this.lbl_display2.TabIndex = 6;
            this.lbl_display2.Text = "Display 2 (C)";
            // 
            // lbl_display1
            // 
            this.lbl_display1.AutoSize = true;
            this.lbl_display1.Location = new System.Drawing.Point(102, 38);
            this.lbl_display1.Name = "lbl_display1";
            this.lbl_display1.Size = new System.Drawing.Size(79, 13);
            this.lbl_display1.TabIndex = 5;
            this.lbl_display1.Text = "Display 1 (B)";
            // 
            // lbl_local_flat_panel
            // 
            this.lbl_local_flat_panel.AutoSize = true;
            this.lbl_local_flat_panel.Location = new System.Drawing.Point(33, 38);
            this.lbl_local_flat_panel.Name = "lbl_local_flat_panel";
            this.lbl_local_flat_panel.Size = new System.Drawing.Size(29, 13);
            this.lbl_local_flat_panel.TabIndex = 4;
            this.lbl_local_flat_panel.Text = "LFP";
            // 
            // cmb_display3
            // 
            this.cmb_display3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmb_display3.FormattingEnabled = true;
            this.cmb_display3.Location = new System.Drawing.Point(299, 59);
            this.cmb_display3.Name = "cmb_display3";
            this.cmb_display3.Size = new System.Drawing.Size(77, 21);
            this.cmb_display3.TabIndex = 3;
            this.cmb_display3.SelectedIndexChanged += new System.EventHandler(this.cmb_display3_SelectedIndexChanged);
            // 
            // cmb_display2
            // 
            this.cmb_display2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmb_display2.FormattingEnabled = true;
            this.cmb_display2.Location = new System.Drawing.Point(199, 59);
            this.cmb_display2.Name = "cmb_display2";
            this.cmb_display2.Size = new System.Drawing.Size(77, 21);
            this.cmb_display2.TabIndex = 2;
            this.cmb_display2.SelectedIndexChanged += new System.EventHandler(this.cmb_display2_SelectedIndexChanged);
            // 
            // cmb_display1
            // 
            this.cmb_display1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmb_display1.FormattingEnabled = true;
            this.cmb_display1.Location = new System.Drawing.Point(105, 59);
            this.cmb_display1.Name = "cmb_display1";
            this.cmb_display1.Size = new System.Drawing.Size(77, 21);
            this.cmb_display1.TabIndex = 1;
            this.cmb_display1.SelectedIndexChanged += new System.EventHandler(this.cmb_display1_SelectedIndexChanged);
            // 
            // cmb_lfp
            // 
            this.cmb_lfp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmb_lfp.FormattingEnabled = true;
            this.cmb_lfp.Location = new System.Drawing.Point(13, 61);
            this.cmb_lfp.Name = "cmb_lfp";
            this.cmb_lfp.Size = new System.Drawing.Size(77, 21);
            this.cmb_lfp.TabIndex = 0;
            this.cmb_lfp.SelectedIndexChanged += new System.EventHandler(this.cmb_lfp_SelectedIndexChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatus_Tool});
            this.statusStrip1.Location = new System.Drawing.Point(0, 531);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(873, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatus_Tool
            // 
            this.toolStripStatus_Tool.Name = "toolStripStatus_Tool";
            this.toolStripStatus_Tool.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatus_Tool.Text = "Status";
            // 
            // tab1Main
            // 
            this.tab1Main.Controls.Add(this.tabMainScr);
            this.tab1Main.Controls.Add(this.tabSettings);
            this.tab1Main.Cursor = System.Windows.Forms.Cursors.Default;
            this.tab1Main.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab1Main.ImageList = this.imageList1;
            this.tab1Main.Location = new System.Drawing.Point(0, 2);
            this.tab1Main.Name = "tab1Main";
            this.tab1Main.SelectedIndex = 0;
            this.tab1Main.Size = new System.Drawing.Size(866, 522);
            this.tab1Main.TabIndex = 19;
            // 
            // tabMainScr
            // 
            this.tabMainScr.Controls.Add(this.btn_Create);
            this.tabMainScr.Controls.Add(this.lbl_merge_name);
            this.tabMainScr.Controls.Add(this.txt_merge_ctm_prefix);
            this.tabMainScr.Controls.Add(this.group_platforms);
            this.tabMainScr.Controls.Add(this.group_SBIOS_list);
            this.tabMainScr.Controls.Add(this.group_preboot);
            this.tabMainScr.Controls.Add(this.group_arch);
            this.tabMainScr.Controls.Add(this.group_preboot_list);
            this.tabMainScr.Controls.Add(this.group_other_flash);
            this.tabMainScr.Controls.Add(this.group_plt_features);
            this.tabMainScr.Controls.Add(this.group_output_ports);
            this.tabMainScr.Controls.Add(this.btn_quit);
            this.tabMainScr.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabMainScr.ImageIndex = 2;
            this.tabMainScr.Location = new System.Drawing.Point(4, 23);
            this.tabMainScr.Name = "tabMainScr";
            this.tabMainScr.Padding = new System.Windows.Forms.Padding(3);
            this.tabMainScr.Size = new System.Drawing.Size(858, 495);
            this.tabMainScr.TabIndex = 0;
            this.tabMainScr.Text = "Main";
            this.tabMainScr.UseVisualStyleBackColor = true;
            // 
            // lbl_merge_name
            // 
            this.lbl_merge_name.AutoSize = true;
            this.lbl_merge_name.Location = new System.Drawing.Point(142, 357);
            this.lbl_merge_name.Name = "lbl_merge_name";
            this.lbl_merge_name.Size = new System.Drawing.Size(12, 13);
            this.lbl_merge_name.TabIndex = 21;
            this.lbl_merge_name.Text = "_";
            // 
            // txt_merge_ctm_prefix
            // 
            this.txt_merge_ctm_prefix.Location = new System.Drawing.Point(25, 354);
            this.txt_merge_ctm_prefix.Name = "txt_merge_ctm_prefix";
            this.txt_merge_ctm_prefix.Size = new System.Drawing.Size(100, 22);
            this.txt_merge_ctm_prefix.TabIndex = 20;
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.panel1);
            this.tabSettings.ImageIndex = 9;
            this.tabSettings.Location = new System.Drawing.Point(4, 23);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettings.Size = new System.Drawing.Size(858, 495);
            this.tabSettings.TabIndex = 1;
            this.tabSettings.Text = "Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txt_merge_name);
            this.panel1.Controls.Add(this.txt_save_name);
            this.panel1.Controls.Add(this.btn_apply_prefs);
            this.panel1.Controls.Add(this.btn_new_merge_folder);
            this.panel1.Controls.Add(this.btn_new_save_folder);
            this.panel1.Controls.Add(this.lbl_flash_tool);
            this.panel1.Controls.Add(this.cmb_flashtools);
            this.panel1.Controls.Add(this.chk_ask_save);
            this.panel1.Controls.Add(this.chk_ask_flash);
            this.panel1.Controls.Add(this.chk_remote_tool);
            this.panel1.Controls.Add(this.chk_remote_folder);
            this.panel1.Location = new System.Drawing.Point(21, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(538, 451);
            this.panel1.TabIndex = 0;
            // 
            // txt_merge_name
            // 
            this.txt_merge_name.Location = new System.Drawing.Point(197, 236);
            this.txt_merge_name.Name = "txt_merge_name";
            this.txt_merge_name.ReadOnly = true;
            this.txt_merge_name.Size = new System.Drawing.Size(221, 22);
            this.txt_merge_name.TabIndex = 21;
            // 
            // txt_save_name
            // 
            this.txt_save_name.Location = new System.Drawing.Point(197, 200);
            this.txt_save_name.Name = "txt_save_name";
            this.txt_save_name.ReadOnly = true;
            this.txt_save_name.Size = new System.Drawing.Size(221, 22);
            this.txt_save_name.TabIndex = 20;
            // 
            // btn_apply_prefs
            // 
            this.btn_apply_prefs.Image = ((System.Drawing.Image)(resources.GetObject("btn_apply_prefs.Image")));
            this.btn_apply_prefs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_apply_prefs.Location = new System.Drawing.Point(26, 414);
            this.btn_apply_prefs.Name = "btn_apply_prefs";
            this.btn_apply_prefs.Size = new System.Drawing.Size(99, 23);
            this.btn_apply_prefs.TabIndex = 8;
            this.btn_apply_prefs.Text = "Apply";
            this.btn_apply_prefs.UseVisualStyleBackColor = true;
            this.btn_apply_prefs.Click += new System.EventHandler(this.btn_apply_prefs_Click);
            // 
            // btn_new_merge_folder
            // 
            this.btn_new_merge_folder.Location = new System.Drawing.Point(29, 236);
            this.btn_new_merge_folder.Name = "btn_new_merge_folder";
            this.btn_new_merge_folder.Size = new System.Drawing.Size(153, 23);
            this.btn_new_merge_folder.TabIndex = 7;
            this.btn_new_merge_folder.Text = "Set new Merge Files folder";
            this.btn_new_merge_folder.UseVisualStyleBackColor = true;
            this.btn_new_merge_folder.Click += new System.EventHandler(this.btn_new_merge_folder_Click);
            // 
            // btn_new_save_folder
            // 
            this.btn_new_save_folder.Location = new System.Drawing.Point(29, 198);
            this.btn_new_save_folder.Name = "btn_new_save_folder";
            this.btn_new_save_folder.Size = new System.Drawing.Size(153, 23);
            this.btn_new_save_folder.TabIndex = 6;
            this.btn_new_save_folder.Text = "Set new Save to folder";
            this.btn_new_save_folder.UseVisualStyleBackColor = true;
            this.btn_new_save_folder.Click += new System.EventHandler(this.btn_new_save_folder_Click);
            // 
            // lbl_flash_tool
            // 
            this.lbl_flash_tool.AutoSize = true;
            this.lbl_flash_tool.Location = new System.Drawing.Point(26, 157);
            this.lbl_flash_tool.Name = "lbl_flash_tool";
            this.lbl_flash_tool.Size = new System.Drawing.Size(126, 13);
            this.lbl_flash_tool.TabIndex = 5;
            this.lbl_flash_tool.Text = "Select Flash Tool to use";
            // 
            // cmb_flashtools
            // 
            this.cmb_flashtools.FormattingEnabled = true;
            this.cmb_flashtools.Location = new System.Drawing.Point(176, 149);
            this.cmb_flashtools.Name = "cmb_flashtools";
            this.cmb_flashtools.Size = new System.Drawing.Size(121, 21);
            this.cmb_flashtools.TabIndex = 4;
            // 
            // chk_ask_save
            // 
            this.chk_ask_save.AutoSize = true;
            this.chk_ask_save.Location = new System.Drawing.Point(26, 117);
            this.chk_ask_save.Name = "chk_ask_save";
            this.chk_ask_save.Size = new System.Drawing.Size(120, 17);
            this.chk_ask_save.TabIndex = 3;
            this.chk_ask_save.Text = "Always ask to save";
            this.chk_ask_save.UseVisualStyleBackColor = true;
            // 
            // chk_ask_flash
            // 
            this.chk_ask_flash.AutoSize = true;
            this.chk_ask_flash.Location = new System.Drawing.Point(26, 84);
            this.chk_ask_flash.Name = "chk_ask_flash";
            this.chk_ask_flash.Size = new System.Drawing.Size(117, 17);
            this.chk_ask_flash.TabIndex = 2;
            this.chk_ask_flash.Text = "Never ask to flash";
            this.chk_ask_flash.UseVisualStyleBackColor = true;
            // 
            // chk_remote_tool
            // 
            this.chk_remote_tool.AutoSize = true;
            this.chk_remote_tool.Location = new System.Drawing.Point(26, 51);
            this.chk_remote_tool.Name = "chk_remote_tool";
            this.chk_remote_tool.Size = new System.Drawing.Size(258, 17);
            this.chk_remote_tool.TabIndex = 1;
            this.chk_remote_tool.Text = "Don\'t check remote for remote tools chnages";
            this.chk_remote_tool.UseVisualStyleBackColor = true;
            // 
            // chk_remote_folder
            // 
            this.chk_remote_folder.AutoSize = true;
            this.chk_remote_folder.Location = new System.Drawing.Point(26, 18);
            this.chk_remote_folder.Name = "chk_remote_folder";
            this.chk_remote_folder.Size = new System.Drawing.Size(206, 17);
            this.chk_remote_folder.TabIndex = 0;
            this.chk_remote_folder.Text = "Don\'t check remote folder changes";
            this.chk_remote_folder.UseVisualStyleBackColor = true;
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Apps-session-logout-icon.png");
            this.imageList1.Images.SetKeyName(1, "Audio-Cd-icon.png");
            this.imageList1.Images.SetKeyName(2, "Document-Text-icon.png");
            this.imageList1.Images.SetKeyName(3, "Gear-icon.png");
            this.imageList1.Images.SetKeyName(4, "Search-icon.png");
            this.imageList1.Images.SetKeyName(5, "symbol-check-icon.png");
            this.imageList1.Images.SetKeyName(6, "Tools-icon.png");
            this.imageList1.Images.SetKeyName(7, "delete-icon.png");
            this.imageList1.Images.SetKeyName(8, "add-icon.png");
            this.imageList1.Images.SetKeyName(9, "folder-document-icon.png");
            this.imageList1.Images.SetKeyName(10, "Hard-Drive-icon.png");
            this.imageList1.Images.SetKeyName(11, "chip-icon.png");
            // 
            // btn_Create
            // 
            this.btn_Create.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Create.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Create.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Create.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Create.ImageIndex = 5;
            this.btn_Create.ImageList = this.imageList1;
            this.btn_Create.Location = new System.Drawing.Point(734, 405);
            this.btn_Create.Name = "btn_Create";
            this.btn_Create.Size = new System.Drawing.Size(103, 29);
            this.btn_Create.TabIndex = 22;
            this.btn_Create.Text = "Create IFWI";
            this.btn_Create.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Create.UseVisualStyleBackColor = true;
            this.btn_Create.Click += new System.EventHandler(this.btn_Create_Click);
            // 
            // frm_mainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 553);
            this.Controls.Add(this.tab1Main);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frm_mainScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Merge BIOS Tool";
            this.Load += new System.EventHandler(this.frm_mainScreen_Load);
            this.group_platforms.ResumeLayout(false);
            this.group_preboot.ResumeLayout(false);
            this.group_preboot.PerformLayout();
            this.group_arch.ResumeLayout(false);
            this.group_arch.PerformLayout();
            this.group_SBIOS_list.ResumeLayout(false);
            this.group_SBIOS_list.PerformLayout();
            this.group_preboot_list.ResumeLayout(false);
            this.group_plt_features.ResumeLayout(false);
            this.group_plt_features.PerformLayout();
            this.group_other_flash.ResumeLayout(false);
            this.group_output_ports.ResumeLayout(false);
            this.group_output_ports.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tab1Main.ResumeLayout(false);
            this.tabMainScr.ResumeLayout(false);
            this.tabMainScr.PerformLayout();
            this.tabSettings.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_plt_type;
        private System.Windows.Forms.ComboBox cmb_platform;
        private System.Windows.Forms.GroupBox group_platforms;
        private System.Windows.Forms.GroupBox group_preboot;
        private System.Windows.Forms.RadioButton radio_vbios;
        private System.Windows.Forms.RadioButton radio_gop;
        private System.Windows.Forms.GroupBox group_arch;
        private System.Windows.Forms.RadioButton radio_x64;
        private System.Windows.Forms.RadioButton radio_x32;
        private System.Windows.Forms.GroupBox group_SBIOS_list;
        private System.Windows.Forms.ComboBox cmb_sbios;
        private System.Windows.Forms.GroupBox group_preboot_list;
        private System.Windows.Forms.ComboBox cmb_preboot;
        private System.Windows.Forms.GroupBox group_plt_features;
        private System.Windows.Forms.CheckBox check_f_connected_standby;
        private System.Windows.Forms.CheckBox check_f_hybrid;
        private System.Windows.Forms.CheckBox check_f_seq_mipi;
        private System.Windows.Forms.CheckBox check_f_mipi;
        private System.Windows.Forms.ComboBox cmb_stepping;
        private System.Windows.Forms.CheckBox check_production;
        private System.Windows.Forms.GroupBox group_other_flash;
        private System.Windows.Forms.Button btn_second_stage;
        private System.Windows.Forms.Button btn_flash_ksc;
        private System.Windows.Forms.Button btn_dediprog;
        private System.Windows.Forms.Button btn_quit;
        private System.Windows.Forms.Label lbl_stepping;
        private System.Windows.Forms.GroupBox group_output_ports;
        private System.Windows.Forms.RadioButton radio_edp;
        private System.Windows.Forms.RadioButton radio_lvds;
        private System.Windows.Forms.Label lbl_display3;
        private System.Windows.Forms.Label lbl_display2;
        private System.Windows.Forms.Label lbl_display1;
        private System.Windows.Forms.Label lbl_local_flat_panel;
        private System.Windows.Forms.ComboBox cmb_display3;
        private System.Windows.Forms.ComboBox cmb_display2;
        private System.Windows.Forms.ComboBox cmb_display1;
        private System.Windows.Forms.ComboBox cmb_lfp;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatus_Tool;
        private System.Windows.Forms.CheckBox check_custom_ports;
        private System.Windows.Forms.Label lbl_display4;
        private System.Windows.Forms.ComboBox cmb_display4;
        private System.Windows.Forms.Button btn_dnx;
        private System.Windows.Forms.TabControl tab1Main;
        private System.Windows.Forms.TabPage tabMainScr;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_new_merge_folder;
        private System.Windows.Forms.Button btn_new_save_folder;
        private System.Windows.Forms.Label lbl_flash_tool;
        private System.Windows.Forms.ComboBox cmb_flashtools;
        private System.Windows.Forms.CheckBox chk_ask_save;
        private System.Windows.Forms.CheckBox chk_ask_flash;
        private System.Windows.Forms.CheckBox chk_remote_tool;
        private System.Windows.Forms.CheckBox chk_remote_folder;
        private System.Windows.Forms.Button btn_apply_prefs;
        private System.Windows.Forms.TextBox txt_merge_name;
        private System.Windows.Forms.TextBox txt_save_name;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lbl_merge_name;
        private System.Windows.Forms.TextBox txt_merge_ctm_prefix;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btn_Create;
    }
}

