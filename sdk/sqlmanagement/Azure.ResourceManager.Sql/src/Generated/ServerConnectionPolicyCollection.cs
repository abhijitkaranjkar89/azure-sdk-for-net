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
using Azure.ResourceManager.Sql.Models;

namespace Azure.ResourceManager.Sql
{
    /// <summary> A class representing collection of ServerConnectionPolicy and their operations over its parent. </summary>
    public partial class ServerConnectionPolicyCollection : ArmCollection, IEnumerable<ServerConnectionPolicy>, IAsyncEnumerable<ServerConnectionPolicy>
    {
        private readonly ClientDiagnostics _serverConnectionPolicyClientDiagnostics;
        private readonly ServerConnectionPoliciesRestOperations _serverConnectionPolicyRestClient;

        /// <summary> Initializes a new instance of the <see cref="ServerConnectionPolicyCollection"/> class for mocking. </summary>
        protected ServerConnectionPolicyCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ServerConnectionPolicyCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal ServerConnectionPolicyCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _serverConnectionPolicyClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sql", ServerConnectionPolicy.ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(ServerConnectionPolicy.ResourceType, out string serverConnectionPolicyApiVersion);
            _serverConnectionPolicyRestClient = new ServerConnectionPoliciesRestOperations(_serverConnectionPolicyClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, serverConnectionPolicyApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != SqlServer.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, SqlServer.ResourceType), nameof(id));
        }

        /// <summary>
        /// Updates a server connection policy
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/connectionPolicies/{connectionPolicyName}
        /// Operation Id: ServerConnectionPolicies_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="connectionPolicyName"> The name of the connection policy. </param>
        /// <param name="parameters"> The required parameters for updating a server connection policy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public async virtual Task<ArmOperation<ServerConnectionPolicy>> CreateOrUpdateAsync(bool waitForCompletion, ConnectionPolicyName connectionPolicyName, ServerConnectionPolicyData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _serverConnectionPolicyClientDiagnostics.CreateScope("ServerConnectionPolicyCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _serverConnectionPolicyRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, connectionPolicyName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new SqlArmOperation<ServerConnectionPolicy>(new ServerConnectionPolicyOperationSource(Client), _serverConnectionPolicyClientDiagnostics, Pipeline, _serverConnectionPolicyRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, connectionPolicyName, parameters).Request, response, OperationFinalStateVia.Location);
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
        /// Updates a server connection policy
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/connectionPolicies/{connectionPolicyName}
        /// Operation Id: ServerConnectionPolicies_CreateOrUpdate
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="connectionPolicyName"> The name of the connection policy. </param>
        /// <param name="parameters"> The required parameters for updating a server connection policy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<ServerConnectionPolicy> CreateOrUpdate(bool waitForCompletion, ConnectionPolicyName connectionPolicyName, ServerConnectionPolicyData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _serverConnectionPolicyClientDiagnostics.CreateScope("ServerConnectionPolicyCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _serverConnectionPolicyRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, connectionPolicyName, parameters, cancellationToken);
                var operation = new SqlArmOperation<ServerConnectionPolicy>(new ServerConnectionPolicyOperationSource(Client), _serverConnectionPolicyClientDiagnostics, Pipeline, _serverConnectionPolicyRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, connectionPolicyName, parameters).Request, response, OperationFinalStateVia.Location);
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
        /// Gets a server connection policy
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/connectionPolicies/{connectionPolicyName}
        /// Operation Id: ServerConnectionPolicies_Get
        /// </summary>
        /// <param name="connectionPolicyName"> The name of the connection policy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<ServerConnectionPolicy>> GetAsync(ConnectionPolicyName connectionPolicyName, CancellationToken cancellationToken = default)
        {
            using var scope = _serverConnectionPolicyClientDiagnostics.CreateScope("ServerConnectionPolicyCollection.Get");
            scope.Start();
            try
            {
                var response = await _serverConnectionPolicyRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, connectionPolicyName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _serverConnectionPolicyClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new ServerConnectionPolicy(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a server connection policy
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/connectionPolicies/{connectionPolicyName}
        /// Operation Id: ServerConnectionPolicies_Get
        /// </summary>
        /// <param name="connectionPolicyName"> The name of the connection policy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ServerConnectionPolicy> Get(ConnectionPolicyName connectionPolicyName, CancellationToken cancellationToken = default)
        {
            using var scope = _serverConnectionPolicyClientDiagnostics.CreateScope("ServerConnectionPolicyCollection.Get");
            scope.Start();
            try
            {
                var response = _serverConnectionPolicyRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, connectionPolicyName, cancellationToken);
                if (response.Value == null)
                    throw _serverConnectionPolicyClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ServerConnectionPolicy(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists connection policy
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/connectionPolicies
        /// Operation Id: ServerConnectionPolicies_ListByServer
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ServerConnectionPolicy" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ServerConnectionPolicy> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<ServerConnectionPolicy>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _serverConnectionPolicyClientDiagnostics.CreateScope("ServerConnectionPolicyCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _serverConnectionPolicyRestClient.ListByServerAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ServerConnectionPolicy(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ServerConnectionPolicy>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _serverConnectionPolicyClientDiagnostics.CreateScope("ServerConnectionPolicyCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _serverConnectionPolicyRestClient.ListByServerNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ServerConnectionPolicy(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Lists connection policy
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/connectionPolicies
        /// Operation Id: ServerConnectionPolicies_ListByServer
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ServerConnectionPolicy" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ServerConnectionPolicy> GetAll(CancellationToken cancellationToken = default)
        {
            Page<ServerConnectionPolicy> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _serverConnectionPolicyClientDiagnostics.CreateScope("ServerConnectionPolicyCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _serverConnectionPolicyRestClient.ListByServer(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ServerConnectionPolicy(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ServerConnectionPolicy> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _serverConnectionPolicyClientDiagnostics.CreateScope("ServerConnectionPolicyCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _serverConnectionPolicyRestClient.ListByServerNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ServerConnectionPolicy(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/connectionPolicies/{connectionPolicyName}
        /// Operation Id: ServerConnectionPolicies_Get
        /// </summary>
        /// <param name="connectionPolicyName"> The name of the connection policy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<bool>> ExistsAsync(ConnectionPolicyName connectionPolicyName, CancellationToken cancellationToken = default)
        {
            using var scope = _serverConnectionPolicyClientDiagnostics.CreateScope("ServerConnectionPolicyCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(connectionPolicyName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/connectionPolicies/{connectionPolicyName}
        /// Operation Id: ServerConnectionPolicies_Get
        /// </summary>
        /// <param name="connectionPolicyName"> The name of the connection policy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<bool> Exists(ConnectionPolicyName connectionPolicyName, CancellationToken cancellationToken = default)
        {
            using var scope = _serverConnectionPolicyClientDiagnostics.CreateScope("ServerConnectionPolicyCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(connectionPolicyName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/connectionPolicies/{connectionPolicyName}
        /// Operation Id: ServerConnectionPolicies_Get
        /// </summary>
        /// <param name="connectionPolicyName"> The name of the connection policy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<ServerConnectionPolicy>> GetIfExistsAsync(ConnectionPolicyName connectionPolicyName, CancellationToken cancellationToken = default)
        {
            using var scope = _serverConnectionPolicyClientDiagnostics.CreateScope("ServerConnectionPolicyCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _serverConnectionPolicyRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, connectionPolicyName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<ServerConnectionPolicy>(null, response.GetRawResponse());
                return Response.FromValue(new ServerConnectionPolicy(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/connectionPolicies/{connectionPolicyName}
        /// Operation Id: ServerConnectionPolicies_Get
        /// </summary>
        /// <param name="connectionPolicyName"> The name of the connection policy. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ServerConnectionPolicy> GetIfExists(ConnectionPolicyName connectionPolicyName, CancellationToken cancellationToken = default)
        {
            using var scope = _serverConnectionPolicyClientDiagnostics.CreateScope("ServerConnectionPolicyCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _serverConnectionPolicyRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, connectionPolicyName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<ServerConnectionPolicy>(null, response.GetRawResponse());
                return Response.FromValue(new ServerConnectionPolicy(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<ServerConnectionPolicy> IEnumerable<ServerConnectionPolicy>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<ServerConnectionPolicy> IAsyncEnumerable<ServerConnectionPolicy>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
