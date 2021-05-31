
namespace borsaProjesi
{
    partial class GirisControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GirisControl));
            this.exit_btn = new System.Windows.Forms.Button();
            this.user = new System.Windows.Forms.Button();
            this.admin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // exit_btn
            // 
            this.exit_btn.BackColor = System.Drawing.Color.Transparent;
            this.exit_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("exit_btn.BackgroundImage")));
            this.exit_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.exit_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exit_btn.FlatAppearance.BorderSize = 0;
            this.exit_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.exit_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.exit_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exit_btn.Location = new System.Drawing.Point(484, 12);
            this.exit_btn.Name = "exit_btn";
            this.exit_btn.Size = new System.Drawing.Size(51, 49);
            this.exit_btn.TabIndex = 4;
            this.exit_btn.UseVisualStyleBackColor = false;
            this.exit_btn.Click += new System.EventHandler(this.Exit_btn_Click);
            // 
            // user
            // 
            this.user.BackColor = System.Drawing.Color.Transparent;
            this.user.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("user.BackgroundImage")));
            this.user.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.user.Cursor = System.Windows.Forms.Cursors.Hand;
            this.user.FlatAppearance.BorderSize = 0;
            this.user.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.user.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.user.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.user.Location = new System.Drawing.Point(339, 12);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(111, 85);
            this.user.TabIndex = 4;
            this.user.UseVisualStyleBackColor = false;
            this.user.Click += new System.EventHandler(this.User_Click);
            // 
            // admin
            // 
            this.admin.BackColor = System.Drawing.Color.Transparent;
            this.admin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("admin.BackgroundImage")));
            this.admin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.admin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.admin.FlatAppearance.BorderSize = 0;
            this.admin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.admin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.admin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.admin.Location = new System.Drawing.Point(59, 99);
            this.admin.Name = "admin";
            this.admin.Size = new System.Drawing.Size(129, 94);
            this.admin.TabIndex = 4;
            this.admin.UseVisualStyleBackColor = false;
            this.admin.Click += new System.EventHandler(this.Admin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.DarkCyan;
            this.label1.Location = new System.Drawing.Point(53, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 31);
            this.label1.TabIndex = 5;
            this.label1.Text = "KULLANICI GİRİŞİ -->";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.DarkCyan;
            this.label2.Location = new System.Drawing.Point(222, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(228, 31);
            this.label2.TabIndex = 5;
            this.label2.Text = "<-- ADMİN GİRİŞİ";
            // 
            // GirisControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(565, 242);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.admin);
            this.Controls.Add(this.user);
            this.Controls.Add(this.exit_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GirisControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GirisControl";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button exit_btn;
        private System.Windows.Forms.Button user;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button admin;
    }
}