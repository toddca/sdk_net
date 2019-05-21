// // -----------------------------------------------------------------------
// // <copyright from="2019" to="2019" file="OrderFulfillment.cs" company="Lindell Technologies">
// //    Copyright (c) Lindell Technologies All Rights Reserved.
// //    Information Contained Herein is Proprietary and Confidential.
// // </copyright>
// // -----------------------------------------------------------------------

using System.Linq;
using Newtonsoft.Json;
using Riskified.SDK.Model.OrderElements;
using Riskified.SDK.Utils;

namespace Riskified.SDK.Model
{
    public class OrderFulfillment : AbstractOrder
    {
        public OrderFulfillment(int merchantOrderId, FulfillmentDetails[] fulfillments)
            : base(merchantOrderId)
        {
            Fulfillments = fulfillments;
        }

        public OrderFulfillment(string merchantOrderId, FulfillmentDetails[] fulfillments)
            : base(merchantOrderId)
        {
            Fulfillments = fulfillments;
        }

        /// <summary>
        ///     A list of fulfillment attempts for the order.
        /// </summary>
        [JsonProperty(PropertyName = "fulfillments")]
        public FulfillmentDetails[] Fulfillments { get; set; }

        public override void Validate(Validations validationType = Validations.Weak)
        {
            base.Validate(validationType);
            InputValidators.ValidateObjectNotNull(Fulfillments, "Fulfillments");
            Fulfillments.ToList().ForEach(item => item.Validate(validationType));
        }
    }
}
