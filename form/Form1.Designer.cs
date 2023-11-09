namespace form
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.changeDefaultMatrix = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.createNewMatrix = new System.Windows.Forms.Button();
            this.delExtrMatrix = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.changeDefaultMatrix);
            this.groupBox1.Controls.Add(this.button8);
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 441);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Панель управления";
            // 
            // changeDefaultMatrix
            // 
            this.changeDefaultMatrix.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.changeDefaultMatrix.Location = new System.Drawing.Point(6, 347);
            this.changeDefaultMatrix.Name = "changeDefaultMatrix";
            this.changeDefaultMatrix.Size = new System.Drawing.Size(188, 81);
            this.changeDefaultMatrix.TabIndex = 6;
            this.changeDefaultMatrix.Text = "Изменить стандартную матрицу";
            this.changeDefaultMatrix.UseVisualStyleBackColor = true;
            this.changeDefaultMatrix.Click += new System.EventHandler(this.changeDefaultMatrix_Click);
            // 
            // button8
            // 
            this.button8.Enabled = false;
            this.button8.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button8.Location = new System.Drawing.Point(6, 306);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(188, 35);
            this.button8.TabIndex = 5;
            this.button8.Text = "СЛАУ";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.Enabled = false;
            this.button7.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button7.Location = new System.Drawing.Point(6, 240);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(188, 60);
            this.button7.TabIndex = 4;
            this.button7.Text = "Произведение матрицы на число";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Enabled = false;
            this.button6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button6.Location = new System.Drawing.Point(6, 174);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(188, 60);
            this.button6.TabIndex = 3;
            this.button6.Text = "Произведение двух матриц";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Enabled = false;
            this.button5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button5.Location = new System.Drawing.Point(6, 133);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(188, 35);
            this.button5.TabIndex = 2;
            this.button5.Text = "Разность";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button4.Location = new System.Drawing.Point(6, 92);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(188, 35);
            this.button4.TabIndex = 1;
            this.button4.Text = "Сложение";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button3.Location = new System.Drawing.Point(6, 22);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(188, 64);
            this.button3.TabIndex = 0;
            this.button3.Text = "Получить обратную матрицу";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // createNewMatrix
            // 
            this.createNewMatrix.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.createNewMatrix.Location = new System.Drawing.Point(18, 459);
            this.createNewMatrix.Name = "createNewMatrix";
            this.createNewMatrix.Size = new System.Drawing.Size(188, 64);
            this.createNewMatrix.TabIndex = 2;
            this.createNewMatrix.Text = "Создать новую матрицу";
            this.createNewMatrix.UseVisualStyleBackColor = true;
            this.createNewMatrix.Click += new System.EventHandler(this.createNewMatrix_Click);
            // 
            // delExtrMatrix
            // 
            this.delExtrMatrix.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.delExtrMatrix.Location = new System.Drawing.Point(18, 529);
            this.delExtrMatrix.Name = "delExtrMatrix";
            this.delExtrMatrix.Size = new System.Drawing.Size(188, 79);
            this.delExtrMatrix.TabIndex = 3;
            this.delExtrMatrix.Text = "Удалить дополнительную матрицу";
            this.delExtrMatrix.UseVisualStyleBackColor = true;
            this.delExtrMatrix.Visible = false;
            this.delExtrMatrix.Click += new System.EventHandler(this.delExtrMatrix_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 620);
            this.Controls.Add(this.delExtrMatrix);
            this.Controls.Add(this.createNewMatrix);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Матрицы";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private GroupBox groupBox1;
        private Button button3;
        private Button button8;
        private Button button7;
        private Button button6;
        private Button button5;
        private Button button4;
        private Button createNewMatrix;
        private Button changeDefaultMatrix;
        private Button delExtrMatrix;
    }
}