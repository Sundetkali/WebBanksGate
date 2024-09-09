set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO




IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.adb_DictionaryBankCode_UniqueCode'))
DROP TRIGGER dbo.adb_DictionaryBankCode_UniqueCode
GO

CREATE TRIGGER dbo.adb_DictionaryBankCode_UniqueCode on dbo.adb_DictionaryBankCode
WITH EXECUTE AS CALLER
FOR INSERT, UPDATE
AS
BEGIN
   if exists(select * from adb_DictionaryBankCode t join Inserted i on i.code = t.code where t.id <> i.id)
   begin
      raiserror (50007, 16, 127)
      rollback  transaction
      return
   end
end
go



IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.DIC_RegistryStatuses_UniqueCode'))
DROP TRIGGER dbo.DIC_RegistryStatuses_UniqueCode
GO

CREATE TRIGGER dbo.DIC_RegistryStatuses_UniqueCode on dbo.DIC_RegistryStatuses
WITH EXECUTE AS CALLER
FOR INSERT, UPDATE
AS
BEGIN
   if exists(select * from DIC_RegistryStatuses t join Inserted i on i.code = t.code where t.id <> i.id)
   begin
      raiserror (50007, 16, 127)
      rollback  transaction
      return
   end
end
go



IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.DIC_PayMethods_UniqueCode'))
DROP TRIGGER dbo.DIC_PayMethods_UniqueCode
GO

CREATE TRIGGER dbo.DIC_PayMethods_UniqueCode on dbo.DIC_PayMethods
WITH EXECUTE AS CALLER
FOR INSERT, UPDATE
AS
BEGIN
   if exists(select * from DIC_PayMethods t join Inserted i on i.code = t.code where t.id <> i.id)
   begin
      raiserror (50007, 16, 127)
      rollback  transaction
      return
   end
end
go



IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.DIC_EconomicSector_UniqueCode'))
DROP TRIGGER dbo.DIC_EconomicSector_UniqueCode
GO

CREATE TRIGGER dbo.DIC_EconomicSector_UniqueCode on dbo.DIC_EconomicSector
WITH EXECUTE AS CALLER
FOR INSERT, UPDATE
AS
BEGIN
   if exists(select * from DIC_EconomicSector t join Inserted i on i.code = t.code where t.id <> i.id)
   begin
      raiserror (50007, 16, 127)
      rollback  transaction
      return
   end
end
go



IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.DIC_CurrencyOperationCodes_UniqueCode'))
DROP TRIGGER dbo.DIC_CurrencyOperationCodes_UniqueCode
GO

CREATE TRIGGER dbo.DIC_CurrencyOperationCodes_UniqueCode on dbo.DIC_CurrencyOperationCodes
WITH EXECUTE AS CALLER
FOR INSERT, UPDATE
AS
BEGIN
   if exists(select * from DIC_CurrencyOperationCodes t join Inserted i on i.code = t.code where t.id <> i.id)
   begin
      raiserror (50007, 16, 127)
      rollback  transaction
      return
   end
end
go



IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.DIC_CurrencyClauses_UniqueCode'))
DROP TRIGGER dbo.DIC_CurrencyClauses_UniqueCode
GO

CREATE TRIGGER dbo.DIC_CurrencyClauses_UniqueCode on dbo.DIC_CurrencyClauses
WITH EXECUTE AS CALLER
FOR INSERT, UPDATE
AS
BEGIN
   if exists(select * from DIC_CurrencyClauses t join Inserted i on i.code = t.code where t.id <> i.id)
   begin
      raiserror (50007, 16, 127)
      rollback  transaction
      return
   end
end
go



IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.DIC_ContractStatuses_UniqueCode'))
DROP TRIGGER dbo.DIC_ContractStatuses_UniqueCode
GO

CREATE TRIGGER dbo.DIC_ContractStatuses_UniqueCode on dbo.DIC_ContractStatuses
WITH EXECUTE AS CALLER
FOR INSERT, UPDATE
AS
BEGIN
   if exists(select * from DIC_ContractStatuses t join Inserted i on i.code = t.code where t.id <> i.id)
   begin
      raiserror (50007, 16, 127)
      rollback  transaction
      return
   end
