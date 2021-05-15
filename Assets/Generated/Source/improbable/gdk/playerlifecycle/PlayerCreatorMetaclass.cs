// =====================================================
// DO NOT EDIT - this file is automatically regenerated.
// =====================================================

using System;
using Improbable.Gdk.Core;
using Improbable.Gdk.Core.Commands;

namespace Improbable.Gdk.PlayerLifecycle
{
    public partial class PlayerCreator
    {
        public class ComponentMetaclass : IComponentMetaclass
        {
            public uint ComponentId => 13000;
            public string Name => "PlayerCreator";

            public Type Data { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.PlayerCreator.Component);
            public Type Authority { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.PlayerCreator.HasAuthority);
            public Type Snapshot { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.PlayerCreator.Snapshot);
            public Type Update { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.PlayerCreator.Update);

            public Type ReplicationSystem { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.PlayerCreator.ReplicationSystem);
            public Type Serializer { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.PlayerCreator.ComponentSerializer);
            public Type DiffDeserializer { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.PlayerCreator.DiffComponentDeserializer);

            public Type DiffStorage { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.PlayerCreator.DiffComponentStorage);
            public Type EcsViewManager { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.PlayerCreator.EcsViewManager);
            public Type DynamicInvokable { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.PlayerCreator.PlayerCreatorDynamic);

            public ICommandMetaclass[] Commands { get; } = new ICommandMetaclass[]
            {
                new CreatePlayerMetaclass()
            };
        }

        public class CreatePlayerMetaclass : ICommandMetaclass
        {
            public uint ComponentId => global::Improbable.Gdk.PlayerLifecycle.PlayerCreator.ComponentId;
            public uint CommandIndex => 1;
            public string Name => "CreatePlayer";

            public Type DiffDeserializer { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.PlayerCreator.CreatePlayerDiffCommandDeserializer);
            public Type Serializer { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.PlayerCreator.CreatePlayerCommandSerializer);

            public Type MetaDataStorage { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.PlayerCreator.CreatePlayerCommandMetaDataStorage);
            public Type SendStorage { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.PlayerCreator.CreatePlayerCommandsToSendStorage);
            public Type DiffStorage { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.PlayerCreator.DiffCreatePlayerCommandStorage);

            public Type Response { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.PlayerCreator.CreatePlayer.Response);
            public Type ReceivedResponse { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.PlayerCreator.CreatePlayer.ReceivedResponse);
            public Type Request { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.PlayerCreator.CreatePlayer.Request);
            public Type ReceivedRequest { get; } = typeof(global::Improbable.Gdk.PlayerLifecycle.PlayerCreator.CreatePlayer.ReceivedRequest);
        }
    }
}
