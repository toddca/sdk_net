// // -----------------------------------------------------------------------
// // <copyright from="2019" to="2019" file="LoginStatus.cs" company="Lindell Technologies">
// //    Copyright (c) Lindell Technologies All Rights Reserved.
// //    Information Contained Herein is Proprietary and Confidential.
// // </copyright>
// // -----------------------------------------------------------------------

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Riskified.SDK.Model.OrderElements
{
    public class LoginStatus
    {
        public LoginStatus(LoginStatusType loginStatusType)
        {
            LoginStatusType = loginStatusType;
        }

        [JsonProperty(PropertyName = "login_status_type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public LoginStatusType LoginStatusType { get; set; }

        [JsonProperty(PropertyName = "failure_reason")]
        [JsonConverter(typeof(StringEnumConverter))]
        public FailureReason? FailureReason { get; set; }
    }
}
