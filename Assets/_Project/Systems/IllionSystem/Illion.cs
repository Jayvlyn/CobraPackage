using UnityEngine;

namespace Cobra.Utilities
{
    public class Illion
    {
        private int sectionValue;
        public int Value => sectionValue;

        public static Illion operator +(Illion self, int value)
        {
            self.Add(value);
            return self;
        }
        public static Illion operator -(Illion self, int value)
        {
            self.Subtract(value);
            return self;
        }

        private void Add(int value)
        {

        }

        private void Subtract(int value)
        {

        }


        public override string ToString()
        {
            return "Illion";
        }
    }
}