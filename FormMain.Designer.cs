namespace HitmanStatistics {
    partial class FormMain {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.LB_ShotsFired = new System.Windows.Forms.Label();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.LB_Running = new System.Windows.Forms.Label();
            this.NB_ShotsFired = new System.Windows.Forms.Label();
            this.NB_CloseEncounters = new System.Windows.Forms.Label();
            this.LB_CloseEncounters = new System.Windows.Forms.Label();
            this.NB_Alerts = new System.Windows.Forms.Label();
            this.LB_Alerts = new System.Windows.Forms.Label();
            this.NB_EnemiesKilled = new System.Windows.Forms.Label();
            this.LB_EnemiesKilled = new System.Windows.Forms.Label();
            this.NB_InnocentsKilled = new System.Windows.Forms.Label();
            this.LB_InnocentsKilled = new System.Windows.Forms.Label();
            this.LB_Time = new System.Windows.Forms.Label();
            this.LB_MapName = new System.Windows.Forms.Label();
            this.NB_Headshots = new System.Windows.Forms.Label();
            this.LB_Headshots = new System.Windows.Forms.Label();
            this.NB_EnemiesHarmed = new System.Windows.Forms.Label();
            this.LB_EnemiesHarmed = new System.Windows.Forms.Label();
            this.NB_InnocentsHarmed = new System.Windows.Forms.Label();
            this.LB_InnocentsHarmed = new System.Windows.Forms.Label();
            this.LB_SilentAssassin = new System.Windows.Forms.Label();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.Menu_Update = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu_About = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.IMG_SA = new System.Windows.Forms.Panel();
            this.NB_Item15 = new System.Windows.Forms.Label();
            this.LB_Item15 = new System.Windows.Forms.Label();
            this.NB_Item13 = new System.Windows.Forms.Label();
            this.LB_Item13 = new System.Windows.Forms.Label();
            this.NB_Item10 = new System.Windows.Forms.Label();
            this.LB_Item10 = new System.Windows.Forms.Label();
            this.NB_Item14 = new System.Windows.Forms.Label();
            this.LB_Item14 = new System.Windows.Forms.Label();
            this.NB_Item12 = new System.Windows.Forms.Label();
            this.LB_Item12 = new System.Windows.Forms.Label();
            this.NB_Item11 = new System.Windows.Forms.Label();
            this.LB_Item11 = new System.Windows.Forms.Label();
            this.NB_Item9 = new System.Windows.Forms.Label();
            this.LB_Item9 = new System.Windows.Forms.Label();
            this.NB_Item8 = new System.Windows.Forms.Label();
            this.LB_Item8 = new System.Windows.Forms.Label();
            this.NB_Item16 = new System.Windows.Forms.Label();
            this.LB_Item16 = new System.Windows.Forms.Label();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // LB_ShotsFired
            // 
            this.LB_ShotsFired.AutoSize = true;
            this.LB_ShotsFired.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_ShotsFired.Location = new System.Drawing.Point(13, 303);
            this.LB_ShotsFired.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LB_ShotsFired.Name = "LB_ShotsFired";
            this.LB_ShotsFired.Size = new System.Drawing.Size(181, 37);
            this.LB_ShotsFired.TabIndex = 0;
            this.LB_ShotsFired.Text = "Shots Fired";
            // 
            // Timer
            // 
            this.Timer.Enabled = true;
            this.Timer.Interval = 500;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // LB_Running
            // 
            this.LB_Running.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_Running.ForeColor = System.Drawing.Color.DimGray;
            this.LB_Running.Location = new System.Drawing.Point(13, 58);
            this.LB_Running.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LB_Running.Name = "LB_Running";
            this.LB_Running.Size = new System.Drawing.Size(666, 53);
            this.LB_Running.TabIndex = 1;
            this.LB_Running.Text = "Game Not Running";
            this.LB_Running.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NB_ShotsFired
            // 
            this.NB_ShotsFired.AutoSize = true;
            this.NB_ShotsFired.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NB_ShotsFired.ForeColor = System.Drawing.Color.Blue;
            this.NB_ShotsFired.Location = new System.Drawing.Point(313, 303);
            this.NB_ShotsFired.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.NB_ShotsFired.Name = "NB_ShotsFired";
            this.NB_ShotsFired.Size = new System.Drawing.Size(36, 37);
            this.NB_ShotsFired.TabIndex = 7;
            this.NB_ShotsFired.Tag = "Value";
            this.NB_ShotsFired.Text = "0";
            // 
            // NB_CloseEncounters
            // 
            this.NB_CloseEncounters.AutoSize = true;
            this.NB_CloseEncounters.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NB_CloseEncounters.ForeColor = System.Drawing.Color.Blue;
            this.NB_CloseEncounters.Location = new System.Drawing.Point(313, 340);
            this.NB_CloseEncounters.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.NB_CloseEncounters.Name = "NB_CloseEncounters";
            this.NB_CloseEncounters.Size = new System.Drawing.Size(36, 37);
            this.NB_CloseEncounters.TabIndex = 9;
            this.NB_CloseEncounters.Tag = "Value";
            this.NB_CloseEncounters.Text = "0";
            // 
            // LB_CloseEncounters
            // 
            this.LB_CloseEncounters.AutoSize = true;
            this.LB_CloseEncounters.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_CloseEncounters.Location = new System.Drawing.Point(14, 340);
            this.LB_CloseEncounters.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LB_CloseEncounters.Name = "LB_CloseEncounters";
            this.LB_CloseEncounters.Size = new System.Drawing.Size(269, 37);
            this.LB_CloseEncounters.TabIndex = 8;
            this.LB_CloseEncounters.Text = "Close Encounters";
            // 
            // NB_Alerts
            // 
            this.NB_Alerts.AutoSize = true;
            this.NB_Alerts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NB_Alerts.ForeColor = System.Drawing.Color.Blue;
            this.NB_Alerts.Location = new System.Drawing.Point(313, 415);
            this.NB_Alerts.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.NB_Alerts.Name = "NB_Alerts";
            this.NB_Alerts.Size = new System.Drawing.Size(36, 37);
            this.NB_Alerts.TabIndex = 13;
            this.NB_Alerts.Tag = "Value";
            this.NB_Alerts.Text = "0";
            // 
            // LB_Alerts
            // 
            this.LB_Alerts.AutoSize = true;
            this.LB_Alerts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_Alerts.Location = new System.Drawing.Point(14, 415);
            this.LB_Alerts.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LB_Alerts.Name = "LB_Alerts";
            this.LB_Alerts.Size = new System.Drawing.Size(99, 37);
            this.LB_Alerts.TabIndex = 12;
            this.LB_Alerts.Text = "Alerts";
            // 
            // NB_EnemiesKilled
            // 
            this.NB_EnemiesKilled.AutoSize = true;
            this.NB_EnemiesKilled.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NB_EnemiesKilled.ForeColor = System.Drawing.Color.Blue;
            this.NB_EnemiesKilled.Location = new System.Drawing.Point(313, 452);
            this.NB_EnemiesKilled.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.NB_EnemiesKilled.Name = "NB_EnemiesKilled";
            this.NB_EnemiesKilled.Size = new System.Drawing.Size(36, 37);
            this.NB_EnemiesKilled.TabIndex = 15;
            this.NB_EnemiesKilled.Tag = "Value";
            this.NB_EnemiesKilled.Text = "0";
            // 
            // LB_EnemiesKilled
            // 
            this.LB_EnemiesKilled.AutoSize = true;
            this.LB_EnemiesKilled.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_EnemiesKilled.Location = new System.Drawing.Point(13, 452);
            this.LB_EnemiesKilled.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LB_EnemiesKilled.Name = "LB_EnemiesKilled";
            this.LB_EnemiesKilled.Size = new System.Drawing.Size(226, 37);
            this.LB_EnemiesKilled.TabIndex = 14;
            this.LB_EnemiesKilled.Text = "Enemies Killed";
            // 
            // NB_InnocentsKilled
            // 
            this.NB_InnocentsKilled.AutoSize = true;
            this.NB_InnocentsKilled.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NB_InnocentsKilled.ForeColor = System.Drawing.Color.Blue;
            this.NB_InnocentsKilled.Location = new System.Drawing.Point(313, 526);
            this.NB_InnocentsKilled.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.NB_InnocentsKilled.Name = "NB_InnocentsKilled";
            this.NB_InnocentsKilled.Size = new System.Drawing.Size(36, 37);
            this.NB_InnocentsKilled.TabIndex = 17;
            this.NB_InnocentsKilled.Tag = "Value";
            this.NB_InnocentsKilled.Text = "0";
            // 
            // LB_InnocentsKilled
            // 
            this.LB_InnocentsKilled.AutoSize = true;
            this.LB_InnocentsKilled.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_InnocentsKilled.Location = new System.Drawing.Point(14, 526);
            this.LB_InnocentsKilled.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LB_InnocentsKilled.Name = "LB_InnocentsKilled";
            this.LB_InnocentsKilled.Size = new System.Drawing.Size(241, 37);
            this.LB_InnocentsKilled.TabIndex = 16;
            this.LB_InnocentsKilled.Text = "Innocents Killed";
            // 
            // LB_Time
            // 
            this.LB_Time.AutoSize = true;
            this.LB_Time.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_Time.ForeColor = System.Drawing.Color.DimGray;
            this.LB_Time.Location = new System.Drawing.Point(13, 183);
            this.LB_Time.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LB_Time.Name = "LB_Time";
            this.LB_Time.Size = new System.Drawing.Size(132, 39);
            this.LB_Time.TabIndex = 21;
            this.LB_Time.Text = "00:00.0";
            // 
            // LB_MapName
            // 
            this.LB_MapName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_MapName.Location = new System.Drawing.Point(13, 122);
            this.LB_MapName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LB_MapName.Name = "LB_MapName";
            this.LB_MapName.Size = new System.Drawing.Size(666, 61);
            this.LB_MapName.TabIndex = 22;
            this.LB_MapName.Text = "No Mission Active";
            this.LB_MapName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NB_Headshots
            // 
            this.NB_Headshots.AutoSize = true;
            this.NB_Headshots.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NB_Headshots.ForeColor = System.Drawing.Color.Blue;
            this.NB_Headshots.Location = new System.Drawing.Point(313, 378);
            this.NB_Headshots.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.NB_Headshots.Name = "NB_Headshots";
            this.NB_Headshots.Size = new System.Drawing.Size(36, 37);
            this.NB_Headshots.TabIndex = 24;
            this.NB_Headshots.Tag = "Value";
            this.NB_Headshots.Text = "0";
            // 
            // LB_Headshots
            // 
            this.LB_Headshots.AutoSize = true;
            this.LB_Headshots.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_Headshots.Location = new System.Drawing.Point(13, 378);
            this.LB_Headshots.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LB_Headshots.Name = "LB_Headshots";
            this.LB_Headshots.Size = new System.Drawing.Size(170, 37);
            this.LB_Headshots.TabIndex = 23;
            this.LB_Headshots.Text = "Headshots";
            // 
            // NB_EnemiesHarmed
            // 
            this.NB_EnemiesHarmed.AutoSize = true;
            this.NB_EnemiesHarmed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NB_EnemiesHarmed.ForeColor = System.Drawing.Color.Blue;
            this.NB_EnemiesHarmed.Location = new System.Drawing.Point(313, 489);
            this.NB_EnemiesHarmed.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.NB_EnemiesHarmed.Name = "NB_EnemiesHarmed";
            this.NB_EnemiesHarmed.Size = new System.Drawing.Size(36, 37);
            this.NB_EnemiesHarmed.TabIndex = 26;
            this.NB_EnemiesHarmed.Tag = "Value";
            this.NB_EnemiesHarmed.Text = "0";
            // 
            // LB_EnemiesHarmed
            // 
            this.LB_EnemiesHarmed.AutoSize = true;
            this.LB_EnemiesHarmed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_EnemiesHarmed.Location = new System.Drawing.Point(14, 489);
            this.LB_EnemiesHarmed.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LB_EnemiesHarmed.Name = "LB_EnemiesHarmed";
            this.LB_EnemiesHarmed.Size = new System.Drawing.Size(263, 37);
            this.LB_EnemiesHarmed.TabIndex = 25;
            this.LB_EnemiesHarmed.Text = "Enemies Harmed";
            // 
            // NB_InnocentsHarmed
            // 
            this.NB_InnocentsHarmed.AutoSize = true;
            this.NB_InnocentsHarmed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NB_InnocentsHarmed.ForeColor = System.Drawing.Color.Blue;
            this.NB_InnocentsHarmed.Location = new System.Drawing.Point(313, 563);
            this.NB_InnocentsHarmed.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.NB_InnocentsHarmed.Name = "NB_InnocentsHarmed";
            this.NB_InnocentsHarmed.Size = new System.Drawing.Size(36, 37);
            this.NB_InnocentsHarmed.TabIndex = 28;
            this.NB_InnocentsHarmed.Tag = "Value";
            this.NB_InnocentsHarmed.Text = "0";
            // 
            // LB_InnocentsHarmed
            // 
            this.LB_InnocentsHarmed.AutoSize = true;
            this.LB_InnocentsHarmed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_InnocentsHarmed.Location = new System.Drawing.Point(14, 563);
            this.LB_InnocentsHarmed.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LB_InnocentsHarmed.Name = "LB_InnocentsHarmed";
            this.LB_InnocentsHarmed.Size = new System.Drawing.Size(278, 37);
            this.LB_InnocentsHarmed.TabIndex = 27;
            this.LB_InnocentsHarmed.Text = "Innocents Harmed";
            // 
            // LB_SilentAssassin
            // 
            this.LB_SilentAssassin.AutoSize = true;
            this.LB_SilentAssassin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_SilentAssassin.ForeColor = System.Drawing.Color.Green;
            this.LB_SilentAssassin.Location = new System.Drawing.Point(13, 238);
            this.LB_SilentAssassin.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LB_SilentAssassin.Name = "LB_SilentAssassin";
            this.LB_SilentAssassin.Size = new System.Drawing.Size(249, 37);
            this.LB_SilentAssassin.TabIndex = 32;
            this.LB_SilentAssassin.Text = "Silent Assassin";
            // 
            // MainMenu
            // 
            this.MainMenu.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.MainMenu.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu_Update,
            this.Menu_About});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(432, 48);
            this.MainMenu.TabIndex = 34;
            this.MainMenu.Text = "menuStrip1";
            // 
            // Menu_Update
            // 
            this.Menu_Update.Name = "Menu_Update";
            this.Menu_Update.Size = new System.Drawing.Size(111, 44);
            this.Menu_Update.Text = "Update";
            this.Menu_Update.Click += new System.EventHandler(this.Menu_Update_Click);
            // 
            // Menu_About
            // 
            this.Menu_About.Name = "Menu_About";
            this.Menu_About.Size = new System.Drawing.Size(99, 44);
            this.Menu_About.Text = "About";
            this.Menu_About.Click += new System.EventHandler(this.Menu_About_Click);
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::HitmanStatistics.Properties.Resources.Bar;
            this.panel2.Location = new System.Drawing.Point(0, 50);
            this.panel2.Margin = new System.Windows.Forms.Padding(6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(431, 10);
            this.panel2.TabIndex = 36;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::HitmanStatistics.Properties.Resources.Bar;
            this.panel1.Location = new System.Drawing.Point(0, 110);
            this.panel1.Margin = new System.Windows.Forms.Padding(6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(431, 14);
            this.panel1.TabIndex = 35;
            // 
            // IMG_SA
            // 
            this.IMG_SA.BackgroundImage = global::HitmanStatistics.Properties.Resources.Yes;
            this.IMG_SA.Location = new System.Drawing.Point(318, 244);
            this.IMG_SA.Margin = new System.Windows.Forms.Padding(6);
            this.IMG_SA.Name = "IMG_SA";
            this.IMG_SA.Size = new System.Drawing.Size(32, 31);
            this.IMG_SA.TabIndex = 33;
            // 
            // NB_Item15
            // 
            this.NB_Item15.AutoSize = true;
            this.NB_Item15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NB_Item15.ForeColor = System.Drawing.Color.Blue;
            this.NB_Item15.Location = new System.Drawing.Point(313, 860);
            this.NB_Item15.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.NB_Item15.Name = "NB_Item15";
            this.NB_Item15.Size = new System.Drawing.Size(36, 37);
            this.NB_Item15.TabIndex = 52;
            this.NB_Item15.Tag = "Value";
            this.NB_Item15.Text = "0";
            // 
            // LB_Item15
            // 
            this.LB_Item15.AutoSize = true;
            this.LB_Item15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_Item15.Location = new System.Drawing.Point(16, 860);
            this.LB_Item15.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LB_Item15.Name = "LB_Item15";
            this.LB_Item15.Size = new System.Drawing.Size(27, 37);
            this.LB_Item15.TabIndex = 51;
            this.LB_Item15.Text = "-";
            // 
            // NB_Item13
            // 
            this.NB_Item13.AutoSize = true;
            this.NB_Item13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NB_Item13.ForeColor = System.Drawing.Color.Blue;
            this.NB_Item13.Location = new System.Drawing.Point(313, 786);
            this.NB_Item13.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.NB_Item13.Name = "NB_Item13";
            this.NB_Item13.Size = new System.Drawing.Size(36, 37);
            this.NB_Item13.TabIndex = 50;
            this.NB_Item13.Tag = "Value";
            this.NB_Item13.Text = "0";
            // 
            // LB_Item13
            // 
            this.LB_Item13.AutoSize = true;
            this.LB_Item13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_Item13.Location = new System.Drawing.Point(16, 786);
            this.LB_Item13.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LB_Item13.Name = "LB_Item13";
            this.LB_Item13.Size = new System.Drawing.Size(27, 37);
            this.LB_Item13.TabIndex = 49;
            this.LB_Item13.Text = "-";
            // 
            // NB_Item10
            // 
            this.NB_Item10.AutoSize = true;
            this.NB_Item10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NB_Item10.ForeColor = System.Drawing.Color.Blue;
            this.NB_Item10.Location = new System.Drawing.Point(313, 675);
            this.NB_Item10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.NB_Item10.Name = "NB_Item10";
            this.NB_Item10.Size = new System.Drawing.Size(36, 37);
            this.NB_Item10.TabIndex = 48;
            this.NB_Item10.Tag = "Value";
            this.NB_Item10.Text = "0";
            // 
            // LB_Item10
            // 
            this.LB_Item10.AutoSize = true;
            this.LB_Item10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_Item10.Location = new System.Drawing.Point(15, 675);
            this.LB_Item10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LB_Item10.Name = "LB_Item10";
            this.LB_Item10.Size = new System.Drawing.Size(27, 37);
            this.LB_Item10.TabIndex = 47;
            this.LB_Item10.Text = "-";
            // 
            // NB_Item14
            // 
            this.NB_Item14.AutoSize = true;
            this.NB_Item14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NB_Item14.ForeColor = System.Drawing.Color.Blue;
            this.NB_Item14.Location = new System.Drawing.Point(313, 823);
            this.NB_Item14.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.NB_Item14.Name = "NB_Item14";
            this.NB_Item14.Size = new System.Drawing.Size(36, 37);
            this.NB_Item14.TabIndex = 46;
            this.NB_Item14.Tag = "Value";
            this.NB_Item14.Text = "0";
            // 
            // LB_Item14
            // 
            this.LB_Item14.AutoSize = true;
            this.LB_Item14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_Item14.Location = new System.Drawing.Point(16, 823);
            this.LB_Item14.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LB_Item14.Name = "LB_Item14";
            this.LB_Item14.Size = new System.Drawing.Size(27, 37);
            this.LB_Item14.TabIndex = 45;
            this.LB_Item14.Text = "-";
            // 
            // NB_Item12
            // 
            this.NB_Item12.AutoSize = true;
            this.NB_Item12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NB_Item12.ForeColor = System.Drawing.Color.Blue;
            this.NB_Item12.Location = new System.Drawing.Point(313, 749);
            this.NB_Item12.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.NB_Item12.Name = "NB_Item12";
            this.NB_Item12.Size = new System.Drawing.Size(36, 37);
            this.NB_Item12.TabIndex = 44;
            this.NB_Item12.Tag = "Value";
            this.NB_Item12.Text = "0";
            // 
            // LB_Item12
            // 
            this.LB_Item12.AutoSize = true;
            this.LB_Item12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_Item12.Location = new System.Drawing.Point(15, 749);
            this.LB_Item12.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LB_Item12.Name = "LB_Item12";
            this.LB_Item12.Size = new System.Drawing.Size(27, 37);
            this.LB_Item12.TabIndex = 43;
            this.LB_Item12.Text = "-";
            // 
            // NB_Item11
            // 
            this.NB_Item11.AutoSize = true;
            this.NB_Item11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NB_Item11.ForeColor = System.Drawing.Color.Blue;
            this.NB_Item11.Location = new System.Drawing.Point(313, 712);
            this.NB_Item11.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.NB_Item11.Name = "NB_Item11";
            this.NB_Item11.Size = new System.Drawing.Size(36, 37);
            this.NB_Item11.TabIndex = 42;
            this.NB_Item11.Tag = "Value";
            this.NB_Item11.Text = "0";
            // 
            // LB_Item11
            // 
            this.LB_Item11.AutoSize = true;
            this.LB_Item11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_Item11.Location = new System.Drawing.Point(16, 712);
            this.LB_Item11.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LB_Item11.Name = "LB_Item11";
            this.LB_Item11.Size = new System.Drawing.Size(27, 37);
            this.LB_Item11.TabIndex = 41;
            this.LB_Item11.Text = "-";
            // 
            // NB_Item9
            // 
            this.NB_Item9.AutoSize = true;
            this.NB_Item9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NB_Item9.ForeColor = System.Drawing.Color.Blue;
            this.NB_Item9.Location = new System.Drawing.Point(313, 637);
            this.NB_Item9.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.NB_Item9.Name = "NB_Item9";
            this.NB_Item9.Size = new System.Drawing.Size(36, 37);
            this.NB_Item9.TabIndex = 40;
            this.NB_Item9.Tag = "Value";
            this.NB_Item9.Text = "0";
            // 
            // LB_Item9
            // 
            this.LB_Item9.AutoSize = true;
            this.LB_Item9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_Item9.Location = new System.Drawing.Point(16, 637);
            this.LB_Item9.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LB_Item9.Name = "LB_Item9";
            this.LB_Item9.Size = new System.Drawing.Size(27, 37);
            this.LB_Item9.TabIndex = 39;
            this.LB_Item9.Text = "-";
            // 
            // NB_Item8
            // 
            this.NB_Item8.AutoSize = true;
            this.NB_Item8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NB_Item8.ForeColor = System.Drawing.Color.Blue;
            this.NB_Item8.Location = new System.Drawing.Point(313, 600);
            this.NB_Item8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.NB_Item8.Name = "NB_Item8";
            this.NB_Item8.Size = new System.Drawing.Size(36, 37);
            this.NB_Item8.TabIndex = 38;
            this.NB_Item8.Tag = "Value";
            this.NB_Item8.Text = "0";
            // 
            // LB_Item8
            // 
            this.LB_Item8.AutoSize = true;
            this.LB_Item8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_Item8.Location = new System.Drawing.Point(15, 600);
            this.LB_Item8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LB_Item8.Name = "LB_Item8";
            this.LB_Item8.Size = new System.Drawing.Size(27, 37);
            this.LB_Item8.TabIndex = 37;
            this.LB_Item8.Text = "-";
            // 
            // NB_Item16
            // 
            this.NB_Item16.AutoSize = true;
            this.NB_Item16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NB_Item16.ForeColor = System.Drawing.Color.Blue;
            this.NB_Item16.Location = new System.Drawing.Point(313, 897);
            this.NB_Item16.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.NB_Item16.Name = "NB_Item16";
            this.NB_Item16.Size = new System.Drawing.Size(36, 37);
            this.NB_Item16.TabIndex = 54;
            this.NB_Item16.Tag = "Value";
            this.NB_Item16.Text = "0";
            // 
            // LB_Item16
            // 
            this.LB_Item16.AutoSize = true;
            this.LB_Item16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_Item16.Location = new System.Drawing.Point(16, 897);
            this.LB_Item16.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LB_Item16.Name = "LB_Item16";
            this.LB_Item16.Size = new System.Drawing.Size(27, 37);
            this.LB_Item16.TabIndex = 53;
            this.LB_Item16.Text = "-";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 949);
            this.Controls.Add(this.NB_Item16);
            this.Controls.Add(this.LB_Item16);
            this.Controls.Add(this.NB_Item15);
            this.Controls.Add(this.LB_Item15);
            this.Controls.Add(this.NB_Item13);
            this.Controls.Add(this.LB_Item13);
            this.Controls.Add(this.NB_Item10);
            this.Controls.Add(this.LB_Item10);
            this.Controls.Add(this.NB_Item14);
            this.Controls.Add(this.LB_Item14);
            this.Controls.Add(this.NB_Item12);
            this.Controls.Add(this.LB_Item12);
            this.Controls.Add(this.NB_Item11);
            this.Controls.Add(this.LB_Item11);
            this.Controls.Add(this.NB_Item9);
            this.Controls.Add(this.LB_Item9);
            this.Controls.Add(this.NB_Item8);
            this.Controls.Add(this.LB_Item8);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.IMG_SA);
            this.Controls.Add(this.LB_SilentAssassin);
            this.Controls.Add(this.NB_InnocentsHarmed);
            this.Controls.Add(this.LB_InnocentsHarmed);
            this.Controls.Add(this.NB_EnemiesHarmed);
            this.Controls.Add(this.LB_EnemiesHarmed);
            this.Controls.Add(this.NB_Headshots);
            this.Controls.Add(this.LB_Headshots);
            this.Controls.Add(this.LB_MapName);
            this.Controls.Add(this.LB_Time);
            this.Controls.Add(this.NB_InnocentsKilled);
            this.Controls.Add(this.LB_InnocentsKilled);
            this.Controls.Add(this.NB_EnemiesKilled);
            this.Controls.Add(this.LB_EnemiesKilled);
            this.Controls.Add(this.NB_Alerts);
            this.Controls.Add(this.LB_Alerts);
            this.Controls.Add(this.NB_CloseEncounters);
            this.Controls.Add(this.LB_CloseEncounters);
            this.Controls.Add(this.NB_ShotsFired);
            this.Controls.Add(this.LB_Running);
            this.Controls.Add(this.LB_ShotsFired);
            this.Controls.Add(this.MainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainMenu;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "Hitman Statistics";
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LB_ShotsFired;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Label LB_Running;
        private System.Windows.Forms.Label NB_ShotsFired;
        private System.Windows.Forms.Label NB_CloseEncounters;
        private System.Windows.Forms.Label LB_CloseEncounters;
        private System.Windows.Forms.Label NB_Alerts;
        private System.Windows.Forms.Label LB_Alerts;
        private System.Windows.Forms.Label NB_EnemiesKilled;
        private System.Windows.Forms.Label LB_EnemiesKilled;
        private System.Windows.Forms.Label NB_InnocentsKilled;
        private System.Windows.Forms.Label LB_InnocentsKilled;
        private System.Windows.Forms.Label LB_Time;
        private System.Windows.Forms.Label LB_MapName;
        private System.Windows.Forms.Label NB_Headshots;
        private System.Windows.Forms.Label LB_Headshots;
        private System.Windows.Forms.Label NB_EnemiesHarmed;
        private System.Windows.Forms.Label LB_EnemiesHarmed;
        private System.Windows.Forms.Label NB_InnocentsHarmed;
        private System.Windows.Forms.Label LB_InnocentsHarmed;
        private System.Windows.Forms.Label LB_SilentAssassin;
        private System.Windows.Forms.Panel IMG_SA;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripMenuItem Menu_Update;
        private System.Windows.Forms.ToolStripMenuItem Menu_About;
        private System.Windows.Forms.Label NB_Item15;
        private System.Windows.Forms.Label LB_Item15;
        private System.Windows.Forms.Label NB_Item13;
        private System.Windows.Forms.Label LB_Item13;
        private System.Windows.Forms.Label NB_Item10;
        private System.Windows.Forms.Label LB_Item10;
        private System.Windows.Forms.Label NB_Item14;
        private System.Windows.Forms.Label LB_Item14;
        private System.Windows.Forms.Label NB_Item12;
        private System.Windows.Forms.Label LB_Item12;
        private System.Windows.Forms.Label NB_Item11;
        private System.Windows.Forms.Label LB_Item11;
        private System.Windows.Forms.Label NB_Item9;
        private System.Windows.Forms.Label LB_Item9;
        private System.Windows.Forms.Label NB_Item8;
        private System.Windows.Forms.Label LB_Item8;
        private System.Windows.Forms.Label NB_Item16;
        private System.Windows.Forms.Label LB_Item16;
    }
}

