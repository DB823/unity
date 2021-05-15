// =====================================================
// DO NOT EDIT - this file is automatically regenerated.
// =====================================================

using System;
using Improbable.Gdk.Core;
using Improbable.Gdk.Core.Commands;

namespace Improbable.Gdk.PlayerLifecycle
{
    public partial class PlayerHeartbeatClient
    {
        public class ComponentMetaclass : IComponentMetaclass
        {
            public uint ComponentId => 13001;
            public string Name => "PlayerHeartbeatClient";

            public Type Data { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.PlayerHeartbeatClient.Component);
            public Type Authority { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.PlayerHeartbeatClient.HasAuthority);
            public Type Snapshot { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.PlayerHeartbeatClient.Snapshot);
            public Type Update { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.PlayerHeartbeatClient.Update);

            public Type ReplicationSystem { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.PlayerHeartbeatClient.ReplicationSystem);
            public Type Serializer { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.PlayerHeartbeatClient.ComponentSerializer);
            public Type DiffDeserializer { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.PlayerHeartbeatClient.DiffComponentDeserializer);

            public Type DiffStorage { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.PlayerHeartbeatClient.DiffComponentStorage);
            public Type EcsViewManager { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.PlayerHeartbeatClient.EcsViewManager);
            public Type DynamicInvokable { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.PlayerHeartbeatClient.PlayerHeartbeatClientDynamic);

            public ICommandMetaclass[] Commands { get; } = new ICommandMetaclass[]
            {
                new PlayerHeartbeatMetaclass()
            };
        }

        public class PlayerHeartbeatMetaclass : ICommandMetaclass
        {
            public uint ComponentId => global::Improbable.Gdk.PlayerLifecycle.PlayerHeartbeatClient.ComponentId;
            public uint CommandIndex => 1;
            public string Name => "PlayerHeartbeat";

            public Type DiffDeserializer { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.PlayerHeartbeatClient.PlayerHeartbeatDiffCommandDeserializer);
            public Type Serializer { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.PlayerHeartbeatClient.PlayerHeartbeatCommandSerializer);

            public Type MetaDataStorage { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.PlayerHeartbeatClient.PlayerHeartbeatCommandMetaDataStorage);
            public Type SendStorage { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.PlayerHeartbeatClient.PlayerHeartbeatCommandsToSendStorage);
            public Type DiffStorage { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.PlayerHeartbeatClient.DiffPlayerHeartbeatCommandStorage);

            public Type Response { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.PlayerHeartbeatClient.PlayerHeartbeat.Response);
            public Type ReceivedResponse { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.PlayerHeartbeatClient.PlayerHeartbeat.ReceivedResponse);
            public Type Request { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.PlayerHeartbeatClient.PlayerHeartbeat.Request);
            public Type ReceivedRequest { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.PlayerHeartbeatClient.PlayerHeartbeat.ReceivedRequest);
        }
    }
}
