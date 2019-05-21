﻿// // -----------------------------------------------------------------------
// // <copyright from="2019" to="2019" file="PartialRefundDetails.cs" company="Lindell Technologies">
// //    Copyright (c) Lindell Technologies All Rights Reserved.
// //    Information Contained Herein is Proprietary and Confidential.
// // </copyright>
// // -----------------------------------------------------------------------

using System;
using Newtonsoft.Json;
using Riskified.SDK.Exceptions;
using Riskified.SDK.Utils;

namespace Riskified.SDK.Model.RefundElements
{
    public class PartialRefundDetails : IJsonSerializable
    {
        /// <summary>
        ///     The details for a single partial refund element
        /// </summary>
        /// <param name="refundId">A unique identifier for the refund record at the merchant's system</param>
        /// <param name="refundedAt">Date and time when the refund occured</param>
        /// <param name="amount">The amount refunded (at the specified currency)</param>
        /// <param name="currency">The currency of the refund amount</param>
        /// <param name="reason">The reason for the partial refund</param>
        /// <exception cref="OrderFieldBadFormatException">
        ///     throws an exception if one of the parameters doesn't match the expected
        ///     format
        /// </exception>
        public PartialRefundDetails(string refundId, DateTime refundedAt, double amount, string currency, string reason)
        {
            RefundId = refundId;
            RefundedAt = refundedAt;
            Amount = amount;
            Currency = currency;
            Reason = reason;
        }

        [JsonProperty(PropertyName = "refund_id")]
        public string RefundId { get; set; }

        [JsonProperty(PropertyName = "refunded_at")]
        public DateTime RefundedAt { get; set; }

        [JsonProperty(PropertyName = "amount")]
        public double Amount { get; set; }

        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }

        [JsonProperty(PropertyName = "reason")]
        public string Reason { get; set; }

        public void Validate(Validations validationType = Validations.Weak)
        {
            InputValidators.ValidateValuedString(RefundId, "Refund ID");
            InputValidators.ValidateDateNotDefault(RefundedAt, "Refunded At");
            InputValidators.ValidateZeroOrPositiveValue(Amount, "Refund Amount");
            InputValidators.ValidateCurrency(Currency);
            InputValidators.ValidateValuedString(Reason, "Refund Reason");
        }
    }
}
