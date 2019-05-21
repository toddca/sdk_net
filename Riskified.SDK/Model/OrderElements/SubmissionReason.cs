// // -----------------------------------------------------------------------
// // <copyright from="2019" to="2019" file="SubmissionReason.cs" company="Lindell Technologies">
// //    Copyright (c) Lindell Technologies All Rights Reserved.
// //    Information Contained Herein is Proprietary and Confidential.
// // </copyright>
// // -----------------------------------------------------------------------

using System.Runtime.Serialization;

namespace Riskified.SDK.Model.OrderElements
{
    public enum SubmissionReason
    {
        [EnumMember(Value = "failed_verification")]
        FailedVerification,

        [EnumMember(Value = "rule_decision")]
        RuleDecision,

        [EnumMember(Value = "third_party")]
        ThirdParty,

        [EnumMember(Value = "manual_decision")]
        ManualDecision,

        [EnumMember(Value = "policy_decision")]
        PolicyDecision
    }
}
