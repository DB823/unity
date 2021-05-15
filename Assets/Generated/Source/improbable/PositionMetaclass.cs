// =====================================================
// DO NOT EDIT - this file is automatically regenerated.
// =====================================================

using System;
using Improbable.Gdk.Core;
using Improbable.Gdk.Core.Commands;

namespace Improbable
{
    public partial class Position
    {
        public class ComponentMetaclass : IComponentMetaclass
        {
            public uint ComponentId => 54;
            public string Name => "Position";

            public Type Data { get; } = typeof(global::Improbable.Position.Component);
            public Type Authority { get; } = typeof(global::Improbable.Position.HasAuthority);
            public Type Snapshot { get; } = typeof(global::Improbable.Position.Snapshot);
            public Type Update { get; } = typeof(global::Improbable.Position.Update);

            public Type ReplicationSystem { get; } = typeof(global::Improbable.Position.ReplicationSystem);
            public Type Serializer { get; } = typeof(global::Improbable.Position.ComponentSerializer);
            public Type DiffDeserializer { get; } = typeof(global::Improbable.Position.DiffComponentDeserializer);

            public Type DiffStorage { get; } = typeof(global::Improbable.Position.DiffComponentStorage);
            public Type EcsViewManager { get; } = typeof(global::Improbable.Position.EcsViewManager);
            public Type DynamicInvokable { get; } = typeof(global::Improbable.Position.PositionDynamic);

            public ICommandMetaclass[] Commands { get; } = new ICommandMetaclass[]
            {
            };
        }
    }
}
