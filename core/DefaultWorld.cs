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

            processor = (WorldProcessor) Activator.CreateInstance(Type.GetType("GameOfLifeWinForms.core." + world_processor_type), width, height);
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