// // -----------------------------------------------------------------------
// // <copyright from="2019" to="2019" file="LoginStatusType.cs" company="Lindell Technologies">
// //    Copyright (c) Lindell Technologies All Rights Reserved.
// //    Information Contained Herein is Proprietary and Confidential.
// // </copyright>
// // -----------------------------------------------------------------------

using System.Runtime.Serialization;

namespace Riskified.SDK.Model.OrderElements
{
    public enum LoginStatusType
    {
        [EnumMember(Value = "success")]
        Success,

        [EnumMember(Value = "failure")]
        Failure
    }
}
