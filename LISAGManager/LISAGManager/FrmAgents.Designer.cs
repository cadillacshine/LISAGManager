namespace LISAGManager {
    partial class FrmAgents {
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPhoneNumber1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPhoneNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmailAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSurveyor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSurvLicenseNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.controlNavigator1 = new DevExpress.XtraEditors.ControlNavigator();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.searchControl1 = new DevExpress.XtraEditors.SearchControl();
            this.controlNavigator2 = new DevExpress.XtraEditors.ControlNavigator();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.gridControl1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.controlNavigator1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.statusStrip1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1064, 567);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gridControl1.Location = new System.Drawing.Point(2, 36);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemCheckEdit2});
            this.gridControl1.Size = new System.Drawing.Size(1060, 480);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9F);
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colPhoneNumber1,
            this.colPhoneNumber,
            this.colEmailAddress,
            this.colSurveyor,
            this.colSurvLicenseNo,
            this.colActive});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsFind.AllowFindPanel = false;
            this.gridView1.OptionsFind.ShowClearButton = false;
            this.gridView1.OptionsFind.ShowCloseButton = false;
            this.gridView1.OptionsFind.ShowFindButton = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colName
            // 
            this.colName.Caption = "Name";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 434;
            // 
            // colPhoneNumber1
            // 
            this.colPhoneNumber1.Caption = "Phone Number #1";
            this.colPhoneNumber1.FieldName = "PhoneNumber1";
            this.colPhoneNumber1.Name = "colPhoneNumber1";
            this.colPhoneNumber1.Visible = true;
            this.colPhoneNumber1.VisibleIndex = 1;
            this.colPhoneNumber1.Width = 242;
            // 
            // colPhoneNumber
            // 
            this.colPhoneNumber.Caption = "Phone Number #2";
            this.colPhoneNumber.FieldName = "PhoneNumber2";
            this.colPhoneNumber.Name = "colPhoneNumber";
            this.colPhoneNumber.Visible = true;
            this.colPhoneNumber.VisibleIndex = 2;
            this.colPhoneNumber.Width = 249;
            // 
            // colEmailAddress
            // 
            this.colEmailAddress.Caption = "Email Address";
            this.colEmailAddress.FieldName = "EmailAddress";
            this.colEmailAddress.Name = "colEmailAddress";
            this.colEmailAddress.Visible = true;
            this.colEmailAddress.VisibleIndex = 3;
            this.colEmailAddress.Width = 235;
            // 
            // colSurveyor
            // 
            this.colSurveyor.Caption = "Lic. Surveyor";
            this.colSurveyor.FieldName = "SurveyorName";
            this.colSurveyor.Name = "colSurveyor";
            this.colSurveyor.Visible = true;
            this.colSurveyor.VisibleIndex = 4;
            this.colSurveyor.Width = 200;
            // 
            // colSurvLicenseNo
            // 
            this.colSurvLicenseNo.Caption = "Lic. Surv. License Number";
            this.colSurvLicenseNo.FieldName = "LicenseNumber";
            this.colSurvLicenseNo.Name = "colSurvLicenseNo";
            this.colSurvLicenseNo.Visible = true;
            this.colSurvLicenseNo.VisibleIndex = 5;
            this.colSurvLicenseNo.Width = 289;
            // 
            // colActive
            // 
            this.colActive.Caption = "Active";
            this.colActive.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colActive.FieldName = "Active";
            this.colActive.Name = "colActive";
            this.colActive.Visible = true;
            this.colActive.VisibleIndex = 6;
            this.colActive.Width = 50;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // controlNavigator1
            // 
            this.controlNavigator1.Buttons.Append.Visible = false;
            this.controlNavigator1.Buttons.CancelEdit.Visible = false;
            this.controlNavigator1.Buttons.Edit.Visible = false;
            this.controlNavigator1.Buttons.EndEdit.Visible = false;
            this.controlNavigator1.Buttons.NextPage.Visible = false;
            this.controlNavigator1.Buttons.Prev.Enabled = false;
            this.controlNavigator1.Buttons.PrevPage.Visible = false;
            this.controlNavigator1.Buttons.Remove.Enabled = false;
            this.controlNavigator1.Buttons.Remove.Visible = false;
            this.controlNavigator1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.controlNavigator1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlNavigator1.Location = new System.Drawing.Point(2, 520);
            this.controlNavigator1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.controlNavigator1.Name = "controlNavigator1";
            this.controlNavigator1.NavigatableControl = this.gridControl1;
            this.controlNavigator1.Size = new System.Drawing.Size(1060, 25);
            this.controlNavigator1.TabIndex = 2;
            this.controlNavigator1.Text = "controlNavigator1";
            this.controlNavigator1.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.Center;
            this.controlNavigator1.TextStringFormat = "{0} of {1}";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 547);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1064, 20);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(35, 15);
            this.toolStripStatusLabel1.Text = "Done";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.45614F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.54386F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel2.Controls.Add(this.searchControl1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.controlNavigator2, 3, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1058, 28);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // searchControl1
            // 
            this.searchControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchControl1.Location = new System.Drawing.Point(12, 3);
            this.searchControl1.Name = "searchControl1";
            this.searchControl1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchControl1.Properties.Appearance.Options.UseFont = true;
            this.searchControl1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.searchControl1.Size = new System.Drawing.Size(424, 22);
            this.searchControl1.TabIndex = 0;
            // 
            // controlNavigator2
            // 
            this.controlNavigator2.Buttons.Append.Visible = false;
            this.controlNavigator2.Buttons.CancelEdit.Visible = false;
            this.controlNavigator2.Buttons.Edit.Visible = false;
            this.controlNavigator2.Buttons.EndEdit.Visible = false;
            this.controlNavigator2.Buttons.First.Visible = false;
            this.controlNavigator2.Buttons.Last.Visible = false;
            this.controlNavigator2.Buttons.Next.Visible = false;
            this.controlNavigator2.Buttons.NextPage.Visible = false;
            this.controlNavigator2.Buttons.Prev.Visible = false;
            this.controlNavigator2.Buttons.PrevPage.Visible = false;
            this.controlNavigator2.Buttons.Remove.Visible = false;
            this.controlNavigator2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.controlNavigator2.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(12)});
            this.controlNavigator2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlNavigator2.Location = new System.Drawing.Point(1026, 3);
            this.controlNavigator2.Name = "controlNavigator2";
            this.controlNavigator2.Size = new System.Drawing.Size(29, 22);
            this.controlNavigator2.TabIndex = 1;
            this.controlNavigator2.Text = "controlNavigator2";
            this.controlNavigator2.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.controlNavigator2_ButtonClick);
            // 
            // FrmAgents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 567);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FrmAgents";
            this.Text = "LISAG - All Agents";
            this.Load += new System.EventHandler(this.FrmAgents_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.searchControl1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colPhoneNumber1;
        private DevExpress.XtraGrid.Columns.GridColumn colPhoneNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colEmailAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colSurveyor;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn colActive;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.ControlNavigator controlNavigator1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevExpress.XtraEditors.SearchControl searchControl1;
        private DevExpress.XtraEditors.ControlNavigator controlNavigator2;
        private DevExpress.XtraGrid.Columns.GridColumn colSurvLicenseNo;
    }
}