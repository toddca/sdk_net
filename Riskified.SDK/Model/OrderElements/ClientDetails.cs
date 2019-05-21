// // -----------------------------------------------------------------------
// // <copyright from="2019" to="2019" file="ClientDetails.cs" company="Lindell Technologies">
// //    Copyright (c) Lindell Technologies All Rights Reserved.
// //    Information Contained Herein is Proprietary and Confidential.
// // </copyright>
// // -----------------------------------------------------------------------

using Newtonsoft.Json;
using Riskified.SDK.Utils;

namespace Riskified.SDK.Model.OrderElements
{
    public class ClientDetails : IJsonSerializable
    {
        /// <summary>
        ///     Technical information regarding the customer's browsing session
        /// </summary>
        /// <param name="acceptLanguage">List of two-letter language codes sent from the client</param>
        /// <param name="userAgent">The full User-Agent sent from the client</param>
        public ClientDetails(
            string acceptLanguage = null,
            string userAgent = null)
        {
            AcceptLanguage = acceptLanguage;
            UserAgent = userAgent;
        }

        [JsonProperty(PropertyName = "accept_language")]
        public string AcceptLanguage { get; set; }

        [JsonProperty(PropertyName = "user_agent")]
        public string UserAgent { get; set; }

        public void Validate(Validations validationType = Validations.Weak)
        {
        }
    }
}
