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

        private string sqlquery = "SELECT Name, PhoneNumber1, PhoneNumber2, EmailAddress, SurveyorName, LicenseNumber, Active FROM vwAgent";
        private string tableOrView = "vwAgent";

        public FrmAgents() {
            InitializeComponent();
        }

        private void FrmAgents_Load(object sender, EventArgs e) {
            gridControl1.DataSource = Misc.loadDataSource(sqlquery, "vwAgent");
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

        private void gridControl1_Click(object sender, EventArgs e) {

        }
    }
}
