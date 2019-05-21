// // -----------------------------------------------------------------------
// // <copyright from="2019" to="2019" file="Program.cs" company="Lindell Technologies">
// //    Copyright (c) Lindell Technologies All Rights Reserved.
// //    Information Contained Herein is Proprietary and Confidential.
// // </copyright>
// // -----------------------------------------------------------------------

using Riskified.SDK.Logging;

namespace Riskified.SDK.Sample
{
    internal static class Program
    {
        private static int Main(string[] args)
        {
            #region logger setup [Optional]

            // setting up a logger facade to the system logger using the ILog interface
            // if a logger facade is created it will enable a peek into the logs created by the SDK and will help understand issues easier
            var logger = new SimpleExampleLogger();
            LoggingServices.InitializeLogger(logger);

            #endregion

            # region run all api endpoints

            if (args.Length > 0 && args[0] == "run_all")
            {
                return OrderTransmissionExample.RunAll();
            }

            #endregion

            # region notification example

            NotificationServerExample.ReceiveNotificationsExample();

            #endregion

            #region orders example

            OrderTransmissionExample.SendOrdersToRiskifiedExample();

            #endregion


            // make sure to shut down the notifications server when done
            NotificationServerExample.StopNotificationServer();

            return 0;
        }
    }
}
