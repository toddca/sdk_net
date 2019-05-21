// // -----------------------------------------------------------------------
// // <copyright from="2019" to="2019" file="AccommodationLineItem.cs" company="Lindell Technologies">
// //    Copyright (c) Lindell Technologies All Rights Reserved.
// //    Information Contained Herein is Proprietary and Confidential.
// // </copyright>
// // -----------------------------------------------------------------------

using System;
using Newtonsoft.Json;
using Riskified.SDK.Utils;

namespace Riskified.SDK.Model.OrderElements
{
    public class AccommodationLineItem : LineItem
    {
        public AccommodationLineItem(
            // inherited
            string title,
            double price,
            int quantityPurchased,
            string productId = null,
            string sku = null,
            string condition = null,
            bool? requiresShipping = null,
            string category = null,
            string subCategory = null,
            string brand = null,
            Seller seller = null,
            DeliveredToType? deliveredTo = null,
            DateTime? deliveredAt = null,
            // accommodation specific
            string roomType = null,
            string city = null,
            string countryCode = null,
            DateTime? checkInDate = null,
            DateTime? checkOutTime = null,
            string rating = null,
            ushort? numberOfGuests = null,
            string cancellationPolicy = null,
            string accommodationType = null
        ) : base(title, price, quantityPurchased, productId, sku, condition,
                 requiresShipping, seller, deliveredTo, deliveredAt,
                 category: category, subCategory: subCategory, brand: brand, productType: OrderElements.ProductType.Accommodation)
        {
            RoomType = roomType;
            City = city;
            CountryCode = countryCode;
            CheckInDate = checkInDate;
            CheckOutTime = checkOutTime;
            Rating = rating;
            NumberOfGuests = numberOfGuests;
            CancellationPolicy = cancellationPolicy;
            AccommodationType = accommodationType;
        }

        [JsonProperty(PropertyName = "room_type")]
        public string RoomType { get; set; }

        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }

        [JsonProperty(PropertyName = "country_code")]
        public string CountryCode { get; set; }

        [JsonProperty(PropertyName = "check_in_date")]
        public DateTime? CheckInDate { get; set; }

        [JsonProperty(PropertyName = "check_out_date")]
        public DateTime? CheckOutTime { get; set; }

        [JsonProperty(PropertyName = "rating")]
        public string Rating { get; set; }

        [JsonProperty(PropertyName = "number_of_guests")]
        public ushort? NumberOfGuests { get; set; }

        [JsonProperty(PropertyName = "cancellation_policy")]
        public string CancellationPolicy { get; set; }

        [JsonProperty(PropertyName = "accommodation_type")]
        public string AccommodationType { get; set; }

        public override void Validate(Validations validationType = Validations.Weak)
        {
            base.Validate(validationType);

            if (CountryCode != null)
            {
                InputValidators.ValidateCountryOrProvinceCode(CountryCode);
            }
        }
    }
}
