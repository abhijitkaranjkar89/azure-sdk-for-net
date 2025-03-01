// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.WebPubSub.Models;

namespace Azure.ResourceManager.WebPubSub
{
    /// <summary> A class representing the WebPubSub data model. </summary>
    public partial class WebPubSubData : TrackedResourceData
    {
        /// <summary> Initializes a new instance of WebPubSubData. </summary>
        /// <param name="location"> The location. </param>
        public WebPubSubData(AzureLocation location) : base(location)
        {
            PrivateEndpointConnections = new ChangeTrackingList<PrivateEndpointConnectionData>();
            SharedPrivateLinkResources = new ChangeTrackingList<SharedPrivateLinkData>();
        }

        /// <summary> Initializes a new instance of WebPubSubData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="type"> The type. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="sku"> The billing information of the resource.(e.g. Free, Standard). </param>
        /// <param name="identity"> The managed identity response. </param>
        /// <param name="provisioningState"> Provisioning state of the resource. </param>
        /// <param name="externalIP"> The publicly accessible IP of the resource. </param>
        /// <param name="hostName"> FQDN of the service instance. </param>
        /// <param name="publicPort"> The publicly accessible port of the resource which is designed for browser/client side usage. </param>
        /// <param name="serverPort"> The publicly accessible port of the resource which is designed for customer server side usage. </param>
        /// <param name="version"> Version of the resource. Probably you need the same or higher version of client SDKs. </param>
        /// <param name="privateEndpointConnections"> Private endpoint connections to the resource. </param>
        /// <param name="sharedPrivateLinkResources"> The list of shared private link resources. </param>
        /// <param name="tls"> TLS settings. </param>
        /// <param name="hostNamePrefix"> Deprecated. </param>
        /// <param name="liveTraceConfiguration"> Live trace configuration of a Microsoft.SignalRService resource. </param>
        /// <param name="resourceLogConfiguration">
        /// Resource log configuration of a Microsoft.SignalRService resource.
        /// If resourceLogConfiguration isn&apos;t null or empty, it will override options &quot;EnableConnectivityLog&quot; and &quot;EnableMessagingLogs&quot; in features.
        /// Otherwise, use options &quot;EnableConnectivityLog&quot; and &quot;EnableMessagingLogs&quot; in features.
        /// </param>
        /// <param name="networkAcls"> Network Acls. </param>
        /// <param name="publicNetworkAccess">
        /// Enable or disable public network access. Default to &quot;Enabled&quot;.
        /// When it&apos;s Enabled, network ACLs still apply.
        /// When it&apos;s Disabled, public network access is always disabled no matter what you set in network ACLs.
        /// </param>
        /// <param name="disableLocalAuth">
        /// DisableLocalAuth
        /// Enable or disable local auth with AccessKey
        /// When set as true, connection with AccessKey=xxx won&apos;t work.
        /// </param>
        /// <param name="disableAadAuth">
        /// DisableLocalAuth
        /// Enable or disable aad auth
        /// When set as true, connection with AuthType=aad won&apos;t work.
        /// </param>
        internal WebPubSubData(ResourceIdentifier id, string name, ResourceType type, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, WebPubSubSku sku, ManagedIdentity identity, ProvisioningState? provisioningState, string externalIP, string hostName, int? publicPort, int? serverPort, string version, IReadOnlyList<PrivateEndpointConnectionData> privateEndpointConnections, IReadOnlyList<SharedPrivateLinkData> sharedPrivateLinkResources, WebPubSubTlsSettings tls, string hostNamePrefix, LiveTraceConfiguration liveTraceConfiguration, ResourceLogConfiguration resourceLogConfiguration, WebPubSubNetworkAcls networkAcls, string publicNetworkAccess, bool? disableLocalAuth, bool? disableAadAuth) : base(id, name, type, systemData, tags, location)
        {
            Sku = sku;
            Identity = identity;
            ProvisioningState = provisioningState;
            ExternalIP = externalIP;
            HostName = hostName;
            PublicPort = publicPort;
            ServerPort = serverPort;
            Version = version;
            PrivateEndpointConnections = privateEndpointConnections;
            SharedPrivateLinkResources = sharedPrivateLinkResources;
            Tls = tls;
            HostNamePrefix = hostNamePrefix;
            LiveTraceConfiguration = liveTraceConfiguration;
            ResourceLogConfiguration = resourceLogConfiguration;
            NetworkAcls = networkAcls;
            PublicNetworkAccess = publicNetworkAccess;
            DisableLocalAuth = disableLocalAuth;
            DisableAadAuth = disableAadAuth;
        }

        /// <summary> The billing information of the resource.(e.g. Free, Standard). </summary>
        public WebPubSubSku Sku { get; set; }
        /// <summary> The managed identity response. </summary>
        public ManagedIdentity Identity { get; set; }
        /// <summary> Provisioning state of the resource. </summary>
        public ProvisioningState? ProvisioningState { get; }
        /// <summary> The publicly accessible IP of the resource. </summary>
        public string ExternalIP { get; }
        /// <summary> FQDN of the service instance. </summary>
        public string HostName { get; }
        /// <summary> The publicly accessible port of the resource which is designed for browser/client side usage. </summary>
        public int? PublicPort { get; }
        /// <summary> The publicly accessible port of the resource which is designed for customer server side usage. </summary>
        public int? ServerPort { get; }
        /// <summary> Version of the resource. Probably you need the same or higher version of client SDKs. </summary>
        public string Version { get; }
        /// <summary> Private endpoint connections to the resource. </summary>
        public IReadOnlyList<PrivateEndpointConnectionData> PrivateEndpointConnections { get; }
        /// <summary> The list of shared private link resources. </summary>
        public IReadOnlyList<SharedPrivateLinkData> SharedPrivateLinkResources { get; }
        /// <summary> TLS settings. </summary>
        public WebPubSubTlsSettings Tls { get; set; }
        /// <summary> Deprecated. </summary>
        public string HostNamePrefix { get; }
        /// <summary> Live trace configuration of a Microsoft.SignalRService resource. </summary>
        public LiveTraceConfiguration LiveTraceConfiguration { get; set; }
        /// <summary>
        /// Resource log configuration of a Microsoft.SignalRService resource.
        /// If resourceLogConfiguration isn&apos;t null or empty, it will override options &quot;EnableConnectivityLog&quot; and &quot;EnableMessagingLogs&quot; in features.
        /// Otherwise, use options &quot;EnableConnectivityLog&quot; and &quot;EnableMessagingLogs&quot; in features.
        /// </summary>
        public ResourceLogConfiguration ResourceLogConfiguration { get; set; }
        /// <summary> Network Acls. </summary>
        public WebPubSubNetworkAcls NetworkAcls { get; set; }
        /// <summary>
        /// Enable or disable public network access. Default to &quot;Enabled&quot;.
        /// When it&apos;s Enabled, network ACLs still apply.
        /// When it&apos;s Disabled, public network access is always disabled no matter what you set in network ACLs.
        /// </summary>
        public string PublicNetworkAccess { get; set; }
        /// <summary>
        /// DisableLocalAuth
        /// Enable or disable local auth with AccessKey
        /// When set as true, connection with AccessKey=xxx won&apos;t work.
        /// </summary>
        public bool? DisableLocalAuth { get; set; }
        /// <summary>
        /// DisableLocalAuth
        /// Enable or disable aad auth
        /// When set as true, connection with AuthType=aad won&apos;t work.
        /// </summary>
        public bool? DisableAadAuth { get; set; }
    }
}
