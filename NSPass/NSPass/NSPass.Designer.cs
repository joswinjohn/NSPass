
namespace NSPass
{
    partial class NSPass
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
            this.onButton = new System.Windows.Forms.Button();
            this.domainBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.consoleBox = new System.Windows.Forms.RichTextBox();
            this.serverBox = new System.Windows.Forms.TextBox();
            this.portBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.blockCheck = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // onButton
            // 
            this.onButton.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.onButton.Location = new System.Drawing.Point(688, 25);
            this.onButton.Name = "onButton";
            this.onButton.Size = new System.Drawing.Size(73, 46);
            this.onButton.TabIndex = 0;
            this.onButton.Text = "CHECK";
            this.onButton.UseVisualStyleBackColor = true;
            this.onButton.Click += new System.EventHandler(this.onButton_Click);
            // 
            // domainBox
            // 
            this.domainBox.Location = new System.Drawing.Point(274, 51);
            this.domainBox.Name = "domainBox";
            this.domainBox.Size = new System.Drawing.Size(408, 20);
            this.domainBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(48, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 42);
            this.label1.TabIndex = 5;
            this.label1.Text = "NSPass";
            // 
            // consoleBox
            // 
            this.consoleBox.Location = new System.Drawing.Point(42, 104);
            this.consoleBox.Name = "consoleBox";
            this.consoleBox.ReadOnly = true;
            this.consoleBox.Size = new System.Drawing.Size(719, 293);
            this.consoleBox.TabIndex = 6;
            this.consoleBox.Text = "";
            // 
            // serverBox
            // 
            this.serverBox.Location = new System.Drawing.Point(274, 25);
            this.serverBox.Name = "serverBox";
            this.serverBox.Size = new System.Drawing.Size(303, 20);
            this.serverBox.TabIndex = 7;
            // 
            // portBox
            // 
            this.portBox.Location = new System.Drawing.Point(613, 27);
            this.portBox.Name = "portBox";
            this.portBox.Size = new System.Drawing.Size(69, 20);
            this.portBox.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(189, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "NSPass Server";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(189, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Domain Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(583, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Port";
            // 
            // blockCheck
            // 
            this.blockCheck.AutoSize = true;
            this.blockCheck.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blockCheck.Location = new System.Drawing.Point(323, 82);
            this.blockCheck.Name = "blockCheck";
            this.blockCheck.Size = new System.Drawing.Size(163, 19);
            this.blockCheck.TabIndex = 12;
            this.blockCheck.Text = "Domain Blocked Check";
            this.blockCheck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(586, 403);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(175, 35);
            this.saveButton.TabIndex = 13;
            this.saveButton.Text = "Save New Hosts File";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // NSPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 450);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.blockCheck);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.portBox);
            this.Controls.Add(this.serverBox);
            this.Controls.Add(this.consoleBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.domainBox);
            this.Controls.Add(this.onButton);
            this.MaximizeBox = false;
            this.Name = "NSPass";
            this.Text = "NSPass";
            this.Load += new System.EventHandler(this.NSPass_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button onButton;
        private System.Windows.Forms.TextBox domainBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox consoleBox;
        private System.Windows.Forms.TextBox serverBox;
        private System.Windows.Forms.TextBox portBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label blockCheck;
        private System.Windows.Forms.Button saveButton;
    }
}

