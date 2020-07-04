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
    public partial class FormAreas : Form
    {
        public FormAreas()
        {
            InitializeComponent();
        }

        private void FormAreas_Load(object sender, EventArgs e)
        {
            string connstring = string.Format("Server={0};Port={1}; User Id={2};Password={3};Database={4};", "127.0.0.1", "5432", "postgres", "123456", "realtor93");
            npgsqlConnection1.ConnectionString = connstring;

            GetDataFromSQLTable(npgsqlConnection1);
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            npgsqlConnection1.Open();

            NpgsqlCommand com = new NpgsqlCommand("insert into areas (kod, name) values (@kod, @name)", npgsqlConnection1);

            com.Parameters.Add("kod", NpgsqlTypes.NpgsqlDbType.Bigint).Value = Convert.ToInt32(textBox1.Text);
            com.Parameters.Add("name", NpgsqlTypes.NpgsqlDbType.Char, 40).Value = textBox2.Text;

            com.ExecuteNonQuery();

            MessageBox.Show("В таблицу добавлена запись");
            npgsqlConnection1.Close();

            GetDataFromSQLTable(npgsqlConnection1);

        }

        private void GetDataFromSQLTable(NpgsqlConnection con)
        {

            con.Open();

            NpgsqlCommand com = new NpgsqlCommand("select * from areas order by kod asc", con);

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
            }

            con.Close();

            dataGridView1.DataSource = Table;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NpgsqlConnection con = npgsqlConnection1;

            con.Open();

            NpgsqlCommand com = new NpgsqlCommand("Delete from areas  WHERE kod = @kod", con);
            com.Parameters.Add("kod", NpgsqlTypes.NpgsqlDbType.Bigint).Value = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);

            NpgsqlDataReader reader = com.ExecuteReader();
            MessageBox.Show("Запись удалена!");

            con.Close();

            GetDataFromSQLTable(npgsqlConnection1);
        }
    }
}
