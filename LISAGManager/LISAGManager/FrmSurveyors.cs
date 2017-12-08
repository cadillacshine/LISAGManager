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
    public partial class FrmSurveyors: Form {

        private string sqlquery = "SELECT Name, DateOfBirth, Hometown, KinName, KinContact, LicenseNumber, InductionYear, Status, Active FROM vwMember";
        private string tableOrView = "vwMember";

        public FrmSurveyors() {
            InitializeComponent();
        }

        private void FrmSurveyors_Load(object sender, EventArgs e) {
            gridControl1.DataSource = Misc.loadDataSource(sqlquery, tableOrView);

            controlNavigator2.Buttons.ImageList = sharedImageCollection1;
            controlNavigator2.Buttons.CustomButtons[0].ImageIndex = 5;
        }

        private void setControlValues() {
            string name = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Name").ToString();
            string licenseNo = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "LicenseNumber").ToString();
            string gender = "", maritalStatus = "", businessAddress = "", residentialAddress = "", phoneNumber1 = "", phoneNumber2 = "", emailAddress = "", accountName = "", bankName = "", bankBranchName = "", accountNumber = "";
            
            
            SqlCommand sqlcmd = new SqlCommand("SELECT Gender, MaritalStatus, BusinessAddress, ResidentialAddress, PhoneNumber1, PhoneNumber2, EmailAddress, AccountName, BankName, BankBranchName, AccountNumber FROM vwMember WHERE LicenseNumber = '" + licenseNo + "' ", Misc.getConn());
            SqlDataReader dReader = sqlcmd.ExecuteReader();

            while (dReader.Read()) {
                gender = dReader["Gender"].ToString();
                maritalStatus = dReader["MaritalStatus"].ToString();
                businessAddress = dReader["BusinessAddress"].ToString();
                residentialAddress = dReader["ResidentialAddress"].ToString();
                phoneNumber1 = dReader["PhoneNumber1"].ToString();
                phoneNumber2 = dReader["PhoneNumber2"].ToString();
                emailAddress = dReader["EmailAddress"].ToString();
                accountName = dReader["AccountName"].ToString();
                bankName = dReader["BankName"].ToString();
                bankBranchName = dReader["BankBranchName"].ToString();
                accountNumber = dReader["AccountNumber"].ToString();
            }

            dReader.Close();

            sqlcmd = new SqlCommand("SELECT COUNT(*) FROM vwAgent WHERE LicenseNumber = '" + licenseNo + "' ", Misc.getConn());
            Misc.connOpen();
            int count = (int)sqlcmd.ExecuteScalar();
            string agentCount = "";

            if (count == 1) 
                agentCount = count + " agent";
             else 
                agentCount = count + " agents";

            lblPersonalInformation.Text = name + "\n" + gender + " || " + maritalStatus + "\n" + agentCount;
            lblContactInformation.Text = phoneNumber2 == "" ? phoneNumber1 + "\n" + emailAddress : phoneNumber1 + "\n" + phoneNumber2 + "\n" + emailAddress;
            lblBusinessAddress.Text = businessAddress;
            lblResidentialAddress.Text = residentialAddress;
            lblBankDetails.Text = accountName + "\n" + bankName + "\n" + bankBranchName + "\n" + accountNumber;
            lblLicenseNumber.Text = "License No.: " + licenseNo;

            pbProfilePicture.Image = Misc.loadImage(licenseNo);
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            setControlValues();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e) {
            setControlValues();
        }

        private void controlNavigator2_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e) {
            try { 
            if (e.Button.Tag.ToString() == "Refresh") {
                gridControl1.DataSource = Misc.loadDataSource(sqlquery, tableOrView);
            }
            } catch {

            }
        }
    }
}
