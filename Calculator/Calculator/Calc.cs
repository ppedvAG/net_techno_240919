using System;

namespace Calculator
{
    public class Calc
    {
        public int Sum(int a, int b)
        {
            if (b > 3233)
                return 44;



            return checked(a + b);
        }

        public bool IsWeekend()
        {
            return DateTime.Now.DayOfWeek == DayOfWeek.Sunday ||
                   DateTime.Now.DayOfWeek == DayOfWeek.Saturday;
        }
    }


}
