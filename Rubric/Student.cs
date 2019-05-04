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
    public partial class Student : Form
    {
        static int i;
        public Student()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text.Length < 3)
            {
                MessageBox.Show("Enter your name again!");
            }
            else if (textBox2.Text.Length < 3)
            {
                MessageBox.Show("Enter your name again!");
            }
            else if (textBox3.Text.Length < 11 && textBox3.Text.Length > 11)
            {
                MessageBox.Show("Enter your valid contact number");
            }
            else if (!textBox4.Text.Contains("@gmail.com"))
            {
                MessageBox.Show("Enter your valid Email Adress");
            }
            
            
            else if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("please fill All the feilds");
            }

            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
            {
                SqlConnection con = new SqlConnection("Data Source = (local); Initial Catalog= ProjectB; Integrated Security = True; MultipleActiveResultSets = True");
                string query = "insert into Student(FirstName, LastName, Contact, Email, RegistrationNumber, Status)values('" + this.textBox1.Text + "', '" + this.textBox2.Text + "', '" + this.textBox3.Text + "', '" + this.textBox4.Text + "', '" + this.textBox5.Text + "', '" + this.textBox6.Text + "')";
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
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Please! Provide details");
            }




        }

       

       

        private void button1_Click_1(object sender, EventArgs e)
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)

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
            else if(e.ColumnIndex == 1)
            {
                i =  Convert.ToInt32( dataGridView1.Rows[e.RowIndex].Cells[2].FormattedValue.ToString());
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].FormattedValue.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[6].FormattedValue.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[7].FormattedValue.ToString();
                textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[8].FormattedValue.ToString();
            }


           // string query = "Update [Student] set RegistrationNo= '" + txtRegistrationNumber.Text.ToString() + "' where( Student.Id='" + id + "')";
           // SqlDataAdapter tbl = new SqlDataAdapter(query, con);
           /// DataTable dt = new DataTable();
           // tbl.Fill(dt);


            //.DataSource = dt;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
            SqlConnection con = new SqlConnection("Data Source = DESKTOP-UMRSA2O; Initial Catalog= ProjectB; Integrated Security = True; MultipleActiveResultSets = True");
            con.Open();
            string query = "update Student set FirstName = '"+textBox1.Text+"', LastName='"+textBox2.Text+"', Contact='"+textBox3.Text+"', Email= '"+textBox4.Text+"', RegistrationNumber='"+textBox5.Text+"', Status='"+textBox6.Text+"' WHERE id ='"+i+"'";
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
