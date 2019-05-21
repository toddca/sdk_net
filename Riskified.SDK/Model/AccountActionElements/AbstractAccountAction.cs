// // -----------------------------------------------------------------------
// // <copyright from="2019" to="2019" file="AbstractAccountAction.cs" company="Lindell Technologies">
// //    Copyright (c) Lindell Technologies All Rights Reserved.
// //    Information Contained Herein is Proprietary and Confidential.
// // </copyright>
// // -----------------------------------------------------------------------

using Newtonsoft.Json;
using Riskified.SDK.Model.OrderElements;

namespace Riskified.SDK.Model.AccountActionElements
{
    public abstract class AbstractAccountAction
    {
        protected AbstractAccountAction(string customerId, ClientDetails clientDetails = null, SessionDetails sessionDetails = null)
        {
            CustomerId = customerId;
            ClientDetails = clientDetails;
            SessionDetails = sessionDetails;
        }

        [JsonProperty(PropertyName = "customer_id")]
        public string CustomerId { get; set; }

        [JsonProperty(PropertyName = "client_details")]
        public ClientDetails ClientDetails { get; set; }

        [JsonProperty(PropertyName = "session_details")]
        public SessionDetails SessionDetails { get; set; }
    }
}
