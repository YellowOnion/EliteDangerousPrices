namespace Project7.Main
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
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnNewPlayer = new System.Windows.Forms.Button();
            this.inNewPlayer = new System.Windows.Forms.TextBox();
            this.cbPlayers = new System.Windows.Forms.ComboBox();
            this.btnJump = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.lblSystem = new System.Windows.Forms.Label();
            this.lblStation = new System.Windows.Forms.Label();
            this.lblCredit = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnDeletePlayer = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnDeletePlayer);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.btnNewPlayer);
            this.groupBox1.Controls.Add(this.inNewPlayer);
            this.groupBox1.Controls.Add(this.cbPlayers);
            this.groupBox1.Controls.Add(this.btnJump);
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Controls.Add(this.lblSystem);
            this.groupBox1.Controls.Add(this.lblStation);
            this.groupBox1.Controls.Add(this.lblCredit);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(591, 112);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Player";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(356, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // btnNewPlayer
            // 
            this.btnNewPlayer.Location = new System.Drawing.Point(244, 13);
            this.btnNewPlayer.Name = "btnNewPlayer";
            this.btnNewPlayer.Size = new System.Drawing.Size(82, 23);
            this.btnNewPlayer.TabIndex = 8;
            this.btnNewPlayer.Text = "New Player";
            this.btnNewPlayer.UseVisualStyleBackColor = true;
            this.btnNewPlayer.Click += new System.EventHandler(this.btnNewPlayer_Click);
            // 
            // inNewPlayer
            // 
            this.inNewPlayer.Location = new System.Drawing.Point(137, 16);
            this.inNewPlayer.Name = "inNewPlayer";
            this.inNewPlayer.Size = new System.Drawing.Size(100, 20);
            this.inNewPlayer.TabIndex = 7;
            // 
            // cbPlayers
            // 
            this.cbPlayers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPlayers.FormattingEnabled = true;
            this.cbPlayers.Location = new System.Drawing.Point(9, 16);
            this.cbPlayers.Name = "cbPlayers";
            this.cbPlayers.Size = new System.Drawing.Size(121, 21);
            this.cbPlayers.TabIndex = 6;
            this.cbPlayers.SelectedValueChanged += new System.EventHandler(this.cbPlayers_SelectedValueChanged);
            // 
            // btnJump
            // 
            this.btnJump.ForeColor = System.Drawing.Color.Transparent;
            this.btnJump.Location = new System.Drawing.Point(356, 77);
            this.btnJump.Name = "btnJump";
            this.btnJump.Size = new System.Drawing.Size(75, 23);
            this.btnJump.TabIndex = 5;
            this.btnJump.Text = "Jump to:";
            this.btnJump.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Right;
            this.listView1.Location = new System.Drawing.Point(437, 16);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(151, 93);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // lblSystem
            // 
            this.lblSystem.AutoSize = true;
            this.lblSystem.Location = new System.Drawing.Point(6, 60);
            this.lblSystem.Name = "lblSystem";
            this.lblSystem.Size = new System.Drawing.Size(19, 13);
            this.lblSystem.TabIndex = 3;
            this.lblSystem.Text = "<>";
            // 
            // lblStation
            // 
            this.lblStation.AutoSize = true;
            this.lblStation.Location = new System.Drawing.Point(6, 82);
            this.lblStation.Name = "lblStation";
            this.lblStation.Size = new System.Drawing.Size(19, 13);
            this.lblStation.TabIndex = 2;
            this.lblStation.Text = "<>";
            // 
            // lblCredit
            // 
            this.lblCredit.AutoSize = true;
            this.lblCredit.Location = new System.Drawing.Point(6, 37);
            this.lblCredit.Name = "lblCredit";
            this.lblCredit.Size = new System.Drawing.Size(19, 13);
            this.lblCredit.TabIndex = 1;
            this.lblCredit.Text = "<>";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Size = new System.Drawing.Size(591, 511);
            this.splitContainer1.SplitterDistance = 112;
            this.splitContainer1.TabIndex = 2;
            // 
            // btnDeletePlayer
            // 
            this.btnDeletePlayer.Location = new System.Drawing.Point(244, 43);
            this.btnDeletePlayer.Name = "btnDeletePlayer";
            this.btnDeletePlayer.Size = new System.Drawing.Size(82, 23);
            this.btnDeletePlayer.TabIndex = 10;
            this.btnDeletePlayer.Text = "Delete Player";
            this.btnDeletePlayer.UseVisualStyleBackColor = true;
            this.btnDeletePlayer.Click += new System.EventHandler(this.btnDeletePlayer_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(591, 511);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblCredit;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnJump;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label lblSystem;
        private System.Windows.Forms.Label lblStation;
        private System.Windows.Forms.ComboBox cbPlayers;
        private System.Windows.Forms.Button btnNewPlayer;
        private System.Windows.Forms.TextBox inNewPlayer;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnDeletePlayer;
    }
}

