namespace zlpP
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
            panelRight = new Panel();
            panelLeft = new Panel();
            btnClear = new Button();
            label3 = new Label();
            btnSolve = new Button();
            label2 = new Label();
            label1 = new Label();
            lblStep = new Label();
            btnPrevStep = new Button();
            btnAddConstraint = new Button();
            btnNextStep = new Button();
            txtSolution = new RichTextBox();
            rbMin = new RadioButton();
            rbMax = new RadioButton();
            txtX2 = new TextBox();
            txtX1 = new TextBox();
            dataGridViewConstraints = new DataGridView();
            A = new DataGridViewTextBoxColumn();
            B = new DataGridViewTextBoxColumn();
            Sign = new DataGridViewTextBoxColumn();
            C = new DataGridViewTextBoxColumn();
            panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewConstraints).BeginInit();
            SuspendLayout();
            // 
            // panelRight
            // 
            panelRight.Location = new Point(396, 12);
            panelRight.Name = "panelRight";
            panelRight.Size = new Size(668, 801);
            panelRight.TabIndex = 3;
            panelRight.Paint += panelRight_Paint_1;
            // 
            // panelLeft
            // 
            panelLeft.Controls.Add(btnClear);
            panelLeft.Controls.Add(label3);
            panelLeft.Controls.Add(btnSolve);
            panelLeft.Controls.Add(label2);
            panelLeft.Controls.Add(label1);
            panelLeft.Controls.Add(lblStep);
            panelLeft.Controls.Add(btnPrevStep);
            panelLeft.Controls.Add(btnAddConstraint);
            panelLeft.Controls.Add(btnNextStep);
            panelLeft.Controls.Add(txtSolution);
            panelLeft.Controls.Add(rbMin);
            panelLeft.Controls.Add(rbMax);
            panelLeft.Controls.Add(txtX2);
            panelLeft.Controls.Add(txtX1);
            panelLeft.Controls.Add(dataGridViewConstraints);
            panelLeft.Location = new Point(12, 12);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(378, 801);
            panelLeft.TabIndex = 2;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(180, 502);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(112, 34);
            btnClear.TabIndex = 3;
            btnClear.Text = "очистить";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click_1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 578);
            label3.Name = "label3";
            label3.Size = new Size(83, 25);
            label3.TabIndex = 7;
            label3.Text = "Решение";
            // 
            // btnSolve
            // 
            btnSolve.Location = new Point(180, 542);
            btnSolve.Name = "btnSolve";
            btnSolve.Size = new Size(112, 34);
            btnSolve.TabIndex = 2;
            btnSolve.Text = "решить!";
            btnSolve.UseVisualStyleBackColor = true;
            btnSolve.Click += btnSolve_Click_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(97, 158);
            label2.Name = "label2";
            label2.Size = new Size(121, 25);
            label2.TabIndex = 6;
            label2.Text = "Ограничения";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 22);
            label1.Name = "label1";
            label1.Size = new Size(113, 25);
            label1.TabIndex = 5;
            label1.Text = "Целевая ф-я";
            // 
            // lblStep
            // 
            lblStep.AutoSize = true;
            lblStep.Location = new Point(130, 765);
            lblStep.Name = "lblStep";
            lblStep.Size = new Size(42, 25);
            lblStep.TabIndex = 4;
            lblStep.Text = "шаг";
            // 
            // btnPrevStep
            // 
            btnPrevStep.Location = new Point(12, 760);
            btnPrevStep.Name = "btnPrevStep";
            btnPrevStep.Size = new Size(112, 34);
            btnPrevStep.TabIndex = 5;
            btnPrevStep.Text = "назад";
            btnPrevStep.UseVisualStyleBackColor = true;
            btnPrevStep.Click += btnPrevStep_Click_1;
            // 
            // btnAddConstraint
            // 
            btnAddConstraint.Location = new Point(24, 464);
            btnAddConstraint.Name = "btnAddConstraint";
            btnAddConstraint.Size = new Size(159, 34);
            btnAddConstraint.TabIndex = 2;
            btnAddConstraint.Text = "добавить огр-е";
            btnAddConstraint.UseVisualStyleBackColor = true;
            btnAddConstraint.Click += btnAddConstraint_Click_1;
            // 
            // btnNextStep
            // 
            btnNextStep.Location = new Point(177, 760);
            btnNextStep.Name = "btnNextStep";
            btnNextStep.Size = new Size(112, 34);
            btnNextStep.TabIndex = 4;
            btnNextStep.Text = "след";
            btnNextStep.UseVisualStyleBackColor = true;
            btnNextStep.Click += btnNextStep_Click_1;
            // 
            // txtSolution
            // 
            txtSolution.Location = new Point(10, 606);
            txtSolution.Name = "txtSolution";
            txtSolution.Size = new Size(279, 144);
            txtSolution.TabIndex = 2;
            txtSolution.Text = "";
            // 
            // rbMin
            // 
            rbMin.AutoSize = true;
            rbMin.Location = new Point(222, 68);
            rbMin.Name = "rbMin";
            rbMin.Size = new Size(67, 29);
            rbMin.TabIndex = 3;
            rbMin.TabStop = true;
            rbMin.Text = "min";
            rbMin.UseVisualStyleBackColor = true;
            // 
            // rbMax
            // 
            rbMax.AutoSize = true;
            rbMax.Location = new Point(222, 33);
            rbMax.Name = "rbMax";
            rbMax.Size = new Size(70, 29);
            rbMax.TabIndex = 2;
            rbMax.TabStop = true;
            rbMax.Text = "max";
            rbMax.UseVisualStyleBackColor = true;
            // 
            // txtX2
            // 
            txtX2.Location = new Point(112, 66);
            txtX2.Name = "txtX2";
            txtX2.Size = new Size(37, 31);
            txtX2.TabIndex = 3;
            // 
            // txtX1
            // 
            txtX1.Location = new Point(59, 66);
            txtX1.Name = "txtX1";
            txtX1.Size = new Size(37, 31);
            txtX1.TabIndex = 2;
            // 
            // dataGridViewConstraints
            // 
            dataGridViewConstraints.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewConstraints.Columns.AddRange(new DataGridViewColumn[] { A, B, Sign, C });
            dataGridViewConstraints.Location = new Point(3, 186);
            dataGridViewConstraints.Name = "dataGridViewConstraints";
            dataGridViewConstraints.RowHeadersWidth = 62;
            dataGridViewConstraints.Size = new Size(372, 188);
            dataGridViewConstraints.TabIndex = 2;
            dataGridViewConstraints.CellValueChanged += dataGridViewConstraints_CellValueChanged_1;
            // 
            // A
            // 
            A.HeaderText = "Коэф. x1";
            A.MinimumWidth = 8;
            A.Name = "A";
            A.Width = 150;
            // 
            // B
            // 
            B.HeaderText = "Коэф. x2";
            B.MinimumWidth = 8;
            B.Name = "B";
            B.Width = 150;
            // 
            // Sign
            // 
            Sign.HeaderText = "Знак";
            Sign.MinimumWidth = 8;
            Sign.Name = "Sign";
            Sign.Width = 150;
            // 
            // C
            // 
            C.HeaderText = "Значение";
            C.MinimumWidth = 8;
            C.Name = "C";
            C.Width = 150;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1090, 827);
            Controls.Add(panelRight);
            Controls.Add(panelLeft);
            Name = "Form1";
            Text = "Form1";
            panelLeft.ResumeLayout(false);
            panelLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewConstraints).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelRight;
        private Panel panelLeft;
        private Button btnClear;
        private Label label3;
        private Button btnSolve;
        private Label label2;
        private Label label1;
        private Label lblStep;
        private Button btnPrevStep;
        private Button btnAddConstraint;
        private Button btnNextStep;
        private RichTextBox txtSolution;
        private RadioButton rbMin;
        private RadioButton rbMax;
        private TextBox txtX2;
        private TextBox txtX1;
        private DataGridView dataGridViewConstraints;
        private DataGridViewTextBoxColumn A;
        private DataGridViewTextBoxColumn B;
        private DataGridViewTextBoxColumn Sign;
        private DataGridViewTextBoxColumn C;
    }
}
