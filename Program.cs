using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using DevExpress.Printing.Native.PrintEditor;

namespace QuanLyVatTu
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static SqlConnection conn = new SqlConnection();
        public static String connstr;
        

        public static SqlDataReader myReader;
        public static String servername = "";
        public static String username = "";
        public static String mlogin = "";
        public static String password = "";

        //DBao Connnection
        public static String connstr_publisher = "Data Source=GODHART-NGUYEN;Initial Catalog=QLVT_DATHANG;Integrated Security=True";
        public static String database = "QLVT_DATHANG";
        public static String remotelogin = "HTKN1";
        public static String remotepassword = "12";



        // TAnh Connection
        //public static String connstr_publisher = "Data Source=DESKTOP-1MDUK92\\MSSQLSERVER1;Initial Catalog=QLVT_DATHANG;Integrated Security=True";
        //public static String database = "QLVT_DATHANG";
        //public static String remotelogin = "HOTROKETNOI";
        //public static String remotepassword = "123";


        public static String mloginDN = "";
        public static String passwordDN = "";
        public static String mGroup = "";
        public static String mHoten = "";

        public static int mChinhanh = 0;

        //DonDatHang 
        public static String maKhodcChon = "";
        public static String maVatTudcChon = "";
        public static String tenVattudcChon = "";
        public static String MaDDHmoi = "";

        //PhieuNhap
        public static String maDDHdcChonTrongPhieuNhap = "";
        public static String maKhodcChonTrongPhieuNhap = "";

        public static BindingSource bds_dspm = new BindingSource();  // giữ bdsPM khi đăng nhập
        public static Form1 frmChinh;

        public static int KetNoi()
        {
            if (Program.conn != null && Program.conn.State == ConnectionState.Open)
            {
                Program.conn.Close();
            }
            try
            {
                Program.connstr = "Data Source=" + Program.servername + ";Initial Catalog=" +
                      Program.database + ";User ID=" +
                      Program.mlogin + ";password=" + Program.password;
                Program.conn.ConnectionString = Program.connstr;
                Program.conn.Open();
                return 1;

            }

            catch (Exception e)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu.\nBạn xem lại user name và password.\n ","Thông báo", MessageBoxButtons.OK);
                return 0;
            }
        }

        public static string ExecuteStoredProcedureFromMainSide( string storedProcedureName)
        {
            string result = null;

            using (SqlConnection connection = new SqlConnection(Program.connstr_publisher))
            {
                using (SqlCommand command = new SqlCommand(storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            // Assuming the stored procedure returns a single value
                            reader.Read();
                            result = reader.GetString(0); // Adjust the index if necessary
                        }
                    }
                }
            }

            return result;
        }

        public static SqlDataReader ExecSqlDataReader(String strLenh)
        {
            SqlDataReader myreader;
            SqlCommand sqlcmd = new SqlCommand(strLenh, Program.conn);
            sqlcmd.CommandType = CommandType.Text;
            if (Program.conn.State == ConnectionState.Closed) Program.conn.Open();
            try
            {
                myreader = sqlcmd.ExecuteReader(); return myreader;

            }
            catch (SqlException ex)
            {
                Program.conn.Close();
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public static DataTable ExecSqlDataTable(String cmd)
        {
            DataTable dt = new DataTable();
            if (Program.conn.State == ConnectionState.Closed) Program.conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd, Program.conn);
            try
            {
                da.Fill(dt); Program.conn.Close();
                return dt;
            }
            catch (SqlException ex)
            {
                Program.conn.Close();
                MessageBox.Show(ex.Message);
                return null;
            }

        }

        public static int ExecSqlNonQuery(String strlenh)
        {
            SqlCommand Sqlcmd = new SqlCommand(strlenh, conn);
            Sqlcmd.CommandType = CommandType.Text;
            Sqlcmd.CommandTimeout = 600;// 10 phut 
            if (conn.State == ConnectionState.Closed) conn.Open();
            try
            {
                Sqlcmd.ExecuteNonQuery(); conn.Close();
                return 0;
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("Error converting data type varchar to int"))
                {
                    MessageBox.Show("Bạn format Cell lại cột \"Ngày Thi\" qua kiểu Number hoặc mở File Excel.");
                }
                else if (ex.Message.Contains("The server principal")){
                    
                    string startTag = "The server principal '";
                    string endTag = "' already exists.";
                    int startIndex = ex.Message.IndexOf(startTag) + startTag.Length;
                    int endIndex = ex.Message.IndexOf(endTag);
                    string existingUsername = ex.Message.Substring(startIndex, endIndex - startIndex);

                    
                    MessageBox.Show($"Tên username '{existingUsername}' bị trùng. Xin vui lòng chọn tên khác", "Lỗi", MessageBoxButtons.OK);
                } else MessageBox.Show(ex.Message);
                conn.Close();
                return ex.State; // trang thai lỗi gởi từ RAISERROR trong SQL Server qua
            }
        }
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmChinh = new Form1();
            Application.Run(frmChinh);
        }
    }
}
