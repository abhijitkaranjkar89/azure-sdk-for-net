# Release History

## 4.0.0-beta.4 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 4.0.0-beta.3 (2022-02-10)

### Features Added
- Added the `DocumentField.AsCurrency` method and the `DocumentFieldType.Currency` enum value to support analyzed currency fields.
- Added the `Languages` property to the `AnalyzeResult` class. This property is populated when using the `prebuilt-read` model and holds information about the languages in which the document is written.
- Added the `Tags` property to the `BuildModelOptions` class. This property can be used to specify custom key-value attributes associated with the model to be built.
- Added the `Tags` property to the `DocumentModelInfo` and to the `ModelOperationInfo` classes.
- Added the `BuildMode` property to `DocTypeInfo` to indicate the technique used when building the correspoding model.
- Added the `DocumentAnalysisModelFactory` static class to the `Azure.AI.FormRecognizer.DocumentAnalysis` namespace. It contains methods for instantiating `DocumentAnalysis` models for mocking.

### Breaking Changes
- Added the required parameter `buildMode` to `StartBuildModel` methods. Users must now choose the technique (`Template` or `Neural`) used to build models. For more information about the available build modes and their differences, see [here](https://aka.ms/azsdk/formrecognizer/buildmode).
- Added the `tags` parameter to the `GetCopyAuthorization` methods.
- Added the `tags` parameter to the `StartCreateComposedModel` methods.
- The `DocumentAnalysisClient` and `DocumentModelAdministrationClient` now target the service version `2022-01-30-preview`, so they don't support `2021-09-30-preview` anymore.

### Bugs Fixed
- FormRecognizerAudience and DocumentAnalysisAudience have been added to allow the user to select the Azure cloud where the resource is located. Issue [17192](https://github.com/azure/azure-sdk-for-net/issues/17192).

## 4.0.0-beta.2 (2021-11-09)

### Bugs Fixed
- `BuildModelOperation` and `CopyModelOperation` correctly populate the `PercentCompleted` property, instead of always having a value of `0`.

## 4.0.0-beta.1 (2021-10-07)
> Note: Starting with version `2021-09-30-preview`, a new set of clients were introduced to leverage the newest features of the Form Recognizer service. Please see the [Migration Guide](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/MigrationGuide.md) for detailed instructions on how to update application code from client library version `3.1.X` or lower to the latest version.

### Features Added
- This version of the SDK defaults to the latest supported Service API version, which currently is `2021_09_30_preview`.
- Added class `DocumentAnalysisClient` to the new `Azure.AI.FormRecognizer.DocumentAnalysis` namespace. This will be the main client to use when analyzing documents for service versions `2021_09_30_preview` and higher. For lower versions, please use the `FormRecognizerClient`.
- Added methods `StartAnalyzeDocument` and `StartAnalyzeDocumentFromUri` to `DocumentAnalysisClient`. These methods substitute all existing `StartRecognize<...>` methods, such as `StartRecognizeContent` and `StartRecognizeReceiptsFromUri`.
- Added class `DocumentModelAdministrationClient` to the new `Azure.AI.FormRecognizer.DocumentAnalysis` namespace. This will be the main client to use for model management for service versions `2021_09_30_preview` and higher. For lower versions, please use the `FormTrainingClient`.
- Added methods `StartBuildModel`, `StartCopyModel`, `StartCreateComposedModel`, `GetCopyAuthorization`, `GetModel`, `GetModels`, `GetAccountProperties`, `DeleteModel`, `GetOperation`, `GetOperations`, and the equivalent async methods to `DocumentModelAdministrationClient`.

## 3.1.1 (2021-06-08)

### Key Bug Fixes
- Handles invoices and other recognition operations that return a `FormField` with `Text` and no `BoundingBox` or `Page` information.

## 3.1.0 (2021-05-26)

### New Features
- This General Availability (GA) release marks the stability of the changes introduced in package versions `3.1.0-beta.1` through `3.1.0-beta.4`.
- Updated the `FormRecognizerModelFactory` class to support missing model types for mocking.
- Added support for service version `2.0`. This can be specified in the `FormRecognizerClientOptions` object under the `ServiceVersion` enum.
By default the SDK targets latest supported service version.

### Breaking changes
- The client defaults to the latest supported service version, which currently is `2.1`.
- Renamed `Id` for `Identity` in all the `StartRecognizeIdDocuments` functionalities. For example, the name of the method is now `StartRecognizeIdentityDocuments`.
- Renamed the model `ReadingOrder` to `FormReadingOrder`.
- The model `TextAppearance` now includes the properties `StyleName` and `StyleConfidence` that were part of the `TextStyle` object.
- Removed the model `TextStyle`.
- Renamed the method `AsCountryCode` to `AsCountryRegion`.
- Removed type `FieldValueGender`.
- Removed value `Gender` from the model `FieldValuetype`.

## 3.0.1 (2021-04-09)

### Key Bug Fixes
- Updated dependency versions.

## 3.1.0-beta.4 (2021-04-06)

### New Features
- Added support for pre-built passports and US driver licenses recognition with the `StartRecognizeIdDocuments` API.
- Expanded the set of document languages that can be provided to the `StartRecognizeContent` API.
- Added property `Pages` to `RecognizeBusinessCardsOptions`, `RecognizeCustomFormsOptions`, `RecognizeInvoicesOptions`, and `RecognizeReceiptsOptions` to specify the page numbers to recognize.
- Added property `ReadingOrder` to `RecognizeContentOptions` to specify the order in which recognized text lines are returned.

### Breaking changes
- The client defaults to the latest supported service version, which currently is `2.1-preview.3`.
- `StartRecognizeCustomForms` now throws a `RequestFailedException` when an invalid file is passed.

## 3.1.0-beta.3 (2021-03-09)

### New Features
- Added protected constructors for mocking to `Operation` types, such as `TrainingOperation` and `RecognizeContentOperation`.

## 3.1.0-beta.2 (2021-02-09)
### Breaking changes
- Renamed the model `Appearance` to `TextAppearance`.
- Renamed the model `Style` to `TextStyle`.
- Renamed the extensible enum `TextStyle` to `TextStyleName`.
- Changed object type for property `Pages` under `RecognizeContentOptions` from `IEnumerable` to `IList`.
- Changed model type of `Locale` from `string` to `FormRecognizerLocale` in `RecognizeBusinessCardsOptions`, `RecognizeInvoicesOptions`, and `RecognizeReceiptsOptions`.
- Changed model type of `Language` from `string` to `FormRecognizerLanguage` in `RecognizeContentOptions`.

## 3.1.0-beta.1 (2020-11-23)

### Breaking changes
- It defaults to the latest supported service version, which currently is `2.1-preview.2`.

### New Features
- Added integration for ASP.NET Core.
- Added support for pre-built business card recognition.
- Added support for pre-built invoices recognition.
- Added support for providing locale information when recognizing receipts and business cards. Supported locales include EN-US, EN-AU, EN-CA, EN-GB, EN-IN.
- Added support for providing the document language in `StartRecognizeContent` when recognizing a form.
- Added support to train and recognize custom forms with selection marks such as check boxes and radio buttons. This functionality is only available in train with labels scenarios.
- Added support to `StartRecognizeContent` to recognize selection marks such as check boxes and radio buttons.
- Added ability to create a composed model from the `FormTrainingClient` by calling method `StartCreateComposedModel`.
- Added ability to pass parameter `ModelName` to `StartTraining` methods.
- Added the properties `ModelName` and `Properties` to types `CustomFormModel` and `CustomFormModelInfo`.
- Added type `CustomFormModelProperties` that includes information like if a model is a composed model.
- Added property `ModelId` to `CustomFormSubmodel` and `TrainingDocumentInfo`.
- Added properties `ModelId` and `FormTypeConfidence` to `RecognizedForm`.
- Added property `Appearance` to `FormLine` to indicate the style of the extracted text. For example, "handwriting" or "other".
- Added property `BoundingBox` to `FormTable`.
- Added support for `ContentType` `image/bmp` in recognize content and prebuilt models.
- Added property `Pages` to `RecognizeContentOptions` to specify the page numbers to analyze.

## 3.0.0 (2020-08-20)

- First stable release of the Azure.AI.FormRecognizer package.

### Breaking changes

- Renamed the model `BoundingBox` to `FieldBoundingBox`.

### New Features

- Added `FormRecognizerModelFactory` static class to support mocking model types.

## 3.0.0-preview.2 (2020-08-18)

### Fixed
- Bug in TaskExtensions.EnsureCompleted method that causes it to unconditionally throw an exception in the environments with synchronization context

## 3.0.0-preview.1 (2020-08-11)

### Breaking changes

- The library now targets the service's v2.0 API, instead of the v2.0-preview.1 API.
- Updated version number from `1.0.0-preview.5` to `3.0.0-preview.1`.
- Added models `RecognizeCustomFormsOptions`, `RecognizeReceiptsOptions`, and `RecognizeContentOptions` instead of a generic `RecognizeOptions` to support passing configurable options to recognize APIs.
- Added model `TrainingOptions` to support passing configurable options to training APIs. This type now includes `TrainingFileFilter`.
- Renamed the `FieldValue` property `Type` to `ValueType`.
- Renamed the `TrainingDocumentInfo` property `DocumentName` to `Name`.
- Renamed the `TrainingFileFilter` property `IncludeSubFolders` to `IncludeSubfolders`.
- Renamed the `FormRecognizerClient.StartRecognizeCustomForms` parameter `formFileStream` to `form`.
- Renamed the `FormRecognizerClient.StartRecognizeCustomFormsFromUri` parameter `formFileUri` to `formUri`.
- Renamed `CustomFormModelStatus.Training` to `CustomFormModelStatus.Creating`.
- Renamed `FormValueType.Integer` to `FormValueType.Int64`.
- `FormField` property `ValueData` is now set to null if there is no text, bounding box or page number associated with it.

### Fixes

- Made the `TrainingFileFilter` constructor public.
- Fixed a bug in which `FormTrainingClient.GetCustomModel` threw an exception if the model was still being created ([#13813](https://github.com/Azure/azure-sdk-for-net/issues/13813)).
- Fixed a bug in which the `BoundingBox` indexer and `ToString` method threw a `NullReferenceException` if it had no points ([#13971](https://github.com/Azure/azure-sdk-for-net/issues/13971)).
- Fixed a bug in which a default `FieldValue` threw a `NullReferenceException` if `AsString` was called. The method now returns `null`.

### New Features

- Added diagnostics functionality to the `FormRecognizerClient`, to the `FormTrainingClient` and to long-running operation types.

## 1.0.0-preview.4 (2020-07-07)

### Renames

- Property `RequestedOn` renamed to `TrainingStartedOn` on `CustomFormModel` and `CustomFormModelInfo`.
- Property `CompletedOn` renamed to `TrainingCompletedOn` on `CustomFormModel` and `CustomFormModelInfo`.
- Property `LabelText` renamed to `LabelData` on `FormField`.
- Property `ValueText` renamed to `ValueData` on `FormField`.
- Property `TextContent` renamed to `FieldElements` on `FieldData` and `FormTableCell`.
- Parameter `formUrl` in `StartRecognizeContent` has been renamed to `formUri`.
- Parameter `receiptUrl` in `StartRecognizeReceipts` has been renamed to `receiptUri`.
- Parameter `accessToken` in `CopyAuthorization.FromJson` has been renamed to `copyAuthorization`.
- Parameter `IncludeTextContent` in `RecognizeOptions` has been renamed to `IncludeFieldElements`.
- Model `FieldText` renamed to `FieldData`.
- Model `FormContent` renamed to `FormElement`.

### Other breaking changes

- Property `CopyAuthorization.ExpiresOn` type is now `DateTimeOffset`.
- `RecognizedReceipt` and `RecognizedReceiptsCollection` classes removed. Receipt field values must now be obtained from a `RecognizedForm`.

### Fixes

- Fixed a bug in which the `FormPage.TextAngle` property sometimes fell out of the (-180, 180] range ([#13082](https://github.com/Azure/azure-sdk-for-net/issues/13082)).

## 1.0.0-preview.3 (06-10-2020)

### Renames

- `FormRecognizerError.Code` renamed to `FormRecognizerError.ErrorCode`.
- `FormTrainingClient.GetModelInfos` renamed to `FormTrainingClient.GetCustomModels`.
- Property `CreatedOn` in types `CustomFormModel` and `CustomFormModelInfo` renamed to `RequestedOn`.
- Property `LastModified` in types `CustomFormModel` and `CustomFormModelInfo` renamed to `CompletedOn`.
- Property `Models` in `CustomFormModel` renamed to `Submodels`.
- Type `CustomFormSubModel` renamed to `CustomFormSubmodel`.
- `ContentType` renamed to `FormContentType`.
- Parameter `useLabels` in `FormTrainingClient.StartTraining` renamed to `useTrainingLabels`.
- Parameter `trainingFiles` in `FormTrainingClient.StartTraining` renamed to `trainingFilesUri`.
- Parameter `filter` in `FormTrainingClient.StartTraining` renamed to `trainingFileFilter`.
- Removed `Type` suffix from all `FieldValueType` values.
- Parameters `formFileStream` and `formFileUri` in `StartRecognizeContent` have been renamed to `form` and `formUrl` respectively.
- Parameters `receiptFileStream` and `receiptFileUri` in `StartRecognizeReceipts` have been renamed to `receipt` and `receiptUrl` respectively.

### Other breaking changes

- `FormPageRange` is now a `struct`.
- `RecognizeContentOperation` now returns a `FormPageCollection`.
- `RecognizeReceiptsOperation` now returns a `RecognizedReceiptCollection`.
- `RecognizeCustomFormsOperation` now returns a `RecognizedFormCollection`.
- In preparation for service-side changes, `FieldValue.AsInt32` has been replaced by `FieldValue.AsInt64`, which returns a `long`.
- Parameter `useTrainingLabels` is now required for `FormTrainingClient.StartTraining`.
- Protected constructors have been removed from `Operation` types, such as `TrainingOperation` or `RecognizeContentOperation`.
- `USReceipt`, `USReceiptItem`, `USReceiptType` and `FormField{T}` types removed. Information about a `RecognizedReceipt` must now be extracted from its `RecognizedForm`.
- `ReceiptLocale` removed from `RecognizedReceipt`.
- An `InvalidOperationException` is now raised if trying to access the `Value` property of a `TrainingOperation` when a trained model is invalid.
- A `RequestFailedException` is now raised if a model with `status=="invalid"` is returned from the `StartTraining` and `StartTrainingAsync` methods.
- A `RequestFailedException` is now raised if an operation like `StartRecognizeReceipts` or `StartRecognizeContent` fails.
- An `InvalidOperationException` is now raised if trying to access the `Value` property of a `xxOperation` object when the executed operation failed.
- Method `GetFormTrainingClient` has been removed from `FormRecognizerClient` and `GetFormRecognizerClient` has been added to `FormTrainingClient`.

### New Features

- `FormRecognizerClient` and `FormTrainingClient` support authentication with Azure Active Directory.
- Support to copy a custom model from one Form Recognizer resource to another.
- Headers and query parameters that were marked as `REDACTED` in error messages and logs are now exposed by default.

### Fixes

- Custom form recognition without labels can now handle multipaged forms ([#11881](https://github.com/Azure/azure-sdk-for-net/issues/11881)).
- `RecognizedForm.Pages` now only contains pages whose numbers are within `RecognizedForm.PageRange`.
- `FieldText.TextContent` cannot be `null` anymore, and it will be empty when no element is returned from the service.
- Custom form recognition with labels can now parse results from forms that do not contain all of the expected labels ([#11821](https://github.com/Azure/azure-sdk-for-net/issues/11821)).
- `FormRecognizerClient.StartRecognizeCustomFormsFromUri` now works with URIs that contain blank spaces, encoded or not ([#11564](https://github.com/Azure/azure-sdk-for-net/issues/11564)).
- Receipt recognition can now parse results from forms that contain blank pages.

## 1.0.0-preview.2 (05-06-2020)

### Fixes

- All of `FormRecognizerClient`'s `FormRecognizerClientOptions` are now passed to the client returned by
    `FormRecognizerClient.GetFormTrainingClient`.

## 1.0.0-preview.1 (04-23-2020)
This is the first preview Azure Form Recognizer client library that follows the [.NET Azure SDK Design Guidelines][guidelines].
This library replaces the package [`Microsoft.Azure.CognitiveServices.FormRecognizer`][cognitiveServices_fr_nuget].

This package's [documentation][readme] and [samples][samples] demonstrate the new API.

### Major changes from `Microsoft.Azure.CognitiveServices.FormRecognizer`
- This library supports only the Form Recognizer Service v2.0-preview API
- The namespace/package name for Azure Form Recognizer client library has changed from 
    `Microsoft.Azure.CognitiveServices.FormRecognizer` to `Azure.AI.FormRecognizer`
- Two client design:
  - `FormRecognizerClient` to recognize and extract fields/values on custom forms, receipts, and form content/layout.
  - `FormTrainingClient` to train custom models, and manage the custom models on your resource account.
- Different recognize methods based on input type: file stream or URI.
- File stream methods will automatically detect content-type of the input file.

[guidelines]: https://azure.github.io/azure-sdk/dotnet_introduction.html
[cognitiveServices_fr_nuget]: https://www.nuget.org/packages/Microsoft.Azure.CognitiveServices.FormRecognizer/0.8.0-preview
[readme]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/README.md
[samples]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/README.md
