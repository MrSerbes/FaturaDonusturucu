namespace WindowsFormsApp1
{
    partial class Fatura
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnFaturaYolu = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFaturaYolu = new System.Windows.Forms.TextBox();
            this.txtExcellYolu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExcellYolu = new System.Windows.Forms.Button();
            this.lstBxFaturalar = new System.Windows.Forms.ListBox();
            this.btnBaslat = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnFaturaYolu
            // 
            this.btnFaturaYolu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnFaturaYolu.Location = new System.Drawing.Point(432, 36);
            this.btnFaturaYolu.Name = "btnFaturaYolu";
            this.btnFaturaYolu.Size = new System.Drawing.Size(115, 26);
            this.btnFaturaYolu.TabIndex = 0;
            this.btnFaturaYolu.Text = "Seç";
            this.btnFaturaYolu.UseVisualStyleBackColor = true;
            this.btnFaturaYolu.Click += new System.EventHandler(this.btnFaturaYolu_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(45, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fatura Yolu :";
            // 
            // txtFaturaYolu
            // 
            this.txtFaturaYolu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtFaturaYolu.Location = new System.Drawing.Point(144, 38);
            this.txtFaturaYolu.Name = "txtFaturaYolu";
            this.txtFaturaYolu.ReadOnly = true;
            this.txtFaturaYolu.Size = new System.Drawing.Size(282, 22);
            this.txtFaturaYolu.TabIndex = 2;
            // 
            // txtExcellYolu
            // 
            this.txtExcellYolu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtExcellYolu.Location = new System.Drawing.Point(144, 305);
            this.txtExcellYolu.Name = "txtExcellYolu";
            this.txtExcellYolu.ReadOnly = true;
            this.txtExcellYolu.Size = new System.Drawing.Size(282, 22);
            this.txtExcellYolu.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(45, 308);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Excel Yolu :";
            // 
            // btnExcellYolu
            // 
            this.btnExcellYolu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnExcellYolu.Location = new System.Drawing.Point(432, 305);
            this.btnExcellYolu.Name = "btnExcellYolu";
            this.btnExcellYolu.Size = new System.Drawing.Size(115, 23);
            this.btnExcellYolu.TabIndex = 3;
            this.btnExcellYolu.Text = "Seç";
            this.btnExcellYolu.UseVisualStyleBackColor = true;
            this.btnExcellYolu.Click += new System.EventHandler(this.btnExcellYolu_Click);
            // 
            // lstBxFaturalar
            // 
            this.lstBxFaturalar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lstBxFaturalar.FormattingEnabled = true;
            this.lstBxFaturalar.ItemHeight = 16;
            this.lstBxFaturalar.Location = new System.Drawing.Point(48, 70);
            this.lstBxFaturalar.Name = "lstBxFaturalar";
            this.lstBxFaturalar.Size = new System.Drawing.Size(499, 196);
            this.lstBxFaturalar.TabIndex = 6;
            // 
            // btnBaslat
            // 
            this.btnBaslat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnBaslat.Location = new System.Drawing.Point(144, 334);
            this.btnBaslat.Name = "btnBaslat";
            this.btnBaslat.Size = new System.Drawing.Size(403, 47);
            this.btnBaslat.TabIndex = 7;
            this.btnBaslat.Text = "Başlat";
            this.btnBaslat.UseVisualStyleBackColor = true;
            this.btnBaslat.Click += new System.EventHandler(this.btnBaslat_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(44, 277);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Bulunan Fatura Sayısı :";
            // 
            // txtCount
            // 
            this.txtCount.BackColor = System.Drawing.SystemColors.Control;
            this.txtCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtCount.ForeColor = System.Drawing.Color.Black;
            this.txtCount.Location = new System.Drawing.Point(216, 271);
            this.txtCount.Name = "txtCount";
            this.txtCount.ReadOnly = true;
            this.txtCount.Size = new System.Drawing.Size(74, 26);
            this.txtCount.TabIndex = 9;
            this.txtCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Fatura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 401);
            this.Controls.Add(this.txtCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnBaslat);
            this.Controls.Add(this.lstBxFaturalar);
            this.Controls.Add(this.txtExcellYolu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnExcellYolu);
            this.Controls.Add(this.txtFaturaYolu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFaturaYolu);
            this.Name = "Fatura";
            this.Text = "Fatura Dönüştürücü";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnFaturaYolu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFaturaYolu;
        private System.Windows.Forms.TextBox txtExcellYolu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExcellYolu;
        private System.Windows.Forms.ListBox lstBxFaturalar;
        private System.Windows.Forms.Button btnBaslat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCount;
    }
}

