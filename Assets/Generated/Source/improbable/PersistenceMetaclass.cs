// =====================================================
// DO NOT EDIT - this file is automatically regenerated.
// =====================================================

using System;
using Improbable.Gdk.Core;
using Improbable.Gdk.Core.Commands;

namespace Improbable
{
    public partial class Persistence
    {
        public class ComponentMetaclass : IComponentMetaclass
        {
            public uint ComponentId => 55;
            public string Name => "Persistence";

            public Type Data { get; } = typeof(global::Improbable.Persistence.Component);
            public Type Authority { get; } = typeof(global::Improbable.Persistence.HasAuthority);
            public Type Snapshot { get; } = typeof(global::Improbable.Persistence.Snapshot);
            public Type Update { get; } = typeof(global::Improbable.Persistence.Update);

            public Type ReplicationSystem { get; } = typeof(global::Improbable.Persistence.ReplicationSystem);
            public Type Serializer { get; } = typeof(global::Improbable.Persistence.ComponentSerializer);
            public Type DiffDeserializer { get; } = typeof(global::Improbable.Persistence.DiffComponentDeserializer);

            public Type DiffStorage { get; } = typeof(global::Improbable.Persistence.DiffComponentStorage);
            public Type EcsViewManager { get; } = typeof(global::Improbable.Persistence.EcsViewManager);
            public Type DynamicInvokable { get; } = typeof(global::Improbable.Persistence.PersistenceDynamic);

            public ICommandMetaclass[] Commands { get; } = new ICommandMetaclass[]
            {
            };
        }
    }
}
