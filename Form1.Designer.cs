namespace Timer;

partial class Form1 {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
        if(disposing && (components != null)) {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.tbHours = new System.Windows.Forms.TextBox();
            this.tbMinutes = new System.Windows.Forms.TextBox();
            this.tbSeconds = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.bStart = new System.Windows.Forms.Button();
            this.bStop = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel1.Location = new System.Drawing.Point(166, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(20, 20);
            this.panel1.TabIndex = 1;
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
            this.panel1.MouseEnter += new System.EventHandler(this.panel1_MouseEnter);
            this.panel1.MouseLeave += new System.EventHandler(this.panel1_MouseLeave);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "x";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
            this.label2.MouseEnter += new System.EventHandler(this.panel1_MouseEnter);
            this.label2.MouseLeave += new System.EventHandler(this.panel1_MouseLeave);
            // 
            // tbHours
            // 
            this.tbHours.Font = new System.Drawing.Font("Courier New", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tbHours.Location = new System.Drawing.Point(24, 20);
            this.tbHours.MaxLength = 2;
            this.tbHours.Name = "tbHours";
            this.tbHours.Size = new System.Drawing.Size(42, 40);
            this.tbHours.TabIndex = 2;
            this.tbHours.Text = "00";
            this.tbHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbHours.TextChanged += new System.EventHandler(this.tbHours_TextChanged);
            this.tbHours.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TimeKeyDown);
            this.tbHours.Leave += new System.EventHandler(this.TimeLostFocus);
            // 
            // tbMinutes
            // 
            this.tbMinutes.Font = new System.Drawing.Font("Courier New", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tbMinutes.Location = new System.Drawing.Point(72, 20);
            this.tbMinutes.MaxLength = 2;
            this.tbMinutes.Name = "tbMinutes";
            this.tbMinutes.Size = new System.Drawing.Size(42, 40);
            this.tbMinutes.TabIndex = 3;
            this.tbMinutes.Text = "00";
            this.tbMinutes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbMinutes.TextChanged += new System.EventHandler(this.tbMinutes_TextChanged);
            this.tbMinutes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TimeKeyDown);
            this.tbMinutes.Leave += new System.EventHandler(this.TimeLostFocus);
            // 
            // tbSeconds
            // 
            this.tbSeconds.Font = new System.Drawing.Font("Courier New", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tbSeconds.Location = new System.Drawing.Point(120, 20);
            this.tbSeconds.MaxLength = 2;
            this.tbSeconds.Name = "tbSeconds";
            this.tbSeconds.Size = new System.Drawing.Size(42, 40);
            this.tbSeconds.TabIndex = 4;
            this.tbSeconds.Text = "00";
            this.tbSeconds.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbSeconds.TextChanged += new System.EventHandler(this.tbSeconds_TextChanged);
            this.tbSeconds.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TimeKeyDown);
            this.tbSeconds.Leave += new System.EventHandler(this.TimeLostFocus);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Courier New", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(54, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 33);
            this.label3.TabIndex = 5;
            this.label3.Text = ":";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Courier New", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(102, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 33);
            this.label4.TabIndex = 6;
            this.label4.Text = ":";
            // 
            // bStart
            // 
            this.bStart.Location = new System.Drawing.Point(12, 65);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(75, 23);
            this.bStart.TabIndex = 7;
            this.bStart.Text = "Start";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // bStop
            // 
            this.bStop.Enabled = false;
            this.bStop.Location = new System.Drawing.Point(99, 65);
            this.bStop.Name = "bStop";
            this.bStop.Size = new System.Drawing.Size(75, 23);
            this.bStop.TabIndex = 8;
            this.bStop.Text = "Stop";
            this.bStop.UseVisualStyleBackColor = true;
            this.bStop.Click += new System.EventHandler(this.bStop_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(186, 100);
            this.Controls.Add(this.bStop);
            this.Controls.Add(this.bStart);
            this.Controls.Add(this.tbSeconds);
            this.Controls.Add(this.tbMinutes);
            this.Controls.Add(this.tbHours);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Timer";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion
    private Panel panel1;
    private Label label2;
    private TextBox tbHours;
    private TextBox tbMinutes;
    private TextBox tbSeconds;
    private Label label3;
    private Label label4;
    private Button bStart;
    private Button bStop;
}
