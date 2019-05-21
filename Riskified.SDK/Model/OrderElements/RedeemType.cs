// // -----------------------------------------------------------------------
// // <copyright from="2019" to="2019" file="RedeemType.cs" company="Lindell Technologies">
// //    Copyright (c) Lindell Technologies All Rights Reserved.
// //    Information Contained Herein is Proprietary and Confidential.
// // </copyright>
// // -----------------------------------------------------------------------

using System.Runtime.Serialization;

namespace Riskified.SDK.Model.OrderElements
{
    public enum RedeemType
    {
        [EnumMember(Value = "promo code")]
        PromoCode,

        [EnumMember(Value = "loyalty points")]
        LoyaltyPoints,

        [EnumMember(Value = "gift card")]
        GiftCard,

        [EnumMember(Value = "other")]
        Other
    }
}
