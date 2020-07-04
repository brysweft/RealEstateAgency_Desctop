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
    public partial class FormRraltor : Form
    {
        public FormRraltor()
        {
            InitializeComponent();
        }

        private void FormRraltor_Shown(object sender, EventArgs e)
        {

        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            npgsqlConnection1.Open();

            NpgsqlCommand com = new NpgsqlCommand("insert into realtors (kod, surname, firstname, middlename, contact) values (@kod, @surname, @firstname, @middlename, @contact)", npgsqlConnection1);

            com.Parameters.Add("kod", NpgsqlTypes.NpgsqlDbType.Bigint).Value = Convert.ToInt32(textBox1.Text);
            com.Parameters.Add("surname", NpgsqlTypes.NpgsqlDbType.Char, 40).Value = textBox2.Text;
            com.Parameters.Add("firstname", NpgsqlTypes.NpgsqlDbType.Char, 40).Value = textBox3.Text;
            com.Parameters.Add("middlename", NpgsqlTypes.NpgsqlDbType.Char, 40).Value = textBox4.Text;
            com.Parameters.Add("contact", NpgsqlTypes.NpgsqlDbType.Char, 40).Value = textBox5.Text;

            com.ExecuteNonQuery();

            MessageBox.Show("В таблицу добавлена запись");
            npgsqlConnection1.Close();

            GetDataFromSQLTable(npgsqlConnection1);
        }

        private void GetDataFromSQLTable(NpgsqlConnection con)
        {

            con.Open();

            NpgsqlCommand com = new NpgsqlCommand("select * from realtors order by surname", con);

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

        private void FormRraltor_Load(object sender, EventArgs e)
        {
            string connstring = string.Format("Server={0};Port={1}; User Id={2};Password={3};Database={4};", "127.0.0.1", "5432", "postgres", "123456", "realtor93");
            npgsqlConnection1.ConnectionString = connstring;

            GetDataFromSQLTable(npgsqlConnection1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NpgsqlConnection con = npgsqlConnection1;

            con.Open();

            try
            {
                NpgsqlCommand com = new NpgsqlCommand("UPDATE realtors  SET contact = @contact WHERE kod = @kod", con);
                com.Parameters.Add("kod", NpgsqlTypes.NpgsqlDbType.Bigint).Value = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                com.Parameters.Add("contact", NpgsqlTypes.NpgsqlDbType.Char, 40).Value = dataGridView1.CurrentRow.Cells[4].Value.ToString().Trim();
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
