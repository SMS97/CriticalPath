using System;

namespace Berechnung
{
    public class ArrayHandler
    {
        private int[] array;
        public ArrayHandler(int[] array)
        {
            this.array = array;
        }
        private int MinValue()
        {
            int minValue = array[0];
            foreach(int value in array)
            {
                if(value <= minValue)
                {
                    minValue = value;
                }
            }
            return minValue;
        }
        private int MaxValue()
        {
            int maxValue = array[0];
            foreach(int value in array)
            {
                if(value >= maxValue)
                {
                    maxValue = value;
                }
            }
            return maxValue;
        }
        public int MinValueOfArray { get => MinValue(); }
        public int MaxValueOfArray { get => MaxValue(); }
        public int IndexOfMaxValue { get => Array.IndexOf(array, MaxValue()); }
        public int IndexOfMinValue { get => Array.IndexOf(array, MinValue()); }
    }
}
