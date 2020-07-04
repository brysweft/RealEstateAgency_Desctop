namespace WindowsFormsApp_DB_LR3
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.npgsqlCommand1 = new Npgsql.NpgsqlCommand();
            this.npgsqlConnection1 = new Npgsql.NpgsqlConnection();
            this.npgsqlDataAdapter1 = new Npgsql.NpgsqlDataAdapter();
            this.npgsqlCommandBuilder1 = new Npgsql.NpgsqlCommandBuilder();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ttryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.менюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.объектыНедвижемостиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьНовыйОбъектToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьРайонToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьМатериалыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьТипОбъектаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.риэторыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьРиэлтораToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оценкаНедвижемостиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьОценкуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьКритерииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.продажиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отразитьПродажуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // npgsqlCommand1
            // 
            this.npgsqlCommand1.AllResultTypesAreUnknown = false;
            this.npgsqlCommand1.Transaction = null;
            this.npgsqlCommand1.UnknownResultTypeList = null;
            // 
            // npgsqlConnection1
            // 
            this.npgsqlConnection1.ProvideClientCertificatesCallback = null;
            this.npgsqlConnection1.UserCertificateValidationCallback = null;
            // 
            // npgsqlDataAdapter1
            // 
            this.npgsqlDataAdapter1.DeleteCommand = null;
            this.npgsqlDataAdapter1.InsertCommand = null;
            this.npgsqlDataAdapter1.SelectCommand = null;
            this.npgsqlDataAdapter1.UpdateCommand = null;
            // 
            // npgsqlCommandBuilder1
            // 
            this.npgsqlCommandBuilder1.QuotePrefix = "\"";
            this.npgsqlCommandBuilder1.QuoteSuffix = "\"";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.SkyBlue;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ttryToolStripMenuItem,
            this.менюToolStripMenuItem,
            this.объектыНедвижемостиToolStripMenuItem,
            this.риэторыToolStripMenuItem,
            this.оценкаНедвижемостиToolStripMenuItem,
            this.продажиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(666, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ttryToolStripMenuItem
            // 
            this.ttryToolStripMenuItem.Name = "ttryToolStripMenuItem";
            this.ttryToolStripMenuItem.Size = new System.Drawing.Size(12, 20);
            // 
            // менюToolStripMenuItem
            // 
            this.менюToolStripMenuItem.Name = "менюToolStripMenuItem";
            this.менюToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.менюToolStripMenuItem.Text = "Меню";
            // 
            // объектыНедвижемостиToolStripMenuItem
            // 
            this.объектыНедвижемостиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьНовыйОбъектToolStripMenuItem,
            this.добавитьРайонToolStripMenuItem,
            this.добавитьМатериалыToolStripMenuItem,
            this.добавитьТипОбъектаToolStripMenuItem});
            this.объектыНедвижемостиToolStripMenuItem.Name = "объектыНедвижемостиToolStripMenuItem";
            this.объектыНедвижемостиToolStripMenuItem.Size = new System.Drawing.Size(152, 20);
            this.объектыНедвижемостиToolStripMenuItem.Text = "Объекты недвижемости";
            // 
            // добавитьНовыйОбъектToolStripMenuItem
            // 
            this.добавитьНовыйОбъектToolStripMenuItem.Name = "добавитьНовыйОбъектToolStripMenuItem";
            this.добавитьНовыйОбъектToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.добавитьНовыйОбъектToolStripMenuItem.Text = "Добавить новый объект";
            this.добавитьНовыйОбъектToolStripMenuItem.Click += new System.EventHandler(this.добавитьНовыйОбъектToolStripMenuItem_Click);
            // 
            // добавитьРайонToolStripMenuItem
            // 
            this.добавитьРайонToolStripMenuItem.Name = "добавитьРайонToolStripMenuItem";
            this.добавитьРайонToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.добавитьРайонToolStripMenuItem.Text = "Добавить район";
            this.добавитьРайонToolStripMenuItem.Click += new System.EventHandler(this.добавитьРайонToolStripMenuItem_Click);
            // 
            // добавитьМатериалыToolStripMenuItem
            // 
            this.добавитьМатериалыToolStripMenuItem.Name = "добавитьМатериалыToolStripMenuItem";
            this.добавитьМатериалыToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.добавитьМатериалыToolStripMenuItem.Text = "Добавить материалы";
            this.добавитьМатериалыToolStripMenuItem.Click += new System.EventHandler(this.добавитьМатериалыToolStripMenuItem_Click);
            // 
            // добавитьТипОбъектаToolStripMenuItem
            // 
            this.добавитьТипОбъектаToolStripMenuItem.Name = "добавитьТипОбъектаToolStripMenuItem";
            this.добавитьТипОбъектаToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.добавитьТипОбъектаToolStripMenuItem.Text = "Добавить тип объекта";
            this.добавитьТипОбъектаToolStripMenuItem.Click += new System.EventHandler(this.добавитьТипОбъектаToolStripMenuItem_Click);
            // 
            // риэторыToolStripMenuItem
            // 
            this.риэторыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьРиэлтораToolStripMenuItem});
            this.риэторыToolStripMenuItem.Name = "риэторыToolStripMenuItem";
            this.риэторыToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.риэторыToolStripMenuItem.Text = "Риэторы";
            // 
            // добавитьРиэлтораToolStripMenuItem
            // 
            this.добавитьРиэлтораToolStripMenuItem.Name = "добавитьРиэлтораToolStripMenuItem";
            this.добавитьРиэлтораToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.добавитьРиэлтораToolStripMenuItem.Text = "Добавить риэлтора";
            this.добавитьРиэлтораToolStripMenuItem.Click += new System.EventHandler(this.добавитьРиэлтораToolStripMenuItem_Click);
            // 
            // оценкаНедвижемостиToolStripMenuItem
            // 
            this.оценкаНедвижемостиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьОценкуToolStripMenuItem,
            this.добавитьКритерииToolStripMenuItem});
            this.оценкаНедвижемостиToolStripMenuItem.Name = "оценкаНедвижемостиToolStripMenuItem";
            this.оценкаНедвижемостиToolStripMenuItem.Size = new System.Drawing.Size(144, 20);
            this.оценкаНедвижемостиToolStripMenuItem.Text = "Оценка недвижемости";
            // 
            // добавитьОценкуToolStripMenuItem
            // 
            this.добавитьОценкуToolStripMenuItem.Name = "добавитьОценкуToolStripMenuItem";
            this.добавитьОценкуToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.добавитьОценкуToolStripMenuItem.Text = "Добавить оценку";
            this.добавитьОценкуToolStripMenuItem.Click += new System.EventHandler(this.добавитьОценкуToolStripMenuItem_Click);
            // 
            // добавитьКритерииToolStripMenuItem
            // 
            this.добавитьКритерииToolStripMenuItem.Name = "добавитьКритерииToolStripMenuItem";
            this.добавитьКритерииToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.добавитьКритерииToolStripMenuItem.Text = "Добавить критерии";
            this.добавитьКритерииToolStripMenuItem.Click += new System.EventHandler(this.добавитьКритерииToolStripMenuItem_Click);
            // 
            // продажиToolStripMenuItem
            // 
            this.продажиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.отразитьПродажуToolStripMenuItem});
            this.продажиToolStripMenuItem.Name = "продажиToolStripMenuItem";
            this.продажиToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.продажиToolStripMenuItem.Text = "Продажи";
            // 
            // отразитьПродажуToolStripMenuItem
            // 
            this.отразитьПродажуToolStripMenuItem.Name = "отразитьПродажуToolStripMenuItem";
            this.отразитьПродажуToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.отразитьПродажуToolStripMenuItem.Text = "Отразить продажу";
            this.отразитьПродажуToolStripMenuItem.Click += new System.EventHandler(this.отразитьПродажуToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 272);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Риэлторское агентство";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Npgsql.NpgsqlCommand npgsqlCommand1;
        private Npgsql.NpgsqlDataAdapter npgsqlDataAdapter1;
        private Npgsql.NpgsqlCommandBuilder npgsqlCommandBuilder1;
        public Npgsql.NpgsqlConnection npgsqlConnection1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ttryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem менюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem объектыНедвижемостиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьНовыйОбъектToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьРайонToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьМатериалыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьТипОбъектаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem риэторыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьРиэлтораToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оценкаНедвижемостиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьОценкуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьКритерииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem продажиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отразитьПродажуToolStripMenuItem;
    }
}

