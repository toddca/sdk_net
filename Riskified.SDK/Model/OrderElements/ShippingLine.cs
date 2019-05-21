// // -----------------------------------------------------------------------
// // <copyright from="2019" to="2019" file="ShippingLine.cs" company="Lindell Technologies">
// //    Copyright (c) Lindell Technologies All Rights Reserved.
// //    Information Contained Herein is Proprietary and Confidential.
// // </copyright>
// // -----------------------------------------------------------------------

using Newtonsoft.Json;
using Riskified.SDK.Utils;

namespace Riskified.SDK.Model.OrderElements
{
    public class ShippingLine : IJsonSerializable
    {
        /// <summary>
        ///     The shipping line (shipping method)
        /// </summary>
        /// <param name="price">The price of this shipping method</param>
        /// <param name="title">A human readable name for the shipping method</param>
        /// <param name="code">A code to the shipping method</param>
        public ShippingLine(double price, string title, string code = null)
        {
            Price = price;
            Title = title;
            // optional
            Code = code;
        }

        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }

        [JsonProperty(PropertyName = "price")]
        public double? Price { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        /// <summary>
        ///     Validates the objects fields content
        /// </summary>
        /// <param name="validationType">Should use weak validations or strong</param>
        /// <exception cref="Exceptions.OrderFieldBadFormatException">
        ///     throws an exception if one of the parameters doesn't match the expected
        ///     format
        /// </exception>
        public void Validate(Validations validationType = Validations.Weak)
        {
            InputValidators.ValidateZeroOrPositiveValue(Price.GetValueOrDefault(), "Price");
            InputValidators.ValidateValuedString(Title, "Title");
        }
    }
}
