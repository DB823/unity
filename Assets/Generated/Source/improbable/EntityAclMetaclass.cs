// =====================================================
// DO NOT EDIT - this file is automatically regenerated.
// =====================================================

using System;
using Improbable.Gdk.Core;
using Improbable.Gdk.Core.Commands;

namespace Improbable
{
    public partial class EntityAcl
    {
        public class ComponentMetaclass : IComponentMetaclass
        {
            public uint ComponentId => 50;
            public string Name => "EntityAcl";

            public Type Data { get; } = typeof(global::Improbable.EntityAcl.Component);
            public Type Authority { get; } = typeof(global::Improbable.EntityAcl.HasAuthority);
            public Type Snapshot { get; } = typeof(global::Improbable.EntityAcl.Snapshot);
            public Type Update { get; } = typeof(global::Improbable.EntityAcl.Update);

            public Type ReplicationSystem { get; } = typeof(global::Improbable.EntityAcl.ReplicationSystem);
            public Type Serializer { get; } = typeof(global::Improbable.EntityAcl.ComponentSerializer);
            public Type DiffDeserializer { get; } = typeof(global::Improbable.EntityAcl.DiffComponentDeserializer);

            public Type DiffStorage { get; } = typeof(global::Improbable.EntityAcl.DiffComponentStorage);
            public Type EcsViewManager { get; } = typeof(global::Improbable.EntityAcl.EcsViewManager);
            public Type DynamicInvokable { get; } = typeof(global::Improbable.EntityAcl.EntityAclDynamic);

            public ICommandMetaclass[] Commands { get; } = new ICommandMetaclass[]
            {
            };
        }
    }
}
