// // -----------------------------------------------------------------------
// // <copyright from="2019" to="2019" file="CustomerCreate.cs" company="Lindell Technologies">
// //    Copyright (c) Lindell Technologies All Rights Reserved.
// //    Information Contained Herein is Proprietary and Confidential.
// // </copyright>
// // -----------------------------------------------------------------------

using Riskified.SDK.Model.OrderElements;

namespace Riskified.SDK.Model.AccountActionElements
{
    public class CustomerCreate : BaseCustomerAction
    {
        public CustomerCreate(string customerId, ClientDetails clientDetails, SessionDetails sessionDetails, Customer customer) :
            base(customerId, clientDetails, sessionDetails, customer)
        {
        }
    }
}
