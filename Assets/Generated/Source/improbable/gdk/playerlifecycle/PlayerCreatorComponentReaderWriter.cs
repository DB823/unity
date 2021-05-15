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
    public class PlayerCreatorReaderSubscriptionManager : ReaderSubscriptionManager<PlayerCreator.Component, PlayerCreatorReader>
    {
        public PlayerCreatorReaderSubscriptionManager(World world) : base(world)
        {
        }

        protected override PlayerCreatorReader CreateReader(Entity entity, EntityId entityId)
        {
            return new PlayerCreatorReader(World, entity, entityId);
        }
    }

    [AutoRegisterSubscriptionManager]
    public class PlayerCreatorWriterSubscriptionManager : WriterSubscriptionManager<PlayerCreator.Component, PlayerCreatorWriter>
    {
        public PlayerCreatorWriterSubscriptionManager(World world) : base(world)
        {
        }

        protected override PlayerCreatorWriter CreateWriter(Entity entity, EntityId entityId)
        {
            return new PlayerCreatorWriter(World, entity, entityId);
        }
    }

    public class PlayerCreatorReader : Reader<PlayerCreator.Component, PlayerCreator.Update>
    {
        internal PlayerCreatorReader(World world, Entity entity, EntityId entityId) : base(world, entity, entityId)
        {
        }
    }

    public class PlayerCreatorWriter : PlayerCreatorReader
    {
        internal PlayerCreatorWriter(World world, Entity entity, EntityId entityId)
            : base(world, entity, entityId)
        {
        }

        public void SendUpdate(PlayerCreator.Update update)
        {
            var component = EntityManager.GetComponentData<PlayerCreator.Component>(Entity);

            EntityManager.SetComponentData(Entity, component);
        }
    }
}
