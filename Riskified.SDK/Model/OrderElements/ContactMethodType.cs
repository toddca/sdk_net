// // -----------------------------------------------------------------------
// // <copyright from="2019" to="2019" file="ContactMethodType.cs" company="Lindell Technologies">
// //    Copyright (c) Lindell Technologies All Rights Reserved.
// //    Information Contained Herein is Proprietary and Confidential.
// // </copyright>
// // -----------------------------------------------------------------------

using System.Runtime.Serialization;

namespace Riskified.SDK.Model.OrderElements
{
    public enum ContactMethodType
    {
        [EnumMember(Value = "email")]
        Email,

        [EnumMember(Value = "website_chat")]
        WebsiteChat,

        [EnumMember(Value = "facebook")]
        Facebook,

        [EnumMember(Value = "phone")]
        Phone,

        [EnumMember(Value = "other")]
        Other
    }
}
