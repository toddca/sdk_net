// // -----------------------------------------------------------------------
// // <copyright from="2019" to="2019" file="OrderTransmissionExample.cs" company="Lindell Technologies">
// //    Copyright (c) Lindell Technologies All Rights Reserved.
// //    Information Contained Herein is Proprietary and Confidential.
// // </copyright>
// // -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Riskified.SDK.Exceptions;
using Riskified.SDK.Model;
using Riskified.SDK.Model.AccountActionElements;
using Riskified.SDK.Model.ChargebackElements;
using Riskified.SDK.Model.OrderCheckoutElements;
using Riskified.SDK.Model.OrderElements;
using Riskified.SDK.Model.RefundElements;
using Riskified.SDK.Orders;
using Riskified.SDK.Utils;

namespace Riskified.SDK.Sample
{
    public static class OrderTransmissionExample
    {
        public static void SendOrdersToRiskifiedExample()
        {
            #region preprocessing and loading config

            var domain = ConfigurationManager.AppSettings["MerchantDomain"];
            var authToken = ConfigurationManager.AppSettings["MerchantAuthenticationToken"];
            var riskifiedEnv = (RiskifiedEnvironment) Enum.Parse(typeof(RiskifiedEnvironment), ConfigurationManager.AppSettings["RiskifiedEnvironment"]);

            // Generating a random starting order number
            // we need to send the order with a new order number in order to create it on riskified
            var rand = new Random();
            var orderNum = rand.Next(1000, 200000);

            // Make orderNum a string to use as customer id
            var idString = $"customerId_{orderNum.ToString()}";

            #endregion

            #region order object creation

            // generate a new order - the sample generates a fixed order with same details but different order number each time
            // see GenerateOrder for more info on how to create the Order objects
            var order = GenerateOrder(orderNum);

            #endregion

            #region sending data to riskified

            // read action from console
            const string Menu = "Commands:\n" +
                                "'p' for checkout\n" +
                                "'e' for checkout denied\n" +
                                "'c' for create\n" +
                                "'u' for update\n" +
                                "'s' for submit\n" +
                                "'d' for cancel\n" +
                                "'r' for partial refund\n" +
                                "'f' for fulfill\n" +
                                "'x' for decision\n" +
                                "'h' for historical sending\n" +
                                "'y' for chargeback submission\n" +
                                "'v' for decide (sync only)\n" +
                                "'l' for eligible for Deco payment \n" +
                                "'o' for opt-in to Deco payment \n" +
                                "'account' for account actions menu\n" +
                                "'q' to quit";

            const string AccountActionsMenu = "Account Action Commands:\n" +
                                              "'li' for login(account)\n" +
                                              "'cc' for customer create (account)\n" +
                                              "'cu' for customer update (account)\n" +
                                              "'lo' for logout (account)\n" +
                                              "'pw' for password reset (account)\n" +
                                              "'wl' for wishlist (account)\n" +
                                              "'re' for redeem (account)\n" +
                                              "'co' for contact (account)\n" +
                                              "'menu' for main menu\n" +
                                              "'q' to quit";

            Console.WriteLine(Menu);
            var commandStr = Console.ReadLine();


            // loop on console actions 
            while (commandStr != null && !commandStr.Equals("q"))
            {
                // the OrdersGateway is responsible for sending orders to Riskified servers
                var gateway = new OrdersGateway(riskifiedEnv, authToken, domain);
                try
                {
                    OrderNotification res = null;
                    AccountActionNotification accRes = null;
                    switch (commandStr)
                    {
                        case "menu":
                        case "account":
                            break;
                        case "p":
                            Console.WriteLine("Order checkout Generated with merchant order number: " + orderNum);
                            var orderCheckout = GenerateOrderCheckout(orderNum.ToString());
                            orderCheckout.Id = orderNum.ToString();

                            // sending order checkout for creation (if new orderNum) or update (if existing orderNum)
                            res = gateway.Checkout(orderCheckout);
                            break;
                        case "e":
                            Console.WriteLine("Order checkout Generated.");
                            var orderCheckoutDenied = GenerateOrderCheckoutDenied(orderNum);

                            Console.Write("checkout to deny id: ");
                            var orderCheckoutDeniedId = Console.ReadLine();

                            orderCheckoutDenied.Id = orderCheckoutDeniedId;

                            // sending order checkout for creation (if new orderNum) or update (if existing orderNum)
                            res = gateway.CheckoutDenied(orderCheckoutDenied);
                            break;
                        case "c":
                            Console.WriteLine("Order Generated with merchant order number: " + orderNum);
                            order.Id = orderNum.ToString();
                            orderNum++;
                            // sending order for creation (if new orderNum) or update (if existing orderNum)
                            res = gateway.Create(order);
                            break;
                        case "s":
                            Console.WriteLine("Order Generated with merchant order number: " + orderNum);
                            order.Id = orderNum.ToString();
                            orderNum++;
                            // sending order for submitting and analysis 
                            // it will generate a callback to the notification webhook (if defined) with a decision regarding the order
                            res = gateway.Submit(order);
                            break;
                        case "v":
                            Console.WriteLine("Order Generated with merchant order number: " + orderNum);
                            order.Id = orderNum.ToString();
                            orderNum++;
                            // sending order for synchronous decision
                            // it will generate a synchronous response with the decision regarding the order
                            // (for sync flow only)
                            res = gateway.Decide(order);
                            break;
                        case "u":
                            Console.Write("Updated order id: ");
                            var upOrderId = Console.ReadLine();
                            order.Id = int.Parse(upOrderId).ToString();
                            res = gateway.Update(order);
                            break;
                        case "d":
                            Console.Write("Cancelled order id: ");
                            var canOrderId = Console.ReadLine();
                            res = gateway.Cancel(
                                                 new OrderCancellation(
                                                                       int.Parse(canOrderId),
                                                                       DateTime.Now,
                                                                       "Customer cancelled before shipping"));
                            break;
                        case "r":
                            Console.Write("Refunded order id: ");
                            var refOrderId = Console.ReadLine();
                            res = gateway.PartlyRefund(
                                                       new OrderPartialRefund(
                                                                              int.Parse(refOrderId),
                                                                              new[]
                                                                              {
                                                                                  new PartialRefundDetails(
                                                                                                           "12345",
                                                                                                           DateTime
                                                                                                               .Now, // make sure to initialize DateTime with the correct timezone
                                                                                                           5.3,
                                                                                                           "USD",
                                                                                                           "Customer partly refunded on shipping fees")
                                                                              }));
                            break;
                        case "f":
                            Console.Write("Fulfill order id: ");
                            var fulfillOrderId = Console.ReadLine();
                            var orderFulfillment = GenerateFulfillment(int.Parse(fulfillOrderId));
                            res = gateway.Fulfill(orderFulfillment);

                            break;
                        case "x":
                            Console.Write("Decision order id: ");
                            var decisionOrderId = Console.ReadLine();
                            var orderDecision = GenerateDecision(int.Parse(decisionOrderId));
                            res = gateway.Decision(orderDecision);

                            break;
                        case "h":
                            var startOrderNum = orderNum;
                            var orders = new List<Order>();
                            var financialStatuses = new[]
                                                    {
                                                        "paid", "cancelled", "chargeback"
                                                    };
                            for (var i = 0;
                                 i < 22;
                                 i++)
                            {
                                var o = GenerateOrder(orderNum++);
                                o.FinancialStatus = financialStatuses[i % 3];
                                orders.Add(o);
                            }

                            Console.WriteLine("Orders Generated with merchant order numbers: {0} to {1}", startOrderNum, orderNum - 1);

                            // sending 3 historical orders with different processing state
                            var success = gateway.SendHistoricalOrders(orders, out var errors);
                            if (success)
                            {
                                Console.WriteLine("All historical orders sent successfully");
                            }
                            else
                            {
                                Console.WriteLine("Some historical orders failed to send:");
                                Console.WriteLine(string.Join("\n", errors.Select(p => p.Key + ":" + p.Value).ToArray()));
                            }
                            break;

                        case "y":
                            Console.Write("Chargeback order id: ");
                            var chargebackOrderId = Console.ReadLine();
                            var orderChargeback = GenerateOrderChargeback(chargebackOrderId);
                            res = gateway.Chargeback(orderChargeback);

                            break;

                        case "l":
                            Console.Write("Check Deco eligibility on id: ");
                            var eligibleOrderId = Console.ReadLine();
                            var eligibleOrderIdOnly = GenerateOrderIdOnly(eligibleOrderId);
                            res = gateway.Eligible(eligibleOrderIdOnly);

                            break;

                        case "o":
                            Console.Write("Opt-in to Deco payment on id: ");
                            var optInOrderId = Console.ReadLine();
                            var optInOrderIdOnly = GenerateOrderIdOnly(optInOrderId);
                            res = gateway.OptIn(optInOrderIdOnly);

                            break;

                        case "li":
                            Console.Write("Login account action");
                            var login = GenerateLogin(idString);

                            accRes = gateway.Login(login);
                            break;

                        case "cc":
                            Console.Write("Customer Create account action");
                            var customerCreate = GenerateCustomerCreate(idString);

                            accRes = gateway.CustomerCreate(customerCreate);
                            break;

                        case "cu":
                            Console.Write("Customer Update account action");
                            var customerUpdate = GenerateCustomerUpdate(idString);

                            accRes = gateway.CustomerUpdate(customerUpdate);
                            break;

                        case "lo":
                            Console.Write("Logout account action");
                            var logout = GenerateLogout(idString);

                            accRes = gateway.Logout(logout);
                            break;

                        case "pw":
                            Console.Write("ResetPasswordRequest account action");
                            var resetPasswordRequest = GenerateResetPasswordRequest(idString);

                            accRes = gateway.ResetPasswordRequest(resetPasswordRequest);
                            break;

                        case "wl":
                            Console.Write("WishlistChanges account action");
                            var wishlistChanges = GenerateWishlistChanges(idString);

                            accRes = gateway.WishlistChanges(wishlistChanges);
                            break;

                        case "re":
                            Console.Write("Redeem account action");
                            var redeem = GenerateRedeem(idString);

                            accRes = gateway.Redeem(redeem);
                            break;

                        case "co":
                            Console.Write("Customer Reach-Out account action");
                            var customerReachOut = GenerateCustomerReachOut(idString);

                            accRes = gateway.CustomerReachOut(customerReachOut);
                            break;
                    }


                    if (res != null)
                    {
                        Console.WriteLine("\n\nOrder sent successfully:" +
                                          "\nStatus at Riskified: " + res.Status +
                                          "\nOrder ID received:" + res.Id +
                                          "\nDescription: " + res.Description +
                                          "\nWarnings: " + (res.Warnings == null
                                                                ? "---"
                                                                : string.Join("        \n", res.Warnings)) + "\n\n");
                    }
                    if (accRes != null)
                    {
                        Console.WriteLine("\n\nAccount Action sent successfully:" +
                                          "\nDecision: " + accRes.Decision);
                    }
                }
                catch (OrderFieldBadFormatException e)
                {
                    // catching 
                    Console.WriteLine("Exception thrown on order field validation: " + e.Message);
                }
                catch (RiskifiedTransactionException e)
                {
                    Console.WriteLine("Exception thrown on transaction: " + e.Message);
                }

                // ask for next action to perform
                Console.WriteLine();
                Console.WriteLine(commandStr.Equals("account")
                                      ? AccountActionsMenu
                                      : Menu);
                commandStr = Console.ReadLine();
            }

            #endregion
        }

