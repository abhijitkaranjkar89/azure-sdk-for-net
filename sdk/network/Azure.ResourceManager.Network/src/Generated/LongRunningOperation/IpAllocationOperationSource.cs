// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.Network
{
    internal class IpAllocationOperationSource : IOperationSource<IpAllocation>
    {
        private readonly ArmClient _client;

        internal IpAllocationOperationSource(ArmClient client)
        {
            _client = client;
        }

        IpAllocation IOperationSource<IpAllocation>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            var data = IpAllocationData.DeserializeIpAllocationData(document.RootElement);
            return new IpAllocation(_client, data);
        }

        async ValueTask<IpAllocation> IOperationSource<IpAllocation>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            var data = IpAllocationData.DeserializeIpAllocationData(document.RootElement);
            return new IpAllocation(_client, data);
        }
    }
}
