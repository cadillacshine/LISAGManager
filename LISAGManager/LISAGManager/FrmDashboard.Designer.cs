namespace LISAGManager {
    partial class FrmDashboard {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDashboard));
            this.panel1 = new System.Windows.Forms.Panel();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup4 = new DevExpress.XtraNavBar.NavBarGroup();
            this.nbiManageAccount = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarSeparatorItem3 = new DevExpress.XtraNavBar.NavBarSeparatorItem();
            this.nbiActivityLog = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.nbiMyProfile = new DevExpress.XtraNavBar.NavBarItem();
            this.nbiChangePassword = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarSeparatorItem2 = new DevExpress.XtraNavBar.NavBarSeparatorItem();
            this.nbiMyAgents = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarSeparatorItem4 = new DevExpress.XtraNavBar.NavBarSeparatorItem();
            this.nbiLogOut = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup2 = new DevExpress.XtraNavBar.NavBarGroup();
            this.nbiSurveyors = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarSeparatorItem5 = new DevExpress.XtraNavBar.NavBarSeparatorItem();
            this.nbiAgents = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup3 = new DevExpress.XtraNavBar.NavBarGroup();
            this.nbiSetupAgent = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarSeparatorItem6 = new DevExpress.XtraNavBar.NavBarSeparatorItem();
            this.nbiRegion = new DevExpress.XtraNavBar.NavBarItem();
            this.nbiCity = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarSeparatorItem1 = new DevExpress.XtraNavBar.NavBarSeparatorItem();
            this.nbiBank = new DevExpress.XtraNavBar.NavBarItem();
            this.nbiBankBranch = new DevExpress.XtraNavBar.NavBarItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.pbProfilePic = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProfilePic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.navBarControl1);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navBarGroup4;
            this.navBarControl1.Appearance.Background.BackColor = ((System.Drawing.Color)(resources.GetObject("navBarControl1.Appearance.Background.BackColor")));
            this.navBarControl1.Appearance.Background.Font = ((System.Drawing.Font)(resources.GetObject("navBarControl1.Appearance.Background.Font")));
            this.navBarControl1.Appearance.Background.Options.UseBackColor = true;
            this.navBarControl1.Appearance.Background.Options.UseFont = true;
            this.navBarControl1.BackColor = System.Drawing.Color.Green;
            resources.ApplyResources(this.navBarControl1, "navBarControl1");
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup4,
            this.navBarGroup1,
            this.navBarGroup2,
            this.navBarGroup3});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.nbiSurveyors,
            this.nbiAgents,
            this.nbiRegion,
            this.nbiCity,
            this.navBarSeparatorItem1,
            this.nbiBank,
            this.nbiBankBranch,
            this.nbiMyProfile,
            this.nbiChangePassword,
            this.navBarSeparatorItem2,
            this.nbiLogOut,
            this.nbiManageAccount,
            this.navBarSeparatorItem3,
            this.nbiActivityLog,
            this.nbiMyAgents,
            this.navBarSeparatorItem4,
            this.navBarSeparatorItem5,
            this.nbiSetupAgent,
            this.navBarSeparatorItem6});
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = ((int)(resources.GetObject("resource.ExpandedWidth")));
            this.navBarControl1.Click += new System.EventHandler(this.navBarControl1_Click);
            // 
            // navBarGroup4
            // 
            resources.ApplyResources(this.navBarGroup4, "navBarGroup4");
            this.navBarGroup4.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsText;
            this.navBarGroup4.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiManageAccount),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarSeparatorItem3),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiActivityLog)});
            this.navBarGroup4.Name = "navBarGroup4";
            // 
            // nbiManageAccount
            // 
            this.nbiManageAccount.CanDrag = false;
            resources.ApplyResources(this.nbiManageAccount, "nbiManageAccount");
            this.nbiManageAccount.Name = "nbiManageAccount";
            this.nbiManageAccount.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiManageAccount_LinkClicked);
            // 
            // navBarSeparatorItem3
            // 
            this.navBarSeparatorItem3.CanDrag = false;
            this.navBarSeparatorItem3.Enabled = false;
            resources.ApplyResources(this.navBarSeparatorItem3, "navBarSeparatorItem3");
            this.navBarSeparatorItem3.LargeImageSize = new System.Drawing.Size(0, 0);
            this.navBarSeparatorItem3.Name = "navBarSeparatorItem3";
            this.navBarSeparatorItem3.SmallImageSize = new System.Drawing.Size(0, 0);
            // 
            // nbiActivityLog
            // 
            resources.ApplyResources(this.nbiActivityLog, "nbiActivityLog");
            this.nbiActivityLog.Name = "nbiActivityLog";
            this.nbiActivityLog.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiActivityLog_LinkClicked);
            // 
            // navBarGroup1
            // 
            resources.ApplyResources(this.navBarGroup1, "navBarGroup1");
            this.navBarGroup1.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsText;
            this.navBarGroup1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiMyProfile),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiChangePassword),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarSeparatorItem2),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiMyAgents),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarSeparatorItem4),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiLogOut)});
            this.navBarGroup1.Name = "navBarGroup1";
            // 
            // nbiMyProfile
            // 
            resources.ApplyResources(this.nbiMyProfile, "nbiMyProfile");
            this.nbiMyProfile.Name = "nbiMyProfile";
            this.nbiMyProfile.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiMyProfile_LinkClicked);
            // 
            // nbiChangePassword
            // 
            resources.ApplyResources(this.nbiChangePassword, "nbiChangePassword");
            this.nbiChangePassword.Name = "nbiChangePassword";
            this.nbiChangePassword.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiChangePassword_LinkClicked);
            // 
            // navBarSeparatorItem2
            // 
            this.navBarSeparatorItem2.CanDrag = false;
            this.navBarSeparatorItem2.Enabled = false;
            resources.ApplyResources(this.navBarSeparatorItem2, "navBarSeparatorItem2");
            this.navBarSeparatorItem2.LargeImageSize = new System.Drawing.Size(0, 0);
            this.navBarSeparatorItem2.Name = "navBarSeparatorItem2";
            this.navBarSeparatorItem2.SmallImageSize = new System.Drawing.Size(0, 0);
            // 
            // nbiMyAgents
            // 
            resources.ApplyResources(this.nbiMyAgents, "nbiMyAgents");
            this.nbiMyAgents.Name = "nbiMyAgents";
            this.nbiMyAgents.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiMyAgents_LinkClicked);
            // 
            // navBarSeparatorItem4
            // 
            this.navBarSeparatorItem4.CanDrag = false;
            this.navBarSeparatorItem4.Enabled = false;
            resources.ApplyResources(this.navBarSeparatorItem4, "navBarSeparatorItem4");
            this.navBarSeparatorItem4.LargeImageSize = new System.Drawing.Size(0, 0);
            this.navBarSeparatorItem4.Name = "navBarSeparatorItem4";
            this.navBarSeparatorItem4.SmallImageSize = new System.Drawing.Size(0, 0);
            // 
            // nbiLogOut
            // 
            resources.ApplyResources(this.nbiLogOut, "nbiLogOut");
            this.nbiLogOut.Name = "nbiLogOut";
            this.nbiLogOut.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiLogOut_LinkClicked);
            // 
            // navBarGroup2
            // 
            resources.ApplyResources(this.navBarGroup2, "navBarGroup2");
            this.navBarGroup2.Expanded = true;
            this.navBarGroup2.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsText;
            this.navBarGroup2.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiSurveyors),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarSeparatorItem5),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiAgents)});
            this.navBarGroup2.Name = "navBarGroup2";
            // 
            // nbiSurveyors
            // 
            resources.ApplyResources(this.nbiSurveyors, "nbiSurveyors");
            this.nbiSurveyors.Name = "nbiSurveyors";
            this.nbiSurveyors.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiSurveyors_LinkClicked);
            // 
            // navBarSeparatorItem5
            // 
            this.navBarSeparatorItem5.CanDrag = false;
            this.navBarSeparatorItem5.Enabled = false;
            resources.ApplyResources(this.navBarSeparatorItem5, "navBarSeparatorItem5");
            this.navBarSeparatorItem5.LargeImageSize = new System.Drawing.Size(0, 0);
            this.navBarSeparatorItem5.Name = "navBarSeparatorItem5";
            this.navBarSeparatorItem5.SmallImageSize = new System.Drawing.Size(0, 0);
            // 
            // nbiAgents
            // 
            resources.ApplyResources(this.nbiAgents, "nbiAgents");
            this.nbiAgents.Name = "nbiAgents";
            this.nbiAgents.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiAgents_LinkClicked);
            // 
            // navBarGroup3
            // 
            resources.ApplyResources(this.navBarGroup3, "navBarGroup3");
            this.navBarGroup3.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsText;
            this.navBarGroup3.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiSetupAgent),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarSeparatorItem6),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiRegion),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiCity),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarSeparatorItem1),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiBank),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiBankBranch)});
            this.navBarGroup3.Name = "navBarGroup3";
            // 
            // nbiSetupAgent
            // 
            resources.ApplyResources(this.nbiSetupAgent, "nbiSetupAgent");
            this.nbiSetupAgent.Name = "nbiSetupAgent";
            this.nbiSetupAgent.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiSetupAgent_LinkClicked);
            // 
            // navBarSeparatorItem6
            // 
            this.navBarSeparatorItem6.CanDrag = false;
            this.navBarSeparatorItem6.Enabled = false;
            resources.ApplyResources(this.navBarSeparatorItem6, "navBarSeparatorItem6");
            this.navBarSeparatorItem6.LargeImageSize = new System.Drawing.Size(0, 0);
            this.navBarSeparatorItem6.Name = "navBarSeparatorItem6";
            this.navBarSeparatorItem6.SmallImageSize = new System.Drawing.Size(0, 0);
            // 
            // nbiRegion
            // 
            resources.ApplyResources(this.nbiRegion, "nbiRegion");
            this.nbiRegion.Name = "nbiRegion";
            this.nbiRegion.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiRegion_LinkClicked);
            // 
            // nbiCity
            // 
            resources.ApplyResources(this.nbiCity, "nbiCity");
            this.nbiCity.Name = "nbiCity";
            this.nbiCity.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiCity_LinkClicked);
            // 
            // navBarSeparatorItem1
            // 
            this.navBarSeparatorItem1.CanDrag = false;
            this.navBarSeparatorItem1.Enabled = false;
            resources.ApplyResources(this.navBarSeparatorItem1, "navBarSeparatorItem1");
            this.navBarSeparatorItem1.LargeImageSize = new System.Drawing.Size(0, 0);
            this.navBarSeparatorItem1.Name = "navBarSeparatorItem1";
            this.navBarSeparatorItem1.SmallImageSize = new System.Drawing.Size(0, 0);
            // 
            // nbiBank
            // 
            resources.ApplyResources(this.nbiBank, "nbiBank");
            this.nbiBank.Name = "nbiBank";
            this.nbiBank.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiBank_LinkClicked);
            // 
            // nbiBankBranch
            // 
            resources.ApplyResources(this.nbiBankBranch, "nbiBankBranch");
            this.nbiBankBranch.Name = "nbiBankBranch";
            this.nbiBankBranch.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiBankBranch_LinkClicked);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkGreen;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.lblUsername);
            this.panel2.Controls.Add(this.pbProfilePic);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Name = "label2";
            // 
            // lblUsername
            // 
            resources.ApplyResources(this.lblUsername, "lblUsername");
            this.lblUsername.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblUsername.Name = "lblUsername";
            // 
            // pbProfilePic
            // 
            resources.ApplyResources(this.pbProfilePic, "pbProfilePic");
            this.pbProfilePic.Image = global::LISAGManager.Properties.Resources.User;
            this.pbProfilePic.Name = "pbProfilePic";
            this.pbProfilePic.TabStop = false;
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = global::LISAGManager.Properties.Resources.LISAG2;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkGreen;
            this.panel3.Controls.Add(this.label1);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Name = "label1";
            // 
            // FrmDashboard
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.IsMdiContainer = true;
            this.Name = "FrmDashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmDashboard_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProfilePic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup2;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.PictureBox pbProfilePic;
        private DevExpress.XtraNavBar.NavBarItem nbiSurveyors;
        private DevExpress.XtraNavBar.NavBarItem nbiAgents;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup3;
        private DevExpress.XtraNavBar.NavBarItem nbiRegion;
        private DevExpress.XtraNavBar.NavBarItem nbiCity;
        private DevExpress.XtraNavBar.NavBarSeparatorItem navBarSeparatorItem1;
        private DevExpress.XtraNavBar.NavBarItem nbiBank;
        private DevExpress.XtraNavBar.NavBarItem nbiBankBranch;
        private DevExpress.XtraNavBar.NavBarItem nbiMyProfile;
        private DevExpress.XtraNavBar.NavBarItem nbiChangePassword;
        private DevExpress.XtraNavBar.NavBarSeparatorItem navBarSeparatorItem2;
        private DevExpress.XtraNavBar.NavBarItem nbiLogOut;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup4;
        private DevExpress.XtraNavBar.NavBarItem nbiManageAccount;
        private DevExpress.XtraNavBar.NavBarSeparatorItem navBarSeparatorItem3;
        private DevExpress.XtraNavBar.NavBarItem nbiActivityLog;
        private DevExpress.XtraNavBar.NavBarItem nbiMyAgents;
        private DevExpress.XtraNavBar.NavBarSeparatorItem navBarSeparatorItem4;
        private DevExpress.XtraNavBar.NavBarSeparatorItem navBarSeparatorItem5;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraNavBar.NavBarItem nbiSetupAgent;
        private DevExpress.XtraNavBar.NavBarSeparatorItem navBarSeparatorItem6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}