        private static OrderChargeback GenerateOrderChargeback(string orderNum)
        {
            var chargebackDetails = new ChargebackDetails("id1234",
                                                          new DateTime(2015, 12, 8, 14, 12, 12, DateTimeKind.Local),
                                                          "USD",
                                                          (float) 50.5,
                                                          "4863",
                                                          "Transaction not recognized",
                                                          "cb",
                                                          "t_123",
                                                          creditCardCompany: "visa",
                                                          respondBy: new DateTime(2016, 9, 1),
                                                          arn: "a123456789012bc3de45678901f23a45",
                                                          feeAmount: 20,
                                                          feeCurrency: "USD",
                                                          cardIssuer: "Wells Fargo Bank",
                                                          gateway: "braintree",
                                                          cardholder: "John Smith",
                                                          message:
                                                          "Cardholder disputes quality/ mis-characterization of service/merchandise. Supply detailed refute of these claims, along with any applicable/supporting doc");

            var fulfillmentDetails = new FulfillmentDetails(
                                                            "123",
                                                            new DateTime(2015, 12, 8, 14, 12, 12, DateTimeKind.Local),
                                                            FulfillmentStatusCode.Success,
                                                            new[]
                                                            {
                                                                new LineItem("Bag", 10.0, 1)
                                                            },
                                                            "TestCompany");

            var disputeDetails = new DisputeDetails(
                                                    disputeType: "first_dispute",
                                                    caseId: "a1234",
                                                    status: "pending",
                                                    issuerPocPhoneNumber: "+1-877-111-1111",
                                                    disputedAt: new DateTime(2016, 9, 15),
                                                    expectedResolutionDate: new DateTime(2016, 11, 1));

            return new OrderChargeback(orderNum, chargebackDetails, fulfillmentDetails, disputeDetails);
        }

