// // -----------------------------------------------------------------------
// // <copyright from="2019" to="2019" file="TransportMethodType.cs" company="Lindell Technologies">
// //    Copyright (c) Lindell Technologies All Rights Reserved.
// //    Information Contained Herein is Proprietary and Confidential.
// // </copyright>
// // -----------------------------------------------------------------------

using System.Runtime.Serialization;

namespace Riskified.SDK.Model.OrderElements
{
    public enum TransportMethodType
    {
        [EnumMember(Value = "plane")]
        Plane,

        [EnumMember(Value = "ship")]
        Ship,

        [EnumMember(Value = "bus")]
        Bus,

        [EnumMember(Value = "train")]
        Train
    }
}
