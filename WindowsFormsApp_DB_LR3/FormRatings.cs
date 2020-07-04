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
    public partial class FormRatings : Form
    {
        public FormRatings()
        {
            InitializeComponent();
        }

        private void FormRatings_Load(object sender, EventArgs e)
        {
            string connstring = string.Format("Server={0};Port={1}; User Id={2};Password={3};Database={4};", "127.0.0.1", "5432", "postgres", "123456", "realtor93");
            npgsqlConnection1.ConnectionString = connstring;

            GetDataFromSQLTable(npgsqlConnection1);
            GetDataForComboBoxObject(npgsqlConnection1);
            GetDataForComboBoxСriteria(npgsqlConnection1);
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            npgsqlConnection1.Open();

            NpgsqlCommand com = new NpgsqlCommand("insert into ratings (object, criterion, rating, date) values (@object, @criterion, @rating, @date)", npgsqlConnection1);

            com.Parameters.Add("object", NpgsqlTypes.NpgsqlDbType.Bigint).Value = Convert.ToInt32(comboBox1.SelectedValue);
            com.Parameters.Add("criterion", NpgsqlTypes.NpgsqlDbType.Bigint).Value = Convert.ToInt32(comboBox2.SelectedValue);
            com.Parameters.Add("rating", NpgsqlTypes.NpgsqlDbType.Double).Value = Convert.ToDouble(textBox3.Text);
            com.Parameters.Add("date", NpgsqlTypes.NpgsqlDbType.Date).Value = dateTimePicker1.Value;

            com.ExecuteNonQuery();

            MessageBox.Show("В таблицу добавлена запись");
            npgsqlConnection1.Close();

            GetDataFromSQLTable(npgsqlConnection1);
        }

        private void GetDataFromSQLTable(NpgsqlConnection con)
        {

            con.Open();

            NpgsqlCommand com = new NpgsqlCommand("SELECT ratings.object, ratings.criterion, realty.adress, criteria.name, ratings.rating, ratings.date FROM realty, ratings, criteria WHERE  public.realty.kod = public.ratings.object and ratings.criterion = criteria.kod ", con);

            NpgsqlDataReader reader = com.ExecuteReader();

            DataTable Table = new DataTable();
            // Заполнение шапки таблицы
            Table.Columns.Add(reader.GetName(0));
            Table.Columns.Add(reader.GetName(1));
            Table.Columns.Add(reader.GetName(2));
            Table.Columns.Add(reader.GetName(3));
            Table.Columns.Add(reader.GetName(4));
            Table.Columns.Add(reader.GetName(5));

            while (reader.Read())
            {
                try
                {
                    Table.Rows.Add(new object[] { reader.GetValue(0), reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), reader.GetValue(4), reader.GetValue(5) });
                }
                catch { }
            }

            con.Close();

            DataSet Nabor = new DataSet();

            NpgsqlDataAdapter Аdapter = new NpgsqlDataAdapter("SELECT ratings.object, ratings.criterion, realty.adress, criteria.name, ratings.rating, ratings.date FROM realty, ratings, criteria WHERE  realty.kod = ratings.object and ratings.criterion = criteria.kod", con);

            Аdapter.Fill(Nabor, "ratings");

            //dataGridView1.DataSource = Table;
            dataGridView1.DataSource = Nabor;
            dataGridView1.DataMember = "ratings";

            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[5].ReadOnly = true;

    
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

        private void GetDataForComboBoxСriteria(NpgsqlConnection con)
        {
            var data = new List<KodName>();

            con.Open();

            NpgsqlCommand com = new NpgsqlCommand("select * from criteria order by kod", con);

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

            comboBox2.DataSource = data;
            comboBox2.DisplayMember = "Name"; // То, что будет отображаться пользователю
            comboBox2.ValueMember = "Kod"; // То, что будет в SelectedValue

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            NpgsqlConnection con = npgsqlConnection1;

            con.Open();



            try
            {
                DataSet Nabor = new DataSet();

                NpgsqlDataAdapter Аdapter = new NpgsqlDataAdapter("SELECT ratings.object, ratings.criterion, realty.adress, criteria.name, ratings.rating, ratings.date FROM realty, ratings, criteria WHERE  realty.kod = ratings.object and ratings.criterion = criteria.kod and  ratings.object = @object", con);

            Аdapter.SelectCommand.Parameters.Add("@object", NpgsqlTypes.NpgsqlDbType.Bigint).Value = Convert.ToInt32(comboBox1.SelectedValue);


                Аdapter.Fill(Nabor, "ratings");

                //dataGridView1.DataSource = Table;
                dataGridView1.DataSource = Nabor;
                dataGridView1.DataMember = "ratings";

                dataGridView1.Columns[3].ReadOnly = true;
                dataGridView1.Columns[5].ReadOnly = true;
            }
            catch { }

            con.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            NpgsqlConnection con = npgsqlConnection1;

            con.Open();

            NpgsqlCommand com = new NpgsqlCommand("Delete from ratings  WHERE object = @object and criterion = @criterion and date = @date", con);
            com.Parameters.Add("object", NpgsqlTypes.NpgsqlDbType.Bigint).Value = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            com.Parameters.Add("criterion", NpgsqlTypes.NpgsqlDbType.Bigint).Value = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value);
            com.Parameters.Add("date", NpgsqlTypes.NpgsqlDbType.Date).Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[5].Value.ToString().Trim());

            NpgsqlDataReader reader = com.ExecuteReader();
            MessageBox.Show("Запись удалена!");

            con.Close();

            GetDataFromSQLTable(npgsqlConnection1);
        }
    }
}
