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
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProfilePic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.navBarControl1);
            this.panel1.Name = "panel1";
            // 
            // navBarControl1
            // 
            resources.ApplyResources(this.navBarControl1, "navBarControl1");
            this.navBarControl1.ActiveGroup = this.navBarGroup4;
            this.navBarControl1.Appearance.Background.BackColor = ((System.Drawing.Color)(resources.GetObject("navBarControl1.Appearance.Background.BackColor")));
            this.navBarControl1.Appearance.Background.Font = ((System.Drawing.Font)(resources.GetObject("navBarControl1.Appearance.Background.Font")));
            this.navBarControl1.Appearance.Background.FontSizeDelta = ((int)(resources.GetObject("navBarControl1.Appearance.Background.FontSizeDelta")));
            this.navBarControl1.Appearance.Background.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("navBarControl1.Appearance.Background.FontStyleDelta")));
            this.navBarControl1.Appearance.Background.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("navBarControl1.Appearance.Background.GradientMode")));
            this.navBarControl1.Appearance.Background.Image = ((System.Drawing.Image)(resources.GetObject("navBarControl1.Appearance.Background.Image")));
            this.navBarControl1.Appearance.Background.Options.UseBackColor = true;
            this.navBarControl1.Appearance.Background.Options.UseFont = true;
            this.navBarControl1.BackColor = System.Drawing.Color.Green;
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
            this.navBarControl1.OptionsNavPane.CollapsedWidth = ((int)(resources.GetObject("resource.CollapsedWidth")));
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
            this.navBarSeparatorItem3.Appearance.FontSizeDelta = ((int)(resources.GetObject("navBarSeparatorItem3.Appearance.FontSizeDelta")));
            this.navBarSeparatorItem3.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("navBarSeparatorItem3.Appearance.FontStyleDelta")));
            this.navBarSeparatorItem3.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("navBarSeparatorItem3.Appearance.GradientMode")));
            this.navBarSeparatorItem3.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("navBarSeparatorItem3.Appearance.Image")));
            this.navBarSeparatorItem3.AppearanceDisabled.FontSizeDelta = ((int)(resources.GetObject("navBarSeparatorItem3.AppearanceDisabled.FontSizeDelta")));
            this.navBarSeparatorItem3.AppearanceDisabled.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("navBarSeparatorItem3.AppearanceDisabled.FontStyleDelta")));
            this.navBarSeparatorItem3.AppearanceDisabled.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("navBarSeparatorItem3.AppearanceDisabled.GradientMode")));
            this.navBarSeparatorItem3.AppearanceDisabled.Image = ((System.Drawing.Image)(resources.GetObject("navBarSeparatorItem3.AppearanceDisabled.Image")));
            this.navBarSeparatorItem3.AppearanceHotTracked.FontSizeDelta = ((int)(resources.GetObject("navBarSeparatorItem3.AppearanceHotTracked.FontSizeDelta")));
            this.navBarSeparatorItem3.AppearanceHotTracked.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("navBarSeparatorItem3.AppearanceHotTracked.FontStyleDelta")));
            this.navBarSeparatorItem3.AppearanceHotTracked.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("navBarSeparatorItem3.AppearanceHotTracked.GradientMode")));
            this.navBarSeparatorItem3.AppearanceHotTracked.Image = ((System.Drawing.Image)(resources.GetObject("navBarSeparatorItem3.AppearanceHotTracked.Image")));
            this.navBarSeparatorItem3.AppearancePressed.FontSizeDelta = ((int)(resources.GetObject("navBarSeparatorItem3.AppearancePressed.FontSizeDelta")));
            this.navBarSeparatorItem3.AppearancePressed.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("navBarSeparatorItem3.AppearancePressed.FontStyleDelta")));
            this.navBarSeparatorItem3.AppearancePressed.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("navBarSeparatorItem3.AppearancePressed.GradientMode")));
            this.navBarSeparatorItem3.AppearancePressed.Image = ((System.Drawing.Image)(resources.GetObject("navBarSeparatorItem3.AppearancePressed.Image")));
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
            this.navBarSeparatorItem2.Appearance.FontSizeDelta = ((int)(resources.GetObject("navBarSeparatorItem2.Appearance.FontSizeDelta")));
            this.navBarSeparatorItem2.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("navBarSeparatorItem2.Appearance.FontStyleDelta")));
            this.navBarSeparatorItem2.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("navBarSeparatorItem2.Appearance.GradientMode")));
            this.navBarSeparatorItem2.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("navBarSeparatorItem2.Appearance.Image")));
            this.navBarSeparatorItem2.AppearanceDisabled.FontSizeDelta = ((int)(resources.GetObject("navBarSeparatorItem2.AppearanceDisabled.FontSizeDelta")));
            this.navBarSeparatorItem2.AppearanceDisabled.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("navBarSeparatorItem2.AppearanceDisabled.FontStyleDelta")));
            this.navBarSeparatorItem2.AppearanceDisabled.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("navBarSeparatorItem2.AppearanceDisabled.GradientMode")));
            this.navBarSeparatorItem2.AppearanceDisabled.Image = ((System.Drawing.Image)(resources.GetObject("navBarSeparatorItem2.AppearanceDisabled.Image")));
            this.navBarSeparatorItem2.AppearanceHotTracked.FontSizeDelta = ((int)(resources.GetObject("navBarSeparatorItem2.AppearanceHotTracked.FontSizeDelta")));
            this.navBarSeparatorItem2.AppearanceHotTracked.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("navBarSeparatorItem2.AppearanceHotTracked.FontStyleDelta")));
            this.navBarSeparatorItem2.AppearanceHotTracked.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("navBarSeparatorItem2.AppearanceHotTracked.GradientMode")));
            this.navBarSeparatorItem2.AppearanceHotTracked.Image = ((System.Drawing.Image)(resources.GetObject("navBarSeparatorItem2.AppearanceHotTracked.Image")));
            this.navBarSeparatorItem2.AppearancePressed.FontSizeDelta = ((int)(resources.GetObject("navBarSeparatorItem2.AppearancePressed.FontSizeDelta")));
            this.navBarSeparatorItem2.AppearancePressed.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("navBarSeparatorItem2.AppearancePressed.FontStyleDelta")));
            this.navBarSeparatorItem2.AppearancePressed.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("navBarSeparatorItem2.AppearancePressed.GradientMode")));
            this.navBarSeparatorItem2.AppearancePressed.Image = ((System.Drawing.Image)(resources.GetObject("navBarSeparatorItem2.AppearancePressed.Image")));
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
            this.navBarSeparatorItem4.Appearance.FontSizeDelta = ((int)(resources.GetObject("navBarSeparatorItem4.Appearance.FontSizeDelta")));
            this.navBarSeparatorItem4.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("navBarSeparatorItem4.Appearance.FontStyleDelta")));
            this.navBarSeparatorItem4.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("navBarSeparatorItem4.Appearance.GradientMode")));
            this.navBarSeparatorItem4.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("navBarSeparatorItem4.Appearance.Image")));
            this.navBarSeparatorItem4.AppearanceDisabled.FontSizeDelta = ((int)(resources.GetObject("navBarSeparatorItem4.AppearanceDisabled.FontSizeDelta")));
            this.navBarSeparatorItem4.AppearanceDisabled.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("navBarSeparatorItem4.AppearanceDisabled.FontStyleDelta")));
            this.navBarSeparatorItem4.AppearanceDisabled.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("navBarSeparatorItem4.AppearanceDisabled.GradientMode")));
            this.navBarSeparatorItem4.AppearanceDisabled.Image = ((System.Drawing.Image)(resources.GetObject("navBarSeparatorItem4.AppearanceDisabled.Image")));
            this.navBarSeparatorItem4.AppearanceHotTracked.FontSizeDelta = ((int)(resources.GetObject("navBarSeparatorItem4.AppearanceHotTracked.FontSizeDelta")));
            this.navBarSeparatorItem4.AppearanceHotTracked.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("navBarSeparatorItem4.AppearanceHotTracked.FontStyleDelta")));
            this.navBarSeparatorItem4.AppearanceHotTracked.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("navBarSeparatorItem4.AppearanceHotTracked.GradientMode")));
            this.navBarSeparatorItem4.AppearanceHotTracked.Image = ((System.Drawing.Image)(resources.GetObject("navBarSeparatorItem4.AppearanceHotTracked.Image")));
            this.navBarSeparatorItem4.AppearancePressed.FontSizeDelta = ((int)(resources.GetObject("navBarSeparatorItem4.AppearancePressed.FontSizeDelta")));
            this.navBarSeparatorItem4.AppearancePressed.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("navBarSeparatorItem4.AppearancePressed.FontStyleDelta")));
            this.navBarSeparatorItem4.AppearancePressed.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("navBarSeparatorItem4.AppearancePressed.GradientMode")));
            this.navBarSeparatorItem4.AppearancePressed.Image = ((System.Drawing.Image)(resources.GetObject("navBarSeparatorItem4.AppearancePressed.Image")));
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
            this.navBarSeparatorItem5.Appearance.FontSizeDelta = ((int)(resources.GetObject("navBarSeparatorItem5.Appearance.FontSizeDelta")));
            this.navBarSeparatorItem5.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("navBarSeparatorItem5.Appearance.FontStyleDelta")));
            this.navBarSeparatorItem5.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("navBarSeparatorItem5.Appearance.GradientMode")));
            this.navBarSeparatorItem5.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("navBarSeparatorItem5.Appearance.Image")));
            this.navBarSeparatorItem5.AppearanceDisabled.FontSizeDelta = ((int)(resources.GetObject("navBarSeparatorItem5.AppearanceDisabled.FontSizeDelta")));
            this.navBarSeparatorItem5.AppearanceDisabled.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("navBarSeparatorItem5.AppearanceDisabled.FontStyleDelta")));
            this.navBarSeparatorItem5.AppearanceDisabled.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("navBarSeparatorItem5.AppearanceDisabled.GradientMode")));
            this.navBarSeparatorItem5.AppearanceDisabled.Image = ((System.Drawing.Image)(resources.GetObject("navBarSeparatorItem5.AppearanceDisabled.Image")));
            this.navBarSeparatorItem5.AppearanceHotTracked.FontSizeDelta = ((int)(resources.GetObject("navBarSeparatorItem5.AppearanceHotTracked.FontSizeDelta")));
            this.navBarSeparatorItem5.AppearanceHotTracked.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("navBarSeparatorItem5.AppearanceHotTracked.FontStyleDelta")));
            this.navBarSeparatorItem5.AppearanceHotTracked.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("navBarSeparatorItem5.AppearanceHotTracked.GradientMode")));
            this.navBarSeparatorItem5.AppearanceHotTracked.Image = ((System.Drawing.Image)(resources.GetObject("navBarSeparatorItem5.AppearanceHotTracked.Image")));
            this.navBarSeparatorItem5.AppearancePressed.FontSizeDelta = ((int)(resources.GetObject("navBarSeparatorItem5.AppearancePressed.FontSizeDelta")));
            this.navBarSeparatorItem5.AppearancePressed.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("navBarSeparatorItem5.AppearancePressed.FontStyleDelta")));
            this.navBarSeparatorItem5.AppearancePressed.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("navBarSeparatorItem5.AppearancePressed.GradientMode")));
            this.navBarSeparatorItem5.AppearancePressed.Image = ((System.Drawing.Image)(resources.GetObject("navBarSeparatorItem5.AppearancePressed.Image")));
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
            this.navBarSeparatorItem6.Appearance.FontSizeDelta = ((int)(resources.GetObject("navBarSeparatorItem6.Appearance.FontSizeDelta")));
            this.navBarSeparatorItem6.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("navBarSeparatorItem6.Appearance.FontStyleDelta")));
            this.navBarSeparatorItem6.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("navBarSeparatorItem6.Appearance.GradientMode")));
            this.navBarSeparatorItem6.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("navBarSeparatorItem6.Appearance.Image")));
            this.navBarSeparatorItem6.AppearanceDisabled.FontSizeDelta = ((int)(resources.GetObject("navBarSeparatorItem6.AppearanceDisabled.FontSizeDelta")));
            this.navBarSeparatorItem6.AppearanceDisabled.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("navBarSeparatorItem6.AppearanceDisabled.FontStyleDelta")));
            this.navBarSeparatorItem6.AppearanceDisabled.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("navBarSeparatorItem6.AppearanceDisabled.GradientMode")));
            this.navBarSeparatorItem6.AppearanceDisabled.Image = ((System.Drawing.Image)(resources.GetObject("navBarSeparatorItem6.AppearanceDisabled.Image")));
            this.navBarSeparatorItem6.AppearanceHotTracked.FontSizeDelta = ((int)(resources.GetObject("navBarSeparatorItem6.AppearanceHotTracked.FontSizeDelta")));
            this.navBarSeparatorItem6.AppearanceHotTracked.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("navBarSeparatorItem6.AppearanceHotTracked.FontStyleDelta")));
            this.navBarSeparatorItem6.AppearanceHotTracked.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("navBarSeparatorItem6.AppearanceHotTracked.GradientMode")));
            this.navBarSeparatorItem6.AppearanceHotTracked.Image = ((System.Drawing.Image)(resources.GetObject("navBarSeparatorItem6.AppearanceHotTracked.Image")));
            this.navBarSeparatorItem6.AppearancePressed.FontSizeDelta = ((int)(resources.GetObject("navBarSeparatorItem6.AppearancePressed.FontSizeDelta")));
            this.navBarSeparatorItem6.AppearancePressed.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("navBarSeparatorItem6.AppearancePressed.FontStyleDelta")));
            this.navBarSeparatorItem6.AppearancePressed.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("navBarSeparatorItem6.AppearancePressed.GradientMode")));
            this.navBarSeparatorItem6.AppearancePressed.Image = ((System.Drawing.Image)(resources.GetObject("navBarSeparatorItem6.AppearancePressed.Image")));
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
            this.navBarSeparatorItem1.Appearance.FontSizeDelta = ((int)(resources.GetObject("navBarSeparatorItem1.Appearance.FontSizeDelta")));
            this.navBarSeparatorItem1.Appearance.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("navBarSeparatorItem1.Appearance.FontStyleDelta")));
            this.navBarSeparatorItem1.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("navBarSeparatorItem1.Appearance.GradientMode")));
            this.navBarSeparatorItem1.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("navBarSeparatorItem1.Appearance.Image")));
            this.navBarSeparatorItem1.AppearanceDisabled.FontSizeDelta = ((int)(resources.GetObject("navBarSeparatorItem1.AppearanceDisabled.FontSizeDelta")));
            this.navBarSeparatorItem1.AppearanceDisabled.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("navBarSeparatorItem1.AppearanceDisabled.FontStyleDelta")));
            this.navBarSeparatorItem1.AppearanceDisabled.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("navBarSeparatorItem1.AppearanceDisabled.GradientMode")));
            this.navBarSeparatorItem1.AppearanceDisabled.Image = ((System.Drawing.Image)(resources.GetObject("navBarSeparatorItem1.AppearanceDisabled.Image")));
            this.navBarSeparatorItem1.AppearanceHotTracked.FontSizeDelta = ((int)(resources.GetObject("navBarSeparatorItem1.AppearanceHotTracked.FontSizeDelta")));
            this.navBarSeparatorItem1.AppearanceHotTracked.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("navBarSeparatorItem1.AppearanceHotTracked.FontStyleDelta")));
            this.navBarSeparatorItem1.AppearanceHotTracked.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("navBarSeparatorItem1.AppearanceHotTracked.GradientMode")));
            this.navBarSeparatorItem1.AppearanceHotTracked.Image = ((System.Drawing.Image)(resources.GetObject("navBarSeparatorItem1.AppearanceHotTracked.Image")));
            this.navBarSeparatorItem1.AppearancePressed.FontSizeDelta = ((int)(resources.GetObject("navBarSeparatorItem1.AppearancePressed.FontSizeDelta")));
            this.navBarSeparatorItem1.AppearancePressed.FontStyleDelta = ((System.Drawing.FontStyle)(resources.GetObject("navBarSeparatorItem1.AppearancePressed.FontStyleDelta")));
            this.navBarSeparatorItem1.AppearancePressed.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("navBarSeparatorItem1.AppearancePressed.GradientMode")));
            this.navBarSeparatorItem1.AppearancePressed.Image = ((System.Drawing.Image)(resources.GetObject("navBarSeparatorItem1.AppearancePressed.Image")));
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
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.BackColor = System.Drawing.Color.DarkGreen;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.lblUsername);
            this.panel2.Controls.Add(this.pbProfilePic);
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
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.BackColor = System.Drawing.Color.DarkGreen;
            this.panel3.Name = "panel3";
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
    }
}