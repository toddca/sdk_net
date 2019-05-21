// // -----------------------------------------------------------------------
// // <copyright from="2019" to="2019" file="WishlistAction.cs" company="Lindell Technologies">
// //    Copyright (c) Lindell Technologies All Rights Reserved.
// //    Information Contained Herein is Proprietary and Confidential.
// // </copyright>
// // -----------------------------------------------------------------------

using System.Runtime.Serialization;

namespace Riskified.SDK.Model.OrderElements
{
    public enum WishlistAction
    {
        [EnumMember(Value = "add")]
        Add,

        [EnumMember(Value = "remove")]
        Remove
    }
}
