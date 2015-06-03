using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 * Created by Nandiola17    
 * Dev started on 21st May, 2015
 * Version 2.1
 * Clarity changes, updated descriptions
 */

namespace GDXSim
{
    public class Algorithm
    {

        //holds last calculated value accessible by the program
        public static double fx;
        
        //TEMPLATE METHOD DO NOT USE
        public static double CalculateX(String cmd, double[] args)
        {
            double temp;

            switch (cmd)
            {
                case "growth": ex_("growth", args);
                    break;
                case "decay": ex_("decay", args);
                    break;
                case "sin": trig_("sin", args);
                    break;
                case "cos": trig_("cos", args);
                    break;
                case "tan": trig_("tan", args);
                    break;
            }

            return 0;
        }

        public static double CalculateFX(String cmd, double[] args)
        {
            switch (cmd)
            {
                case "growth": ex("growth", args);
                    break;
                case "decay": ex("decay", args);
                    break;
                case "sin": trig("sin", args);
                    break;
                case "cos": trig("cos", args);
                    break;
                case "tan": trig("tan", args);
                    break;
            }

            return fx;
        }

        /// <summary>
        /// Calculates exponential equations for value F(x)
        /// </summary>
        /// <param name="cmd">Whether the equation is exponential decay or exponential growth.</param>
        /// <param name="args">Array of doubles holding the parameters for the equation.
        /// [0] is the orginal amount; [1] is time elapsed, [2] is the time period, [3] is the rate</param>
        /// <returns>f(x)</returns>
        private static double ex(String cmd, double[] args)
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

        private static double ex_(String cmd, double[] args)
        {
            double x;
            double fx;
            return 0;
        }

        /// <summary>
        /// Calculates trig equations for value F(x)
        /// </summary>
        /// <param name="cmd">Calculate sin, cos or tan depending on the value of the 'cmd' string.</param>
        /// <param name="args"> Array contains all args required by the algorithm.
        /// [0] holds the angle theta, [1] holds the horizontal shift, [2] holds the vertical shift, [3] holds the period, [4] holds amplitude</param>
        /// <returns></returns>
        private static double trig(String cmd, double[] args)
        {
            double answer;
            double angle = args[0]; double HS = args[1]; double VS = args[2]; double period = args[3]; double amp = args[4];

            //add horizontal components
            angle = angle / period;
            angle = angle + HS;

            switch (cmd)
            {
                case "sin": answer = Math.Sin(angle);
                    break;
                case "cos": answer = Math.Cos(angle);
                    break;
                case "tan": answer = Math.Tan(angle);
                    break;
            }
            
            //add vertical components
            answer = angle + VS;
            answer = answer * amp;

            return answer;

        }

        //TEMPLATE METHOD DO NOT USE
        private static double trig_(String cmd, double[] args)
        {
            double x;
            double fx;
            return 0;
        }
    }
}
