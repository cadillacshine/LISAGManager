using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace LISAGManager {
    public partial class FrmManageAccount: Form {

        NavigatorCustomButton BtnAdd, BtnEdit, BtnSave, BtnCancel, BtnSwitch, BtnRefresh;
        NavigatorCustomButton BtnCIAdd, BtnCIEdit, BtnCISave, BtnCICancel, BtnCISwitch, BtnCIRefresh;
        NavigatorCustomButton BtnKDAdd, BtnKDEdit, BtnKDSave, BtnKDCancel, BtnKDSwitch, BtnKDRefresh;
        NavigatorCustomButton BtnLocAdd, BtnLocEdit, BtnLocSave, BtnLocCancel, BtnLocSwitch, BtnLocRefresh;
        NavigatorCustomButton BtnBDAdd, BtnBDEdit, BtnBDSave, BtnBDCancel, BtnBDSwitch, BtnBDRefresh;
        NavigatorCustomButton BtnADAdd, BtnADEdit, BtnADSave, BtnADCancel, BtnADSwitch, BtnADRefresh;
        NavigatorCustomButton BtnARAdd, BtnAREdit, BtnARSave, BtnARCancel, BtnARSwitch, BtnARRefresh;

        private string actionState = "a";
        private string sqlQuery = "SELECT Name, Gender, DateOfBirth, MaritalStatus, Hometown, LicenseNumber, InductionYear, Status, Active FROM vwMember ORDER BY Name";
        private string sqlQueryRegion = "SELECT Name FROM Region WHERE Active = 'True'";
        private string sqlQueryBank = "SELECT Name FROM Bank WHERE Active = 'True'";

        AppUser appUser = new AppUser();
        SqlCommand sqlcmd = new SqlCommand();

        private int memberIDforAccessRight = 0;



        public FrmManageAccount() {
            InitializeComponent();
        }

        private void FrmManageAccount_Load(object sender, EventArgs e) {
            loadForm();

            controlNavigator1.Buttons.ImageList = sharedImageCollection1;
            controlNavigator1.Buttons.CustomButtons[0].ImageIndex = 0;
            controlNavigator1.Buttons.CustomButtons[1].ImageIndex = 1;
            controlNavigator1.Buttons.CustomButtons[2].ImageIndex = 2;
            controlNavigator1.Buttons.CustomButtons[3].ImageIndex = 3;
            controlNavigator1.Buttons.CustomButtons[4].ImageIndex = 4;
            controlNavigator1.Buttons.CustomButtons[5].ImageIndex = 5;

            controlNavigatorCI.Buttons.ImageList = sharedImageCollection1;
            controlNavigatorCI.Buttons.CustomButtons[0].ImageIndex = 0;
            controlNavigatorCI.Buttons.CustomButtons[1].ImageIndex = 1;
            controlNavigatorCI.Buttons.CustomButtons[2].ImageIndex = 2;
            controlNavigatorCI.Buttons.CustomButtons[3].ImageIndex = 3;
            controlNavigatorCI.Buttons.CustomButtons[4].ImageIndex = 4;
            controlNavigatorCI.Buttons.CustomButtons[5].ImageIndex = 5;

            controlNavigatorAD.Buttons.ImageList = sharedImageCollection1;
            controlNavigatorAD.Buttons.CustomButtons[0].ImageIndex = 0;
            controlNavigatorAD.Buttons.CustomButtons[1].ImageIndex = 1;
            controlNavigatorAD.Buttons.CustomButtons[2].ImageIndex = 2;
            controlNavigatorAD.Buttons.CustomButtons[3].ImageIndex = 3;
            controlNavigatorAD.Buttons.CustomButtons[4].ImageIndex = 4;
            controlNavigatorAD.Buttons.CustomButtons[5].ImageIndex = 5;

            controlNavigatorKD.Buttons.ImageList = sharedImageCollection1;
            controlNavigatorKD.Buttons.CustomButtons[0].ImageIndex = 0;
            controlNavigatorKD.Buttons.CustomButtons[1].ImageIndex = 1;
            controlNavigatorKD.Buttons.CustomButtons[2].ImageIndex = 2;
            controlNavigatorKD.Buttons.CustomButtons[3].ImageIndex = 3;
            controlNavigatorKD.Buttons.CustomButtons[4].ImageIndex = 4;
            controlNavigatorKD.Buttons.CustomButtons[5].ImageIndex = 5;

            controlNavigatorLoc.Buttons.ImageList = sharedImageCollection1;
            controlNavigatorLoc.Buttons.CustomButtons[0].ImageIndex = 0;
            controlNavigatorLoc.Buttons.CustomButtons[1].ImageIndex = 1;
            controlNavigatorLoc.Buttons.CustomButtons[2].ImageIndex = 2;
            controlNavigatorLoc.Buttons.CustomButtons[3].ImageIndex = 3;
            controlNavigatorLoc.Buttons.CustomButtons[4].ImageIndex = 4;
            controlNavigatorLoc.Buttons.CustomButtons[5].ImageIndex = 5;

            controlNavigatorBD.Buttons.ImageList = sharedImageCollection1;
            controlNavigatorBD.Buttons.CustomButtons[0].ImageIndex = 0;
            controlNavigatorBD.Buttons.CustomButtons[1].ImageIndex = 1;
            controlNavigatorBD.Buttons.CustomButtons[2].ImageIndex = 2;
            controlNavigatorBD.Buttons.CustomButtons[3].ImageIndex = 3;
            controlNavigatorBD.Buttons.CustomButtons[4].ImageIndex = 4;
            controlNavigatorBD.Buttons.CustomButtons[5].ImageIndex = 5;

            controlNavigatorAD.Buttons.ImageList = sharedImageCollection1;
            controlNavigatorAD.Buttons.CustomButtons[0].ImageIndex = 0;
            controlNavigatorAD.Buttons.CustomButtons[1].ImageIndex = 1;
            controlNavigatorAD.Buttons.CustomButtons[2].ImageIndex = 2;
            controlNavigatorAD.Buttons.CustomButtons[3].ImageIndex = 3;
            controlNavigatorAD.Buttons.CustomButtons[4].ImageIndex = 4;
            controlNavigatorAD.Buttons.CustomButtons[5].ImageIndex = 5;

            controlNavigatorAR.Buttons.ImageList = sharedImageCollection1;
            controlNavigatorAR.Buttons.CustomButtons[0].ImageIndex = 0;
            controlNavigatorAR.Buttons.CustomButtons[1].ImageIndex = 1;
            controlNavigatorAR.Buttons.CustomButtons[2].ImageIndex = 2;
            controlNavigatorAR.Buttons.CustomButtons[3].ImageIndex = 3;
            controlNavigatorAR.Buttons.CustomButtons[4].ImageIndex = 4;
            controlNavigatorAR.Buttons.CustomButtons[5].ImageIndex = 5;
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
                searchControlKD.Text = "";
                loadKinDetails();
                sqlQuery = "SELECT Name, LicenseNumber, KinName, KinContact FROM vwMember ORDER BY Name";
                gridControlKD.DataSource = Misc.loadDataSource(sqlQuery, "vwMember");
            } else if (xtraTabControl1.SelectedTabPage.Text == "Location") {
                searchControlLoc.Text = "";
                loadLocation();
                sqlQuery = "SELECT Name, LicenseNumber, RegionName, CityName, BusinessAddress, ResidentialAddress FROM vwMember ORDER BY Name";
                gridControlLoc.DataSource = Misc.loadDataSource(sqlQuery, "vwMember");
            } else if (xtraTabControl1.SelectedTabPage.Text == "Bank Details") {
                searchControlBD.Text = "";
                loadBankDetails();
                sqlQuery = "SELECT Name, LicenseNumber, BankName, BankBranchName, AccountName, AccountNumber FROM vwMember ORDER BY Name";
                gridControlBD.DataSource = Misc.loadDataSource(sqlQuery, "vwMember");
            } else if (xtraTabControl1.SelectedTabPage.Text == "Account Details") {
                searchControlAD.Text = "";
                loadAccountDetails();
                sqlQuery = "SELECT Name, LicenseNumber, Username, Administrator, AccountActive FROM vwMember ORDER BY Name";
                gridControlAD.DataSource = Misc.loadDataSource(sqlQuery, "vwMember");
            } else if (xtraTabControl1.SelectedTabPage.Text == "Access Rights") {
                searchControlAR.Text = "";
                loadAccessRights();
                sqlQuery = "SELECT Name, LicenseNumber, Username FROM vwMember ORDER BY Name";
                gridControlARUsers.DataSource = Misc.loadDataSource(sqlQuery, "vwMember");
            }
        }

        private void loadForm() {
            // set default values
            gridControl1.DataSource = Misc.loadDataSource(sqlQuery, "vwMember");
            cmbGender.SelectedIndex = -1;
            cmbMaritalStatus.SelectedIndex = -1;
            deDOB.DateTime = new DateTime(1900, 01, 01);

            cmbStatus.DataSource = Misc.loadDataSource("SELECT Status FROM Status WHERE Active ='True'", "Status");
            cmbStatus.DisplayMember = "Status";

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
           // try {

                int memberID = 0;
                if (e.Button.Tag.ToString() == "Add") {
                    toolStripStatusLabel1.Text = "Adding...";
                    if (tableLayoutPanel2.RowStyles[2].Height == 1)
                        tableLayoutPanel2.RowStyles[2].Height = 149;
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

                    pictureBoxPI.Image = Properties.Resources.User;

                } else if (e.Button.Tag.ToString() == "Edit") {
                    if (tableLayoutPanel2.RowStyles[2].Height == 1)
                        tableLayoutPanel2.RowStyles[2].Height = 149;
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
                        memberID = (int)sqlcmd.ExecuteScalar();

                        sqlcmd = new SqlCommand("SELECT StatusID FROM Status WHERE Status = '" + cmbStatus.Text + "' AND Active = 'True'", Misc.getConn());
                        Misc.connOpen();
                        int statusID = (int)sqlcmd.ExecuteScalar();

                        sqlcmd = new SqlCommand("UPDATE Member SET FirstName = @FirstName, MiddleName = @MiddleName, LastName = @LastName, Gender = @Gender, DateOfBirth = @DateOfBirth, MaritalStatus = @MaritalStatus, Hometown = @Hometown, LicenseNumber = @LicenseNumber, InductionYear = @InductionYear, StatusID = @StatusID, Active = @Active WHERE MemberID = '" + memberID + "' ", Misc.getConn());

                        sqlcmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                        sqlcmd.Parameters.AddWithValue("@MiddleName", txtMiddleName.Text);
                        sqlcmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                        sqlcmd.Parameters.AddWithValue("@Gender", cmbGender.Text);
                        sqlcmd.Parameters.AddWithValue("@DateOfBirth", deDOB.DateTime);
                        sqlcmd.Parameters.AddWithValue("@MaritalStatus", cmbMaritalStatus.Text);
                        sqlcmd.Parameters.AddWithValue("@Hometown", txtHometown.Text);
                        sqlcmd.Parameters.AddWithValue("@LicenseNumber", txtLicenseNo.Text);
                        sqlcmd.Parameters.AddWithValue("@InductionYear", txtInductionYear.Text);
                        sqlcmd.Parameters.AddWithValue("@StatusID", statusID);
                        sqlcmd.Parameters.AddWithValue("@Active", cbActive.Checked);
                        Misc.connOpen();
                        sqlcmd.ExecuteNonQuery();
                        sqlcmd.Dispose();

                        string image = openFileDialog1.FileName;

                        if (image.Equals("") || image == null) {
                        return;
                        } else {
                        Misc.updateImage(memberID, image);
                        }
                        
                    } else if (actionState == "a") {
                        toolStripStatusLabel1.Text = "Saving...";

                        if (!verifyInput())
                            return;

                        sqlcmd = new SqlCommand("SELECT StatusID FROM Status WHERE Status = '" + cmbStatus.Text + "' AND Active = 'True'", Misc.getConn());
                        Misc.connOpen();
                        int statusID = (int)sqlcmd.ExecuteScalar();

                        sqlcmd = new SqlCommand("INSERT INTO Member (FirstName, MiddleName, LastName, Gender, DateOfBirth, MaritalStatus, Hometown, KinName, KinContact, LicenseNumber, PhoneNumber1, PhoneNumber2, EmailAddress, CityID, BusinessAddress, ResidentialAddress, LISAGBankID, InductionYear, StatusID, Active) VALUES (@FirstName, @MiddleName, @LastName, @Gender, @DateOfBirth, @MaritalStatus, @Hometown, @KinName, @KinContact, @LicenseNumber, @PhoneNumber1, @PhoneNumber2, @EmailAddress, @CityID, @BusinessAddress, @ResidentialAddress, @LISAGBankID, @InductionYear, @StatusID, @Active)", Misc.getConn());

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
                        sqlcmd.Parameters.AddWithValue("@StatusID", statusID);
                        sqlcmd.Parameters.AddWithValue("@Active", cbActive.Checked);
                        Misc.connOpen();
                        sqlcmd.ExecuteNonQuery();
                        sqlcmd.Dispose();

                        sqlcmd = new SqlCommand("SELECT MemberID FROM Member WHERE LicenseNumber = '" + txtLicenseNo.Text + "' ", Misc.getConn());
                        Misc.connOpen();
                        memberID = (int)sqlcmd.ExecuteScalar();

                        Misc.connOpen();
                        string image = openFileDialog1.FileName;

                 
                        Misc.saveImage(memberID, image);

                        sqlcmd = new SqlCommand("INSERT INTO UserAccount (MemberID, Username, Password, Administrator, Active) VALUES (@MemberID, @Username, @Password, @Administrator, @Active)", Misc.getConn());
                        sqlcmd.Parameters.AddWithValue("@MemberID", memberID);
                        sqlcmd.Parameters.AddWithValue("@Username", txtFirstName.Text + "." + txtLastName.Text);
                        sqlcmd.Parameters.AddWithValue("@Password", "Passw0rd");
                        sqlcmd.Parameters.AddWithValue("@Administrator", false);
                        sqlcmd.Parameters.AddWithValue("@Active", false);
                        Misc.connOpen();
                        sqlcmd.ExecuteNonQuery();
                        sqlcmd.Dispose();

                        sqlcmd = new SqlCommand("INSERT INTO LISAGBank (MemberID, BankBranchID, AccountName, AccountNumber) VALUES(@MemberID, @BankBranchID, @AccountName, @AccountNumber) ", Misc.getConn());
                        sqlcmd.Parameters.AddWithValue("@MemberID", memberID);
                        sqlcmd.Parameters.AddWithValue("@BankBranchID", 2);
                        sqlcmd.Parameters.AddWithValue("@AccountName", "Unassigned");
                        sqlcmd.Parameters.AddWithValue("@AccountNumber", "Unassigned");
                        Misc.connOpen();
                        sqlcmd.ExecuteNonQuery();
                        sqlcmd.Dispose();

                        sqlcmd = new SqlCommand("SELECT LISAGBankID FROM LISAGBank WHERE MemberID = '" + memberID + "' ", Misc.getConn());
                        Misc.connOpen();
                        int lisagBankID = (int)sqlcmd.ExecuteScalar();

                        sqlcmd = new SqlCommand("UPDATE Member SET LISAGBankID = @LISAGBankID WHERE MemberID = '" + memberID + "' ", Misc.getConn());
                        sqlcmd.Parameters.AddWithValue("@LISAGBankID", lisagBankID);
                        Misc.connOpen();
                        sqlcmd.ExecuteNonQuery();
                        sqlcmd.Dispose();

                        insertRights(memberID);
                    }

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
                    if (tableLayoutPanel2.RowStyles[2].Height == 149) {
                        tableLayoutPanel2.RowStyles[2].Height = 1;
                    } else {
                        tableLayoutPanel2.RowStyles[2].Height = 149;
                    }
                }
            //} catch {

            //}
        }

        private void insertRights(int memberID) {
            try {


                List<int> list = new List<int>();
                sqlcmd = new SqlCommand("SELECT FormID FROM Form WHERE Name = 'FrmLogin'", Misc.getConn());
                Misc.connOpen();
                int frmLoginID = (int)sqlcmd.ExecuteScalar();
                list.Add(frmLoginID);

                sqlcmd = new SqlCommand("SELECT FormID FROM Form WHERE Name = 'FrmMe'", Misc.getConn());
                Misc.connOpen();
                int frmMeID = (int)sqlcmd.ExecuteScalar();
                list.Add(frmMeID);

                sqlcmd = new SqlCommand("SELECT FormID FROM Form WHERE Name = 'FrmSurveyors'", Misc.getConn());
                Misc.connOpen();
                int frmSurveyorsID = (int)sqlcmd.ExecuteScalar();
                list.Add(frmSurveyorsID);

                sqlcmd = new SqlCommand("SELECT FormID FROM Form WHERE Name = 'FrmRegion'", Misc.getConn());
                Misc.connOpen();
                int frmRegionID = (int)sqlcmd.ExecuteScalar();
                list.Add(frmRegionID);

                sqlcmd = new SqlCommand("SELECT FormID FROM Form WHERE Name = 'FrmCity'", Misc.getConn());
                Misc.connOpen();
                int frmCityID = (int)sqlcmd.ExecuteScalar();
                list.Add(frmCityID);

                sqlcmd = new SqlCommand("SELECT FormID FROM Form WHERE Name = 'FrmBank'", Misc.getConn());
                Misc.connOpen();
                int frmBankID = (int)sqlcmd.ExecuteScalar();
                list.Add(frmBankID);

                sqlcmd = new SqlCommand("SELECT FormID FROM Form WHERE Name = 'FrmBankBranch'", Misc.getConn());
                Misc.connOpen();
                int frmBankBranchID = (int)sqlcmd.ExecuteScalar();
                list.Add(frmBankBranchID);

                sqlcmd = new SqlCommand("SELECT FormID FROM Form WHERE Name = 'FrmChangePassword'", Misc.getConn());
                Misc.connOpen();
                int frmChangePasswordID = (int)sqlcmd.ExecuteScalar();
                list.Add(frmChangePasswordID);

                sqlcmd = new SqlCommand("SELECT FormID FROM Form WHERE Name = 'FrmActivityLog'", Misc.getConn());
                Misc.connOpen();
                int frmActivityLogID = (int)sqlcmd.ExecuteScalar();
                list.Add(frmActivityLogID);

                sqlcmd = new SqlCommand("SELECT FormID FROM Form WHERE Name = 'FrmAgent'", Misc.getConn());
                Misc.connOpen();
                int frmAgentID = (int)sqlcmd.ExecuteScalar();
                list.Add(frmAgentID);

                sqlcmd = new SqlCommand("SELECT FormID FROM Form WHERE Name = 'FrmAgents'", Misc.getConn());
                Misc.connOpen();
                int frmAgentsID = (int)sqlcmd.ExecuteScalar();
                list.Add(frmAgentsID);

                sqlcmd = new SqlCommand("SELECT FormID FROM Form WHERE Name = 'FrmMyAgents'", Misc.getConn());
                Misc.connOpen();
                int frmMyAgentsID = (int)sqlcmd.ExecuteScalar();
                list.Add(frmMyAgentsID);

                sqlcmd = new SqlCommand("SELECT FormID FROM Form WHERE Name = 'FrmManageAccount'", Misc.getConn());
                Misc.connOpen();
                int frmManageAccountID = (int)sqlcmd.ExecuteScalar();
                list.Add(frmManageAccountID);

                foreach (var item in list) {
                    sqlcmd = new SqlCommand("INSERT INTO AppAccess(FormID, MemberID, Access) VALUES(@FormID, @MemberID, @Access)", Misc.getConn());
                    sqlcmd.Parameters.AddWithValue("@FormID", item);
                    sqlcmd.Parameters.AddWithValue("@MemberID", memberID);
                    sqlcmd.Parameters.AddWithValue("@Access", false);
                    sqlcmd.ExecuteNonQuery();
                    sqlcmd.Dispose();
                }
            } catch {

            }
        }

        private void setTabState(bool status) {
            // enable/disable tab page selection
            xtraTabControl1.TabPages[0].PageEnabled = status;
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
            cmbStatus.Enabled = status;
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

        private void gridViewKD_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            selectionChangedKD();
            setControlValuesKD();
        }

        private void gridViewKD_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e) {
            selectionChangedKD();
            setControlValuesKD();
        }

        private void controlNavigatorLoc_ButtonClick(object sender, NavigatorButtonClickEventArgs e) {
            try {

                if (e.Button.Tag.ToString() == "Edit") {
                    if (tableLayoutPanel26.RowStyles[2].Height == 1)
                        tableLayoutPanel26.RowStyles[2].Height = 234;
                    actionState = "e";
                    setControlStateLoc(true);

                    xtraTabControl1.TabPages[0].PageEnabled = false;
                    xtraTabControl1.TabPages[1].PageEnabled = false;
                    xtraTabControl1.TabPages[2].PageEnabled = false;
                    xtraTabControl1.TabPages[3].PageEnabled = true;
                    xtraTabControl1.TabPages[4].PageEnabled = false;
                    xtraTabControl1.TabPages[5].PageEnabled = false;
                    xtraTabControl1.TabPages[6].PageEnabled = false;

                    cmbLocRegion.Focus();
                    BtnLocEdit.Enabled = false;
                    BtnLocSave.Enabled = true;
                    BtnLocCancel.Enabled = true;
                    BtnLocSwitch.Enabled = false;
                    BtnLocRefresh.Enabled = false;
                    btnPic.Enabled = true;

                    controlNavigatorLoc.Buttons.First.Enabled = false;
                    controlNavigatorLoc.Buttons.Next.Enabled = false;
                    controlNavigatorLoc.Buttons.Prev.Enabled = false;
                    controlNavigatorLoc.Buttons.Last.Enabled = false;

                    searchControlLoc.Enabled = false;
                    gridControlLoc.Enabled = false;
                } else if (e.Button.Tag.ToString() == "Save") {

                    if (actionState == "e") {
                        toolStripStatusLabelLoc.Text = "Editing...";
                        sqlcmd = new SqlCommand("SELECT MemberID FROM vwMember WHERE LicenseNumber = '" + txtLocLicenseNumber.Text + "' ", Misc.getConn());
                        Misc.connOpen();
                        int memberID = (int)sqlcmd.ExecuteScalar();

                        sqlcmd = new SqlCommand("SELECT RegionID FROM Region WHERE Name = '" + cmbLocRegion.Text + "' ", Misc.getConn());
                        int regionID = (int)sqlcmd.ExecuteScalar();

                        sqlcmd = new SqlCommand("SELECT CityID FROM City WHERE Name = '" + cmbLocCity.Text + "' AND RegionID = '" + regionID + "' ", Misc.getConn());
                        int cityID = (int)sqlcmd.ExecuteScalar();

                        sqlcmd = new SqlCommand("UPDATE Member SET CityID = @CityID, BusinessAddress = @BusinessAddress, ResidentialAddress=@ResidentialAddress WHERE MemberID = '" + memberID + "' ", Misc.getConn());

                        sqlcmd.Parameters.AddWithValue("@CityID", cityID);
                        sqlcmd.Parameters.AddWithValue("@BusinessAddress", txtBusinessAddress.Text);
                        sqlcmd.Parameters.AddWithValue("@ResidentialAddress", txtResidentialAddress.Text);
                    }


                    Misc.connOpen();
                    sqlcmd.ExecuteNonQuery();
                    sqlcmd.Dispose();

                    actionState = "a";

                    gridControlLoc.DataSource = Misc.loadDataSource(sqlQuery, "vwMember");
                    setControlStateLoc(false);
                    BtnLocSave.Enabled = false;
                    BtnLocEdit.Enabled = true;
                    BtnLocAdd.Enabled = true;
                    BtnLocCancel.Enabled = false;
                    BtnLocSwitch.Enabled = true;
                    BtnLocRefresh.Enabled = true;
                    btnPic.Enabled = false;

                    controlNavigatorLoc.Buttons.First.Enabled = true;
                    controlNavigatorLoc.Buttons.Next.Enabled = true;
                    controlNavigatorLoc.Buttons.Prev.Enabled = true;
                    controlNavigatorLoc.Buttons.Last.Enabled = true;

                    searchControlLoc.Enabled = true;
                    gridControlLoc.Enabled = true;
                    setTabState(true);
                    gridControlLoc.DataSource = Misc.loadDataSource(sqlQuery, "vwMember");
                    toolStripStatusLabelLoc.Text = "Saved";

                } else if (e.Button.Tag.ToString() == "Cancel") {
                    setControlStateLoc(false);
                    actionState = "a";
                    BtnLocAdd.Enabled = false;
                    BtnLocEdit.Enabled = true;
                    BtnLocSave.Enabled = false;
                    BtnLocCancel.Enabled = false;
                    BtnLocSwitch.Enabled = true;
                    BtnLocRefresh.Enabled = true;
                    btnPic.Enabled = false;

                    controlNavigatorLoc.Buttons.First.Enabled = true;
                    controlNavigatorLoc.Buttons.Next.Enabled = true;
                    controlNavigatorLoc.Buttons.Prev.Enabled = true;
                    controlNavigatorLoc.Buttons.Last.Enabled = true;

                    searchControlLoc.Enabled = true;
                    gridControlLoc.Enabled = true;
                    setTabState(true);

                    toolStripStatusLabelLoc.Text = "Done";

                } else if (e.Button.Tag.ToString() == "Refresh") {
                    toolStripStatusLabelLoc.Text = "Refreshing...";
                    gridControlLoc.DataSource = Misc.loadDataSource(sqlQuery, "vwMember");
                    cmbLocRegion.DataSource = Misc.loadDataSource(sqlQueryRegion, "Region");
                    toolStripStatusLabelLoc.Text = "Done";

                } else if (e.Button.Tag.ToString() == "Switch") {
                    if (tableLayoutPanel26.RowStyles[2].Height == 234) {
                        tableLayoutPanel26.RowStyles[2].Height = 1;
                    } else {
                        tableLayoutPanel26.RowStyles[2].Height = 234;
                    }
                }
            } catch {

            }
        }

        private void gridViewLoc_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            selectionChangedLoc();
            setControlValuesLoc();
        }

        private void gridViewLoc_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e) {
            selectionChangedLoc();
            setControlValuesLoc();
        }

        private void cmbBDBankName_SelectedIndexChanged(object sender, EventArgs e) {
            cmbBDBranchName.DataSource = Misc.loadDataSource("SELECT Name FROM vwBankBranch WHERE Bank = '" + cmbBDBankName.Text + "' ", "vwBankBranch");
            cmbBDBranchName.DisplayMember = "Name";
        }

        private void controlNavigatorBD_ButtonClick(object sender, NavigatorButtonClickEventArgs e) {
            //try {

            if (e.Button.Tag.ToString() == "Edit") {
                if (tableLayoutPanel35.RowStyles[2].Height == 1)
                    tableLayoutPanel35.RowStyles[2].Height = 144;
                actionState = "e";
                setControlStateBD(true);

                xtraTabControl1.TabPages[0].PageEnabled = false;
                xtraTabControl1.TabPages[1].PageEnabled = false;
                xtraTabControl1.TabPages[2].PageEnabled = false;
                xtraTabControl1.TabPages[3].PageEnabled = false;
                xtraTabControl1.TabPages[4].PageEnabled = true;
                xtraTabControl1.TabPages[5].PageEnabled = false;
                xtraTabControl1.TabPages[6].PageEnabled = false;

                cmbBDBankName.Focus();
                BtnBDEdit.Enabled = false;
                BtnBDSave.Enabled = true;
                BtnBDCancel.Enabled = true;
                BtnBDSwitch.Enabled = false;
                BtnBDRefresh.Enabled = false;
                btnPic.Enabled = true;

                controlNavigatorBD.Buttons.First.Enabled = false;
                controlNavigatorBD.Buttons.Next.Enabled = false;
                controlNavigatorBD.Buttons.Prev.Enabled = false;
                controlNavigatorBD.Buttons.Last.Enabled = false;

                searchControlBD.Enabled = false;
                gridControlBD.Enabled = false;
            } else if (e.Button.Tag.ToString() == "Save") {

                if (actionState == "e") {
                    toolStripStatusLabelBD.Text = "Editing...";
                    sqlcmd = new SqlCommand("SELECT MemberID FROM vwMember WHERE LicenseNumber = '" + txtBDLicenseNumber.Text + "' ", Misc.getConn());
                    Misc.connOpen();
                    int memberID = (int)sqlcmd.ExecuteScalar();

                    sqlcmd = new SqlCommand("SELECT LISAGBankID FROM LISAGBank WHERE MemberID = '" + memberID + "' ", Misc.getConn());
                    Misc.connOpen();
                    int lisagBankID = (int)sqlcmd.ExecuteScalar();

                    sqlcmd = new SqlCommand("SELECT BankBranchID FROM vwBankBranch WHERE Bank = '" + cmbBDBankName.Text + "' ", Misc.getConn());
                    Misc.connOpen();
                    int bankBranchID = (int)sqlcmd.ExecuteScalar();

                    sqlcmd = new SqlCommand("UPDATE LISAGBank SET BankBranchID = @BankBranchID, AccountName = @AccountName, AccountNumber = @AccountNumber WHERE LISAGBankID = '" + lisagBankID + "' ", Misc.getConn());

                    sqlcmd.Parameters.AddWithValue("@BankBranchID", bankBranchID);
                    sqlcmd.Parameters.AddWithValue("@AccountName", txtBDAccountName.Text);
                    sqlcmd.Parameters.AddWithValue("@AccountNumber", txtBDAccountNumber.Text);
                    Misc.connOpen();
                    sqlcmd.ExecuteNonQuery();
                    sqlcmd.Dispose();
                }

                actionState = "a";

                gridControlBD.DataSource = Misc.loadDataSource(sqlQuery, "vwMember");
                setControlStateBD(false);
                BtnBDSave.Enabled = false;
                BtnBDEdit.Enabled = true;
                BtnBDAdd.Enabled = true;
                BtnBDCancel.Enabled = false;
                BtnBDSwitch.Enabled = true;
                BtnBDRefresh.Enabled = true;
                btnPic.Enabled = false;

                controlNavigatorBD.Buttons.First.Enabled = true;
                controlNavigatorBD.Buttons.Next.Enabled = true;
                controlNavigatorBD.Buttons.Prev.Enabled = true;
                controlNavigatorBD.Buttons.Last.Enabled = true;

                searchControlBD.Enabled = true;
                gridControlBD.Enabled = true;
                setTabState(true);
                gridControlBD.DataSource = Misc.loadDataSource(sqlQuery, "vwMember");
                toolStripStatusLabelBD.Text = "Saved";

            } else if (e.Button.Tag.ToString() == "Cancel") {
                setControlStateBD(false);
                actionState = "a";
                BtnBDAdd.Enabled = false;
                BtnBDEdit.Enabled = true;
                BtnBDSave.Enabled = false;
                BtnBDCancel.Enabled = false;
                BtnBDSwitch.Enabled = true;
                BtnBDRefresh.Enabled = true;
                btnPic.Enabled = false;

                controlNavigatorBD.Buttons.First.Enabled = true;
                controlNavigatorBD.Buttons.Next.Enabled = true;
                controlNavigatorBD.Buttons.Prev.Enabled = true;
                controlNavigatorBD.Buttons.Last.Enabled = true;

                searchControlBD.Enabled = true;
                gridControlBD.Enabled = true;
                setTabState(true);

                txtADPassword.Text = txtADConfirmPassword.Text = "ThisIsMyPassword";

                toolStripStatusLabelBD.Text = "Done";

            } else if (e.Button.Tag.ToString() == "Refresh") {
                toolStripStatusLabelBD.Text = "Refreshing...";
                gridControlBD.DataSource = Misc.loadDataSource(sqlQuery, "vwMember");
                toolStripStatusLabelBD.Text = "Done";

            } else if (e.Button.Tag.ToString() == "Switch") {
                if (tableLayoutPanel35.RowStyles[2].Height == 144) {
                    tableLayoutPanel35.RowStyles[2].Height = 1;
                } else {
                    tableLayoutPanel35.RowStyles[2].Height = 144;
                }
            }
            //} catch {

            //}
        }

        private void gridViewBD_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            selectionChangedBD();
            setControlValuesBD();
        }

        private void gridViewBD_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e) {
            selectionChangedBD();
            setControlValuesBD();
        }

        private void controlNavigatorAD_ButtonClick(object sender, NavigatorButtonClickEventArgs e) {
            //try {

                if (e.Button.Tag.ToString() == "Edit") {
                    if (tableLayoutPanel52.RowStyles[2].Height == 1)
                        tableLayoutPanel52.RowStyles[2].Height = 146;
                    actionState = "e";
                    setControlStateAD(true);

                    xtraTabControl1.TabPages[0].PageEnabled = false;
                    xtraTabControl1.TabPages[1].PageEnabled = false;
                    xtraTabControl1.TabPages[2].PageEnabled = false;
                    xtraTabControl1.TabPages[3].PageEnabled = false;
                    xtraTabControl1.TabPages[4].PageEnabled = false;
                    xtraTabControl1.TabPages[5].PageEnabled = true;
                    xtraTabControl1.TabPages[6].PageEnabled = false;

                    txtADUsername.Focus();
                    BtnADEdit.Enabled = false;
                    BtnADSave.Enabled = true;
                    BtnADCancel.Enabled = true;
                    BtnADSwitch.Enabled = false;
                    BtnADRefresh.Enabled = false;
                    btnPic.Enabled = true;

                    controlNavigatorAD.Buttons.First.Enabled = false;
                    controlNavigatorAD.Buttons.Next.Enabled = false;
                    controlNavigatorAD.Buttons.Prev.Enabled = false;
                    controlNavigatorAD.Buttons.Last.Enabled = false;

                    searchControlAD.Enabled = false;
                    gridControlAD.Enabled = false;

                    txtADPassword.Text = "";
                    txtADConfirmPassword.Text = "";
                } else if (e.Button.Tag.ToString() == "Save") {

                    if (actionState == "e") {
                        toolStripStatusLabelAD.Text = "Editing...";
                        sqlcmd = new SqlCommand("SELECT MemberID FROM vwMember WHERE LicenseNumber = '" + txtADLicenseNumber.Text + "' ", Misc.getConn());
                        Misc.connOpen();
                        int memberID = (int)sqlcmd.ExecuteScalar();

                        if (txtADUsername.Text.Trim() == "") {
                            MessageBox.Show("Username cannot be empty!", "Account Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtADUsername.Focus();
                            return;
                        }

                        if (cbADChangePassword.Checked) {
                            if (txtADPassword.Text.Trim() == "") {
                                MessageBox.Show("Password cannot be empty!", "Account Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtADPassword.Focus();
                                return;
                            }

                            if (txtADConfirmPassword.Text.Trim() == "") {
                                MessageBox.Show("Enter password to confirm!", "Account Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtADConfirmPassword.Focus();
                                return;
                            }

                            if (!txtADPassword.Text.Equals(txtADConfirmPassword.Text)) {
                                MessageBox.Show("Passwords do not match!", "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txtADPassword.SelectAll();
                                txtADPassword.Focus();
                                return;
                            }

                            sqlcmd = new SqlCommand("UPDATE UserAccount SET Username = @Username, Password = @Password, Administrator = @Administrator, Active = @Active WHERE MemberID = '" + memberID + "' ", Misc.getConn());

                            sqlcmd.Parameters.AddWithValue("@Username", txtADUsername.Text);
                            sqlcmd.Parameters.AddWithValue("@Password", txtADPassword.Text);
                            sqlcmd.Parameters.AddWithValue("@Administrator", cbADAdministrator.Checked);
                            sqlcmd.Parameters.AddWithValue("@Active", cbADAccountActive.Checked);
                        } else {
                            sqlcmd = new SqlCommand("UPDATE UserAccount SET Username = @Username, Administrator = @Administrator, Active = @Active WHERE MemberID = '" + memberID + "' ", Misc.getConn());

                            sqlcmd.Parameters.AddWithValue("@Username", txtADUsername.Text);
                            sqlcmd.Parameters.AddWithValue("@Administrator", cbADAdministrator.Checked);
                            sqlcmd.Parameters.AddWithValue("@Active", cbADAccountActive.Checked);
                        }
                    }

                    Misc.connOpen();
                    sqlcmd.ExecuteNonQuery();
                    sqlcmd.Dispose();

                    actionState = "a";

                    gridControlAD.DataSource = Misc.loadDataSource(sqlQuery, "vwMember");
                    setControlStateAD(false);
                    BtnADSave.Enabled = false;
                    BtnADEdit.Enabled = true;
                    BtnADAdd.Enabled = true;
                    BtnADCancel.Enabled = false;
                    BtnADSwitch.Enabled = true;
                    BtnADRefresh.Enabled = true;
                    btnPic.Enabled = false;

                    controlNavigatorAD.Buttons.First.Enabled = true;
                    controlNavigatorAD.Buttons.Next.Enabled = true;
                    controlNavigatorAD.Buttons.Prev.Enabled = true;
                    controlNavigatorAD.Buttons.Last.Enabled = true;

                    searchControlAD.Enabled = true;
                    gridControlAD.Enabled = true;
                    setTabState(true);
                    gridControlAD.DataSource = Misc.loadDataSource(sqlQuery, "vwMember");
                    toolStripStatusLabelAD.Text = "Saved";

                } else if (e.Button.Tag.ToString() == "Cancel") {
                    setControlStateAD(false);
                    actionState = "a";
                    BtnADAdd.Enabled = false;
                    BtnADEdit.Enabled = true;
                    BtnADSave.Enabled = false;
                    BtnADCancel.Enabled = false;
                    BtnADSwitch.Enabled = true;
                    BtnADRefresh.Enabled = true;
                    btnPic.Enabled = false;

                    controlNavigatorAD.Buttons.First.Enabled = true;
                    controlNavigatorAD.Buttons.Next.Enabled = true;
                    controlNavigatorAD.Buttons.Prev.Enabled = true;
                    controlNavigatorAD.Buttons.Last.Enabled = true;

                    searchControlAD.Enabled = true;
                    gridControlAD.Enabled = true;
                    setTabState(true);

                    toolStripStatusLabelAD.Text = "Done";

                } else if (e.Button.Tag.ToString() == "Refresh") {
                    toolStripStatusLabelAD.Text = "Refreshing...";
                    gridControlAD.DataSource = Misc.loadDataSource(sqlQuery, "vwMember");
                    toolStripStatusLabelAD.Text = "Done";

                } else if (e.Button.Tag.ToString() == "Switch") {
                    if (tableLayoutPanel52.RowStyles[2].Height == 144) {
                        tableLayoutPanel52.RowStyles[2].Height = 1;
                    } else {
                        tableLayoutPanel52.RowStyles[2].Height = 144;
                    }
                }
            //} catch {

            //}
        }

        private void gridViewAD_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            selectionChangedAD();
            setControlValuesAD();
        }

        private void gridViewARUsers_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e) {
            selectionChangedAR();
            setControlValuesAR();
        }

        private void gridViewARUsers_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e) {
            selectionChangedAR();
            setControlValuesAR();
        }

        private void controlNavigatorAR_ButtonClick(object sender, NavigatorButtonClickEventArgs e) {

            if (e.Button.Tag.ToString() == "Save") {
                toolStripStatusLabelAR.Text = "Saving...";
                DataRow[] rows = new DataRow[gridViewARAccessRights.RowCount];
                for (int j = 0; j < gridViewARAccessRights.RowCount; j++) {
                    rows[j] = gridViewARAccessRights.GetDataRow(j);

                    // end editing of gridview
                    if (gridViewARAccessRights.IsEditing)
                        gridViewARAccessRights.CloseEditor();

                    bool access = (bool)rows[j]["Access"];
                    string displayName = rows[j]["DisplayName"].ToString();

                    sqlcmd = new SqlCommand("SELECT FormID FROM Form WHERE DisplayName = '" + displayName + "' ", Misc.getConn());
                    Misc.connOpen();
                    int formID = (int)sqlcmd.ExecuteScalar();

                    sqlcmd = new SqlCommand("UPDATE AppAccess SET Access = '" + access + "' WHERE FormID = '" + formID + "' AND MemberID = '" + memberIDforAccessRight + "' ", Misc.getConn());
                    Misc.connOpen();
                    sqlcmd.ExecuteNonQuery();
                    sqlcmd.Dispose();

                    toolStripStatusLabelAR.Text = "Saved";
                }
            } else if (e.Button.Tag.ToString() == "Switch") {
                if (tableLayoutPanel1.RowStyles[2].Height == 94) {
                    tableLayoutPanel1.RowStyles[2].Height = 1;
                } else {
                    tableLayoutPanel1.RowStyles[2].Height = 94;
                }
            } else if (e.Button.Tag.ToString() == "Refresh") {
                toolStripStatusLabelAR.Text = "Refreshing...";
                gridControlARUsers.DataSource = Misc.loadDataSource(sqlQuery, "vwMember");
                toolStripStatusLabelAR.Text = "Done";
            }
        }

        private void btnPic_Click(object sender, EventArgs e) {
            openFileDialog1.Filter = "Image Files(*.jpeg;*.bmp;*.png;*.jpg)|*.jpeg;*.bmp;*.png;*.jpg";
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                pictureBoxPI.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void gridViewAD_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e) {
            selectionChangedAD();
            setControlValuesAD();
        }

        private void cmbMaritalStatus_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void cmbLocRegion_SelectedIndexChanged(object sender, EventArgs e) {
            cmbLocCity.DataSource = Misc.loadDataSource("SELECT Name FROM vwCity WHERE Region = '" + cmbLocRegion.Text + "' ", "vwCity");
            cmbLocCity.DisplayMember = "Name";
        }

        private void controlNavigatorKD_ButtonClick(object sender, NavigatorButtonClickEventArgs e) {
            try {

                if (e.Button.Tag.ToString() == "Edit") {
                    if (tableLayoutPanel14.RowStyles[2].Height == 1)
                        tableLayoutPanel14.RowStyles[2].Height = 146;
                    actionState = "e";
                    setControlStateKD(true);

                    xtraTabControl1.TabPages[0].PageEnabled = false;
                    xtraTabControl1.TabPages[1].PageEnabled = false;
                    xtraTabControl1.TabPages[2].PageEnabled = true;
                    xtraTabControl1.TabPages[3].PageEnabled = false;
                    xtraTabControl1.TabPages[4].PageEnabled = false;
                    xtraTabControl1.TabPages[5].PageEnabled = false;
                    xtraTabControl1.TabPages[6].PageEnabled = false;

                    txtKDKinName.Focus();
                    BtnKDEdit.Enabled = false;
                    BtnKDSave.Enabled = true;
                    BtnKDCancel.Enabled = true;
                    BtnKDSwitch.Enabled = false;
                    BtnKDRefresh.Enabled = false;
                    btnPic.Enabled = true;

                    controlNavigatorKD.Buttons.First.Enabled = false;
                    controlNavigatorKD.Buttons.Next.Enabled = false;
                    controlNavigatorKD.Buttons.Prev.Enabled = false;
                    controlNavigatorKD.Buttons.Last.Enabled = false;

                    searchControlKD.Enabled = false;
                    gridControlKD.Enabled = false;
                } else if (e.Button.Tag.ToString() == "Save") {

                    if (actionState == "e") {
                        toolStripStatusLabelKD.Text = "Editing...";
                        sqlcmd = new SqlCommand("SELECT MemberID FROM vwMember WHERE LicenseNumber = '" + txtKDLicenseNumber.Text + "' ", Misc.getConn());
                        Misc.connOpen();
                        int memberID = (int)sqlcmd.ExecuteScalar();

                        sqlcmd = new SqlCommand("UPDATE Member SET KinName = @KinName, KinContact = @KinContact WHERE MemberID = '" + memberID + "' ", Misc.getConn());
                    }

                    sqlcmd.Parameters.AddWithValue("@KinName", txtKDKinName.Text);
                    sqlcmd.Parameters.AddWithValue("@KinContact", txtKDKinContact.Text);

                    Misc.connOpen();
                    sqlcmd.ExecuteNonQuery();
                    sqlcmd.Dispose();

                    actionState = "a";

                    gridControlKD.DataSource = Misc.loadDataSource(sqlQuery, "vwMember");
                    setControlStateKD(false);
                    BtnKDSave.Enabled = false;
                    BtnKDEdit.Enabled = true;
                    BtnKDAdd.Enabled = true;
                    BtnKDCancel.Enabled = false;
                    BtnKDSwitch.Enabled = true;
                    BtnKDRefresh.Enabled = true;
                    btnPic.Enabled = false;

                    controlNavigatorKD.Buttons.First.Enabled = true;
                    controlNavigatorKD.Buttons.Next.Enabled = true;
                    controlNavigatorKD.Buttons.Prev.Enabled = true;
                    controlNavigatorKD.Buttons.Last.Enabled = true;

                    searchControlKD.Enabled = true;
                    gridControlKD.Enabled = true;
                    setTabState(true);
                    gridControlKD.DataSource = Misc.loadDataSource(sqlQuery, "vwMember");
                    toolStripStatusLabelKD.Text = "Saved";

                } else if (e.Button.Tag.ToString() == "Cancel") {
                    setControlStateKD(false);
                    actionState = "a";
                    BtnKDAdd.Enabled = false;
                    BtnKDEdit.Enabled = true;
                    BtnKDSave.Enabled = false;
                    BtnKDCancel.Enabled = false;
                    BtnKDSwitch.Enabled = true;
                    BtnKDRefresh.Enabled = true;
                    btnPic.Enabled = false;

                    controlNavigatorKD.Buttons.First.Enabled = true;
                    controlNavigatorKD.Buttons.Next.Enabled = true;
                    controlNavigatorKD.Buttons.Prev.Enabled = true;
                    controlNavigatorKD.Buttons.Last.Enabled = true;

                    searchControlKD.Enabled = true;
                    gridControlKD.Enabled = true;
                    setTabState(true);

                    toolStripStatusLabelKD.Text = "Done";

                } else if (e.Button.Tag.ToString() == "Refresh") {
                    toolStripStatusLabelKD.Text = "Refreshing...";
                    gridControlKD.DataSource = Misc.loadDataSource(sqlQuery, "vwMember");
                    toolStripStatusLabelKD.Text = "Done";

                } else if (e.Button.Tag.ToString() == "Switch") {
                    if (tableLayoutPanel14.RowStyles[2].Height == 146) {
                        tableLayoutPanel14.RowStyles[2].Height = 1;
                    } else {
                        tableLayoutPanel14.RowStyles[2].Height = 146;
                    }
                }
            } catch {

            }
        }

        private void setControlStateCI(bool status) {
            txtCIPhoneNumber1.Enabled = status;
            txtCIPhoneNumber2.Enabled = status;
            txtCIEmailAddress.Enabled = status;
            btnPic.Enabled = status;
        }

        private void setControlStateKD(bool status) {
            txtKDKinName.Enabled = status;
            txtKDKinContact.Enabled = status;
        }

        private void setControlStateLoc(bool status) {
            cmbLocRegion.Enabled = status;
            cmbLocCity.Enabled = status;
            txtBusinessAddress.Enabled = status;
            txtResidentialAddress.Enabled = status;
        }

        private void setControlStateBD(bool status) {
            cmbBDBankName.Enabled = status;
            cmbBDBranchName.Enabled = status;
            txtBDAccountName.Enabled = status;
            txtBDAccountNumber.Enabled = status;
        }

        private void setControlStateAD(bool status) {
            txtADUsername.Enabled = status;
            txtADPassword.Enabled = status;
            txtADConfirmPassword.Enabled = status;
            cbADAdministrator.Enabled = status;
            cbADAccountActive.Enabled = status;
        }

        private void setControlStateAR(bool status) {
            //gridControlARAccessRights.Enabled = status;
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
            try {

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

                    gridControlCI.DataSource = Misc.loadDataSource(sqlQuery, "vwMember");
                    setControlStateCI(false);
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
                    BtnCIAdd.Enabled = false;
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
            } catch {

            }
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
            cmbStatus.Text = "";
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

        private void selectionChangedKD() {
            setTabState(true);
            setControlStateKD(false);

            BtnKDAdd.Enabled = false;
            BtnKDEdit.Enabled = true;
            BtnKDSave.Enabled = false;
            BtnKDCancel.Enabled = false;
            BtnKDSwitch.Enabled = true;
            BtnKDRefresh.Enabled = true;
            btnPic.Enabled = true;
        }

        private void selectionChangedLoc() {
            setTabState(true);
            setControlStateLoc(false);

            BtnLocAdd.Enabled = false;
            BtnLocEdit.Enabled = true;
            BtnLocSave.Enabled = false;
            BtnLocCancel.Enabled = false;
            BtnLocSwitch.Enabled = true;
            BtnLocRefresh.Enabled = true;
            btnPic.Enabled = true;
        }

        private void selectionChangedBD() {
            setTabState(true);
            setControlStateBD(false);

            BtnBDAdd.Enabled = false;
            BtnBDEdit.Enabled = true;
            BtnBDSave.Enabled = false;
            BtnBDCancel.Enabled = false;
            BtnBDSwitch.Enabled = true;
            BtnBDRefresh.Enabled = true;
            btnPic.Enabled = true;
        }

        private void selectionChangedAD() {
            setTabState(true);
            setControlStateAD(false);

            BtnADAdd.Enabled = false;
            BtnADEdit.Enabled = true;
            BtnADSave.Enabled = false;
            BtnADCancel.Enabled = false;
            BtnADSwitch.Enabled = true;
            BtnADRefresh.Enabled = true;
            btnPic.Enabled = true;
        }

        private void selectionChangedAR() {
            setTabState(true);
            setControlStateAR(false);

            BtnARAdd.Enabled = false;
            BtnAREdit.Enabled = false;
            BtnARSave.Enabled = true;
            BtnARCancel.Enabled = false;
            BtnARSwitch.Enabled = true;
            BtnARRefresh.Enabled = true;
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

            pictureBoxPI.Image = Misc.loadImage(licenseNumber);
            txtLicenseNo.Text = licenseNumber;
            cmbGender.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Gender").ToString();
            deDOB.DateTime = (DateTime)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DateOfBirth");
            cmbMaritalStatus.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MaritalStatus").ToString();
            txtHometown.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Hometown").ToString();
            txtInductionYear.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "InductionYear").ToString();
            cmbStatus.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "Status").ToString();
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

            pictureBoxCI.Image = Misc.loadImage(licenseNumber);
            txtCIFirstName.Text = firstName;
            txtCIMiddleName.Text = middleName;
            txtCILastName.Text = lastName;
            txtCILicenseNumber.Text = licenseNumber;
            txtCIPhoneNumber1.Text = gridViewCI.GetRowCellValue(gridViewCI.FocusedRowHandle, "PhoneNumber1").ToString();
            txtCIPhoneNumber2.Text = gridViewCI.GetRowCellValue(gridViewCI.FocusedRowHandle, "PhoneNumber2").ToString();
            txtCIEmailAddress.Text = gridViewCI.GetRowCellValue(gridViewCI.FocusedRowHandle, "EmailAddress").ToString();
        }

        private void setControlValuesKD() {
            string firstName = "";
            string middleName = "";
            string lastName = "";
            string licenseNumber = gridViewKD.GetRowCellValue(gridViewKD.FocusedRowHandle, "LicenseNumber").ToString();
            sqlcmd = new SqlCommand("SELECT FirstName, MiddleName, LastName FROM Member WHERE LicenseNumber = '" + licenseNumber + "' ", Misc.getConn());
            SqlDataReader dReader = sqlcmd.ExecuteReader();
            Misc.connOpen();
            while (dReader.Read()) {
                firstName = dReader.GetString(0);
                middleName = dReader.GetString(1);
                lastName = dReader.GetString(2);
            }
            dReader.Close();

            pictureBoxKD.Image = Misc.loadImage(licenseNumber);
            txtKDFirstName.Text = firstName;
            txtKDMiddleName.Text = middleName;
            txtKDLastName.Text = lastName;
            txtKDLicenseNumber.Text = licenseNumber;
            txtKDKinName.Text = gridViewKD.GetRowCellValue(gridViewKD.FocusedRowHandle, "KinName").ToString();
            txtKDKinContact.Text = gridViewKD.GetRowCellValue(gridViewKD.FocusedRowHandle, "KinContact").ToString();
        }

        private void setControlValuesLoc() {
            string firstName = "";
            string middleName = "";
            string lastName = "";
            string licenseNumber = gridViewLoc.GetRowCellValue(gridViewLoc.FocusedRowHandle, "LicenseNumber").ToString();
            sqlcmd = new SqlCommand("SELECT FirstName, MiddleName, LastName FROM Member WHERE LicenseNumber = '" + licenseNumber + "' ", Misc.getConn());
            SqlDataReader dReader = sqlcmd.ExecuteReader();
            Misc.connOpen();
            while (dReader.Read()) {
                firstName = dReader.GetString(0);
                middleName = dReader.GetString(1);
                lastName = dReader.GetString(2);
            }
            dReader.Close();

            pictureBoxLoc.Image = Misc.loadImage(licenseNumber);
            txtLocFirstName.Text = firstName;
            txtLocMiddleName.Text = middleName;
            txtLocLastName.Text = lastName;
            txtLocLicenseNumber.Text = licenseNumber;
            cmbLocRegion.Text = gridViewLoc.GetRowCellValue(gridViewLoc.FocusedRowHandle, "RegionName").ToString();
            cmbLocCity.Text = gridViewLoc.GetRowCellValue(gridViewLoc.FocusedRowHandle, "CityName").ToString();
            txtResidentialAddress.Text = gridViewLoc.GetRowCellValue(gridViewLoc.FocusedRowHandle, "ResidentialAddress").ToString();
            txtBusinessAddress.Text = gridViewLoc.GetRowCellValue(gridViewLoc.FocusedRowHandle, "BusinessAddress").ToString();
        }

        private void setControlValuesBD() {
            string firstName = "";
            string middleName = "";
            string lastName = "";
            string licenseNumber = gridViewBD.GetRowCellValue(gridViewBD.FocusedRowHandle, "LicenseNumber").ToString();
            sqlcmd = new SqlCommand("SELECT FirstName, MiddleName, LastName FROM Member WHERE LicenseNumber = '" + licenseNumber + "' ", Misc.getConn());
            SqlDataReader dReader = sqlcmd.ExecuteReader();
            Misc.connOpen();
            while (dReader.Read()) {
                firstName = dReader.GetString(0);
                middleName = dReader.GetString(1);
                lastName = dReader.GetString(2);
            }
            dReader.Close();

            pictureBoxBD.Image = Misc.loadImage(licenseNumber);
            txtBDFirstName.Text = firstName;
            txtBDMiddleName.Text = middleName;
            txtBDLastName.Text = lastName;
            txtBDLicenseNumber.Text = licenseNumber;
            cmbBDBankName.Text = gridViewBD.GetRowCellValue(gridViewBD.FocusedRowHandle, "BankName").ToString();
            cmbBDBranchName.Text = gridViewBD.GetRowCellValue(gridViewBD.FocusedRowHandle, "BankBranchName").ToString();
            txtBDAccountName.Text = gridViewBD.GetRowCellValue(gridViewBD.FocusedRowHandle, "AccountName").ToString();
            txtBDAccountNumber.Text = gridViewBD.GetRowCellValue(gridViewBD.FocusedRowHandle, "AccountNumber").ToString();
        }

        private void setControlValuesAD() {
            string firstName = "";
            string middleName = "";
            string lastName = "";
            string licenseNumber = gridViewAD.GetRowCellValue(gridViewAD.FocusedRowHandle, "LicenseNumber").ToString();
            sqlcmd = new SqlCommand("SELECT FirstName, MiddleName, LastName FROM Member WHERE LicenseNumber = '" + licenseNumber + "' ", Misc.getConn());
            SqlDataReader dReader = sqlcmd.ExecuteReader();
            Misc.connOpen();
            while (dReader.Read()) {
                firstName = dReader.GetString(0);
                middleName = dReader.GetString(1);
                lastName = dReader.GetString(2);
            }
            dReader.Close();

            pictureBoxAD.Image = Misc.loadImage(licenseNumber);
            txtADFirstName.Text = firstName;
            txtADMiddleName.Text = middleName;
            txtADLastName.Text = lastName;
            txtADLicenseNumber.Text = licenseNumber;
            txtADUsername.Text = gridViewAD.GetRowCellValue(gridViewAD.FocusedRowHandle, "Username").ToString();
            txtADPassword.Text = "ThisIsMyPassword";
            txtADConfirmPassword.Text = "ThisIsMyPassword";
            cbADAdministrator.Checked = (bool)gridViewAD.GetRowCellValue(gridViewAD.FocusedRowHandle, "Administrator");
            cbADAccountActive.Checked = (bool)gridViewAD.GetRowCellValue(gridViewAD.FocusedRowHandle, "AccountActive");
        }

        private void setControlValuesAR() {
            txtARLicenseNumber.Text = gridViewARUsers.GetRowCellValue(gridViewARUsers.FocusedRowHandle, "LicenseNumber").ToString();
            txtARUsername.Text = gridViewARUsers.GetRowCellValue(gridViewARUsers.FocusedRowHandle, "Username").ToString();

            gridControlARAccessRights.DataSource = Misc.loadDataSource("SELECT DisplayName, FormDescription, Access FROM vwAppAccess WHERE LicenseNumber = '" + txtARLicenseNumber.Text + "' AND Active = 'True'", "vwAppAccess");

            sqlcmd = new SqlCommand("SELECT MemberID FROM Member WHERE LicenseNumber = '" + txtARLicenseNumber.Text + "' ", Misc.getConn());
            Misc.connOpen();
            memberIDforAccessRight = (int)sqlcmd.ExecuteScalar();
            pictureBoxAR.Image = Misc.loadImage(txtARLicenseNumber.Text);
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

        private void loadKinDetails() {
            BtnKDAdd = controlNavigatorKD.Buttons.CustomButtons[0];
            BtnKDEdit = controlNavigatorKD.Buttons.CustomButtons[1];
            BtnKDSave = controlNavigatorKD.Buttons.CustomButtons[2];
            BtnKDCancel = controlNavigatorKD.Buttons.CustomButtons[3];
            BtnKDSwitch = controlNavigatorKD.Buttons.CustomButtons[4];
            BtnKDRefresh = controlNavigatorKD.Buttons.CustomButtons[5];

            BtnKDAdd.Enabled = false;
            BtnKDEdit.Enabled = true;
            BtnKDSave.Enabled = false;
            BtnKDCancel.Enabled = false;
            BtnKDSwitch.Enabled = true;
            BtnKDRefresh.Enabled = true;
            btnPic.Enabled = true;
        }

        private void loadLocation() {
            BtnLocAdd = controlNavigatorLoc.Buttons.CustomButtons[0];
            BtnLocEdit = controlNavigatorLoc.Buttons.CustomButtons[1];
            BtnLocSave = controlNavigatorLoc.Buttons.CustomButtons[2];
            BtnLocCancel = controlNavigatorLoc.Buttons.CustomButtons[3];
            BtnLocSwitch = controlNavigatorLoc.Buttons.CustomButtons[4];
            BtnLocRefresh = controlNavigatorLoc.Buttons.CustomButtons[5];

            BtnLocAdd.Enabled = false;
            BtnLocEdit.Enabled = true;
            BtnLocSave.Enabled = false;
            BtnLocCancel.Enabled = false;
            BtnLocSwitch.Enabled = true;
            BtnLocRefresh.Enabled = true;
            btnPic.Enabled = true;

            cmbLocRegion.DataSource = Misc.loadDataSource(sqlQueryRegion, "Region");
            cmbLocRegion.DisplayMember = "Name";
        }

        private void loadBankDetails() {
            BtnBDAdd = controlNavigatorBD.Buttons.CustomButtons[0];
            BtnBDEdit = controlNavigatorBD.Buttons.CustomButtons[1];
            BtnBDSave = controlNavigatorBD.Buttons.CustomButtons[2];
            BtnBDCancel = controlNavigatorBD.Buttons.CustomButtons[3];
            BtnBDSwitch = controlNavigatorBD.Buttons.CustomButtons[4];
            BtnBDRefresh = controlNavigatorBD.Buttons.CustomButtons[5];

            BtnBDAdd.Enabled = false;
            BtnBDEdit.Enabled = true;
            BtnBDSave.Enabled = false;
            BtnBDCancel.Enabled = false;
            BtnBDSwitch.Enabled = true;
            BtnBDRefresh.Enabled = true;
            btnPic.Enabled = true;

            cmbBDBankName.DataSource = Misc.loadDataSource(sqlQueryBank, "Bank");
            cmbBDBankName.DisplayMember = "Name";
        }

        private void loadAccountDetails() {
            BtnADAdd = controlNavigatorAD.Buttons.CustomButtons[0];
            BtnADEdit = controlNavigatorAD.Buttons.CustomButtons[1];
            BtnADSave = controlNavigatorAD.Buttons.CustomButtons[2];
            BtnADCancel = controlNavigatorAD.Buttons.CustomButtons[3];
            BtnADSwitch = controlNavigatorAD.Buttons.CustomButtons[4];
            BtnADRefresh = controlNavigatorAD.Buttons.CustomButtons[5];

            BtnADAdd.Enabled = false;
            BtnADEdit.Enabled = true;
            BtnADSave.Enabled = false;
            BtnADCancel.Enabled = false;
            BtnADSwitch.Enabled = true;
            BtnADRefresh.Enabled = true;
            btnPic.Enabled = true;
        }

        private void loadAccessRights() {
            BtnARAdd = controlNavigatorAR.Buttons.CustomButtons[0];
            BtnAREdit = controlNavigatorAR.Buttons.CustomButtons[1];
            BtnARSave = controlNavigatorAR.Buttons.CustomButtons[2];
            BtnARCancel = controlNavigatorAR.Buttons.CustomButtons[3];
            BtnARSwitch = controlNavigatorAR.Buttons.CustomButtons[4];
            BtnARRefresh = controlNavigatorAR.Buttons.CustomButtons[5];

            BtnARAdd.Enabled = false;
            BtnAREdit.Enabled = false;
            BtnARSave.Enabled = true;
            BtnARCancel.Enabled = false;
            BtnARSwitch.Enabled = true;
            BtnARRefresh.Enabled = true;
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