        private static OrderDecision GenerateDecision(int p)
        {
            // make sure to initialize DateTime with the correct timezone
            var orderDecision = new OrderDecision(p, new DecisionDetails(ExternalStatusType.ChargebackFraud, DateTime.Now, "used proxy and stolen credit card."));
            return orderDecision;
        }

        private static OrderCheckout GenerateOrderCheckout(string orderNum)
        {
            var orderCheckout = new OrderCheckout(orderNum);

            var address = new AddressInformation(
                                                 "Ben",
                                                 "Rolling",
                                                 "27 5th avenue",
                                                 "Manhattan",
                                                 "United States",
                                                 "US",
                                                 "5554321234",
                                                 "Apartment 5",
                                                 "54545",
                                                 "New York",
                                                 "NY",
                                                 "IBM",
                                                 "Ben Philip Rolling");

            var payments = new[]
                           {
                               new CreditCardPaymentDetails(
                                                            "Y",
                                                            "n",
                                                            "124580",
                                                            "Visa",
                                                            "XXXX-XXXX-XXXX-4242",
                                                            creditCardToken: "2233445566778899"
                                                           )
                           };

            var lines = new[]
                        {
                            new ShippingLine(22.22, "Mail")
                        };

            // This is an example for client details section
            var clientDetails = new ClientDetails(
                                                  "en-CA",
                                                  "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)"
                                                 );


            // Fill optional fields
            var customer = new Customer(
                                        "John",
                                        "Doe",
                                        "405050606",
                                        4,
                                        "test@example.com",
                                        true,
                                        new DateTime(2013, 12, 8, 14, 12, 12, DateTimeKind.Local), // make sure to initialize DateTime with the correct timezone
                                        "No additional info");

            var items = new[]
                        {
                            new LineItem("Bag", 55.44, 1, "48484", "1272727"), new LineItem("Monster", 22.3, 3)
                        };

            var discountCodes = new[]
                                {
                                    new DiscountCode(7, "1")
                                };

            orderCheckout.Email = "tester@exampler.com";
            orderCheckout.Currency = "USD";
            orderCheckout.UpdatedAt = DateTime.Now; // make sure to initialize DateTime with the correct timezone
            orderCheckout.Gateway = "authorize_net";
            orderCheckout.CustomerBrowserIp = "165.12.1.1";
            orderCheckout.TotalPrice = 100.60;
            orderCheckout.CartToken = "a68778783ad298f1c80c3bafcddeea02f";
            orderCheckout.ReferringSite = "nba.com";
            orderCheckout.LineItems = items;
            orderCheckout.DiscountCodes = discountCodes;
            orderCheckout.ShippingLines = lines;
            orderCheckout.PaymentDetails = payments;
            orderCheckout.Customer = customer;
            orderCheckout.BillingAddress = address;
            orderCheckout.ShippingAddress = address;
            orderCheckout.ClientDetails = clientDetails;

            return orderCheckout;
        }

