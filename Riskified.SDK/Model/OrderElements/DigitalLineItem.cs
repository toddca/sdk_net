// // -----------------------------------------------------------------------
// // <copyright from="2019" to="2019" file="DigitalLineItem.cs" company="Lindell Technologies">
// //    Copyright (c) Lindell Technologies All Rights Reserved.
// //    Information Contained Herein is Proprietary and Confidential.
// // </copyright>
// // -----------------------------------------------------------------------

using System;
using Newtonsoft.Json;

namespace Riskified.SDK.Model.OrderElements
{
    public class DigitalLineItem : LineItem
    {
        public DigitalLineItem(
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

            // gift card specific
            string senderName = null,
            string displayName = null,
            bool? photoUploaded = null,
            string photoUrl = null,
            string greetingPhotoUrl = null,
            string message = null,
            string greetingMessage = null,
            string cardType = null,
            string cardSubType = null,
            string senderEmail = null,
            Recipient recipient = null
        ) : base(
                 title, price, quantityPurchased, productId, sku,
                 condition,
                 requiresShipping, seller, deliveredTo, deliveredAt,
                 category: category, subCategory: subCategory, brand: brand,
                 productType: OrderElements.ProductType.Digital)
        {
            SenderName = senderName;
            DisplayName = displayName;
            PhotoUploaded = photoUploaded;
            PhotoUrl = photoUrl;
            GreetingPhotoUrl = greetingPhotoUrl;
            Message = message;
            GreetingMessage = greetingMessage;
            CardType = cardType;
            CardSubtype = cardSubType;
            SenderEmail = senderEmail;
            Recipient = recipient;
        }

        /// <summary>
        ///     The digital good's (gift card) sender name.
        /// </summary>
        [JsonProperty(PropertyName = "sender_name")]
        public string SenderName { get; set; }

        /// <summary>
        ///     The digital good's (gift card) sender email.
        /// </summary>
        [JsonProperty(PropertyName = "sender_email")]
        public string SenderEmail { get; set; }

        /// <summary>
        ///     The digital good's (gift card) display name.
        /// </summary>
        [JsonProperty(PropertyName = "display_name")]
        public string DisplayName { get; set; }

        /// <summary>
        ///     Is the gift card sender added a photo.
        /// </summary>
        [JsonProperty(PropertyName = "photo_uploaded")]
        public bool? PhotoUploaded { get; set; }

        /// <summary>
        ///     The digital good's (gift card) sender photo's url.
        /// </summary>
        [JsonProperty(PropertyName = "photo_url")]
        public string PhotoUrl { get; set; }

        /// <summary>
        ///     The digital good's (gift card) greeting's photo url.
        /// </summary>
        [JsonProperty(PropertyName = "greeting_photo_url")]
        public string GreetingPhotoUrl { get; set; }

        /// <summary>
        ///     The digital good's (gift card) message.
        /// </summary>
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        /// <summary>
        ///     The digital good's (gift card) greeting message.
        /// </summary>
        [JsonProperty(PropertyName = "greeting_message")]
        public string GreetingMessage { get; set; }

        /// <summary>
        ///     The digital good's (gift card) type.
        /// </summary>
        [JsonProperty(PropertyName = "card_type")]
        public string CardType { get; set; }

        /// <summary>
        ///     The digital good's (gift card) sub type.
        /// </summary>
        [JsonProperty(PropertyName = "card_subtype")]
        public string CardSubtype { get; set; }

        [JsonProperty(PropertyName = "recipient")]
        public Recipient Recipient { get; set; }
    }
}
