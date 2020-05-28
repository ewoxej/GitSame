namespace GitSame
{
    partial class FilterForm
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
            this.listFiles = new System.Windows.Forms.ListBox();
            this.inputFiles = new System.Windows.Forms.TextBox();
            this.addFileButton = new System.Windows.Forms.Button();
            this.continueButton = new System.Windows.Forms.Button();
            this.deleteItemButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listFiles
            // 
            this.listFiles.FormattingEnabled = true;
            this.listFiles.Location = new System.Drawing.Point(272, 47);
            this.listFiles.Name = "listFiles";
            this.listFiles.Size = new System.Drawing.Size(142, 212);
            this.listFiles.TabIndex = 0;
            // 
            // inputFiles
            // 
            this.inputFiles.Location = new System.Drawing.Point(15, 102);
            this.inputFiles.Name = "inputFiles";
            this.inputFiles.Size = new System.Drawing.Size(217, 20);
            this.inputFiles.TabIndex = 1;
            // 
            // addFileButton
            // 
            this.addFileButton.Location = new System.Drawing.Point(15, 138);
            this.addFileButton.Name = "addFileButton";
            this.addFileButton.Size = new System.Drawing.Size(118, 35);
            this.addFileButton.TabIndex = 2;
            this.addFileButton.Text = "добавить в список";
            this.addFileButton.UseVisualStyleBackColor = true;
            this.addFileButton.Click += new System.EventHandler(this.addFileButton_Click);
            // 
            // continueButton
            // 
            this.continueButton.Location = new System.Drawing.Point(139, 340);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(169, 41);
            this.continueButton.TabIndex = 3;
            this.continueButton.Text = "продолжить проверку";
            this.continueButton.UseVisualStyleBackColor = true;
            this.continueButton.Click += new System.EventHandler(this.continueButton_Click);
            // 
            // deleteItemButton
            // 
            this.deleteItemButton.Location = new System.Drawing.Point(273, 278);
            this.deleteItemButton.Name = "deleteItemButton";
            this.deleteItemButton.Size = new System.Drawing.Size(141, 25);
            this.deleteItemButton.TabIndex = 4;
            this.deleteItemButton.Text = "удалить из списка";
            this.deleteItemButton.UseVisualStyleBackColor = true;
            this.deleteItemButton.Click += new System.EventHandler(this.deleteItemButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Lavender;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(269, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 21);
            this.label1.TabIndex = 5;
            this.label1.Text = "список:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Lavender;
            this.label2.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(220, 80);
            this.label2.TabIndex = 6;
            this.label2.Text = "Введите имя файла или папки,\r\nкоторый(ую) следует игнорировать \r\nи нажмите кнопку" +
    " \"добавить в список\". \r\nНазвание отобразится в списке.\r\n\r\n";
            // 
            // FilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(459, 393);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.deleteItemButton);
            this.Controls.Add(this.continueButton);
            this.Controls.Add(this.addFileButton);
            this.Controls.Add(this.inputFiles);
            this.Controls.Add(this.listFiles);
            this.Name = "FilterForm";
            this.Text = "FilterForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listFiles;
        private System.Windows.Forms.TextBox inputFiles;
        private System.Windows.Forms.Button addFileButton;
        private System.Windows.Forms.Button continueButton;
        private System.Windows.Forms.Button deleteItemButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}