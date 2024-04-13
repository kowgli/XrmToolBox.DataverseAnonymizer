using System;

namespace XrmToolBox.DataverseAnonymizer.Helpers
{
    public class RandomHelper
    {
        private static readonly Random rnd = new Random();

        public static int GetRandomInt(int min, int max)
        {
            return rnd.Next(min, max + 1);
        }

        public static float GetRandomFloat(float min, float max)
        {
            return (float)(rnd.NextDouble() * (max - min) + min);
        }

        public static double GetRandomDouble(double min, double max)
        {
            return (double)(rnd.NextDouble() * (max - min) + min);
        }

        public static decimal GetRandomDecimal(decimal min, decimal max)
        {
            return (decimal)(rnd.NextDouble() * (double)(max - min) + (double)min);
        }
    }
}
