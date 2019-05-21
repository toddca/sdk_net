// // -----------------------------------------------------------------------
// // <copyright from="2019" to="2019" file="InputValidators.cs" company="Lindell Technologies">
// //    Copyright (c) Lindell Technologies All Rights Reserved.
// //    Information Contained Herein is Proprietary and Confidential.
// // </copyright>
// // -----------------------------------------------------------------------

using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using Riskified.SDK.Exceptions;

namespace Riskified.SDK.Utils
{
    internal static class InputValidators
    {
        private static bool IsInputFullMatchingRegex(string value, string regex)
        {
            if (value == null)
            {
                return false;
            }
            var r = new Regex(regex);

            return r.IsMatch(value);
        }

        public static void ValidateEmail(string email)
        {
            if (!IsInputFullMatchingRegex(email, @"^.+@.+\..+$"))
                //|| (!isWeak && !IsInputFullMatchingRegex(email, @"^([a-zA-Z0-9_\-\.\+\%]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})$")))
            {
                throw new OrderFieldBadFormatException($"Email field invalid. Was \"{email}\"");
            }
        }

        public static void ValidateIp(string ip)
        {
            AddressFamily[] validAddresses =
            {
                AddressFamily.InterNetwork, AddressFamily.InterNetworkV6
            };
            if (!IPAddress.TryParse(ip, out var address) || !validAddresses.Contains(address.AddressFamily))
            {
                throw new OrderFieldBadFormatException($"IP field invalid. Was \"{ip}\"");
            }
        }

        public static void ValidateCountryOrProvinceCode(string locationCode)
        {
            if (!IsInputFullMatchingRegex(locationCode, @"^[A-Za-z]{2}$"))
            {
                throw new OrderFieldBadFormatException($"Location Code field invalid. Should be exactly 2 letters. Value was \"{locationCode}\"");
            }
        }

        public static void ValidateAvsResultCode(string resultCode)
        {
            if (!IsInputFullMatchingRegex(resultCode, @"^[A-Za-z0-9 ]+$"))
            {
                throw new OrderFieldBadFormatException($"Avs result Code field invalid. Should contain only letters and digits. Value was \"{resultCode}\"");
            }
        }

        public static void ValidateCvvResultCode(string resultCode)
        {
            if (!IsInputFullMatchingRegex(resultCode, @"^[A-Za-z0-9 ]+$"))
            {
                throw new OrderFieldBadFormatException($"Cvv result Code field invalid. Should contain only letters and digits. Value was \"{resultCode}\"");
            }
        }

        public static void ValidateValuedString(string stringToValidate, string fieldName)
        {
            if (string.IsNullOrEmpty(stringToValidate))
            {
                throw new OrderFieldBadFormatException(fieldName + " can't be null or empty");
            }
        }

        public static void ValidatePhoneNumber(string phoneNumber)
        {
            if (!IsInputFullMatchingRegex(phoneNumber, @"^\+?[0-9][0-9\-]+[0-9]$"))
            {
                throw new
                    OrderFieldBadFormatException($"Phone number format incorrect. Can only contain digits 0 to 9, the symbol '+' at the beginning and the symbol '-' between digits. Value was \"{phoneNumber}\"");
            }
        }

        public static void ValidateZeroOrPositiveValue(double number, string fieldName)
        {
            if (number < 0)
            {
                throw new OrderFieldBadFormatException($"{fieldName} must be positive or zero. Value was \"{number}\"");
            }
        }

        public static void ValidateZeroOrPositiveValue(float number, string fieldName)
        {
            if (number < 0)
            {
                throw new OrderFieldBadFormatException($"{fieldName} must be positive or zero. Value was \"{number}\"");
            }
        }

        public static void ValidatePositiveValue(int number, string fieldName)
        {
            if (number <= 0)
            {
                throw new OrderFieldBadFormatException($"{fieldName} must be positive (greater than zero). Value was \"{number}\"");
            }
        }

        public static void ValidateObjectNotNull(object obj, string fieldName)
        {
            if (obj == null)
            {
                throw new OrderFieldBadFormatException($"{fieldName} can't be null.");
            }
        }

        public static void ValidateDateNotDefault(DateTime date, string fieldName)
        {
            if (date.Equals(DateTime.MinValue) || date.Equals(DateTime.MaxValue))
            {
                throw new OrderFieldBadFormatException($"{fieldName} date value must have a valid logical date (not default value).");
            }
        }

        public static void ValidateCurrency(string currency)
        {
            if (string.IsNullOrEmpty(currency) || currency.Length != 3 || !IsInputFullMatchingRegex(currency, "^[A-Za-z]{3}$"))
            {
                throw new OrderFieldBadFormatException("Currency must be a 3 letters code matching ISO 4217.");
            }
        }

        public static void ValidateCreditCard(string creditCardNumber)
        {
            if (!IsInputFullMatchingRegex(creditCardNumber, @"^[Xx\-0-9]*[0-9]{4}$"))
            {
                throw
                    new OrderFieldBadFormatException("Credit card number should end with 4 digits, with preceeding sequence of digits and symbols of 'X','x',-'");
            }
        }
    }
}
