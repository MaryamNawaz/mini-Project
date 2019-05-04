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

namespace Rubric
{
    public partial class Rubric : Form
    {
        static int i;
        public Rubric()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source = DESKTOP-UMRSA2O; Initial Catalog= ProjectB; Integrated Security = True; MultipleActiveResultSets = True");
            string query = "SELECT * FROM Student";
            SqlCommand command = new SqlCommand(query, con);
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                //SqlDataAdapter da = new SqlDataAdapter();
                //da.SelectCommand = command;
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                SqlConnection con = new SqlConnection("Data Source = (local); Initial Catalog= ProjectB; Integrated Security = True; MultipleActiveResultSets = True");
                string query = "insert into Clo(Name)values('" + this.textBox1.Text + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader myreader;
                try
                {
                    con.Open();
                    myreader = cmd.ExecuteReader();
                    MessageBox.Show("Saved");
                    while (myreader.Read())
                    {

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Please! Provide details");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source = DESKTOP-UMRSA2O; Initial Catalog= ProjectB; Integrated Security = True; MultipleActiveResultSets = True");
            con.Open();
            int id1 = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
            if (e.ColumnIndex == 0)
            {

                string q = "delete from student where Id = '" + id1 + "'";
                SqlCommand cmd = new SqlCommand(q, con);
                //cmd.Parameters.Add(new SqlParameter("@id", id));
                cmd.ExecuteReader();
                con.Close();
                this.dataGridView1.Rows.RemoveAt(e.RowIndex);
            }
            else if (e.ColumnIndex == 1)
            {
                i = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[2].FormattedValue.ToString());
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source = DESKTOP-UMRSA2O; Initial Catalog= ProjectB; Integrated Security = True; MultipleActiveResultSets = True");
            con.Open();
            string query = "update Student set Name = '" + textBox1.Text + "'";
            SqlCommand command = new SqlCommand(query, con);
            command.ExecuteNonQuery();
            /* command.Parameters.AddwithValue("@firstname, txtFirstName.Text");
             command.Parameters.AddwithValue("@lastname, txtLastName.Text");
             command.Parameters.AddwithValue("@contact, txtContact.Text");
             command.Parameters.AddwithValue("@email, txtEmail.Text");
             command.Parameters.AddwithValue("@registrationnumber, txtRegistrationNumber.Text");
             command.Parameters.AddwithValue("@status, txtStatus.Text");*/


            try
            {
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                //SqlDataAdapter da = new SqlDataAdapter();
                //da.SelectCommand = command;
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Main m = new Main();
            this.Hide();
            m.Show();
        }
    }
}