end
go



IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.DIC_Regions_UniqueCode'))
DROP TRIGGER dbo.DIC_Regions_UniqueCode
GO

CREATE TRIGGER dbo.DIC_Regions_UniqueCode on dbo.DIC_Regions
WITH EXECUTE AS CALLER
FOR INSERT, UPDATE
AS
BEGIN
   if exists(select * from DIC_Regions t join Inserted i on i.code = t.code where t.id <> i.id)
   begin
      raiserror (50007, 16, 127)
      rollback  transaction
      return
   end
end
go



IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.DIC_PeriodTypes_UniqueCode'))
DROP TRIGGER dbo.DIC_PeriodTypes_UniqueCode
GO

CREATE TRIGGER dbo.DIC_PeriodTypes_UniqueCode on dbo.DIC_PeriodTypes
WITH EXECUTE AS CALLER
FOR INSERT, UPDATE
AS
BEGIN
   if exists(select * from DIC_PeriodTypes t join Inserted i on i.code = t.code where t.id <> i.id)
   begin
      raiserror (50007, 16, 127)
      rollback  transaction
      return
   end
end
go



IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.DIC_PaymentStatuses_UniqueCode'))
DROP TRIGGER dbo.DIC_PaymentStatuses_UniqueCode
GO

CREATE TRIGGER dbo.DIC_PaymentStatuses_UniqueCode on dbo.DIC_PaymentStatuses
WITH EXECUTE AS CALLER
FOR INSERT, UPDATE
AS
BEGIN
   if exists(select * from DIC_PaymentStatuses t join Inserted i on i.code = t.code where t.id <> i.id)
   begin
      raiserror (50007, 16, 127)
      rollback  transaction
      return
   end
end
go



IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.DIC_PaymentDocTypes_UniqueCode'))
DROP TRIGGER dbo.DIC_PaymentDocTypes_UniqueCode
GO

CREATE TRIGGER dbo.DIC_PaymentDocTypes_UniqueCode on dbo.DIC_PaymentDocTypes
WITH EXECUTE AS CALLER
FOR INSERT, UPDATE
AS
BEGIN
   if exists(select * from DIC_PaymentDocTypes t join Inserted i on i.code = t.code where t.id <> i.id)
   begin
      raiserror (50007, 16, 127)
      rollback  transaction
      return
   end
end
go



IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.DIC_LegalTypes_UniqueCode'))
DROP TRIGGER dbo.DIC_LegalTypes_UniqueCode
GO

CREATE TRIGGER dbo.DIC_LegalTypes_UniqueCode on dbo.DIC_LegalTypes
WITH EXECUTE AS CALLER
FOR INSERT, UPDATE
AS
BEGIN
   if exists(select * from DIC_LegalTypes t join Inserted i on i.code = t.code where t.id <> i.id)
   begin
      raiserror (50007, 16, 127)
      rollback  transaction
      return
   end
end
go



IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.DIC_KNP_UniqueCode'))
DROP TRIGGER dbo.DIC_KNP_UniqueCode
GO

CREATE TRIGGER dbo.DIC_KNP_UniqueCode on dbo.DIC_KNP
WITH EXECUTE AS CALLER
FOR INSERT, UPDATE
AS
BEGIN
   if exists(select * from DIC_KNP t join Inserted i on i.code = t.code where t.id <> i.id)
   begin
      raiserror (50007, 16, 127)
      rollback  transaction
      return
   end
end
go



IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.DIC_DocumentTypes_UniqueCode'))
DROP TRIGGER dbo.DIC_DocumentTypes_UniqueCode
GO

CREATE TRIGGER dbo.DIC_DocumentTypes_UniqueCode on dbo.DIC_DocumentTypes
WITH EXECUTE AS CALLER
FOR INSERT, UPDATE
AS
BEGIN
   if exists(select * from DIC_DocumentTypes t join Inserted i on i.code = t.code where t.id <> i.id)
   begin
      raiserror (50007, 16, 127)
      rollback  transaction
      return
   end
end
go



IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.DIC_ContractCategories_UniqueCode'))
DROP TRIGGER dbo.DIC_ContractCategories_UniqueCode
GO

