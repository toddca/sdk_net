// // -----------------------------------------------------------------------
// // <copyright from="2019" to="2019" file="Recipient.cs" company="Lindell Technologies">
// //    Copyright (c) Lindell Technologies All Rights Reserved.
// //    Information Contained Herein is Proprietary and Confidential.
// // </copyright>
// // -----------------------------------------------------------------------

using Newtonsoft.Json;
using Riskified.SDK.Exceptions;
using Riskified.SDK.Utils;

namespace Riskified.SDK.Model.OrderElements
{
    [JsonObject("recipient")]
    public class Recipient : IJsonSerializable
    {
        /// <summary>
        ///     Creates a new Recipient, mainly for digital goods (e.g. gift cards) orders
        /// </summary>
        /// <param name="email">The recipient email</param>
        /// <param name="phone"></param>
        /// <param name="social"></param>
        public Recipient(string email = null, string phone = null, SocialDetails social = null)
        {
            Email = email;
            Social = social;
            Phone = phone;
        }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "phone")]
        public string Phone { get; set; }

        [JsonProperty(PropertyName = "social")]
        public SocialDetails Social { get; set; }

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
            // optional fields validations
            if (!string.IsNullOrEmpty(Email))
            {
                InputValidators.ValidateEmail(Email);
            }

            if (!string.IsNullOrEmpty(Phone))
            {
                InputValidators.ValidatePhoneNumber(Phone);
            }

            Social?.Validate(validationType);

            if (Social == null && string.IsNullOrEmpty(Email) && string.IsNullOrEmpty(Phone))
            {
                throw new OrderFieldBadFormatException("All recipient fields are missing - at least one should be specified");
            }
        }
    }
}
