// -----------------------------------------------------------------------
// <copyright file="MilisecondConverter.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace RLCTelemetry.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Takes in a float of miliseconds. Returns a new time formatted as 1:11.111.
    /// </summary>
    public class MillisecondConverter
    {
        public String Convert(float milliseconds)
        {
            double divisor = 60;
            double remainder = Math.Round(milliseconds % divisor, 3);
            int quotient = (int)(milliseconds / divisor);

            if (quotient > 0)
            {
                return string.Format("{0}:{1}", quotient, remainder);
            }
            else
            {
                return string.Format("{0}", remainder);
            }
        }
    }
}
