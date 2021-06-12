
namespace borsaProjesi
{
    partial class SiparislerimListele
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SiparislerimListele));
            this.cikis_btn = new System.Windows.Forms.Button();
            this.aktifsip_listele = new System.Windows.Forms.Button();
            this.tamamsip_listele = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.Siparislistele_datagird = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Siparislistele_datagird)).BeginInit();
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
            this.cikis_btn.Location = new System.Drawing.Point(920, 12);
            this.cikis_btn.Name = "cikis_btn";
            this.cikis_btn.Size = new System.Drawing.Size(58, 52);
            this.cikis_btn.TabIndex = 4;
            this.cikis_btn.UseVisualStyleBackColor = false;
            this.cikis_btn.Click += new System.EventHandler(this.Cikis_btn_Click);
            // 
            // aktifsip_listele
            // 
            this.aktifsip_listele.Location = new System.Drawing.Point(59, 40);
            this.aktifsip_listele.Name = "aktifsip_listele";
            this.aktifsip_listele.Size = new System.Drawing.Size(303, 70);
            this.aktifsip_listele.TabIndex = 5;
            this.aktifsip_listele.Text = "Aktif Siparişlerim";
            this.aktifsip_listele.UseVisualStyleBackColor = true;
            this.aktifsip_listele.Click += new System.EventHandler(this.Aktifsip_listele_Click);
            // 
            // tamamsip_listele
            // 
            this.tamamsip_listele.Location = new System.Drawing.Point(516, 40);
            this.tamamsip_listele.Name = "tamamsip_listele";
            this.tamamsip_listele.Size = new System.Drawing.Size(303, 70);
            this.tamamsip_listele.TabIndex = 5;
            this.tamamsip_listele.Text = "Tamamlanmış Siparişlerim";
            this.tamamsip_listele.UseVisualStyleBackColor = true;
            this.tamamsip_listele.Click += new System.EventHandler(this.Tamamsip_listele_Click);
            // 
            // Siparislistele_datagird
            // 
            this.Siparislistele_datagird.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Siparislistele_datagird.Location = new System.Drawing.Point(59, 141);
            this.Siparislistele_datagird.Name = "Siparislistele_datagird";
            this.Siparislistele_datagird.Size = new System.Drawing.Size(760, 297);
            this.Siparislistele_datagird.TabIndex = 6;
            // 
            // SiparislerimListele
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 450);
            this.Controls.Add(this.Siparislistele_datagird);
            this.Controls.Add(this.tamamsip_listele);
            this.Controls.Add(this.aktifsip_listele);
            this.Controls.Add(this.cikis_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SiparislerimListele";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SiparislerimListele";
            this.Load += new System.EventHandler(this.SiparislerimListele_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Siparislistele_datagird)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cikis_btn;
        private System.Windows.Forms.Button aktifsip_listele;
        private System.Windows.Forms.Button tamamsip_listele;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridView Siparislistele_datagird;
    }
}