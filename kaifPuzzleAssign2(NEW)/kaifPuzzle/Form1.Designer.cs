namespace kaifPuzzle
{
    partial class Form1
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
            this.tbl1 = new System.Windows.Forms.TableLayoutPanel();
            this.clock1 = new kaifPuzzle.clock();
            this.button2 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Moves = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Select = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tb3 = new System.Windows.Forms.TableLayoutPanel();
            this.down = new System.Windows.Forms.Button();
            this.Left = new System.Windows.Forms.Button();
            this.UP = new System.Windows.Forms.Button();
            this.right = new System.Windows.Forms.Button();
            this.tb2 = new System.Windows.Forms.TableLayoutPanel();
            this.tbl1.SuspendLayout();
            this.tb3.SuspendLayout();
            this.tb2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbl1
            // 
            this.tbl1.ColumnCount = 2;
            this.tbl1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbl1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tbl1.Controls.Add(this.tb2, 1, 0);
            this.tbl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbl1.Location = new System.Drawing.Point(0, 0);
            this.tbl1.Margin = new System.Windows.Forms.Padding(0);
            this.tbl1.Name = "tbl1";
            this.tbl1.RowCount = 1;
            this.tbl1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbl1.Size = new System.Drawing.Size(784, 634);
            this.tbl1.TabIndex = 5;
            // 
            // clock1
            // 
            this.clock1.Location = new System.Drawing.Point(3, 133);
            this.clock1.Name = "clock1";
            this.clock1.Size = new System.Drawing.Size(135, 140);
            this.clock1.TabIndex = 6;
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(3, 554);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(144, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Resume";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Name,
            this.Moves,
            this.Time});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(3, 284);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(144, 264);
            this.listView1.TabIndex = 7;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // Name
            // 
            this.Name.Text = "Name";
            this.Name.Width = 40;
            // 
            // Moves
            // 
            this.Moves.Text = "Moves";
            this.Moves.Width = 48;
            // 
            // Time
            // 
            this.Time.Text = "Time";
            this.Time.Width = 64;
            // 
            // Select
            // 
            this.Select.Location = new System.Drawing.Point(0, 0);
            this.Select.Margin = new System.Windows.Forms.Padding(0);
            this.Select.Name = "Select";
            this.Select.Size = new System.Drawing.Size(150, 30);
            this.Select.TabIndex = 4;
            this.Select.Text = "Click Folder";
            this.Select.UseVisualStyleBackColor = true;
            this.Select.Click += new System.EventHandler(this.Select_Click);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(3, 583);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 38);
            this.button1.TabIndex = 1;
            this.button1.Text = "Pause";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // tb3
            // 
            this.tb3.ColumnCount = 2;
            this.tb3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tb3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tb3.Controls.Add(this.right, 1, 0);
            this.tb3.Controls.Add(this.UP, 0, 0);
            this.tb3.Controls.Add(this.Left, 1, 1);
            this.tb3.Controls.Add(this.down, 0, 1);
            this.tb3.Location = new System.Drawing.Point(0, 30);
            this.tb3.Margin = new System.Windows.Forms.Padding(0);
            this.tb3.Name = "tb3";
            this.tb3.RowCount = 2;
            this.tb3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tb3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tb3.Size = new System.Drawing.Size(150, 100);
            this.tb3.TabIndex = 5;
            // 
            // down
            // 
            this.down.BackColor = System.Drawing.SystemColors.Highlight;
            this.down.ForeColor = System.Drawing.SystemColors.Window;
            this.down.Location = new System.Drawing.Point(0, 50);
            this.down.Margin = new System.Windows.Forms.Padding(0);
            this.down.Name = "down";
            this.down.Size = new System.Drawing.Size(63, 37);
            this.down.TabIndex = 3;
            this.down.Text = "DOWN vv";
            this.down.UseVisualStyleBackColor = false;
            this.down.Click += new System.EventHandler(this.button3_Click);
            // 
            // Left
            // 
            this.Left.BackColor = System.Drawing.SystemColors.GrayText;
            this.Left.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Left.Location = new System.Drawing.Point(75, 50);
            this.Left.Margin = new System.Windows.Forms.Padding(0);
            this.Left.Name = "Left";
            this.Left.Size = new System.Drawing.Size(49, 37);
            this.Left.TabIndex = 1;
            this.Left.Text = "LEFT <<";
            this.Left.UseVisualStyleBackColor = false;
            this.Left.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // UP
            // 
            this.UP.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.UP.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.UP.Location = new System.Drawing.Point(0, 0);
            this.UP.Margin = new System.Windows.Forms.Padding(0);
            this.UP.Name = "UP";
            this.UP.Size = new System.Drawing.Size(63, 35);
            this.UP.TabIndex = 0;
            this.UP.Text = "UP ^^";
            this.UP.UseVisualStyleBackColor = false;
            this.UP.Click += new System.EventHandler(this.button1_Click);
            // 
            // right
            // 
            this.right.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.right.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.right.Location = new System.Drawing.Point(75, 0);
            this.right.Margin = new System.Windows.Forms.Padding(0);
            this.right.Name = "right";
            this.right.Size = new System.Drawing.Size(56, 35);
            this.right.TabIndex = 2;
            this.right.Text = "RIGHT >>";
            this.right.UseVisualStyleBackColor = false;
            this.right.Click += new System.EventHandler(this.right_Click);
            // 
            // tb2
            // 
            this.tb2.ColumnCount = 1;
            this.tb2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tb2.Controls.Add(this.tb3, 0, 1);
            this.tb2.Controls.Add(this.button1, 0, 5);
            this.tb2.Controls.Add(this.Select, 0, 0);
            this.tb2.Controls.Add(this.listView1, 0, 3);
            this.tb2.Controls.Add(this.button2, 0, 4);
            this.tb2.Controls.Add(this.clock1, 0, 2);
            this.tb2.Location = new System.Drawing.Point(634, 0);
            this.tb2.Margin = new System.Windows.Forms.Padding(0);
            this.tb2.Name = "tb2";
            this.tb2.RowCount = 7;
            this.tb2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tb2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tb2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 151F));
            this.tb2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 270F));
            this.tb2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tb2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tb2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tb2.Size = new System.Drawing.Size(150, 634);
            this.tb2.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 634);
            this.Controls.Add(this.tbl1);
            //this.Name = "Form1";
            this.Text = "Form1";
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.tbl1.ResumeLayout(false);
            this.tb3.ResumeLayout(false);
            this.tb2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tbl1;
        private System.Windows.Forms.TableLayoutPanel tb2;
        private System.Windows.Forms.TableLayoutPanel tb3;
        private System.Windows.Forms.Button right;
        private System.Windows.Forms.Button UP;
        private System.Windows.Forms.Button Left;
        private System.Windows.Forms.Button down;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Select;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Name;
        private System.Windows.Forms.ColumnHeader Moves;
        private System.Windows.Forms.ColumnHeader Time;
        private System.Windows.Forms.Button button2;
        private clock clock1;
    }
}

