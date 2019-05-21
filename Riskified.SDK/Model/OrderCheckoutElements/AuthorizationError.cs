// // -----------------------------------------------------------------------
// // <copyright from="2019" to="2019" file="AuthorizationError.cs" company="Lindell Technologies">
// //    Copyright (c) Lindell Technologies All Rights Reserved.
// //    Information Contained Herein is Proprietary and Confidential.
// // </copyright>
// // -----------------------------------------------------------------------

using System;
using Newtonsoft.Json;
using Riskified.SDK.Utils;

namespace Riskified.SDK.Model.OrderCheckoutElements
{
    public class AuthorizationError : IJsonSerializable
    {
        public AuthorizationError(DateTime createdAt, string errorCode, string message = null)
        {
            CreatedAt = createdAt;
            ErrorCode = errorCode;

            // optional field
            Message = message;
        }


        [JsonProperty(PropertyName = "created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty(PropertyName = "error_code")]
        public string ErrorCode { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        public void Validate(Validations validationType = Validations.Weak)
        {
            InputValidators.ValidateValuedString(ErrorCode, "Error Code");

            // optional fields validations
            if (Message != null)
            {
                InputValidators.ValidateValuedString(Message, "Message");
            }
        }
    }
}
