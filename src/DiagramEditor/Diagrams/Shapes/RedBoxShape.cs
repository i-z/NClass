
using System.Drawing;
using NClass.Core;

namespace NClass.DiagramEditor.Diagrams.Shapes
{
    internal sealed class RedBoxShape : Shape
    {
         const int DefaultWidth = 100;
         const int DefaultHeight = 60;

          
        static Pen borderPen = new Pen(Color.Black);
        static SolidBrush backgroundBrush = new SolidBrush(Color.White);


        private RedBox redBox;

        internal RedBoxShape(RedBox redBox) : base(redBox)
        {
            this.redBox = redBox;
        }

        public override IEntity Entity => redBox;

        protected override Size DefaultSize => new(DefaultWidth, DefaultHeight);

        public override void Draw(IGraphics g, bool onScreen, Style style)
        {
            Rectangle rect = BorderRectangle;
            g.FillRectangle(backgroundBrush, rect);
            int borderWidth = GetBorderWidth(style);
            using Pen pen = new Pen(borderPen.Color, borderWidth);
            g.DrawRectangle(pen, rect);
        }

        protected override bool CloneEntity(IDiagram diagram)
        {
            return false;
        }

        protected override int GetBorderWidth(Style style)
        {
            return style.ClassBorderWidth;
        }
    }
}