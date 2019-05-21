// // -----------------------------------------------------------------------
// // <copyright from="2019" to="2019" file="DisputeDetails.cs" company="Lindell Technologies">
// //    Copyright (c) Lindell Technologies All Rights Reserved.
// //    Information Contained Herein is Proprietary and Confidential.
// // </copyright>
// // -----------------------------------------------------------------------

using System;
using Newtonsoft.Json;
using Riskified.SDK.Utils;

namespace Riskified.SDK.Model.ChargebackElements
{
    public class DisputeDetails : IJsonSerializable
    {
        public DisputeDetails(
            string caseId = null,
            string status = null,
            DateTime? disputedAt = null,
            DateTime? expectedResolutionDate = null,
            string disputeType = null,
            string issuerPocPhoneNumber = null)
        {
            CaseId = caseId;
            Status = status;
            DisputedAt = disputedAt;
            ExpectedResolutionDate = expectedResolutionDate;
            DisputeType = disputeType;
            IssuerPocPhoneNumber = issuerPocPhoneNumber;
        }

        /// <summary>
        ///     Dispute identifier as defined by the issuer/gateway
        /// </summary>
        [JsonProperty(PropertyName = "case_id")]
        public string CaseId { get; set; }

        /// <summary>
        ///     One of the following:
        ///     candidate
        ///     ineligible
        ///     pending
        ///     won
        ///     lost
        ///     Note: we expect to update the api when the dispute status changes
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        ///     When was the dispute sent
        /// </summary>
        [JsonProperty(PropertyName = "disputed_at")]
        public DateTime? DisputedAt { get; set; }

        /// <summary>
        ///     When should we expect a decision from the issuer (60-75 days usually)
        /// </summary>
        [JsonProperty(PropertyName = "expected_resolution_date")]
        public DateTime? ExpectedResolutionDate { get; set; }

        /// <summary>
        ///     One of the following:
        ///     first_dispute
        ///     second_dispute
        ///     arbitrary_court
        ///     Note: we expect to update the api when the dispute status changes
        /// </summary>
        [JsonProperty(PropertyName = "dispute_type")]
        public string DisputeType { get; set; }

        /// <summary>
        ///     Credit card issuer or gateway provider phone number
        /// </summary>
        [JsonProperty(PropertyName = "issuer_poc_phone_number")]
        public string IssuerPocPhoneNumber { get; set; }

        public void Validate(Validations validationType = Validations.Weak)
        {
        }
    }
}
