// // -----------------------------------------------------------------------
// // <copyright from="2019" to="2019" file="FailureReason.cs" company="Lindell Technologies">
// //    Copyright (c) Lindell Technologies All Rights Reserved.
// //    Information Contained Herein is Proprietary and Confidential.
// // </copyright>
// // -----------------------------------------------------------------------

using System.Runtime.Serialization;

namespace Riskified.SDK.Model.OrderElements
{
    public enum FailureReason
    {
        [EnumMember(Value = "wrong password")]
        WrongPassword,

        [EnumMember(Value = "captcha")]
        Captcha,

        [EnumMember(Value = "disabled account")]
        DisabledAccount,

        [EnumMember(Value = "nonexistent account")]
        NonexistentAccount,

        [EnumMember(Value = "other")]
        Other
    }
}