        private static OrderCheckoutDenied GenerateOrderCheckoutDenied(int orderNum)
        {
            var authorizationError = new AuthorizationError(
                                                            new DateTime(2013, 12, 8, 14, 12, 12,
                                                                         DateTimeKind.Local), // make sure to initialize DateTime with the correct timezone
                                                            "Card Declined",
                                                            "Card was Declined.");

            var payments = new[]
                           {
                               new CreditCardPaymentDetails(
                                                            "Y",
                                                            "n",
                                                            "124580",
                                                            "Visa",
                                                            "XXXX-XXXX-XXXX-4242",
                                                            creditCardToken: "2233445566778899"
                                                           )
                               {
                                   AuthorizationError = authorizationError
                               }
                           };

            var orderCheckoutDenied = new OrderCheckoutDenied(orderNum.ToString())
                                      {
                                          PaymentDetails = payments
                                      };

            return orderCheckoutDenied;
        }

        private static OrderFulfillment GenerateFulfillment(int fulfillOrderId)
        {
            FulfillmentDetails[] fulfillmentList =
            {
                new FulfillmentDetails(
                                       "123",
                                       new DateTime(2013, 12, 8, 14, 12, 12, DateTimeKind.Local),
                                       FulfillmentStatusCode.Success,
                                       new[]
                                       {
                                           new LineItem("Bag", 10.0, 1)
                                       },
                                       "TestCompany")
            };

            var orderFulfillment = new OrderFulfillment(
                                                        fulfillOrderId,
                                                        fulfillmentList);

            return orderFulfillment;
        }

