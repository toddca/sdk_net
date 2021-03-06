﻿// // -----------------------------------------------------------------------
// // <copyright from="2019" to="2019" file="Customer.cs" company="Lindell Technologies">
// //    Copyright (c) Lindell Technologies All Rights Reserved.
// //    Information Contained Herein is Proprietary and Confidential.
// // </copyright>
// // -----------------------------------------------------------------------

using System;
using System.Linq;
using Newtonsoft.Json;
using Riskified.SDK.Exceptions;
using Riskified.SDK.Utils;

namespace Riskified.SDK.Model.OrderElements
{
    [JsonObject("customer")]
    public class Customer : IJsonSerializable
    {
        /// <summary>
        ///     Creates a new Customer
        /// </summary>
        /// <param name="firstName">The customer first name</param>
        /// <param name="lastName">The customer last name</param>
        /// <param name="id">The customer id (optional)</param>
        /// <param name="ordersCount">The total number of orders made to the merchant by this customer (optional)</param>
        /// <param name="email">The customer email - as registered with (optional) </param>
        /// <param name="verifiedEmail">Signs if the email was verified by the merchant is some way (optional)</param>
        /// <param name="createdAt">The time of creation of the customer card (optional)</param>
        /// <param name="notes">Additional notes regarding the customer (optional)</param>
        /// <param name="social"></param>
        /// <param name="address"></param>
        /// <param name="accountType"></param>
        public Customer(
            string firstName, string lastName, string id, int? ordersCount = null, string email = null, bool? verifiedEmail = null, DateTime? createdAt = null,
            string notes = null, SocialDetails[] social = null, BasicAddress address = null, string accountType = null)
        {
            FirstName = firstName;
            LastName = lastName;

            // optional fields
            Id = id;
            Email = email;
            OrdersCount = ordersCount;
            VerifiedEmail = verifiedEmail;
            CreatedAt = createdAt;
            Note = notes;
            Social = social;
            Address = address;
            AccountType = accountType;
        }

        [JsonProperty(PropertyName = "created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "first_name")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "last_name")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "note")]
        public string Note { get; set; }

        [JsonProperty(PropertyName = "orders_count")]
        public int? OrdersCount { get; set; }

        [JsonProperty(PropertyName = "verified_email")]
        public bool? VerifiedEmail { get; set; }

        [JsonProperty(PropertyName = "social")]
        public SocialDetails[] Social { get; set; }

        [JsonProperty(PropertyName = "buyer_anonymous_id")]
        public string AnonymousId { get; set; }

        [JsonProperty(PropertyName = "address")]
        public BasicAddress Address { get; set; }

        [JsonProperty(PropertyName = "account_type")]
        public string AccountType { get; set; }

        /// <summary>
        ///     Validates the objects fields content
        /// </summary>
        /// <param name="validationType">Validation level to use on this Model</param>
        /// <exception cref="OrderFieldBadFormatException">
        ///     throws an exception if one of the parameters doesn't match the expected
        ///     format
        /// </exception>
        public void Validate(Validations validationType = Validations.Weak)
        {
            if (validationType == Validations.Weak)
            {
                if (string.IsNullOrEmpty(FirstName) && string.IsNullOrEmpty(LastName))
                {
                    throw new OrderFieldBadFormatException("Both First name and last name are missing or empty - at least one should be specified");
                }
            }
            else
            {
                InputValidators.ValidateValuedString(FirstName, "First Name");
                InputValidators.ValidateValuedString(LastName, "Last Name");
            }

            // optional fields validations
            if (!string.IsNullOrEmpty(Email))
            {
                InputValidators.ValidateEmail(Email);
            }
            if (OrdersCount.HasValue)
            {
                InputValidators.ValidateZeroOrPositiveValue(OrdersCount.Value, "Orders Count");
            }
            if (CreatedAt.HasValue)
            {
                InputValidators.ValidateDateNotDefault(CreatedAt.Value, "Created At");
            }
            Social?.ToList().ForEach(item => item.Validate(validationType));
            Address?.Validate(validationType);
        }
    }
}
