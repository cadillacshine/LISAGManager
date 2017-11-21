using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;

namespace LISAGManager {
    public partial class FrmCity: Form {

        NavigatorCustomButton BtnAdd, BtnEdit, BtnSave, BtnCancel, BtnSwitch, BtnRefresh;
        private string actionState = "a";
        private string sqlQuery = "SELECT Name, ShortName, Region, Active FROM vwCity ORDER BY Name";
        private string tableOrView = "vwCity";
        int cityID = 0;

        public FrmCity() {
            InitializeComponent();
        }

        private void FrmCity_Load(object sender, EventArgs e) {
            loadForm();
        }
        private void controlNavigator1_ButtonClick(object sender, NavigatorButtonClickEventArgs e) {
           // try {

                SqlCommand sqlcmd = new SqlCommand();
                int regionID = 0;

                if (e.Button.Tag.ToString() == "Add") {
                    toolStripStatusLabel1.Text = "Adding...";
                    if (tableLayoutPanel1.RowStyles[2].Height == 1)
                        tableLayoutPanel1.RowStyles[2].Height = 80;
                    actionState = "a";
                    setControlState(true);
                    emptyControls();
                    txtCity.Focus();

                    BtnAdd.Enabled = false;
                    BtnEdit.Enabled = false;
                    BtnSave.Enabled = true;
                    BtnCancel.Enabled = true;
                    BtnSwitch.Enabled = false;
                    BtnRefresh.Enabled = false;

                    controlNavigator1.Buttons.First.Enabled = false;
                    controlNavigator1.Buttons.Next.Enabled = false;
                    controlNavigator1.Buttons.Prev.Enabled = false;
                    controlNavigator1.Buttons.Last.Enabled = false;

                    searchControl1.Enabled = false;
                    gridControl1.Enabled = false;

                } else if (e.Button.Tag.ToString() == "Edit") {

                    sqlcmd = new SqlCommand("SELECT CityID FROM vwCity WHERE city = '" + txtCity.Text + "' AND Region = '" + cmbRegion.Text + "' ", Misc.getConn());
                    Misc.connOpen();
                    cityID = (int)sqlcmd.ExecuteScalar();

                    if (tableLayoutPanel1.RowStyles[2].Height == 1)
                        tableLayoutPanel1.RowStyles[2].Height = 104;
                    actionState = "e";
                    setControlState(true);

                    txtCity.Focus();
                    BtnAdd.Enabled = false;
                    BtnEdit.Enabled = false;
                    BtnSave.Enabled = true;
                    BtnCancel.Enabled = true;
                    BtnSwitch.Enabled = false;
                    BtnRefresh.Enabled = false;

                    controlNavigator1.Buttons.First.Enabled = false;
                    controlNavigator1.Buttons.Next.Enabled = false;
                    controlNavigator1.Buttons.Prev.Enabled = false;
                    controlNavigator1.Buttons.Last.Enabled = false;

                    searchControl1.Enabled = false;
                    gridControl1.Enabled = false;
                } else if (e.Button.Tag.ToString() == "Save") {

                    sqlcmd = new SqlCommand("SELECT RegionID FROM Region WHERE Name = '" + cmbRegion.Text + "' ", Misc.getConn());
                        Misc.connOpen();
                        regionID = (int)sqlcmd.ExecuteScalar();
                    if (actionState == "e") {
                        toolStripStatusLabel1.Text = "Editing...";

                        


                        sqlcmd = new SqlCommand("UPDATE City SET Name = @Name, ShortName = @ShortName, RegionID = @RegionID, Active = @Active WHERE CityID = '" + cityID + "' ", Misc.getConn());

                    } else if (actionState == "a") {
                        toolStripStatusLabel1.Text = "Saving...";

                        verifyInput();

                        sqlcmd = new SqlCommand("INSERT INTO City (Name, ShortName, RegionID, Active) VALUES (@Name, @ShortName, @RegionID, @Active)", Misc.getConn());
                    }

                    sqlcmd.Parameters.AddWithValue("@Name", txtCity.Text);
                    sqlcmd.Parameters.AddWithValue("@ShortName", txtShortName.Text);
                    sqlcmd.Parameters.AddWithValue("@RegionID", regionID);
                    sqlcmd.Parameters.AddWithValue("@Active", cbActive.Checked);

                    Misc.connOpen();
                    sqlcmd.ExecuteNonQuery();
                    sqlcmd.Dispose();

                    actionState = "a";

                    gridControl1.DataSource = Misc.loadDataSource(sqlQuery, tableOrView);
                    setControlState(false);
                    BtnSave.Enabled = false;
                    BtnEdit.Enabled = true;
                    BtnAdd.Enabled = true;
                    BtnCancel.Enabled = false;
                    BtnSwitch.Enabled = true;
                    BtnRefresh.Enabled = true;

                    controlNavigator1.Buttons.First.Enabled = true;
                    controlNavigator1.Buttons.Next.Enabled = true;
                    controlNavigator1.Buttons.Prev.Enabled = true;
                    controlNavigator1.Buttons.Last.Enabled = true;

                    searchControl1.Enabled = true;
                    gridControl1.Enabled = true;
                    toolStripStatusLabel1.Text = "Saved";

                } else if (e.Button.Tag.ToString() == "Cancel") {
                    setControlState(false);
                    actionState = "a";
                    BtnAdd.Enabled = true;
                    BtnEdit.Enabled = true;
                    BtnSave.Enabled = false;
                    BtnCancel.Enabled = false;
                    BtnSwitch.Enabled = true;
                    BtnRefresh.Enabled = true;

                    controlNavigator1.Buttons.First.Enabled = true;
                    controlNavigator1.Buttons.Next.Enabled = true;
                    controlNavigator1.Buttons.Prev.Enabled = true;
                    controlNavigator1.Buttons.Last.Enabled = true;

                    searchControl1.Enabled = true;
                    gridControl1.Enabled = true;

                    toolStripStatusLabel1.Text = "Done";

                } else if (e.Button.Tag.ToString() == "Refresh") {
                    toolStripStatusLabel1.Text = "Refreshing...";
                    gridControl1.DataSource = Misc.loadDataSource(sqlQuery, tableOrView);
                    toolStripStatusLabel1.Text = "Done";

                } else if (e.Button.Tag.ToString() == "Switch") {
                    if (tableLayoutPanel1.RowStyles[2].Height == 104) {
                        tableLayoutPanel1.RowStyles[2].Height = 1;
                    } else {
                        tableLayoutPanel1.RowStyles[2].Height = 104;
                    }
                }
            //} catch {

            //}
        }
        private void loadForm() {

            gridControl1.DataSource = Misc.loadDataSource(sqlQuery, tableOrView);
            cmbRegion.DataSource = Misc.loadDataSource("SELECT Name FROM Region WHERE Active = 'True' ORDER BY Name", "Region");
            cmbRegion.ValueMember = "Name";

            BtnAdd = controlNavigator1.Buttons.CustomButtons[0];
            BtnEdit = controlNavigator1.Buttons.CustomButtons[1];
            BtnSave = controlNavigator1.Buttons.CustomButtons[2];
            BtnCancel = controlNavigator1.Buttons.CustomButtons[3];
            BtnSwitch = controlNavigator1.Buttons.CustomButtons[4];
            BtnRefresh = controlNavigator1.Buttons.CustomButtons[5];

            BtnAdd.Enabled = true;
            BtnEdit.Enabled = true;
            BtnSave.Enabled = false;
            BtnCancel.Enabled = false;
            BtnSwitch.Enabled = true;
            BtnRefresh.Enabled = true;

            setControlState(false);
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            setControlValues();
            selectionChanged();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e) {
            setControlValues();
            selectionChanged();
        }

