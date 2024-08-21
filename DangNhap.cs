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

namespace Nhom5QLHocVienTTTH
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }


        DBConnect db = new DBConnect();
        public SqlConnection conn = new SqlConnection();
        private void btnTaoTK_Click(object sender, EventArgs e)
        {
            DangKy dk = new DangKy();
            dk.ShowDialog();
        }

        private void lbqmk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            QuenMatKhau qmk = new QuenMatKhau();
            qmk.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string tk = txtTK.Text;
            string mk = txtMK.Text;

            DBConnect db = new DBConnect();
            string str = "SELECT TruyCap FROM NguoiDung WHERE TaiKhoan = '" + tk + "' AND MatKhau = '" + mk + "'";
            DataTable dt = db.getDataTable(str);
            SqlDataReader dtr = null;
            try
            {
                if (dt.Rows.Count > 0)
                {
                    // Access the value directly from the DataTable
                    string TruyCap = dt.Rows[0]["TruyCap"].ToString().Trim();
                    Console.WriteLine("TruyCap: " + TruyCap);

                    if (string.Equals(TruyCap, "Admin", StringComparison.OrdinalIgnoreCase))
                    {
                        TrangChu tc = new TrangChu();
                        tc.Show();
                        this.Hide();
                        // Thực hiện các hành động sau khi đăng nhập thành công cho Admin
                    }
                    else if (string.Equals(TruyCap, "User", StringComparison.OrdinalIgnoreCase))
                    {
                        Thông_tin_cá_nhân_học_viên thv = new Thông_tin_cá_nhân_học_viên();
                        thv.TaiKhoan = tk;

                        // Check for specific user accounts
                        List<string> allowedUsers = new List<string> { "user1", "user2", "user3", "user4", "user5", "user6" };

                        if (allowedUsers.Contains(thv.TaiKhoan))
                        {
                            this.Hide();
                            thv.Show();
                        }
                        else
                        {
                            MessageBox.Show("Tài khoản không được phép truy cập.");
                        }

                        // Thực hiện các hành động sau khi đăng nhập thành công cho User
                    }
                    else
                    {
                        MessageBox.Show("Quyền truy cập không hợp lệ");
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy người dùng với tên đăng nhập và mật khẩu cung cấp.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
        }
    }
}
 
        //private void DangNhap_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    DialogResult r;
        //    r = MessageBox.Show("Bạn có muốn thoát!!!!!!!!!", "Thoat", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

        //    if (r == DialogResult.No)
        //        e.Cancel = true;
        //}

        


        
   
