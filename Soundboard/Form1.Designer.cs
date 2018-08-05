namespace Soundboard
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
            this.saveButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.keyToPressTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.OpenFileButton = new System.Windows.Forms.Button();
            this.soundPathText = new System.Windows.Forms.TextBox();
            this.rebindButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(340, 195);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 31);
            this.saveButton.TabIndex = 13;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(348, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Note: Each Key bind will have to be used with Alt";
            // 
            // keyToPressTextBox
            // 
            this.keyToPressTextBox.Location = new System.Drawing.Point(144, 23);
            this.keyToPressTextBox.Name = "keyToPressTextBox";
            this.keyToPressTextBox.Size = new System.Drawing.Size(100, 26);
            this.keyToPressTextBox.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Key To Press";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "soundFileDialog";
            this.openFileDialog1.InitialDirectory = "C:\\";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Sound Path";
            // 
            // OpenFileButton
            // 
            this.OpenFileButton.Location = new System.Drawing.Point(340, 68);
            this.OpenFileButton.Name = "OpenFileButton";
            this.OpenFileButton.Size = new System.Drawing.Size(75, 35);
            this.OpenFileButton.TabIndex = 11;
            this.OpenFileButton.Text = "Browse";
            this.OpenFileButton.UseVisualStyleBackColor = true;
            this.OpenFileButton.Click += new System.EventHandler(this.OpenFileButton_Click);
            // 
            // soundPathText
            // 
            this.soundPathText.Location = new System.Drawing.Point(144, 70);
            this.soundPathText.Name = "soundPathText";
            this.soundPathText.Size = new System.Drawing.Size(190, 26);
            this.soundPathText.TabIndex = 10;
            // 
            // rebindButton
            // 
            this.rebindButton.Location = new System.Drawing.Point(16, 195);
            this.rebindButton.Name = "rebindButton";
            this.rebindButton.Size = new System.Drawing.Size(75, 31);
            this.rebindButton.TabIndex = 14;
            this.rebindButton.Text = "Rebind";
            this.rebindButton.UseVisualStyleBackColor = true;
            this.rebindButton.Click += new System.EventHandler(this.rebindButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 245);
            this.Controls.Add(this.rebindButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.keyToPressTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.OpenFileButton);
            this.Controls.Add(this.soundPathText);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Soundboard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox keyToPressTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button OpenFileButton;
        private System.Windows.Forms.TextBox soundPathText;
        private System.Windows.Forms.Button rebindButton;
    }
}

