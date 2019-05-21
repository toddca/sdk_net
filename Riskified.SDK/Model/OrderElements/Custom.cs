// // -----------------------------------------------------------------------
// // <copyright from="2019" to="2019" file="Custom.cs" company="Lindell Technologies">
// //    Copyright (c) Lindell Technologies All Rights Reserved.
// //    Information Contained Herein is Proprietary and Confidential.
// // </copyright>
// // -----------------------------------------------------------------------

using Newtonsoft.Json;
using Riskified.SDK.Utils;

namespace Riskified.SDK.Model.OrderElements
{
    public class Custom : IJsonSerializable
    {
        /// <summary>
        ///     Custom information attached to the order
        /// </summary>
        /// <param name="appDomId">Originating System</param>
        public Custom(string appDomId = null)
        {
            AppDomId = appDomId;
        }

        [JsonProperty(PropertyName = "app_dom_id")]
        public string AppDomId { get; set; }

        public void Validate(Validations validationType = Validations.Weak)
        {
        }
    }
}
