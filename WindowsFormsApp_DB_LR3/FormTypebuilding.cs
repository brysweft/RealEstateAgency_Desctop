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
    public partial class FormTypebuilding : Form
    {
        public FormTypebuilding()
        {
            InitializeComponent();
        }


        private void FormTypebuilding_Load(object sender, EventArgs e)
        {



            string connstring = string.Format("Server={0};Port={1}; User Id={2};Password={3};Database={4};", "127.0.0.1", "5432", "postgres", "123456", "realtor93");
            npgsqlConnection1.ConnectionString = connstring;

            GetDataFromSQLTable(npgsqlConnection1);
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            npgsqlConnection1.Open();

            NpgsqlCommand com = new NpgsqlCommand("insert into typebuilding (kod, name) values (@kod, @name)", npgsqlConnection1);

            com.Parameters.Add("kod", NpgsqlTypes.NpgsqlDbType.Bigint).Value = Convert.ToInt32(textBox1.Text);
            com.Parameters.Add("name", NpgsqlTypes.NpgsqlDbType.Char, 40).Value = textBox2.Text;
    
            com.ExecuteNonQuery();

            MessageBox.Show("В таблицу добавлена запись");
            npgsqlConnection1.Close();

            GetDataFromSQLTable(npgsqlConnection1);
        }

        private void GetDataFromSQLTable(NpgsqlConnection con)
        {
            var data = new List<KodName>();

            con.Open();

            NpgsqlCommand com = new NpgsqlCommand("select * from typebuilding order by kod", con);

            NpgsqlDataReader reader = com.ExecuteReader();

            DataTable Table = new DataTable();
            // Заполнение шапки таблицы
            Table.Columns.Add(reader.GetName(0));
            Table.Columns.Add(reader.GetName(1));


            while (reader.Read())
            {
                try
                {
                    Table.Rows.Add(new object[] { reader.GetValue(0), reader.GetValue(1) });
                }
                catch { }

                var mc = new KodName
                {
                    Kod = reader[1].ToString().Trim(),
                    Name = reader[0].ToString().Trim()
                };
                data.Add(mc);
            }

            con.Close();

            dataGridView1.DataSource = Table;

            comboBox1.DataSource = data;
            comboBox1.DisplayMember = "Name"; // То, что будет отображаться пользователю
            comboBox1.ValueMember = "Kod"; // То, что будет в SelectedValue

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            //com.Parameters.Add("p1", NpgsqlTypes.NpgsqlDbType.Bigint).Value = int.Parse(comboBox1.SelectedValue.ToString());
            textBox1.Text = ((KodName)comboBox1.SelectedItem).Kod;
            textBox2.Text = ((KodName)comboBox1.SelectedItem).Name;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();

            string selectString = "name like '%" + textBox3.Text.Trim() + "%'";
            DataRowCollection allRows = ((DataTable)dataGridView1.DataSource).Rows;

            DataRow[] searchedRows = ((DataTable)dataGridView1.DataSource).Select(selectString);

            for (int i = 0; i < searchedRows.Count(); i++)
            {
                int rowIndex = allRows.IndexOf(searchedRows[i]);
                dataGridView1.Rows[rowIndex].Cells[0].Selected = true;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            GetDataFromSQLTable(npgsqlConnection1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NpgsqlConnection con = npgsqlConnection1;

            con.Open();

                NpgsqlCommand com = new NpgsqlCommand("Delete from typebuilding  WHERE kod = @kod", con);
                com.Parameters.Add("kod", NpgsqlTypes.NpgsqlDbType.Bigint).Value = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value);

                NpgsqlDataReader reader = com.ExecuteReader();
                MessageBox.Show("Запись удалена!");

            con.Close();

            GetDataFromSQLTable(npgsqlConnection1);
        }
    }
}
