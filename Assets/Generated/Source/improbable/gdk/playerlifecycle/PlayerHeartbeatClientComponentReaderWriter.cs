// =====================================================
// DO NOT EDIT - this file is automatically regenerated.
// =====================================================

using System;
using System.Collections.Generic;
using Improbable.Gdk.Core;
using Improbable.Gdk.Subscriptions;
using Unity.Entities;
using Entity = Unity.Entities.Entity;

namespace Improbable.Gdk.PlayerLifecycle
{
    [AutoRegisterSubscriptionManager]
    public class PlayerHeartbeatClientReaderSubscriptionManager : ReaderSubscriptionManager<PlayerHeartbeatClient.Component, PlayerHeartbeatClientReader>
    {
        public PlayerHeartbeatClientReaderSubscriptionManager(World world) : base(world)
        {
        }

        protected override PlayerHeartbeatClientReader CreateReader(Entity entity, EntityId entityId)
        {
            return new PlayerHeartbeatClientReader(World, entity, entityId);
        }
    }

    [AutoRegisterSubscriptionManager]
    public class PlayerHeartbeatClientWriterSubscriptionManager : WriterSubscriptionManager<PlayerHeartbeatClient.Component, PlayerHeartbeatClientWriter>
    {
        public PlayerHeartbeatClientWriterSubscriptionManager(World world) : base(world)
        {
        }

        protected override PlayerHeartbeatClientWriter CreateWriter(Entity entity, EntityId entityId)
        {
            return new PlayerHeartbeatClientWriter(World, entity, entityId);
        }
    }

    public class PlayerHeartbeatClientReader : Reader<PlayerHeartbeatClient.Component, PlayerHeartbeatClient.Update>
    {
        internal PlayerHeartbeatClientReader(World world, Entity entity, EntityId entityId) : base(world, entity, entityId)
        {
        }
    }

    public class PlayerHeartbeatClientWriter : PlayerHeartbeatClientReader
    {
        internal PlayerHeartbeatClientWriter(World world, Entity entity, EntityId entityId)
            : base(world, entity, entityId)
        {
        }

        public void SendUpdate(PlayerHeartbeatClient.Update update)
        {
            var component = EntityManager.GetComponentData<PlayerHeartbeatClient.Component>(Entity);

            EntityManager.SetComponentData(Entity, component);
        }
    }
}