        /// <summary>
        ///     Generates a new order object
        ///     Mind that some of the fields of the order (and it's sub-objects) are optional
        /// </summary>
        /// <param name="orderNum">The order number to put in the order object</param>
        /// <returns></returns>
        private static Order GenerateOrder(int orderNum)
        {
            var customerAddress = new BasicAddress(
                                                   "27 5th avenue",
                                                   "Manhattan",
                                                   "United States",
                                                   "US",
                                                   "5554321234",
                                                   "Apartment 5",
                                                   "54545"
                                                  );

            // putting sample customer details
            var customer = new Customer(
                                        "John",
                                        "Doe",
                                        "405050606",
                                        4,
                                        "test@example.com",
                                        true,
                                        new DateTime(2013, 12, 8, 14, 12, 12, DateTimeKind.Local), // make sure to initialize DateTime with the correct timezone
                                        "No additional info",
                                        address: customerAddress,
                                        accountType: "Premium");

            // putting sample billing details
            var billing = new AddressInformation(
                                                 "Ben",
                                                 "Rolling",
                                                 "27 5th avenue",
                                                 "Manhattan",
                                                 "United States",
                                                 "US",
                                                 "5554321234",
                                                 "Apartment 5",
                                                 "54545",
                                                 "New York",
                                                 "NY",
                                                 "IBM",
                                                 "Ben Philip Rolling");

            var shipping = new AddressInformation(
                                                  "Luke",
                                                  "Rolling",
                                                  "4 Bermingham street",
                                                  "Cherry Hill",
                                                  "United States",
                                                  "US",
                                                  "55546665",
                                                  provinceCode: "NJ",
                                                  province: "New Jersey");

            IPaymentDetails[] payments =
            {
                new CreditCardPaymentDetails(
                                             "Y",
                                             "n",
                                             "124580",
                                             "Visa",
                                             "XXXX-XXXX-XXXX-4242",
                                             creditCardToken: "2233445566778899"
                                            )
            };

            var noChargeAmount = new NoChargeDetails(
                                                     "123444",
                                                     20.5,
                                                     "GBP",
                                                     "giftcard"
                                                    );

            var lines = new[]
                        {
                            new ShippingLine(22.22, "Mail"), new ShippingLine(2, "Ship", "A22F")
                        };

            var recipientSocial = new SocialDetails(
                                                    "Facebook",
                                                    "john.smith",
                                                    accountUrl: "http://www.facebook.com/john.smith");

            var recipient = new Recipient(
                                          "aa@bb.com",
                                          "96522444221",
                                          recipientSocial);


            var items = new[]
                        {
                            new LineItem("Bag", 55.44, 1, "48484", "1272727",
                                         deliveredTo: DeliveredToType.StorePickup,
                                         deliveredAt: new DateTime(2016, 12, 8, 14, 12, 12, DateTimeKind.Local)),
                            new LineItem("Monster", 22.3, 3,
                                         seller: new Seller(customer, 1, true, 120)),

                            // Events Tickets Product (applicable for event industry merchants)
                            new EventTicketLineItem(
                                                    "Concert",
                                                    123,
                                                    1,
                                                    category: "Singers",
                                                    subCategory: "Rock",
                                                    eventName: "Bon Jovy",
                                                    eventSectionName: "Section",
                                                    //eventCountry: "USA",
                                                    eventCountryCode: "US",
                                                    latitude: 0,
                                                    longitude: 0),

                            // Gift card Product (applicable for gift card industry merchants)
                            new DigitalLineItem(
                                                "Concert",
                                                123,
                                                1,
                                                senderName: "John",
                                                displayName: "JohnJohn",
                                                photoUploaded: true,
                                                photoUrl: "http://my_pic_url",
                                                greetingPhotoUrl: "http://my_greeting_pic_url",
                                                message: "Happy Birthday",
                                                greetingMessage: "Happy Birthday from John",
                                                cardType: "regular",
                                                cardSubType: "birthday",
                                                senderEmail: "new_email@bb.com",
                                                recipient: recipient),

                            // Travel ticket product (applicable for travel industry merchants)
                            new TravelTicketLineItem("Concert",
                                                     123,
                                                     1,
                                                     departureCity: "ashdod",
                                                     departureCountryCode: "IL",
                                                     transportMethod: TransportMethodType.Plane),
                            // Accommodation reservation product (applicable for travel industry merchants)
                            new AccommodationLineItem(
                                                      "Hotel Arcadia - Standard Room",
                                                      476,
                                                      1,
                                                      "123",
                                                      city: "London",
                                                      countryCode: "GB",
                                                      rating: "5",
                                                      numberOfGuests: 2,
                                                      cancellationPolicy: "Not applicable",
                                                      accommodationType: "Hotel")
                        };

            var discountCodes = new[]
                                {
                                    new DiscountCode(7, "1")
                                };

            var decisionDetails = new DecisionDetails(ExternalStatusType.Approved, DateTime.Now); // make sure to initialize DateTime with the correct timezone

            // This is an example for an order with charge free sums (e.g. gift card payment)
            var chargeFreePayments = new ChargeFreePaymentDetails(
                                                                  "giftcard",
                                                                  45);

            // This is an example for client details section
            var clientDetails = new ClientDetails(
                                                  "en-CA",
                                                  "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)");

            var custom = new Custom(
                                    "D2C"
                                   );

            var order = new Order(
                                  orderNum.ToString(),
                                  "tester@exampler.com",
                                  customer,
                                  paymentDetails: payments,
                                  billingAddress: billing,
                                  shippingAddress: shipping,
                                  lineItems: items,
                                  shippingLines: lines,
                                  gateway: "authorize_net",
                                  customerBrowserIp: "165.12.1.1",
                                  currency: "USD",
                                  totalPrice: 100.60,
                                  createdAt: DateTime.Now, // make sure to initialize DateTime with the correct timezone
                                  updatedAt: DateTime.Now, // make sure to initialize DateTime with the correct timezone
                                  discountCodes: discountCodes,
                                  source: "web",
                                  noChargeDetails: noChargeAmount,
                                  decisionDetails: decisionDetails,
                                  vendorId: "2",
                                  vendorName: "domestic",
                                  additionalEmails: new[]
                                                    {
                                                        "a@a.com", "b@b.com"
                                                    },
                                  chargeFreePaymentDetails: chargeFreePayments,
                                  clientDetails: clientDetails,
                                  custom: custom,
                                  groupFounderOrderId: "2222",
                                  submissionReason: SubmissionReason.ManualDecision
                                 );

            return order;
        }

