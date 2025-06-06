namespace Sudoku
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
            SUDOKU = new Label();
            dataGridView1 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            Column8 = new DataGridViewTextBoxColumn();
            Column9 = new DataGridViewTextBoxColumn();
            groupBox1 = new GroupBox();
            schwer = new RadioButton();
            mittel = new RadioButton();
            leicht = new RadioButton();
            newgame = new Button();
            resetgame = new Button();
            showresult = new Button();
            fails = new Label();
            resultsudoku = new Button();
            label1 = new Label();
            redo = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // SUDOKU
            // 
            SUDOKU.AutoSize = true;
            SUDOKU.Font = new Font("Unispace", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SUDOKU.Location = new Point(8, 9);
            SUDOKU.Name = "SUDOKU";
            SUDOKU.Size = new Size(199, 58);
            SUDOKU.TabIndex = 0;
            SUDOKU.Text = "SUDOKU";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5, Column6, Column7, Column8, Column9 });
            dataGridView1.Location = new Point(8, 75);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.RowTemplate.Height = 40;
            dataGridView1.Size = new Size(363, 363);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            dataGridView1.Paint += dataGridView1_Paint;
            // 
            // Column1
            // 
            Column1.HeaderText = "Column1";
            Column1.Name = "Column1";
            // 
            // Column2
            // 
            Column2.HeaderText = "Column2";
            Column2.Name = "Column2";
            // 
            // Column3
            // 
            Column3.HeaderText = "Column3";
            Column3.Name = "Column3";
            // 
            // Column4
            // 
            Column4.HeaderText = "Column4";
            Column4.Name = "Column4";
            // 
            // Column5
            // 
            Column5.HeaderText = "Column5";
            Column5.Name = "Column5";
            // 
            // Column6
            // 
            Column6.HeaderText = "Column6";
            Column6.Name = "Column6";
            // 
            // Column7
            // 
            Column7.HeaderText = "Column7";
            Column7.Name = "Column7";
            // 
            // Column8
            // 
            Column8.HeaderText = "Column8";
            Column8.Name = "Column8";
            // 
            // Column9
            // 
            Column9.HeaderText = "Column9";
            Column9.Name = "Column9";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(schwer);
            groupBox1.Controls.Add(mittel);
            groupBox1.Controls.Add(leicht);
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(377, 86);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(169, 106);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Schwierigkeit";
            // 
            // schwer
            // 
            schwer.AutoSize = true;
            schwer.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            schwer.Location = new Point(42, 72);
            schwer.Name = "schwer";
            schwer.Size = new Size(81, 25);
            schwer.TabIndex = 2;
            schwer.Text = "schwer";
            schwer.UseVisualStyleBackColor = true;
            // 
            // mittel
            // 
            mittel.AutoSize = true;
            mittel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            mittel.Location = new Point(42, 47);
            mittel.Name = "mittel";
            mittel.Size = new Size(74, 25);
            mittel.TabIndex = 1;
            mittel.Text = "mittel";
            mittel.UseVisualStyleBackColor = true;
            // 
            // leicht
            // 
            leicht.AutoSize = true;
            leicht.Checked = true;
            leicht.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            leicht.Location = new Point(42, 22);
            leicht.Name = "leicht";
            leicht.Size = new Size(71, 25);
            leicht.TabIndex = 0;
            leicht.TabStop = true;
            leicht.Text = "leicht";
            leicht.UseVisualStyleBackColor = true;
            // 
            // newgame
            // 
            newgame.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            newgame.Location = new Point(377, 198);
            newgame.Name = "newgame";
            newgame.Size = new Size(169, 27);
            newgame.TabIndex = 3;
            newgame.Text = "Neues Spiel";
            newgame.UseVisualStyleBackColor = true;
            newgame.Click += newgame_Click;
            // 
            // resetgame
            // 
            resetgame.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            resetgame.Location = new Point(377, 360);
            resetgame.Name = "resetgame";
            resetgame.Size = new Size(169, 27);
            resetgame.TabIndex = 4;
            resetgame.Text = "Spielfeld leeren";
            resetgame.UseVisualStyleBackColor = true;
            resetgame.Click += resetgame_Click;
            // 
            // showresult
            // 
            showresult.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            showresult.Location = new Point(377, 264);
            showresult.Name = "showresult";
            showresult.Size = new Size(169, 27);
            showresult.TabIndex = 5;
            showresult.Text = "Lösung aufdecken";
            showresult.UseVisualStyleBackColor = true;
            showresult.Click += showresult_Click;
            // 
            // fails
            // 
            fails.AutoSize = true;
            fails.Font = new Font("Segoe UI Black", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            fails.ForeColor = Color.Red;
            fails.Location = new Point(419, 440);
            fails.Name = "fails";
            fails.Size = new Size(112, 25);
            fails.TabIndex = 6;
            fails.Text = "Fehler: 0/3";
            // 
            // resultsudoku
            // 
            resultsudoku.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            resultsudoku.Location = new Point(377, 327);
            resultsudoku.Name = "resultsudoku";
            resultsudoku.Size = new Size(169, 27);
            resultsudoku.TabIndex = 8;
            resultsudoku.Text = "Spielfeld lösen";
            resultsudoku.UseVisualStyleBackColor = true;
            resultsudoku.Click += resultsudoku_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(377, 309);
            label1.Name = "label1";
            label1.Size = new Size(90, 15);
            label1.TabIndex = 9;
            label1.Text = "Eigenes Sudoku";
            // 
            // redo
            // 
            redo.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            redo.Location = new Point(377, 231);
            redo.Name = "redo";
            redo.Size = new Size(169, 27);
            redo.TabIndex = 10;
            redo.Text = "Spiel zurücksetzen";
            redo.UseVisualStyleBackColor = true;
            redo.Click += redo_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(571, 474);
            Controls.Add(redo);
            Controls.Add(label1);
            Controls.Add(resultsudoku);
            Controls.Add(fails);
            Controls.Add(showresult);
            Controls.Add(resetgame);
            Controls.Add(newgame);
            Controls.Add(groupBox1);
            Controls.Add(dataGridView1);
            Controls.Add(SUDOKU);
            Name = "Form1";
            Text = "Sudoku";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label SUDOKU;
        private DataGridView dataGridView1;
        private GroupBox groupBox1;
        private RadioButton schwer;
        private RadioButton mittel;
        private RadioButton leicht;
        private Button newgame;
        private Button resetgame;
        private Button showresult;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewTextBoxColumn Column9;
        private Label fails;
        private Button resultsudoku;
        private Label label1;
        private Button redo;
    }
}
