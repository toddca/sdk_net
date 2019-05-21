// // -----------------------------------------------------------------------
// // <copyright from="2019" to="2019" file="ExternalStatusType.cs" company="Lindell Technologies">
// //    Copyright (c) Lindell Technologies All Rights Reserved.
// //    Information Contained Herein is Proprietary and Confidential.
// // </copyright>
// // -----------------------------------------------------------------------

using System.Runtime.Serialization;

namespace Riskified.SDK.Model.OrderElements
{
    public enum ExternalStatusType
    {
        [EnumMember(Value = "approved")]
        Approved,

        [EnumMember(Value = "checkout")]
        Checkout,

        [EnumMember(Value = "cancelled")]
        Cancelled,

        [EnumMember(Value = "declined")]
        Declined,

        [EnumMember(Value = "declined_fraud")]
        DeclinedFraud,

        [EnumMember(Value = "chargeback_fraud")]
        ChargebackFraud,

        [EnumMember(Value = "chargeback_not_fraud")]
        ChargebackNotFraud
    }
}
