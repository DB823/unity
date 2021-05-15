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
    public class PlayerHeartbeatServerReaderSubscriptionManager : ReaderSubscriptionManager<PlayerHeartbeatServer.Component, PlayerHeartbeatServerReader>
    {
        public PlayerHeartbeatServerReaderSubscriptionManager(World world) : base(world)
        {
        }

        protected override PlayerHeartbeatServerReader CreateReader(Entity entity, EntityId entityId)
        {
            return new PlayerHeartbeatServerReader(World, entity, entityId);
        }
    }

    [AutoRegisterSubscriptionManager]
    public class PlayerHeartbeatServerWriterSubscriptionManager : WriterSubscriptionManager<PlayerHeartbeatServer.Component, PlayerHeartbeatServerWriter>
    {
        public PlayerHeartbeatServerWriterSubscriptionManager(World world) : base(world)
        {
        }

        protected override PlayerHeartbeatServerWriter CreateWriter(Entity entity, EntityId entityId)
        {
            return new PlayerHeartbeatServerWriter(World, entity, entityId);
        }
    }

    public class PlayerHeartbeatServerReader : Reader<PlayerHeartbeatServer.Component, PlayerHeartbeatServer.Update>
    {
        internal PlayerHeartbeatServerReader(World world, Entity entity, EntityId entityId) : base(world, entity, entityId)
        {
        }
    }

    public class PlayerHeartbeatServerWriter : PlayerHeartbeatServerReader
    {
        internal PlayerHeartbeatServerWriter(World world, Entity entity, EntityId entityId)
            : base(world, entity, entityId)
        {
        }

        public void SendUpdate(PlayerHeartbeatServer.Update update)
        {
            var component = EntityManager.GetComponentData<PlayerHeartbeatServer.Component>(Entity);

            EntityManager.SetComponentData(Entity, component);
        }
    }
}
