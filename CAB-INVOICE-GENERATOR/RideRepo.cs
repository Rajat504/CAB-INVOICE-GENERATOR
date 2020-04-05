using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace CAB_INVOICE_GENERATOR
{
    namespace Cab_Invoice_Generator
    {
        using global::Cab_Invoice_Generator;
        using System.Collections.Generic;

        /// <summary>
        /// RideRepository Class.
        /// </summary>
        public class RideRepo
        {
            /// <summary>
            /// Dictionary Reference.
            /// </summary>
            Dictionary<string, List<Ride>> UserRides = null;

            /// <summary>
            /// RideRepository Constructor.
            /// </summary>
            public RideRepo()
            {
                this.UserRides = new Dictionary<string, List<Ride>>();
            }

            /// <summary>
            /// AddRides Method.
            /// </summary>
            /// <param name="userID"></param>
            /// <param name="rides"></param>
            public void AddRides(string userID, Ride[] rides)
            {
                bool rideList = this.UserRides.ContainsKey(userID);
                if (rideList == false)
                {
                    List<Ride> list = new List<Ride>();
                    list.AddRange(rides);
                    this.UserRides.Add(userID, list);
                }
            }

            /// <summary>
            /// GetRides Method.
            /// gets UserId 
            /// </summary>
            /// <param name="userID"></param>
            /// <returns> Ride </returns>
            public Ride[] GetRides(string userID)
            {
                return this.UserRides[userID].ToArray();
            }
        }
    }



}
