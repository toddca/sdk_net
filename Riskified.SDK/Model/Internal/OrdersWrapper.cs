// // -----------------------------------------------------------------------
// // <copyright from="2019" to="2019" file="OrdersWrapper.cs" company="Lindell Technologies">
// //    Copyright (c) Lindell Technologies All Rights Reserved.
// //    Information Contained Herein is Proprietary and Confidential.
// // </copyright>
// // -----------------------------------------------------------------------

using System.Collections.Generic;
using Newtonsoft.Json;

namespace Riskified.SDK.Model.Internal
{
    internal class OrdersWrapper
    {
        public OrdersWrapper(IEnumerable<AbstractOrder> orders)
        {
            Orders = orders;
        }

        [JsonProperty(PropertyName = "orders")]
        public IEnumerable<AbstractOrder> Orders { get; set; }
    }
}
