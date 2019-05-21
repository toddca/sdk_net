// // -----------------------------------------------------------------------
// // <copyright from="2019" to="2019" file="DecisionDetails.cs" company="Lindell Technologies">
// //    Copyright (c) Lindell Technologies All Rights Reserved.
// //    Information Contained Herein is Proprietary and Confidential.
// // </copyright>
// // -----------------------------------------------------------------------

using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Riskified.SDK.Utils;

namespace Riskified.SDK.Model.OrderElements
{
    public class DecisionDetails : IJsonSerializable
    {
        public DecisionDetails(
            ExternalStatusType externalStatus, DateTime? decidedAt, string reason = null, float? amount = null, string currency = null)
        {
            ExternalStatus = externalStatus;
            DecidedAt = decidedAt;

            // Optional fields
            Reason = reason;
            Amount = amount;
            Currency = currency;
            Notes = Notes;
        }

        /// <summary>
        ///     The external status, meaning the merchant decision on the order
        /// </summary>
        [JsonProperty(PropertyName = "external_status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ExternalStatusType ExternalStatus { get; set; }

        /// <summary>
        ///     The date when the order was decided.
        /// </summary>
        [JsonProperty(PropertyName = "decided_at")]
        public DateTime? DecidedAt { get; set; }

        /// <summary>
        ///     A reason for the decision.
        /// </summary>
        [JsonProperty(PropertyName = "reason")]
        public string Reason { get; set; }

        /// <summary>
        ///     The amount the decision is relevant on.
        /// </summary>
        [JsonProperty(PropertyName = "amount")]
        public float? Amount { get; set; }

        /// <summary>
        ///     The three letter code (ISO 4217) for the currency used for the payment.
        /// </summary>
        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }

        /// <summary>
        ///     Free text for describing the decision.
        /// </summary>
        [JsonProperty(PropertyName = "notes")]
        public string Notes { get; set; }

        public void Validate(Validations validationType = Validations.Weak)
        {
            InputValidators.ValidateObjectNotNull(ExternalStatus, "External Status");
            if (DecidedAt != null)
            {
                InputValidators.ValidateDateNotDefault(DecidedAt.Value, "Decided At");
            }

            if (Currency != null)
            {
                InputValidators.ValidateCurrency(Currency);
            }
        }
    }
}
