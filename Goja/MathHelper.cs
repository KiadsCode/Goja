using System;

namespace Goja
{
    public static class MathHelper
    {
        public static float Lerp(float a, float b, float k)
        {
            float result = a * (1 - k) + b * k;

            if (result >= b)
                result = b;
            else if (result <= a)
                result = a;

            return result;
        }
        public static double DLengthBetweenPoint2D(Vector2 a, Vector2 b)
        {
            double result = Math.Sqrt(Math.Pow(b.X - a.X, 2) + Math.Pow(b.Y - a.Y, 2));
            return result;
        }
        public static float FLengthBetweenPoint2D(Vector2 a, Vector2 b)
        {
            double rawResult = Math.Sqrt(Math.Pow(b.X - a.X, 2) + Math.Pow(b.Y - a.Y, 2));
            float result = Convert.ToSingle(rawResult);
            return result;
        }
        public static int ILengthBetweenPoint2D(Vector2 a, Vector2 b)
        {
            double rawResult = Math.Sqrt(Math.Pow(b.X - a.X, 2) + Math.Pow(b.Y - a.Y, 2));
            int result = Convert.ToInt32(rawResult);
            return result;
        }

        public static int ILengthBetweenPoint1D(int a, int b)
        {
            double rawResult = Math.Sqrt(Math.Pow(b - a, 2));
            int result = Convert.ToInt32(rawResult);
            return result;
        }
        public static float FLengthBetweenPoint1D(int a, int b)
        {
            double rawResult = Math.Sqrt(Math.Pow(b - a, 2));
            float result = Convert.ToSingle(rawResult);
            return result;
        }
        public static double DLengthBetweenPoint1D(int a, int b)
        {
            double result = Math.Sqrt(Math.Pow(b - a, 2));
            return result;
        }
        public static float Clamp(float value, float min, float max)
        {
            bool flag = value < min;
            if (flag)
            {
                value = min;
            }
            else
            {
                bool flag2 = value > max;
                if (flag2)
                {
                    value = max;
                }
            }
            return value;
        }

        public static float Repeat(float t, float length)
        {
            return Clamp(t - Convert.ToSingle(Math.Floor(t / length)) * length, 0f, length);
        }

        public static float MoveTowards(float current, float target, float maxDelta)
        {
            bool flag = Math.Abs(target - current) <= maxDelta;
            float result;
            if (flag)
                result = target;
            else
                result = current + Math.Sign(target - current) * maxDelta;
            return result;
        }
    }
}
