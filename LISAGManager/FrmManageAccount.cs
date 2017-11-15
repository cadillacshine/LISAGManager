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
    public partial class FrmManageAccount: Form {

        NavigatorCustomButton BtnAdd, BtnEdit, BtnSave, BtnCancel, BtnSwitch, BtnRefresh;
        NavigatorCustomButton BtnCIAdd, BtnCIEdit, BtnCISave, BtnCICancel, BtnCISwitch, BtnCIRefresh;
        private string actionState = "a";
        private string sqlQuery = "SELECT Name, Gender, DateOfBirth, MaritalStatus, Hometown, LicenseNumber, InductionYear, GoodStanding, Active FROM vwMember ORDER BY Name";
        AppUser appUser = new AppUser();
        SqlCommand sqlcmd = new SqlCommand();

        public FrmManageAccount() {
            InitializeComponent();
        }

        private void FrmManageAccount_Load(object sender, EventArgs e) {
            loadForm();

        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e) {
            if (xtraTabControl1.SelectedTabPage.Text == "Personal Information") {
                searchControl1.Text = "";
            } else if (xtraTabControl1.SelectedTabPage.Text == "Contact Information") {
                searchControlCI.Text = "";
                loadContactInformation();
                sqlQuery = "SELECT Name, LicenseNumber, PhoneNumber1, PhoneNumber2, EmailAddress FROM vwMember ORDER BY Name";
                gridControlCI.DataSource = Misc.loadDataSource(sqlQuery, "vwMember");

            } else if (xtraTabControl1.SelectedTabPage.Text == "Kin Details") {
                searchControl3.Text = "";
            } else if (xtraTabControl1.SelectedTabPage.Text == "Location") {
                searchControl4.Text = "";
            } else if (xtraTabControl1.SelectedTabPage.Text == "Bank Details") {
                searchControl5.Text = "";
            } else if (xtraTabControl1.SelectedTabPage.Text == "Account Details") {
                searchControl6.Text = "";
            } else if (xtraTabControl1.SelectedTabPage.Text == "Access Rights") {
                searchControl7.Text = "";
            }
        }

        private void loadForm() {
            // set default values
            gridControl1.DataSource = Misc.loadDataSource(sqlQuery, "vwMember");
            cmbGender.SelectedIndex = -1;
            cmbMaritalStatus.SelectedIndex = -1;
            deDOB.DateTime = new DateTime(1900, 01, 01);

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
            btnPic.Enabled = true;

            setTabState(true);
            setControlState(false);
        }

        private void controlNavigator1_ButtonClick(object sender, NavigatorButtonClickEventArgs e) {
            //try {

          
            if (e.Button.Tag.ToString() == "Add") {
                toolStripStatusLabel1.Text = "Adding...";
                if (tableLayoutPanel2.RowStyles[2].Height == 1)
                    tableLayoutPanel2.RowStyles[2].Height = 143;
                actionState = "a";
                setTabState(false);
                setControlState(true);
                emptyControls();
                txtFirstName.Focus();

                BtnAdd.Enabled = false;
                BtnEdit.Enabled = false;
                BtnSave.Enabled = true;
                BtnCancel.Enabled = true;
                BtnSwitch.Enabled = false;
                BtnRefresh.Enabled = false;
                btnPic.Enabled = true;

                controlNavigator1.Buttons.First.Enabled = false;
                controlNavigator1.Buttons.Next.Enabled = false;
                controlNavigator1.Buttons.Prev.Enabled = false;
                controlNavigator1.Buttons.Last.Enabled = false;

                searchControl1.Enabled = false;
                gridControl1.Enabled = false;

            } else if (e.Button.Tag.ToString() == "Edit") {
                if (tableLayoutPanel2.RowStyles[2].Height == 1)
                    tableLayoutPanel2.RowStyles[2].Height = 143;
                actionState = "e";
                setControlState(true);

                txtFirstName.Focus();
                BtnAdd.Enabled = false;
                BtnEdit.Enabled = false;
                BtnSave.Enabled = true;
                BtnCancel.Enabled = true;
                BtnSwitch.Enabled = false;
                BtnRefresh.Enabled = false;
                btnPic.Enabled = true;

                controlNavigator1.Buttons.First.Enabled = false;
                controlNavigator1.Buttons.Next.Enabled = false;
                controlNavigator1.Buttons.Prev.Enabled = false;
                controlNavigator1.Buttons.Last.Enabled = false;

                searchControl1.Enabled = false;
                gridControl1.Enabled = false;
            } else if (e.Button.Tag.ToString() == "Save") {

                if (actionState == "e") {
                    toolStripStatusLabel1.Text = "Editing...";
                    sqlcmd = new SqlCommand("SELECT MemberID FROM vwMember WHERE LicenseNumber = '" + txtLicenseNo.Text + "' ", Misc.getConn());
                    Misc.connOpen();
                    string memberID = sqlcmd.ExecuteScalar().ToString();

                    sqlcmd = new SqlCommand("UPDATE Member SET FirstName = @FirstName, MiddleName = @MiddleName, LastName = @LastName, Gender = @Gender, DateOfBirth = @DateOfBirth, MaritalStatus = @MaritalStatus, Hometown = @Hometown, LicenseNumber = @LicenseNumber, InductionYear = @InductionYear, GoodStanding = @GoodStanding, Active = @Active WHERE MemberID = '" + memberID + "' ", Misc.getConn());

                } else if (actionState == "a") {
                    toolStripStatusLabel1.Text = "Saving...";

                    if (!verifyInput()) return;

                    sqlcmd = new SqlCommand("INSERT INTO Member (FirstName, MiddleName, LastName, Gender, DateOfBirth, MaritalStatus, Hometown, KinName, KinContact, LicenseNumber, PhoneNumber1, PhoneNumber2, EmailAddress, CityID, BusinessAddress, ResidentialAddress, LISAGBankID, InductionYear, GoodStanding, Active) VALUES (@FirstName, @MiddleName, @LastName, @Gender, @DateOfBirth, @MaritalStatus, @Hometown, @KinName, @KinContact, @LicenseNumber, @PhoneNumber1, @PhoneNumber2, @EmailAddress, @CityID, @BusinessAddress, @ResidentialAddress, @LISAGBankID, @InductionYear, @GoodStanding, @Active)", Misc.getConn());
                }

                sqlcmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                sqlcmd.Parameters.AddWithValue("@MiddleName", txtMiddleName.Text);
                sqlcmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                sqlcmd.Parameters.AddWithValue("@Gender", cmbGender.Text);
                sqlcmd.Parameters.AddWithValue("@DateOfBirth", deDOB.DateTime);
                sqlcmd.Parameters.AddWithValue("@MaritalStatus", cmbMaritalStatus.Text);
                sqlcmd.Parameters.AddWithValue("@Hometown", txtHometown.Text);
                sqlcmd.Parameters.AddWithValue("@KinName", "Unassigned");
                sqlcmd.Parameters.AddWithValue("@KinContact", "Unassigned");
                sqlcmd.Parameters.AddWithValue("@LicenseNumber", txtLicenseNo.Text);
                sqlcmd.Parameters.AddWithValue("@PhoneNumber1", "Unassigned");
                sqlcmd.Parameters.AddWithValue("@PhoneNumber2", "Unassigned");
                sqlcmd.Parameters.AddWithValue("@EmailAddress", "Unassigned");
                sqlcmd.Parameters.AddWithValue("@CityID", 5);
                sqlcmd.Parameters.AddWithValue("@BusinessAddress", "Unassigned");
                sqlcmd.Parameters.AddWithValue("@ResidentialAddress", "Unassigned");
                sqlcmd.Parameters.AddWithValue("@LISAGBankID", 1);
                sqlcmd.Parameters.AddWithValue("@InductionYear", txtInductionYear.Text);
                sqlcmd.Parameters.AddWithValue("@GoodStanding", cbGoodStanding.Checked);
                sqlcmd.Parameters.AddWithValue("@Active", cbActive.Checked);

                Misc.connOpen();
                sqlcmd.ExecuteNonQuery();
                sqlcmd.Dispose();

                actionState = "a";

                gridControl1.DataSource = Misc.loadDataSource(sqlQuery, "vwMember");
                setControlState(false);
                BtnSave.Enabled = false;
                BtnEdit.Enabled = true;
                BtnAdd.Enabled = true;
                BtnCancel.Enabled = false;
                BtnSwitch.Enabled = true;
                BtnRefresh.Enabled = true;
                btnPic.Enabled = false;

                controlNavigator1.Buttons.First.Enabled = true;
                controlNavigator1.Buttons.Next.Enabled = true;
                controlNavigator1.Buttons.Prev.Enabled = true;
                controlNavigator1.Buttons.Last.Enabled = true;

                searchControl1.Enabled = true;
                gridControl1.Enabled = true;
                setTabState(true);
                toolStripStatusLabel1.Text = "Saved";

                appUser.firstName = txtFirstName.Text;
                appUser.middleName = txtMiddleName.Text;
                appUser.lastName = txtLastName.Text;
                appUser.licenseNumber = txtLicenseNo.Text;

            } else if (e.Button.Tag.ToString() == "Cancel") {
                setControlState(false);
                actionState = "a";
                BtnAdd.Enabled = true;
                BtnEdit.Enabled = true;
                BtnSave.Enabled = false;
                BtnCancel.Enabled = false;
                BtnSwitch.Enabled = true;
                BtnRefresh.Enabled = true;
                btnPic.Enabled = false;

                controlNavigator1.Buttons.First.Enabled = true;
                controlNavigator1.Buttons.Next.Enabled = true;
                controlNavigator1.Buttons.Prev.Enabled = true;
                controlNavigator1.Buttons.Last.Enabled = true;

                searchControl1.Enabled = true;
                gridControl1.Enabled = true;

                toolStripStatusLabel1.Text = "Done";

            } else if (e.Button.Tag.ToString() == "Refresh") {
                toolStripStatusLabel1.Text = "Refreshing...";
                gridControl1.DataSource = Misc.loadDataSource(sqlQuery, "vwMember");
                toolStripStatusLabel1.Text = "Done";

            } else if (e.Button.Tag.ToString() == "Switch") {
                if (tableLayoutPanel2.RowStyles[2].Height == 143) {
                    tableLayoutPanel2.RowStyles[2].Height = 1;
                } else {
                    tableLayoutPanel2.RowStyles[2].Height = 143;
                }
            }
            //} catch {

            //}
        }

        private void setTabState(bool status) {
            // enable/disable tab page selection
            //xtraTabControl1.TabPages[0].PageEnabled = status;
            xtraTabControl1.TabPages[1].PageEnabled = status;
            xtraTabControl1.TabPages[2].PageEnabled = status;
            xtraTabControl1.TabPages[3].PageEnabled = status;
            xtraTabControl1.TabPages[4].PageEnabled = status;
            xtraTabControl1.TabPages[5].PageEnabled = status;
            xtraTabControl1.TabPages[6].PageEnabled = status;
        }

        private void SetTabStateWithIndex(bool status, int index) {
            xtraTabControl1.TabPages[0].PageEnabled = status;
            xtraTabControl1.TabPages[1].PageEnabled = status;
            xtraTabControl1.TabPages[2].PageEnabled = status;
            xtraTabControl1.TabPages[3].PageEnabled = status;
            xtraTabControl1.TabPages[4].PageEnabled = status;
            xtraTabControl1.TabPages[5].PageEnabled = status;
            xtraTabControl1.TabPages[6].PageEnabled = status;
        }

        private void setControlState(bool status) {
            // enable/disable all other controls
            txtFirstName.Enabled = status;
            txtMiddleName.Enabled = status;
            txtLastName.Enabled = status;
            cmbGender.Enabled = status;
            deDOB.Enabled = status;
            cmbMaritalStatus.Enabled = status;
            txtHometown.Enabled = status;
            txtLicenseNo.Enabled = status;
            txtInductionYear.Enabled = status;
            cbGoodStanding.Enabled = status;
            cbActive.Enabled = status;
            btnPic.Enabled = status;
        }

        private void gridViewCI_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            selectionChangedCI();
            setControlValuesCI();
        }

        private void gridViewCI_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e) {
            try {
                selectionChangedCI();
                setControlValuesCI();
            } catch {

            }
        }

        private void setControlStateCI(bool status) {
            // enable/disable all other controls
            //txtCIFirstName.Enabled = status;
            //txtCIMiddleName.Enabled = status;
            //txtCILastName.Enabled = status;
            txtCIPhoneNumber1.Enabled = status;
            txtCIPhoneNumber2.Enabled = status;
            txtCIEmailAddress.Enabled = status;
            btnPic.Enabled = status;
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e) {
            selectionChanged();
            setControlValues();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            try {
                selectionChanged();
                setControlValues();
            } catch {

            }
            
        }

        private void controlNavigatorCI_ButtonClick(object sender, NavigatorButtonClickEventArgs e) {
            //try {

            if (e.Button.Tag.ToString() == "Edit") {
                if (tableLayoutPanel8.RowStyles[2].Height == 1)
                    tableLayoutPanel8.RowStyles[2].Height = 146;
                actionState = "e";
                setControlStateCI(true);

                xtraTabControl1.TabPages[0].PageEnabled = false;
                xtraTabControl1.TabPages[1].PageEnabled = true;
                xtraTabControl1.TabPages[2].PageEnabled = false;
                xtraTabControl1.TabPages[3].PageEnabled = false;
                xtraTabControl1.TabPages[4].PageEnabled = false;
                xtraTabControl1.TabPages[5].PageEnabled = false;
                xtraTabControl1.TabPages[6].PageEnabled = false;

                txtCIPhoneNumber1.Focus();
                BtnCIEdit.Enabled = false;
                BtnCISave.Enabled = true;
                BtnCICancel.Enabled = true;
                BtnCISwitch.Enabled = false;
                BtnCIRefresh.Enabled = false;
                btnPic.Enabled = true;

                controlNavigatorCI.Buttons.First.Enabled = false;
                controlNavigatorCI.Buttons.Next.Enabled = false;
                controlNavigatorCI.Buttons.Prev.Enabled = false;
                controlNavigatorCI.Buttons.Last.Enabled = false;

                searchControlCI.Enabled = false;
                gridControlCI.Enabled = false;
            } else if (e.Button.Tag.ToString() == "Save") {

                if (actionState == "e") {
                    toolStripStatusLabelCI.Text = "Editing...";
                    sqlcmd = new SqlCommand("SELECT MemberID FROM vwMember WHERE LicenseNumber = '" + txtCILicenseNumber.Text + "' ", Misc.getConn());
                    Misc.connOpen();
                    int memberID = (int)sqlcmd.ExecuteScalar();

                    sqlcmd = new SqlCommand("UPDATE Member SET PhoneNumber1 = @PhoneNumber1, PhoneNumber2 = @PhoneNumber2, EmailAddress = @EmailAddress WHERE MemberID = '" + memberID + "' ", Misc.getConn());
                }

                sqlcmd.Parameters.AddWithValue("@PhoneNumber1", txtCIPhoneNumber1.Text);
                sqlcmd.Parameters.AddWithValue("@PhoneNumber2", txtCIPhoneNumber2.Text);
                sqlcmd.Parameters.AddWithValue("@EmailAddress", txtCIEmailAddress.Text);

                Misc.connOpen();
                sqlcmd.ExecuteNonQuery();
                sqlcmd.Dispose();

                actionState = "a";

                gridControl1.DataSource = Misc.loadDataSource(sqlQuery, "vwMember");
                setControlState(false);
                BtnCISave.Enabled = false;
                BtnCIEdit.Enabled = true;
                BtnCIAdd.Enabled = true;
                BtnCICancel.Enabled = false;
                BtnCISwitch.Enabled = true;
                BtnCIRefresh.Enabled = true;
                btnPic.Enabled = false;

                controlNavigatorCI.Buttons.First.Enabled = true;
                controlNavigatorCI.Buttons.Next.Enabled = true;
                controlNavigatorCI.Buttons.Prev.Enabled = true;
                controlNavigatorCI.Buttons.Last.Enabled = true;

                searchControlCI.Enabled = true;
                gridControlCI.Enabled = true;
                setTabState(true);
                gridControlCI.DataSource = Misc.loadDataSource(sqlQuery, "vwMember");
                toolStripStatusLabelCI.Text = "Saved";

            } else if (e.Button.Tag.ToString() == "Cancel") {
                setControlStateCI(false);
                actionState = "a";
                BtnCIAdd.Enabled = true;
                BtnCIEdit.Enabled = true;
                BtnCISave.Enabled = false;
                BtnCICancel.Enabled = false;
                BtnCISwitch.Enabled = true;
                BtnCIRefresh.Enabled = true;
                btnPic.Enabled = false;

                controlNavigatorCI.Buttons.First.Enabled = true;
                controlNavigatorCI.Buttons.Next.Enabled = true;
                controlNavigatorCI.Buttons.Prev.Enabled = true;
                controlNavigatorCI.Buttons.Last.Enabled = true;

                searchControlCI.Enabled = true;
                gridControlCI.Enabled = true;
                setTabState(true);

                toolStripStatusLabelCI.Text = "Done";

            } else if (e.Button.Tag.ToString() == "Refresh") {
                toolStripStatusLabelCI.Text = "Refreshing...";
                gridControlCI.DataSource = Misc.loadDataSource(sqlQuery, "vwMember");
                toolStripStatusLabelCI.Text = "Done";

            } else if (e.Button.Tag.ToString() == "Switch") {
                if (tableLayoutPanel8.RowStyles[2].Height == 146) {
                    tableLayoutPanel8.RowStyles[2].Height = 1;
                } else {
                    tableLayoutPanel8.RowStyles[2].Height = 146;
                }
            }
            //} catch {

            //}
        }

        private void emptyControls() {
            // clear all controls
            txtFirstName.Text = "";
            txtMiddleName.Text = "";
            txtLastName.Text = "";
            cmbGender.SelectedIndex = -1;
            deDOB.DateTime = new DateTime(1900, 01, 01);
            cmbMaritalStatus.SelectedIndex = -1;
            txtHometown.Text = "";
            txtLicenseNo.Text = "";
            txtInductionYear.Text = "";
            cbGoodStanding.Checked = true;
            cbActive.Checked = true;
        }

        private void selectionChanged() {
            setTabState(true);
            setControlState(false);

            BtnAdd.Enabled = true;
            BtnEdit.Enabled = true;
            BtnSave.Enabled = false;
            BtnCancel.Enabled = false;
            BtnSwitch.Enabled = true;
            BtnRefresh.Enabled = true;
            btnPic.Enabled = true;
        }

        private void selectionChangedCI() {
            setTabState(true);
            setControlStateCI(false);

            BtnCIAdd.Enabled = false;
            BtnCIEdit.Enabled = true;
            BtnCISave.Enabled = false;
            BtnCICancel.Enabled = false;
            BtnCISwitch.Enabled = true;
            BtnCIRefresh.Enabled = true;
            btnPic.Enabled = true;
        }

        private void setControlValues() {
            string firstName = "";
            string middleName = "";
            string lastName = "";
            string licenseNumber = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "LicenseNumber").ToString();
            sqlcmd = new SqlCommand("SELECT FirstName, MiddleName, LastName FROM Member WHERE LicenseNumber = '" + licenseNumber + "' ", Misc.getConn());
            SqlDataReader dReader = sqlcmd.ExecuteReader();
            Misc.connOpen();
            while (dReader.Read()) {
                firstName = dReader.GetString(0);
                middleName = dReader.GetString(1);
                lastName = dReader.GetString(2);
            }
            dReader.Close();

            txtFirstName.Text = firstName;
            txtMiddleName.Text = middleName;
            txtLastName.Text = lastName;

            txtLicenseNo.Text = licenseNumber;
            cmbGender.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Gender").ToString();
            deDOB.DateTime = (DateTime)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DateOfBirth");
            cmbMaritalStatus.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaritalStatus").ToString();
            txtHometown.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Hometown").ToString();
            txtInductionYear.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "InductionYear").ToString();
            cbGoodStanding.Checked = (bool)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "GoodStanding");
            cbActive.Checked = (bool)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Active");
        }

        private void setControlValuesCI() {
            string firstName = "";
            string middleName = "";
            string lastName = "";
            string licenseNumber = gridViewCI.GetRowCellValue(gridViewCI.FocusedRowHandle, "LicenseNumber").ToString();
            sqlcmd = new SqlCommand("SELECT FirstName, MiddleName, LastName FROM Member WHERE LicenseNumber = '" + licenseNumber + "' ", Misc.getConn());
            SqlDataReader dReader = sqlcmd.ExecuteReader();
            Misc.connOpen();
            while (dReader.Read()) {
                firstName = dReader.GetString(0);
                middleName = dReader.GetString(1);
                lastName = dReader.GetString(2);
            }
            dReader.Close();

            txtCIFirstName.Text = firstName;
            txtCIMiddleName.Text = middleName;
            txtCILastName.Text = lastName;

            txtCIFirstName.Text = firstName;
            txtCIMiddleName.Text = middleName;
            txtCILastName.Text = lastName;
            txtCILicenseNumber.Text = licenseNumber;
            txtCIPhoneNumber1.Text = gridViewCI.GetRowCellValue(gridViewCI.FocusedRowHandle, "PhoneNumber1").ToString();
            txtCIPhoneNumber2.Text = gridViewCI.GetRowCellValue(gridViewCI.FocusedRowHandle, "PhoneNumber2").ToString();
            txtCIEmailAddress.Text = gridViewCI.GetRowCellValue(gridViewCI.FocusedRowHandle, "EmailAddress").ToString();
        }

        private void loadContactInformation() {
            BtnCIAdd = controlNavigatorCI.Buttons.CustomButtons[0];
            BtnCIEdit = controlNavigatorCI.Buttons.CustomButtons[1];
            BtnCISave = controlNavigatorCI.Buttons.CustomButtons[2];
            BtnCICancel = controlNavigatorCI.Buttons.CustomButtons[3];
            BtnCISwitch = controlNavigatorCI.Buttons.CustomButtons[4];
            BtnCIRefresh = controlNavigatorCI.Buttons.CustomButtons[5];

            BtnCIAdd.Enabled = false;
            BtnCIEdit.Enabled = true;
            BtnCISave.Enabled = false;
            BtnCICancel.Enabled = false;
            BtnCISwitch.Enabled = true;
            BtnCIRefresh.Enabled = true;
            btnPic.Enabled = true;
        }

        private bool verifyInput() {
            if (txtFirstName.Text == "") {
                MessageBox.Show("First name cannot be empty", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFirstName.Focus();
                return false;
            }


            if (txtLastName.Text == "") {
                MessageBox.Show("Last name cannot be empty", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLastName.Focus();
                return false;
            }

            if (cmbGender.SelectedIndex == -1) {
                MessageBox.Show("Gender cannot be empty", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbGender.Focus();
                return false;
            }

            if (deDOB.DateTime == new DateTime(1900, 01, 01)) {
                MessageBox.Show("You're not that old", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                deDOB.Focus();
                return false;
            }

            if (cmbMaritalStatus.SelectedIndex == -1) {
                MessageBox.Show("Marital Status cannot be empty", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbMaritalStatus.Focus();
                return false;
            }

            if (txtHometown.Text == "") {
                MessageBox.Show("Hometown cannot be empty", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHometown.Focus();
                return false;
            }

            if (txtLicenseNo.Text == "") {
                MessageBox.Show("License Number cannot be empty!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLicenseNo.Focus();
                return false;
            }

            if (txtInductionYear.Text == "") {
                MessageBox.Show("Induction Year cannot be empty", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtInductionYear.Focus();
                return false;
            }

            int inductionYear = 0;
            if (Int32.TryParse(txtInductionYear.Text, out inductionYear)) {
                txtInductionYear.Text = inductionYear.ToString();
            } else {
                MessageBox.Show("Induction Year incorrect", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtInductionYear.Text = 0.ToString();
                txtInductionYear.Focus();
                return false;
            }
            return true;

        }

    }

}
