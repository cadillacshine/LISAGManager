using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace LISAGManager {
    class Misc {
        public static string loginName { get; set; }
        private static SqlConnection conn { get; set; }
        private static AppUser user { get; set; }

        public struct strAccess {
            public string name;
            public int ID;
        }

        public static void setConn(string connection) {
            if (connection == "Production")
                conn = new SqlConnection(@"data source=FIVE\FIVE14;initial catalog=dbLISAG;integrated security=True");
            else
                conn = new SqlConnection(@"data source=FIVE\FIVE14;initial catalog=dbLISAG;integrated security=True");
        }

        public static SqlConnection getConn() {
            return conn;
        }

        public static void connOpen() {
            if (conn.State == System.Data.ConnectionState.Closed)
                conn.Open();
        }

        public static void connClose() {
            conn.Close();
        }

        public static void setUser(AppUser usr) {
            user = usr;
        }

        public static AppUser getUser() {
            return user;
        }

        public static void verifyUsername(string username) {
            
        }

        public static void logActivity(int memberID, string activity) {
            SqlCommand sqlcmd = new SqlCommand("INSERT INTO ActivityLog(UserAccountID, ActivityTime, Activity) VALUES(@UserAccountID, @ActivityTime, @Activity)", Misc.getConn());
            sqlcmd.Parameters.AddWithValue("@UserAccountID", memberID);
            sqlcmd.Parameters.AddWithValue("ActivityTime", DateTime.Now);
            sqlcmd.Parameters.AddWithValue("@Activity", activity);
            sqlcmd.ExecuteNonQuery();
            sqlcmd.Dispose();
        }

        public static DataTable loadDataSource(String query, string tableOrView) {
            SqlDataAdapter dtAdapter = new SqlDataAdapter(query, Misc.getConn());
            DataTable dTable = new DataTable(tableOrView);
            dtAdapter.Fill(dTable);
            return dTable;
        }

        public static List<strAccess> formIDs() {
            SqlCommand sqlcmd = new SqlCommand();
            
            List<strAccess> list = new List<strAccess>();
            sqlcmd = new SqlCommand("SELECT FormID FROM Form WHERE Name = 'FrmLogin'", Misc.getConn());
            Misc.connOpen();
            int frmLoginID = (int)sqlcmd.ExecuteScalar();
            list.Add(new strAccess {
                name = "FrmLogin",
                ID = frmLoginID
            });

            sqlcmd = new SqlCommand("SELECT FormID FROM Form WHERE Name = 'FrmMe'", Misc.getConn());
            Misc.connOpen();
            int frmMeID = (int)sqlcmd.ExecuteScalar();
            list.Add(new strAccess {
                name = "FrmMe",
                ID = frmMeID
            });

            sqlcmd = new SqlCommand("SELECT FormID FROM Form WHERE Name = 'FrmSurveyors'", Misc.getConn());
            Misc.connOpen();
            int frmSurveyorsID = (int)sqlcmd.ExecuteScalar();
            list.Add(new strAccess {
                name = "FrmSurveyors",
                ID = frmMeID
            });

            sqlcmd = new SqlCommand("SELECT FormID FROM Form WHERE Name = 'FrmRegion'", Misc.getConn());
            Misc.connOpen();
            int frmRegionID = (int)sqlcmd.ExecuteScalar();
            list.Add(new strAccess {
                name = "FrmRegion",
                ID = frmRegionID
            });

            sqlcmd = new SqlCommand("SELECT FormID FROM Form WHERE Name = 'FrmCity'", Misc.getConn());
            Misc.connOpen();
            int frmCityID = (int)sqlcmd.ExecuteScalar();
            list.Add(new strAccess {
                name = "FrmCity",
                ID = frmCityID
            });

            sqlcmd = new SqlCommand("SELECT FormID FROM Form WHERE Name = 'FrmBank'", Misc.getConn());
            Misc.connOpen();
            int frmBankID = (int)sqlcmd.ExecuteScalar();
            list.Add(new strAccess {
                name = "FrmBank",
                ID = frmBankID
            });

            sqlcmd = new SqlCommand("SELECT FormID FROM Form WHERE Name = 'FrmBankBranch'", Misc.getConn());
            Misc.connOpen();
            int frmBankBranchID = (int)sqlcmd.ExecuteScalar();
            list.Add(new strAccess {
                name = "FrmBankBranch",
                ID = frmBankBranchID
            });

            sqlcmd = new SqlCommand("SELECT FormID FROM Form WHERE Name = 'FrmChangePassword'", Misc.getConn());
            Misc.connOpen();
            int frmChangePasswordID = (int)sqlcmd.ExecuteScalar();
            list.Add(new strAccess {
                name = "FrmChangePassword",
                ID = frmChangePasswordID
            });

            sqlcmd = new SqlCommand("SELECT FormID FROM Form WHERE Name = 'FrmActivityLog'", Misc.getConn());
            Misc.connOpen();
            int frmActivityLogID = (int)sqlcmd.ExecuteScalar();
            list.Add(new strAccess {
                name = "FrmActivityLog",
                ID = frmActivityLogID
            });

            sqlcmd = new SqlCommand("SELECT FormID FROM Form WHERE Name = 'FrmAgent'", Misc.getConn());
            Misc.connOpen();
            int frmAgentID = (int)sqlcmd.ExecuteScalar();
            list.Add(new strAccess {
                name = "FrmAgent",
                ID = frmAgentID
            });

            sqlcmd = new SqlCommand("SELECT FormID FROM Form WHERE Name = 'FrmManageAccount'", Misc.getConn());
            Misc.connOpen();
            int frmManageAccountID = (int)sqlcmd.ExecuteScalar();
            list.Add(new strAccess {
                name = "FrmManageAccount",
                ID = frmManageAccountID
            });

            sqlcmd = new SqlCommand("SELECT FormID FROM Form WHERE Name = 'FrmMyAgents'", Misc.getConn());
            Misc.connOpen();
            int frmMyAgentsID = (int)sqlcmd.ExecuteScalar();
            list.Add(new strAccess {
                name = "FrmMyAgents",
                ID = frmMyAgentsID
            });

            sqlcmd = new SqlCommand("SELECT FormID FROM Form WHERE Name = 'FrmAgents'", Misc.getConn());
            Misc.connOpen();
            int frmAgentsID = (int)sqlcmd.ExecuteScalar();
            list.Add(new strAccess {
                name = "FrmAgents",
                ID = frmAgentsID
            });

            return list;
        }

        public static void saveImage(int memberID, string image) {
            Bitmap bmp = new Bitmap(image);
            FileStream fs = new FileStream(image, FileMode.Open, FileAccess.Read);
            byte[] bimage = new byte[fs.Length];
            fs.Read(bimage, 0, Convert.ToInt32(fs.Length));
            fs.Close();
            SqlCommand sqlcmd = new SqlCommand("INSERT INTO MemberImage(MemberID, MemberImage) values(@MemberID, @MemberImage)", Misc.getConn());
            sqlcmd.Parameters.AddWithValue("@MemberID", memberID);
            sqlcmd.Parameters.AddWithValue("@MemberImage", SqlDbType.Image).Value = bimage;
            Misc.connOpen();
            sqlcmd.ExecuteNonQuery();
        }

        public static void saveImage(int memberID, Image image) {
            MemoryStream stream = new MemoryStream();
            image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] pic = stream.ToArray();
            SqlCommand sqlcmd = new SqlCommand("INSERT INTO MemberImage(MemberID, MemberImage) values(@MemberID, @MemberImage)", Misc.getConn());
            sqlcmd.Parameters.AddWithValue("@MemberID", memberID);
            sqlcmd.Parameters.AddWithValue("@MemberImage", pic);
            Misc.connOpen();
            sqlcmd.ExecuteNonQuery();
        }

        public static void saveAgentImage(int agentID, string image) {
            Bitmap bmp = new Bitmap(image);
            FileStream fs = new FileStream(image, FileMode.Open, FileAccess.Read);
            byte[] bimage = new byte[fs.Length];
            fs.Read(bimage, 0, Convert.ToInt32(fs.Length));
            fs.Close();
            SqlCommand sqlcmd = new SqlCommand("INSERT INTO AgentImage(AgentID, AgentImage) values(@AgentID, @AgentImage)", Misc.getConn());
            sqlcmd.Parameters.AddWithValue("@AgentID", agentID);
            sqlcmd.Parameters.AddWithValue("@AgentImage", SqlDbType.Image).Value = bimage;
            Misc.connOpen();
            sqlcmd.ExecuteNonQuery();
        }

        public static void saveAgentImage(int agentID, Image image) {
            MemoryStream stream = new MemoryStream();
            image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] pic = stream.ToArray();
            SqlCommand sqlcmd = new SqlCommand("INSERT INTO AgentImage(AgentID, AgentImage) values(@AgentID, @AgentImage)", Misc.getConn());
            sqlcmd.Parameters.AddWithValue("@AgentID", agentID);
            sqlcmd.Parameters.AddWithValue("@AgentImage", pic);
            Misc.connOpen();
            sqlcmd.ExecuteNonQuery();
        }

        public static void updateImage(int memberID, string image) {
            Bitmap bmp = new Bitmap(image);
            FileStream fs = new FileStream(image, FileMode.Open, FileAccess.Read);
            byte[] bimage = new byte[fs.Length];
            fs.Read(bimage, 0, Convert.ToInt32(fs.Length));
            fs.Close();
            SqlCommand sqlcmd = new SqlCommand("UPDATE MemberImage SET MemberImage = @MemberImage WHERE MemberID = @MemberID", Misc.getConn());
            sqlcmd.Parameters.AddWithValue("@MemberID", memberID);
            sqlcmd.Parameters.AddWithValue("@MemberImage", SqlDbType.Image).Value = bimage;
            Misc.connOpen();
            sqlcmd.ExecuteNonQuery();
        }

        public static void updateImage(int memberID, Image image) {
            MemoryStream stream = new MemoryStream();
            image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] pic = stream.ToArray();
            SqlCommand sqlcmd = new SqlCommand("UPDATE MemberImage SET MemberImage = @MemberImage WHERE MemberID = @MemberID", Misc.getConn());
            sqlcmd.Parameters.AddWithValue("@MemberID", memberID);
            sqlcmd.Parameters.AddWithValue("@MemberImage", pic);
            Misc.connOpen();
            sqlcmd.ExecuteNonQuery();
        }

        public static void updateAgentImage(int agentID, string image) {
            Bitmap bmp = new Bitmap(image);
            FileStream fs = new FileStream(image, FileMode.Open, FileAccess.Read);
            byte[] bimage = new byte[fs.Length];
            fs.Read(bimage, 0, Convert.ToInt32(fs.Length));
            fs.Close();
            SqlCommand sqlcmd = new SqlCommand("UPDATE AgentImage SET AgentImage = @AgentImage WHERE AgentID = @AgentID", Misc.getConn());
            sqlcmd.Parameters.AddWithValue("@AgentID", agentID);
            sqlcmd.Parameters.AddWithValue("@AgentImage", SqlDbType.Image).Value = bimage;
            Misc.connOpen();
            sqlcmd.ExecuteNonQuery();
        }

        public static void updateAgentImage(int agentID, Image image) {
            MemoryStream stream = new MemoryStream();
            image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] pic = stream.ToArray();
            SqlCommand sqlcmd = new SqlCommand("UPDATE AgentImage SET AgentImage = @AgentImage WHERE AgentID = @AgentID", Misc.getConn());
            sqlcmd.Parameters.AddWithValue("@AgentID", agentID);
            sqlcmd.Parameters.AddWithValue("@AgentImage", pic);
            Misc.connOpen();
            sqlcmd.ExecuteNonQuery();
        }

        public static Image loadImage(int memberID) {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT MemberImage FROM MemberImage WHERE MemberID = '" + memberID + "' ", Misc.getConn());
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);

           // if (dataSet.Tables[0].Rows.Count == 1) {
                Byte[] data = new Byte[0];
                data = (Byte[])(dataSet.Tables[0].Rows[0]["MemberImage"]);
                MemoryStream mem = new MemoryStream(data);
                return Image.FromStream(mem);
            //}
        }

        public static Image loadImage(string licenseNumber) {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT MemberImage FROM vwMember WHERE LicenseNumber = '" + licenseNumber + "' ", Misc.getConn());
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);

            // if (dataSet.Tables[0].Rows.Count == 1) {
            Byte[] data = new Byte[0];
            data = (Byte[])(dataSet.Tables[0].Rows[0]["MemberImage"]);
            MemoryStream mem = new MemoryStream(data);
            return Image.FromStream(mem);
            //}
        }

        public static Image loadAgentImage(int agentID) {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT AgentImage FROM AgentImage WHERE AgentID = '" + agentID + "' ", Misc.getConn());
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);

            // if (dataSet.Tables[0].Rows.Count == 1) {
            Byte[] data = new Byte[0];
            data = (Byte[])(dataSet.Tables[0].Rows[0]["AgentImage"]);
            MemoryStream mem = new MemoryStream(data);
            return Image.FromStream(mem);
            //}
        }

        public static Image loadAgentImage(string agentNumber) {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT AgentImage FROM vwAgent WHERE AgentNumber = '" + agentNumber + "' ", Misc.getConn());
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);

            // if (dataSet.Tables[0].Rows.Count == 1) {
            Byte[] data = new Byte[0];
            data = (Byte[])(dataSet.Tables[0].Rows[0]["AgentImage"]);
            MemoryStream mem = new MemoryStream(data);
            return Image.FromStream(mem);
            //}
        }
    }

    class AppUser {
        public int appUserID { get; set; }
        public string username { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string licenseNumber { get; set; } 
        public string gender { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string maritalStatus { get; set; }
        public string hometown { get; set; }
        public string kinName { get; set; }
        public string kinContact { get; set; }
        public string phoneNumber1 { get; set; }
        public string phoneNumber2 { get; set; }
        public string emailAddress { get; set; }
        public string region { get; set; }
        public string city { get; set; }
        public string businessAddress { get; set; }
        public string residentialAddress { get; set; }
        public string bankBranch { get; set; }
        public string bank { get; set; }
        public string accountName { get; set; }
        public string accountNumber { get; set; }
        public int inductionYear { get; set; }
        public string status { get; set; }
        public Access access { get; set; }
        public bool administrator { get; set; }
        public bool active { get; set; }
    }

    class Access {
        public bool login { get; set; }
        public bool dashboard { get; set; }
        public bool me { get; set; }
        public bool surveyors { get; set; }
        public bool region { get; set; }
        public bool city { get; set; }
        public bool bank { get; set; }
        public bool bankBranch { get; set; }
        public bool changePassword { get; set; }
        public bool activityLog { get; set; }
        public bool agents { get; set; }
        public bool setupAgent { get; set; }
        public bool manageAccount { get; set; }
        public bool myAgents { get; set; }
    }
}
