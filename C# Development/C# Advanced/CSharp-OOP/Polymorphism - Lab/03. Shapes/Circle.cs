﻿using System;

namespace Shapes
{
    public class Circle : Shape
    {
        private double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * (this.radius * this.radius);
        }

        public override string Draw()
        {
            return "Circle";
        }
    }
}