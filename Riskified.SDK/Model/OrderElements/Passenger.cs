// // -----------------------------------------------------------------------
// // <copyright from="2019" to="2019" file="Passenger.cs" company="Lindell Technologies">
// //    Copyright (c) Lindell Technologies All Rights Reserved.
// //    Information Contained Herein is Proprietary and Confidential.
// // </copyright>
// // -----------------------------------------------------------------------

using System;
using Newtonsoft.Json;
using Riskified.SDK.Utils;

namespace Riskified.SDK.Model.OrderElements
{
    [JsonObject("passenger")]
    public class Passenger : IJsonSerializable
    {
        /// <summary>
        ///     The Passenger
        /// </summary>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <param name="dateOfBirth"></param>
        /// <param name="nationalityCode"></param>
        /// <param name="insurancePrice"></param>
        /// <param name="documentNumber"></param>
        /// <param name="documentType"></param>
        /// <param name="documentIssueDate"></param>
        /// <param name="documentExpirationDate"></param>
        /// <param name="passengerType"></param>
        /// <param name="insuranceType"></param>
        public Passenger(
            string firstname, string lastname, DateTime dateOfBirth, string nationalityCode,
            float? insurancePrice, string documentNumber, string documentType, DateTime? documentIssueDate,
            DateTime? documentExpirationDate, string passengerType = null, string insuranceType = null)
        {
            Firstname = firstname;
            Lastname = lastname;
            DateOfBirth = dateOfBirth;
            NationalityCode = nationalityCode;
            InsuranceType = insuranceType;
            InsurancePrice = insurancePrice;
            DocumentNumber = documentNumber;
            DocumentType = documentType;
            DocumentIssueDate = documentIssueDate;
            DocumentExpirationDate = documentExpirationDate;
            PassengerType = passengerType;
        }

        [JsonProperty(PropertyName = "first_name")]
        public string Firstname { get; set; }

        [JsonProperty(PropertyName = "last_name")]
        public string Lastname { get; set; }

        [JsonProperty(PropertyName = "date_of_birth")]
        public DateTime? DateOfBirth { get; set; }

        [JsonProperty(PropertyName = "nationality_code")]
        public string NationalityCode { get; set; }

        [JsonProperty(PropertyName = "insurance_type")]
        public string InsuranceType { get; set; }

        [JsonProperty(PropertyName = "insurance_price")]
        public float? InsurancePrice { get; set; }

        [JsonProperty(PropertyName = "document_number")]
        public string DocumentNumber { get; set; }

        [JsonProperty(PropertyName = "document_type")]
        public string DocumentType { get; set; }

        [JsonProperty(PropertyName = "document_issue_date")]
        public DateTime? DocumentIssueDate { get; set; }

        [JsonProperty(PropertyName = "document_expiration_date")]
        public DateTime? DocumentExpirationDate { get; set; }

        [JsonProperty(PropertyName = "passenger_type")]
        public string PassengerType { get; set; }

        /// <summary>
        ///     Validates the objects fields content
        /// </summary>
        /// <param name="validationType">Should use weak validations or strong</param>
        public void Validate(Validations validationType = Validations.Weak)
        {
            //TODO: add validations
        }
    }
}
