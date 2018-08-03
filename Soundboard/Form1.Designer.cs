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
            this.newKeyBind = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // newKeyBind
            // 
            this.newKeyBind.Location = new System.Drawing.Point(197, 244);
            this.newKeyBind.Name = "newKeyBind";
            this.newKeyBind.Size = new System.Drawing.Size(138, 80);
            this.newKeyBind.TabIndex = 0;
            this.newKeyBind.Text = "Add New Keybind";
            this.newKeyBind.UseVisualStyleBackColor = true;
            this.newKeyBind.Click += new System.EventHandler(this.newKeyBind_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 549);
            this.Controls.Add(this.newKeyBind);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button newKeyBind;
    }
}

