using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LISAGManager {
    public partial class FrmDashboard : Form {

        private FrmSurveyors fSurveyors;
        private FrmRegion fRegion;
        private FrmCity fCity;
        private FrmBank fBank;
        private FrmLogin fLogin;
        private FrmChangePassword fChangePassword;
        private FrmActivityLog fActivityLog;
        private FrmAgents fAgents;
        private FrmMyAgents fMyAgents;
        private FrmBankBranch fBankBranch;
        private FrmMe fMe;
        private FrmManageAccount fManageAccount;
        private FrmAgent fAgent;

        public FrmDashboard() {
            InitializeComponent();
        }

        private void launchSurveyors() {
            if (fSurveyors != null) {
                if (!fSurveyors.IsDisposed) {
                    fSurveyors.MdiParent = this;
                    fSurveyors.WindowState = FormWindowState.Normal;
                    fSurveyors.BringToFront();
                } else {
                    fSurveyors = new FrmSurveyors();
                    fSurveyors.MdiParent = this;
                    fSurveyors.Show();
                }
            } else {
                fSurveyors = new FrmSurveyors();
                fSurveyors.MdiParent = this;
                fSurveyors.Show();
            }
        }

        private void launchRegionSetup() {
            if (fRegion != null) {
                if (!fRegion.IsDisposed) {
                    fRegion.MdiParent = this;
                    fRegion.WindowState = FormWindowState.Normal;
                    fRegion.BringToFront();
                } else {
                    fRegion = new FrmRegion();
                    fRegion.MdiParent = this;
                    fRegion.Show();
                }
            } else {
                fRegion = new FrmRegion();
                fRegion.MdiParent = this;
                fRegion.Show();
            }
        }

        private void launchCitySetup() {
            if (fCity != null) {
                if (!fCity.IsDisposed) {
                    fCity.MdiParent = this;
                    fCity.WindowState = FormWindowState.Normal;
                    fCity.BringToFront();
                } else {
                    fCity = new FrmCity();
                    fCity.MdiParent = this;
                    fCity.Show();
                }
            } else {
                fCity = new FrmCity();
                fCity.MdiParent = this;
                fCity.Show();
            }
        }

        private void launchBankSetup() {
            if (fBank != null) {
                if (!fBank.IsDisposed) {
                    fBank.MdiParent = this;
                    fBank.WindowState = FormWindowState.Normal;
                    fBank.BringToFront();
                } else {
                    fBank = new FrmBank();
                    fBank.MdiParent = this;
                    fBank.Show();
                }
            } else {
                fBank = new FrmBank();
                fBank.MdiParent = this;
                fBank.Show();
            }
        }

        private void logOut() {
            Misc.logActivity(Misc.getUser().appUserID, "logged out");
            this.Close();

            fLogin = new FrmLogin();

            fLogin.Show();

        }

        private void launchChangePassword() {
            if (fChangePassword != null) {
                if (!fChangePassword.IsDisposed) {
                    fChangePassword.MdiParent = this;
                    fChangePassword.WindowState = FormWindowState.Normal;
                    fChangePassword.BringToFront();
                } else {
                    fChangePassword = new FrmChangePassword();
                    fChangePassword.MdiParent = this;
                    fChangePassword.Show();
                }
            } else {
                fChangePassword = new FrmChangePassword();
                fChangePassword.MdiParent = this;
                fChangePassword.Show();
            }
        }

        private void launchActivityLog() {
            if (fActivityLog != null) {
                if (!fActivityLog.IsDisposed) {
                    fActivityLog.MdiParent = this;
                    fActivityLog.WindowState = FormWindowState.Normal;
                    fActivityLog.BringToFront();
                } else {
                    fActivityLog = new FrmActivityLog();
                    fActivityLog.MdiParent = this;
                    fActivityLog.Show();
                }
            } else {
                fActivityLog = new FrmActivityLog();
                fActivityLog.MdiParent = this;
                fActivityLog.Show();
            }
        }

        private void launchAgents() {
            if (fAgents != null) {
                if (!fAgents.IsDisposed) {
                    fAgents.MdiParent = this;
                    fAgents.WindowState = FormWindowState.Normal;
                    fAgents.BringToFront();
                } else {
                    fAgents = new FrmAgents();
                    fAgents.MdiParent = this;
                    fAgents.Show();
                }
            } else {
                fAgents = new FrmAgents();
                fAgents.MdiParent = this;
                fAgents.Show();
            }
        }

        private void launchMyAgents() {
            if (fMyAgents != null) {
                if (!fMyAgents.IsDisposed) {
                    fMyAgents.MdiParent = this;
                    fMyAgents.WindowState = FormWindowState.Normal;
                    fMyAgents.BringToFront();
                } else {
                    fMyAgents = new FrmMyAgents();
                    fMyAgents.MdiParent = this;
                    fMyAgents.Show();
                }
            } else {
                fMyAgents = new FrmMyAgents();
                fMyAgents.MdiParent = this;
                fMyAgents.Show();
            }
        }

        private void launchBankBranch() {
            if (fBankBranch != null) {
                if (!fBankBranch.IsDisposed) {
                    fBankBranch.MdiParent = this;
                    fBankBranch.WindowState = FormWindowState.Normal;
                    fBankBranch.BringToFront();
                } else {
                    fBankBranch = new FrmBankBranch();
                    fBankBranch.MdiParent = this;
                    fBankBranch.Show();
                }
            } else {
                fBankBranch = new FrmBankBranch();
                fBankBranch.MdiParent = this;
                fBankBranch.Show();
            }
        }

        private void launchMe() {
            if (fMe != null) {
                if (!fMe.IsDisposed) {
                    fMe.MdiParent = this;
                    fMe.WindowState = FormWindowState.Normal;
                    fMe.BringToFront();
                } else {
                    fMe = new FrmMe();
                    fMe.MdiParent = this;
                    fMe.Show();
                }
            } else {
                fMe = new FrmMe();
                fMe.MdiParent = this;
                fMe.Show();
            }
        }

        private void launchManageAccount() {
            if (fManageAccount != null) {
                if (!fManageAccount.IsDisposed) {
                    fManageAccount.MdiParent = this;
                    fManageAccount.WindowState = FormWindowState.Normal;
                    fManageAccount.BringToFront();
                } else {
                    fManageAccount = new FrmManageAccount();
                    fManageAccount.MdiParent = this;
                    fManageAccount.Show();
                }
            } else {
                fManageAccount = new FrmManageAccount();
                fManageAccount.MdiParent = this;
                fManageAccount.Show();
            }
        }

        private void launchAgent() {
            if (fAgent != null) {
                if (!fAgent.IsDisposed) {
                    fAgent.MdiParent = this;
                    fAgent.WindowState = FormWindowState.Normal;
                    fAgent.BringToFront();
                } else {
                    fAgent = new FrmAgent();
                    fAgent.MdiParent = this;
                    fAgent.Show();
                }
            } else {
                fAgent = new FrmAgent();
                fAgent.MdiParent = this;
                fAgent.Show();
            }
        }

        private void FrmDashboard_Load(object sender, EventArgs e) {

        }

        private void nbiSurveyors_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e) {
            launchSurveyors();
        }

        private void nbiRegion_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e) {
            launchRegionSetup();
        }

        private void nbiCity_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e) {
            launchCitySetup();
        }

        private void nbiBank_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e) {
            launchBankSetup();
        }

        private void nbiLogOut_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e) {
            logOut();
        }

        private void nbiChangePassword_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e) {
            launchChangePassword();
        }

        private void nbiActivityLog_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e) {
            launchActivityLog();
        }

        private void nbiAgents_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e) {
            launchAgents();
        }

        private void nbiMyAgents_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e) {
            launchMyAgents();
        }

        private void nbiBankBranch_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e) {
            launchBankBranch();
        }

        private void nbiMyProfile_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e) {
            launchMe();
        }

        private void nbiManageAccount_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e) {
            launchManageAccount();
        }

        private void nbiSetupAgent_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e) {
            launchAgent();
        }
    }
}
