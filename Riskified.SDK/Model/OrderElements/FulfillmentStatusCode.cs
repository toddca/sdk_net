// // -----------------------------------------------------------------------
// // <copyright from="2019" to="2019" file="FulfillmentStatusCode.cs" company="Lindell Technologies">
// //    Copyright (c) Lindell Technologies All Rights Reserved.
// //    Information Contained Herein is Proprietary and Confidential.
// // </copyright>
// // -----------------------------------------------------------------------

using System.Runtime.Serialization;

namespace Riskified.SDK.Model.OrderElements
{
    public enum FulfillmentStatusCode
    {
        [EnumMember(Value = "success")]
        Success,

        [EnumMember(Value = "cancelled")]
        Cancelled,

        [EnumMember(Value = "error")]
        Error,

        [EnumMember(Value = "failure")]
        Failure
    }
}
