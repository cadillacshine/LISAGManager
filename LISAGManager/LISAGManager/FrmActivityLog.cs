using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LISAGManager {
    public partial class FrmActivityLog: Form {
        public FrmActivityLog() {
            InitializeComponent();
        }

        private void FrmActivityLog_Load(object sender, EventArgs e) {
            controlNavigator1.Buttons.ImageList = sharedImageCollection1;
            controlNavigator1.Buttons.CustomButtons[0].ImageIndex = 5;

            gridControl1.DataSource = Misc.loadDataSource("SELECT Username, Activity, ActivityTime FROM vwActivityLog ORDER BY ActivityTime DESC", "vwActivityLog");
        }

        private void controlNavigator1_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e) {
            try {
                if (e.Button.Tag.ToString() == "Refresh") {
                    toolStripStatusLabel1.Text = "Refreshing...";
                    searchControl1.Text = "";
                    gridControl1.DataSource = Misc.loadDataSource("SELECT Username, Activity, ActivityTime FROM vwActivityLog ORDER BY ActivityTime DESC", "vwActivityLog");
                    toolStripStatusLabel1.Text = "Done";
                }
            } catch {

            }
        }
    }
}
