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
    /// <summary> A class representing collection of DscpConfiguration and their operations over its parent. </summary>
    public partial class DscpConfigurationCollection : ArmCollection, IEnumerable<DscpConfiguration>, IAsyncEnumerable<DscpConfiguration>
    {
        private readonly ClientDiagnostics _dscpConfigurationClientDiagnostics;
        private readonly DscpConfigurationRestOperations _dscpConfigurationRestClient;

        /// <summary> Initializes a new instance of the <see cref="DscpConfigurationCollection"/> class for mocking. </summary>
        protected DscpConfigurationCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="DscpConfigurationCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal DscpConfigurationCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _dscpConfigurationClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Network", DscpConfiguration.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(DscpConfiguration.ResourceType, out string dscpConfigurationApiVersion);
            _dscpConfigurationRestClient = new DscpConfigurationRestOperations(_dscpConfigurationClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, dscpConfigurationApiVersion);
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
        /// Creates or updates a DSCP Configuration.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dscpConfigurations/{dscpConfigurationName}
        /// Operation Id: DscpConfiguration_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="dscpConfigurationName"> The name of the resource. </param>
        /// <param name="parameters"> Parameters supplied to the create or update dscp configuration operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="dscpConfigurationName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="dscpConfigurationName"/> or <paramref name="parameters"/> is null. </exception>
        public async virtual Task<ArmOperation<DscpConfiguration>> CreateOrUpdateAsync(bool waitForCompletion, string dscpConfigurationName, DscpConfigurationData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(dscpConfigurationName, nameof(dscpConfigurationName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _dscpConfigurationClientDiagnostics.CreateScope("DscpConfigurationCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _dscpConfigurationRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, dscpConfigurationName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new NetworkArmOperation<DscpConfiguration>(new DscpConfigurationOperationSource(Client), _dscpConfigurationClientDiagnostics, Pipeline, _dscpConfigurationRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, dscpConfigurationName, parameters).Request, response, OperationFinalStateVia.Location);
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
        /// Creates or updates a DSCP Configuration.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dscpConfigurations/{dscpConfigurationName}
        /// Operation Id: DscpConfiguration_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="dscpConfigurationName"> The name of the resource. </param>
        /// <param name="parameters"> Parameters supplied to the create or update dscp configuration operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="dscpConfigurationName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="dscpConfigurationName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<DscpConfiguration> CreateOrUpdate(bool waitForCompletion, string dscpConfigurationName, DscpConfigurationData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(dscpConfigurationName, nameof(dscpConfigurationName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _dscpConfigurationClientDiagnostics.CreateScope("DscpConfigurationCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _dscpConfigurationRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, dscpConfigurationName, parameters, cancellationToken);
                var operation = new NetworkArmOperation<DscpConfiguration>(new DscpConfigurationOperationSource(Client), _dscpConfigurationClientDiagnostics, Pipeline, _dscpConfigurationRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, dscpConfigurationName, parameters).Request, response, OperationFinalStateVia.Location);
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
        /// Gets a DSCP Configuration.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dscpConfigurations/{dscpConfigurationName}
        /// Operation Id: DscpConfiguration_Get
        /// </summary>
        /// <param name="dscpConfigurationName"> The name of the resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="dscpConfigurationName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="dscpConfigurationName"/> is null. </exception>
        public async virtual Task<Response<DscpConfiguration>> GetAsync(string dscpConfigurationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(dscpConfigurationName, nameof(dscpConfigurationName));

            using var scope = _dscpConfigurationClientDiagnostics.CreateScope("DscpConfigurationCollection.Get");
            scope.Start();
            try
            {
                var response = await _dscpConfigurationRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, dscpConfigurationName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _dscpConfigurationClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new DscpConfiguration(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a DSCP Configuration.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dscpConfigurations/{dscpConfigurationName}
        /// Operation Id: DscpConfiguration_Get
        /// </summary>
        /// <param name="dscpConfigurationName"> The name of the resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="dscpConfigurationName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="dscpConfigurationName"/> is null. </exception>
        public virtual Response<DscpConfiguration> Get(string dscpConfigurationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(dscpConfigurationName, nameof(dscpConfigurationName));

            using var scope = _dscpConfigurationClientDiagnostics.CreateScope("DscpConfigurationCollection.Get");
            scope.Start();
            try
            {
                var response = _dscpConfigurationRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, dscpConfigurationName, cancellationToken);
                if (response.Value == null)
                    throw _dscpConfigurationClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new DscpConfiguration(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a DSCP Configuration.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dscpConfigurations
        /// Operation Id: DscpConfiguration_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DscpConfiguration" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DscpConfiguration> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<DscpConfiguration>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _dscpConfigurationClientDiagnostics.CreateScope("DscpConfigurationCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _dscpConfigurationRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DscpConfiguration(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<DscpConfiguration>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _dscpConfigurationClientDiagnostics.CreateScope("DscpConfigurationCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _dscpConfigurationRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DscpConfiguration(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Gets a DSCP Configuration.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dscpConfigurations
        /// Operation Id: DscpConfiguration_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DscpConfiguration" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DscpConfiguration> GetAll(CancellationToken cancellationToken = default)
        {
            Page<DscpConfiguration> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _dscpConfigurationClientDiagnostics.CreateScope("DscpConfigurationCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _dscpConfigurationRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DscpConfiguration(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<DscpConfiguration> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _dscpConfigurationClientDiagnostics.CreateScope("DscpConfigurationCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _dscpConfigurationRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DscpConfiguration(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dscpConfigurations/{dscpConfigurationName}
        /// Operation Id: DscpConfiguration_Get
        /// </summary>
        /// <param name="dscpConfigurationName"> The name of the resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="dscpConfigurationName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="dscpConfigurationName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string dscpConfigurationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(dscpConfigurationName, nameof(dscpConfigurationName));

            using var scope = _dscpConfigurationClientDiagnostics.CreateScope("DscpConfigurationCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(dscpConfigurationName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dscpConfigurations/{dscpConfigurationName}
        /// Operation Id: DscpConfiguration_Get
        /// </summary>
        /// <param name="dscpConfigurationName"> The name of the resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="dscpConfigurationName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="dscpConfigurationName"/> is null. </exception>
        public virtual Response<bool> Exists(string dscpConfigurationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(dscpConfigurationName, nameof(dscpConfigurationName));

            using var scope = _dscpConfigurationClientDiagnostics.CreateScope("DscpConfigurationCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(dscpConfigurationName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dscpConfigurations/{dscpConfigurationName}
        /// Operation Id: DscpConfiguration_Get
        /// </summary>
        /// <param name="dscpConfigurationName"> The name of the resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="dscpConfigurationName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="dscpConfigurationName"/> is null. </exception>
        public async virtual Task<Response<DscpConfiguration>> GetIfExistsAsync(string dscpConfigurationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(dscpConfigurationName, nameof(dscpConfigurationName));

            using var scope = _dscpConfigurationClientDiagnostics.CreateScope("DscpConfigurationCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _dscpConfigurationRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, dscpConfigurationName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<DscpConfiguration>(null, response.GetRawResponse());
                return Response.FromValue(new DscpConfiguration(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/dscpConfigurations/{dscpConfigurationName}
        /// Operation Id: DscpConfiguration_Get
        /// </summary>
        /// <param name="dscpConfigurationName"> The name of the resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="dscpConfigurationName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="dscpConfigurationName"/> is null. </exception>
        public virtual Response<DscpConfiguration> GetIfExists(string dscpConfigurationName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(dscpConfigurationName, nameof(dscpConfigurationName));

            using var scope = _dscpConfigurationClientDiagnostics.CreateScope("DscpConfigurationCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _dscpConfigurationRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, dscpConfigurationName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<DscpConfiguration>(null, response.GetRawResponse());
                return Response.FromValue(new DscpConfiguration(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<DscpConfiguration> IEnumerable<DscpConfiguration>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<DscpConfiguration> IAsyncEnumerable<DscpConfiguration>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
