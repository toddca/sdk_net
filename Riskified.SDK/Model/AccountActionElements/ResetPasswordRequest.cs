// // -----------------------------------------------------------------------
// // <copyright from="2019" to="2019" file="ResetPasswordRequest.cs" company="Lindell Technologies">
// //    Copyright (c) Lindell Technologies All Rights Reserved.
// //    Information Contained Herein is Proprietary and Confidential.
// // </copyright>
// // -----------------------------------------------------------------------

using Riskified.SDK.Model.OrderElements;

namespace Riskified.SDK.Model.AccountActionElements
{
    public class ResetPasswordRequest : AbstractAccountAction
    {
        public ResetPasswordRequest(string customerId, ClientDetails clientDetails, SessionDetails sessionDetails) :
            base(customerId, clientDetails, sessionDetails)
        {
        }
    }
}
