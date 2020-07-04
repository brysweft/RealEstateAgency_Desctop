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

    public partial class FormRealty : Form
    {
        public FormRealty()
        {
            InitializeComponent();
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            npgsqlConnection1.Open();

            NpgsqlCommand com = new NpgsqlCommand("insert into realty (kod, area, adress, level, nrooms, type, status, cost, description, material, square, date_ads) values (@kod, @area, @adress, @level, @nrooms, @type, @status, @cost, @description, @material, @square, @date_ads)", npgsqlConnection1);

            com.Parameters.Add("kod", NpgsqlTypes.NpgsqlDbType.Bigint).Value = Convert.ToInt32(textBox1.Text);
            com.Parameters.Add("area", NpgsqlTypes.NpgsqlDbType.Bigint).Value = Convert.ToInt32(comboBox1.SelectedValue);
            com.Parameters.Add("adress", NpgsqlTypes.NpgsqlDbType.Char, 100).Value = textBox3.Text;
            com.Parameters.Add("level", NpgsqlTypes.NpgsqlDbType.Bigint).Value = Convert.ToInt32(textBox4.Text);
            com.Parameters.Add("nrooms", NpgsqlTypes.NpgsqlDbType.Bigint).Value = Convert.ToInt32(textBox5.Text);
            com.Parameters.Add("type", NpgsqlTypes.NpgsqlDbType.Bigint).Value = Convert.ToInt32(comboBox2.SelectedValue);
            com.Parameters.Add("status", NpgsqlTypes.NpgsqlDbType.Boolean).Value = checkBox1.Checked;
            com.Parameters.Add("cost", NpgsqlTypes.NpgsqlDbType.Bigint).Value = Convert.ToInt32(textBox7.Text);
            com.Parameters.Add("description", NpgsqlTypes.NpgsqlDbType.Text).Value = textBox8.Text;
            com.Parameters.Add("material", NpgsqlTypes.NpgsqlDbType.Bigint).Value = Convert.ToInt32(comboBox3.SelectedValue);
            com.Parameters.Add("square", NpgsqlTypes.NpgsqlDbType.Double).Value = Convert.ToDouble(textBox10.Text);
            com.Parameters.Add("date_ads", NpgsqlTypes.NpgsqlDbType.Date).Value = dateTimePicker1.Value;



            com.ExecuteNonQuery();

            MessageBox.Show("В таблицу добавлена запись");
            npgsqlConnection1.Close();

            GetDataFromSQLTable(npgsqlConnection1);
        }

        private void FormRealty_Load(object sender, EventArgs e)
        {
            string connstring = string.Format("Server={0};Port={1}; User Id={2};Password={3};Database={4};", "127.0.0.1", "5432", "postgres", "123456", "realtor93");
            npgsqlConnection1.ConnectionString = connstring;

            GetDataFromSQLTable(npgsqlConnection1);
            GetDataForComboBoxTypebuilding(npgsqlConnection1);
            GetDataForComboBoxArea(npgsqlConnection1);
            GetDataForComboBoxMaterial(npgsqlConnection1);
        }

        private void GetDataFromSQLTable(NpgsqlConnection con)
        {

            con.Open();

            NpgsqlCommand com = new NpgsqlCommand("select * from realty order by cost desc", con);

            NpgsqlDataReader reader = com.ExecuteReader();

            DataTable Table = new DataTable();
            // Заполнение шапки таблицы
            Table.Columns.Add(reader.GetName(0));
            Table.Columns.Add(reader.GetName(1));
            Table.Columns.Add(reader.GetName(2));
            Table.Columns.Add(reader.GetName(3));
            Table.Columns.Add(reader.GetName(4));
            Table.Columns.Add(reader.GetName(5));
            Table.Columns.Add(reader.GetName(6));
            Table.Columns.Add(reader.GetName(7));
            Table.Columns.Add(reader.GetName(8));
            Table.Columns.Add(reader.GetName(9));
            Table.Columns.Add(reader.GetName(10));
            Table.Columns.Add(reader.GetName(11));

            while (reader.Read())
            {
                try
                {
                    Table.Rows.Add(new object[] { reader.GetValue(0), reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), reader.GetValue(4), reader.GetValue(5), Convert.ToBoolean(reader.GetValue(6).ToString().Trim()), reader.GetValue(7), reader.GetValue(8), reader.GetValue(9), reader.GetValue(10), reader.GetValue(11) });
                }
                catch { }
            }

            con.Close();

            dataGridView1.DataSource = Table;
        }

        private void GetDataForComboBoxTypebuilding(NpgsqlConnection con)
        {
            var data = new List<KodName>();

            con.Open();

            NpgsqlCommand com = new NpgsqlCommand("select * from typebuilding order by kod", con);

            NpgsqlDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                var mc = new KodName
                {
                    Kod = reader[1].ToString().Trim(),
                    Name = reader[0].ToString().Trim()
                };
                data.Add(mc);
            }

            con.Close();

            comboBox2.DataSource = data;
            comboBox2.DisplayMember = "Name"; // То, что будет отображаться пользователю
            comboBox2.ValueMember = "Kod"; // То, что будет в SelectedValue

        }

        private void GetDataForComboBoxArea(NpgsqlConnection con)
        {
            var data = new List<KodName>();

            con.Open();

            NpgsqlCommand com = new NpgsqlCommand("select * from areas order by kod", con);

            NpgsqlDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                var mc = new KodName
                {
                    Kod = reader[0].ToString().Trim(),
                    Name = reader[1].ToString().Trim()
                };
                data.Add(mc);
            }

            con.Close();

            comboBox1.DataSource = data;
            comboBox1.DisplayMember = "Name"; // То, что будет отображаться пользователю
            comboBox1.ValueMember = "Kod"; // То, что будет в SelectedValue

        }

        private void GetDataForComboBoxMaterial(NpgsqlConnection con)
        {
            var data = new List<KodName>();

            con.Open();

            NpgsqlCommand com = new NpgsqlCommand("select * from materials order by kod", con);

            NpgsqlDataReader reader = com.ExecuteReader();

            while (reader.Read())
            {
                var mc = new KodName
                {
                    Kod = reader[0].ToString().Trim(),
                    Name = reader[1].ToString().Trim()
                };
                data.Add(mc);
            }

            con.Close();

            comboBox3.DataSource = data;
            comboBox3.DisplayMember = "Name"; // То, что будет отображаться пользователю
            comboBox3.ValueMember = "Kod"; // То, что будет в SelectedValue

        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();

            string selectString = "level like '%" + textBoxFindLevel.Text.Trim() + "%' and nrooms like '%" + textBoxFindNrooms.Text.Trim() + "%' and cost like '%" + textBoxFindCost.Text.Trim() + "%' and description like '%" + textBoxFindDescrip.Text.Trim() + "%'";
            DataRowCollection allRows = ((DataTable)dataGridView1.DataSource).Rows;

            DataRow[] searchedRows = ((DataTable)dataGridView1.DataSource).Select(selectString);

            for (int i = 0; i < searchedRows.Count(); i++)
            {
                int rowIndex = allRows.IndexOf(searchedRows[i]);
                if (textBoxFindLevel.Text.Trim() != "")
                    {
                    dataGridView1.Rows[rowIndex].Cells[3].Selected = true;
                }
                if (textBoxFindNrooms.Text.Trim() != "")
                {
                    dataGridView1.Rows[rowIndex].Cells[4].Selected = true;
                }
                if (textBoxFindCost.Text.Trim() != "")
                {
                    dataGridView1.Rows[rowIndex].Cells[7].Selected = true;
                }
                if (textBoxFindDescrip.Text.Trim() != "")
                {
                    dataGridView1.Rows[rowIndex].Cells[8].Selected = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NpgsqlConnection con = npgsqlConnection1;

            con.Open();

            try
            {
            NpgsqlCommand com = new NpgsqlCommand("UPDATE realty  SET status = @starus, cost=@cost, description=@description, date_ads=@date_ads WHERE kod = @kod_object", con);
            com.Parameters.Add("kod_object", NpgsqlTypes.NpgsqlDbType.Bigint).Value = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            com.Parameters.Add("starus", NpgsqlTypes.NpgsqlDbType.Boolean).Value = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[6].Value.ToString().Trim());
            com.Parameters.Add("cost", NpgsqlTypes.NpgsqlDbType.Bigint).Value = Convert.ToInt32(dataGridView1.CurrentRow.Cells[7].Value);
            com.Parameters.Add("description", NpgsqlTypes.NpgsqlDbType.Text).Value = dataGridView1.CurrentRow.Cells[8].Value.ToString().Trim();
            com.Parameters.Add("date_ads", NpgsqlTypes.NpgsqlDbType.Date).Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[11].Value.ToString().Trim());
            NpgsqlDataReader reader = com.ExecuteReader();
            MessageBox.Show("Запись сохранена!");
            }
            catch {
                MessageBox.Show("Некорректный ввод данных!");
            }
            con.Close();
        }
    }
}
