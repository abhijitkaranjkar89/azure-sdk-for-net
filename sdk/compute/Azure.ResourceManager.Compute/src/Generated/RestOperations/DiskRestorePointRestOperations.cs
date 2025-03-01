// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Core;

namespace Azure.ResourceManager.Compute
{
    internal partial class DiskRestorePointRestOperations
    {
        private readonly string _userAgent;
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> Initializes a new instance of DiskRestorePointRestOperations. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="applicationId"> The application id to use for user agent. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="apiVersion"> Api Version. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="apiVersion"/> is null. </exception>
        public DiskRestorePointRestOperations(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string applicationId, Uri endpoint = null, string apiVersion = default)
        {
            _endpoint = endpoint ?? new Uri("https://management.azure.com");
            _apiVersion = apiVersion ?? "2021-08-01";
            ClientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
            _userAgent = Core.HttpMessageUtilities.GetUserAgentName(this, applicationId);
        }

        internal HttpMessage CreateGetRequest(string subscriptionId, string resourceGroupName, string restorePointCollectionName, string vmRestorePointName, string diskRestorePointName)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.Compute/restorePointCollections/", false);
            uri.AppendPath(restorePointCollectionName, true);
            uri.AppendPath("/restorePoints/", false);
            uri.AppendPath(vmRestorePointName, true);
            uri.AppendPath("/diskRestorePoints/", false);
            uri.AppendPath(diskRestorePointName, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            message.SetProperty("SDKUserAgent", _userAgent);
            return message;
        }

