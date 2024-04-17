using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace QuanLyKhachSan.All_User_Control
{
    public partial class UC_AddRoom : UserControl
    {
        function fn = new function();
        String query;
        public UC_AddRoom()
        {
            InitializeComponent();
        }

        private void UC_AddRoom_Load(object sender, EventArgs e)
        {
            query = "Select * From Phong";
            DataSet ds = fn.getData(query);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if(txtMaPhong.Text != "" && txtMaNV.Text != "" && txtTenPhong.Text != "" && txtLoaiPhong.Text != ""
                && txtGia.Text != "" && txtTinhTrang.Text != "")
            {
                Int64 maphong = Int64.Parse(txtMaPhong.Text);
                Int64 manv = Int64.Parse(txtMaNV.Text);
                String tenphong = txtTenPhong.Text;
                String loaiphong = txtLoaiPhong.Text;
                String gia = txtGia.Text;
                String tinhtrang = txtTinhTrang.Text;

                query = "Insert into Phong (MaPhong,MANV,TenPhong,LoaiPhong,Gia,TinhTrangPhong) values ('" + maphong + "','" + manv + "','" + tenphong + "','" + loaiphong + "','" + gia + "','" + tinhtrang + "')";
                fn.setData(query,"Đã Thêm Phòng");

                UC_AddRoom_Load(this,null);
                clearAll();
            }
            else
            {
                MessageBox.Show("Xin Vui Lòng Điền Đầy Đủ Thông Tin ", "Warning !!!",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void clearAll()
        {
            txtMaPhong.Clear();
            txtMaNV.Clear();
            txtTenPhong.SelectedIndex = -1;
            txtLoaiPhong.SelectedIndex= -1;
            txtGia.SelectedIndex = -1;
            txtTinhTrang.SelectedIndex = -1;
        }

        private void UC_AddRoom_Leave(object sender, EventArgs e)
        {
            clearAll();
        }

        private void UC_AddRoom_Enter(object sender, EventArgs e)
        {
            UC_AddRoom_Load(this, null);
        }
    }
}
