// // -----------------------------------------------------------------------
// // <copyright from="2019" to="2019" file="FulfillmentDetails.cs" company="Lindell Technologies">
// //    Copyright (c) Lindell Technologies All Rights Reserved.
// //    Information Contained Herein is Proprietary and Confidential.
// // </copyright>
// // -----------------------------------------------------------------------

using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Riskified.SDK.Utils;

namespace Riskified.SDK.Model.OrderElements
{
    public class FulfillmentDetails : IJsonSerializable
    {
        public FulfillmentDetails(
            string fulfillmentId, DateTime createdAt, FulfillmentStatusCode status, LineItem[] lineItems = null, string trackingCompany = null,
            string trackingNumbers = null,
            string trackingUrls = null, string message = null, string receipt = null)
        {
            FulfillmentId = fulfillmentId;
            CreatedAt = createdAt;
            Status = status;

            // Optional fields
            LineItems = lineItems;
            TrackingCompany = trackingCompany;
            TrackingNumbers = trackingNumbers;
            TrackingUrls = trackingUrls;
            Message = message;
            Receipt = receipt;
        }

        /// <summary>
        ///     Unique identifier of this fulfillment attempt.
        /// </summary>
        [JsonProperty(PropertyName = "fulfillment_id")]
        public string FulfillmentId { get; set; }

        /// <summary>
        ///     When the order was fulfilled.
        /// </summary>
        [JsonProperty(PropertyName = "created_at")]
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        ///     The fulfillment status, Valid values are: success, cancelled, error, failure.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public FulfillmentStatusCode Status { get; set; }

        /// <summary>
        ///     A list of each line item in the attempted fulfillment.
        /// </summary>
        [JsonProperty(PropertyName = "line_items")]
        public LineItem[] LineItems { get; set; }

        /// <summary>
        ///     The name of the shipping company.
        /// </summary>
        [JsonProperty(PropertyName = "tracking_company")]
        public string TrackingCompany { get; set; }

        /// <summary>
        ///     A list of shipping numbers, provided by the shipping company.
        /// </summary>
        [JsonProperty(PropertyName = "tracking_numbers")]
        public string TrackingNumbers { get; set; }

        /// <summary>
        ///     The URLs to track the fulfillment.
        /// </summary>
        [JsonProperty(PropertyName = "tracking_urls")]
        public string TrackingUrls { get; set; }

        /// <summary>
        ///     Additional textual description regarding the fulfillment status.
        /// </summary>
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        /// <summary>
        ///     Additional textual description regarding the fulfillment status.
        /// </summary>
        [JsonProperty(PropertyName = "receipt")]
        public string Receipt { get; set; }


        public void Validate(Validations validationType = Validations.Weak)
        {
            InputValidators.ValidateValuedString(FulfillmentId, "Fulfillment Id");
            InputValidators.ValidateDateNotDefault(CreatedAt.GetValueOrDefault(), "Created At");
            InputValidators.ValidateObjectNotNull(Status, "Status");


            LineItems?.ToList().ForEach(item => item.Validate(validationType));
        }
    }
}
