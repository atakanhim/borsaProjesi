
namespace borsaProjesi
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.kadi_txt = new System.Windows.Forms.TextBox();
            this.password_txt = new System.Windows.Forms.TextBox();
            this.geri_btn = new System.Windows.Forms.Button();
            this.sign_up_btn = new System.Windows.Forms.Button();
            this.Giris_yap_btn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // kadi_txt
            // 
            this.kadi_txt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.kadi_txt.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kadi_txt.Location = new System.Drawing.Point(229, 256);
            this.kadi_txt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.kadi_txt.Multiline = true;
            this.kadi_txt.Name = "kadi_txt";
            this.kadi_txt.Size = new System.Drawing.Size(408, 33);
            this.kadi_txt.TabIndex = 2;
            // 
            // password_txt
            // 
            this.password_txt.BackColor = System.Drawing.SystemColors.Window;
            this.password_txt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.password_txt.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.password_txt.Location = new System.Drawing.Point(229, 313);
            this.password_txt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.password_txt.Multiline = true;
            this.password_txt.Name = "password_txt";
            this.password_txt.PasswordChar = '*';
            this.password_txt.Size = new System.Drawing.Size(408, 32);
            this.password_txt.TabIndex = 2;
            // 
            // geri_btn
            // 
            this.geri_btn.BackColor = System.Drawing.Color.Transparent;
            this.geri_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("geri_btn.BackgroundImage")));
            this.geri_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.geri_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.geri_btn.FlatAppearance.BorderSize = 0;
            this.geri_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.geri_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.geri_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.geri_btn.Location = new System.Drawing.Point(715, 14);
            this.geri_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.geri_btn.Name = "geri_btn";
            this.geri_btn.Size = new System.Drawing.Size(85, 71);
            this.geri_btn.TabIndex = 3;
            this.geri_btn.UseVisualStyleBackColor = false;
            this.geri_btn.Click += new System.EventHandler(this.geri_btn_Click);
            // 
            // sign_up_btn
            // 
            this.sign_up_btn.BackColor = System.Drawing.Color.Transparent;
            this.sign_up_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sign_up_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sign_up_btn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.sign_up_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.sign_up_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.sign_up_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sign_up_btn.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sign_up_btn.Location = new System.Drawing.Point(424, 401);
            this.sign_up_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sign_up_btn.Name = "sign_up_btn";
            this.sign_up_btn.Size = new System.Drawing.Size(228, 50);
            this.sign_up_btn.TabIndex = 4;
            this.sign_up_btn.Text = "SIGN UP";
            this.sign_up_btn.UseVisualStyleBackColor = false;
            this.sign_up_btn.Click += new System.EventHandler(this.sign_up_btn_Click);
            // 
            // Giris_yap_btn
            // 
            this.Giris_yap_btn.BackColor = System.Drawing.Color.Transparent;
            this.Giris_yap_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Giris_yap_btn.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.Giris_yap_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.Giris_yap_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.Giris_yap_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Giris_yap_btn.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Giris_yap_btn.ForeColor = System.Drawing.Color.Black;
            this.Giris_yap_btn.Location = new System.Drawing.Point(160, 401);
            this.Giris_yap_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Giris_yap_btn.Name = "Giris_yap_btn";
            this.Giris_yap_btn.Size = new System.Drawing.Size(228, 50);
            this.Giris_yap_btn.TabIndex = 1;
            this.Giris_yap_btn.Text = "LOGIN";
            this.Giris_yap_btn.UseVisualStyleBackColor = false;
            this.Giris_yap_btn.Click += new System.EventHandler(this.Giris_yap_btn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(324, 74);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(184, 155);
            this.pictureBox1.TabIndex = 43;
            this.pictureBox1.TabStop = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(816, 553);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.sign_up_btn);
            this.Controls.Add(this.geri_btn);
            this.Controls.Add(this.password_txt);
            this.Controls.Add(this.kadi_txt);
            this.Controls.Add(this.Giris_yap_btn);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox kadi_txt;
        private System.Windows.Forms.TextBox password_txt;
        private System.Windows.Forms.Button geri_btn;
        private System.Windows.Forms.Button sign_up_btn;
        private System.Windows.Forms.Button Giris_yap_btn;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}