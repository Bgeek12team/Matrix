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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.changeDefaultMatrix = new System.Windows.Forms.Button();
            this.buttonSlay = new System.Windows.Forms.Button();
            this.buttonMultNumb = new System.Windows.Forms.Button();
            this.buttonMultMatrx = new System.Windows.Forms.Button();
            this.buttonSub = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonGetRevMatrx = new System.Windows.Forms.Button();
            this.createNewMatrix = new System.Windows.Forms.Button();
            this.delExtrMatrix = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.changeDefaultMatrix);
            this.groupBox1.Controls.Add(this.buttonSlay);
            this.groupBox1.Controls.Add(this.buttonMultNumb);
            this.groupBox1.Controls.Add(this.buttonMultMatrx);
            this.groupBox1.Controls.Add(this.buttonSub);
            this.groupBox1.Controls.Add(this.buttonAdd);
            this.groupBox1.Controls.Add(this.buttonGetRevMatrx);
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
            // buttonSlay
            // 
            this.buttonSlay.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonSlay.Location = new System.Drawing.Point(6, 306);
            this.buttonSlay.Name = "buttonSlay";
            this.buttonSlay.Size = new System.Drawing.Size(188, 35);
            this.buttonSlay.TabIndex = 5;
            this.buttonSlay.Text = "СЛАУ";
            this.buttonSlay.UseVisualStyleBackColor = true;
            this.buttonSlay.Click += new System.EventHandler(this.button8_Click);
            // 
            // buttonMultNumb
            // 
            this.buttonMultNumb.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonMultNumb.Location = new System.Drawing.Point(6, 240);
            this.buttonMultNumb.Name = "buttonMultNumb";
            this.buttonMultNumb.Size = new System.Drawing.Size(188, 60);
            this.buttonMultNumb.TabIndex = 4;
            this.buttonMultNumb.Text = "Произведение матрицы на число";
            this.buttonMultNumb.UseVisualStyleBackColor = true;
            this.buttonMultNumb.Click += new System.EventHandler(this.buttonMultNumb_Click);
            // 
            // buttonMultMatrx
            // 
            this.buttonMultMatrx.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonMultMatrx.Location = new System.Drawing.Point(6, 174);
            this.buttonMultMatrx.Name = "buttonMultMatrx";
            this.buttonMultMatrx.Size = new System.Drawing.Size(188, 60);
            this.buttonMultMatrx.TabIndex = 3;
            this.buttonMultMatrx.Text = "Произведение двух матриц";
            this.buttonMultMatrx.UseVisualStyleBackColor = true;
            this.buttonMultMatrx.Click += new System.EventHandler(this.buttonMultMatrx_Click);
            // 
            // buttonSub
            // 
            this.buttonSub.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonSub.Location = new System.Drawing.Point(6, 133);
            this.buttonSub.Name = "buttonSub";
            this.buttonSub.Size = new System.Drawing.Size(188, 35);
            this.buttonSub.TabIndex = 2;
            this.buttonSub.Text = "Разность";
            this.buttonSub.UseVisualStyleBackColor = true;
            this.buttonSub.Click += new System.EventHandler(this.buttonSub_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonAdd.Location = new System.Drawing.Point(6, 92);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(188, 35);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "Сложение";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonGetRevMatrx
            // 
            this.buttonGetRevMatrx.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonGetRevMatrx.Location = new System.Drawing.Point(6, 22);
            this.buttonGetRevMatrx.Name = "buttonGetRevMatrx";
            this.buttonGetRevMatrx.Size = new System.Drawing.Size(188, 64);
            this.buttonGetRevMatrx.TabIndex = 0;
            this.buttonGetRevMatrx.Text = "Получить обратную матрицу";
            this.buttonGetRevMatrx.UseVisualStyleBackColor = true;
            this.buttonGetRevMatrx.Click += new System.EventHandler(this.buttonGetRevMatrx_Click);
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
            this.delExtrMatrix.Size = new System.Drawing.Size(188, 64);
            this.delExtrMatrix.TabIndex = 3;
            this.delExtrMatrix.Text = "Удалить дополнительную матрицу";
            this.delExtrMatrix.UseVisualStyleBackColor = true;
            this.delExtrMatrix.Visible = false;
            this.delExtrMatrix.Click += new System.EventHandler(this.delExtrMatrix_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 620);
            this.Controls.Add(this.delExtrMatrix);
            this.Controls.Add(this.createNewMatrix);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Матрицы";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private GroupBox groupBox1;
        private Button buttonGetRevMatrx;
        private Button buttonSlay;
        private Button buttonMultNumb;
        private Button buttonMultMatrx;
        private Button buttonSub;
        private Button buttonAdd;
        private Button createNewMatrix;
        private Button changeDefaultMatrix;
        private Button delExtrMatrix;
        private ErrorProvider errorProvider1;
    }
}