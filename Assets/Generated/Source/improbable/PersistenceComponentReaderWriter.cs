// =====================================================
// DO NOT EDIT - this file is automatically regenerated.
// =====================================================

using System;
using System.Collections.Generic;
using Improbable.Gdk.Core;
using Improbable.Gdk.Subscriptions;
using Unity.Entities;
using Entity = Unity.Entities.Entity;

namespace Improbable
{
    [AutoRegisterSubscriptionManager]
    public class PersistenceReaderSubscriptionManager : ReaderSubscriptionManager<Persistence.Component, PersistenceReader>
    {
        public PersistenceReaderSubscriptionManager(World world) : base(world)
        {
        }

        protected override PersistenceReader CreateReader(Entity entity, EntityId entityId)
        {
            return new PersistenceReader(World, entity, entityId);
        }
    }

    [AutoRegisterSubscriptionManager]
    public class PersistenceWriterSubscriptionManager : WriterSubscriptionManager<Persistence.Component, PersistenceWriter>
    {
        public PersistenceWriterSubscriptionManager(World world) : base(world)
        {
        }

        protected override PersistenceWriter CreateWriter(Entity entity, EntityId entityId)
        {
            return new PersistenceWriter(World, entity, entityId);
        }
    }

    public class PersistenceReader : Reader<Persistence.Component, Persistence.Update>
    {
        internal PersistenceReader(World world, Entity entity, EntityId entityId) : base(world, entity, entityId)
        {
        }
    }

    public class PersistenceWriter : PersistenceReader
    {
        internal PersistenceWriter(World world, Entity entity, EntityId entityId)
            : base(world, entity, entityId)
        {
        }

        public void SendUpdate(Persistence.Update update)
        {
            var component = EntityManager.GetComponentData<Persistence.Component>(Entity);

            EntityManager.SetComponentData(Entity, component);
        }
    }
}
