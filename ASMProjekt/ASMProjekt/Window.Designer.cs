using System;

namespace ASMProjekt
{
    partial class Window
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
            this.OrginalPic = new System.Windows.Forms.PictureBox();
            this.ModedPic = new System.Windows.Forms.PictureBox();
            this.Modify = new System.Windows.Forms.Button();
            this.Matrix3 = new System.Windows.Forms.RadioButton();
            this.Matrix2 = new System.Windows.Forms.RadioButton();
            this.Matrix1 = new System.Windows.Forms.RadioButton();
            this.MatrixBox = new System.Windows.Forms.GroupBox();
            this.Asm = new System.Windows.Forms.Button();
            this.ChosePic = new System.Windows.Forms.Button();
            this.TimeCounter = new System.Windows.Forms.Label();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.ThredNumber = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.OrginalPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModedPic)).BeginInit();
            this.MatrixBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // OrginalPic
            // 
            this.OrginalPic.Location = new System.Drawing.Point(12, 12);
            this.OrginalPic.Name = "OrginalPic";
            this.OrginalPic.Size = new System.Drawing.Size(431, 379);
            this.OrginalPic.TabIndex = 0;
            this.OrginalPic.TabStop = false;
            this.OrginalPic.Click += new System.EventHandler(this.OrginalPic_Click);
            // 
            // ModedPic
            // 
            this.ModedPic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ModedPic.Location = new System.Drawing.Point(571, 12);
            this.ModedPic.Name = "ModedPic";
            this.ModedPic.Size = new System.Drawing.Size(431, 379);
            this.ModedPic.TabIndex = 1;
            this.ModedPic.TabStop = false;
            // 
            // Modify
            // 
            this.Modify.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Modify.Location = new System.Drawing.Point(471, 462);
            this.Modify.Name = "Modify";
            this.Modify.Size = new System.Drawing.Size(75, 23);
            this.Modify.TabIndex = 2;
            this.Modify.Text = "C#";
            this.Modify.UseVisualStyleBackColor = true;
            this.Modify.Click += new System.EventHandler(this.Modify_Click);
            // 
            // Matrix3
            // 
            this.Matrix3.AutoSize = true;
            this.Matrix3.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Matrix3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Matrix3.Location = new System.Drawing.Point(6, 65);
            this.Matrix3.Name = "Matrix3";
            this.Matrix3.Size = new System.Drawing.Size(51, 22);
            this.Matrix3.TabIndex = 6;
            this.Matrix3.TabStop = true;
            this.Matrix3.Text = "7x7";
            this.Matrix3.UseVisualStyleBackColor = true;
            // 
            // Matrix2
            // 
            this.Matrix2.AutoSize = true;
            this.Matrix2.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Matrix2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Matrix2.Location = new System.Drawing.Point(6, 42);
            this.Matrix2.Name = "Matrix2";
            this.Matrix2.Size = new System.Drawing.Size(51, 22);
            this.Matrix2.TabIndex = 7;
            this.Matrix2.TabStop = true;
            this.Matrix2.Text = "5x5";
            this.Matrix2.UseVisualStyleBackColor = true;
            // 
            // Matrix1
            // 
            this.Matrix1.AutoSize = true;
            this.Matrix1.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Matrix1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Matrix1.Location = new System.Drawing.Point(6, 19);
            this.Matrix1.Name = "Matrix1";
            this.Matrix1.Size = new System.Drawing.Size(51, 22);
            this.Matrix1.TabIndex = 8;
            this.Matrix1.TabStop = true;
            this.Matrix1.Text = "3x3";
            this.Matrix1.UseVisualStyleBackColor = true;
            this.Matrix1.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // MatrixBox
            // 
            this.MatrixBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.MatrixBox.Controls.Add(this.Matrix1);
            this.MatrixBox.Controls.Add(this.Matrix3);
            this.MatrixBox.Controls.Add(this.Matrix2);
            this.MatrixBox.Location = new System.Drawing.Point(32, 462);
            this.MatrixBox.Name = "MatrixBox";
            this.MatrixBox.Size = new System.Drawing.Size(200, 100);
            this.MatrixBox.TabIndex = 9;
            this.MatrixBox.TabStop = false;
            // 
            // Asm
            // 
            this.Asm.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Asm.Location = new System.Drawing.Point(471, 539);
            this.Asm.Name = "Asm";
            this.Asm.Size = new System.Drawing.Size(75, 23);
            this.Asm.TabIndex = 10;
            this.Asm.Text = "Asm";
            this.Asm.UseVisualStyleBackColor = true;
            this.Asm.Click += new System.EventHandler(this.Asm_Click);
            // 
            // ChosePic
            // 
            this.ChosePic.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ChosePic.Location = new System.Drawing.Point(471, 12);
            this.ChosePic.Name = "ChosePic";
            this.ChosePic.Size = new System.Drawing.Size(75, 23);
            this.ChosePic.TabIndex = 11;
            this.ChosePic.Text = "Zdjęcie";
            this.ChosePic.UseVisualStyleBackColor = true;
            this.ChosePic.Click += new System.EventHandler(this.ChosePic_Click);
            // 
            // TimeCounter
            // 
            this.TimeCounter.AutoSize = true;
            this.TimeCounter.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeCounter.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.TimeCounter.Location = new System.Drawing.Point(486, 211);
            this.TimeCounter.Name = "TimeCounter";
            this.TimeCounter.Size = new System.Drawing.Size(41, 18);
            this.TimeCounter.TabIndex = 13;
            this.TimeCounter.Text = "Czas";
            // 
            // trackBar
            // 
            this.trackBar.Location = new System.Drawing.Point(714, 504);
            this.trackBar.Maximum = 6;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(164, 45);
            this.trackBar.TabIndex = 14;
            this.trackBar.Value = 1;
            this.trackBar.Scroll += new System.EventHandler(this.TrackBar_Scroll);
            // 
            // ThredNumber
            // 
            this.ThredNumber.AutoSize = true;
            this.ThredNumber.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThredNumber.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ThredNumber.Location = new System.Drawing.Point(711, 463);
            this.ThredNumber.Name = "ThredNumber";
            this.ThredNumber.Size = new System.Drawing.Size(116, 18);
            this.ThredNumber.TabIndex = 15;
            this.ThredNumber.Text = "Ilość Wątków:";
            this.ThredNumber.Click += new System.EventHandler(this.ThredNumber_Click);
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GrayText;
            this.ClientSize = new System.Drawing.Size(1014, 622);
            this.Controls.Add(this.ThredNumber);
            this.Controls.Add(this.trackBar);
            this.Controls.Add(this.TimeCounter);
            this.Controls.Add(this.ChosePic);
            this.Controls.Add(this.Asm);
            this.Controls.Add(this.MatrixBox);
            this.Controls.Add(this.Modify);
            this.Controls.Add(this.ModedPic);
            this.Controls.Add(this.OrginalPic);
            this.Name = "Window";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.OrginalPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ModedPic)).EndInit();
            this.MatrixBox.ResumeLayout(false);
            this.MatrixBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox OrginalPic;
        private System.Windows.Forms.PictureBox ModedPic;
        private System.Windows.Forms.Button Modify;
        private System.Windows.Forms.RadioButton Matrix3;
        private System.Windows.Forms.RadioButton Matrix2;
        private System.Windows.Forms.RadioButton Matrix1;
        private System.Windows.Forms.GroupBox MatrixBox;
        private System.Windows.Forms.Button Asm;
        private System.Windows.Forms.Button ChosePic;
        private System.Windows.Forms.Label TimeCounter;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.Label ThredNumber;
    }

}