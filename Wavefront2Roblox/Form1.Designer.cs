namespace Wavefront2Roblox
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
            this.components = new System.ComponentModel.Container();
            this.txtFileInput = new System.Windows.Forms.TextBox();
            this.lblInputIndicator = new System.Windows.Forms.Label();
            this.btnBrowseInput = new System.Windows.Forms.Button();
            this.ReaderProgress = new System.Windows.Forms.ProgressBar();
            this.ProgressUpdater = new System.Windows.Forms.Timer(this.components);
            this.ConverterProgress = new System.Windows.Forms.ProgressBar();
            this.btnOutputBrowse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFileOutput = new System.Windows.Forms.TextBox();
            this.btnDOIT = new System.Windows.Forms.Button();
            this.lblstat = new System.Windows.Forms.Label();
            this.saveWaiter = new System.Windows.Forms.Timer(this.components);
            this.readWaiter = new System.Windows.Forms.Timer(this.components);
            this.lblfaces = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtFileInput
            // 
            this.txtFileInput.Location = new System.Drawing.Point(15, 25);
            this.txtFileInput.Name = "txtFileInput";
            this.txtFileInput.Size = new System.Drawing.Size(359, 20);
            this.txtFileInput.TabIndex = 0;
            // 
            // lblInputIndicator
            // 
            this.lblInputIndicator.AutoSize = true;
            this.lblInputIndicator.Location = new System.Drawing.Point(12, 9);
            this.lblInputIndicator.Name = "lblInputIndicator";
            this.lblInputIndicator.Size = new System.Drawing.Size(50, 13);
            this.lblInputIndicator.TabIndex = 1;
            this.lblInputIndicator.Text = "Input file:";
            // 
            // btnBrowseInput
            // 
            this.btnBrowseInput.Location = new System.Drawing.Point(299, 51);
            this.btnBrowseInput.Name = "btnBrowseInput";
            this.btnBrowseInput.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseInput.TabIndex = 2;
            this.btnBrowseInput.Text = "Browse...";
            this.btnBrowseInput.UseVisualStyleBackColor = true;
            // 
            // ReaderProgress
            // 
            this.ReaderProgress.Location = new System.Drawing.Point(12, 201);
            this.ReaderProgress.Name = "ReaderProgress";
            this.ReaderProgress.Size = new System.Drawing.Size(359, 23);
            this.ReaderProgress.TabIndex = 4;
            // 
            // ConverterProgress
            // 
            this.ConverterProgress.Location = new System.Drawing.Point(12, 230);
            this.ConverterProgress.Name = "ConverterProgress";
            this.ConverterProgress.Size = new System.Drawing.Size(359, 23);
            this.ConverterProgress.TabIndex = 5;
            // 
            // btnOutputBrowse
            // 
            this.btnOutputBrowse.Location = new System.Drawing.Point(296, 106);
            this.btnOutputBrowse.Name = "btnOutputBrowse";
            this.btnOutputBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnOutputBrowse.TabIndex = 9;
            this.btnOutputBrowse.Text = "Browse...";
            this.btnOutputBrowse.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 8;
            this.label1.Tag = "Output fl";
            this.label1.Text = "Output file:";
            // 
            // txtFileOutput
            // 
            this.txtFileOutput.Location = new System.Drawing.Point(12, 80);
            this.txtFileOutput.Name = "txtFileOutput";
            this.txtFileOutput.Size = new System.Drawing.Size(359, 20);
            this.txtFileOutput.TabIndex = 7;
            // 
            // btnDOIT
            // 
            this.btnDOIT.Location = new System.Drawing.Point(12, 172);
            this.btnDOIT.Name = "btnDOIT";
            this.btnDOIT.Size = new System.Drawing.Size(359, 23);
            this.btnDOIT.TabIndex = 10;
            this.btnDOIT.Text = "JUST DO IT";
            this.btnDOIT.UseVisualStyleBackColor = true;
            // 
            // lblstat
            // 
            this.lblstat.AutoSize = true;
            this.lblstat.Location = new System.Drawing.Point(12, 156);
            this.lblstat.Name = "lblstat";
            this.lblstat.Size = new System.Drawing.Size(31, 13);
            this.lblstat.TabIndex = 11;
            this.lblstat.Text = "IDLE";
            // 
            // lblfaces
            // 
            this.lblfaces.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblfaces.Location = new System.Drawing.Point(191, 156);
            this.lblfaces.Name = "lblfaces";
            this.lblfaces.Size = new System.Drawing.Size(180, 13);
            this.lblfaces.TabIndex = 12;
            this.lblfaces.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 261);
            this.Controls.Add(this.lblfaces);
            this.Controls.Add(this.lblstat);
            this.Controls.Add(this.btnDOIT);
            this.Controls.Add(this.btnOutputBrowse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFileOutput);
            this.Controls.Add(this.ConverterProgress);
            this.Controls.Add(this.ReaderProgress);
            this.Controls.Add(this.btnBrowseInput);
            this.Controls.Add(this.lblInputIndicator);
            this.Controls.Add(this.txtFileInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wavefront2Roblox";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFileInput;
        private System.Windows.Forms.Label lblInputIndicator;
        private System.Windows.Forms.Button btnBrowseInput;
        private System.Windows.Forms.ProgressBar ReaderProgress;
        private System.Windows.Forms.Timer ProgressUpdater;
        private System.Windows.Forms.ProgressBar ConverterProgress;
        private System.Windows.Forms.Button btnOutputBrowse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFileOutput;
        private System.Windows.Forms.Button btnDOIT;
        private System.Windows.Forms.Label lblstat;
        private System.Windows.Forms.Timer saveWaiter;
        private System.Windows.Forms.Timer readWaiter;
        private System.Windows.Forms.Label lblfaces;
    }
}

