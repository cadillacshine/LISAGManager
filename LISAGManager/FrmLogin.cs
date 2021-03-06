﻿using System;
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
                    //MessageBox.Show("Authenticated!");

                    sqlcmd = new SqlCommand("SELECT UserAccountID FROM UserAccount WHERE Username = '" + txtUsername.Text + "' AND Active = 'True'", Misc.getConn());
                    Misc.connOpen();
                    int userID = (int)sqlcmd.ExecuteScalar();

                    string fName = "", mName = "", lName = "", licenseNumber = "", gender = "", maritalStatus = "", hometown = "", kinName = "", kinContact = "", phoneNumber1 = "", phoneNumber2 = "", region = "", city = "", businessAddress = "", residentialAddress = "", bankbranch = "", bank = "", accountName = "", accountNumber = "", emailAddress = "";
                    int inductionYear = 0;
                    DateTime dateOfBirth = DateTime.Now;
                    bool goodStanding = true, active = true;

        sqlcmd = new SqlCommand("SELECT FirstName, MiddleName, LastName, LicenseNumber, Gender, DateOfBirth, Hometown, MaritalStatus, KinName, KinContact, phoneNumber1, phoneNumber2, emailAddress, regionName, cityName, businessAddress, residentialAddress, bankBranchName, bankName, accountName, accountNumber, inductionYear, goodStanding, active FROM vwMember WHERE MemberID = '" + userID + "' ", Misc.getConn());
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
                        goodStanding = dReader.GetBoolean(22);
                        active = dReader.GetBoolean(23);
                        
                    }

                    AppUser appUser = new AppUser() {
                        username = txtUsername.Text,
                        appUserID = userID,
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
                        goodStanding = goodStanding,
                        active = active
                };
                    dReader.Close();

                    Misc.setUser(appUser);
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
    }
}
