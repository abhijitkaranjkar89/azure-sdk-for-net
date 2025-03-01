// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.AppConfiguration.Models;
using Azure.ResourceManager.Core;

namespace Azure.ResourceManager.AppConfiguration
{
    /// <summary> A class to add extension methods to Subscription. </summary>
    internal partial class SubscriptionExtensionClient : ArmResource
    {
        private ClientDiagnostics _configurationStoreClientDiagnostics;
        private ConfigurationStoresRestOperations _configurationStoreRestClient;
        private ClientDiagnostics _defaultClientDiagnostics;
        private AppConfigurationManagementRestOperations _defaultRestClient;

        /// <summary> Initializes a new instance of the <see cref="SubscriptionExtensionClient"/> class for mocking. </summary>
        protected SubscriptionExtensionClient()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="SubscriptionExtensionClient"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal SubscriptionExtensionClient(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        private ClientDiagnostics ConfigurationStoreClientDiagnostics => _configurationStoreClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.AppConfiguration", ConfigurationStore.ResourceType.Namespace, DiagnosticOptions);
        private ConfigurationStoresRestOperations ConfigurationStoreRestClient => _configurationStoreRestClient ??= new ConfigurationStoresRestOperations(ConfigurationStoreClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, GetApiVersionOrNull(ConfigurationStore.ResourceType));
        private ClientDiagnostics DefaultClientDiagnostics => _defaultClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.AppConfiguration", ProviderConstants.DefaultProviderNamespace, DiagnosticOptions);
        private AppConfigurationManagementRestOperations DefaultRestClient => _defaultRestClient ??= new AppConfigurationManagementRestOperations(DefaultClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri);

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary>
        /// Lists the configuration stores for a given subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.AppConfiguration/configurationStores
        /// Operation Id: ConfigurationStores_List
        /// </summary>
        /// <param name="skipToken"> A skip token is used to continue retrieving items after an operation returns a partial result. If a previous response contains a nextLink element, the value of the nextLink element will include a skipToken parameter that specifies a starting point to use for subsequent calls. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ConfigurationStore" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ConfigurationStore> GetConfigurationStoresAsync(string skipToken = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ConfigurationStore>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = ConfigurationStoreClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetConfigurationStores");
                scope.Start();
                try
                {
                    var response = await ConfigurationStoreRestClient.ListAsync(Id.SubscriptionId, skipToken, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ConfigurationStore(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ConfigurationStore>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = ConfigurationStoreClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetConfigurationStores");
                scope.Start();
                try
                {
                    var response = await ConfigurationStoreRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, skipToken, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ConfigurationStore(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Lists the configuration stores for a given subscription.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.AppConfiguration/configurationStores
        /// Operation Id: ConfigurationStores_List
        /// </summary>
        /// <param name="skipToken"> A skip token is used to continue retrieving items after an operation returns a partial result. If a previous response contains a nextLink element, the value of the nextLink element will include a skipToken parameter that specifies a starting point to use for subsequent calls. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ConfigurationStore" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ConfigurationStore> GetConfigurationStores(string skipToken = null, CancellationToken cancellationToken = default)
        {
            Page<ConfigurationStore> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = ConfigurationStoreClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetConfigurationStores");
                scope.Start();
                try
                {
                    var response = ConfigurationStoreRestClient.List(Id.SubscriptionId, skipToken, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ConfigurationStore(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ConfigurationStore> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = ConfigurationStoreClientDiagnostics.CreateScope("SubscriptionExtensionClient.GetConfigurationStores");
                scope.Start();
                try
                {
                    var response = ConfigurationStoreRestClient.ListNextPage(nextLink, Id.SubscriptionId, skipToken, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ConfigurationStore(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Checks whether the configuration store name is available for use.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.AppConfiguration/checkNameAvailability
        /// Operation Id: CheckAppConfigurationNameAvailability
        /// </summary>
        /// <param name="checkNameAvailabilityParameters"> The object containing information for the availability request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<NameAvailabilityStatus>> CheckAppConfigurationNameAvailabilityAsync(CheckNameAvailabilityParameters checkNameAvailabilityParameters, CancellationToken cancellationToken = default)
        {
            using var scope = DefaultClientDiagnostics.CreateScope("SubscriptionExtensionClient.CheckAppConfigurationNameAvailability");
            scope.Start();
            try
            {
                var response = await DefaultRestClient.CheckAppConfigurationNameAvailabilityAsync(Id.SubscriptionId, checkNameAvailabilityParameters, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks whether the configuration store name is available for use.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.AppConfiguration/checkNameAvailability
        /// Operation Id: CheckAppConfigurationNameAvailability
        /// </summary>
        /// <param name="checkNameAvailabilityParameters"> The object containing information for the availability request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<NameAvailabilityStatus> CheckAppConfigurationNameAvailability(CheckNameAvailabilityParameters checkNameAvailabilityParameters, CancellationToken cancellationToken = default)
        {
            using var scope = DefaultClientDiagnostics.CreateScope("SubscriptionExtensionClient.CheckAppConfigurationNameAvailability");
            scope.Start();
            try
            {
                var response = DefaultRestClient.CheckAppConfigurationNameAvailability(Id.SubscriptionId, checkNameAvailabilityParameters, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
