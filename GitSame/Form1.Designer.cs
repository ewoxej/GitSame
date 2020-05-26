namespace GitSame
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.checkButton = new System.Windows.Forms.Button();
            this.addRepos = new System.Windows.Forms.Button();
            this.inputRepos = new System.Windows.Forms.TextBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.filterButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.address = new System.Windows.Forms.DataGridViewLinkColumn();
            this.author = new System.Windows.Forms.DataGridViewLinkColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deleteRepos = new System.Windows.Forms.DataGridViewButtonColumn();
            this.updateRepos = new System.Windows.Forms.DataGridViewButtonColumn();
            this.selectRepos = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.checkAll = new System.Windows.Forms.CheckBox();
            this.autoplagiatCheck = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // checkButton
            // 
            this.checkButton.Font = new System.Drawing.Font("Franklin Gothic Book", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkButton.Location = new System.Drawing.Point(492, 353);
            this.checkButton.Name = "checkButton";
            this.checkButton.Size = new System.Drawing.Size(152, 41);
            this.checkButton.TabIndex = 6;
            this.checkButton.Text = "проверить";
            this.checkButton.UseVisualStyleBackColor = true;
            this.checkButton.Click += new System.EventHandler(this.checkButton_Click);
            // 
            // addRepos
            // 
            this.addRepos.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addRepos.Location = new System.Drawing.Point(529, 53);
            this.addRepos.Name = "addRepos";
            this.addRepos.Size = new System.Drawing.Size(115, 27);
            this.addRepos.TabIndex = 5;
            this.addRepos.Text = "добавить";
            this.addRepos.UseVisualStyleBackColor = true;
            this.addRepos.Click += new System.EventHandler(this.addRepos_Click);
            // 
            // inputRepos
            // 
            this.inputRepos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inputRepos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.inputRepos.Location = new System.Drawing.Point(182, 55);
            this.inputRepos.Name = "inputRepos";
            this.inputRepos.Size = new System.Drawing.Size(341, 23);
            this.inputRepos.TabIndex = 4;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.BackgroundColor = System.Drawing.Color.Lavender;
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Honeydew;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.address,
            this.author,
            this.description,
            this.deleteRepos,
            this.updateRepos,
            this.selectRepos});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Franklin Gothic Book", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView.GridColor = System.Drawing.Color.DarkGreen;
            this.dataGridView.Location = new System.Drawing.Point(12, 120);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(632, 211);
            this.dataGridView.TabIndex = 1;
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            this.dataGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_CellMouseClick);
            // 
            // filterButton
            // 
            this.filterButton.Font = new System.Drawing.Font("Franklin Gothic Demi", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.filterButton.Location = new System.Drawing.Point(12, 358);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(177, 34);
            this.filterButton.TabIndex = 7;
            this.filterButton.Text = "добавить фильтры для поиска";
            this.filterButton.UseVisualStyleBackColor = true;
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Book", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "добавить репозиторий: ";
            // 
            // address
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            this.address.DefaultCellStyle = dataGridViewCellStyle6;
            this.address.HeaderText = "репозиторий";
            this.address.Name = "address";
            this.address.ReadOnly = true;
            this.address.Text = "";
            this.address.Width = 150;
            // 
            // author
            // 
            this.author.HeaderText = "владелец";
            this.author.Name = "author";
            this.author.ReadOnly = true;
            this.author.Width = 130;
            // 
            // description
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.description.DefaultCellStyle = dataGridViewCellStyle7;
            this.description.HeaderText = "описание";
            this.description.Name = "description";
            this.description.ReadOnly = true;
            // 
            // deleteRepos
            // 
            this.deleteRepos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.deleteRepos.HeaderText = "удалить";
            this.deleteRepos.Name = "deleteRepos";
            this.deleteRepos.ReadOnly = true;
            this.deleteRepos.Width = 60;
            // 
            // updateRepos
            // 
            this.updateRepos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.updateRepos.HeaderText = "обновить";
            this.updateRepos.Name = "updateRepos";
            this.updateRepos.ReadOnly = true;
            this.updateRepos.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.updateRepos.Width = 70;
            // 
            // selectRepos
            // 
            this.selectRepos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.selectRepos.HeaderText = "проверить";
            this.selectRepos.Name = "selectRepos";
            this.selectRepos.ReadOnly = true;
            this.selectRepos.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.selectRepos.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.selectRepos.Width = 78;
            // 
            // checkAll
            // 
            this.checkAll.AutoSize = true;
            this.checkAll.Font = new System.Drawing.Font("Franklin Gothic Book", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkAll.Location = new System.Drawing.Point(543, 93);
            this.checkAll.Name = "checkAll";
            this.checkAll.Size = new System.Drawing.Size(101, 21);
            this.checkAll.TabIndex = 9;
            this.checkAll.Text = "отметить все";
            this.checkAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkAll.UseVisualStyleBackColor = true;
            this.checkAll.CheckedChanged += new System.EventHandler(this.checkAll_CheckedChanged);
            // 
            // autoplagiatCheck
            // 
            this.autoplagiatCheck.AutoSize = true;
            this.autoplagiatCheck.Font = new System.Drawing.Font("Franklin Gothic Book", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.autoplagiatCheck.Location = new System.Drawing.Point(195, 366);
            this.autoplagiatCheck.Name = "autoplagiatCheck";
            this.autoplagiatCheck.Size = new System.Drawing.Size(153, 21);
            this.autoplagiatCheck.TabIndex = 10;
            this.autoplagiatCheck.Text = "включить автоплагиат";
            this.autoplagiatCheck.UseVisualStyleBackColor = true;
            this.autoplagiatCheck.CheckedChanged += new System.EventHandler(this.autoplagiatCheck_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(656, 424);
            this.Controls.Add(this.autoplagiatCheck);
            this.Controls.Add(this.checkAll);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.filterButton);
            this.Controls.Add(this.checkButton);
            this.Controls.Add(this.addRepos);
            this.Controls.Add(this.inputRepos);
            this.Controls.Add(this.dataGridView);
            this.Name = "Form1";
            this.Text = "Репозитории";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button checkButton;
        private System.Windows.Forms.Button addRepos;
        private System.Windows.Forms.TextBox inputRepos;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button filterButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewLinkColumn address;
        private System.Windows.Forms.DataGridViewLinkColumn author;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.DataGridViewButtonColumn deleteRepos;
        private System.Windows.Forms.DataGridViewButtonColumn updateRepos;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selectRepos;
        private System.Windows.Forms.CheckBox checkAll;
        private System.Windows.Forms.CheckBox autoplagiatCheck;
    }
}

