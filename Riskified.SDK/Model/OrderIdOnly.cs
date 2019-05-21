// // -----------------------------------------------------------------------
// // <copyright from="2019" to="2019" file="OrderIdOnly.cs" company="Lindell Technologies">
// //    Copyright (c) Lindell Technologies All Rights Reserved.
// //    Information Contained Herein is Proprietary and Confidential.
// // </copyright>
// // -----------------------------------------------------------------------

namespace Riskified.SDK.Model
{
    public class OrderIdOnly : OrderBase
    {
        public OrderIdOnly(string merchantOrderId) : base(merchantOrderId)
        {
        }
    }
}