        private void txtCity_TextChanged(object sender, EventArgs e) {
            txtShortName.Text = txtCity.Text;
        }

        private void setControlState(bool status) {
            // enable/disable all other controls
            cmbRegion.Enabled = status;
            txtCity.Enabled = status;
            txtShortName.Enabled = status;
            cbActive.Enabled = status;
        }

        private void emptyControls() {
            // clear all controls
            cmbRegion.SelectedIndex = -1;
            txtCity.Text = "";
            txtShortName.Text = "";
            cbActive.Checked = true;
        }

        private void selectionChanged() {
            setControlState(false);

            BtnAdd = controlNavigator1.Buttons.CustomButtons[0];
            BtnEdit = controlNavigator1.Buttons.CustomButtons[1];
            BtnSave = controlNavigator1.Buttons.CustomButtons[2];
            BtnCancel = controlNavigator1.Buttons.CustomButtons[3];
            BtnSwitch = controlNavigator1.Buttons.CustomButtons[4];
            BtnRefresh = controlNavigator1.Buttons.CustomButtons[5];

            BtnAdd.Enabled = true;
            BtnEdit.Enabled = true;
            BtnSave.Enabled = false;
            BtnCancel.Enabled = false;
            BtnSwitch.Enabled = true;
            BtnRefresh.Enabled = true;
        }

        private void setControlValues() {
            cmbRegion.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Region").ToString();
            txtCity.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Name").ToString();
            txtShortName.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ShortName").ToString();
            cbActive.Checked = (bool)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Active");
        }

        private void verifyInput() {
            if (cmbRegion.SelectedIndex == -1) {
                MessageBox.Show("Region cannot be empty!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbRegion.Focus();
                return;
            }

            if (txtCity.Text == "") {
                MessageBox.Show("City cannot be empty!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCity.Focus();
                return;
            }
        }
    }
}