        private static Order PayPalGenerateOrder(int orderNum)
        {
            // putting sample customer details
            var customer = new Customer(
                                        "John",
                                        "Doe",
                                        "405050606",
                                        4,
                                        "test@example.com",
                                        true,
                                        new DateTime(2013, 12, 8, 14, 12, 12, DateTimeKind.Local), // make sure to initialize DateTime with the correct timezone
                                        "No additional info");

            // putting sample billing details
            var billing = new AddressInformation(
                                                 "Ben",
                                                 "Rolling",
                                                 "27 5th avenue",
                                                 "Manhattan",
                                                 "United States",
                                                 "US",
                                                 "5554321234",
                                                 "Apartment 5",
                                                 "54545",
                                                 "New York",
                                                 "NY",
                                                 "IBM",
                                                 "Ben Philip Rolling");

            var shipping = new AddressInformation(
                                                  "Luke",
                                                  "Rolling",
                                                  "4 Bermingham street",
                                                  "Cherry Hill",
                                                  "United States",
                                                  "US",
                                                  "55546665",
                                                  provinceCode: "NJ",
                                                  province: "New Jersey");

            var payments = new[]
                           {
                               new PaypalPaymentDetails(
                                                        "Authorized",
                                                        "AFSDF332432SDF45DS5FD",
                                                        "payer@gmail.com",
                                                        "Verified",
                                                        "Unverified",
                                                        "Partly Eligible",
                                                        "Review"
                                                       )
                           };

            var lines = new[]
                        {
                            new ShippingLine(22.22, "Mail"), new ShippingLine(2, "Ship", "A22F")
                        };

            var items = new[]
                        {
                            new LineItem("Bag", 55.44, 1, "48484", "1272727"), new LineItem("Monster", 22.3, 3)
                        };

            var discountCodes = new[]
                                {
                                    new DiscountCode(7, "1")
                                };

            var order = new Order(
                                  orderNum.ToString(),
                                  "tester@exampler.com",
                                  customer,
                                  paymentDetails: payments,
                                  billingAddress: billing,
                                  shippingAddress: shipping,
                                  lineItems: items,
                                  shippingLines: lines,
                                  gateway: "authorize_net",
                                  customerBrowserIp: "165.12.1.1",
                                  currency: "USD",
                                  totalPrice: 100.60,
                                  createdAt: DateTime.Now, // make sure to initialize DateTime with the correct timezone
                                  updatedAt: DateTime.Now, // make sure to initialize DateTime with the correct timezone
                                  discountCodes: discountCodes);

            return order;
        }

