namespace ClassBoxDataValidation
{
    public class Box
    {
        public double Volume { get; private set; }

        public double LateralSurfaceArea { get; private set; }

        public double SurfaceArea { get; private set; }

        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double heigth)
        {
            this.length = length;
            this.width = width;
            this.height = heigth;

            Volume = length * width * height;
            LateralSurfaceArea = 2 * (length * height) + 2 * (width * height);
            SurfaceArea = 2 * (length * width) + 2 * (length * height) +  2 * (width * height);
        }

        private string BoxDataValidation(double length, double width, double height)
        {
            if (length <= 0)
            {
                return "Length cannot be zero or negative.";
            }
            else if (width <= 0)
            {
                return "Width cannot be zero or negative.";
            }
            else if (height <= 0)
            {
                return "Height cannot be zero or negative.";
            }
            return "";
        }

        public override string ToString()
        {
            if (BoxDataValidation(length, width, height) != "")
            {
                return BoxDataValidation(length, width, height);
            }
            return $"Surface Area - {SurfaceArea:f2}\nLateral Surface Area - {LateralSurfaceArea:f2}\nVolume - {Volume:f2}";
        }
    }
}