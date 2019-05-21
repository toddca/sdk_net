﻿// // -----------------------------------------------------------------------
// // <copyright from="2019" to="2019" file="OrderDecision.cs" company="Lindell Technologies">
// //    Copyright (c) Lindell Technologies All Rights Reserved.
// //    Information Contained Herein is Proprietary and Confidential.
// // </copyright>
// // -----------------------------------------------------------------------

using Newtonsoft.Json;
using Riskified.SDK.Exceptions;
using Riskified.SDK.Model.OrderElements;
using Riskified.SDK.Utils;

namespace Riskified.SDK.Model
{
    public class OrderDecision : AbstractOrder
    {
        public OrderDecision(int merchantOrderId, DecisionDetails decision)
            : base(merchantOrderId)
        {
            Decision = decision;
        }

        public OrderDecision(string merchantOrderId, DecisionDetails decision)
            : base(merchantOrderId)
        {
            Decision = decision;
        }

        /// <summary>
        ///     An object containing information about the decision the merchant made on the order.
        /// </summary>
        [JsonProperty(PropertyName = "decision")]
        public DecisionDetails Decision { get; set; }

        /// <summary>
        ///     Validates the objects fields content
        /// </summary>
        /// <param name="validationType">Validation level of the model</param>
        /// <exception cref="OrderFieldBadFormatException">
        ///     throws an exception if one of the parameters doesn't match the expected
        ///     format
        /// </exception>
        public override void Validate(Validations validationType = Validations.Weak)
        {
            base.Validate(validationType);
            InputValidators.ValidateObjectNotNull(Decision, "Decision");
            Decision.Validate(validationType);
        }
    }
}
