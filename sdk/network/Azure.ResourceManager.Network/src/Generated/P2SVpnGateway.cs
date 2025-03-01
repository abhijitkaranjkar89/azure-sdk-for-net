// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network
{
    /// <summary> A Class representing a P2SVpnGateway along with the instance operations that can be performed on it. </summary>
    public partial class P2SVpnGateway : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="P2SVpnGateway"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string gatewayName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/p2svpnGateways/{gatewayName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _p2SVpnGatewayP2sVpnGatewaysClientDiagnostics;
        private readonly P2SVpnGatewaysRestOperations _p2SVpnGatewayP2sVpnGatewaysRestClient;
        private readonly P2SVpnGatewayData _data;

        /// <summary> Initializes a new instance of the <see cref="P2SVpnGateway"/> class for mocking. </summary>
        protected P2SVpnGateway()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "P2SVpnGateway"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal P2SVpnGateway(ArmClient client, P2SVpnGatewayData data) : this(client, new ResourceIdentifier(data.Id))
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="P2SVpnGateway"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal P2SVpnGateway(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _p2SVpnGatewayP2sVpnGatewaysClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Network", ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(ResourceType, out string p2SVpnGatewayP2sVpnGatewaysApiVersion);
            _p2SVpnGatewayP2sVpnGatewaysRestClient = new P2SVpnGatewaysRestOperations(_p2SVpnGatewayP2sVpnGatewaysClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, p2SVpnGatewayP2sVpnGatewaysApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Network/p2svpnGateways";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual P2SVpnGatewayData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                return _data;
            }
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
        }

        /// <summary>
        /// Retrieves the details of a virtual wan p2s vpn gateway.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/p2svpnGateways/{gatewayName}
        /// Operation Id: P2sVpnGateways_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<P2SVpnGateway>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _p2SVpnGatewayP2sVpnGatewaysClientDiagnostics.CreateScope("P2SVpnGateway.Get");
            scope.Start();
            try
            {
                var response = await _p2SVpnGatewayP2sVpnGatewaysRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _p2SVpnGatewayP2sVpnGatewaysClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new P2SVpnGateway(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves the details of a virtual wan p2s vpn gateway.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/p2svpnGateways/{gatewayName}
        /// Operation Id: P2sVpnGateways_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<P2SVpnGateway> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _p2SVpnGatewayP2sVpnGatewaysClientDiagnostics.CreateScope("P2SVpnGateway.Get");
            scope.Start();
            try
            {
                var response = _p2SVpnGatewayP2sVpnGatewaysRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw _p2SVpnGatewayP2sVpnGatewaysClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new P2SVpnGateway(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes a virtual wan p2s vpn gateway.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/p2svpnGateways/{gatewayName}
        /// Operation Id: P2sVpnGateways_Delete
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<ArmOperation> DeleteAsync(bool waitForCompletion, CancellationToken cancellationToken = default)
        {
            using var scope = _p2SVpnGatewayP2sVpnGatewaysClientDiagnostics.CreateScope("P2SVpnGateway.Delete");
            scope.Start();
            try
            {
                var response = await _p2SVpnGatewayP2sVpnGatewaysRestClient.DeleteAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new NetworkArmOperation(_p2SVpnGatewayP2sVpnGatewaysClientDiagnostics, Pipeline, _p2SVpnGatewayP2sVpnGatewaysRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name).Request, response, OperationFinalStateVia.Location);
                if (waitForCompletion)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes a virtual wan p2s vpn gateway.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/p2svpnGateways/{gatewayName}
        /// Operation Id: P2sVpnGateways_Delete
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(bool waitForCompletion, CancellationToken cancellationToken = default)
        {
            using var scope = _p2SVpnGatewayP2sVpnGatewaysClientDiagnostics.CreateScope("P2SVpnGateway.Delete");
            scope.Start();
            try
            {
                var response = _p2SVpnGatewayP2sVpnGatewaysRestClient.Delete(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                var operation = new NetworkArmOperation(_p2SVpnGatewayP2sVpnGatewaysClientDiagnostics, Pipeline, _p2SVpnGatewayP2sVpnGatewaysRestClient.CreateDeleteRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name).Request, response, OperationFinalStateVia.Location);
                if (waitForCompletion)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Resets the primary of the p2s vpn gateway in the specified resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/p2svpnGateways/{gatewayName}/reset
        /// Operation Id: P2sVpnGateways_Reset
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<ArmOperation<P2SVpnGateway>> ResetAsync(bool waitForCompletion, CancellationToken cancellationToken = default)
        {
            using var scope = _p2SVpnGatewayP2sVpnGatewaysClientDiagnostics.CreateScope("P2SVpnGateway.Reset");
            scope.Start();
            try
            {
                var response = await _p2SVpnGatewayP2sVpnGatewaysRestClient.ResetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new NetworkArmOperation<P2SVpnGateway>(new P2SVpnGatewayOperationSource(Client), _p2SVpnGatewayP2sVpnGatewaysClientDiagnostics, Pipeline, _p2SVpnGatewayP2sVpnGatewaysRestClient.CreateResetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name).Request, response, OperationFinalStateVia.Location);
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
        /// Resets the primary of the p2s vpn gateway in the specified resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/p2svpnGateways/{gatewayName}/reset
        /// Operation Id: P2sVpnGateways_Reset
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation<P2SVpnGateway> Reset(bool waitForCompletion, CancellationToken cancellationToken = default)
        {
            using var scope = _p2SVpnGatewayP2sVpnGatewaysClientDiagnostics.CreateScope("P2SVpnGateway.Reset");
            scope.Start();
            try
            {
                var response = _p2SVpnGatewayP2sVpnGatewaysRestClient.Reset(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                var operation = new NetworkArmOperation<P2SVpnGateway>(new P2SVpnGatewayOperationSource(Client), _p2SVpnGatewayP2sVpnGatewaysClientDiagnostics, Pipeline, _p2SVpnGatewayP2sVpnGatewaysRestClient.CreateResetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name).Request, response, OperationFinalStateVia.Location);
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
        /// Generates VPN profile for P2S client of the P2SVpnGateway in the specified resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/p2svpnGateways/{gatewayName}/generatevpnprofile
        /// Operation Id: P2sVpnGateways_GenerateVpnProfile
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="parameters"> Parameters supplied to the generate P2SVpnGateway VPN client package operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public async virtual Task<ArmOperation<VpnProfileResponse>> GenerateVpnProfileAsync(bool waitForCompletion, P2SVpnProfileParameters parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _p2SVpnGatewayP2sVpnGatewaysClientDiagnostics.CreateScope("P2SVpnGateway.GenerateVpnProfile");
            scope.Start();
            try
            {
                var response = await _p2SVpnGatewayP2sVpnGatewaysRestClient.GenerateVpnProfileAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new NetworkArmOperation<VpnProfileResponse>(new VpnProfileResponseOperationSource(), _p2SVpnGatewayP2sVpnGatewaysClientDiagnostics, Pipeline, _p2SVpnGatewayP2sVpnGatewaysRestClient.CreateGenerateVpnProfileRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, parameters).Request, response, OperationFinalStateVia.Location);
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
        /// Generates VPN profile for P2S client of the P2SVpnGateway in the specified resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/p2svpnGateways/{gatewayName}/generatevpnprofile
        /// Operation Id: P2sVpnGateways_GenerateVpnProfile
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="parameters"> Parameters supplied to the generate P2SVpnGateway VPN client package operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<VpnProfileResponse> GenerateVpnProfile(bool waitForCompletion, P2SVpnProfileParameters parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _p2SVpnGatewayP2sVpnGatewaysClientDiagnostics.CreateScope("P2SVpnGateway.GenerateVpnProfile");
            scope.Start();
            try
            {
                var response = _p2SVpnGatewayP2sVpnGatewaysRestClient.GenerateVpnProfile(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, parameters, cancellationToken);
                var operation = new NetworkArmOperation<VpnProfileResponse>(new VpnProfileResponseOperationSource(), _p2SVpnGatewayP2sVpnGatewaysClientDiagnostics, Pipeline, _p2SVpnGatewayP2sVpnGatewaysRestClient.CreateGenerateVpnProfileRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, parameters).Request, response, OperationFinalStateVia.Location);
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
        /// Gets the connection health of P2S clients of the virtual wan P2SVpnGateway in the specified resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/p2svpnGateways/{gatewayName}/getP2sVpnConnectionHealth
        /// Operation Id: P2sVpnGateways_GetP2SVpnConnectionHealth
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<ArmOperation<P2SVpnGateway>> GetP2SVpnConnectionHealthAsync(bool waitForCompletion, CancellationToken cancellationToken = default)
        {
            using var scope = _p2SVpnGatewayP2sVpnGatewaysClientDiagnostics.CreateScope("P2SVpnGateway.GetP2SVpnConnectionHealth");
            scope.Start();
            try
            {
                var response = await _p2SVpnGatewayP2sVpnGatewaysRestClient.GetP2SVpnConnectionHealthAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new NetworkArmOperation<P2SVpnGateway>(new P2SVpnGatewayOperationSource(Client), _p2SVpnGatewayP2sVpnGatewaysClientDiagnostics, Pipeline, _p2SVpnGatewayP2sVpnGatewaysRestClient.CreateGetP2SVpnConnectionHealthRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name).Request, response, OperationFinalStateVia.Location);
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
        /// Gets the connection health of P2S clients of the virtual wan P2SVpnGateway in the specified resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/p2svpnGateways/{gatewayName}/getP2sVpnConnectionHealth
        /// Operation Id: P2sVpnGateways_GetP2SVpnConnectionHealth
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation<P2SVpnGateway> GetP2SVpnConnectionHealth(bool waitForCompletion, CancellationToken cancellationToken = default)
        {
            using var scope = _p2SVpnGatewayP2sVpnGatewaysClientDiagnostics.CreateScope("P2SVpnGateway.GetP2SVpnConnectionHealth");
            scope.Start();
            try
            {
                var response = _p2SVpnGatewayP2sVpnGatewaysRestClient.GetP2SVpnConnectionHealth(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                var operation = new NetworkArmOperation<P2SVpnGateway>(new P2SVpnGatewayOperationSource(Client), _p2SVpnGatewayP2sVpnGatewaysClientDiagnostics, Pipeline, _p2SVpnGatewayP2sVpnGatewaysRestClient.CreateGetP2SVpnConnectionHealthRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name).Request, response, OperationFinalStateVia.Location);
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
        /// Gets the sas url to get the connection health detail of P2S clients of the virtual wan P2SVpnGateway in the specified resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/p2svpnGateways/{gatewayName}/getP2sVpnConnectionHealthDetailed
        /// Operation Id: P2sVpnGateways_GetP2SVpnConnectionHealthDetailed
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="request"> Request parameters supplied to get p2s vpn connections detailed health. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="request"/> is null. </exception>
        public async virtual Task<ArmOperation<P2SVpnConnectionHealth>> GetP2SVpnConnectionHealthDetailedAsync(bool waitForCompletion, P2SVpnConnectionHealthRequest request, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(request, nameof(request));

            using var scope = _p2SVpnGatewayP2sVpnGatewaysClientDiagnostics.CreateScope("P2SVpnGateway.GetP2SVpnConnectionHealthDetailed");
            scope.Start();
            try
            {
                var response = await _p2SVpnGatewayP2sVpnGatewaysRestClient.GetP2SVpnConnectionHealthDetailedAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, request, cancellationToken).ConfigureAwait(false);
                var operation = new NetworkArmOperation<P2SVpnConnectionHealth>(new P2SVpnConnectionHealthOperationSource(), _p2SVpnGatewayP2sVpnGatewaysClientDiagnostics, Pipeline, _p2SVpnGatewayP2sVpnGatewaysRestClient.CreateGetP2SVpnConnectionHealthDetailedRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, request).Request, response, OperationFinalStateVia.Location);
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
        /// Gets the sas url to get the connection health detail of P2S clients of the virtual wan P2SVpnGateway in the specified resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/p2svpnGateways/{gatewayName}/getP2sVpnConnectionHealthDetailed
        /// Operation Id: P2sVpnGateways_GetP2SVpnConnectionHealthDetailed
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="request"> Request parameters supplied to get p2s vpn connections detailed health. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="request"/> is null. </exception>
        public virtual ArmOperation<P2SVpnConnectionHealth> GetP2SVpnConnectionHealthDetailed(bool waitForCompletion, P2SVpnConnectionHealthRequest request, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(request, nameof(request));

            using var scope = _p2SVpnGatewayP2sVpnGatewaysClientDiagnostics.CreateScope("P2SVpnGateway.GetP2SVpnConnectionHealthDetailed");
            scope.Start();
            try
            {
                var response = _p2SVpnGatewayP2sVpnGatewaysRestClient.GetP2SVpnConnectionHealthDetailed(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, request, cancellationToken);
                var operation = new NetworkArmOperation<P2SVpnConnectionHealth>(new P2SVpnConnectionHealthOperationSource(), _p2SVpnGatewayP2sVpnGatewaysClientDiagnostics, Pipeline, _p2SVpnGatewayP2sVpnGatewaysRestClient.CreateGetP2SVpnConnectionHealthDetailedRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, request).Request, response, OperationFinalStateVia.Location);
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
        /// Disconnect P2S vpn connections of the virtual wan P2SVpnGateway in the specified resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/p2svpnGateways/{p2SVpnGatewayName}/disconnectP2sVpnConnections
        /// Operation Id: P2sVpnGateways_DisconnectP2SVpnConnections
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="request"> The parameters are supplied to disconnect p2s vpn connections. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="request"/> is null. </exception>
        public async virtual Task<ArmOperation> DisconnectP2SVpnConnectionsAsync(bool waitForCompletion, P2SVpnConnectionRequest request, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(request, nameof(request));

            using var scope = _p2SVpnGatewayP2sVpnGatewaysClientDiagnostics.CreateScope("P2SVpnGateway.DisconnectP2SVpnConnections");
            scope.Start();
            try
            {
                var response = await _p2SVpnGatewayP2sVpnGatewaysRestClient.DisconnectP2SVpnConnectionsAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, request, cancellationToken).ConfigureAwait(false);
                var operation = new NetworkArmOperation(_p2SVpnGatewayP2sVpnGatewaysClientDiagnostics, Pipeline, _p2SVpnGatewayP2sVpnGatewaysRestClient.CreateDisconnectP2SVpnConnectionsRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, request).Request, response, OperationFinalStateVia.Location);
                if (waitForCompletion)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Disconnect P2S vpn connections of the virtual wan P2SVpnGateway in the specified resource group.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/p2svpnGateways/{p2SVpnGatewayName}/disconnectP2sVpnConnections
        /// Operation Id: P2sVpnGateways_DisconnectP2SVpnConnections
        /// </summary>
        /// <param name="waitForCompletion"> Waits for the completion of the long running operations. </param>
        /// <param name="request"> The parameters are supplied to disconnect p2s vpn connections. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="request"/> is null. </exception>
        public virtual ArmOperation DisconnectP2SVpnConnections(bool waitForCompletion, P2SVpnConnectionRequest request, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(request, nameof(request));

            using var scope = _p2SVpnGatewayP2sVpnGatewaysClientDiagnostics.CreateScope("P2SVpnGateway.DisconnectP2SVpnConnections");
            scope.Start();
            try
            {
                var response = _p2SVpnGatewayP2sVpnGatewaysRestClient.DisconnectP2SVpnConnections(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, request, cancellationToken);
                var operation = new NetworkArmOperation(_p2SVpnGatewayP2sVpnGatewaysClientDiagnostics, Pipeline, _p2SVpnGatewayP2sVpnGatewaysRestClient.CreateDisconnectP2SVpnConnectionsRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, request).Request, response, OperationFinalStateVia.Location);
                if (waitForCompletion)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Add a tag to the current resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/p2svpnGateways/{gatewayName}
        /// Operation Id: P2sVpnGateways_Get
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        public async virtual Task<Response<P2SVpnGateway>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            using var scope = _p2SVpnGatewayP2sVpnGatewaysClientDiagnostics.CreateScope("P2SVpnGateway.AddTag");
            scope.Start();
            try
            {
                var originalTags = await TagResource.GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.Properties.TagsValue[key] = value;
                await TagResource.CreateOrUpdateAsync(true, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalResponse = await _p2SVpnGatewayP2sVpnGatewaysRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new P2SVpnGateway(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Add a tag to the current resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/p2svpnGateways/{gatewayName}
        /// Operation Id: P2sVpnGateways_Get
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        public virtual Response<P2SVpnGateway> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            using var scope = _p2SVpnGatewayP2sVpnGatewaysClientDiagnostics.CreateScope("P2SVpnGateway.AddTag");
            scope.Start();
            try
            {
                var originalTags = TagResource.Get(cancellationToken);
                originalTags.Value.Data.Properties.TagsValue[key] = value;
                TagResource.CreateOrUpdate(true, originalTags.Value.Data, cancellationToken: cancellationToken);
                var originalResponse = _p2SVpnGatewayP2sVpnGatewaysRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                return Response.FromValue(new P2SVpnGateway(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Replace the tags on the resource with the given set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/p2svpnGateways/{gatewayName}
        /// Operation Id: P2sVpnGateways_Get
        /// </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tags"/> is null. </exception>
        public async virtual Task<Response<P2SVpnGateway>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            using var scope = _p2SVpnGatewayP2sVpnGatewaysClientDiagnostics.CreateScope("P2SVpnGateway.SetTags");
            scope.Start();
            try
            {
                await TagResource.DeleteAsync(true, cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalTags = await TagResource.GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.Properties.TagsValue.ReplaceWith(tags);
                await TagResource.CreateOrUpdateAsync(true, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalResponse = await _p2SVpnGatewayP2sVpnGatewaysRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new P2SVpnGateway(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Replace the tags on the resource with the given set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/p2svpnGateways/{gatewayName}
        /// Operation Id: P2sVpnGateways_Get
        /// </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tags"/> is null. </exception>
        public virtual Response<P2SVpnGateway> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            using var scope = _p2SVpnGatewayP2sVpnGatewaysClientDiagnostics.CreateScope("P2SVpnGateway.SetTags");
            scope.Start();
            try
            {
                TagResource.Delete(true, cancellationToken: cancellationToken);
                var originalTags = TagResource.Get(cancellationToken);
                originalTags.Value.Data.Properties.TagsValue.ReplaceWith(tags);
                TagResource.CreateOrUpdate(true, originalTags.Value.Data, cancellationToken: cancellationToken);
                var originalResponse = _p2SVpnGatewayP2sVpnGatewaysRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                return Response.FromValue(new P2SVpnGateway(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Removes a tag by key from the resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/p2svpnGateways/{gatewayName}
        /// Operation Id: P2sVpnGateways_Get
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public async virtual Task<Response<P2SVpnGateway>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

            using var scope = _p2SVpnGatewayP2sVpnGatewaysClientDiagnostics.CreateScope("P2SVpnGateway.RemoveTag");
            scope.Start();
            try
            {
                var originalTags = await TagResource.GetAsync(cancellationToken).ConfigureAwait(false);
                originalTags.Value.Data.Properties.TagsValue.Remove(key);
                await TagResource.CreateOrUpdateAsync(true, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                var originalResponse = await _p2SVpnGatewayP2sVpnGatewaysRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new P2SVpnGateway(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Removes a tag by key from the resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/p2svpnGateways/{gatewayName}
        /// Operation Id: P2sVpnGateways_Get
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public virtual Response<P2SVpnGateway> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

            using var scope = _p2SVpnGatewayP2sVpnGatewaysClientDiagnostics.CreateScope("P2SVpnGateway.RemoveTag");
            scope.Start();
            try
            {
                var originalTags = TagResource.Get(cancellationToken);
                originalTags.Value.Data.Properties.TagsValue.Remove(key);
                TagResource.CreateOrUpdate(true, originalTags.Value.Data, cancellationToken: cancellationToken);
                var originalResponse = _p2SVpnGatewayP2sVpnGatewaysRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken);
                return Response.FromValue(new P2SVpnGateway(Client, originalResponse.Value), originalResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
