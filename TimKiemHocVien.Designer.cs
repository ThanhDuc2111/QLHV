namespace Nhom5QLHocVienTTTH
{
    partial class TimKiemHocVien
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnTim = new System.Windows.Forms.Button();
            this.txtID = new System.Windows.Forms.TextBox();
            this.btnDong = new System.Windows.Forms.Button();
            this.dtTimKiem = new System.Windows.Forms.DataGridView();
            this.txtTenHocVien = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtTimKiem)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Silver;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(63, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập ID Học Viên Để Tìm Kiếm";
            // 
            // btnTim
            // 
            this.btnTim.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTim.Location = new System.Drawing.Point(125, 359);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(120, 45);
            this.btnTim.TabIndex = 1;
            this.btnTim.Text = "Tìm Kiếm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // txtID
            // 
            this.txtID.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.Location = new System.Drawing.Point(67, 115);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(133, 26);
            this.txtID.TabIndex = 2;
            // 
            // btnDong
            // 
            this.btnDong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnDong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDong.Location = new System.Drawing.Point(513, 359);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(88, 45);
            this.btnDong.TabIndex = 4;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // dtTimKiem
            // 
            this.dtTimKiem.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dtTimKiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtTimKiem.Location = new System.Drawing.Point(58, 181);
            this.dtTimKiem.Name = "dtTimKiem";
            this.dtTimKiem.Size = new System.Drawing.Size(648, 150);
            this.dtTimKiem.TabIndex = 5;
            // 
            // txtTenHocVien
            // 
            this.txtTenHocVien.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenHocVien.Location = new System.Drawing.Point(353, 115);
            this.txtTenHocVien.Name = "txtTenHocVien";
            this.txtTenHocVien.Size = new System.Drawing.Size(133, 26);
            this.txtTenHocVien.TabIndex = 6;
            // 
            // TimKiemHocVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BackgroundImage = global::Nhom5QLHocVienTTTH.Properties.Resources.tải_xuống1;
            this.ClientSize = new System.Drawing.Size(821, 431);
            this.Controls.Add(this.txtTenHocVien);
            this.Controls.Add(this.dtTimKiem);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.label1);
            this.Name = "TimKiemHocVien";
            this.Text = "Tìm Kiếm Học Viên";
            this.Load += new System.EventHandler(this.TimKiemHocVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtTimKiem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.DataGridView dtTimKiem;
        private System.Windows.Forms.TextBox txtTenHocVien;
    }
}