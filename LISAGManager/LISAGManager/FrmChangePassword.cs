using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LISAGManager {
    public partial class FrmChangePassword: Form {

        NavigatorCustomButton BtnAdd, BtnEdit, BtnSave, BtnCancel, BtnSwitch, BtnRefresh;
        string actionState = "a";
        string sqlQuery = "SELECT Username FROM UserAccount WHERE Active = 'True' ORDER BY Username";
        string tableOrView = "UserAccount";
        int userID = 0;

        public FrmChangePassword() {
            InitializeComponent();
        }

        private void controlNavigator1_ButtonClick(object sender, NavigatorButtonClickEventArgs e) {
             try {

            SqlCommand sqlcmd = new SqlCommand();

            if (e.Button.Tag.ToString() == "Edit") {

                sqlcmd = new SqlCommand("SELECT MemberID FROM UserAccount WHERE Username = '" + Misc.getUser().username + "' ", Misc.getConn());
                Misc.connOpen();
                userID = (int)sqlcmd.ExecuteScalar();

                actionState = "e";
                setControlState(true);

                txtPassword.Focus();
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

            } else if (e.Button.Tag.ToString() == "Save") {

                verifyInput();

                if (actionState == "e") {
                    toolStripStatusLabel1.Text = "Editing...";

                    sqlcmd = new SqlCommand("UPDATE UserAccount SET Password = @Password WHERE MemberID = '" + userID + "' ", Misc.getConn());
                }

                sqlcmd.Parameters.AddWithValue("@Password", txtPassword.Text);      

                Misc.connOpen();
                sqlcmd.ExecuteNonQuery();
                sqlcmd.Dispose();

                actionState = "a";

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

                toolStripStatusLabel1.Text = "Done";

            } else if (e.Button.Tag.ToString() == "Refresh") {
                toolStripStatusLabel1.Text = "Refreshing...";
                cmbUsername.DataSource = Misc.loadDataSource(sqlQuery, tableOrView);
                toolStripStatusLabel1.Text = "Done";
            }
            } catch {

            }
        }

        private void FrmChangePassword_Load(object sender, EventArgs e) {
            loadForm();
            setControlValues();

            controlNavigator1.Buttons.ImageList = sharedImageCollection1;
            controlNavigator1.Buttons.CustomButtons[0].ImageIndex = 1;
            controlNavigator1.Buttons.CustomButtons[1].ImageIndex = 2;
            controlNavigator1.Buttons.CustomButtons[2].ImageIndex = 3;
        }

        private void loadForm() {
            cmbUsername.DataSource = Misc.loadDataSource(sqlQuery, tableOrView);
            cmbUsername.DisplayMember = "Username";

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

        private void setControlValues() {
            cmbUsername.Text = Misc.getUser().username;
        }

        private void verifyInput() {
            if (txtPassword.Text == "") {
                MessageBox.Show("Password cannot be empty!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return;
            }

            if (txtConfirmPassword.Text == "") {
                MessageBox.Show("Confirm Password cannot be empty!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return;
            }

            if (txtPassword.Text != txtConfirmPassword.Text) {
                MessageBox.Show("Password do not match!", "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return;
            }
        }

        private void setControlState(bool status) {
            cmbUsername.Enabled = false;
            txtPassword.Enabled = status;
            txtConfirmPassword.Enabled = status;
        }
    }
}
