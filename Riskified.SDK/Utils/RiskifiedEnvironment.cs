// // -----------------------------------------------------------------------
// // <copyright from="2019" to="2019" file="RiskifiedEnvironment.cs" company="Lindell Technologies">
// //    Copyright (c) Lindell Technologies All Rights Reserved.
// //    Information Contained Herein is Proprietary and Confidential.
// // </copyright>
// // -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Riskified.SDK.Exceptions;

namespace Riskified.SDK.Utils
{
    public enum RiskifiedEnvironment
    {
        Debug,
        Sandbox,
        Production
    }

    public enum FlowStrategy
    {
        Default,
        Sync,
        Account,
        Deco
    }

    internal static class EnvironmentsUrls
    {
        private static readonly Dictionary<RiskifiedEnvironment, Dictionary<FlowStrategy, string>> s_envToUrl;

        private static readonly Dictionary<FlowStrategy, string> s_debugUrl;

        static EnvironmentsUrls()
        {
            s_envToUrl = new Dictionary<RiskifiedEnvironment, Dictionary<FlowStrategy, string>>(3);

            s_debugUrl = new Dictionary<FlowStrategy, string>(1);
            var sandboxUrl = new Dictionary<FlowStrategy, string>(3);
            var productionUrl = new Dictionary<FlowStrategy, string>(4);

            s_envToUrl.Add(RiskifiedEnvironment.Debug, s_debugUrl);

            sandboxUrl.Add(FlowStrategy.Default, "https://sandbox.riskified.com");
            sandboxUrl.Add(FlowStrategy.Account, "https://api-sandbox.riskified.com");
            sandboxUrl.Add(FlowStrategy.Deco, "https://sandboxw.decopayments.com");
            s_envToUrl.Add(RiskifiedEnvironment.Sandbox, sandboxUrl);

            productionUrl.Add(FlowStrategy.Default, "https://wh.riskified.com");
            productionUrl.Add(FlowStrategy.Sync, "https://wh-sync.riskified.com");
            productionUrl.Add(FlowStrategy.Account, "https://api.riskified.com");
            productionUrl.Add(FlowStrategy.Deco, "https://w.decopayments.com");
            s_envToUrl.Add(RiskifiedEnvironment.Production, productionUrl);
        }

        public static void SetDebugRiskifiedHostUrl(string debugRiskifiedHostUrl)
        {
            if (string.IsNullOrEmpty(debugRiskifiedHostUrl))
            {
                throw new ArgumentNullException(nameof(debugRiskifiedHostUrl));
            }

            s_debugUrl.Add(FlowStrategy.Default, debugRiskifiedHostUrl);
        }

        public static Dictionary<FlowStrategy, string> GetEnv(RiskifiedEnvironment env)
        {
            if (s_envToUrl.ContainsKey(env))
            {
                return s_envToUrl[env];
            }

            throw new RiskifiedException($"Riskified environment '{env}' doesn't exist");
        }

        public static string GetEnvUrl(RiskifiedEnvironment env, FlowStrategy flow)
        {
            var currentEnv = GetEnv(env);
            return currentEnv.ContainsKey(flow)
                       ? currentEnv[flow]
                       : currentEnv[FlowStrategy.Default];
        }
    }
}
