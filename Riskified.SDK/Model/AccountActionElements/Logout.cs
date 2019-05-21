// // -----------------------------------------------------------------------
// // <copyright from="2019" to="2019" file="Logout.cs" company="Lindell Technologies">
// //    Copyright (c) Lindell Technologies All Rights Reserved.
// //    Information Contained Herein is Proprietary and Confidential.
// // </copyright>
// // -----------------------------------------------------------------------

using Riskified.SDK.Model.OrderElements;

namespace Riskified.SDK.Model.AccountActionElements
{
    public class Logout : AbstractAccountAction
    {
        public Logout(string customerId, ClientDetails clientDetails, SessionDetails sessionDetails) :
            base(customerId, clientDetails, sessionDetails)
        {
        }
    }
}
