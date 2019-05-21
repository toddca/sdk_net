// // -----------------------------------------------------------------------
// // <copyright from="2019" to="2019" file="BaseCustomerAction.cs" company="Lindell Technologies">
// //    Copyright (c) Lindell Technologies All Rights Reserved.
// //    Information Contained Herein is Proprietary and Confidential.
// // </copyright>
// // -----------------------------------------------------------------------

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Riskified.SDK.Model.OrderElements;

namespace Riskified.SDK.Model.AccountActionElements
{
    public class BaseCustomerAction : AbstractAccountAction
    {
        public BaseCustomerAction(string customerId, ClientDetails clientDetails, SessionDetails sessionDetails, Customer customer) :
            base(customerId, clientDetails, sessionDetails)
        {
            Customer = customer;
        }

        [JsonProperty(PropertyName = "phone_mandatory")]
        public bool? PhoneMandatory { get; set; }

        [JsonProperty(PropertyName = "referrer_customer_id")]
        public string ReferrerCustomerId { get; set; }

        [JsonProperty(PropertyName = "social_signup_type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public SocialType SocialSignupType { get; set; }

        [JsonProperty(PropertyName = "customer")]
        public Customer Customer { get; set; }

        [JsonProperty(PropertyName = "payment_details")]
        public IPaymentDetails[] PaymentDetails { get; set; }

        [JsonProperty(PropertyName = "billing_address")]
        public AddressInformation[] BillingAddress { get; set; }

        [JsonProperty(PropertyName = "shipping_address")]
        public AddressInformation[] ShippingAddress { get; set; }
    }
}
