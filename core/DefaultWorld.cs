using System;
using System.Drawing;

namespace GameOfLifeWinForms.core
{
    public class DefaultWorld : World
    {
        Graphics graphics;
        readonly int width;
        readonly int height;
        readonly int square_size;
        readonly WorldProcessor processor;

        public DefaultWorld(Graphics graphics, int square_size, int width, int height, string world_processor_type)
        {
            this.graphics = graphics;
            this.square_size = square_size;
            this.width = width;
            this.height = height;

            processor = (WorldProcessor)Activator.CreateInstance(Type.GetType("GameOfLifeWinForms.core." + world_processor_type), width, height, graphics, square_size);
            processor.setup_map();            

        }

        public bool next_generation()
        {
            return processor.next_generation();
        }

        public void render()
        {
            processor.render_map();
        }

    }
}