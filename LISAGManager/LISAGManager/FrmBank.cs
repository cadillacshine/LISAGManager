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
    public partial class FrmBank: Form {

        NavigatorCustomButton BtnAdd, BtnEdit, BtnSave, BtnCancel, BtnSwitch, BtnRefresh;
        private string actionState = "a";
        private string sqlQuery = "SELECT Name, ShortName, Active FROM Bank ORDER BY Name";
        private string tableOrView = "Bank";
        int bankID = 0;

        public FrmBank() {
            InitializeComponent();
        }

        private void FrmBank_Load(object sender, EventArgs e) {
            loadForm();

            controlNavigator1.Buttons.ImageList = sharedImageCollection1;
            controlNavigator1.Buttons.CustomButtons[0].ImageIndex = 0;
            controlNavigator1.Buttons.CustomButtons[1].ImageIndex = 1;
            controlNavigator1.Buttons.CustomButtons[2].ImageIndex = 2;
            controlNavigator1.Buttons.CustomButtons[3].ImageIndex = 3;
            controlNavigator1.Buttons.CustomButtons[4].ImageIndex = 4;
            controlNavigator1.Buttons.CustomButtons[5].ImageIndex = 5;
        }

        private void loadForm() {

            gridControl1.DataSource = Misc.loadDataSource(sqlQuery, tableOrView);

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

        private void controlNavigator1_ButtonClick(object sender, NavigatorButtonClickEventArgs e) {
            try {

                SqlCommand sqlcmd = new SqlCommand();

                if (e.Button.Tag.ToString() == "Add") {
                    toolStripStatusLabel1.Text = "Adding...";
                    if (tableLayoutPanel1.RowStyles[2].Height == 1)
                        tableLayoutPanel1.RowStyles[2].Height = 80;
                    actionState = "a";
                    setControlState(true);
                    emptyControls();
                    txtBank.Focus();

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

                    sqlcmd = new SqlCommand("SELECT BankID FROM Bank WHERE Name = '" + txtBank.Text + "' ", Misc.getConn());
                    Misc.connOpen();
                    bankID = (int)sqlcmd.ExecuteScalar();

                    if (tableLayoutPanel1.RowStyles[2].Height == 1)
                        tableLayoutPanel1.RowStyles[2].Height = 80;
                    actionState = "e";
                    setControlState(true);

                    txtBank.Focus();
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

                    if (actionState == "e") {
                        toolStripStatusLabel1.Text = "Editing...";

                        sqlcmd = new SqlCommand("UPDATE Bank SET Name = @Name, ShortName = @ShortName, Active = @Active WHERE BankID = '" + bankID + "' ", Misc.getConn());

                    } else if (actionState == "a") {
                        toolStripStatusLabel1.Text = "Saving...";

                        verifyInput();

                        sqlcmd = new SqlCommand("INSERT INTO Bank (Name, ShortName, Active) VALUES (@Name, @ShortName, @Active)", Misc.getConn());
                    }

                    sqlcmd.Parameters.AddWithValue("@Name", txtBank.Text);
                    sqlcmd.Parameters.AddWithValue("@ShortName", txtShortName.Text);
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
                    if (tableLayoutPanel1.RowStyles[2].Height == 80) {
                        tableLayoutPanel1.RowStyles[2].Height = 1;
                    } else {
                        tableLayoutPanel1.RowStyles[2].Height = 80;
                    }
                }
            } catch {

            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            setControlValues();
            selectionChanged();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e) {
            setControlValues();
            selectionChanged();
        }

        private void txtBank_TextChanged(object sender, EventArgs e) {
            txtShortName.Text = txtBank.Text;
        }

        private void setControlState(bool status) {
            // enable/disable all other controls
            txtBank.Enabled = status;
            txtShortName.Enabled = status;
            cbActive.Enabled = status;
        }

        private void emptyControls() {
            // clear all controls
            txtBank.Text = "";
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
            try {
                txtBank.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Name").ToString();
                txtShortName.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ShortName").ToString();
                cbActive.Checked = (bool)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Active");
            } catch {

            }
        }

        private void verifyInput() {
            if (txtBank.Text == "") {
                MessageBox.Show("Bank Name cannot be empty!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBank.Focus();
                return;
            }
        }
    }
}
