using System;

namespace TicketMachine
{
    public class AMU
    {
        public const int FloatPrecision = 1000000; // 10^6
        private int big, small;

        public AMU(int big, int small)
        {
            this.big = big;
            this.small = small;
        }

        public AMU(double balance) : this((int)balance, (int)(balance % 1 * FloatPrecision)) {}
        public AMU(int big) : this(big, 0) {}

        public override string ToString()
        {
            return string.Format("{0}.{1} AMU", big, small.ToString("D6"));
        }

        public static AMU operator +(AMU o1, AMU o2)
        {
            int newSmall = o1.small + o2.small;
            int newBig = o1.big + o2.big + (newSmall >= FloatPrecision ? 1 : 0);

            return new AMU(newBig, newSmall % FloatPrecision);
        }

        public static AMU operator -(AMU o1, AMU o2)
        {
            int newSmall = o1.small - o2.small;
            int newBig = o1.big + o2.big;
            if (newSmall < 0)
            {
                newBig--;
                newSmall += FloatPrecision;
            }

            return new AMU(newBig, newSmall);
        }

        public static bool operator <(AMU o1, AMU o2)
        {
            if (o1.big < o2.big)
            {
                return true;
            } 
            else if (o1.big == o2.big)
            {
                return o1.small < o2.small;
            }
            else
            {
                return false;
            }
        }

        public static bool operator >(AMU o1, AMU o2)
        {
            if (o1.big > o2.big)
            {
                return true;
            }
            else if (o1.big == o2.big)
            {
                return o1.small > o2.small;
            }
            else
            {
                return false;
            }
        }

        public static bool operator <(AMU o1, int i)
        {
            return o1 < new AMU(i);
        }

        public static bool operator >(AMU o1, int i)
        {
            return o1 > new AMU(i);
        }

        public int Big
        {
            get
            {
                return big;
            }
        }

        public int Small
        {
            get
            {
                return small;
            }
        }
    }
}