CREATE TRIGGER dbo.DIC_ContractCategories_UniqueCode on dbo.DIC_ContractCategories
WITH EXECUTE AS CALLER
FOR INSERT, UPDATE
AS
BEGIN
   if exists(select * from DIC_ContractCategories t join Inserted i on i.code = t.code where t.id <> i.id)
   begin
      raiserror (50007, 16, 127)
      rollback  transaction
      return
   end
end
go



IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.DIC_ContractAttrs_UniqueCode'))
DROP TRIGGER dbo.DIC_ContractAttrs_UniqueCode
GO

CREATE TRIGGER dbo.DIC_ContractAttrs_UniqueCode on dbo.DIC_ContractAttrs
WITH EXECUTE AS CALLER
FOR INSERT, UPDATE
AS
BEGIN
   if exists(select * from DIC_ContractAttrs t join Inserted i on i.code = t.code where t.id <> i.id)
   begin
      raiserror (50007, 16, 127)
      rollback  transaction
      return
   end
end
go



IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.DIC_Breaches_UniqueCode'))
DROP TRIGGER dbo.DIC_Breaches_UniqueCode
GO

CREATE TRIGGER dbo.DIC_Breaches_UniqueCode on dbo.DIC_Breaches
WITH EXECUTE AS CALLER
FOR INSERT, UPDATE
AS
BEGIN
   if exists(select * from DIC_Breaches t join Inserted i on i.code = t.code where t.id <> i.id)
   begin
      raiserror (50007, 16, 127)
      rollback  transaction
      return
   end
end
go



IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.DIC_BankDivisions_UniqueCode'))
DROP TRIGGER dbo.DIC_BankDivisions_UniqueCode
GO

CREATE TRIGGER dbo.DIC_BankDivisions_UniqueCode on dbo.DIC_BankDivisions
WITH EXECUTE AS CALLER
FOR INSERT, UPDATE
AS
BEGIN
   if exists(select * from DIC_BankDivisions t join Inserted i on i.code = t.code where t.id <> i.id)
   begin
      raiserror (50007, 16, 127)
      rollback  transaction
      return
   end
end
go



IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.DIC_ContractCloseCauses_UniqueCode'))
DROP TRIGGER dbo.DIC_ContractCloseCauses_UniqueCode
GO

CREATE TRIGGER dbo.DIC_ContractCloseCauses_UniqueCode on dbo.DIC_ContractCloseCauses
WITH EXECUTE AS CALLER
FOR INSERT, UPDATE
AS
BEGIN
   if exists(select * from DIC_ContractCloseCauses t join Inserted i on i.code = t.code where t.id <> i.id)
   begin
      raiserror (50007, 16, 127)
      rollback  transaction
      return
   end
end
go



IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.DIC_CreditConditions_UniqueCode'))
DROP TRIGGER dbo.DIC_CreditConditions_UniqueCode
GO

CREATE TRIGGER dbo.DIC_CreditConditions_UniqueCode on dbo.DIC_CreditConditions
WITH EXECUTE AS CALLER
FOR INSERT, UPDATE
AS
BEGIN
   if exists(select * from DIC_CreditConditions t join Inserted i on i.code = t.code where t.id <> i.id)
   begin
      raiserror (50007, 16, 127)
      rollback  transaction
      return
   end
end
go



IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.DIC_MonitoringDays_UniqueCode'))
DROP TRIGGER dbo.DIC_MonitoringDays_UniqueCode
GO

CREATE TRIGGER dbo.DIC_MonitoringDays_UniqueCode on dbo.DIC_MonitoringDays
WITH EXECUTE AS CALLER
FOR INSERT, UPDATE
AS
BEGIN
   if exists(select * from DIC_MonitoringDays t join Inserted i on i.code = t.code where t.id <> i.id)
   begin
      raiserror (50007, 16, 127)
      rollback  transaction
      return
   end
end
go



IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.DIC_OutlookTemplateTypes_UniqueCode'))
DROP TRIGGER dbo.DIC_OutlookTemplateTypes_UniqueCode
GO