        /// <summary> Get disk restorePoint resource. </summary>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="restorePointCollectionName"> The name of the restore point collection that the disk restore point belongs. </param>
        /// <param name="vmRestorePointName"> The name of the vm restore point that the disk disk restore point belongs. </param>
        /// <param name="diskRestorePointName"> The name of the disk restore point created. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="restorePointCollectionName"/>, <paramref name="vmRestorePointName"/> or <paramref name="diskRestorePointName"/> is null. </exception>
        public async Task<Response<DiskRestorePointData>> GetAsync(string subscriptionId, string resourceGroupName, string restorePointCollectionName, string vmRestorePointName, string diskRestorePointName, CancellationToken cancellationToken = default)
        {
            if (subscriptionId == null)
            {
                throw new ArgumentNullException(nameof(subscriptionId));
            }
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (restorePointCollectionName == null)
            {
                throw new ArgumentNullException(nameof(restorePointCollectionName));
            }
            if (vmRestorePointName == null)
            {
                throw new ArgumentNullException(nameof(vmRestorePointName));
            }
            if (diskRestorePointName == null)
            {
                throw new ArgumentNullException(nameof(diskRestorePointName));
            }

            using var message = CreateGetRequest(subscriptionId, resourceGroupName, restorePointCollectionName, vmRestorePointName, diskRestorePointName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DiskRestorePointData value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = DiskRestorePointData.DeserializeDiskRestorePointData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((DiskRestorePointData)null, message.Response);
                default:
                    throw await ClientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Get disk restorePoint resource. </summary>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="restorePointCollectionName"> The name of the restore point collection that the disk restore point belongs. </param>
        /// <param name="vmRestorePointName"> The name of the vm restore point that the disk disk restore point belongs. </param>
        /// <param name="diskRestorePointName"> The name of the disk restore point created. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="restorePointCollectionName"/>, <paramref name="vmRestorePointName"/> or <paramref name="diskRestorePointName"/> is null. </exception>
        public Response<DiskRestorePointData> Get(string subscriptionId, string resourceGroupName, string restorePointCollectionName, string vmRestorePointName, string diskRestorePointName, CancellationToken cancellationToken = default)
        {
            if (subscriptionId == null)
            {
                throw new ArgumentNullException(nameof(subscriptionId));
            }
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (restorePointCollectionName == null)
            {
                throw new ArgumentNullException(nameof(restorePointCollectionName));
            }
            if (vmRestorePointName == null)
            {
                throw new ArgumentNullException(nameof(vmRestorePointName));
            }
            if (diskRestorePointName == null)
            {
                throw new ArgumentNullException(nameof(diskRestorePointName));
            }

            using var message = CreateGetRequest(subscriptionId, resourceGroupName, restorePointCollectionName, vmRestorePointName, diskRestorePointName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DiskRestorePointData value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = DiskRestorePointData.DeserializeDiskRestorePointData(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                case 404:
                    return Response.FromValue((DiskRestorePointData)null, message.Response);
                default:
                    throw ClientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateListByRestorePointRequest(string subscriptionId, string resourceGroupName, string restorePointCollectionName, string vmRestorePointName)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.Compute/restorePointCollections/", false);
            uri.AppendPath(restorePointCollectionName, true);
            uri.AppendPath("/restorePoints/", false);
            uri.AppendPath(vmRestorePointName, true);
            uri.AppendPath("/diskRestorePoints", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            message.SetProperty("SDKUserAgent", _userAgent);
            return message;
        }

        /// <summary> Lists diskRestorePoints under a vmRestorePoint. </summary>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="restorePointCollectionName"> The name of the restore point collection that the disk restore point belongs. </param>
        /// <param name="vmRestorePointName"> The name of the vm restore point that the disk disk restore point belongs. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="restorePointCollectionName"/> or <paramref name="vmRestorePointName"/> is null. </exception>
        public async Task<Response<DiskRestorePointList>> ListByRestorePointAsync(string subscriptionId, string resourceGroupName, string restorePointCollectionName, string vmRestorePointName, CancellationToken cancellationToken = default)
        {
            if (subscriptionId == null)
            {
                throw new ArgumentNullException(nameof(subscriptionId));
            }
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (restorePointCollectionName == null)
            {
                throw new ArgumentNullException(nameof(restorePointCollectionName));
            }
            if (vmRestorePointName == null)
            {
                throw new ArgumentNullException(nameof(vmRestorePointName));
            }

            using var message = CreateListByRestorePointRequest(subscriptionId, resourceGroupName, restorePointCollectionName, vmRestorePointName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DiskRestorePointList value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = DiskRestorePointList.DeserializeDiskRestorePointList(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw await ClientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Lists diskRestorePoints under a vmRestorePoint. </summary>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="restorePointCollectionName"> The name of the restore point collection that the disk restore point belongs. </param>
        /// <param name="vmRestorePointName"> The name of the vm restore point that the disk disk restore point belongs. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="restorePointCollectionName"/> or <paramref name="vmRestorePointName"/> is null. </exception>
        public Response<DiskRestorePointList> ListByRestorePoint(string subscriptionId, string resourceGroupName, string restorePointCollectionName, string vmRestorePointName, CancellationToken cancellationToken = default)
        {
            if (subscriptionId == null)
            {
                throw new ArgumentNullException(nameof(subscriptionId));
            }
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (restorePointCollectionName == null)
            {
                throw new ArgumentNullException(nameof(restorePointCollectionName));
            }
            if (vmRestorePointName == null)
            {
                throw new ArgumentNullException(nameof(vmRestorePointName));
            }

            using var message = CreateListByRestorePointRequest(subscriptionId, resourceGroupName, restorePointCollectionName, vmRestorePointName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DiskRestorePointList value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = DiskRestorePointList.DeserializeDiskRestorePointList(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw ClientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateGrantAccessRequest(string subscriptionId, string resourceGroupName, string restorePointCollectionName, string vmRestorePointName, string diskRestorePointName, GrantAccessData grantAccessData)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.Compute/restorePointCollections/", false);
            uri.AppendPath(restorePointCollectionName, true);
            uri.AppendPath("/restorePoints/", false);
            uri.AppendPath(vmRestorePointName, true);
            uri.AppendPath("/diskRestorePoints/", false);
            uri.AppendPath(diskRestorePointName, true);
            uri.AppendPath("/beginGetAccess", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(grantAccessData);
            request.Content = content;
            message.SetProperty("SDKUserAgent", _userAgent);
            return message;
        }

        /// <summary> Grants access to a diskRestorePoint. </summary>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="restorePointCollectionName"> The name of the restore point collection that the disk restore point belongs. </param>
        /// <param name="vmRestorePointName"> The name of the vm restore point that the disk disk restore point belongs. </param>
        /// <param name="diskRestorePointName"> The name of the disk restore point created. </param>
        /// <param name="grantAccessData"> Access data object supplied in the body of the get disk access operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="restorePointCollectionName"/>, <paramref name="vmRestorePointName"/>, <paramref name="diskRestorePointName"/> or <paramref name="grantAccessData"/> is null. </exception>
        public async Task<Response> GrantAccessAsync(string subscriptionId, string resourceGroupName, string restorePointCollectionName, string vmRestorePointName, string diskRestorePointName, GrantAccessData grantAccessData, CancellationToken cancellationToken = default)
        {
            if (subscriptionId == null)
            {
                throw new ArgumentNullException(nameof(subscriptionId));
            }
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (restorePointCollectionName == null)
            {
                throw new ArgumentNullException(nameof(restorePointCollectionName));
            }
            if (vmRestorePointName == null)
            {
                throw new ArgumentNullException(nameof(vmRestorePointName));
            }
            if (diskRestorePointName == null)
            {
                throw new ArgumentNullException(nameof(diskRestorePointName));
            }
            if (grantAccessData == null)
            {
                throw new ArgumentNullException(nameof(grantAccessData));
            }

            using var message = CreateGrantAccessRequest(subscriptionId, resourceGroupName, restorePointCollectionName, vmRestorePointName, diskRestorePointName, grantAccessData);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                    return message.Response;
                default:
                    throw await ClientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Grants access to a diskRestorePoint. </summary>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="restorePointCollectionName"> The name of the restore point collection that the disk restore point belongs. </param>
        /// <param name="vmRestorePointName"> The name of the vm restore point that the disk disk restore point belongs. </param>
        /// <param name="diskRestorePointName"> The name of the disk restore point created. </param>
        /// <param name="grantAccessData"> Access data object supplied in the body of the get disk access operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="restorePointCollectionName"/>, <paramref name="vmRestorePointName"/>, <paramref name="diskRestorePointName"/> or <paramref name="grantAccessData"/> is null. </exception>
        public Response GrantAccess(string subscriptionId, string resourceGroupName, string restorePointCollectionName, string vmRestorePointName, string diskRestorePointName, GrantAccessData grantAccessData, CancellationToken cancellationToken = default)
        {
            if (subscriptionId == null)
            {
                throw new ArgumentNullException(nameof(subscriptionId));
            }
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (restorePointCollectionName == null)
            {
                throw new ArgumentNullException(nameof(restorePointCollectionName));
            }
            if (vmRestorePointName == null)
            {
                throw new ArgumentNullException(nameof(vmRestorePointName));
            }
            if (diskRestorePointName == null)
            {
                throw new ArgumentNullException(nameof(diskRestorePointName));
            }
            if (grantAccessData == null)
            {
                throw new ArgumentNullException(nameof(grantAccessData));
            }

            using var message = CreateGrantAccessRequest(subscriptionId, resourceGroupName, restorePointCollectionName, vmRestorePointName, diskRestorePointName, grantAccessData);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                    return message.Response;
                default:
                    throw ClientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateRevokeAccessRequest(string subscriptionId, string resourceGroupName, string restorePointCollectionName, string vmRestorePointName, string diskRestorePointName)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/subscriptions/", false);
            uri.AppendPath(subscriptionId, true);
            uri.AppendPath("/resourceGroups/", false);
            uri.AppendPath(resourceGroupName, true);
            uri.AppendPath("/providers/Microsoft.Compute/restorePointCollections/", false);
            uri.AppendPath(restorePointCollectionName, true);
            uri.AppendPath("/restorePoints/", false);
            uri.AppendPath(vmRestorePointName, true);
            uri.AppendPath("/diskRestorePoints/", false);
            uri.AppendPath(diskRestorePointName, true);
            uri.AppendPath("/endGetAccess", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            message.SetProperty("SDKUserAgent", _userAgent);
            return message;
        }

        /// <summary> Revokes access to a diskRestorePoint. </summary>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="restorePointCollectionName"> The name of the restore point collection that the disk restore point belongs. </param>
        /// <param name="vmRestorePointName"> The name of the vm restore point that the disk disk restore point belongs. </param>
        /// <param name="diskRestorePointName"> The name of the disk restore point created. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="restorePointCollectionName"/>, <paramref name="vmRestorePointName"/> or <paramref name="diskRestorePointName"/> is null. </exception>
        public async Task<Response> RevokeAccessAsync(string subscriptionId, string resourceGroupName, string restorePointCollectionName, string vmRestorePointName, string diskRestorePointName, CancellationToken cancellationToken = default)
        {
            if (subscriptionId == null)
            {
                throw new ArgumentNullException(nameof(subscriptionId));
            }
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (restorePointCollectionName == null)
            {
                throw new ArgumentNullException(nameof(restorePointCollectionName));
            }
            if (vmRestorePointName == null)
            {
                throw new ArgumentNullException(nameof(vmRestorePointName));
            }
            if (diskRestorePointName == null)
            {
                throw new ArgumentNullException(nameof(diskRestorePointName));
            }

            using var message = CreateRevokeAccessRequest(subscriptionId, resourceGroupName, restorePointCollectionName, vmRestorePointName, diskRestorePointName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                    return message.Response;
                default:
                    throw await ClientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Revokes access to a diskRestorePoint. </summary>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="restorePointCollectionName"> The name of the restore point collection that the disk restore point belongs. </param>
        /// <param name="vmRestorePointName"> The name of the vm restore point that the disk disk restore point belongs. </param>
        /// <param name="diskRestorePointName"> The name of the disk restore point created. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="restorePointCollectionName"/>, <paramref name="vmRestorePointName"/> or <paramref name="diskRestorePointName"/> is null. </exception>
        public Response RevokeAccess(string subscriptionId, string resourceGroupName, string restorePointCollectionName, string vmRestorePointName, string diskRestorePointName, CancellationToken cancellationToken = default)
        {
            if (subscriptionId == null)
            {
                throw new ArgumentNullException(nameof(subscriptionId));
            }
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (restorePointCollectionName == null)
            {
                throw new ArgumentNullException(nameof(restorePointCollectionName));
            }
            if (vmRestorePointName == null)
            {
                throw new ArgumentNullException(nameof(vmRestorePointName));
            }
            if (diskRestorePointName == null)
            {
                throw new ArgumentNullException(nameof(diskRestorePointName));
            }

            using var message = CreateRevokeAccessRequest(subscriptionId, resourceGroupName, restorePointCollectionName, vmRestorePointName, diskRestorePointName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                case 202:
                    return message.Response;
                default:
                    throw ClientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }

        internal HttpMessage CreateListByRestorePointNextPageRequest(string nextLink, string subscriptionId, string resourceGroupName, string restorePointCollectionName, string vmRestorePointName)
        {
            var message = _pipeline.CreateMessage();
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRawNextLink(nextLink, false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            message.SetProperty("SDKUserAgent", _userAgent);
            return message;
        }

        /// <summary> Lists diskRestorePoints under a vmRestorePoint. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="restorePointCollectionName"> The name of the restore point collection that the disk restore point belongs. </param>
        /// <param name="vmRestorePointName"> The name of the vm restore point that the disk disk restore point belongs. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/>, <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="restorePointCollectionName"/> or <paramref name="vmRestorePointName"/> is null. </exception>
        public async Task<Response<DiskRestorePointList>> ListByRestorePointNextPageAsync(string nextLink, string subscriptionId, string resourceGroupName, string restorePointCollectionName, string vmRestorePointName, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }
            if (subscriptionId == null)
            {
                throw new ArgumentNullException(nameof(subscriptionId));
            }
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (restorePointCollectionName == null)
            {
                throw new ArgumentNullException(nameof(restorePointCollectionName));
            }
            if (vmRestorePointName == null)
            {
                throw new ArgumentNullException(nameof(vmRestorePointName));
            }

            using var message = CreateListByRestorePointNextPageRequest(nextLink, subscriptionId, resourceGroupName, restorePointCollectionName, vmRestorePointName);
            await _pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DiskRestorePointList value = default;
                        using var document = await JsonDocument.ParseAsync(message.Response.ContentStream, default, cancellationToken).ConfigureAwait(false);
                        value = DiskRestorePointList.DeserializeDiskRestorePointList(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw await ClientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
            }
        }

        /// <summary> Lists diskRestorePoints under a vmRestorePoint. </summary>
        /// <param name="nextLink"> The URL to the next page of results. </param>
        /// <param name="subscriptionId"> Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call. </param>
        /// <param name="resourceGroupName"> The name of the resource group. </param>
        /// <param name="restorePointCollectionName"> The name of the restore point collection that the disk restore point belongs. </param>
        /// <param name="vmRestorePointName"> The name of the vm restore point that the disk disk restore point belongs. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nextLink"/>, <paramref name="subscriptionId"/>, <paramref name="resourceGroupName"/>, <paramref name="restorePointCollectionName"/> or <paramref name="vmRestorePointName"/> is null. </exception>
        public Response<DiskRestorePointList> ListByRestorePointNextPage(string nextLink, string subscriptionId, string resourceGroupName, string restorePointCollectionName, string vmRestorePointName, CancellationToken cancellationToken = default)
        {
            if (nextLink == null)
            {
                throw new ArgumentNullException(nameof(nextLink));
            }
            if (subscriptionId == null)
            {
                throw new ArgumentNullException(nameof(subscriptionId));
            }
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException(nameof(resourceGroupName));
            }
            if (restorePointCollectionName == null)
            {
                throw new ArgumentNullException(nameof(restorePointCollectionName));
            }
            if (vmRestorePointName == null)
            {
                throw new ArgumentNullException(nameof(vmRestorePointName));
            }

            using var message = CreateListByRestorePointNextPageRequest(nextLink, subscriptionId, resourceGroupName, restorePointCollectionName, vmRestorePointName);
            _pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case 200:
                    {
                        DiskRestorePointList value = default;
                        using var document = JsonDocument.Parse(message.Response.ContentStream);
                        value = DiskRestorePointList.DeserializeDiskRestorePointList(document.RootElement);
                        return Response.FromValue(value, message.Response);
                    }
                default:
                    throw ClientDiagnostics.CreateRequestFailedException(message.Response);
            }
        }
    }
}
