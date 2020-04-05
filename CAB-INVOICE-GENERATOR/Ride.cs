using System;
using System.Collections.Generic;
using System.Text;



namespace Cab_Invoice_Generator
{

    /// <summary>
    /// Ride Class.
    /// </summary>
    public class Ride
    {
        double distance;
        double time;

        /// <summary>
        /// Constructor with Parameter of Ride Class.
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="time"></param>
        public Ride(double distance, double time)
        {
            this.distance = distance;
            this.time = time;
        }

        /// <summary>
        /// Get Property of Distance.
        /// </summary>
        public double Distance
        {
            get
            {
                return this.distance;
            }
        }

        /// <summary>
        /// Get property of time.
        /// </summary>
        public double Time
        {
            get
            {
                return this.time;
            }
        }
    }
}
