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

namespace Nhom5QLHocVienTTTH
{
    public partial class QuenMatKhau : Form
    {
        public QuenMatKhau()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DangNhap DN = new DangNhap();
            DN.Show();
            MessageBox.Show("Bạn có muốn hủy không");
            this.Close();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            DBConnect db = new DBConnect();
            string userEmail = txtEmail.Text;


            try
            {
                db.OpenConnection();
                string query = "SELECT MatKhau FROM NguoiDung WHERE Email = @Email";

                DataTable dataTable = db.ExecuteNonQuery(query, new SqlParameter("@Email", userEmail));


                if (dataTable.Rows.Count > 0)
                {
                    string password = dataTable.Rows[0]["MatKhau"].ToString();
                    MessageBox.Show("Mật khẩu của bạn là: " + password, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DangNhap DN = new DangNhap();
                    DN.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Email không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


       
        }


    }
}
