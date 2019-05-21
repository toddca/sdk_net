// // -----------------------------------------------------------------------
// // <copyright from="2019" to="2019" file="OrderPartialRefund.cs" company="Lindell Technologies">
// //    Copyright (c) Lindell Technologies All Rights Reserved.
// //    Information Contained Herein is Proprietary and Confidential.
// // </copyright>
// // -----------------------------------------------------------------------

using System.Linq;
using Newtonsoft.Json;
using Riskified.SDK.Model.RefundElements;
using Riskified.SDK.Utils;

namespace Riskified.SDK.Model
{
    public class OrderPartialRefund : AbstractOrder
    {
        public OrderPartialRefund(int merchantOrderId, PartialRefundDetails[] partialRefunds) : base(merchantOrderId)
        {
            Refunds = partialRefunds;
        }

        public OrderPartialRefund(string merchantOrderId, PartialRefundDetails[] partialRefunds) : base(merchantOrderId)
        {
            Refunds = partialRefunds;
        }

        [JsonProperty(PropertyName = "refunds")]
        public PartialRefundDetails[] Refunds { get; set; }

        public override void Validate(Validations validationType = Validations.Weak)
        {
            base.Validate(validationType);
            InputValidators.ValidateObjectNotNull(Refunds, "Refunds");
            Refunds.ToList().ForEach(item => item.Validate(validationType));
        }
    }
}
