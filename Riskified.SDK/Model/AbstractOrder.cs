// // -----------------------------------------------------------------------
// // <copyright from="2019" to="2019" file="AbstractOrder.cs" company="Lindell Technologies">
// //    Copyright (c) Lindell Technologies All Rights Reserved.
// //    Information Contained Herein is Proprietary and Confidential.
// // </copyright>
// // -----------------------------------------------------------------------

using Newtonsoft.Json;
using Riskified.SDK.Utils;

namespace Riskified.SDK.Model
{
    public abstract class AbstractOrder : IJsonSerializable
    {
        /// <summary>
        ///     @Deprecated - old - replaced by string ctor with order id other than int
        /// </summary>
        protected AbstractOrder(int merchantOrderId)
        {
            Id = merchantOrderId.ToString();
        }

        protected AbstractOrder(string merchantOrderId)
        {
            InputValidators.ValidateValuedString(merchantOrderId, "Merchant Order ID");
            Id = merchantOrderId;
        }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        public virtual void Validate(Validations validationType = Validations.Weak)
        {
            InputValidators.ValidateValuedString(Id, "Merchant Order ID");
        }
    }
}
