// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Network
{
    /// <summary> A class representing collection of NetworkVirtualAppliance and their operations over its parent. </summary>
    public partial class NetworkVirtualApplianceCollection : ArmCollection, IEnumerable<NetworkVirtualAppliance>, IAsyncEnumerable<NetworkVirtualAppliance>
    {
        private readonly ClientDiagnostics _networkVirtualApplianceClientDiagnostics;
        private readonly NetworkVirtualAppliancesRestOperations _networkVirtualApplianceRestClient;

        /// <summary> Initializes a new instance of the <see cref="NetworkVirtualApplianceCollection"/> class for mocking. </summary>
        protected NetworkVirtualApplianceCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="NetworkVirtualApplianceCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal NetworkVirtualApplianceCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _networkVirtualApplianceClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Network", NetworkVirtualAppliance.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(NetworkVirtualAppliance.ResourceType, out string networkVirtualApplianceApiVersion);
            _networkVirtualApplianceRestClient = new NetworkVirtualAppliancesRestOperations(_networkVirtualApplianceClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, networkVirtualApplianceApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceGroup.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceGroup.ResourceType), nameof(id));
        }

        /// <summary>
        /// Creates or updates the specified Network Virtual Appliance.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/networkVirtualAppliances/{networkVirtualApplianceName}
        /// Operation Id: NetworkVirtualAppliances_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="networkVirtualApplianceName"> The name of Network Virtual Appliance. </param>
        /// <param name="parameters"> Parameters supplied to the create or update Network Virtual Appliance. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="networkVirtualApplianceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="networkVirtualApplianceName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<ArmOperation<NetworkVirtualAppliance>> CreateOrUpdateAsync(bool waitForCompletion, string networkVirtualApplianceName, NetworkVirtualApplianceData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(networkVirtualApplianceName, nameof(networkVirtualApplianceName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _networkVirtualApplianceClientDiagnostics.CreateScope("NetworkVirtualApplianceCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _networkVirtualApplianceRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, networkVirtualApplianceName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new NetworkArmOperation<NetworkVirtualAppliance>(new NetworkVirtualApplianceOperationSource(Client), _networkVirtualApplianceClientDiagnostics, Pipeline, _networkVirtualApplianceRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, networkVirtualApplianceName, parameters).Request, response, OperationFinalStateVia.AzureAsyncOperation);
                if (waitForCompletion)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Creates or updates the specified Network Virtual Appliance.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/networkVirtualAppliances/{networkVirtualApplianceName}
        /// Operation Id: NetworkVirtualAppliances_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="networkVirtualApplianceName"> The name of Network Virtual Appliance. </param>
        /// <param name="parameters"> Parameters supplied to the create or update Network Virtual Appliance. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="networkVirtualApplianceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="networkVirtualApplianceName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<NetworkVirtualAppliance> CreateOrUpdate(bool waitForCompletion, string networkVirtualApplianceName, NetworkVirtualApplianceData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(networkVirtualApplianceName, nameof(networkVirtualApplianceName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _networkVirtualApplianceClientDiagnostics.CreateScope("NetworkVirtualApplianceCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _networkVirtualApplianceRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, networkVirtualApplianceName, parameters, cancellationToken);
                var operation = new NetworkArmOperation<NetworkVirtualAppliance>(new NetworkVirtualApplianceOperationSource(Client), _networkVirtualApplianceClientDiagnostics, Pipeline, _networkVirtualApplianceRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, networkVirtualApplianceName, parameters).Request, response, OperationFinalStateVia.AzureAsyncOperation);
                if (waitForCompletion)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the specified Network Virtual Appliance.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/networkVirtualAppliances/{networkVirtualApplianceName}
        /// Operation Id: NetworkVirtualAppliances_Get
        /// </summary>
        /// <param name="networkVirtualApplianceName"> The name of Network Virtual Appliance. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="networkVirtualApplianceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="networkVirtualApplianceName"/> is null. </exception>
        public async virtual Task<Response<NetworkVirtualAppliance>> GetAsync(string networkVirtualApplianceName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(networkVirtualApplianceName, nameof(networkVirtualApplianceName));

            using var scope = _networkVirtualApplianceClientDiagnostics.CreateScope("NetworkVirtualApplianceCollection.Get");
            scope.Start();
            try
            {
                var response = await _networkVirtualApplianceRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, networkVirtualApplianceName, expand, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _networkVirtualApplianceClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new NetworkVirtualAppliance(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the specified Network Virtual Appliance.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/networkVirtualAppliances/{networkVirtualApplianceName}
        /// Operation Id: NetworkVirtualAppliances_Get
        /// </summary>
        /// <param name="networkVirtualApplianceName"> The name of Network Virtual Appliance. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="networkVirtualApplianceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="networkVirtualApplianceName"/> is null. </exception>
        public virtual Response<NetworkVirtualAppliance> Get(string networkVirtualApplianceName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(networkVirtualApplianceName, nameof(networkVirtualApplianceName));

            using var scope = _networkVirtualApplianceClientDiagnostics.CreateScope("NetworkVirtualApplianceCollection.Get");
            scope.Start();
            try
            {
                var response = _networkVirtualApplianceRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, networkVirtualApplianceName, expand, cancellationToken);
                if (response.Value == null)
                    throw _networkVirtualApplianceClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new NetworkVirtualAppliance(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists all Network Virtual Appliances in a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/networkVirtualAppliances
        /// Operation Id: NetworkVirtualAppliances_ListByResourceGroup
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="NetworkVirtualAppliance" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<NetworkVirtualAppliance> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<NetworkVirtualAppliance>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _networkVirtualApplianceClientDiagnostics.CreateScope("NetworkVirtualApplianceCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _networkVirtualApplianceRestClient.ListByResourceGroupAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new NetworkVirtualAppliance(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<NetworkVirtualAppliance>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _networkVirtualApplianceClientDiagnostics.CreateScope("NetworkVirtualApplianceCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _networkVirtualApplianceRestClient.ListByResourceGroupNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new NetworkVirtualAppliance(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists all Network Virtual Appliances in a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/networkVirtualAppliances
        /// Operation Id: NetworkVirtualAppliances_ListByResourceGroup
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="NetworkVirtualAppliance" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<NetworkVirtualAppliance> GetAll(CancellationToken cancellationToken = default)
        {
            Page<NetworkVirtualAppliance> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _networkVirtualApplianceClientDiagnostics.CreateScope("NetworkVirtualApplianceCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _networkVirtualApplianceRestClient.ListByResourceGroup(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new NetworkVirtualAppliance(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<NetworkVirtualAppliance> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _networkVirtualApplianceClientDiagnostics.CreateScope("NetworkVirtualApplianceCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _networkVirtualApplianceRestClient.ListByResourceGroupNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new NetworkVirtualAppliance(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/networkVirtualAppliances/{networkVirtualApplianceName}
        /// Operation Id: NetworkVirtualAppliances_Get
        /// </summary>
        /// <param name="networkVirtualApplianceName"> The name of Network Virtual Appliance. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="networkVirtualApplianceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="networkVirtualApplianceName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string networkVirtualApplianceName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(networkVirtualApplianceName, nameof(networkVirtualApplianceName));

            using var scope = _networkVirtualApplianceClientDiagnostics.CreateScope("NetworkVirtualApplianceCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(networkVirtualApplianceName, expand: expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/networkVirtualAppliances/{networkVirtualApplianceName}
        /// Operation Id: NetworkVirtualAppliances_Get
        /// </summary>
        /// <param name="networkVirtualApplianceName"> The name of Network Virtual Appliance. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="networkVirtualApplianceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="networkVirtualApplianceName"/> is null. </exception>
        public virtual Response<bool> Exists(string networkVirtualApplianceName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(networkVirtualApplianceName, nameof(networkVirtualApplianceName));

            using var scope = _networkVirtualApplianceClientDiagnostics.CreateScope("NetworkVirtualApplianceCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(networkVirtualApplianceName, expand: expand, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/networkVirtualAppliances/{networkVirtualApplianceName}
        /// Operation Id: NetworkVirtualAppliances_Get
        /// </summary>
        /// <param name="networkVirtualApplianceName"> The name of Network Virtual Appliance. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="networkVirtualApplianceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="networkVirtualApplianceName"/> is null. </exception>
        public async virtual Task<Response<NetworkVirtualAppliance>> GetIfExistsAsync(string networkVirtualApplianceName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(networkVirtualApplianceName, nameof(networkVirtualApplianceName));

            using var scope = _networkVirtualApplianceClientDiagnostics.CreateScope("NetworkVirtualApplianceCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _networkVirtualApplianceRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, networkVirtualApplianceName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<NetworkVirtualAppliance>(null, response.GetRawResponse());
                return Response.FromValue(new NetworkVirtualAppliance(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/networkVirtualAppliances/{networkVirtualApplianceName}
        /// Operation Id: NetworkVirtualAppliances_Get
        /// </summary>
        /// <param name="networkVirtualApplianceName"> The name of Network Virtual Appliance. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="networkVirtualApplianceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="networkVirtualApplianceName"/> is null. </exception>
        public virtual Response<NetworkVirtualAppliance> GetIfExists(string networkVirtualApplianceName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(networkVirtualApplianceName, nameof(networkVirtualApplianceName));

            using var scope = _networkVirtualApplianceClientDiagnostics.CreateScope("NetworkVirtualApplianceCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _networkVirtualApplianceRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, networkVirtualApplianceName, expand, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<NetworkVirtualAppliance>(null, response.GetRawResponse());
                return Response.FromValue(new NetworkVirtualAppliance(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<NetworkVirtualAppliance> IEnumerable<NetworkVirtualAppliance>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<NetworkVirtualAppliance> IAsyncEnumerable<NetworkVirtualAppliance>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