CREATE TRIGGER dbo.DIC_OutlookTemplateTypes_UniqueCode on dbo.DIC_OutlookTemplateTypes
WITH EXECUTE AS CALLER
FOR INSERT, UPDATE
AS
BEGIN
   if exists(select * from DIC_OutlookTemplateTypes t join Inserted i on i.code = t.code where t.id <> i.id)
   begin
      raiserror (50007, 16, 127)
      rollback  transaction
      return
   end
end
go



IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.DIC_ControlCardTypes_UniqueCode'))
DROP TRIGGER dbo.DIC_ControlCardTypes_UniqueCode
GO

CREATE TRIGGER dbo.DIC_ControlCardTypes_UniqueCode on dbo.DIC_ControlCardTypes
WITH EXECUTE AS CALLER
FOR INSERT, UPDATE
AS
BEGIN
   if exists(select * from DIC_ControlCardTypes t join Inserted i on i.code = t.code where t.id <> i.id)
   begin
      raiserror (50007, 16, 127)
      rollback  transaction
      return
   end
end
go



IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.DIC_CustomsRegimes_UniqueCode'))
DROP TRIGGER dbo.DIC_CustomsRegimes_UniqueCode
GO

CREATE TRIGGER dbo.DIC_CustomsRegimes_UniqueCode on dbo.DIC_CustomsRegimes
WITH EXECUTE AS CALLER
FOR INSERT, UPDATE
AS
BEGIN
   if exists(select * from DIC_CustomsRegimes t join Inserted i on i.code = t.code where t.id <> i.id)
   begin
      raiserror (50007, 16, 127)
      rollback  transaction
      return
   end
end
go



IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.DIC_DeclarationGoodsStatuses_UniqueCode'))
DROP TRIGGER dbo.DIC_DeclarationGoodsStatuses_UniqueCode
GO

CREATE TRIGGER dbo.DIC_DeclarationGoodsStatuses_UniqueCode on dbo.DIC_DeclarationGoodsStatuses
WITH EXECUTE AS CALLER
FOR INSERT, UPDATE
AS
BEGIN
   if exists(select * from DIC_DeclarationGoodsStatuses t join Inserted i on i.code = t.code where t.id <> i.id)
   begin
      raiserror (50007, 16, 127)
      rollback  transaction
      return
   end
end
go



IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.DIC_DeclarationStatuses_UniqueCode'))
DROP TRIGGER dbo.DIC_DeclarationStatuses_UniqueCode
GO

CREATE TRIGGER dbo.DIC_DeclarationStatuses_UniqueCode on dbo.DIC_DeclarationStatuses
WITH EXECUTE AS CALLER
FOR INSERT, UPDATE
AS
BEGIN
   if exists(select * from DIC_DeclarationStatuses t join Inserted i on i.code = t.code where t.id <> i.id)
   begin
      raiserror (50007, 16, 127)
      rollback  transaction
      return
   end
end
go



IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.DIC_CustomsProcedures_UniqueCode'))
DROP TRIGGER dbo.DIC_CustomsProcedures_UniqueCode
GO

CREATE TRIGGER dbo.DIC_CustomsProcedures_UniqueCode on dbo.DIC_CustomsProcedures
WITH EXECUTE AS CALLER
FOR INSERT, UPDATE
AS
BEGIN
   if exists(select * from DIC_CustomsProcedures t join Inserted i on i.code = t.code where t.id <> i.id)
   begin
      raiserror (50007, 16, 127)
      rollback  transaction
      return
   end
end
go



IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.DIC_DocumentTypePurpose_UniqueCode'))
DROP TRIGGER dbo.DIC_DocumentTypePurpose_UniqueCode
GO

CREATE TRIGGER dbo.DIC_DocumentTypePurpose_UniqueCode on dbo.DIC_DocumentTypePurpose
WITH EXECUTE AS CALLER
FOR INSERT, UPDATE
AS
BEGIN
   if exists(select * from DIC_DocumentTypePurpose t join Inserted i on i.code = t.code where t.id <> i.id)
   begin
      raiserror (50007, 16, 127)
      rollback  transaction
      return
   end
end
go



IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.DIC_PaymentTypes_UniqueCode'))
DROP TRIGGER dbo.DIC_PaymentTypes_UniqueCode
GO

