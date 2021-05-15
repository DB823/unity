// =====================================================
// DO NOT EDIT - this file is automatically regenerated.
// =====================================================

using System;
using Improbable.Gdk.Core;
using Improbable.Gdk.Core.Commands;

namespace Improbable.Restricted
{
    public partial class PlayerClient
    {
        public class ComponentMetaclass : IComponentMetaclass
        {
            public uint ComponentId => 61;
            public string Name => "PlayerClient";

            public Type Data { get; } = typeof(global::Improbable.Restricted.PlayerClient.Component);
            public Type Authority { get; } = typeof(global::Improbable.Restricted.PlayerClient.HasAuthority);
            public Type Snapshot { get; } = typeof(global::Improbable.Restricted.PlayerClient.Snapshot);
            public Type Update { get; } = typeof(global::Improbable.Restricted.PlayerClient.Update);

            public Type ReplicationSystem { get; } = typeof(global::Improbable.Restricted.PlayerClient.ReplicationSystem);
            public Type Serializer { get; } = typeof(global::Improbable.Restricted.PlayerClient.ComponentSerializer);
            public Type DiffDeserializer { get; } = typeof(global::Improbable.Restricted.PlayerClient.DiffComponentDeserializer);

            public Type DiffStorage { get; } = typeof(global::Improbable.Restricted.PlayerClient.DiffComponentStorage);
            public Type EcsViewManager { get; } = typeof(global::Improbable.Restricted.PlayerClient.EcsViewManager);
            public Type DynamicInvokable { get; } = typeof(global::Improbable.Restricted.PlayerClient.PlayerClientDynamic);

            public ICommandMetaclass[] Commands { get; } = new ICommandMetaclass[]
            {
            };
        }
    }
}
