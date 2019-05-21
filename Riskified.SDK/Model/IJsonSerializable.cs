// // -----------------------------------------------------------------------
// // <copyright from="2019" to="2019" file="IJsonSerializable.cs" company="Lindell Technologies">
// //    Copyright (c) Lindell Technologies All Rights Reserved.
// //    Information Contained Herein is Proprietary and Confidential.
// // </copyright>
// // -----------------------------------------------------------------------

using Riskified.SDK.Exceptions;
using Riskified.SDK.Utils;

namespace Riskified.SDK.Model
{
    public interface IJsonSerializable
    {
        /// <summary>
        ///     Validates the objects fields content
        /// </summary>
        /// <param name="validationType">The level of validation to apply on the object properties</param>
        /// <exception cref="OrderFieldBadFormatException">
        ///     throws an exception if one of the parameters doesn't match the expected
        ///     format
        /// </exception>
        void Validate(Validations validationType = Validations.Weak);
    }
}
