using System.Collections.Generic;
using System.Linq;

namespace BanksGateDataModel.Codes
{
    public static class PaymentStatusEnumExtension
    {
        public static string[] ToCodes(this IEnumerable<PaymentStatusEnum> statuses)
        {
            return statuses.Select(r => ((int) r).ToString()).ToArray();
        }

        public static string ToCode(this PaymentStatusEnum status)
        {
            return ((int) status).ToString();
        }

        public static PaymentStatusEnum ToPaymentStatusCode(this string status)
        {
            return (PaymentStatusEnum) int.Parse(status);
        }

        public static PaymentStatusEnum[] OnProcess()
        {
            return new[]
            {
                PaymentStatusEnum.None,
                PaymentStatusEnum.LoadInDataBase,
                PaymentStatusEnum.LinkedWithClient,
                PaymentStatusEnum.RequestInformation,
                PaymentStatusEnum.Accepted,
                PaymentStatusEnum.Compliance,
                PaymentStatusEnum.Sundry,
                PaymentStatusEnum.Transit,
                PaymentStatusEnum.OnDevelop,
                //PaymentStatusEnum.OnApproveDocumentScreening,
                PaymentStatusEnum.TransitInvestigation,
                PaymentStatusEnum.ManualNew,
                PaymentStatusEnum.ManualOnDevelop,
                PaymentStatusEnum.ApprovedFinalManualOnDevelop,
                PaymentStatusEnum.TransitOnDevelop,
                PaymentStatusEnum.TransitRequestInformation,
                PaymentStatusEnum.CancelNotAcceptedByCF,
                PaymentStatusEnum.PaymentRejection,
            };
        }

        public static PaymentStatusEnum[] OnProcessed()
        {
            return new[]
            {
                PaymentStatusEnum.Rollback,
                PaymentStatusEnum.Approved,
            };
        }

        public static PaymentStatusEnum[] OnApprove()
        {
            return new[]
            {
                PaymentStatusEnum.OnApprove,
                PaymentStatusEnum.OnCancel,
                PaymentStatusEnum.ManualOnApprove,
                PaymentStatusEnum.SendToTransit,
                PaymentStatusEnum.TransitOnApprove,
                PaymentStatusEnum.SendToTransitRequestInformation,
                PaymentStatusEnum.SendToTransitInvestigation,
                PaymentStatusEnum.SendToTransitDocumentScreening,
                PaymentStatusEnum.SendToTransitApprovedDocumentScreening,
                PaymentStatusEnum.SetZeroFXOnApprove,
            };
        }

        public static PaymentStatusEnum[] OnFinal()
        {
            return new[]
            {
                PaymentStatusEnum.Canceled,
                PaymentStatusEnum.ApprovedFinal,
                PaymentStatusEnum.CanceledFinal,
                PaymentStatusEnum.DeletedFinal,
                PaymentStatusEnum.RollbackFinal,
                PaymentStatusEnum.ManualApproved,
                PaymentStatusEnum.SetZeroFXApproved,
                PaymentStatusEnum.ApprovedFinalManualOnDevelop,
                PaymentStatusEnum.TransitNotAcceptedByCF,
            };
        }
        
        public static PaymentStatusEnum[] OnFinalSuccess()
        {
            return new[]
            {
                PaymentStatusEnum.ApprovedFinal,
                PaymentStatusEnum.ManualApproved,
                PaymentStatusEnum.ApprovedFinalManualOnDevelop,
            };
        }

        public static PaymentStatusEnum[] AllCanceled()
        {
            return new[]
            {
                PaymentStatusEnum.Canceled,
                PaymentStatusEnum.CanceledFinal,
                PaymentStatusEnum.DeletedFinal,
                PaymentStatusEnum.RollbackFinal,
                PaymentStatusEnum.Archive,
                PaymentStatusEnum.Deleted,
            };
        }

        public static PaymentStatusEnum[] OnArchive()
        {
            return new[]
            {
                PaymentStatusEnum.Archive,
                PaymentStatusEnum.Deleted
            };
        }

        public static PaymentStatusEnum[] BlockedStatuses()
        {
            return new[]
            {
                PaymentStatusEnum.Blocked,
                PaymentStatusEnum.OnUnblocking,
                PaymentStatusEnum.BlockedRequirementsOfAFR,
                PaymentStatusEnum.OnUnblockingRequirementsOfAFRHasAMLAnswer,
                PaymentStatusEnum.BlockedRequirementsOfGoodsPreCheck, 
                PaymentStatusEnum.OnUnblockingRequirementsOfGoodsPreCheckHasAnswer, 
                PaymentStatusEnum.BlockedPaymentFallsCriteriaNewRules,
                PaymentStatusEnum.OnBlockingPaymentFallsCriteriaNewRulesOnUnlocking
            };
        }

        public static PaymentStatusEnum[] BlockedStatusesForApproveCanselButton()
        {
            return new[]
                   {
                       PaymentStatusEnum.BlockedPaymentFallsCriteriaNewRules,
                       PaymentStatusEnum.OnBlockingPaymentFallsCriteriaNewRulesOnUnlocking
                   };
        }

