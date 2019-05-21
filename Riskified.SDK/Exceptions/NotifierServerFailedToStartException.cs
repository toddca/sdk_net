// // -----------------------------------------------------------------------
// // <copyright from="2019" to="2019" file="NotifierServerFailedToStartException.cs" company="Lindell Technologies">
// //    Copyright (c) Lindell Technologies All Rights Reserved.
// //    Information Contained Herein is Proprietary and Confidential.
// // </copyright>
// // -----------------------------------------------------------------------

using System;

namespace Riskified.SDK.Exceptions
{
    public class NotifierServerFailedToStartException : RiskifiedException
    {
        public NotifierServerFailedToStartException(string message)
            : base(message)
        {
        }

        public NotifierServerFailedToStartException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
