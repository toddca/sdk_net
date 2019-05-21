﻿// // -----------------------------------------------------------------------
// // <copyright from="2019" to="2019" file="CustomerUpdate.cs" company="Lindell Technologies">
// //    Copyright (c) Lindell Technologies All Rights Reserved.
// //    Information Contained Herein is Proprietary and Confidential.
// // </copyright>
// // -----------------------------------------------------------------------

using Newtonsoft.Json;
using Riskified.SDK.Model.OrderElements;

namespace Riskified.SDK.Model.AccountActionElements
{
    public class CustomerUpdate : BaseCustomerAction
    {
        public CustomerUpdate(string customerId, bool? passwordChanged, ClientDetails clientDetails, SessionDetails sessionDetails, Customer customer) :
            base(customerId, clientDetails, sessionDetails, customer)
        {
            PasswordChanged = passwordChanged;
        }

        [JsonProperty(PropertyName = "password_changed")]
        public bool? PasswordChanged { get; set; }
    }
}
