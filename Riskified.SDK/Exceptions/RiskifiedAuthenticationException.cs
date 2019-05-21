// // -----------------------------------------------------------------------
// // <copyright from="2019" to="2019" file="RiskifiedAuthenticationException.cs" company="Lindell Technologies">
// //    Copyright (c) Lindell Technologies All Rights Reserved.
// //    Information Contained Herein is Proprietary and Confidential.
// // </copyright>
// // -----------------------------------------------------------------------

using System;

namespace Riskified.SDK.Exceptions
{
    public class RiskifiedAuthenticationException : RiskifiedException
    {
        public RiskifiedAuthenticationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public RiskifiedAuthenticationException(string message)
            : base(message)
        {
        }
    }
}
