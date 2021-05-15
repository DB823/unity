// =====================================================
// DO NOT EDIT - this file is automatically regenerated.
// =====================================================

using System;
using Improbable.Gdk.Core;
using Improbable.Gdk.Core.Commands;

namespace Improbable.Gdk.TransformSynchronization
{
    public partial class TransformInternal
    {
        public class ComponentMetaclass : IComponentMetaclass
        {
            public uint ComponentId => 11000;
            public string Name => "TransformInternal";

            public Type Data { get; } = typeof(global::Improbable.Gdk.TransformSynchronization.TransformInternal.Component);
            public Type Authority { get; } = typeof(global::Improbable.Gdk.TransformSynchronization.TransformInternal.HasAuthority);
            public Type Snapshot { get; } = typeof(global::Improbable.Gdk.TransformSynchronization.TransformInternal.Snapshot);
            public Type Update { get; } = typeof(global::Improbable.Gdk.TransformSynchronization.TransformInternal.Update);

            public Type ReplicationSystem { get; } = typeof(global::Improbable.Gdk.TransformSynchronization.TransformInternal.ReplicationSystem);
            public Type Serializer { get; } = typeof(global::Improbable.Gdk.TransformSynchronization.TransformInternal.ComponentSerializer);
            public Type DiffDeserializer { get; } = typeof(global::Improbable.Gdk.TransformSynchronization.TransformInternal.DiffComponentDeserializer);

            public Type DiffStorage { get; } = typeof(global::Improbable.Gdk.TransformSynchronization.TransformInternal.DiffComponentStorage);
            public Type EcsViewManager { get; } = typeof(global::Improbable.Gdk.TransformSynchronization.TransformInternal.EcsViewManager);
            public Type DynamicInvokable { get; } = typeof(global::Improbable.Gdk.TransformSynchronization.TransformInternal.TransformInternalDynamic);

            public ICommandMetaclass[] Commands { get; } = new ICommandMetaclass[]
            {
            };
        }
    }
}
