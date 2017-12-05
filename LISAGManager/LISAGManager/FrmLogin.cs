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

    public partial class FrmLogin: Form {

        FrmDashboard fDashboard;

        public FrmLogin() {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e) {
            Misc.setConn("Production");
        }

        private void btnLogin_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(txtUsername.Text)) {
                MessageBox.Show("Username cannot be empty!", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtPassword.Text)) {
                MessageBox.Show("Password cannot be empty!", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return;
            }

            SqlCommand sqlcmd = new SqlCommand("SELECT COUNT(*) FROM UserAccount WHERE Username = '" + txtUsername.Text + "' AND Active = 'True'", Misc.getConn());
            Misc.connOpen();
            int count = (int)sqlcmd.ExecuteScalar();

            if (count > 0) {
                sqlcmd = new SqlCommand("SELECT Password FROM UserAccount WHERE Username = '" + txtUsername.Text + "' AND Active = 'True'", Misc.getConn());
                Misc.connOpen();
                string password = (string)sqlcmd.ExecuteScalar();

                if (string.Equals(password, txtPassword.Text)) {
                    fDashboard = new FrmDashboard();
                    fDashboard.Show();

                    this.Hide();


                    sqlcmd = new SqlCommand("SELECT MemberID FROM UserAccount WHERE Username = '" + txtUsername.Text + "' AND Active = 'True'", Misc.getConn());
                    Misc.connOpen();
                    int memberID = (int)sqlcmd.ExecuteScalar();

                    string fName = "", mName = "", lName = "", licenseNumber = "", gender = "", maritalStatus = "", hometown = "", kinName = "", kinContact = "", phoneNumber1 = "", phoneNumber2 = "", region = "", city = "", businessAddress = "", residentialAddress = "", bankbranch = "", bank = "", accountName = "", accountNumber = "", emailAddress = "", status = "";
                    int inductionYear = 0;
                    DateTime dateOfBirth = DateTime.Now;
                    bool active = true;
                    bool administrator = false;

                    sqlcmd = new SqlCommand("SELECT FirstName, MiddleName, LastName, LicenseNumber, Gender, DateOfBirth, Hometown, MaritalStatus, KinName, KinContact, phoneNumber1, phoneNumber2, emailAddress, regionName, cityName, businessAddress, residentialAddress, bankBranchName, bankName, accountName, accountNumber, inductionYear, Status, administrator, active FROM vwMember WHERE MemberID = '" + memberID + "' ", Misc.getConn());
                    Misc.connOpen();
                    SqlDataReader dReader = sqlcmd.ExecuteReader();

                    while (dReader.Read()) {
                        fName = dReader.GetString(0);
                        mName = dReader.GetString(1);
                        lName = dReader.GetString(2);
                        licenseNumber = dReader.GetString(3);
                        gender = dReader.GetString(4);
                        dateOfBirth = dReader.GetDateTime(5);
                        hometown = dReader.GetString(6);
                        maritalStatus = dReader.GetString(7);
                        kinName = dReader.GetString(8);
                        kinContact = dReader.GetString(9);
                        phoneNumber1 = dReader.GetString(10);
                        phoneNumber2 = dReader.GetString(11);
                        emailAddress = dReader.GetString(12);
                        region = dReader.GetString(13);
                        city = dReader.GetString(14);
                        businessAddress = dReader.GetString(15);
                        residentialAddress = dReader.GetString(16);
                        bankbranch = dReader.GetString(17);
                        bank = dReader.GetString(18);
                        accountName = dReader.GetString(19);
                        accountNumber = dReader.GetString(20);
                        inductionYear = dReader.GetInt32(21);
                        status = dReader.GetString(22);
                        administrator = dReader.GetBoolean(23);
                        active = dReader.GetBoolean(24);
                    }

                    AppUser appUser = new AppUser() {
                        username = txtUsername.Text,
                        appUserID = memberID,
                        firstName = fName,
                        middleName = mName,
                        lastName = lName,
                        licenseNumber = licenseNumber,
                        gender = gender,
                        dateOfBirth = dateOfBirth,
                        hometown = hometown,
                        kinName = kinName,
                        kinContact = kinContact,
                        phoneNumber1 = phoneNumber1,
                        phoneNumber2 = phoneNumber2,
                        emailAddress = emailAddress,
                        region = region,
                        city = city,
                        businessAddress = businessAddress,
                        residentialAddress = residentialAddress,
                        bankBranch = bankbranch,
                        bank = bank,
                        accountName = accountName,
                        accountNumber = accountNumber,
                        inductionYear = inductionYear,
                        status = status,
                        administrator = administrator,
                        active = active
                    };
                    dReader.Close();

                    List<Misc.strAccess> formIDs = Misc.formIDs();
                    appUser.access = new Access();

                    foreach (var item in formIDs) {
                        if (item.name == "FrmLogin") {
                            sqlcmd = new SqlCommand("SELECT Access FROM vwAppAccess WHERE Name = 'FrmLogin' AND LicenseNumber = '" + appUser.licenseNumber + "' ", Misc.getConn());
                            
                            Misc.connOpen();
                            appUser.access.login = (bool)sqlcmd.ExecuteScalar();
                        }

                        if (item.name == "FrmMe") {
                            sqlcmd = new SqlCommand("SELECT Access FROM vwAppAccess WHERE Name = 'FrmMe' AND LicenseNumber = '" + appUser.licenseNumber + "' ", Misc.getConn());
                            
                            Misc.connOpen();
                            appUser.access.me = (bool)sqlcmd.ExecuteScalar();
                        }

                        if (item.name == "FrmSurveyors") {
                            sqlcmd = new SqlCommand("SELECT Access FROM vwAppAccess WHERE Name = 'FrmSurveyors' AND LicenseNumber = '" + appUser.licenseNumber + "' ", Misc.getConn());
                            
                            Misc.connOpen();
                            appUser.access.surveyors = (bool)sqlcmd.ExecuteScalar();
                        }

                        if (item.name == "FrmRegion") {
                            sqlcmd = new SqlCommand("SELECT Access FROM vwAppAccess WHERE Name = 'FrmRegion' AND LicenseNumber = '" + appUser.licenseNumber + "' ", Misc.getConn());
                            
                            Misc.connOpen();
                            appUser.access.region = (bool)sqlcmd.ExecuteScalar();
                        }

                        if (item.name == "FrmCity") {
                            sqlcmd = new SqlCommand("SELECT Access FROM vwAppAccess WHERE Name = 'FrmCity' AND LicenseNumber = '" + appUser.licenseNumber + "' ", Misc.getConn());
                            
                            Misc.connOpen();
                            appUser.access.city = (bool)sqlcmd.ExecuteScalar();
                        }

                        if (item.name == "FrmBank") {
                            sqlcmd = new SqlCommand("SELECT Access FROM vwAppAccess WHERE Name = 'FrmBank' AND LicenseNumber = '" + appUser.licenseNumber + "' ", Misc.getConn());
                            
                            Misc.connOpen();
                            appUser.access.bank = (bool)sqlcmd.ExecuteScalar();
                        }

                        if (item.name == "FrmBankBranch") {
                            sqlcmd = new SqlCommand("SELECT Access FROM vwAppAccess WHERE Name = 'FrmBankBranch' AND LicenseNumber = '" + appUser.licenseNumber + "' ", Misc.getConn());
                            
                            Misc.connOpen();
                            appUser.access.bankBranch = (bool)sqlcmd.ExecuteScalar();
                        }

                        if (item.name == "FrmChangePassword") {
                            sqlcmd = new SqlCommand("SELECT Access FROM vwAppAccess WHERE Name = 'FrmChangePassword' AND LicenseNumber = '" + appUser.licenseNumber + "' ", Misc.getConn());
                            
                            Misc.connOpen();
                            appUser.access.changePassword = (bool)sqlcmd.ExecuteScalar();
                        }

                        if (item.name == "FrmActivityLog") {
                            sqlcmd = new SqlCommand("SELECT Access FROM vwAppAccess WHERE Name = 'FrmActivityLog' AND LicenseNumber = '" + appUser.licenseNumber + "' ", Misc.getConn());
                            
                            Misc.connOpen();
                            appUser.access.activityLog = (bool)sqlcmd.ExecuteScalar();
                        }

                        if (item.name == "FrmAgent") {
                            sqlcmd = new SqlCommand("SELECT Access FROM vwAppAccess WHERE Name = 'FrmAgent' AND LicenseNumber = '" + appUser.licenseNumber + "' ", Misc.getConn());
                            
                            Misc.connOpen();
                            appUser.access.setupAgent = (bool)sqlcmd.ExecuteScalar();
                        }

                        if (item.name == "FrmAgents") {
                            sqlcmd = new SqlCommand("SELECT Access FROM vwAppAccess WHERE Name = 'FrmAgents' AND LicenseNumber = '" + appUser.licenseNumber + "' ", Misc.getConn());

                            Misc.connOpen();
                            appUser.access.agents = (bool)sqlcmd.ExecuteScalar();
                        }

                        if (item.name == "FrmMyAgents") {
                            sqlcmd = new SqlCommand("SELECT Access FROM vwAppAccess WHERE Name = 'FrmMyAgents' AND LicenseNumber = '" + appUser.licenseNumber + "' ", Misc.getConn());

                            Misc.connOpen();
                            appUser.access.myAgents = (bool)sqlcmd.ExecuteScalar();
                        }

                        if (item.name == "FrmManageAccount") {
                            sqlcmd = new SqlCommand("SELECT Access FROM vwAppAccess WHERE Name = 'FrmManageAccount' AND LicenseNumber = '" + appUser.licenseNumber + "' ", Misc.getConn());

                            Misc.connOpen();
                            appUser.access.manageAccount = (bool)sqlcmd.ExecuteScalar();
                        }
                    }

                    Misc.setUser(appUser);
                    fDashboard.setUserDetails();
                    fDashboard.allAccessRights();
                    Misc.logActivity(appUser.appUserID, "logged in");
                    
                } else {
                    MessageBox.Show("Username/ Password Incorrect!", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.SelectAll();
                    return;
                }
            } else {
                MessageBox.Show("Username/ Password Incorrect!", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.SelectAll();
                return;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e) {

        }
    }
}