        private static OrderIdOnly GenerateOrderIdOnly(string orderNum)
        {
            return new OrderIdOnly(orderNum);
        }

        private static ClientDetails GenerateClientDetails()
        {
            return new ClientDetails("en-CA", "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)");
        }

        private static SessionDetails GenerateSessionDetails()
        {
            return new SessionDetails(DateTime.Now, "68778783ad298f1c80c3bafcddeea02f", "111.111.111.111", SessionSource.DesktopWeb);
        }

        private static Customer GenerateCustomer(string idString)
        {
            return new Customer("Bob", "Norman", idString)
                   {
                       CreatedAt = DateTime.Now,
                       VerifiedEmail = true,
                       Email = "bob.norman@hostmail.com"
                   };
        }

        private static IPaymentDetails[] GenerateCreditCardPaymentDetails()
        {
            return new IPaymentDetails[]
                   {
                       new CreditCardPaymentDetails("Y", "M", "123456", "Visa", "4242")
                       {
                           AuthorizationError = new AuthorizationError(DateTime.Now, "card_declined", "insufficient funds")
                       }
                   };
        }

        private static AddressInformation GenerateAddressInformation()
        {
            return new AddressInformation("Bob", "Norman", "Chestnut Street 92", "Louisville", "United States", "US", "555-625-1199")
                   {
                       FullName = "Bob Norman",
                       Province = "Kentucky",
                       ProvinceCode = "KY",
                       ZipCode = "40202"
                   };
        }

        private static Login GenerateLogin(string idString)
        {
            var loginStatus = new LoginStatus(LoginStatusType.Success);
            var clientDetails = GenerateClientDetails();
            var sessionDetails = GenerateSessionDetails();

            return new Login(idString, "bob.norman@hostmail.com", loginStatus, clientDetails, sessionDetails);
        }

        private static CustomerCreate GenerateCustomerCreate(string idString)
        {
            var addresses = new[]
                            {
                                GenerateAddressInformation()
                            };

            return new CustomerCreate(idString, GenerateClientDetails(), GenerateSessionDetails(), GenerateCustomer(idString))
                   {
                       PaymentDetails = GenerateCreditCardPaymentDetails(),
                       BillingAddress = addresses,
                       ShippingAddress = addresses
                   };
        }

        private static CustomerUpdate GenerateCustomerUpdate(string idString)
        {
            var addresses = new[]
                            {
                                GenerateAddressInformation()
                            };

            return new CustomerUpdate(idString, false, GenerateClientDetails(), GenerateSessionDetails(), GenerateCustomer(idString))
                   {
                       PaymentDetails = GenerateCreditCardPaymentDetails(),
                       BillingAddress = addresses,
                       ShippingAddress = addresses
                   };
        }

