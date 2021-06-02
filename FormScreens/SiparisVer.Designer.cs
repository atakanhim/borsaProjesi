
namespace borsaProjesi.FormScreens
{
    partial class SiparisVer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SiparisVer));
            this.cikis_btn = new System.Windows.Forms.Button();
            this.kacadet_txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.kactl_txt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Siparis_ver_btn = new System.Windows.Forms.Button();
            this.urun_adi_txt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Siparislerim_btn = new System.Windows.Forms.Button();
            this.hesap_bakiyesi_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cikis_btn
            // 
            this.cikis_btn.BackColor = System.Drawing.Color.Transparent;
            this.cikis_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cikis_btn.BackgroundImage")));
            this.cikis_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cikis_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cikis_btn.FlatAppearance.BorderSize = 0;
            this.cikis_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.cikis_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.cikis_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cikis_btn.Location = new System.Drawing.Point(292, 37);
            this.cikis_btn.Name = "cikis_btn";
            this.cikis_btn.Size = new System.Drawing.Size(29, 30);
            this.cikis_btn.TabIndex = 1;
            this.cikis_btn.UseVisualStyleBackColor = false;
            this.cikis_btn.Click += new System.EventHandler(this.Cikis_btn_Click);
            // 
            // kacadet_txt
            // 
            this.kacadet_txt.Location = new System.Drawing.Point(171, 102);
            this.kacadet_txt.Margin = new System.Windows.Forms.Padding(2);
            this.kacadet_txt.Name = "kacadet_txt";
            this.kacadet_txt.Size = new System.Drawing.Size(86, 20);
            this.kacadet_txt.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 102);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Kac Adet Alıcaksın :";
            // 
            // kactl_txt
            // 
            this.kactl_txt.Location = new System.Drawing.Point(171, 132);
            this.kactl_txt.Margin = new System.Windows.Forms.Padding(2);
            this.kactl_txt.Name = "kactl_txt";
            this.kactl_txt.Size = new System.Drawing.Size(86, 20);
            this.kactl_txt.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 132);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Kaç tl den almak isriyorsun :";
            // 
            // Siparis_ver_btn
            // 
            this.Siparis_ver_btn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Siparis_ver_btn.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Siparis_ver_btn.Location = new System.Drawing.Point(0, 187);
            this.Siparis_ver_btn.Margin = new System.Windows.Forms.Padding(2);
            this.Siparis_ver_btn.Name = "Siparis_ver_btn";
            this.Siparis_ver_btn.Size = new System.Drawing.Size(331, 32);
            this.Siparis_ver_btn.TabIndex = 7;
            this.Siparis_ver_btn.Text = "SIPARIS VER";
            this.Siparis_ver_btn.UseVisualStyleBackColor = true;
            this.Siparis_ver_btn.Click += new System.EventHandler(this.Siparis_ver_btn_Click);
            // 
            // urun_adi_txt
            // 
            this.urun_adi_txt.Location = new System.Drawing.Point(171, 72);
            this.urun_adi_txt.Margin = new System.Windows.Forms.Padding(2);
            this.urun_adi_txt.Name = "urun_adi_txt";
            this.urun_adi_txt.Size = new System.Drawing.Size(86, 20);
            this.urun_adi_txt.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 72);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Hangi Ürünü Alıcaksın :";
            // 
            // Siparislerim_btn
            // 
            this.Siparislerim_btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.Siparislerim_btn.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Siparislerim_btn.Location = new System.Drawing.Point(0, 0);
            this.Siparislerim_btn.Margin = new System.Windows.Forms.Padding(2);
            this.Siparislerim_btn.Name = "Siparislerim_btn";
            this.Siparislerim_btn.Size = new System.Drawing.Size(331, 32);
            this.Siparislerim_btn.TabIndex = 10;
            this.Siparislerim_btn.Text = "SIPARISLARIM";
            this.Siparislerim_btn.UseVisualStyleBackColor = true;
            this.Siparislerim_btn.Click += new System.EventHandler(this.Siparislerim_btn_Click);
            // 
            // hesap_bakiyesi_label
            // 
            this.hesap_bakiyesi_label.AutoSize = true;
            this.hesap_bakiyesi_label.Location = new System.Drawing.Point(80, 37);
            this.hesap_bakiyesi_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.hesap_bakiyesi_label.Name = "hesap_bakiyesi_label";
            this.hesap_bakiyesi_label.Size = new System.Drawing.Size(73, 13);
            this.hesap_bakiyesi_label.TabIndex = 11;
            this.hesap_bakiyesi_label.Text = "CurrentBakiye";
            // 
            // SiparisVer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 219);
            this.Controls.Add(this.hesap_bakiyesi_label);
            this.Controls.Add(this.Siparislerim_btn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.kactl_txt);
            this.Controls.Add(this.urun_adi_txt);
            this.Controls.Add(this.kacadet_txt);
            this.Controls.Add(this.Siparis_ver_btn);
            this.Controls.Add(this.cikis_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SiparisVer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "s";
            this.Load += new System.EventHandler(this.SiparisVer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cikis_btn;
        private System.Windows.Forms.TextBox kacadet_txt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox kactl_txt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Siparis_ver_btn;
        private System.Windows.Forms.TextBox urun_adi_txt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Siparislerim_btn;
        private System.Windows.Forms.Label hesap_bakiyesi_label;
    }
}