CREATE TRIGGER dbo.DIC_PaymentTypes_UniqueCode on dbo.DIC_PaymentTypes
WITH EXECUTE AS CALLER
FOR INSERT, UPDATE
AS
BEGIN
   if exists(select * from DIC_PaymentTypes t join Inserted i on i.code = t.code where t.id <> i.id)
   begin
      raiserror (50007, 16, 127)
      rollback  transaction
      return
   end
end
go



IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.DIC_DocumentStatuses_UniqueCode'))
DROP TRIGGER dbo.DIC_DocumentStatuses_UniqueCode
GO

CREATE TRIGGER dbo.DIC_DocumentStatuses_UniqueCode on dbo.DIC_DocumentStatuses
WITH EXECUTE AS CALLER
FOR INSERT, UPDATE
AS
BEGIN
   if exists(select * from DIC_DocumentStatuses t join Inserted i on i.code = t.code where t.id <> i.id)
   begin
      raiserror (50007, 16, 127)
      rollback  transaction
      return
   end
end
go



IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.DIC_FCYFTCodeAll_UniqueCode'))
DROP TRIGGER dbo.DIC_FCYFTCodeAll_UniqueCode
GO

CREATE TRIGGER dbo.DIC_FCYFTCodeAll_UniqueCode on dbo.DIC_FCYFTCodeAll
WITH EXECUTE AS CALLER
FOR INSERT, UPDATE
AS
BEGIN
   if exists(select * from DIC_FCYFTCodeAll t join Inserted i on i.code = t.code where t.id <> i.id)
   begin
      raiserror (50007, 16, 127)
      rollback  transaction
      return
   end
end
go



IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.DIC_FCYFTCodeCUS_UniqueCode'))
DROP TRIGGER dbo.DIC_FCYFTCodeCUS_UniqueCode
GO

CREATE TRIGGER dbo.DIC_FCYFTCodeCUS_UniqueCode on dbo.DIC_FCYFTCodeCUS
WITH EXECUTE AS CALLER
FOR INSERT, UPDATE
AS
BEGIN
   if exists(select * from DIC_FCYFTCodeCUS t join Inserted i on i.code = t.code where t.id <> i.id)
   begin
      raiserror (50007, 16, 127)
      rollback  transaction
      return
   end
end
go



IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.DIC_PaymentCancelationCause_UniqueCode'))
DROP TRIGGER dbo.DIC_PaymentCancelationCause_UniqueCode
GO

CREATE TRIGGER dbo.DIC_PaymentCancelationCause_UniqueCode on dbo.DIC_PaymentCancelationCause
WITH EXECUTE AS CALLER
FOR INSERT, UPDATE
AS
BEGIN
   if exists(select * from DIC_PaymentCancelationCause t join Inserted i on i.code = t.code where t.id <> i.id)
   begin
      raiserror (50007, 16, 127)
      rollback  transaction
      return
   end
end
go



IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.DIC_SignatoriesDocType_UniqueCode'))
DROP TRIGGER dbo.DIC_SignatoriesDocType_UniqueCode
GO

CREATE TRIGGER dbo.DIC_SignatoriesDocType_UniqueCode on dbo.DIC_SignatoriesDocType
WITH EXECUTE AS CALLER
FOR INSERT, UPDATE
AS
BEGIN
   if exists(select * from DIC_SignatoriesDocType t join Inserted i on i.code = t.code where t.id <> i.id)
   begin
      raiserror (50007, 16, 127)
      rollback  transaction
      return
   end
end
go



IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.DIC_BankAccountTypes_UniqueCode'))
DROP TRIGGER dbo.DIC_BankAccountTypes_UniqueCode
GO

CREATE TRIGGER dbo.DIC_BankAccountTypes_UniqueCode on dbo.DIC_BankAccountTypes
WITH EXECUTE AS CALLER
FOR INSERT, UPDATE
AS
BEGIN
   if exists(select * from DIC_BankAccountTypes t join Inserted i on i.code = t.code where t.id <> i.id)
   begin
      raiserror (50007, 16, 127)
      rollback  transaction
      return
   end
end
go



IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.DIC_ComplianceBankAccounts_UniqueCode'))
DROP TRIGGER dbo.DIC_ComplianceBankAccounts_UniqueCode
GO

CREATE TRIGGER dbo.DIC_ComplianceBankAccounts_UniqueCode on dbo.DIC_ComplianceBankAccounts
WITH EXECUTE AS CALLER
FOR INSERT, UPDATE
AS
BEGIN
   if exists(select * from DIC_ComplianceBankAccounts t join Inserted i on i.code = t.code where t.id <> i.id)
   begin
      raiserror (50007, 16, 127)
      rollback  transaction
      return
   end
end
go



IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.DIC_ComplianceEKNPTreasurys_UniqueCode'))
DROP TRIGGER dbo.DIC_ComplianceEKNPTreasurys_UniqueCode
GO

CREATE TRIGGER dbo.DIC_ComplianceEKNPTreasurys_UniqueCode on dbo.DIC_ComplianceEKNPTreasurys
WITH EXECUTE AS CALLER
FOR INSERT, UPDATE
AS
BEGIN
   if exists(select * from DIC_ComplianceEKNPTreasurys t join Inserted i on i.code = t.code where t.id <> i.id)
   begin
      raiserror (50007, 16, 127)
      rollback  transaction
      return
   end
end
go



IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.DIC_ClientSendDataExceptionsDocType_UniqueCode'))
DROP TRIGGER dbo.DIC_ClientSendDataExceptionsDocType_UniqueCode
GO

CREATE TRIGGER dbo.DIC_ClientSendDataExceptionsDocType_UniqueCode on dbo.DIC_ClientSendDataExceptionsDocType
WITH EXECUTE AS CALLER
FOR INSERT, UPDATE
AS
BEGIN
   if exists(select * from DIC_ClientSendDataExceptionsDocType t join Inserted i on i.code = t.code where t.id <> i.id)
   begin
      raiserror (50007, 16, 127)
      rollback  transaction
      return
   end
end
go



IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.DIC_CitistoreTemplateTypes_UniqueCode'))
DROP TRIGGER dbo.DIC_CitistoreTemplateTypes_UniqueCode
GO

CREATE TRIGGER dbo.DIC_CitistoreTemplateTypes_UniqueCode on dbo.DIC_CitistoreTemplateTypes
WITH EXECUTE AS CALLER
FOR INSERT, UPDATE
AS
BEGIN
   if exists(select * from DIC_CitistoreTemplateTypes t join Inserted i on i.code = t.code where t.id <> i.id)
   begin
      raiserror (50007, 16, 127)
      rollback  transaction
      return
   end
end
go



IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.DIC_EditTemplates_UniqueCode'))
DROP TRIGGER dbo.DIC_EditTemplates_UniqueCode
GO

CREATE TRIGGER dbo.DIC_EditTemplates_UniqueCode on dbo.DIC_EditTemplates
WITH EXECUTE AS CALLER
FOR INSERT, UPDATE
AS
BEGIN
   if exists(select * from DIC_EditTemplates t join Inserted i on i.code = t.code where t.id <> i.id)
   begin
      raiserror (50007, 16, 127)
      rollback  transaction
      return
   end
end
go



IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.DIC_ReportApp3Statuses_UniqueCode'))
DROP TRIGGER dbo.DIC_ReportApp3Statuses_UniqueCode
GO

CREATE TRIGGER dbo.DIC_ReportApp3Statuses_UniqueCode on dbo.DIC_ReportApp3Statuses
WITH EXECUTE AS CALLER
FOR INSERT, UPDATE
AS
BEGIN
   if exists(select * from DIC_ReportApp3Statuses t join Inserted i on i.code = t.code where t.id <> i.id)
   begin
      raiserror (50007, 16, 127)
      rollback  transaction
      return
   end
end
go



IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.DIC_ReportApp3RecipientsTypes_UniqueCode'))
DROP TRIGGER dbo.DIC_ReportApp3RecipientsTypes_UniqueCode
GO

