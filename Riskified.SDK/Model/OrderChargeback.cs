// // -----------------------------------------------------------------------
// // <copyright from="2019" to="2019" file="OrderChargeback.cs" company="Lindell Technologies">
// //    Copyright (c) Lindell Technologies All Rights Reserved.
// //    Information Contained Herein is Proprietary and Confidential.
// // </copyright>
// // -----------------------------------------------------------------------

using Newtonsoft.Json;
using Riskified.SDK.Model.ChargebackElements;
using Riskified.SDK.Model.OrderElements;

namespace Riskified.SDK.Model
{
    public class OrderChargeback : OrderBase
    {
        /// <summary>
        ///     Creates a new order chargeback
        /// </summary>
        /// <param name="merchantOrderId">The unique id of the order at the merchant systems</param>
        /// <param name="chargebackDetails"></param>
        /// <param name="fulfillment"></param>
        /// <param name="disputeDetails"></param>
        public OrderChargeback(string merchantOrderId, ChargebackDetails chargebackDetails, FulfillmentDetails fulfillment, DisputeDetails disputeDetails)
            : base(merchantOrderId)
        {
            Chargeback = chargebackDetails;
            Fulfillment = fulfillment;
            Dispute = disputeDetails;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "chargeback_details")]
        public ChargebackDetails Chargeback { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "fulfillment")]
        public FulfillmentDetails Fulfillment { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "dispute_details")]
        public DisputeDetails Dispute { get; set; }

    }
}
