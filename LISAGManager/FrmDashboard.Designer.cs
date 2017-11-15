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
            this.label1 = new System.Windows.Forms.Label();
            this.pbProfilePic = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProfilePic)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.navBarControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 66);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(302, 1074);
            this.panel1.TabIndex = 0;
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navBarGroup4;
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.navBarControl1.Location = new System.Drawing.Point(0, 0);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 302;
            this.navBarControl1.Size = new System.Drawing.Size(302, 1074);
            this.navBarControl1.TabIndex = 0;
            this.navBarControl1.Text = "navBarControl1";
            // 
            // navBarGroup4
            // 
            this.navBarGroup4.Caption = "System Admin";
            this.navBarGroup4.Expanded = true;
            this.navBarGroup4.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsText;
            this.navBarGroup4.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiManageAccount),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarSeparatorItem3),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiActivityLog)});
            this.navBarGroup4.Name = "navBarGroup4";
            this.navBarGroup4.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarGroup4.SmallImage")));
            // 
            // nbiManageAccount
            // 
            this.nbiManageAccount.CanDrag = false;
            this.nbiManageAccount.Caption = "Manage Account(s)";
            this.nbiManageAccount.LargeImage = ((System.Drawing.Image)(resources.GetObject("nbiManageAccount.LargeImage")));
            this.nbiManageAccount.Name = "nbiManageAccount";
            this.nbiManageAccount.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiManageAccount_LinkClicked);
            // 
            // navBarSeparatorItem3
            // 
            this.navBarSeparatorItem3.CanDrag = false;
            this.navBarSeparatorItem3.Enabled = false;
            this.navBarSeparatorItem3.Hint = null;
            this.navBarSeparatorItem3.LargeImageIndex = 0;
            this.navBarSeparatorItem3.LargeImageSize = new System.Drawing.Size(0, 0);
            this.navBarSeparatorItem3.Name = "navBarSeparatorItem3";
            this.navBarSeparatorItem3.SmallImageIndex = 0;
            this.navBarSeparatorItem3.SmallImageSize = new System.Drawing.Size(0, 0);
            // 
            // nbiActivityLog
            // 
            this.nbiActivityLog.Caption = "Activity Log";
            this.nbiActivityLog.LargeImage = ((System.Drawing.Image)(resources.GetObject("nbiActivityLog.LargeImage")));
            this.nbiActivityLog.Name = "nbiActivityLog";
            this.nbiActivityLog.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiActivityLog_LinkClicked);
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "Me";
            this.navBarGroup1.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsText;
            this.navBarGroup1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiMyProfile),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiChangePassword),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarSeparatorItem2),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiMyAgents),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarSeparatorItem4),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiLogOut)});
            this.navBarGroup1.Name = "navBarGroup1";
            this.navBarGroup1.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarGroup1.SmallImage")));
            // 
            // nbiMyProfile
            // 
            this.nbiMyProfile.Caption = "My Profile";
            this.nbiMyProfile.LargeImage = ((System.Drawing.Image)(resources.GetObject("nbiMyProfile.LargeImage")));
            this.nbiMyProfile.Name = "nbiMyProfile";
            this.nbiMyProfile.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiMyProfile_LinkClicked);
            // 
            // nbiChangePassword
            // 
            this.nbiChangePassword.Caption = "Change Password";
            this.nbiChangePassword.LargeImage = ((System.Drawing.Image)(resources.GetObject("nbiChangePassword.LargeImage")));
            this.nbiChangePassword.Name = "nbiChangePassword";
            this.nbiChangePassword.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiChangePassword_LinkClicked);
            // 
            // navBarSeparatorItem2
            // 
            this.navBarSeparatorItem2.CanDrag = false;
            this.navBarSeparatorItem2.Enabled = false;
            this.navBarSeparatorItem2.Hint = null;
            this.navBarSeparatorItem2.LargeImageIndex = 0;
            this.navBarSeparatorItem2.LargeImageSize = new System.Drawing.Size(0, 0);
            this.navBarSeparatorItem2.Name = "navBarSeparatorItem2";
            this.navBarSeparatorItem2.SmallImageIndex = 0;
            this.navBarSeparatorItem2.SmallImageSize = new System.Drawing.Size(0, 0);
            // 
            // nbiMyAgents
            // 
            this.nbiMyAgents.Caption = "My Agents";
            this.nbiMyAgents.LargeImage = ((System.Drawing.Image)(resources.GetObject("nbiMyAgents.LargeImage")));
            this.nbiMyAgents.Name = "nbiMyAgents";
            this.nbiMyAgents.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiMyAgents_LinkClicked);
            // 
            // navBarSeparatorItem4
            // 
            this.navBarSeparatorItem4.CanDrag = false;
            this.navBarSeparatorItem4.Enabled = false;
            this.navBarSeparatorItem4.Hint = null;
            this.navBarSeparatorItem4.LargeImageIndex = 0;
            this.navBarSeparatorItem4.LargeImageSize = new System.Drawing.Size(0, 0);
            this.navBarSeparatorItem4.Name = "navBarSeparatorItem4";
            this.navBarSeparatorItem4.SmallImageIndex = 0;
            this.navBarSeparatorItem4.SmallImageSize = new System.Drawing.Size(0, 0);
            // 
            // nbiLogOut
            // 
            this.nbiLogOut.Caption = "Log Out";
            this.nbiLogOut.LargeImage = ((System.Drawing.Image)(resources.GetObject("nbiLogOut.LargeImage")));
            this.nbiLogOut.Name = "nbiLogOut";
            this.nbiLogOut.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiLogOut_LinkClicked);
            // 
            // navBarGroup2
            // 
            this.navBarGroup2.Caption = "Surveyors";
            this.navBarGroup2.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsText;
            this.navBarGroup2.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiSurveyors),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarSeparatorItem5),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nbiAgents)});
            this.navBarGroup2.Name = "navBarGroup2";
            this.navBarGroup2.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarGroup2.SmallImage")));
            // 
            // nbiSurveyors
            // 
            this.nbiSurveyors.Caption = "All Surveyors";
            this.nbiSurveyors.LargeImage = ((System.Drawing.Image)(resources.GetObject("nbiSurveyors.LargeImage")));
            this.nbiSurveyors.Name = "nbiSurveyors";
            this.nbiSurveyors.SmallImage = ((System.Drawing.Image)(resources.GetObject("nbiSurveyors.SmallImage")));
            this.nbiSurveyors.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiSurveyors_LinkClicked);
            // 
            // navBarSeparatorItem5
            // 
            this.navBarSeparatorItem5.CanDrag = false;
            this.navBarSeparatorItem5.Enabled = false;
            this.navBarSeparatorItem5.Hint = null;
            this.navBarSeparatorItem5.LargeImageIndex = 0;
            this.navBarSeparatorItem5.LargeImageSize = new System.Drawing.Size(0, 0);
            this.navBarSeparatorItem5.Name = "navBarSeparatorItem5";
            this.navBarSeparatorItem5.SmallImageIndex = 0;
            this.navBarSeparatorItem5.SmallImageSize = new System.Drawing.Size(0, 0);
            // 
            // nbiAgents
            // 
            this.nbiAgents.Caption = "All Agents";
            this.nbiAgents.LargeImage = ((System.Drawing.Image)(resources.GetObject("nbiAgents.LargeImage")));
            this.nbiAgents.Name = "nbiAgents";
            this.nbiAgents.SmallImage = ((System.Drawing.Image)(resources.GetObject("nbiAgents.SmallImage")));
            this.nbiAgents.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiAgents_LinkClicked);
            // 
            // navBarGroup3
            // 
            this.navBarGroup3.Caption = "Setups";
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
            this.navBarGroup3.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarGroup3.SmallImage")));
            // 
            // nbiSetupAgent
            // 
            this.nbiSetupAgent.Caption = "Agent";
            this.nbiSetupAgent.LargeImage = ((System.Drawing.Image)(resources.GetObject("nbiSetupAgent.LargeImage")));
            this.nbiSetupAgent.Name = "nbiSetupAgent";
            this.nbiSetupAgent.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiSetupAgent_LinkClicked);
            // 
            // navBarSeparatorItem6
            // 
            this.navBarSeparatorItem6.CanDrag = false;
            this.navBarSeparatorItem6.Enabled = false;
            this.navBarSeparatorItem6.Hint = null;
            this.navBarSeparatorItem6.LargeImageIndex = 0;
            this.navBarSeparatorItem6.LargeImageSize = new System.Drawing.Size(0, 0);
            this.navBarSeparatorItem6.Name = "navBarSeparatorItem6";
            this.navBarSeparatorItem6.SmallImageIndex = 0;
            this.navBarSeparatorItem6.SmallImageSize = new System.Drawing.Size(0, 0);
            // 
            // nbiRegion
            // 
            this.nbiRegion.Caption = "Region";
            this.nbiRegion.LargeImage = ((System.Drawing.Image)(resources.GetObject("nbiRegion.LargeImage")));
            this.nbiRegion.Name = "nbiRegion";
            this.nbiRegion.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiRegion_LinkClicked);
            // 
            // nbiCity
            // 
            this.nbiCity.Caption = "City";
            this.nbiCity.LargeImage = ((System.Drawing.Image)(resources.GetObject("nbiCity.LargeImage")));
            this.nbiCity.Name = "nbiCity";
            this.nbiCity.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiCity_LinkClicked);
            // 
            // navBarSeparatorItem1
            // 
            this.navBarSeparatorItem1.CanDrag = false;
            this.navBarSeparatorItem1.Enabled = false;
            this.navBarSeparatorItem1.Hint = null;
            this.navBarSeparatorItem1.LargeImageIndex = 0;
            this.navBarSeparatorItem1.LargeImageSize = new System.Drawing.Size(0, 0);
            this.navBarSeparatorItem1.Name = "navBarSeparatorItem1";
            this.navBarSeparatorItem1.SmallImageIndex = 0;
            this.navBarSeparatorItem1.SmallImageSize = new System.Drawing.Size(0, 0);
            // 
            // nbiBank
            // 
            this.nbiBank.Caption = "Bank";
            this.nbiBank.LargeImage = ((System.Drawing.Image)(resources.GetObject("nbiBank.LargeImage")));
            this.nbiBank.Name = "nbiBank";
            this.nbiBank.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiBank_LinkClicked);
            // 
            // nbiBankBranch
            // 
            this.nbiBankBranch.Caption = "Bank Branch";
            this.nbiBankBranch.LargeImage = ((System.Drawing.Image)(resources.GetObject("nbiBankBranch.LargeImage")));
            this.nbiBankBranch.Name = "nbiBankBranch";
            this.nbiBankBranch.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nbiBankBranch_LinkClicked);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.pbProfilePic);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1904, 66);
            this.panel2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Monotype Corsiva", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Tomato;
            this.label2.Location = new System.Drawing.Point(6, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(351, 57);
            this.label2.TabIndex = 2;
            this.label2.Text = "LISAG Mananger";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1454, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(380, 40);
            this.label1.TabIndex = 1;
            this.label1.Text = "Administrator";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pbProfilePic
            // 
            this.pbProfilePic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbProfilePic.Image = global::LISAGManager.Properties.Resources.User;
            this.pbProfilePic.Location = new System.Drawing.Point(1842, 3);
            this.pbProfilePic.Name = "pbProfilePic";
            this.pbProfilePic.Size = new System.Drawing.Size(60, 60);
            this.pbProfilePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbProfilePic.TabIndex = 0;
            this.pbProfilePic.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 1140);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1904, 18);
            this.panel3.TabIndex = 3;
            // 
            // FrmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1158);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.IsMdiContainer = true;
            this.Name = "FrmDashboard";
            this.Text = "LISAG - Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmDashboard_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProfilePic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup2;
        private System.Windows.Forms.Label label1;
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
    }
}