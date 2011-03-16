using System;
using System.Drawing;
using System.Windows.Forms;

namespace GameOfLifeWinForms
{
    public partial class GameOfLife : Form
    {
        private static Graphics graphics;
        private static World world;
        public GameOfLife()
        {
            InitializeComponent();
        }

        private void GameOfLife_Load(object sender, EventArgs e)
        {
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint,true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            //this.SetStyle(ControlStyles.OptimizedDoubleBuffer,true);
            this.BackColor = Color.Black;
            graphics = this.CreateGraphics();
           
            this.Show();

            this.Click += mouse_click;

            timer1.Interval = 200;
            timer1.Tick += handle_tick;
            timer1.Enabled = true;

            int width = 114;
            int height = 66;

            //world = new TwoFlowerWorld(width, height);
            //world = new LineWorld(width, height);
            //world = new SlashWorld(width, height);
            world = new OddWorld(width, height);
            world.setup_map();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            
            base.OnPaint(e);
        }

        public void mouse_click(object sender, EventArgs args)
        {
            timer1.Enabled = !timer1.Enabled;
        }

        public void handle_tick(object sender, EventArgs args)
        {
            world.execute_generation();
            world.render_map(graphics);
            //base.Invalidate();
        }

    }
}
