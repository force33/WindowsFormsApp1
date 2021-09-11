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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            string ConnectionString = "Server=localhost;Database=pz3536;Integrated Security=True;";
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            //textBox1.Text = sqlConnection.State.ToString();
            SqlCommand command = new SqlCommand("select * from student", sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand("select * from student", sqlConnection);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            SqlDataReader reader = command.ExecuteReader();
            dataGridView1.DataSource = ds.Tables[0];
            foreach (DataTable dt in ds.Tables)
            {
                textBox1.Text += dt.TableName;
                foreach (DataColumn column in dt.Columns)
                {

                    // dataGridView1.Columns = column.ColumnName; 
                    //textBox2.Text += column.ColumnName;
                }
                foreach (DataRow row in dt.Rows)
                {
                    var cells = row.ItemArray;
                    foreach (object cell in cells)
                    {
                        textBox3.Text += cell.ToString();
                    }
                }
            }
            while (reader.Read())
            {
                textBox4.Text += ((IDataRecord)reader).ToString();
            }
            reader.Close();
        }
    }
}
