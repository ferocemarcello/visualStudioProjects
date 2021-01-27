using System;

namespace ConversionPolarToCartesian
{
    public class PolarToCartesianConverter
    {
        public static double GetXFromPolars(double angle, double length)
        {
            double angleRa = angle * 2 * Math.PI / 360;
            double x = length * Math.Cos(angleRa);
            return x;
        }
        public static double GetYFromPolars(double angle, double length)
        {
            double angleRa = angle * 2 * Math.PI / 360;
            double y = length * Math.Sin(angleRa);
            return y;
        }
    }
}