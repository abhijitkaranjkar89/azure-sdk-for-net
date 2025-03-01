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
    /// <summary> A class representing collection of PublicIPPrefix and their operations over its parent. </summary>
    public partial class PublicIPPrefixCollection : ArmCollection, IEnumerable<PublicIPPrefix>, IAsyncEnumerable<PublicIPPrefix>
    {
        private readonly ClientDiagnostics _publicIPPrefixClientDiagnostics;
        private readonly PublicIPPrefixesRestOperations _publicIPPrefixRestClient;

        /// <summary> Initializes a new instance of the <see cref="PublicIPPrefixCollection"/> class for mocking. </summary>
        protected PublicIPPrefixCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="PublicIPPrefixCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal PublicIPPrefixCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _publicIPPrefixClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Network", PublicIPPrefix.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(PublicIPPrefix.ResourceType, out string publicIPPrefixApiVersion);
            _publicIPPrefixRestClient = new PublicIPPrefixesRestOperations(_publicIPPrefixClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, publicIPPrefixApiVersion);
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
        /// Creates or updates a static or dynamic public IP prefix.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/publicIPPrefixes/{publicIpPrefixName}
        /// Operation Id: PublicIPPrefixes_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="publicIpPrefixName"> The name of the public IP prefix. </param>
        /// <param name="parameters"> Parameters supplied to the create or update public IP prefix operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="publicIpPrefixName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="publicIpPrefixName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<ArmOperation<PublicIPPrefix>> CreateOrUpdateAsync(bool waitForCompletion, string publicIpPrefixName, PublicIPPrefixData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(publicIpPrefixName, nameof(publicIpPrefixName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _publicIPPrefixClientDiagnostics.CreateScope("PublicIPPrefixCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _publicIPPrefixRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, publicIpPrefixName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new NetworkArmOperation<PublicIPPrefix>(new PublicIPPrefixOperationSource(Client), _publicIPPrefixClientDiagnostics, Pipeline, _publicIPPrefixRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, publicIpPrefixName, parameters).Request, response, OperationFinalStateVia.Location);
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
        /// Creates or updates a static or dynamic public IP prefix.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/publicIPPrefixes/{publicIpPrefixName}
        /// Operation Id: PublicIPPrefixes_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="publicIpPrefixName"> The name of the public IP prefix. </param>
        /// <param name="parameters"> Parameters supplied to the create or update public IP prefix operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="publicIpPrefixName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="publicIpPrefixName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<PublicIPPrefix> CreateOrUpdate(bool waitForCompletion, string publicIpPrefixName, PublicIPPrefixData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(publicIpPrefixName, nameof(publicIpPrefixName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _publicIPPrefixClientDiagnostics.CreateScope("PublicIPPrefixCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _publicIPPrefixRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, publicIpPrefixName, parameters, cancellationToken);
                var operation = new NetworkArmOperation<PublicIPPrefix>(new PublicIPPrefixOperationSource(Client), _publicIPPrefixClientDiagnostics, Pipeline, _publicIPPrefixRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, publicIpPrefixName, parameters).Request, response, OperationFinalStateVia.Location);
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
        /// Gets the specified public IP prefix in a specified resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/publicIPPrefixes/{publicIpPrefixName}
        /// Operation Id: PublicIPPrefixes_Get
        /// </summary>
        /// <param name="publicIpPrefixName"> The name of the public IP prefix. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="publicIpPrefixName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="publicIpPrefixName"/> is null. </exception>
        public async virtual Task<Response<PublicIPPrefix>> GetAsync(string publicIpPrefixName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(publicIpPrefixName, nameof(publicIpPrefixName));

            using var scope = _publicIPPrefixClientDiagnostics.CreateScope("PublicIPPrefixCollection.Get");
            scope.Start();
            try
            {
                var response = await _publicIPPrefixRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, publicIpPrefixName, expand, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _publicIPPrefixClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new PublicIPPrefix(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the specified public IP prefix in a specified resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/publicIPPrefixes/{publicIpPrefixName}
        /// Operation Id: PublicIPPrefixes_Get
        /// </summary>
        /// <param name="publicIpPrefixName"> The name of the public IP prefix. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="publicIpPrefixName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="publicIpPrefixName"/> is null. </exception>
        public virtual Response<PublicIPPrefix> Get(string publicIpPrefixName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(publicIpPrefixName, nameof(publicIpPrefixName));

            using var scope = _publicIPPrefixClientDiagnostics.CreateScope("PublicIPPrefixCollection.Get");
            scope.Start();
            try
            {
                var response = _publicIPPrefixRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, publicIpPrefixName, expand, cancellationToken);
                if (response.Value == null)
                    throw _publicIPPrefixClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new PublicIPPrefix(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets all public IP prefixes in a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/publicIPPrefixes
        /// Operation Id: PublicIPPrefixes_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="PublicIPPrefix" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<PublicIPPrefix> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<PublicIPPrefix>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _publicIPPrefixClientDiagnostics.CreateScope("PublicIPPrefixCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _publicIPPrefixRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new PublicIPPrefix(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<PublicIPPrefix>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _publicIPPrefixClientDiagnostics.CreateScope("PublicIPPrefixCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _publicIPPrefixRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new PublicIPPrefix(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Gets all public IP prefixes in a resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/publicIPPrefixes
        /// Operation Id: PublicIPPrefixes_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="PublicIPPrefix" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<PublicIPPrefix> GetAll(CancellationToken cancellationToken = default)
        {
            Page<PublicIPPrefix> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _publicIPPrefixClientDiagnostics.CreateScope("PublicIPPrefixCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _publicIPPrefixRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new PublicIPPrefix(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<PublicIPPrefix> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _publicIPPrefixClientDiagnostics.CreateScope("PublicIPPrefixCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _publicIPPrefixRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new PublicIPPrefix(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/publicIPPrefixes/{publicIpPrefixName}
        /// Operation Id: PublicIPPrefixes_Get
        /// </summary>
        /// <param name="publicIpPrefixName"> The name of the public IP prefix. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="publicIpPrefixName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="publicIpPrefixName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string publicIpPrefixName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(publicIpPrefixName, nameof(publicIpPrefixName));

            using var scope = _publicIPPrefixClientDiagnostics.CreateScope("PublicIPPrefixCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(publicIpPrefixName, expand: expand, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/publicIPPrefixes/{publicIpPrefixName}
        /// Operation Id: PublicIPPrefixes_Get
        /// </summary>
        /// <param name="publicIpPrefixName"> The name of the public IP prefix. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="publicIpPrefixName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="publicIpPrefixName"/> is null. </exception>
        public virtual Response<bool> Exists(string publicIpPrefixName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(publicIpPrefixName, nameof(publicIpPrefixName));

            using var scope = _publicIPPrefixClientDiagnostics.CreateScope("PublicIPPrefixCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(publicIpPrefixName, expand: expand, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/publicIPPrefixes/{publicIpPrefixName}
        /// Operation Id: PublicIPPrefixes_Get
        /// </summary>
        /// <param name="publicIpPrefixName"> The name of the public IP prefix. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="publicIpPrefixName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="publicIpPrefixName"/> is null. </exception>
        public async virtual Task<Response<PublicIPPrefix>> GetIfExistsAsync(string publicIpPrefixName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(publicIpPrefixName, nameof(publicIpPrefixName));

            using var scope = _publicIPPrefixClientDiagnostics.CreateScope("PublicIPPrefixCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _publicIPPrefixRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, publicIpPrefixName, expand, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<PublicIPPrefix>(null, response.GetRawResponse());
                return Response.FromValue(new PublicIPPrefix(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/publicIPPrefixes/{publicIpPrefixName}
        /// Operation Id: PublicIPPrefixes_Get
        /// </summary>
        /// <param name="publicIpPrefixName"> The name of the public IP prefix. </param>
        /// <param name="expand"> Expands referenced resources. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="publicIpPrefixName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="publicIpPrefixName"/> is null. </exception>
        public virtual Response<PublicIPPrefix> GetIfExists(string publicIpPrefixName, string expand = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(publicIpPrefixName, nameof(publicIpPrefixName));

            using var scope = _publicIPPrefixClientDiagnostics.CreateScope("PublicIPPrefixCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _publicIPPrefixRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, publicIpPrefixName, expand, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<PublicIPPrefix>(null, response.GetRawResponse());
                return Response.FromValue(new PublicIPPrefix(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<PublicIPPrefix> IEnumerable<PublicIPPrefix>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<PublicIPPrefix> IAsyncEnumerable<PublicIPPrefix>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
