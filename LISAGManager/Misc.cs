using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace LISAGManager {
    class Misc {
        public static string loginName { get; set; }
        private static SqlConnection conn { get; set; }
        private static AppUser user { get; set; }

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
        public bool goodStanding { get; set; }
        public bool active { get; set; }
    }
}