CREATE TRIGGER dbo.DIC_ReportApp3RecipientsTypes_UniqueCode on dbo.DIC_ReportApp3RecipientsTypes
WITH EXECUTE AS CALLER
FOR INSERT, UPDATE
AS
BEGIN
   if exists(select * from DIC_ReportApp3RecipientsTypes t join Inserted i on i.code = t.code where t.id <> i.id)
   begin
      raiserror (50007, 16, 127)
      rollback  transaction
      return
   end
end
go



IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.DIC_RequirementsOfAFR_UniqueCode'))
DROP TRIGGER dbo.DIC_RequirementsOfAFR_UniqueCode
GO

CREATE TRIGGER dbo.DIC_RequirementsOfAFR_UniqueCode on dbo.DIC_RequirementsOfAFR
WITH EXECUTE AS CALLER
FOR INSERT, UPDATE
AS
BEGIN
   if exists(select * from DIC_RequirementsOfAFR t join Inserted i on i.code = t.code where t.id <> i.id)
   begin
      raiserror (50007, 16, 127)
      rollback  transaction
      return
   end
end
go



IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.DIC_ThirdPersonAddBasis_UniqueCode'))
DROP TRIGGER dbo.DIC_ThirdPersonAddBasis_UniqueCode
GO

CREATE TRIGGER dbo.DIC_ThirdPersonAddBasis_UniqueCode on dbo.DIC_ThirdPersonAddBasis
WITH EXECUTE AS CALLER
FOR INSERT, UPDATE
AS
BEGIN
   if exists(select * from DIC_ThirdPersonAddBasis t join Inserted i on i.code = t.code where t.id <> i.id)
   begin
      raiserror (50007, 16, 127)
      rollback  transaction
      return
   end
end
go



IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.DIC_SignatoriesTemplates_UniqueCode'))
DROP TRIGGER dbo.DIC_SignatoriesTemplates_UniqueCode
GO

CREATE TRIGGER dbo.DIC_SignatoriesTemplates_UniqueCode on dbo.DIC_SignatoriesTemplates
WITH EXECUTE AS CALLER
FOR INSERT, UPDATE
AS
BEGIN
   if exists(select * from DIC_SignatoriesTemplates t join Inserted i on i.code = t.code where t.id <> i.id)
   begin
      raiserror (50007, 16, 127)
      rollback  transaction
      return
   end
end
go



IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.DIC_ReasonSendingPaymentForRevision_UniqueCode'))
DROP TRIGGER dbo.DIC_ReasonSendingPaymentForRevision_UniqueCode
GO

CREATE TRIGGER dbo.DIC_ReasonSendingPaymentForRevision_UniqueCode on dbo.DIC_ReasonSendingPaymentForRevision
WITH EXECUTE AS CALLER
FOR INSERT, UPDATE
AS
BEGIN
   if exists(select * from DIC_ReasonSendingPaymentForRevision t join Inserted i on i.code = t.code where t.id <> i.id)
   begin
      raiserror (50007, 16, 127)
      rollback  transaction
      return
   end
end
go



IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.DIC_EconomicTradeType_UniqueCode'))
DROP TRIGGER dbo.DIC_EconomicTradeType_UniqueCode
GO

CREATE TRIGGER dbo.DIC_EconomicTradeType_UniqueCode on dbo.DIC_EconomicTradeType
WITH EXECUTE AS CALLER
FOR INSERT, UPDATE
AS
BEGIN
   if exists(select * from DIC_EconomicTradeType t join Inserted i on i.code = t.code where t.id <> i.id)
   begin
      raiserror (50007, 16, 127)
      rollback  transaction
      return
   end
end
go



IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.DIC_WeekendMaster_Type_UniqueCode'))
DROP TRIGGER dbo.DIC_WeekendMaster_Type_UniqueCode
GO

CREATE TRIGGER dbo.DIC_WeekendMaster_Type_UniqueCode on dbo.DIC_WeekendMaster_Type
WITH EXECUTE AS CALLER
FOR INSERT, UPDATE
AS
BEGIN
   if exists(select * from DIC_WeekendMaster_Type t join Inserted i on i.code = t.code where t.id <> i.id)
   begin
      raiserror (50007, 16, 127)
      rollback  transaction
      return
   end
end
go



IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.DIC_RequirementsOfAFRType_UniqueCode'))
DROP TRIGGER dbo.DIC_RequirementsOfAFRType_UniqueCode
GO

CREATE TRIGGER dbo.DIC_RequirementsOfAFRType_UniqueCode on dbo.DIC_RequirementsOfAFRType
WITH EXECUTE AS CALLER
FOR INSERT, UPDATE
AS
BEGIN
   if exists(select * from DIC_RequirementsOfAFRType t join Inserted i on i.code = t.code where t.id <> i.id)
   begin
      raiserror (50007, 16, 127)
      rollback  transaction
      return
   end
end
go



IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.DIC_GoodsPreCheck_UniqueCode'))
DROP TRIGGER dbo.DIC_GoodsPreCheck_UniqueCode
GO

CREATE TRIGGER dbo.DIC_GoodsPreCheck_UniqueCode on dbo.DIC_GoodsPreCheck
WITH EXECUTE AS CALLER
FOR INSERT, UPDATE
AS
BEGIN
   if exists(select * from DIC_GoodsPreCheck t join Inserted i on i.code = t.code where t.id <> i.id)
   begin
      raiserror (50007, 16, 127)
      rollback  transaction
      return
   end
end
go



IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.DIC_SpecialControlNBGrounds_UniqueCode'))
DROP TRIGGER dbo.DIC_SpecialControlNBGrounds_UniqueCode
GO

CREATE TRIGGER dbo.DIC_SpecialControlNBGrounds_UniqueCode on dbo.DIC_SpecialControlNBGrounds
WITH EXECUTE AS CALLER
FOR INSERT, UPDATE
AS
BEGIN
   if exists(select * from DIC_SpecialControlNBGrounds t join Inserted i on i.code = t.code where t.id <> i.id)
   begin
      raiserror (50007, 16, 127)
      rollback  transaction
      return
   end
end
go



IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.DIC_Languages_UniqueCode'))
DROP TRIGGER dbo.DIC_Languages_UniqueCode
GO

CREATE TRIGGER dbo.DIC_Languages_UniqueCode on dbo.DIC_Languages
WITH EXECUTE AS CALLER
FOR INSERT, UPDATE
AS
BEGIN
   if exists(select * from DIC_Languages t join Inserted i on i.code = t.code where t.id <> i.id)
   begin
      raiserror (50007, 16, 127)
      rollback  transaction
      return
   end
end
go



IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.DIC_SignatureTemplateTypes_UniqueCode'))
DROP TRIGGER dbo.DIC_SignatureTemplateTypes_UniqueCode
GO

CREATE TRIGGER dbo.DIC_SignatureTemplateTypes_UniqueCode on dbo.DIC_SignatureTemplateTypes
WITH EXECUTE AS CALLER
FOR INSERT, UPDATE
AS
BEGIN
   if exists(select * from DIC_SignatureTemplateTypes t join Inserted i on i.code = t.code where t.id <> i.id)
   begin
      raiserror (50007, 16, 127)
      rollback  transaction
      return
   end
end
go




IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.DIC_ContractTypes_UniqueCode'))
DROP TRIGGER dbo.DIC_ContractTypes_UniqueCode
GO

CREATE TRIGGER dbo.DIC_ContractTypes_UniqueCode on dbo.DIC_ContractTypes
WITH EXECUTE AS CALLER
FOR INSERT, UPDATE
AS
BEGIN
   if exists(select * from DIC_ContractTypes t join Inserted i on i.code = t.code where t.id <> i.id)
   begin
      raiserror (50007, 16, 127)
      rollback  transaction
      return
   end
end
go



IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'dbo.DIC_TaxAuthorities_UniqueCode'))
DROP TRIGGER dbo.DIC_TaxAuthorities_UniqueCode
GO

CREATE TRIGGER dbo.DIC_TaxAuthorities_UniqueCode on dbo.DIC_TaxAuthorities
WITH EXECUTE AS CALLER
FOR INSERT, UPDATE
AS
BEGIN
   if exists(select * from DIC_TaxAuthorities t join Inserted i on i.code = t.code where t.id <> i.id)
   begin
      raiserror (50007, 16, 127)
      rollback  transaction
      return
   end
end
go