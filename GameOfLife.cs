using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using GameOfLifeWinForms.core;
using Microsoft.Win32;

namespace GameOfLifeWinForms
{
    public partial class GameOfLife : Form
    {
        #region Win32 API functions

        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        static extern bool GetClientRect(IntPtr hWnd, out Rectangle lpRect);

        #endregion

        private Point mouseLocation;
        private bool previewMode = false;
        private Random rand = new Random();
        private static World world;
        private int speed;
        private string processor_type;

        public GameOfLife()
        {
            InitializeComponent();
        }

        public GameOfLife(Rectangle Bounds)
        {
            InitializeComponent();
            this.Bounds = Bounds;
        }

        public GameOfLife(IntPtr PreviewWndHandle)
        {
            InitializeComponent();

            // Set the preview window as the parent of this window
            SetParent(this.Handle, PreviewWndHandle);

            // Make this a child window so it will close when the parent dialog closes
            SetWindowLong(this.Handle, -16, new IntPtr(GetWindowLong(this.Handle, -16) | 0x40000000));

            // Place our window inside the parent
            Rectangle ParentRect;
            GetClientRect(PreviewWndHandle, out ParentRect);
            Size = ParentRect.Size;
            Location = new Point(0, 0);

            previewMode = true;
        }


        private void GameOfLife_Load(object sender, EventArgs e)
        {
            LoadSettings();
            configure();

            Cursor.Hide();
            TopMost = true;

            this.KeyPress += new KeyPressEventHandler(this.ScreenSaverForm_KeyPress);
            this.MouseClick += new MouseEventHandler(this.ScreenSaverForm_MouseClick);
            this.MouseMove += new MouseEventHandler(this.ScreenSaverForm_MouseMove);

            timer1.Interval = speed;
            timer1.Tick += handle_tick;
            timer1.Enabled = true;
            timer1.Start();
        }

        private void configure()
        {
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            //this.SetStyle(ControlStyles.OptimizedDoubleBuffer,true);
            this.BackColor = Color.Black;

            this.Show();

            //this.Click += mouse_click;

            world = new DefaultWorld(this.CreateGraphics(), Bounds.Width / 8, Bounds.Height / 7, processor_type);
        }

        private void LoadSettings()
        {
            // Use the string from the Registry if it exists
            RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\GameOfLife_ScreenSaver");
            if (key == null)
                speed = 500;
            else
                speed = int.Parse((string)key.GetValue("speed"));

            key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\GameOfLife_ScreenSaver");
            if (key == null)
                processor_type = "LineWorldProcessor";
            else
                processor_type = (string)key.GetValue("type");
            
        }

        //public void mouse_click(object sender, EventArgs args)
        //{
        //    timer1.Enabled = !timer1.Enabled;
        //}

        public void handle_tick(object sender, EventArgs args)
        {
            if(!world.next_generation())
            {
                timer1.Enabled = false;
            }
            world.render();
        }

        private void ScreenSaverForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (!previewMode)
            {
                if (!mouseLocation.IsEmpty)
                {
                    // Terminate if mouse is moved a significant distance
                    if (Math.Abs(mouseLocation.X - e.X) > 5 ||
                        Math.Abs(mouseLocation.Y - e.Y) > 5)
                        Application.Exit();
                }

                // Update current mouse location
                mouseLocation = e.Location;
            }
        }

        private void ScreenSaverForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!previewMode)
                Application.Exit();
        }

        private void ScreenSaverForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (!previewMode)
                Application.Exit();
        }

    }
}