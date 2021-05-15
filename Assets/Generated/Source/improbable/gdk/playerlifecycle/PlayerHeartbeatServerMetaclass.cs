// =====================================================
// DO NOT EDIT - this file is automatically regenerated.
// =====================================================

using System;
using Improbable.Gdk.Core;
using Improbable.Gdk.Core.Commands;

namespace Improbable.Gdk.PlayerLifecycle
{
    public partial class PlayerHeartbeatServer
    {
        public class ComponentMetaclass : IComponentMetaclass
        {
            public uint ComponentId => 13002;
            public string Name => "PlayerHeartbeatServer";

            public Type Data { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.PlayerHeartbeatServer.Component);
            public Type Authority { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.PlayerHeartbeatServer.HasAuthority);
            public Type Snapshot { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.PlayerHeartbeatServer.Snapshot);
            public Type Update { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.PlayerHeartbeatServer.Update);

            public Type ReplicationSystem { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.PlayerHeartbeatServer.ReplicationSystem);
            public Type Serializer { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.PlayerHeartbeatServer.ComponentSerializer);
            public Type DiffDeserializer { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.PlayerHeartbeatServer.DiffComponentDeserializer);

            public Type DiffStorage { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.PlayerHeartbeatServer.DiffComponentStorage);
            public Type EcsViewManager { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.PlayerHeartbeatServer.EcsViewManager);
            public Type DynamicInvokable { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.PlayerHeartbeatServer.PlayerHeartbeatServerDynamic);

            public ICommandMetaclass[] Commands { get; } = new ICommandMetaclass[]
            {
            };
        }
    }
}
