using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 * Created by Nandiola17    
 * Dev started on 21st May, 2015
 * Version 2.0 
 */

namespace GDXSim
{
    class Algorithm
    {

        public static double fx; //last calculated value
        public static double CalculateFX(String cmd, double[] args)
        {
            double temp = 0;
            switch (cmd)
            {
                case "sin": temp = trig(cmd, args);
                    break;
                case "cos": temp = trig(cmd, args);
                    break;
                case "tan": temp = trig(cmd, args);
                    break;
                case "growth": temp = ex(cmd, args);
                    break;
                case "decay": temp = ex(cmd, args);
                    break;
            }

            if (check(temp))
                fx = temp; //complete calculations
            else
                Console.WriteLine("error at operation sign " + cmd);

            return fx;
        }

        private static Boolean check(double temp)
        {
            try
            {
                if (double.IsPositiveInfinity(temp))
                {
                    //it is a positive infinite number
                    return false;
                }
                else if (double.IsNegativeInfinity(temp))
                {
                    //it is negative infinite
                    return false;
                }

                //try doing basic math to see if anything wrong
                temp = (temp + 1) / 1000;

                //otherwise nothing wrong
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public static double ex(String cmd, double[] args)
        {
            double temp = 0;
            double xo = args[0]; //original amount
            double t = args[1]; //time elapsed
            double period = args[2]; //time period 
            double k = t / period; //to be used in the equation

            //check for exponential growth or decay
            double rate; //the rate at which it increases
            if (cmd.Equals("growth"))
                rate = 1 + (args[3] / 100); //exponential growth
            else
                rate = 1 - (args[3] / 100); //exponential decay

            //calculate
            temp = Math.Pow(rate, k);
            temp = xo * temp;

            //return temp to be fx
            return temp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmd"> Takes in a special command for advanced operations. "Degrees" indicates that input is in degrees, "radians" indicates radians.</param>
        /// <param name="args"> Array contains all args required by the algorithm.
        /// [0] holds the angle theta, [1] holds the horizontal shift, [2] holds the vertical shift, [3] holds the period, [4] holds amplitude</param>
        /// <returns></returns>
        public static double trig(String cmd, double[] args)
        {
            double answer = 0;
            double angle = args[0]; double HS = args[1]; double VS = args[2]; double period = args[3]; double amp = args[4];

            //add horizontal components
            answer = angle / period;
            answer = answer + HS;
            Console.WriteLine("angle to be passed: " + answer);

            switch (cmd)
            {
                case "sin": answer = Math.Sin(answer);
                    break;
                case "cos": answer = Math.Cos(answer);
                    break;
                case "tan": answer = Math.Tan(answer);
                    break;
            }

            Console.WriteLine("answer gotten : " + answer);
            //add vertical components
            answer = answer * amp;
            answer = answer + VS;

            return answer;
        }
    }
}
