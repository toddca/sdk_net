// // -----------------------------------------------------------------------
// // <copyright from="2019" to="2019" file="ChargebackDetails.cs" company="Lindell Technologies">
// //    Copyright (c) Lindell Technologies All Rights Reserved.
// //    Information Contained Herein is Proprietary and Confidential.
// // </copyright>
// // -----------------------------------------------------------------------

using System;
using Newtonsoft.Json;
using Riskified.SDK.Utils;

namespace Riskified.SDK.Model.ChargebackElements
{
    public class ChargebackDetails : IJsonSerializable
    {
        public ChargebackDetails(
            string id = null,
            DateTime? chargebackAt = null,
            string chargebackCurrency = null,
            float? chargebackAmount = null,
            string reasonCode = null,
            string reasonDesc = null,
            string type = null,
            string mid = null,
            string arn = null,
            string creditCardCompany = null,
            DateTime? respondBy = null,
            float? feeAmount = null,
            string feeCurrency = null,
            string cardIssuer = null,
            string gateway = null,
            string cardholder = null,
            string message = null)
        {
            Id = id;
            ChargebackAt = chargebackAt;
            ChargebackCurrency = chargebackCurrency;
            ChargebackAmount = chargebackAmount;
            ReasonCode = reasonCode;
            ReasonDescription = reasonDesc;
            Type = type;
            Mid = mid;
            Arn = arn;
            CreditCardCompany = creditCardCompany;
            RespondBy = respondBy;
            FeeAmount = feeAmount;
            FeeCurrency = feeCurrency;
            CardIssuer = cardIssuer;
            Gateway = gateway;
            Cardholder = cardholder;
            Message = message;
        }

        /// <summary>
        ///     The chargeback notice id (if applicable).
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        ///     The chargeback date, as received from the acquirer.
        /// </summary>
        [JsonProperty(PropertyName = "chargeback_at")]
        public DateTime? ChargebackAt { get; set; }

        /// <summary>
        ///     The chargeback currency, ISO 4217.
        /// </summary>
        [JsonProperty(PropertyName = "chargeback_currency")]
        public string ChargebackCurrency { get; set; }

        /// <summary>
        ///     The chargeback amount as stated in the chargeback notice.
        /// </summary>
        [JsonProperty(PropertyName = "chargeback_amount")]
        public float? ChargebackAmount { get; set; }

        /// <summary>
        ///     The chargeback reason code, as received from the acquirer.
        /// </summary>
        [JsonProperty(PropertyName = "reason_code")]
        public string ReasonCode { get; set; }

        /// <summary>
        ///     The chargeback reason description, as received from the acquirer.
        /// </summary>
        [JsonProperty(PropertyName = "reason_description")]
        public string ReasonDescription { get; set; }

        /// <summary>
        ///     The chargeback transaction type, as received from the acquirer
        ///     rfi - Request for Information.
        ///     cb - Notification of Chargeback.
        ///     cb2 - Second Chargeback.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        ///     The merchant account id at the payment gateway
        /// </summary>
        [JsonProperty(PropertyName = "mid")]
        public string Mid { get; set; }

        /// <summary>
        ///     Acquirer Reference Number (ARN) A unique number that tags a credit card transaction when it goes from the
        ///     merchant's bank (the acquiring bank) through the card scheme to the card holder's bank (the issuer).
        /// </summary>
        [JsonProperty(PropertyName = "arn")]
        public string Arn { get; set; }

        /// <summary>
        ///     Credit card brand: VISA, Mastercard, AMEX, JCB, etc.
        /// </summary>
        [JsonProperty(PropertyName = "credit_card_company")]
        public string CreditCardCompany { get; set; }

        /// <summary>
        ///     Last date to challenge CHB
        /// </summary>
        [JsonProperty(PropertyName = "respond_by")]
        public DateTime? RespondBy { get; set; }

        /// <summary>
        ///     The chargeback fee amount
        /// </summary>
        [JsonProperty(PropertyName = "fee_amount")]
        public float? FeeAmount { get; set; }

        /// <summary>
        ///     The chargeback fee currency
        /// </summary>
        [JsonProperty(PropertyName = "fee_currency")]
        public string FeeCurrency { get; set; }

        /// <summary>
        ///     The card issuer
        /// </summary>
        [JsonProperty(PropertyName = "card_issuer")]
        public string CardIssuer { get; set; }

        /// <summary>
        ///     The payment gateway who processed the order
        /// </summary>
        [JsonProperty(PropertyName = "gateway")]
        public string Gateway { get; set; }

        /// <summary>
        ///     The identifier of the person who submitted the CHB, as it appears on the chargeback notice
        /// </summary>
        [JsonProperty(PropertyName = "cardholder")]
        public string Cardholder { get; set; }

        /// <summary>
        ///     Optional issuer message
        /// </summary>
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        public void Validate(Validations validationType = Validations.Weak)
        {
        }
    }
}
