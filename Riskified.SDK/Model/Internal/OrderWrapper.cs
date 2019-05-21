// // -----------------------------------------------------------------------
// // <copyright from="2019" to="2019" file="OrderWrapper.cs" company="Lindell Technologies">
// //    Copyright (c) Lindell Technologies All Rights Reserved.
// //    Information Contained Herein is Proprietary and Confidential.
// // </copyright>
// // -----------------------------------------------------------------------

using Newtonsoft.Json;

namespace Riskified.SDK.Model.Internal
{
    internal class OrderWrapper<TOrder>
    {
        public OrderWrapper(TOrder order)
        {
            Order = order;
        }

        [JsonProperty(PropertyName = "order", Required = Required.Always)]
        public TOrder Order { get; set; }

        [JsonProperty(PropertyName = "warnings")]
        public string[] Warnings { get; set; }
    }
}
