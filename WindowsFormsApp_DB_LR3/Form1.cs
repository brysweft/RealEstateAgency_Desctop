using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Npgsql;

namespace WindowsFormsApp_DB_LR3
{

    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
   

        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void добавитьРиэлтораToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRraltor f = new FormRraltor();
            f.ShowDialog();
        }

        private void добавитьНовыйОбъектToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRealty f = new FormRealty();
            f.ShowDialog();
        }

        private void добавитьМатериалыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMaterials f = new FormMaterials();
            f.ShowDialog();
        }

        private void добавитьРайонToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAreas f = new FormAreas();
            f.ShowDialog();
        }

        private void добавитьТипОбъектаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTypebuilding f = new FormTypebuilding();
            f.ShowDialog();
        }

        private void добавитьОценкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRatings f = new FormRatings();
            f.ShowDialog();
        }

        private void добавитьКритерииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCriteria f = new FormCriteria();
            f.ShowDialog();
        }

        private void отразитьПродажуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSales f = new FormSales();
            f.ShowDialog();
        }
    }
}
