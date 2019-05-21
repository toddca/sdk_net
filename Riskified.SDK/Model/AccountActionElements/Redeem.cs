// // -----------------------------------------------------------------------
// // <copyright from="2019" to="2019" file="Redeem.cs" company="Lindell Technologies">
// //    Copyright (c) Lindell Technologies All Rights Reserved.
// //    Information Contained Herein is Proprietary and Confidential.
// // </copyright>
// // -----------------------------------------------------------------------

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Riskified.SDK.Model.OrderElements;

namespace Riskified.SDK.Model.AccountActionElements
{
    public class Redeem : AbstractAccountAction
    {
        public Redeem(string customerId, RedeemType redeemType, ClientDetails clientDetails, SessionDetails sessionDetails) :
            base(customerId, clientDetails, sessionDetails)
        {
            RedeemType = redeemType;
        }

        [JsonProperty(PropertyName = "redeem_type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public RedeemType RedeemType { get; set; }
    }
}
