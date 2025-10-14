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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panelRight = new Panel();
            panelLeft = new Panel();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
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
            panelRight.Font = new Font("GOST type A", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panelRight.Location = new Point(515, 11);
            panelRight.Margin = new Padding(4, 3, 4, 3);
            panelRight.Name = "panelRight";
            panelRight.Size = new Size(868, 705);
            panelRight.TabIndex = 3;
            panelRight.Paint += panelRight_Paint_1;
            // 
            // panelLeft
            // 
            panelLeft.Controls.Add(label7);
            panelLeft.Controls.Add(label6);
            panelLeft.Controls.Add(label5);
            panelLeft.Controls.Add(label4);
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
            panelLeft.Location = new Point(16, 11);
            panelLeft.Margin = new Padding(4, 3, 4, 3);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(491, 705);
            panelLeft.TabIndex = 2;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("GOST Type BU", 14F, FontStyle.Italic, GraphicsUnit.Point, 204);
            label7.Location = new Point(205, 56);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(30, 33);
            label7.TabIndex = 11;
            label7.Text = "+";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("GOST Type BU", 9.999999F, FontStyle.Italic, GraphicsUnit.Point, 204);
            label6.Location = new Point(13, 58);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(60, 24);
            label6.TabIndex = 10;
            label6.Text = "F(x) =";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("GOST Type BU", 9.999999F, FontStyle.Italic, GraphicsUnit.Point, 204);
            label5.Location = new Point(311, 64);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(25, 24);
            label5.TabIndex = 9;
            label5.Text = "x₂";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("GOST Type BU", 9.999999F, FontStyle.Italic, GraphicsUnit.Point, 204);
            label4.Location = new Point(169, 64);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(25, 24);
            label4.TabIndex = 8;
            label4.Text = "x₁";
            // 
            // btnClear
            // 
            btnClear.Font = new Font("GOST type A", 10F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnClear.Location = new Point(276, 363);
            btnClear.Margin = new Padding(4, 3, 4, 3);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(192, 30);
            btnClear.TabIndex = 3;
            btnClear.Text = "Очистить всё";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click_1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("GOST type A", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label3.Location = new Point(17, 449);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(88, 25);
            label3.TabIndex = 7;
            label3.Text = "Решение";
            // 
            // btnSolve
            // 
            btnSolve.BackColor = Color.LightSteelBlue;
            btnSolve.Font = new Font("GOST type A", 10F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnSolve.Location = new Point(276, 408);
            btnSolve.Margin = new Padding(4, 3, 4, 3);
            btnSolve.Name = "btnSolve";
            btnSolve.Size = new Size(187, 33);
            btnSolve.TabIndex = 2;
            btnSolve.Text = "Решить";
            btnSolve.UseVisualStyleBackColor = false;
            btnSolve.Click += btnSolve_Click_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("GOST type A", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.Location = new Point(169, 117);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(124, 25);
            label2.TabIndex = 6;
            label2.Text = "Ограничения";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("GOST Type BU", 9.999999F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(16, 21);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(176, 24);
            label1.TabIndex = 5;
            label1.Text = "Целевая функция";
            // 
            // lblStep
            // 
            lblStep.AutoSize = true;
            lblStep.Font = new Font("GOST type A", 10F, FontStyle.Italic, GraphicsUnit.Point, 204);
            lblStep.Location = new Point(221, 673);
            lblStep.Margin = new Padding(4, 0, 4, 0);
            lblStep.Name = "lblStep";
            lblStep.Size = new Size(37, 21);
            lblStep.TabIndex = 4;
            lblStep.Text = "Шаг";
            // 
            // btnPrevStep
            // 
            btnPrevStep.Font = new Font("GOST type A", 14F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnPrevStep.Location = new Point(16, 669);
            btnPrevStep.Margin = new Padding(4, 3, 4, 3);
            btnPrevStep.Name = "btnPrevStep";
            btnPrevStep.Size = new Size(146, 30);
            btnPrevStep.TabIndex = 5;
            btnPrevStep.Text = "<<";
            btnPrevStep.UseVisualStyleBackColor = true;
            btnPrevStep.Click += btnPrevStep_Click_1;
            // 
            // btnAddConstraint
            // 
            btnAddConstraint.Font = new Font("GOST type A", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnAddConstraint.Location = new Point(17, 321);
            btnAddConstraint.Margin = new Padding(4, 3, 4, 3);
            btnAddConstraint.Name = "btnAddConstraint";
            btnAddConstraint.Size = new Size(169, 30);
            btnAddConstraint.TabIndex = 2;
            btnAddConstraint.Text = "Добавить огр-е";
            btnAddConstraint.UseVisualStyleBackColor = true;
            btnAddConstraint.Click += btnAddConstraint_Click_1;
            // 
            // btnNextStep
            // 
            btnNextStep.Font = new Font("GOST type A", 14F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnNextStep.Location = new Point(342, 669);
            btnNextStep.Margin = new Padding(4, 3, 4, 3);
            btnNextStep.Name = "btnNextStep";
            btnNextStep.Size = new Size(146, 30);
            btnNextStep.TabIndex = 4;
            btnNextStep.Text = ">>";
            btnNextStep.UseVisualStyleBackColor = true;
            btnNextStep.Click += btnNextStep_Click_1;
            // 
            // txtSolution
            // 
            txtSolution.Font = new Font("GOST type A", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSolution.Location = new Point(13, 481);
            txtSolution.Margin = new Padding(4, 3, 4, 3);
            txtSolution.Name = "txtSolution";
            txtSolution.Size = new Size(473, 183);
            txtSolution.TabIndex = 2;
            txtSolution.Text = "";
            // 
            // rbMin
            // 
            rbMin.AutoSize = true;
            rbMin.Font = new Font("GOST type A", 9F);
            rbMin.Location = new Point(393, 82);
            rbMin.Margin = new Padding(4, 3, 4, 3);
            rbMin.Name = "rbMin";
            rbMin.Size = new Size(54, 23);
            rbMin.TabIndex = 3;
            rbMin.TabStop = true;
            rbMin.Text = "min";
            rbMin.UseVisualStyleBackColor = true;
            // 
            // rbMax
            // 
            rbMax.AutoSize = true;
            rbMax.Font = new Font("GOST type A", 9F);
            rbMax.Location = new Point(393, 51);
            rbMax.Margin = new Padding(4, 3, 4, 3);
            rbMax.Name = "rbMax";
            rbMax.Size = new Size(58, 23);
            rbMax.TabIndex = 2;
            rbMax.TabStop = true;
            rbMax.Text = "max";
            rbMax.UseVisualStyleBackColor = true;
            // 
            // txtX2
            // 
            txtX2.Location = new Point(259, 58);
            txtX2.Margin = new Padding(4, 3, 4, 3);
            txtX2.Name = "txtX2";
            txtX2.Size = new Size(47, 29);
            txtX2.TabIndex = 3;
            // 
            // txtX1
            // 
            txtX1.Location = new Point(113, 58);
            txtX1.Margin = new Padding(4, 3, 4, 3);
            txtX1.Name = "txtX1";
            txtX1.Size = new Size(47, 29);
            txtX1.TabIndex = 2;
            // 
            // dataGridViewConstraints
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("GOST type A", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridViewConstraints.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewConstraints.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewConstraints.Columns.AddRange(new DataGridViewColumn[] { A, B, Sign, C });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Magneto", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.Navy;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridViewConstraints.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewConstraints.Location = new Point(4, 142);
            dataGridViewConstraints.Margin = new Padding(4, 3, 4, 3);
            dataGridViewConstraints.Name = "dataGridViewConstraints";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("GOST type A", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridViewConstraints.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewConstraints.RowHeadersWidth = 62;
            dataGridViewConstraints.Size = new Size(484, 165);
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
            AutoScaleDimensions = new SizeF(13F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1417, 728);
            Controls.Add(panelRight);
            Controls.Add(panelLeft);
            Font = new Font("Magneto", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "Решение ЗЛП графическим методом";
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
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
    }
}
