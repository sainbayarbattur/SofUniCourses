namespace _2PointinRectangle
{
    public class Rectangle
    {
        public Rectangle(Point topLeft, Point bottomRight)
        {
            this.TopLeft = topLeft;
            this.BottomRight = bottomRight;
        }

        public Point TopLeft { get; set; }

        public Point BottomRight { get; set; }

        public bool Contains(Point point)
        {
            return (point.X >= TopLeft.X && point.Y >= TopLeft.Y) && (point.X <= BottomRight.X && point.Y <= BottomRight.Y);
        }
    }
}