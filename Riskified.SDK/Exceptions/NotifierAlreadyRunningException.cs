// // -----------------------------------------------------------------------
// // <copyright from="2019" to="2019" file="NotifierAlreadyRunningException.cs" company="Lindell Technologies">
// //    Copyright (c) Lindell Technologies All Rights Reserved.
// //    Information Contained Herein is Proprietary and Confidential.
// // </copyright>
// // -----------------------------------------------------------------------

namespace Riskified.SDK.Exceptions
{
    public class NotifierAlreadyRunningException : RiskifiedException
    {
        public NotifierAlreadyRunningException(string message) : base(message)
        {
        }
    }
}
