﻿// // -----------------------------------------------------------------------
// // <copyright from="2019" to="2019" file="NoChargeDetails.cs" company="Lindell Technologies">
// //    Copyright (c) Lindell Technologies All Rights Reserved.
// //    Information Contained Herein is Proprietary and Confidential.
// // </copyright>
// // -----------------------------------------------------------------------

using Newtonsoft.Json;
using Riskified.SDK.Exceptions;
using Riskified.SDK.Utils;

namespace Riskified.SDK.Model.OrderElements
{
    public class NoChargeDetails : IJsonSerializable
    {
        public NoChargeDetails(string refundId, double amount, string currency, string reason)
        {
            RefundId = refundId;
            Amount = amount;
            Currency = currency;
            Reason = reason;
        }

        [JsonProperty(PropertyName = "refund_id")]
        public string RefundId { get; set; }

        [JsonProperty(PropertyName = "amount")]
        public double Amount { get; set; }

        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }

        [JsonProperty(PropertyName = "reason")]
        public string Reason { get; set; }

        /// <summary>
        ///     Validates the objects fields content
        /// </summary>
        /// <param name="validationType">Should use weak validations or strong</param>
        /// <exception cref="OrderFieldBadFormatException">
        ///     throws an exception if one of the parameters doesn't match the expected
        ///     format
        /// </exception>
        public void Validate(Validations validationType = Validations.Weak)
        {
            InputValidators.ValidateValuedString(RefundId, "Refund ID");
            InputValidators.ValidateZeroOrPositiveValue(Amount, "No Charge Amount");
            InputValidators.ValidateCurrency(Currency);
            InputValidators.ValidateValuedString(Reason, "No Charge Reason");
        }
    }
}
