namespace GitSame
{
    partial class FinalForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewFinal = new System.Windows.Forms.DataGridView();
            this.address = new System.Windows.Forms.DataGridViewLinkColumn();
            this.author = new System.Windows.Forms.DataGridViewLinkColumn();
            this.description = new System.Windows.Forms.DataGridViewLinkColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFinal)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewFinal
            // 
            this.dataGridViewFinal.AllowUserToAddRows = false;
            this.dataGridViewFinal.AllowUserToDeleteRows = false;
            this.dataGridViewFinal.BackgroundColor = System.Drawing.Color.Lavender;
            this.dataGridViewFinal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFinal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.address,
            this.author,
            this.description});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Franklin Gothic Book", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewFinal.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewFinal.Location = new System.Drawing.Point(12, 87);
            this.dataGridViewFinal.Name = "dataGridViewFinal";
            this.dataGridViewFinal.ReadOnly = true;
            this.dataGridViewFinal.Size = new System.Drawing.Size(524, 298);
            this.dataGridViewFinal.TabIndex = 2;
            this.dataGridViewFinal.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewFinal_CellContentClick);
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
            this.description.HeaderText = "файл";
            this.description.Name = "description";
            this.description.ReadOnly = true;
            this.description.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.description.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.description.Width = 200;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Book", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "РЕЗУЛЬТАТЫ\r\n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Franklin Gothic Book", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(13, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Проверка завершена";
            // 
            // FinalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 438);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewFinal);
            this.Name = "FinalForm";
            this.Text = "Репозитории";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFinal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewFinal;
        private System.Windows.Forms.DataGridViewLinkColumn address;
        private System.Windows.Forms.DataGridViewLinkColumn author;
        private System.Windows.Forms.DataGridViewLinkColumn description;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}