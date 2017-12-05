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
    public partial class FrmMe: Form {

        NavigatorCustomButton BtnAdd, BtnEdit, BtnSave, BtnCancel, BtnSwitch, BtnRefresh;
        string actionState = "a";
        string sqlQueryRegion = "SELECT Name FROM Region WHERE Active = 'True' ORDER BY Name";
        string sqlQueryBankName = "SELECT Name FROM Bank WHERE Active = 'True' ORDER BY Name";
        string regionTableOrView = "Region";
        string bankTableOrView = "Bank";
        int memberID = 0;

        public FrmMe() {
            InitializeComponent();
        }

        private void FrmMe_Load(object sender, EventArgs e) {
            loadForm();
            setControlValues();
            setControlState(false);

            controlNavigator1.Buttons.ImageList = sharedImageCollection1;
            controlNavigator1.Buttons.CustomButtons[1].ImageIndex = 1;
            controlNavigator1.Buttons.CustomButtons[2].ImageIndex = 2;
            controlNavigator1.Buttons.CustomButtons[3].ImageIndex = 3;
            controlNavigator1.Buttons.CustomButtons[5].ImageIndex = 5;
        }

        private void cmbRegion_SelectedIndexChanged(object sender, EventArgs e) {
            cmbCity.DataSource = Misc.loadDataSource("SELECT Name FROM vwCity WHERE Region = '" + cmbRegion.Text + "' AND Active = 'True'", "vwCity");
            cmbCity.DisplayMember = "Name";
        }

        private void cmbBankName_SelectedIndexChanged(object sender, EventArgs e) {
            cmbBankBranch.DataSource = Misc.loadDataSource("SELECT Name FROM vwBankBranch WHERE Bank = '" + cmbBankName.Text + "' AND Active = 'True'", "vwBankBranch");
            cmbBankBranch.DisplayMember = "Name";
        }

        private void controlNavigator1_ButtonClick(object sender, NavigatorButtonClickEventArgs e) {
            try {

                SqlCommand sqlcmd = new SqlCommand();

                if (e.Button.Tag.ToString() == "Edit") {

                    sqlcmd = new SqlCommand("SELECT MemberID FROM Member WHERE LicenseNumber = '" + txtLicenseNo.Text + "' ", Misc.getConn());
                    Misc.connOpen();
                    memberID = (int)sqlcmd.ExecuteScalar();

                    actionState = "e";
                    setControlState(true);

                    // these fields need to be disabled even on edit
                    txtFirstName.Enabled = false;
                    txtMiddleName.Enabled = false;
                    txtLastName.Enabled = false;
                    txtInductionYear.Enabled = false;
                    txtLicenseNo.Enabled = false;

                    txtFirstName.Focus();
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

                    sqlcmd = new SqlCommand("SELECT RegionID FROM Region WHERE Name = '" + cmbRegion.Text + "' ", Misc.getConn());
                    int regionID = (int)sqlcmd.ExecuteScalar();

                    sqlcmd = new SqlCommand("SELECT CityID FROM City WHERE RegionID = '" + regionID + "' ", Misc.getConn());
                    int cityID = (int)sqlcmd.ExecuteScalar();

                    sqlcmd = new SqlCommand("SELECT LISAGBankID FROM LISAGBank WHERE AccountName = '" + txtAccountName.Text + "' AND AccountNumber = '" + txtAccountNumber.Text + "' ", Misc.getConn());
                    int lisagBankID = (int)sqlcmd.ExecuteScalar();


                    if (actionState == "e") {
                        toolStripStatusLabel1.Text = "Editing...";

                        sqlcmd = new SqlCommand("UPDATE Member SET FirstName = @FirstName, MiddleName = @MiddleName, LastName = @LastName, InductionYear = @InductionYear, LicenseNumber = @LicenseNumber, PhoneNumber1 = @PhoneNumber1, PhoneNumber2 = @PhoneNumber2, EmailAddress = @EmailAddress, KinName = @KinName, KinContact = @KinContact, CityID = @CityID, BusinessAddress = @BusinessAddress, ResidentialAddress = @ResidentialAddress, LISAGBankID = @LISAGBankID WHERE MemberID = '" + memberID + "' ", Misc.getConn());
                    }

                    sqlcmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                    sqlcmd.Parameters.AddWithValue("@MiddleName", txtMiddleName.Text);
                    sqlcmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                    sqlcmd.Parameters.AddWithValue("@InductionYear", txtInductionYear.Text);
                    sqlcmd.Parameters.AddWithValue("@LicenseNumber", txtLicenseNo.Text);
                    sqlcmd.Parameters.AddWithValue("PhoneNumber1", txtPhoneNumber1.Text);
                    sqlcmd.Parameters.AddWithValue("@PhoneNumber2", txtPhoneNumber2.Text);
                    sqlcmd.Parameters.AddWithValue("@EmailAddress", txtEmailAddress.Text);
                    sqlcmd.Parameters.AddWithValue("@KinName", txtKinName.Text);
                    sqlcmd.Parameters.AddWithValue("@KinContact", txtKinContact.Text);
                    sqlcmd.Parameters.AddWithValue("@CityID", cityID);
                    sqlcmd.Parameters.AddWithValue("@BusinessAddress", txtBusinessAddress.Text);
                    sqlcmd.Parameters.AddWithValue("@ResidentialAddress", txtResidentialAddress.Text);
                    sqlcmd.Parameters.AddWithValue("@LISAGBankID", lisagBankID);

                    Misc.connOpen();
                    sqlcmd.ExecuteNonQuery();
                    sqlcmd.Dispose();

                    Misc.connOpen();
                    string imageName = openFileDialog1.FileName;

                    if (imageName.Equals("openFileDialog1")) {
                        Misc.updateImage(memberID, pictureBox1.Image);
                    } else {
                        Misc.updateImage(memberID, imageName);
                    }               

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

                    updateAppUser();
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
                    cmbRegion.DataSource = Misc.loadDataSource(sqlQueryRegion, regionTableOrView);
                    cmbBankName.DataSource = Misc.loadDataSource(sqlQueryBankName, bankTableOrView);
                    toolStripStatusLabel1.Text = "Done";
                }
            } catch {

            }
        }

        private void btnPicture_Click(object sender, EventArgs e) {
            openFileDialog1.Filter = "Image Files(*.jpeg;*.bmp;*.png;*.jpg)|*.jpeg;*.bmp;*.png;*.jpg";
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void loadForm() {
            cmbRegion.DataSource = Misc.loadDataSource(sqlQueryRegion, regionTableOrView);
            cmbRegion.DisplayMember = "Name";
            cmbBankName.DataSource = Misc.loadDataSource(sqlQueryBankName, bankTableOrView);
            cmbBankName.DisplayMember = "Name";

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

        private void setControlState(bool status) {
            txtFirstName.Enabled = status;
            txtMiddleName.Enabled = status;
            txtLastName.Enabled = status;
            txtInductionYear.Enabled = status;
            txtLicenseNo.Enabled = status;
            txtPhoneNumber1.Enabled = status;
            txtPhoneNumber2.Enabled = status;
            txtEmailAddress.Enabled = status;
            txtKinName.Enabled = status;
            txtKinContact.Enabled = status;
            cmbRegion.Enabled = status;
            cmbCity.Enabled = status;
            txtBusinessAddress.Enabled = status;
            txtResidentialAddress.Enabled = status;
            txtAccountName.Enabled = status;
            cmbBankBranch.Enabled = status;
            cmbBankName.Enabled = status;
            txtAccountName.Enabled = status;
            txtAccountNumber.Enabled = status;
            btnPicture.Enabled = status;
        }

        private void setControlValues() {
            txtFirstName.Text = Misc.getUser().firstName;
            txtMiddleName.Text = Misc.getUser().middleName;
            txtLastName.Text = Misc.getUser().lastName;
            txtInductionYear.Text = Misc.getUser().inductionYear.ToString();
            txtLicenseNo.Text = Misc.getUser().licenseNumber;
            txtPhoneNumber1.Text = Misc.getUser().phoneNumber1;
            txtPhoneNumber2.Text = Misc.getUser().phoneNumber2;
            txtEmailAddress.Text = Misc.getUser().emailAddress;
            txtKinName.Text = Misc.getUser().kinName;
            txtKinContact.Text = Misc.getUser().kinContact;
            cmbRegion.Text = Misc.getUser().region;
            cmbCity.Text = Misc.getUser().city;
            txtBusinessAddress.Text = Misc.getUser().businessAddress;
            txtResidentialAddress.Text = Misc.getUser().residentialAddress;
            txtAccountName.Text = Misc.getUser().accountName;
            cmbBankBranch.Text = Misc.getUser().bankBranch;
            cmbBankName.Text = Misc.getUser().bank;
            txtAccountNumber.Text = Misc.getUser().accountNumber;
            pictureBox1.Image = Misc.loadImage(Misc.getUser().appUserID);
        }

        private void verifyInput() {
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

            if (txtInductionYear.Text == "") {
                MessageBox.Show("Induction Year cannot be empty!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtInductionYear.Focus();
                return;
            }

            if (txtLicenseNo.Text == "") {
                MessageBox.Show("License Number cannot be empty!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLicenseNo.Focus();
                return;
            }

            if (txtPhoneNumber1.Text == "") {
                MessageBox.Show("Phone Number cannot be empty!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPhoneNumber1.Focus();
                return;
            }

            if (txtEmailAddress.Text == "") {
                MessageBox.Show("Email Address cannot be empty!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmailAddress.Focus();
                return;
            }

            if (txtKinName.Text == "") {
                MessageBox.Show("Kin Name cannot be empty!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtKinName.Focus();
                return;
            }

            if (txtKinContact.Text == "") {
                MessageBox.Show("Kin Contact cannot be empty!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtKinContact.Focus();
                return;
            }

            if (txtBusinessAddress.Text == "") {
                MessageBox.Show("Business Address cannot be empty!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBusinessAddress.Focus();
                return;
            }

            if (txtResidentialAddress.Text == "") {
                MessageBox.Show("Residential Address cannot be empty!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtResidentialAddress.Focus();
                return;
            }

            if (txtAccountName.Text == "") {
                MessageBox.Show("Account Name cannot be empty!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAccountName.Focus();
                return;
            }

            if (txtAccountNumber.Text == "") {
                MessageBox.Show("Account Number cannot be empty!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAccountNumber.Focus();
                return;
            }
        }

        private void updateAppUser() {
            AppUser user = Misc.getUser();
            user.firstName = txtFirstName.Text;
            user.middleName = txtMiddleName.Text;
            user.lastName = txtLastName.Text;
            user.licenseNumber = txtLicenseNo.Text;
            user.inductionYear = int.Parse(txtInductionYear.Text);
            user.phoneNumber1 = txtPhoneNumber1.Text;
            user.phoneNumber2 = txtPhoneNumber2.Text;
            user.emailAddress = txtEmailAddress.Text;
            user.kinName = txtKinName.Text;
            user.kinContact = txtKinContact.Text;
            user.region = cmbRegion.Text;
            user.city = cmbCity.Text;
            user.businessAddress = txtBusinessAddress.Text;
            user.residentialAddress = txtResidentialAddress.Text;
            user.accountName = txtAccountName.Text;
            user.accountNumber = txtAccountNumber.Text;
            user.bank = cmbBankName.Text;
            user.bankBranch = cmbBankBranch.Text;

            Misc.setUser(user);
        }
    }

}
