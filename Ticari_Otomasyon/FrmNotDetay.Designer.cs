
namespace Ticari_Otomasyon
{
    partial class FrmNotDetay
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
            this.RchNot = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // RchNot
            // 
            this.RchNot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.RchNot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RchNot.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.RchNot.Location = new System.Drawing.Point(0, 0);
            this.RchNot.Name = "RchNot";
            this.RchNot.ReadOnly = true;
            this.RchNot.Size = new System.Drawing.Size(819, 435);
            this.RchNot.TabIndex = 1;
            this.RchNot.Text = "";
            // 
            // FrmNotDetay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(819, 435);
            this.Controls.Add(this.RchNot);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmNotDetay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NOT DETAY";
            this.Load += new System.EventHandler(this.FrmNotDetay_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox RchNot;
    }
}