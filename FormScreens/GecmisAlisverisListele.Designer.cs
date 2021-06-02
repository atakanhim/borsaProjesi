
namespace borsaProjesi.FormScreens
{
    partial class GecmisAlisverisListele
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GecmisAlisverisListele));
            this.back_btn = new System.Windows.Forms.Button();
            this.tarih1_datetime = new System.Windows.Forms.DateTimePicker();
            this.ShowSiparisler_datagrid = new System.Windows.Forms.DataGridView();
            this.tarih2_datetime = new System.Windows.Forms.DateTimePicker();
            this.OncekiSiparislerim_listele_btn = new System.Windows.Forms.Button();
            this.Yaptigim_satislar_btn = new System.Windows.Forms.Button();
            this.tarihler_label = new System.Windows.Forms.Label();
            this.herikiside_btn = new System.Windows.Forms.Button();
            this.Rapor_olustur_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ShowSiparisler_datagrid)).BeginInit();
            this.SuspendLayout();
            // 
            // back_btn
            // 
            this.back_btn.BackColor = System.Drawing.Color.Transparent;
            this.back_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("back_btn.BackgroundImage")));
            this.back_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.back_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.back_btn.FlatAppearance.BorderSize = 0;
            this.back_btn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.back_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.back_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.back_btn.Location = new System.Drawing.Point(717, 12);
            this.back_btn.Name = "back_btn";
            this.back_btn.Size = new System.Drawing.Size(58, 52);
            this.back_btn.TabIndex = 1;
            this.back_btn.UseVisualStyleBackColor = false;
            this.back_btn.Click += new System.EventHandler(this.Back_btn_Click);
            // 
            // tarih1_datetime
            // 
            this.tarih1_datetime.Location = new System.Drawing.Point(35, 54);
            this.tarih1_datetime.Name = "tarih1_datetime";
            this.tarih1_datetime.Size = new System.Drawing.Size(170, 20);
            this.tarih1_datetime.TabIndex = 2;
            this.tarih1_datetime.Value = new System.DateTime(2021, 5, 1, 0, 0, 0, 0);
            // 
            // ShowSiparisler_datagrid
            // 
            this.ShowSiparisler_datagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ShowSiparisler_datagrid.Location = new System.Drawing.Point(3, 194);
            this.ShowSiparisler_datagrid.Name = "ShowSiparisler_datagrid";
            this.ShowSiparisler_datagrid.RowHeadersVisible = false;
            this.ShowSiparisler_datagrid.Size = new System.Drawing.Size(772, 330);
            this.ShowSiparisler_datagrid.TabIndex = 3;
            // 
            // tarih2_datetime
            // 
            this.tarih2_datetime.Location = new System.Drawing.Point(243, 54);
            this.tarih2_datetime.Name = "tarih2_datetime";
            this.tarih2_datetime.Size = new System.Drawing.Size(170, 20);
            this.tarih2_datetime.TabIndex = 2;
            // 
            // OncekiSiparislerim_listele_btn
            // 
            this.OncekiSiparislerim_listele_btn.Location = new System.Drawing.Point(35, 96);
            this.OncekiSiparislerim_listele_btn.Name = "OncekiSiparislerim_listele_btn";
            this.OncekiSiparislerim_listele_btn.Size = new System.Drawing.Size(170, 40);
            this.OncekiSiparislerim_listele_btn.TabIndex = 4;
            this.OncekiSiparislerim_listele_btn.Text = "Gecmis Alısverislerim";
            this.OncekiSiparislerim_listele_btn.UseVisualStyleBackColor = true;
            this.OncekiSiparislerim_listele_btn.Click += new System.EventHandler(this.OncekiSiparislerim_listele_btn_Click);
            // 
            // Yaptigim_satislar_btn
            // 
            this.Yaptigim_satislar_btn.Location = new System.Drawing.Point(243, 96);
            this.Yaptigim_satislar_btn.Name = "Yaptigim_satislar_btn";
            this.Yaptigim_satislar_btn.Size = new System.Drawing.Size(170, 40);
            this.Yaptigim_satislar_btn.TabIndex = 4;
            this.Yaptigim_satislar_btn.Text = "Yaptigim Satislar";
            this.Yaptigim_satislar_btn.UseVisualStyleBackColor = true;
            this.Yaptigim_satislar_btn.Click += new System.EventHandler(this.Yaptigim_satislar_btn_Click);
            // 
            // tarihler_label
            // 
            this.tarihler_label.AutoSize = true;
            this.tarihler_label.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tarihler_label.Location = new System.Drawing.Point(31, 12);
            this.tarihler_label.Name = "tarihler_label";
            this.tarihler_label.Size = new System.Drawing.Size(382, 22);
            this.tarihler_label.TabIndex = 5;
            this.tarihler_label.Text = "Hangi Tarihler Arasını listelemek istiyorsunuz";
            // 
            // herikiside_btn
            // 
            this.herikiside_btn.Location = new System.Drawing.Point(119, 142);
            this.herikiside_btn.Name = "herikiside_btn";
            this.herikiside_btn.Size = new System.Drawing.Size(203, 46);
            this.herikiside_btn.TabIndex = 4;
            this.herikiside_btn.Text = "Her İkiside";
            this.herikiside_btn.UseVisualStyleBackColor = true;
            this.herikiside_btn.Click += new System.EventHandler(this.Herikiside_btn_Click);
            // 
            // Rapor_olustur_btn
            // 
            this.Rapor_olustur_btn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Rapor_olustur_btn.Location = new System.Drawing.Point(0, 530);
            this.Rapor_olustur_btn.Name = "Rapor_olustur_btn";
            this.Rapor_olustur_btn.Size = new System.Drawing.Size(782, 67);
            this.Rapor_olustur_btn.TabIndex = 6;
            this.Rapor_olustur_btn.Text = "Rapor Olustur";
            this.Rapor_olustur_btn.UseVisualStyleBackColor = true;
            this.Rapor_olustur_btn.Click += new System.EventHandler(this.Rapor_olustur_btn_Click);
            // 
            // GecmisAlisverisListele
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 597);
            this.Controls.Add(this.Rapor_olustur_btn);
            this.Controls.Add(this.tarihler_label);
            this.Controls.Add(this.herikiside_btn);
            this.Controls.Add(this.Yaptigim_satislar_btn);
            this.Controls.Add(this.OncekiSiparislerim_listele_btn);
            this.Controls.Add(this.ShowSiparisler_datagrid);
            this.Controls.Add(this.tarih2_datetime);
            this.Controls.Add(this.tarih1_datetime);
            this.Controls.Add(this.back_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GecmisAlisverisListele";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Siparislerim";
            this.Load += new System.EventHandler(this.Siparislerim_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ShowSiparisler_datagrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button back_btn;
        private System.Windows.Forms.DateTimePicker tarih1_datetime;
        private System.Windows.Forms.DataGridView ShowSiparisler_datagrid;
        private System.Windows.Forms.DateTimePicker tarih2_datetime;
        private System.Windows.Forms.Button OncekiSiparislerim_listele_btn;
        private System.Windows.Forms.Button Yaptigim_satislar_btn;
        private System.Windows.Forms.Label tarihler_label;
        private System.Windows.Forms.Button herikiside_btn;
        private System.Windows.Forms.Button Rapor_olustur_btn;
    }
}