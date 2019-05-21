// // -----------------------------------------------------------------------
// // <copyright from="2019" to="2019" file="SocialType.cs" company="Lindell Technologies">
// //    Copyright (c) Lindell Technologies All Rights Reserved.
// //    Information Contained Herein is Proprietary and Confidential.
// // </copyright>
// // -----------------------------------------------------------------------

using System.Runtime.Serialization;

namespace Riskified.SDK.Model.OrderElements
{
    public enum SocialType
    {
        [EnumMember(Value = "facebook")]
        Facebook,

        [EnumMember(Value = "google")]
        Google,

        [EnumMember(Value = "linkedin")]
        LinkedIn,

        [EnumMember(Value = "twitter")]
        Twitter,

        [EnumMember(Value = "yahoo")]
        Yahoo,

        [EnumMember(Value = "other")]
        Other
    }
}
