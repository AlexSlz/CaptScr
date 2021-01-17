using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaptScr
{
    public partial class Form1 : Form
    {

        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);


        Graphics _graphics;
        Pen _pen = new Pen(Color.White, 2);
        private int X0, Y0, X1, Y1;


        void ScreenShotArea()
        {
            Bitmap _bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            _graphics = Graphics.FromImage(_bitmap);
            _graphics.CopyFromScreen(0, 0, 0, 0, _bitmap.Size);
            pictureBox1.CreateGraphics().Dispose();
            pictureBox1.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            pictureBox1.Image = _bitmap;
            Show();
        }
        /*void BlurDraw()
        {
            SolidBrush Brush = new SolidBrush(Color.FromArgb(50, 0, 0, 0));
            _graphics.FillRectangle(Brush, 0, 0, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
        }*/

        public Form1()
        {
            InitializeComponent();
            Tray.ShowBalloonTip(1000);
            Boolean PSRegistered = RegisterHotKey(
                this.Handle, 1, 0x0002, (int)Keys.PrintScreen
            );
            if (!PSRegistered)
            {
                Console.WriteLine("Клавиша printscreen не зарегистрированная! Разработчик лох!(");
            }
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312)
            {
                int id = m.WParam.ToInt32();
                switch (id)
                {
                    case 1:
                        ScreenShotArea();
                        break;
                }
            }
            base.WndProc(ref m);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Hide();
        }

        private void Tray_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ScreenShotArea();
            }
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        int _Power = 10;
        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Hide();
            }
            if (e.Control && e.KeyCode == Keys.C)
            {
                SaveImg();
            }
            if (e.KeyCode == Keys.Up && !e.Control && !e.Alt)
            {
                hitbox.Y -= _Power;
            }
            if (e.KeyCode == Keys.Down && !e.Control && !e.Alt)
            {
                hitbox.Y += _Power;
            }
            if (e.KeyCode == Keys.Left && !e.Control && !e.Alt)
            {
                hitbox.X -= _Power;
            }
            if (e.KeyCode == Keys.Right && !e.Control && !e.Alt)
            {
                hitbox.X += _Power;
            }

            if (e.KeyCode == Keys.Up && e.Control && !e.Alt)
            {
                hitbox.Height -= _Power;
            }
            if (e.KeyCode == Keys.Down && e.Control && !e.Alt)
            {
                hitbox.Height += _Power;
            }
            if (e.KeyCode == Keys.Left && e.Control && !e.Alt)
            {
                hitbox.Width -= _Power;
            }
            if (e.KeyCode == Keys.Right && e.Control && !e.Alt)
            {
                hitbox.Width += _Power;
            }

            if (e.Alt && e.KeyCode == Keys.Up)
            {
                if (_Power < 100)
                    _Power++;
                power_text.Text = "Power: " + _Power.ToString();
            }else
            if (e.Alt && e.KeyCode == Keys.Down)
            {
                if(_Power > 1)
                    _Power--;
                power_text.Text = "Power: " + _Power.ToString();
            }
            else
            {
                power_text.Text = "";
            }
            TestIfRectInsideArea();
            pictureBox1.Refresh();
            Draw();
        }
        private void SaveImg()
        {
            if (hitbox.X > 0)
            {
                Bitmap _bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                pictureBox1.DrawToBitmap(_bitmap, pictureBox1.ClientRectangle);
                Bitmap crpImg = new Bitmap(hitbox.Width, hitbox.Height);
                for (int i = 0; i < hitbox.Width; i++)
                {
                    for (int j = 0; j < hitbox.Height; j++)
                    {
                        Color color = _bitmap.GetPixel(hitbox.X + i, hitbox.Y + j);
                        crpImg.SetPixel(i, j, color);
                    }
                }
                Clipboard.SetImage((Image)crpImg);
            }
            else
            {
                Clipboard.SetImage(pictureBox1.Image);
            }
            Hide();
        }
        Rectangle hitbox;
        bool drag = false;
        private PosSizableRect nodeSelected = PosSizableRect.None;
        private enum PosSizableRect
        {
            LeftUp,
            RightBottom,
            None

        };

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            ChangeCursor(e.Location);
            SolidBrush Brush = new SolidBrush(Color.FromArgb(100, 0, 0, 0));
            if (e.Button == MouseButtons.Left && !drag)
            {
                pictureBox1.Refresh();
                X1 = e.X;
                Y1 = e.Y;
                hitbox = new Rectangle(Math.Min(X0, X1), Math.Min(Y0, Y1), Math.Abs(X0 - X1), Math.Abs(Y0 - Y1));
            }
            if (drag)
            {
                pictureBox1.Refresh();
                Rectangle backupRect = hitbox;
                switch (nodeSelected)
                {
                    case PosSizableRect.LeftUp:
                        hitbox.X += e.X - ClickCursor.X;
                        hitbox.Width -= e.X - ClickCursor.X;
                        hitbox.Y += e.Y - ClickCursor.Y;
                        hitbox.Height -= e.Y - ClickCursor.Y;
                        break;
                    case PosSizableRect.RightBottom:
                        hitbox.Width += e.X - ClickCursor.X;
                        hitbox.Height += e.Y - ClickCursor.Y;
                        break;

                    default:
                        hitbox.X = hitbox.X + e.X - ClickCursor.X;
                        hitbox.Y = hitbox.Y + e.Y - ClickCursor.Y;
                        break;
                }
                ClickCursor.X = e.X;
                ClickCursor.Y = e.Y;
                if (hitbox.Width < 10 || hitbox.Height < 10)
                {
                    hitbox = backupRect;
                }
                TestIfRectInsideArea();
            }
            Draw();
        }
        private void Draw()
        {
            _pen.StartCap = LineCap.ArrowAnchor;
            _pen.EndCap = LineCap.RoundAnchor;
            _pen.DashPattern = new float[] { 8, 2 };
            SolidBrush TextClr = new SolidBrush(Color.Red);
            Point _point = new Point(hitbox.X, hitbox.Y - 20);
            pictureBox1.CreateGraphics().DrawString(hitbox.Width + " x " + hitbox.Height, DefaultFont, TextClr, _point);
            pictureBox1.CreateGraphics().DrawRectangle(_pen, hitbox);
            foreach (PosSizableRect pos in Enum.GetValues(typeof(PosSizableRect)))
            {
                pictureBox1.CreateGraphics().DrawRectangle(new Pen(Color.Red), GetRect(pos));
            }
        }
        private void TestIfRectInsideArea()
        {
            if (hitbox.X <= 0) hitbox.X = 0;
            if (hitbox.Y <= 0) hitbox.Y = 0;
            if (hitbox.Width <= 0) hitbox.Width = 1;
            if (hitbox.Height <= 0) hitbox.Height = 1;

            if (hitbox.X + hitbox.Width > Screen.PrimaryScreen.Bounds.Width)
            {
                hitbox.Width = Screen.PrimaryScreen.Bounds.Width - hitbox.X;
            }
            if (hitbox.Y + hitbox.Height > Screen.PrimaryScreen.Bounds.Height)
            {
                hitbox.Height = Screen.PrimaryScreen.Bounds.Height - hitbox.Y;
            }
        }
        private int sizeNodeRect = 10;
        private Rectangle GetRect(PosSizableRect p)
        {
            switch (p)
            {
                case PosSizableRect.LeftUp:
                    return CreateRectSizableNode(hitbox.X, hitbox.Y);

                case PosSizableRect.RightBottom:
                    return CreateRectSizableNode(hitbox.X + hitbox.Width, hitbox.Y + hitbox.Height);

                default:
                    return new Rectangle();
            }
        }
        private Rectangle CreateRectSizableNode(int x, int y)
        {
            return new Rectangle(x - sizeNodeRect / 2, y - sizeNodeRect / 2, sizeNodeRect, sizeNodeRect);
        }
        Point ClickCursor;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            nodeSelected = PosSizableRect.None;
            nodeSelected = GetNodeSelectable(e.Location);
            if (hitbox.Contains(new Point(e.X, e.Y)))
            {
                drag = true;
                if (e.Button == MouseButtons.Left)
                {
                    ClickCursor.X = e.X;
                    ClickCursor.Y = e.Y;
                }
            }
            if (e.Button == MouseButtons.Left)
            {
                X0 = e.X;
                Y0 = e.Y;
            }
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            hitbox.Width = Screen.PrimaryScreen.Bounds.Width;
            hitbox.Height = Screen.PrimaryScreen.Bounds.Height;
            hitbox.X = 0;
            hitbox.Y = 0;
            pictureBox1.Refresh();
        }

        private PosSizableRect GetNodeSelectable(Point p)
        {
            foreach (PosSizableRect r in Enum.GetValues(typeof(PosSizableRect)))
            {
                if (GetRect(r).Contains(p))
                {
                    return r;
                }
            }
            return PosSizableRect.None;
        }
        private void ChangeCursor(Point p)
        {
            pictureBox1.Cursor = GetCursor(GetNodeSelectable(p));
        }
        private Cursor GetCursor(PosSizableRect p)
        {
            switch (p)
            {
                case PosSizableRect.LeftUp:
                    return Cursors.SizeNWSE;

                case PosSizableRect.RightBottom:
                    return Cursors.SizeNWSE;
                default:
                    return Cursors.Default;
            }
        }
    }
}
