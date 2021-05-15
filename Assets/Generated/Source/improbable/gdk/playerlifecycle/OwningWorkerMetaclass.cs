// =====================================================
// DO NOT EDIT - this file is automatically regenerated.
// =====================================================

using System;
using Improbable.Gdk.Core;
using Improbable.Gdk.Core.Commands;

namespace Improbable.Gdk.PlayerLifecycle
{
    public partial class OwningWorker
    {
        public class ComponentMetaclass : IComponentMetaclass
        {
            public uint ComponentId => 13003;
            public string Name => "OwningWorker";

            public Type Data { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.OwningWorker.Component);
            public Type Authority { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.OwningWorker.HasAuthority);
            public Type Snapshot { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.OwningWorker.Snapshot);
            public Type Update { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.OwningWorker.Update);

            public Type ReplicationSystem { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.OwningWorker.ReplicationSystem);
            public Type Serializer { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.OwningWorker.ComponentSerializer);
            public Type DiffDeserializer { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.OwningWorker.DiffComponentDeserializer);

            public Type DiffStorage { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.OwningWorker.DiffComponentStorage);
            public Type EcsViewManager { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.OwningWorker.EcsViewManager);
            public Type DynamicInvokable { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.OwningWorker.OwningWorkerDynamic);

            public ICommandMetaclass[] Commands { get; } = new ICommandMetaclass[]
            {
            };
        }
    }
}
