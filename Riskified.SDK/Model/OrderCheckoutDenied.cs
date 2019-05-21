// // -----------------------------------------------------------------------
// // <copyright from="2019" to="2019" file="OrderCheckoutDenied.cs" company="Lindell Technologies">
// //    Copyright (c) Lindell Technologies All Rights Reserved.
// //    Information Contained Herein is Proprietary and Confidential.
// // </copyright>
// // -----------------------------------------------------------------------

using Newtonsoft.Json;
using Riskified.SDK.Model.OrderCheckoutElements;

namespace Riskified.SDK.Model
{
    public class OrderCheckoutDenied : OrderBase
    {
        /// <summary>
        ///     @Deprecated - Create a checkout denied (deprecated constructor, please use PaymentDetails.AuthorizationError)
        /// </summary>
        /// <param name="merchantOrderId">The unique id of the order at the merchant systems</param>
        /// <param name="authorizationError">
        ///     An object describing the failed result of an authorization attempt by a payment
        ///     gateway
        /// </param>
        public OrderCheckoutDenied(string merchantOrderId, AuthorizationError authorizationError)
            : base(merchantOrderId)
        {
            AuthorizationError = authorizationError;
        }

        /// <summary>
        ///     Create a checkout denied
        /// </summary>
        /// <param name="merchantOrderId">The unique id of the order at the merchant systems</param>
        public OrderCheckoutDenied(string merchantOrderId)
            : base(merchantOrderId)
        {
        }

        /// <summary>
        ///     @Deprecated property, please use PaymentDetails.AuthorizationError
        /// </summary>
        [JsonProperty(PropertyName = "authorization_error")]
        public AuthorizationError AuthorizationError { get; set; }
    }
}
