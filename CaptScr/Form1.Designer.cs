
namespace CaptScr
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Tray = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.сделатьСкриншотToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.записатьВидеоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.закрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.power_text = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Tray
            // 
            this.Tray.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.Tray.BalloonTipText = "Welcome, Ctrl + PrintScreen";
            this.Tray.BalloonTipTitle = "PUK";
            this.Tray.ContextMenuStrip = this.contextMenuStrip1;
            this.Tray.Icon = ((System.Drawing.Icon)(resources.GetObject("Tray.Icon")));
            this.Tray.Text = "Echidna";
            this.Tray.Visible = true;
            this.Tray.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Tray_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сделатьСкриншотToolStripMenuItem,
            this.записатьВидеоToolStripMenuItem,
            this.настройкиToolStripMenuItem,
            this.закрытьToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(236, 92);
            // 
            // сделатьСкриншотToolStripMenuItem
            // 
            this.сделатьСкриншотToolStripMenuItem.Name = "сделатьСкриншотToolStripMenuItem";
            this.сделатьСкриншотToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.сделатьСкриншотToolStripMenuItem.Text = "Сделать скриншот";
            // 
            // записатьВидеоToolStripMenuItem
            // 
            this.записатьВидеоToolStripMenuItem.Name = "записатьВидеоToolStripMenuItem";
            this.записатьВидеоToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.записатьВидеоToolStripMenuItem.Text = "Записать видео(Не работаит)";
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.настройкиToolStripMenuItem.Text = "Настройки(Мне лень делать)";
            // 
            // закрытьToolStripMenuItem
            // 
            this.закрытьToolStripMenuItem.Name = "закрытьToolStripMenuItem";
            this.закрытьToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.закрытьToolStripMenuItem.Text = "Закрыть";
            this.закрытьToolStripMenuItem.Click += new System.EventHandler(this.закрытьToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(778, 467);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // power_text
            // 
            this.power_text.AutoSize = true;
            this.power_text.Location = new System.Drawing.Point(12, 9);
            this.power_text.Name = "power_text";
            this.power_text.Size = new System.Drawing.Size(55, 13);
            this.power_text.TabIndex = 2;
            this.power_text.Text = "Power: 10";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(949, 561);
            this.ControlBox = false;
            this.Controls.Add(this.power_text);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Made by Alex S.";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon Tray;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem сделатьСкриншотToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem записатьВидеоToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem закрытьToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label power_text;
    }
}

