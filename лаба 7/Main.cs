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

namespace лаба_7
{
    public partial class Form1 : Form
    {
        SqlConnection connection = new SqlConnection(@"Database=DESKTOP-I15JQK7; Initial Catalog=Examen; Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connection.Open();
            load_data();
        }
        void load_data()
        {
            SqlDataAdapter sqlData = new SqlDataAdapter("SELECT*FROM [User]", connection);
            DataTable data = new DataTable();
            sqlData.Fill(data);
            dataGridView1.DataSource = data;

        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("INSERT INTO [User](Id, Name, Adress, Tel) VALUES ('" + id_txt.Text + " ',' " + name_txt.Text + "' , '" + ad_txt.Text + "' , '" + tel_txt.Text + " ')", connection);
            command.ExecuteNonQuery();
            clear_fun();
            MessageBox.Show("saved");

        }
        void clear_fun()
        {
            id_txt.Text = "";
            name_txt.Text = "";
            ad_txt.Text = "";
            tel_txt.Text = "";
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            clear_fun();
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("UPDATE [User] SET Name='" + name_txt.Text + "', Adress='" + ad_txt.Text + "', Tel='" + tel_txt.Text + "' where id='" + id_txt.Text + "'", connection);
            command.ExecuteNonQuery();
            load_data();
            clear_fun();
            MessageBox.Show("Updated");

        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("DELETE FROM [User] WHERE Id='" + id_txt.Text + "'", connection);
            command.ExecuteNonQuery();
            load_data();
            clear_fun();
            MessageBox.Show("Deleted");

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int Num = dataGridView1.CurrentCell.RowIndex;
            id_txt.Text = dataGridView1.Rows[Num].Cells[0].Value.ToString();
            name_txt.Text = dataGridView1.Rows[Num].Cells[1].Value.ToString();
            ad_txt.Text = dataGridView1.Rows[Num].Cells[2].Value.ToString();
            tel_txt.Text = dataGridView1.Rows[Num].Cells[3].Value.ToString();

        }

    }
}
