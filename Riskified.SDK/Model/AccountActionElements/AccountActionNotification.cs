// // -----------------------------------------------------------------------
// // <copyright from="2019" to="2019" file="AccountActionNotification.cs" company="Lindell Technologies">
// //    Copyright (c) Lindell Technologies All Rights Reserved.
// //    Information Contained Herein is Proprietary and Confidential.
// // </copyright>
// // -----------------------------------------------------------------------

using Newtonsoft.Json;

namespace Riskified.SDK.Model.AccountActionElements
{
    public class AccountActionNotification
    {
        [JsonProperty(PropertyName = "decision", Required = Required.Always)]
        public string Decision { get; set; }
    }
}
