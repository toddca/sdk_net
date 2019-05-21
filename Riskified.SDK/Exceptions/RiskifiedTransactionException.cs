// // -----------------------------------------------------------------------
// // <copyright from="2019" to="2019" file="RiskifiedTransactionException.cs" company="Lindell Technologies">
// //    Copyright (c) Lindell Technologies All Rights Reserved.
// //    Information Contained Herein is Proprietary and Confidential.
// // </copyright>
// // -----------------------------------------------------------------------

using System;

namespace Riskified.SDK.Exceptions
{
    public class RiskifiedTransactionException : RiskifiedException
    {
        public RiskifiedTransactionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public RiskifiedTransactionException(string message) : base(message)
        {
        }
    }
}
