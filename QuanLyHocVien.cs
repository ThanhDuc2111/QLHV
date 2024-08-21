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
    public partial class QuanLyHocVien : Form
    {
        public QuanLyHocVien()
        {
            InitializeComponent();
        }
        
        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();

        private void Load_DataHocVien()
        {
          

            DBConnect db = new DBConnect();
            string str = "Select * from HocVien";
            DataTable dt = db.getDataTable(str);
            datagv.DataSource = dt;

    
        }

        private void QLHV_Load(object sender, EventArgs e)
        {

            Load_DataHocVien();
            Load_CBKhoaHoc();
        
        }
        private void QLHV_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có muốn thoát!!!!!!!!!", "Thoat", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (r == DialogResult.No)
                e.Cancel = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void datagv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = datagv.CurrentRow.Index;
            txtMa.Text = datagv.Rows[i].Cells[0].Value.ToString();
            txtTen.Text = datagv.Rows[i].Cells[1].Value.ToString();
            dtNS.Text = datagv.Rows[i].Cells[2].Value.ToString();
            cbGT.Text = datagv.Rows[i].Cells[3].Value.ToString();
            txtE.Text = datagv.Rows[i].Cells[4].Value.ToString();
            txtSDT.Text = datagv.Rows[i].Cells[5].Value.ToString();
            cbKhoaHoc.Text = datagv.Rows[i].Cells[6].Value.ToString();

           
        }
//---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        private void btnThem_Click(object sender, EventArgs e)
        {

            DBConnect db = new DBConnect();
            db.Open();

            string str = "INSERT INTO HocVien (IDHocVien, HoTen, NgaySinh, GioiTinh, Email, DienThoai) VALUES ('" + txtMa.Text + "', N'" + txtTen.Text + "','" + dtNS.Text + "',N'" + cbGT.Text + "','" + txtE.Text + "','" + txtSDT.Text + "')";

            using (SqlCommand cmd = new SqlCommand(str, db.Connection))
            {
                try
                {
                    int kq = cmd.ExecuteNonQuery();

                    if (kq > 0)
                    {
                        MessageBox.Show("Đã thêm thành công");
                        Load_DataHocVien();

                        txtMa.Clear();
                        txtTen.Clear();
                        txtE.Clear();
                        txtSDT.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Không thể thêm dữ liệu. Vui lòng kiểm tra lại.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            db.Close();

        }
        //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void btnXoa_Click(object sender, EventArgs e)
        {

            DBConnect db = new DBConnect();
            db.Open();

            string str = "DELETE FROM HocVien WHERE IDHocVien ='" + txtMa.Text + "'";

            using (SqlCommand cmd = new SqlCommand(str, db.Connection))
            {
                try
                {
                    int kq = cmd.ExecuteNonQuery();

                    if (kq == 0)
                    {
                        MessageBox.Show("Đã xóa thành công");
                        Load_DataHocVien();

                        txtMa.Clear();
                        txtTen.Clear();
                        txtE.Clear();
                        txtSDT.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa dữ liệu. Vui lòng kiểm tra lại.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            db.Close();

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    cmd = cn.CreateCommand();
            //    cmd.CommandText = "UPDATE HocVien SET HoTen = N'" + txtTen.Text + "',NgaySinh = '" + dtNS.Text + "',GioiTinh = N'" + cbGT.Text + "',Email = '" + txtE.Text + "',DienThoai = '" + txtSDT.Text + "'where IDHocVien='" + txtMa.Text + "'";
            //    cmd.ExecuteNonQuery();
            //    Load_DataHocVien();
            //}
            //catch (SqlException sqlEx)
            //{
            //    MessageBox.Show("Lỗi SQL: " + sqlEx.Message);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Lỗi: " + ex.Message);

            DBConnect db = new DBConnect();
            db.Open();
            string suaNgay = dtNS.Value.ToString("yyyy-MM-dd");
            string str = "UPDATE HocVien SET HoTen = N'" + txtTen.Text + "',NgaySinh = '" + suaNgay + "',GioiTinh = N'" + cbGT.Text + "',Email = '" + txtE.Text + "',DienThoai = '" + txtSDT.Text + "'where IDHocVien='" + txtMa.Text + "'";

            using (SqlCommand cmd = new SqlCommand(str, db.Connection))
            {
                try
                {
                    int kq = cmd.ExecuteNonQuery();

                    if (kq > 0)
                    {
                        MessageBox.Show("Đã sửa thành công");
                        Load_DataHocVien();

                        txtMa.Clear();
                        txtTen.Clear();
                        txtE.Clear();
                        txtSDT.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Không thể thêm dữ liệu. Vui lòng kiểm tra lại.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            db.Close();
            //}
        }

//----------------------------------------------------------------------------------------------------------------------

        private void Load_CBKhoaHoc()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(@"Data Source=MINHQUOC\SA;Initial Catalog=QLHVTTTH;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT TenKhoaHoc FROM KhoaHoc", cn))
                    {
                        cn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            string tenKhoaHoc = reader["TenKhoaHoc"].ToString();
                            cbKhoaHoc.Items.Add(tenKhoaHoc);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu khóa học: " + ex.Message);
            }
        }


          
    }
}

