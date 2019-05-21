// // -----------------------------------------------------------------------
// // <copyright from="2019" to="2019" file="OrderFieldBadFormatException.cs" company="Lindell Technologies">
// //    Copyright (c) Lindell Technologies All Rights Reserved.
// //    Information Contained Herein is Proprietary and Confidential.
// // </copyright>
// // -----------------------------------------------------------------------

using System;

namespace Riskified.SDK.Exceptions
{
    public class OrderFieldBadFormatException : RiskifiedException
    {
        public OrderFieldBadFormatException(string message) : base(message)
        {
        }

        public OrderFieldBadFormatException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
