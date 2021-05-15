// =====================================================
// DO NOT EDIT - this file is automatically regenerated.
// =====================================================

using System;
using Improbable.Gdk.Core;
using Improbable.Gdk.Core.Commands;

namespace Improbable
{
    public partial class Interest
    {
        public class ComponentMetaclass : IComponentMetaclass
        {
            public uint ComponentId => 58;
            public string Name => "Interest";

            public Type Data { get; } = typeof(global::Improbable.Interest.Component);
            public Type Authority { get; } = typeof(global::Improbable.Interest.HasAuthority);
            public Type Snapshot { get; } = typeof(global::Improbable.Interest.Snapshot);
            public Type Update { get; } = typeof(global::Improbable.Interest.Update);

            public Type ReplicationSystem { get; } = typeof(global::Improbable.Interest.ReplicationSystem);
            public Type Serializer { get; } = typeof(global::Improbable.Interest.ComponentSerializer);
            public Type DiffDeserializer { get; } = typeof(global::Improbable.Interest.DiffComponentDeserializer);

            public Type DiffStorage { get; } = typeof(global::Improbable.Interest.DiffComponentStorage);
            public Type EcsViewManager { get; } = typeof(global::Improbable.Interest.EcsViewManager);
            public Type DynamicInvokable { get; } = typeof(global::Improbable.Interest.InterestDynamic);

            public ICommandMetaclass[] Commands { get; } = new ICommandMetaclass[]
            {
            };
        }
    }
}
