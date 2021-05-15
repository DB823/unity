// =====================================================
// DO NOT EDIT - this file is automatically regenerated.
// =====================================================

using System;
using Improbable.Gdk.Core;
using Improbable.Gdk.Core.Commands;

namespace Improbable.Restricted
{
    public partial class Worker
    {
        public class ComponentMetaclass : IComponentMetaclass
        {
            public uint ComponentId => 60;
            public string Name => "Worker";

            public Type Data { get; } = typeof(global::Improbable.Restricted.Worker.Component);
            public Type Authority { get; } = typeof(global::Improbable.Restricted.Worker.HasAuthority);
            public Type Snapshot { get; } = typeof(global::Improbable.Restricted.Worker.Snapshot);
            public Type Update { get; } = typeof(global::Improbable.Restricted.Worker.Update);

            public Type ReplicationSystem { get; } = typeof(global::Improbable.Restricted.Worker.ReplicationSystem);
            public Type Serializer { get; } = typeof(global::Improbable.Restricted.Worker.ComponentSerializer);
            public Type DiffDeserializer { get; } = typeof(global::Improbable.Restricted.Worker.DiffComponentDeserializer);

            public Type DiffStorage { get; } = typeof(global::Improbable.Restricted.Worker.DiffComponentStorage);
            public Type EcsViewManager { get; } = typeof(global::Improbable.Restricted.Worker.EcsViewManager);
            public Type DynamicInvokable { get; } = typeof(global::Improbable.Restricted.Worker.WorkerDynamic);

            public ICommandMetaclass[] Commands { get; } = new ICommandMetaclass[]
            {
                new DisconnectMetaclass()
            };
        }

        public class DisconnectMetaclass : ICommandMetaclass
        {
            public uint ComponentId => global::Improbable.Restricted.Worker.ComponentId;
            public uint CommandIndex => 1;
            public string Name => "Disconnect";

            public Type DiffDeserializer { get; } = typeof(global::Improbable.Restricted.Worker.DisconnectDiffCommandDeserializer);
            public Type Serializer { get; } = typeof(global::Improbable.Restricted.Worker.DisconnectCommandSerializer);

            public Type MetaDataStorage { get; } = typeof(global::Improbable.Restricted.Worker.DisconnectCommandMetaDataStorage);
            public Type SendStorage { get; } = typeof(global::Improbable.Restricted.Worker.DisconnectCommandsToSendStorage);
            public Type DiffStorage { get; } = typeof(global::Improbable.Restricted.Worker.DiffDisconnectCommandStorage);

            public Type Response { get; } = typeof(global::Improbable.Restricted.Worker.Disconnect.Response);
            public Type ReceivedResponse { get; } = typeof(global::Improbable.Restricted.Worker.Disconnect.ReceivedResponse);
            public Type Request { get; } = typeof(global::Improbable.Restricted.Worker.Disconnect.Request);
            public Type ReceivedRequest { get; } = typeof(global::Improbable.Restricted.Worker.Disconnect.ReceivedRequest);
        }
    }
}
