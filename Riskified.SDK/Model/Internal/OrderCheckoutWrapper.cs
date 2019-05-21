// // -----------------------------------------------------------------------
// // <copyright from="2019" to="2019" file="OrderCheckoutWrapper.cs" company="Lindell Technologies">
// //    Copyright (c) Lindell Technologies All Rights Reserved.
// //    Information Contained Herein is Proprietary and Confidential.
// // </copyright>
// // -----------------------------------------------------------------------

using Newtonsoft.Json;

namespace Riskified.SDK.Model.Internal
{
    internal class OrderCheckoutWrapper<TOrderCheckout>
    {
        public OrderCheckoutWrapper(TOrderCheckout order)
        {
            Order = order;
        }

        [JsonProperty(PropertyName = "checkout", Required = Required.Always)]
        public TOrderCheckout Order { get; set; }

        [JsonProperty(PropertyName = "warnings")]
        public string[] Warnings { get; set; }
    }
}
