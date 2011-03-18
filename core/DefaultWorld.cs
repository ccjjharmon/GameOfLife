using System;
using System.Drawing;

namespace GameOfLifeWinForms.core
{
    public class DefaultWorld : World
    {
        Graphics graphics;
        readonly int width;
        readonly int height;
        readonly WorldProcessor processor;

        public DefaultWorld(Graphics graphics, int width, int height, string world_processor_type)
        {
            this.graphics = graphics;

            this.width = width;
            this.height = height;

            
            //processor = new TwoFlowerWorldProcessor(width, height);
            //processor = new LineWorldProcessor(width, height);
            //processor = new SlashWorldProcessor(width, height);
            //processor = new OddWorldProcessor(width, height);
            //don't work ... processor = (WorldProcessor) System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(world_processor_type);
            processor = (WorldProcessor) Activator.CreateInstance(Type.GetType(world_processor_type), width, height);
            processor.setup_map();            

        }

        public bool next_generation()
        {
            return processor.next_generation();
        }

        public void render()
        {
            processor.render_map(graphics);
        }

    }
}