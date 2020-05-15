using System;


namespace ObstacleApp
{
    // Supply WGS84 earth ellipsoid axis lengths in meters:
    // computed from WGS84 earth flattening coefficient definition
    static class Inverse
    {


        static void inputcheck(double lat1, double lat2, double lon1, double lon2, Exception ex)
        {

            if (Math.Abs(lat1) > 90 * Math.PI / 180 || Math.Abs(lat2) > 90 * Math.PI / 180 || Math.Abs(lon1) > 180 * Math.PI / 180 || Math.Abs(lat2) > 180 * Math.PI / 180)
            {
                Console.WriteLine("Error - " + ex.ToString());
                Console.WriteLine("Error: invalid input");
            }
        }

        //***************** duplicate check *******************
        static void inputduplicate(double az, double arc, double lat1, double lat2, double lon1, double lon2, Exception ex)
        {
            if (lat1 == lat2 && lon1 == lon2)
            {
                Console.WriteLine("Error - " + ex.ToString());
                Console.WriteLine("Error: Same coodinate");
                az = 0;
                arc = 0;
                return;
            }
        }

        // correct for errors at exact poles by adjusting 0.6 millimeters:
        static void antipodal(double lat1, double lat2)
        {
            if (Math.Abs(Math.PI / 2 - Math.Abs(lat1)) < 1e-10)
            {
                lat1 = Math.Sin(lat1) * (Math.PI / 2 - 1e-10);
            }

            if (Math.Abs(Math.PI / 2 - Math.Abs(lat2)) < 1e-10)
            {
                lat2 = Math.Sin(lat2) * (Math.PI / 2 - 1e-10);
            }

        }

        static public inverseCalc invcalc(double lat1, double lon1, double lat2, double lon2)
        {

            double lat1rad = lat1 * Math.PI / 180;
            double lon1rad = lon1 * Math.PI / 180;
            double lat2rad = lat2 * Math.PI / 180;
            double lon2rad = lon2 * Math.PI / 180;

            if (lat1rad == lat2rad && lon1rad == lon2rad)
            {
                inverseCalc sameCalc;
                sameCalc.az = 0;
                sameCalc.xmeters = 0;
                return sameCalc;           //return xmeters;
            }

            double az = 0;
            double xmeters = 0;
            double majorRad = 6378137;
            double minorRad = 6356752.31424518;
            double fc = (majorRad - minorRad) / majorRad;     // 1/(flatening coef.) = 298.25722356
            double U1 = Math.Atan((1 - fc) * Math.Tan(lat1rad));
            double U2 = Math.Atan((1 - fc) * Math.Tan(lat2rad));
            double lt = Math.Abs(lon1rad - lon2rad);
            double lambda = Math.Abs(lon1rad - lon2rad);
            double lambdaold = 0;
            double sinsigma_radical_term1 = 0;
            double sinsigma_radical_term2 = 0;
            double sinsigma = 0;
            double cossigma = 0;
            double alfa = 0;
            double sigma = 0;
            double cos2sigmam = 0;
            double C = 0;
            double Ax = 0;
            double Bx = 0;
            double deltasigma = 0;

            int itercount = 0;

            if (lt > Math.PI * 1)
            {
                lt = 2 * Math.PI - lt;
            }

            while (itercount == 0 || Math.Abs(lambda - lambdaold) > 1e-12)  //SET DECIMALS TO 12, force at least one execution
            {
                itercount = itercount + 1;

                if (itercount > 50)
                {
                    lambda = Math.PI; // points are essentially antipodal           
                }

                lambdaold = lambda;
                sinsigma_radical_term1 = Math.Cos(U2) * Math.Sin(lambda) * (Math.Cos(U2) * Math.Sin(lambda));
                sinsigma_radical_term2 = Math.Cos(U1) * Math.Sin(U2) - Math.Sin(U1) * Math.Cos(U2) * Math.Cos(lambda);
                sinsigma = Math.Sqrt(sinsigma_radical_term1 + sinsigma_radical_term2 * sinsigma_radical_term2);
                cossigma = Math.Sin(U1) * Math.Sin(U2) + Math.Cos(U1) * Math.Cos(U2) * Math.Cos(lambda);
                sigma = Math.Atan2(sinsigma, cossigma);
                alfa = Math.Asin(Math.Cos(U1) * Math.Cos(U2) * Math.Sin(lambda) / Math.Sin(sigma));
                cos2sigmam = Math.Cos(sigma) - 2 * (Math.Sin(U1) * Math.Sin(U2) / (Math.Cos(alfa) * Math.Cos(alfa)));
                C = fc / 16 * (Math.Cos(alfa) * Math.Cos(alfa)) * (4 + fc * (4 - 3 * (Math.Cos(alfa) * Math.Cos(alfa))));
                lambda = lt + (1 - C) * fc * Math.Sin(alfa) * (sigma + C * Math.Sin(sigma) * (cos2sigmam + C * Math.Cos(sigma) * (-1 + 2 * cos2sigmam * cos2sigmam)));
            }

            U2 = Math.Cos(alfa) * Math.Cos(alfa) * (majorRad * majorRad - minorRad * minorRad) / (minorRad * minorRad);
            Ax = 1 + U2 / 16384 * (4096 + U2 * (-768 + U2 * (320 - 175 * U2)));
            Bx = U2 / 1024 * (256 + U2 * (-128 + U2 * (74 - 47 * U2)));
            deltasigma = Bx * Math.Sin(sigma) * (cos2sigmam + Bx / 4 * (Math.Cos(sigma) * (-1 + 2 * cos2sigmam * cos2sigmam) - Bx / 6 * cos2sigmam * (-3 + 4 * Math.Sin(sigma) * Math.Sin(sigma) * (-3 + 4 * cos2sigmam * cos2sigmam))));
            xmeters = minorRad * Ax * (sigma - deltasigma);
            U1 = Math.Atan((1 - fc) * Math.Tan(lat1rad));
            U2 = Math.Atan((1 - fc) * Math.Tan(lat2rad));
            az = Math.Atan2(Math.Cos(U2) * Math.Sin(lambda), Math.Cos(U1) * Math.Sin(U2) - Math.Sin(U1) * Math.Cos(U2) * Math.Cos(lambda));

            if (lon2 > lon1)
            {
                double azx = az;
                az = 2 * Math.PI - azx; // returned forward result 
            }

            inverseCalc myCalc;
            myCalc.az = az;
            myCalc.xmeters = xmeters;
            return myCalc;           //return xmeters;
        }

    }

    public struct inverseCalc
    {
        public double az;
        public double xmeters;
    }
}



