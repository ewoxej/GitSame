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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.checkButton = new System.Windows.Forms.Button();
            this.addRepos = new System.Windows.Forms.Button();
            this.inputRepos = new System.Windows.Forms.TextBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.address = new System.Windows.Forms.DataGridViewLinkColumn();
            this.author = new System.Windows.Forms.DataGridViewLinkColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deleteRepos = new System.Windows.Forms.DataGridViewButtonColumn();
            this.updateRepos = new System.Windows.Forms.DataGridViewButtonColumn();
            this.selectRepos = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // checkButton
            // 
            this.checkButton.Font = new System.Drawing.Font("Franklin Gothic Book", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkButton.Location = new System.Drawing.Point(240, 357);
            this.checkButton.Name = "checkButton";
            this.checkButton.Size = new System.Drawing.Size(186, 35);
            this.checkButton.TabIndex = 6;
            this.checkButton.Text = "проверить";
            this.checkButton.UseVisualStyleBackColor = true;
            // 
            // addRepos
            // 
            this.addRepos.Font = new System.Drawing.Font("Franklin Gothic Book", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addRepos.Location = new System.Drawing.Point(409, 62);
            this.addRepos.Name = "addRepos";
            this.addRepos.Size = new System.Drawing.Size(170, 32);
            this.addRepos.TabIndex = 5;
            this.addRepos.Text = "добавить репозиторий";
            this.addRepos.UseVisualStyleBackColor = true;
            this.addRepos.Click += new System.EventHandler(this.addRepos_Click);
            // 
            // inputRepos
            // 
            this.inputRepos.Location = new System.Drawing.Point(48, 68);
            this.inputRepos.Name = "inputRepos";
            this.inputRepos.Size = new System.Drawing.Size(306, 20);
            this.inputRepos.TabIndex = 4;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.address,
            this.author,
            this.description,
            this.deleteRepos,
            this.updateRepos,
            this.selectRepos});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Franklin Gothic Book", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView.Location = new System.Drawing.Point(12, 113);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(616, 211);
            this.dataGridView.TabIndex = 1;
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            // 
            // address
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.address.DefaultCellStyle = dataGridViewCellStyle1;
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.description.DefaultCellStyle = dataGridViewCellStyle2;
            this.description.HeaderText = "описание";
            this.description.Name = "description";
            this.description.ReadOnly = true;
            // 
            // deleteRepos
            // 
            this.deleteRepos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.deleteRepos.HeaderText = "удалить";
            this.deleteRepos.Name = "deleteRepos";
            this.deleteRepos.ReadOnly = true;
            this.deleteRepos.Width = 53;
            // 
            // updateRepos
            // 
            this.updateRepos.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.updateRepos.HeaderText = "обновить";
            this.updateRepos.Name = "updateRepos";
            this.updateRepos.ReadOnly = true;
            this.updateRepos.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.updateRepos.Width = 60;
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 424);
            this.Controls.Add(this.checkButton);
            this.Controls.Add(this.addRepos);
            this.Controls.Add(this.inputRepos);
            this.Controls.Add(this.dataGridView);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button checkButton;
        private System.Windows.Forms.Button addRepos;
        private System.Windows.Forms.TextBox inputRepos;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewLinkColumn address;
        private System.Windows.Forms.DataGridViewLinkColumn author;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.DataGridViewButtonColumn deleteRepos;
        private System.Windows.Forms.DataGridViewButtonColumn updateRepos;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selectRepos;
    }
}

