// // -----------------------------------------------------------------------
// // <copyright from="2019" to="2019" file="ProductType.cs" company="Lindell Technologies">
// //    Copyright (c) Lindell Technologies All Rights Reserved.
// //    Information Contained Herein is Proprietary and Confidential.
// // </copyright>
// // -----------------------------------------------------------------------

using System.Runtime.Serialization;

namespace Riskified.SDK.Model.OrderElements
{
    public enum ProductType
    {
        [EnumMember(Value = "digital")]
        Digital,

        [EnumMember(Value = "downloadable")]
        Downloadable,

        [EnumMember(Value = "physical")]
        Physical,

        [EnumMember(Value = "composite")]
        Composite,

        [EnumMember(Value = "event")]
        EventTicket,

        [EnumMember(Value = "travel")]
        TravelTicket,

        [EnumMember(Value = "accommodation")]
        Accommodation
    }
}
