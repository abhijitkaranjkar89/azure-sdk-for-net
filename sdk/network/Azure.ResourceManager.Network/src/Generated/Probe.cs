// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;

namespace Azure.ResourceManager.Network
{
    /// <summary> A Class representing a Probe along with the instance operations that can be performed on it. </summary>
    public partial class Probe : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="Probe"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string loadBalancerName, string probeName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/loadBalancers/{loadBalancerName}/probes/{probeName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _probeLoadBalancerProbesClientDiagnostics;
        private readonly LoadBalancerProbesRestOperations _probeLoadBalancerProbesRestClient;
        private readonly ProbeData _data;

        /// <summary> Initializes a new instance of the <see cref="Probe"/> class for mocking. </summary>
        protected Probe()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "Probe"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal Probe(ArmClient client, ProbeData data) : this(client, new ResourceIdentifier(data.Id))
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="Probe"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal Probe(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _probeLoadBalancerProbesClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Network", ResourceType.Namespace, DiagnosticOptions);
            TryGetApiVersion(ResourceType, out string probeLoadBalancerProbesApiVersion);
            _probeLoadBalancerProbesRestClient = new LoadBalancerProbesRestOperations(_probeLoadBalancerProbesClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, probeLoadBalancerProbesApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Network/loadBalancers/probes";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual ProbeData Data
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
        /// Gets load balancer probe.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/loadBalancers/{loadBalancerName}/probes/{probeName}
        /// Operation Id: LoadBalancerProbes_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public async virtual Task<Response<Probe>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _probeLoadBalancerProbesClientDiagnostics.CreateScope("Probe.Get");
            scope.Start();
            try
            {
                var response = await _probeLoadBalancerProbesRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _probeLoadBalancerProbesClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new Probe(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets load balancer probe.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/loadBalancers/{loadBalancerName}/probes/{probeName}
        /// Operation Id: LoadBalancerProbes_Get
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Probe> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _probeLoadBalancerProbesClientDiagnostics.CreateScope("Probe.Get");
            scope.Start();
            try
            {
                var response = _probeLoadBalancerProbesRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw _probeLoadBalancerProbesClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new Probe(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
