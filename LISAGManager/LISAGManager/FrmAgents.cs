using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LISAGManager {
    public partial class FrmAgents : Form {

        private string sqlquery = "SELECT Name, AgentNumber, PhoneNumber1, PhoneNumber2, EmailAddress, SurveyorName, LicenseNumber, Active FROM vwAgent";
        private string tableOrView = "vwAgent";

        public FrmAgents() {
            InitializeComponent();
        }

        private void FrmAgents_Load(object sender, EventArgs e) {
            gridControl1.DataSource = Misc.loadDataSource(sqlquery, "vwAgent");

            controlNavigator2.Buttons.ImageList = sharedImageCollection1;
            controlNavigator2.Buttons.CustomButtons[0].ImageIndex = 5;
        }

        private void controlNavigator2_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e) {
           // try {
                if (e.Button.Tag.ToString() == "Refresh") {
                    toolStripStatusLabel1.Text = "Refreshing...";
                    gridControl1.DataSource = Misc.loadDataSource(sqlquery, tableOrView);
                    toolStripStatusLabel1.Text = "Done";
                }
            //} catch {

                
            //}
        }

        private void gridControl1_Click(object sender, EventArgs e) {

        }

        private void setControlValues() {
            string licenseNumber = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "LicenseNumber").ToString();
            string agentNumber = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "AgentNumber").ToString();
            label1.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Name").ToString() + "\n-\n" + agentNumber;
            label2.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SurveyorName").ToString() + "\n-\n" + licenseNumber;
            pictureBox2.Image = Misc.loadImage(licenseNumber);
            pictureBox1.Image = Misc.loadAgentImage(agentNumber);
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            setControlValues();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e) {

        }
    }
}
