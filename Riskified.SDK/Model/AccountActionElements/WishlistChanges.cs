﻿// // -----------------------------------------------------------------------
// // <copyright from="2019" to="2019" file="WishlistChanges.cs" company="Lindell Technologies">
// //    Copyright (c) Lindell Technologies All Rights Reserved.
// //    Information Contained Herein is Proprietary and Confidential.
// // </copyright>
// // -----------------------------------------------------------------------

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Riskified.SDK.Model.OrderElements;

namespace Riskified.SDK.Model.AccountActionElements
{
    public class WishlistChanges : AbstractAccountAction
    {
        public WishlistChanges(string customerId, WishlistAction wishlistAction, ClientDetails clientDetails, SessionDetails sessionDetails, LineItem lineItem) :
            base(customerId, clientDetails, sessionDetails)
        {
            WishlistAction = wishlistAction;
            LineItem = lineItem;
        }

        [JsonProperty(PropertyName = "wishlist_action")]
        [JsonConverter(typeof(StringEnumConverter))]
        public WishlistAction WishlistAction { get; set; }

        [JsonProperty(PropertyName = "line_item")]
        public LineItem LineItem { get; set; }
    }
}
