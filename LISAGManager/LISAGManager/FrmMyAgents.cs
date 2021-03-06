﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LISAGManager {
    public partial class FrmMyAgents : Form {

        private string sqlquery = "SELECT Name, AgentNumber, PhoneNumber1, PhoneNumber2, EmailAddress, Active FROM vwAgent WHERE licenseNumber = " + Misc.getUser().licenseNumber;
        private string tableOrView = "vwAgent";

        public FrmMyAgents() {
            InitializeComponent();
        }

        private void FrmMyAgents_Load(object sender, EventArgs e) {
            gridControl1.DataSource = Misc.loadDataSource(sqlquery, "vwAgent");

            controlNavigator2.Buttons.ImageList = sharedImageCollection1;
            controlNavigator2.Buttons.CustomButtons[0].ImageIndex = 5;
        }

        private void controlNavigator2_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e) {
            try { 
            if (e.Button.Tag.ToString() == "Refresh") {
                toolStripStatusLabel1.Text = "Refreshing...";
                gridControl1.DataSource = Misc.loadDataSource(sqlquery, tableOrView);
                toolStripStatusLabel1.Text = "Done";
            }
            } catch {

            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            setControlValues();
        }

        private void setControlValues() {
            string agentNumber = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "AgentNumber").ToString();
            pictureBox1.Image = Misc.loadAgentImage(agentNumber);
        }
    }
}
