using DevExpress.XtraEditors;
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
    public partial class FrmAgent: Form {

        NavigatorCustomButton BtnAdd, BtnEdit, BtnSave, BtnCancel, BtnSwitch, BtnRefresh;
        private string actionState = "a";
        private string sqlQuery = "SELECT Name, AgentNumber, SurveyorName, LicenseNumber, Active FROM vwAgent ORDER BY Name";
        private string tableOrView = "vwAgent";
        int myAgentID = 0;

        public FrmAgent() {
            InitializeComponent();
        }

        private void FrmAgent_Load(object sender, EventArgs e) {
            loadForm();
        }

        private void loadForm() {
            cmbSurveyor.DataSource = Misc.loadDataSource("SELECT Name FROM vwMember WHERE Active = 'True' ORDER BY Name", "vwMember");
            cmbSurveyor.DisplayMember = "Name";

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
            btnPicture.Enabled = false;

            setControlState(false);
        }

        private void controlNavigator1_ButtonClick(object sender, NavigatorButtonClickEventArgs e) {
            SqlCommand sqlcmd = new SqlCommand();
            int surveyorID = 0;

            if (e.Button.Tag.ToString() == "Add") {
                toolStripStatusLabel1.Text = "Adding...";
                if (tableLayoutPanel1.RowStyles[2].Height == 1)
                    tableLayoutPanel1.RowStyles[2].Height = 159;
                actionState = "a";
                setControlState(true);
                emptyControls();
                txtFirstName.Focus();

                pictureBox1.Image = Properties.Resources.User;

                BtnAdd.Enabled = false;
                BtnEdit.Enabled = false;
                BtnSave.Enabled = true;
                BtnCancel.Enabled = true;
                BtnSwitch.Enabled = false;
                BtnRefresh.Enabled = false;
                btnPicture.Enabled = true;

                controlNavigator1.Buttons.First.Enabled = false;
                controlNavigator1.Buttons.Next.Enabled = false;
                controlNavigator1.Buttons.Prev.Enabled = false;
                controlNavigator1.Buttons.Last.Enabled = false;

                searchControl1.Enabled = false;
                gridControl1.Enabled = false;

            } else if (e.Button.Tag.ToString() == "Edit") {

                // agentID has been set in setControlValues()

                if (tableLayoutPanel1.RowStyles[2].Height == 1)
                    tableLayoutPanel1.RowStyles[2].Height = 159;
                actionState = "e";
                setControlState(true);

                txtFirstName.Focus();
                BtnAdd.Enabled = false;
                BtnEdit.Enabled = false;
                BtnSave.Enabled = true;
                BtnCancel.Enabled = true;
                BtnSwitch.Enabled = false;
                BtnRefresh.Enabled = false;
                btnPicture.Enabled = true;

                controlNavigator1.Buttons.First.Enabled = false;
                controlNavigator1.Buttons.Next.Enabled = false;
                controlNavigator1.Buttons.Prev.Enabled = false;
                controlNavigator1.Buttons.Last.Enabled = false;

                searchControl1.Enabled = false;
                gridControl1.Enabled = false;
            } else if (e.Button.Tag.ToString() == "Save") {

                sqlcmd = new SqlCommand("SELECT MemberID FROM vwMember WHERE Name = '" + cmbSurveyor.Text + "' ", Misc.getConn());
                Misc.connOpen();
                surveyorID = (int)sqlcmd.ExecuteScalar();
                if (actionState == "e") {
                    toolStripStatusLabel1.Text = "Editing...";

                    string image = openFileDialog1.FileName;
                    Misc.updateAgentImage(myAgentID, image);

                    sqlcmd = new SqlCommand("UPDATE Agent SET FirstName = @FirstName, MiddleName = @MiddleName, LastName = @LastName, AgentNumber = @AgentNumber, PhoneNumber1 = @PhoneNumber1, PhoneNumber2 = @PhoneNumber2, EmailAddress = @EmailAddress, MemberID = @MemberID, Active = @Active WHERE AgentID = '" + myAgentID + "' ", Misc.getConn());

                    sqlcmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                    sqlcmd.Parameters.AddWithValue("@MiddleName", txtMiddleName.Text);
                    sqlcmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                    sqlcmd.Parameters.AddWithValue("@AgentNumber", txtAgentNumber.Text);
                    sqlcmd.Parameters.AddWithValue("@PhoneNumber1", txtPhoneNumber1.Text);
                    sqlcmd.Parameters.AddWithValue("@PhoneNumber2", txtPhoneNumber2.Text);
                    sqlcmd.Parameters.AddWithValue("@EmailAddress", txtEmailAddress.Text);
                    sqlcmd.Parameters.AddWithValue("@MemberID", surveyorID);
                    sqlcmd.Parameters.AddWithValue("@Active", cbActive.Checked);

                    Misc.connOpen();
                    sqlcmd.ExecuteNonQuery();
                    sqlcmd.Dispose();

                } else if (actionState == "a") {
                    toolStripStatusLabel1.Text = "Saving...";

                    verifyInput();

                    sqlcmd = new SqlCommand("INSERT INTO Agent (FirstName, MiddleName, LastName, AgentNumber, PhoneNumber1, PhoneNumber2, EmailAddress, MemberID, Active) VALUES (@FirstName, @MiddleName, @LastName, @AgentNumber, @PhoneNumber1, @PhoneNumber2, @EmailAddress, @MemberID, @Active)", Misc.getConn());

                    sqlcmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                    sqlcmd.Parameters.AddWithValue("@MiddleName", txtMiddleName.Text);
                    sqlcmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                    sqlcmd.Parameters.AddWithValue("@AgentNumber", txtAgentNumber.Text);
                    sqlcmd.Parameters.AddWithValue("@PhoneNumber1", txtPhoneNumber1.Text);
                    sqlcmd.Parameters.AddWithValue("@PhoneNumber2", txtPhoneNumber2.Text);
                    sqlcmd.Parameters.AddWithValue("@EmailAddress", txtEmailAddress.Text);
                    sqlcmd.Parameters.AddWithValue("@MemberID", surveyorID);
                    sqlcmd.Parameters.AddWithValue("@Active", cbActive.Checked);

                    Misc.connOpen();
                    sqlcmd.ExecuteNonQuery();
                    sqlcmd.Dispose();

                    sqlcmd = new SqlCommand("SELECT AgentID FROM Agent WHERE AgentNumber = '" + txtAgentNumber.Text + "' ", Misc.getConn());
                    Misc.connOpen();
                    myAgentID = (int)sqlcmd.ExecuteScalar();

                    Misc.connOpen();
                    string image = openFileDialog1.FileName;
                    Misc.saveAgentImage(myAgentID, image);
                }

                actionState = "a";

                gridControl1.DataSource = Misc.loadDataSource(sqlQuery, tableOrView);
                setControlState(false);
                BtnSave.Enabled = false;
                BtnEdit.Enabled = true;
                BtnAdd.Enabled = true;
                BtnCancel.Enabled = false;
                BtnSwitch.Enabled = true;
                BtnRefresh.Enabled = true;
                btnPicture.Enabled = false;

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
                btnPicture.Enabled = false;

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
                if (tableLayoutPanel1.RowStyles[2].Height == 159) {
                    tableLayoutPanel1.RowStyles[2].Height = 1;
                } else {
                    tableLayoutPanel1.RowStyles[2].Height = 159;
                }
            }
            //} catch {

            //}
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            setControlValues();
            selectionChanged();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e) {
            setControlValues();
            selectionChanged();
        }

        private void btnPicture_Click(object sender, EventArgs e) {
            openFileDialog1.Filter = "Image Files(*.jpeg;*.bmp;*.png;*.jpg)|*.jpeg;*.bmp;*.png;*.jpg";
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void setControlState(bool status) {
            // enable/disable all other controls
            cmbSurveyor.Enabled = status;
            txtFirstName.Enabled = status;
            txtMiddleName.Enabled = status;
            txtLastName.Enabled = status;
            txtPhoneNumber1.Enabled = status;
            txtPhoneNumber2.Enabled = status;
            txtEmailAddress.Enabled = status;
            txtAgentNumber.Enabled = status;
            cbActive.Enabled = status;
        }

        private void emptyControls() {
            // clear all controls
            cmbSurveyor.SelectedIndex = -1;
            txtFirstName.Text = "";
            txtMiddleName.Text = "";
            txtLastName.Text = "";
            txtPhoneNumber1.Text = "";
            txtPhoneNumber2.Text = "";
            txtEmailAddress.Text = "";
            txtAgentNumber.Text = "";
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
            btnPicture.Enabled = false;
        }

        private void setControlValues() {
            string name = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Name").ToString();
            cmbSurveyor.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SurveyorName").ToString();
            cbActive.Checked = (bool)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Active");
            string licenseNumber = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "LicenseNumber").ToString();
            

            SqlCommand sqlcmd = new SqlCommand("SELECT AgentID FROM vwAgent WHERE Name = '" + name + "' AND LicenseNumber = '" + licenseNumber + "' ", Misc.getConn());
            Misc.connOpen();
            myAgentID = (int)sqlcmd.ExecuteScalar();

            sqlcmd = new SqlCommand("SELECT FirstName, MiddleName, LastName, AgentNumber, PhoneNumber1, PhoneNumber2, EmailAddress FROM vwAgent WHERE AgentID = '" + myAgentID + "' ", Misc.getConn());
            Misc.connOpen();
            SqlDataReader dReader = sqlcmd.ExecuteReader();

            while (dReader.Read()) {
                txtFirstName.Text = dReader.GetString(0);
                txtMiddleName.Text = dReader.GetString(1);
                txtLastName.Text = dReader.GetString(2);
                txtAgentNumber.Text = dReader.GetString(3);
                txtPhoneNumber1.Text = dReader.GetString(4);
                txtPhoneNumber2.Text = dReader.GetString(5);
                txtEmailAddress.Text = dReader.GetString(6);
            }
            dReader.Close();
            pictureBox1.Image = Misc.loadAgentImage(txtAgentNumber.Text);
        }

        private void verifyInput() {
            if (cmbSurveyor.SelectedIndex == -1) {
                MessageBox.Show("Surveyor's Name cannot be empty!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbSurveyor.Focus();
                return;
            }

            if (txtFirstName.Text == "") {
                MessageBox.Show("First Name cannot be empty!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFirstName.Focus();
                return;
            }

            if (txtLastName.Text == "") {
                MessageBox.Show("Last Name cannot be empty!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLastName.Focus();
                return;
            }

            if (txtAgentNumber.Text == "") {
                MessageBox.Show("Agent number cannot be empty!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAgentNumber.Focus();
                return;
            }

            if (txtPhoneNumber1.Text == "") {
                MessageBox.Show("Phone Number cannot be empty!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPhoneNumber1.Focus();
                return;
            }

        }
    }
}
