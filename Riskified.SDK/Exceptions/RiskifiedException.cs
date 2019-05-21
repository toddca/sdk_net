// // -----------------------------------------------------------------------
// // <copyright from="2019" to="2019" file="RiskifiedException.cs" company="Lindell Technologies">
// //    Copyright (c) Lindell Technologies All Rights Reserved.
// //    Information Contained Herein is Proprietary and Confidential.
// // </copyright>
// // -----------------------------------------------------------------------

using System;

namespace Riskified.SDK.Exceptions
{
    public class RiskifiedException : Exception
    {
        public RiskifiedException(string message) : base(message)
        {
        }

        protected RiskifiedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
