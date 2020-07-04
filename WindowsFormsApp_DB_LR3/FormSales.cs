using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace WindowsFormsApp_DB_LR3
{
    public partial class FormSales : Form
    {
        public FormSales()
        {
            InitializeComponent();
        }

        private void FormSales_Load(object sender, EventArgs e)
        {
            string connstring = string.Format("Server={0};Port={1}; User Id={2};Password={3};Database={4};", "127.0.0.1", "5432", "postgres", "123456", "realtor93");
            npgsqlConnection1.ConnectionString = connstring;

            GetDataFromSQLTable(npgsqlConnection1);
            GetDataForComboBoxObject(npgsqlConnection1);
            GetDataForComboBoxRealtors(npgsqlConnection1);
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            npgsqlConnection1.Open();

            NpgsqlCommand com = new NpgsqlCommand("insert into sales (kod, realty, realtor, cost, date) values (@kod, @realty, @realtor, @cost, @date)", npgsqlConnection1);

            com.Parameters.Add("kod", NpgsqlTypes.NpgsqlDbType.Bigint).Value = Convert.ToInt32(textBox1.Text);
            com.Parameters.Add("realty", NpgsqlTypes.NpgsqlDbType.Bigint).Value = Convert.ToInt32(comboBox1.SelectedValue);
            com.Parameters.Add("realtor", NpgsqlTypes.NpgsqlDbType.Bigint).Value = Convert.ToInt32(comboBox2.SelectedValue);
            com.Parameters.Add("cost", NpgsqlTypes.NpgsqlDbType.Double).Value = Convert.ToDouble(textBox4.Text);
            com.Parameters.Add("date", NpgsqlTypes.NpgsqlDbType.Date).Value = dateTimePicker1.Value;
 
            com.ExecuteNonQuery();

            MessageBox.Show("В таблицу добавлена запись");
            npgsqlConnection1.Close();

            GetDataFromSQLTable(npgsqlConnection1);
        }

        private void GetDataFromSQLTable(NpgsqlConnection con)
        {

            con.Open();

            NpgsqlCommand com = new NpgsqlCommand("select * from sales order by kod", con);

            NpgsqlDataReader reader = com.ExecuteReader();

            DataTable Table = new DataTable();
            // Заполнение шапки таблицы
            Table.Columns.Add(reader.GetName(0));
            Table.Columns.Add(reader.GetName(1));
            Table.Columns.Add(reader.GetName(2));
            Table.Columns.Add(reader.GetName(3));
            Table.Columns.Add(reader.GetName(4));

            while (reader.Read())
            {
                try
                {
                    Table.Rows.Add(new object[] { reader.GetValue(0), reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), reader.GetValue(4) });
                }
                catch { }
            }

            con.Close();

            dataGridView1.DataSource = Table;
        }

        private void GetDataForComboBoxObject(NpgsqlConnection con)
        {
            var data = new List<KodName>();

            con.Open();

            NpgsqlCommand com = new NpgsqlCommand("select * from realty order by kod", con);

            NpgsqlDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                var mc = new KodName
                {
                    Kod = reader[0].ToString().Trim(),
                    Name = reader[2].ToString().Trim()
                };
                data.Add(mc);
            }

            con.Close();

            comboBox1.DataSource = data;
            comboBox1.DisplayMember = "Name"; // То, что будет отображаться пользователю
            comboBox1.ValueMember = "Kod"; // То, что будет в SelectedValue

        }

        private void GetDataForComboBoxRealtors(NpgsqlConnection con)
        {
            var data = new List<KodName>();

            con.Open();

            NpgsqlCommand com = new NpgsqlCommand("select * from realtors order by kod", con);

            NpgsqlDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                var mc = new KodName
                {
                    Kod = reader[0].ToString().Trim(),
                    Name = reader[1].ToString().Trim() + " " + reader[2].ToString().Trim() + " " + reader[3].ToString().Trim()
                };
                data.Add(mc);
            }

            con.Close();

            comboBox2.DataSource = data;
            comboBox2.DisplayMember = "Name"; // То, что будет отображаться пользователю
            comboBox2.ValueMember = "Kod"; // То, что будет в SelectedValue

        }

        private void GetDataForDataObject(NpgsqlConnection con)
        {
 
            con.Open();

            try
            {

                NpgsqlCommand com = new NpgsqlCommand("select status from realty where realty.kod = @kod_object", con);

  
                com.Parameters.Add("kod_object", NpgsqlTypes.NpgsqlDbType.Bigint).Value = Convert.ToInt32(comboBox1.SelectedValue);

            

            NpgsqlDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                //status
                checkBox1.Checked = Convert.ToBoolean(reader[0]);
  

            }

            }
            catch
            {

            }

            con.Close();


        }

        private void button1_Click(object sender, EventArgs e)
        {

           NpgsqlConnection con = npgsqlConnection1;

             con.Open();

                NpgsqlCommand com = new NpgsqlCommand("UPDATE realty  SET status=@starus WHERE kod = @kod_object", con);
                 com.Parameters.Add("kod_object", NpgsqlTypes.NpgsqlDbType.Bigint).Value = Convert.ToInt32(comboBox1.SelectedValue);
                 com.Parameters.Add("starus", NpgsqlTypes.NpgsqlDbType.Boolean).Value = checkBox1.Checked;
                 NpgsqlDataReader reader = com.ExecuteReader();

            con.Close();

            GetDataFromSQLTable(npgsqlConnection1);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetDataForDataObject(npgsqlConnection1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NpgsqlConnection con = npgsqlConnection1;

            con.Open();

            try
            {
                NpgsqlCommand com = new NpgsqlCommand("UPDATE sales  SET cost=@cost, date=@date WHERE kod = @kod_sales", con);
                com.Parameters.Add("kod_sales", NpgsqlTypes.NpgsqlDbType.Bigint).Value = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                com.Parameters.Add("cost", NpgsqlTypes.NpgsqlDbType.Bigint).Value = Convert.ToInt32(dataGridView1.CurrentRow.Cells[4].Value);
                com.Parameters.Add("date", NpgsqlTypes.NpgsqlDbType.Date).Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[2].Value.ToString().Trim());
                NpgsqlDataReader reader = com.ExecuteReader();
                MessageBox.Show("Запись сохранена!");
            }
            catch
            {
                MessageBox.Show("Некорректный ввод данных!");
            }
            con.Close();
        }
    }
}
