// // -----------------------------------------------------------------------
// // <copyright from="2019" to="2019" file="DiscountCode.cs" company="Lindell Technologies">
// //    Copyright (c) Lindell Technologies All Rights Reserved.
// //    Information Contained Herein is Proprietary and Confidential.
// // </copyright>
// // -----------------------------------------------------------------------

using Newtonsoft.Json;
using Riskified.SDK.Utils;

namespace Riskified.SDK.Model.OrderElements
{
    public class DiscountCode : IJsonSerializable
    {
        /// <summary>
        ///     A discount code for one of the products in the order
        /// </summary>
        /// <param name="moneyDiscountSum">
        ///     The amount of money (in the currency specified in the order) that was discounted
        ///     (optional)
        /// </param>
        /// <param name="code">The discount code (optional) </param>
        public DiscountCode(double? moneyDiscountSum = null, string code = null)
        {
            MoneyDiscountSum = moneyDiscountSum;
            Code = code;
        }

        [JsonProperty(PropertyName = "amount")]
        public double? MoneyDiscountSum { get; set; }

        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }

        /// <summary>
        ///     Validates the objects fields content
        /// </summary>
        /// <param name="validationType"></param>
        public void Validate(Validations validationType = Validations.Weak)
        {
        }
    }
}
