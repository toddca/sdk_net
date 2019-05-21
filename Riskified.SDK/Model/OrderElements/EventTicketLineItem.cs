// // -----------------------------------------------------------------------
// // <copyright from="2019" to="2019" file="EventTicketLineItem.cs" company="Lindell Technologies">
// //    Copyright (c) Lindell Technologies All Rights Reserved.
// //    Information Contained Herein is Proprietary and Confidential.
// // </copyright>
// // -----------------------------------------------------------------------

using System;
using Newtonsoft.Json;

namespace Riskified.SDK.Model.OrderElements
{
    public class EventTicketLineItem : LineItem
    {
        public EventTicketLineItem(
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
            // event ticket specific
            string eventName = null,
            string eventSectionName = null,
            DateTime? eventDate = null,
            string eventCity = null,
            string eventCountryCode = null,
            float? latitude = null,
            float? longitude = null
        ) : base(
                 title, price, quantityPurchased, productId, sku,
                 condition,
                 requiresShipping, seller, deliveredTo, deliveredAt,
                 category: category, subCategory: subCategory, brand: brand,
                 productType: OrderElements.ProductType.EventTicket)
        {
            EventName = eventName;
            EventSectionName = eventSectionName;
            EventDate = eventDate;
            EventCountryCode = eventCountryCode;
            EventCity = eventCity;
            Latitude = latitude;
            Longitude = longitude;
        }

        /// <summary>
        ///     The event name.
        /// </summary>
        [JsonProperty(PropertyName = "event_name")]
        public string EventName { get; set; }

        /// <summary>
        ///     The event section name.
        /// </summary>
        [JsonProperty(PropertyName = "event_section_name")]
        public string EventSectionName { get; set; }

        /// <summary>
        ///     The country code where the event is taking place.
        /// </summary>
        [JsonProperty(PropertyName = "event_country_code")]
        public string EventCountryCode { get; set; }

        /// <summary>
        ///     The city where the event is taking place.
        /// </summary>
        [JsonProperty(PropertyName = "event_city")]
        public string EventCity { get; set; }

        /// <summary>
        ///     The event date.
        /// </summary>
        [JsonProperty(PropertyName = "event_date")]
        public DateTime? EventDate { get; set; }

        /// <summary>
        ///     Latitude coordinate of the event's location
        /// </summary>
        [JsonProperty(PropertyName = "latitude")]
        public float? Latitude { get; set; }

        /// <summary>
        ///     Longitude coordinate of the event's location
        /// </summary>
        [JsonProperty(PropertyName = "longitude")]
        public float? Longitude { get; set; }

    }
}