        private static Logout GenerateLogout(string idString)
        {
            return new Logout(idString, GenerateClientDetails(), GenerateSessionDetails());
        }

        private static ResetPasswordRequest GenerateResetPasswordRequest(string idString)
        {
            return new ResetPasswordRequest(idString, GenerateClientDetails(), GenerateSessionDetails());
        }

        private static Redeem GenerateRedeem(string idString)
        {
            return new Redeem(idString, RedeemType.GiftCard, GenerateClientDetails(), GenerateSessionDetails());
        }

        private static WishlistChanges GenerateWishlistChanges(string idString)
        {
            var lineItem = new LineItem("IPod Nano - 8gb - green", 199, 1)
                           {
                               Brand = "Apple",
                               ProductId = "632910392",
                               ProductType = ProductType.Physical,
                               Category = "Electronics"
                           };

            return new WishlistChanges(idString, WishlistAction.Add, GenerateClientDetails(), GenerateSessionDetails(), lineItem);
        }

        private static CustomerReachOut GenerateCustomerReachOut(string idString)
        {
            var contactMethod = new ContactMethod(ContactMethodType.Email)
                                {
                                    Email = "moo@gmail.com"
                                };
            return new CustomerReachOut(idString, contactMethod);
        }

        #region Run all endpoints

        public static int RunAll()
        {
            try
            {
                var domain = ConfigurationManager.AppSettings["MerchantDomain"];
                var authToken = ConfigurationManager.AppSettings["MerchantAuthenticationToken"];
                var riskifiedEnv = (RiskifiedEnvironment) Enum.Parse(typeof(RiskifiedEnvironment), ConfigurationManager.AppSettings["RiskifiedEnvironment"]);

                var rand = new Random();
                var orderNum = rand.Next(1000, 200000);
                var order = GenerateOrder(orderNum);

                var gateway = new OrdersGateway(riskifiedEnv, authToken, domain);

                var orderCheckout = GenerateOrderCheckout(orderNum.ToString());
                orderCheckout.Id = orderNum.ToString();
                gateway.Checkout(orderCheckout);

                var orderCheckoutDenied = GenerateOrderCheckoutDenied(orderNum);
                orderNum++;
                orderCheckoutDenied.Id = orderNum.ToString();
                gateway.CheckoutDenied(orderCheckoutDenied);

                orderNum++;
                order.Id = orderNum.ToString();
                gateway.Create(order);

                order.Id = orderNum.ToString();
                orderNum++;
                gateway.Submit(order);

                gateway.Update(order);
                gateway.Cancel(
                               new OrderCancellation(
                                                     order.Id,
                                                     DateTime.Now,
                                                     "Customer cancelled before shipping"));

                order.Id = orderNum.ToString();
                orderNum++;
                // sending order for creation (if new orderNum) or update (if existing orderNum)
                gateway.Create(order);

                order.Id = orderNum.ToString();
                orderNum++;
                // sending order for submitting and analysis 
                // it will generate a callback to the notification webhook (if defined) with a decision regarding the order
                gateway.Submit(order);

                order.Id = order.Id;
                gateway.Update(order);

                gateway.Cancel(
                               new OrderCancellation(
                                                     int.Parse(order.Id),
                                                     DateTime.Now,
                                                     "Customer cancelled before shipping"));

                gateway.PartlyRefund(
                                     new OrderPartialRefund(
                                                            int.Parse(order.Id),
                                                            new[]
                                                            {
                                                                new PartialRefundDetails(
                                                                                         "12345",
                                                                                         DateTime
                                                                                             .Now, // make sure to initialize DateTime with the correct timezone
                                                                                         5.3,
                                                                                         "USD",
                                                                                         "Customer partly refunded on shipping fees")
                                                            }));

                var orderFulfillment = GenerateFulfillment(int.Parse(order.Id));
                gateway.Fulfill(orderFulfillment);


                var orderDecision = GenerateDecision(int.Parse(order.Id));
                gateway.Decision(orderDecision);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[failed] " + ex);
                return -1;
            }

            return 0;
        }

        #endregion
    }
}
