// // -----------------------------------------------------------------------
// // <copyright from="2019" to="2019" file="OrderNotification.cs" company="Lindell Technologies">
// //    Copyright (c) Lindell Technologies All Rights Reserved.
// //    Information Contained Herein is Proprietary and Confidential.
// // </copyright>
// // -----------------------------------------------------------------------

using Riskified.SDK.Model.Internal;
using Riskified.SDK.Model.OrderElements;

namespace Riskified.SDK.Model
{
    public class OrderNotification
    {
        internal OrderNotification(OrderWrapper<Notification> notificationInfo)
        {
            Id = notificationInfo.Order.Id;
            Status = notificationInfo.Order.Status;
            OldStatus = notificationInfo.Order.OldStatus;
            Description = notificationInfo.Order.Description;
            Custom = notificationInfo.Order.Custom;
            Category = notificationInfo.Order.Category;
            DecisionCode = notificationInfo.Order.DecisionCode;
            Warnings = notificationInfo.Warnings;
        }

        internal OrderNotification(OrderCheckoutWrapper<Notification> notificationInfo)
        {
            Id = notificationInfo.Order.Id;
            Status = notificationInfo.Order.Status;
            OldStatus = notificationInfo.Order.OldStatus;
            Description = notificationInfo.Order.Description;
            Custom = notificationInfo.Order.Custom;
            Category = notificationInfo.Order.Category;
            Warnings = notificationInfo.Warnings;
        }

        public string Id { get; }
        public string Status { get; }
        public string OldStatus { get; }
        public string Description { get; }
        public Custom Custom { get; }
        public string Category { get; }
        public string DecisionCode { get; }
        public string[] Warnings { get; }
    }
}
