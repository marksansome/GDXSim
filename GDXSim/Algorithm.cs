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
            switch (cmd)
            {
                //cases
            }

            return fx;
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
                rate = 1 + (args[4] / 100); //exponential growth
            else
                rate = 1 - (args[4] / 100); //exponential decay

            //calculate
            temp = Math.Pow(rate, k);
            temp = xo * temp;

            //return temp to be fx
            return temp;
        }


        public static double Sin(String cmd, double[] args)
        {
            double sin;
            double angle = args[0];

            if (!(cmd.Equals("degrees")))
                angle = Math.PI * angle / 180.0; //value sent in was in degrees; convert to radians

            //calculate sin
            sin = Math.Sin(angle);

            return sin;
        }

        public static double Cos(String cmd, double[] args)
        {
            double cos;
            double angle = args[0];

            if (!(cmd.Equals("radians")))
                angle = Math.PI * angle / 180.0; //value sent in was in degrees; convert to radians

            //calculate cos
            cos = Math.Cos(angle);

            return cos;
        }

        public static double Tan(String cmd, double[] args)
        {
            double tan;
            double angle = args[0];

            if (!(cmd.Equals("radians")))
                angle = Math.PI * angle / 180.0; //value sent in was in degrees; convert to radians

            //calculate sin
            tan = Math.Atan(angle);

            return tan;
        }
    }
}
