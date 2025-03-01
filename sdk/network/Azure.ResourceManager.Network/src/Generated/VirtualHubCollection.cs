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
    /// <summary> A class representing collection of VirtualHub and their operations over its parent. </summary>
    public partial class VirtualHubCollection : ArmCollection, IEnumerable<VirtualHub>, IAsyncEnumerable<VirtualHub>
    {
        private readonly ClientDiagnostics _virtualHubClientDiagnostics;
        private readonly VirtualHubsRestOperations _virtualHubRestClient;

        /// <summary> Initializes a new instance of the <see cref="VirtualHubCollection"/> class for mocking. </summary>
        protected VirtualHubCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="VirtualHubCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal VirtualHubCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _virtualHubClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Network", VirtualHub.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(VirtualHub.ResourceType, out string virtualHubApiVersion);
            _virtualHubRestClient = new VirtualHubsRestOperations(_virtualHubClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, virtualHubApiVersion);
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
        /// Creates a VirtualHub resource if it doesn&apos;t exist else updates the existing VirtualHub.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualHubs/{virtualHubName}
        /// Operation Id: VirtualHubs_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="virtualHubName"> The name of the VirtualHub. </param>
        /// <param name="virtualHubParameters"> Parameters supplied to create or update VirtualHub. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="virtualHubName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="virtualHubName"/> or <paramref name="virtualHubParameters"/> is null. </exception>
        public async virtual Task<ArmOperation<VirtualHub>> CreateOrUpdateAsync(bool waitForCompletion, string virtualHubName, VirtualHubData virtualHubParameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(virtualHubName, nameof(virtualHubName));
            Argument.AssertNotNull(virtualHubParameters, nameof(virtualHubParameters));

            using var scope = _virtualHubClientDiagnostics.CreateScope("VirtualHubCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _virtualHubRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, virtualHubName, virtualHubParameters, cancellationToken).ConfigureAwait(false);
                var operation = new NetworkArmOperation<VirtualHub>(new VirtualHubOperationSource(Client), _virtualHubClientDiagnostics, Pipeline, _virtualHubRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, virtualHubName, virtualHubParameters).Request, response, OperationFinalStateVia.AzureAsyncOperation);
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
        /// Creates a VirtualHub resource if it doesn&apos;t exist else updates the existing VirtualHub.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualHubs/{virtualHubName}
        /// Operation Id: VirtualHubs_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="virtualHubName"> The name of the VirtualHub. </param>
        /// <param name="virtualHubParameters"> Parameters supplied to create or update VirtualHub. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="virtualHubName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="virtualHubName"/> or <paramref name="virtualHubParameters"/> is null. </exception>
        public virtual ArmOperation<VirtualHub> CreateOrUpdate(bool waitForCompletion, string virtualHubName, VirtualHubData virtualHubParameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(virtualHubName, nameof(virtualHubName));
            Argument.AssertNotNull(virtualHubParameters, nameof(virtualHubParameters));

            using var scope = _virtualHubClientDiagnostics.CreateScope("VirtualHubCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _virtualHubRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, virtualHubName, virtualHubParameters, cancellationToken);
                var operation = new NetworkArmOperation<VirtualHub>(new VirtualHubOperationSource(Client), _virtualHubClientDiagnostics, Pipeline, _virtualHubRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, virtualHubName, virtualHubParameters).Request, response, OperationFinalStateVia.AzureAsyncOperation);
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
        /// Retrieves the details of a VirtualHub.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualHubs/{virtualHubName}
        /// Operation Id: VirtualHubs_Get
        /// </summary>
        /// <param name="virtualHubName"> The name of the VirtualHub. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="virtualHubName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="virtualHubName"/> is null. </exception>
        public async virtual Task<Response<VirtualHub>> GetAsync(string virtualHubName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(virtualHubName, nameof(virtualHubName));

            using var scope = _virtualHubClientDiagnostics.CreateScope("VirtualHubCollection.Get");
            scope.Start();
            try
            {
                var response = await _virtualHubRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, virtualHubName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _virtualHubClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new VirtualHub(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves the details of a VirtualHub.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualHubs/{virtualHubName}
        /// Operation Id: VirtualHubs_Get
        /// </summary>
        /// <param name="virtualHubName"> The name of the VirtualHub. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="virtualHubName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="virtualHubName"/> is null. </exception>
        public virtual Response<VirtualHub> Get(string virtualHubName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(virtualHubName, nameof(virtualHubName));

            using var scope = _virtualHubClientDiagnostics.CreateScope("VirtualHubCollection.Get");
            scope.Start();
            try
            {
                var response = _virtualHubRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, virtualHubName, cancellationToken);
                if (response.Value == null)
                    throw _virtualHubClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new VirtualHub(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists all the VirtualHubs in a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualHubs
        /// Operation Id: VirtualHubs_ListByResourceGroup
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="VirtualHub" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<VirtualHub> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<VirtualHub>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _virtualHubClientDiagnostics.CreateScope("VirtualHubCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _virtualHubRestClient.ListByResourceGroupAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualHub(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<VirtualHub>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _virtualHubClientDiagnostics.CreateScope("VirtualHubCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _virtualHubRestClient.ListByResourceGroupNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualHub(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists all the VirtualHubs in a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualHubs
        /// Operation Id: VirtualHubs_ListByResourceGroup
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="VirtualHub" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<VirtualHub> GetAll(CancellationToken cancellationToken = default)
        {
            Page<VirtualHub> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _virtualHubClientDiagnostics.CreateScope("VirtualHubCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _virtualHubRestClient.ListByResourceGroup(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualHub(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<VirtualHub> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _virtualHubClientDiagnostics.CreateScope("VirtualHubCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _virtualHubRestClient.ListByResourceGroupNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new VirtualHub(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualHubs/{virtualHubName}
        /// Operation Id: VirtualHubs_Get
        /// </summary>
        /// <param name="virtualHubName"> The name of the VirtualHub. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="virtualHubName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="virtualHubName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string virtualHubName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(virtualHubName, nameof(virtualHubName));

            using var scope = _virtualHubClientDiagnostics.CreateScope("VirtualHubCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(virtualHubName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualHubs/{virtualHubName}
        /// Operation Id: VirtualHubs_Get
        /// </summary>
        /// <param name="virtualHubName"> The name of the VirtualHub. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="virtualHubName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="virtualHubName"/> is null. </exception>
        public virtual Response<bool> Exists(string virtualHubName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(virtualHubName, nameof(virtualHubName));

            using var scope = _virtualHubClientDiagnostics.CreateScope("VirtualHubCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(virtualHubName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualHubs/{virtualHubName}
        /// Operation Id: VirtualHubs_Get
        /// </summary>
        /// <param name="virtualHubName"> The name of the VirtualHub. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="virtualHubName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="virtualHubName"/> is null. </exception>
        public async virtual Task<Response<VirtualHub>> GetIfExistsAsync(string virtualHubName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(virtualHubName, nameof(virtualHubName));

            using var scope = _virtualHubClientDiagnostics.CreateScope("VirtualHubCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _virtualHubRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, virtualHubName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<VirtualHub>(null, response.GetRawResponse());
                return Response.FromValue(new VirtualHub(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/virtualHubs/{virtualHubName}
        /// Operation Id: VirtualHubs_Get
        /// </summary>
        /// <param name="virtualHubName"> The name of the VirtualHub. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="virtualHubName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="virtualHubName"/> is null. </exception>
        public virtual Response<VirtualHub> GetIfExists(string virtualHubName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(virtualHubName, nameof(virtualHubName));

            using var scope = _virtualHubClientDiagnostics.CreateScope("VirtualHubCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _virtualHubRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, virtualHubName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<VirtualHub>(null, response.GetRawResponse());
                return Response.FromValue(new VirtualHub(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<VirtualHub> IEnumerable<VirtualHub>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<VirtualHub> IAsyncEnumerable<VirtualHub>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
