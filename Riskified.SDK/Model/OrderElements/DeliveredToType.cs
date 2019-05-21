// // -----------------------------------------------------------------------
// // <copyright from="2019" to="2019" file="DeliveredToType.cs" company="Lindell Technologies">
// //    Copyright (c) Lindell Technologies All Rights Reserved.
// //    Information Contained Herein is Proprietary and Confidential.
// // </copyright>
// // -----------------------------------------------------------------------

using System.Runtime.Serialization;

namespace Riskified.SDK.Model.OrderElements
{
    // Used on the line item level, the pickup location for that product
    public enum DeliveredToType
    {
        [EnumMember(Value = "shipping_address")]
        ShippingAddress,

        [EnumMember(Value = "store_pickup")]
        StorePickup
    }
}
