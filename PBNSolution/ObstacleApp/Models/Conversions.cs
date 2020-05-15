using System;
using System.Collections.Generic;
using System.Text;

namespace ObstacleApp
{
    static class Conversions
    {
        //Distances
        static double fmr = 0.3048;             // Constant, feet to meters ratio
        static double NM_M = 1852;              // Constant, Nautical miles in meters
        static double NM_f = 1852 / 0.3048;     // Constant, 6076.11548
        public static double ConvertPosition(double input)
        {
            //remove -
            if (input < 0)
            {
                input *= -1;
            }

            //DMStoDdeg
            if (input > 1000)
            {
                double dDeg = (input / 10000) - (input / 10000 % 1);
                double mDeg = ((((input) - (dDeg * 10000)) / 100) - ((((input) - (dDeg * 10000)) / 100) % 1)) / 60;
                double sDeg = ((((input) - (dDeg * 10000)) / 100) % 1) / 36;

                return dDeg + mDeg + sDeg;
            }

            //DDegToDMS
            else
            {
                double dDMS = ((input - (input % 1)) * 10000);
                double mDMS = (((input % 1) * 60) - (((input % 1) * 60) % 1)) * 100;
                double sDMS = (((input % 1) * 60) % 1) * 60;

                return Math.Round(dDMS + mDMS + sDMS, 2);
            }

        }
    }
}
