namespace ProttoEncrypter
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
            System.Windows.Forms.Button DecryptaButton;
            this.NormalText = new System.Windows.Forms.RichTextBox();
            this.EncrypterText = new System.Windows.Forms.RichTextBox();
            this.CryptaButton = new System.Windows.Forms.Button();
            this.PassphraseText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            DecryptaButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NormalText
            // 
            this.NormalText.Location = new System.Drawing.Point(12, 117);
            this.NormalText.Name = "NormalText";
            this.NormalText.Size = new System.Drawing.Size(401, 87);
            this.NormalText.TabIndex = 0;
            this.NormalText.Text = "";
            // 
            // EncrypterText
            // 
            this.EncrypterText.Location = new System.Drawing.Point(12, 225);
            this.EncrypterText.Name = "EncrypterText";
            this.EncrypterText.Size = new System.Drawing.Size(401, 87);
            this.EncrypterText.TabIndex = 1;
            this.EncrypterText.Text = "";
            // 
            // CryptaButton
            // 
            this.CryptaButton.Location = new System.Drawing.Point(12, 25);
            this.CryptaButton.Name = "CryptaButton";
            this.CryptaButton.Size = new System.Drawing.Size(128, 47);
            this.CryptaButton.TabIndex = 2;
            this.CryptaButton.Text = "Crypta";
            this.CryptaButton.UseVisualStyleBackColor = true;
            this.CryptaButton.Click += new System.EventHandler(this.CryptaButton_Click);
            // 
            // DecryptaButton
            // 
            DecryptaButton.Location = new System.Drawing.Point(285, 25);
            DecryptaButton.Name = "DecryptaButton";
            DecryptaButton.Size = new System.Drawing.Size(128, 47);
            DecryptaButton.TabIndex = 3;
            DecryptaButton.Text = "Decrypta";
            DecryptaButton.UseVisualStyleBackColor = true;
            DecryptaButton.Click += new System.EventHandler(this.DecryptaButton_Click);
            // 
            // PassphraseText
            // 
            this.PassphraseText.Location = new System.Drawing.Point(110, 85);
            this.PassphraseText.Name = "PassphraseText";
            this.PassphraseText.Size = new System.Drawing.Size(303, 22);
            this.PassphraseText.TabIndex = 4;
            this.PassphraseText.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Passphase";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 339);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PassphraseText);
            this.Controls.Add(DecryptaButton);
            this.Controls.Add(this.CryptaButton);
            this.Controls.Add(this.EncrypterText);
            this.Controls.Add(this.NormalText);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox NormalText;
        private System.Windows.Forms.RichTextBox EncrypterText;
        private System.Windows.Forms.Button CryptaButton;
        private System.Windows.Forms.TextBox PassphraseText;
        private System.Windows.Forms.Label label1;
    }
}

