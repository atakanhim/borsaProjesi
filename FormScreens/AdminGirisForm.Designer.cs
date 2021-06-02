
namespace borsaProjesi
{
    partial class AdminGirisForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminGirisForm));
            this.geri_btn = new System.Windows.Forms.Button();
            this.giris_btn = new System.Windows.Forms.Button();
            this.username_admin = new System.Windows.Forms.TextBox();
            this.password_admin = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
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
            this.geri_btn.Location = new System.Drawing.Point(824, 12);
            this.geri_btn.Name = "geri_btn";
            this.geri_btn.Size = new System.Drawing.Size(58, 52);
            this.geri_btn.TabIndex = 0;
            this.geri_btn.UseVisualStyleBackColor = false;
            this.geri_btn.Click += new System.EventHandler(this.Geri_btn_Click);
            // 
            // giris_btn
            // 
            this.giris_btn.BackColor = System.Drawing.Color.Transparent;
            this.giris_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.giris_btn.FlatAppearance.BorderSize = 0;
            this.giris_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.giris_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.giris_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.giris_btn.Font = new System.Drawing.Font("Tempus Sans ITC", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giris_btn.ForeColor = System.Drawing.Color.Black;
            this.giris_btn.Location = new System.Drawing.Point(240, 302);
            this.giris_btn.Name = "giris_btn";
            this.giris_btn.Size = new System.Drawing.Size(120, 41);
            this.giris_btn.TabIndex = 1;
            this.giris_btn.Tag = "";
            this.giris_btn.UseVisualStyleBackColor = false;
            this.giris_btn.Click += new System.EventHandler(this.Giris_btn_Click);
            // 
            // username_admin
            // 
            this.username_admin.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.username_admin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.username_admin.Font = new System.Drawing.Font("Times New Roman", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.username_admin.Location = new System.Drawing.Point(249, 191);
            this.username_admin.Multiline = true;
            this.username_admin.Name = "username_admin";
            this.username_admin.Size = new System.Drawing.Size(358, 28);
            this.username_admin.TabIndex = 2;
            // 
            // password_admin
            // 
            this.password_admin.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.password_admin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.password_admin.Font = new System.Drawing.Font("Times New Roman", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.password_admin.Location = new System.Drawing.Point(249, 257);
            this.password_admin.Multiline = true;
            this.password_admin.Name = "password_admin";
            this.password_admin.PasswordChar = '*';
            this.password_admin.Size = new System.Drawing.Size(358, 28);
            this.password_admin.TabIndex = 2;
            // 
            // AdminGirisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(894, 515);
            this.Controls.Add(this.password_admin);
            this.Controls.Add(this.username_admin);
            this.Controls.Add(this.giris_btn);
            this.Controls.Add(this.geri_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminGirisForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminGirisForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button geri_btn;
        private System.Windows.Forms.Button giris_btn;
        private System.Windows.Forms.TextBox username_admin;
        private System.Windows.Forms.TextBox password_admin;
    }
}