        public static PaymentStatusEnum[] BlockedStatusesForApproveUnblockButton()
        {
            return new[]
            {
                PaymentStatusEnum.OnUnblocking,
                PaymentStatusEnum.OnUnblockingRequirementsOfAFRHasAMLAnswer,
                PaymentStatusEnum.OnUnblockingRequirementsOfGoodsPreCheckHasAnswer,
                PaymentStatusEnum.OnBlockingPaymentFallsCriteriaNewRulesOnUnlocking
            };
        }

        public static PaymentStatusEnum[] BlockedStatusesForUnblockButton()
        {
            return new[]
            {
                PaymentStatusEnum.Blocked,
                PaymentStatusEnum.BlockedRequirementsOfAFR,
                PaymentStatusEnum.BlockedRequirementsOfGoodsPreCheck,
                PaymentStatusEnum.BlockedPaymentFallsCriteriaNewRules,
                PaymentStatusEnum.OnBlockingPaymentFallsCriteriaNewRulesOnUnlocking
            };
        }

        public static PaymentStatusEnum[] AllBlockStatuses()
        {
            return new[]
            {
                PaymentStatusEnum.Blocked,
                PaymentStatusEnum.OnUnblocking,
                PaymentStatusEnum.BlockedRequirementsOfAFR,
                PaymentStatusEnum.OnUnblockingRequirementsOfAFRHasAMLAnswer,
                PaymentStatusEnum.UnblockedRequirementsOfAFRHasAMLAnswer,
                PaymentStatusEnum.BlockedRequirementsOfGoodsPreCheck, 
                PaymentStatusEnum.OnUnblockingRequirementsOfGoodsPreCheckHasAnswer, 
                PaymentStatusEnum.UnblockedRequirementsOfGoodsPreCheckHasAnswer,
                PaymentStatusEnum.BlockedPaymentFallsCriteriaNewRules,
                PaymentStatusEnum.OnBlockingPaymentFallsCriteriaNewRulesOnUnlocking
            };
        }

        public static PaymentStatusEnum[] ManualStatuses()
        {
            return new[]
            {
                PaymentStatusEnum.ManualNew,
                PaymentStatusEnum.ManualApproved,
                PaymentStatusEnum.ManualOnApprove,
                PaymentStatusEnum.ManualOnDevelop,
                PaymentStatusEnum.ApprovedFinalManualOnDevelop
            };
        }
        
        public static PaymentStatusEnum[] ZeroStatuses()
        {
            return new[]
            {
                PaymentStatusEnum.SetZeroPaymentOnApprove,
                PaymentStatusEnum.SetZeroPaymentApproved,
                PaymentStatusEnum.SetZeroPaymentCanceled,
                PaymentStatusEnum.FixPaymentTypeApproved,
                PaymentStatusEnum.FixPaymentTypeOnApprove,
                PaymentStatusEnum.FixPaymentTypeCanceled,
            };
        }

        public static PaymentStatusEnum[] TransitStatuses()
        {
            return new[]
            {
                PaymentStatusEnum.Transit,
                PaymentStatusEnum.TransitInvestigation,
                PaymentStatusEnum.TransitRequestInformation,
                PaymentStatusEnum.TransitNotAcceptedByCF,
                PaymentStatusEnum.TransitOnApprove,
                PaymentStatusEnum.TransitOnDevelop,
                PaymentStatusEnum.Sundry,
                PaymentStatusEnum.SendToTransit,
                PaymentStatusEnum.SendToTransitInvestigation,
                PaymentStatusEnum.SendToTransitRequestInformation,
                PaymentStatusEnum.SendToTransitDocumentScreening,
                PaymentStatusEnum.SendToTransitApprovedDocumentScreening,
            };
        }

        public static PaymentStatusEnum[] OnTransitStatuses()
        {
            return new[]
            {
                PaymentStatusEnum.Transit,
                PaymentStatusEnum.TransitRequestInformation,
                PaymentStatusEnum.TransitOnDevelop,
            };
        }

        public static PaymentStatusEnum[] DocumentScreening()
        {
            return new[]
            {
                PaymentStatusEnum.OnApproveDocumentScreening,
                PaymentStatusEnum.ApprovedDocumentScreening,
            };
        }

        public static bool AllowStartFix(this PaymentStatusEnum status)
        {
            switch (status)
            {
                case PaymentStatusEnum.SetZeroPaymentCanceled:
                case PaymentStatusEnum.FixPaymentTypeApproved:
                case PaymentStatusEnum.FixPaymentTypeCanceled:
                    return true;
            }

            return false;
        }

        public static PaymentStatusEnum[] FinalExcludedFromCalc()
        {
            return new[]
                   {
                       PaymentStatusEnum.CanceledFinal,
                       PaymentStatusEnum.DeletedFinal,
                       PaymentStatusEnum.RollbackFinal,
                   };
        }
    }
}