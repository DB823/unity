// =====================================================
// DO NOT EDIT - this file is automatically regenerated.
// =====================================================

using System;
using System.Collections.Generic;
using Improbable.Gdk.Core;
using Improbable.Gdk.Subscriptions;
using Unity.Entities;
using Entity = Unity.Entities.Entity;

namespace Improbable.Restricted
{
    [AutoRegisterSubscriptionManager]
    public class SystemReaderSubscriptionManager : ReaderSubscriptionManager<System.Component, SystemReader>
    {
        public SystemReaderSubscriptionManager(World world) : base(world)
        {
        }

        protected override SystemReader CreateReader(Entity entity, EntityId entityId)
        {
            return new SystemReader(World, entity, entityId);
        }
    }

    [AutoRegisterSubscriptionManager]
    public class SystemWriterSubscriptionManager : WriterSubscriptionManager<System.Component, SystemWriter>
    {
        public SystemWriterSubscriptionManager(World world) : base(world)
        {
        }

        protected override SystemWriter CreateWriter(Entity entity, EntityId entityId)
        {
            return new SystemWriter(World, entity, entityId);
        }
    }

    public class SystemReader : Reader<System.Component, System.Update>
    {
        internal SystemReader(World world, Entity entity, EntityId entityId) : base(world, entity, entityId)
        {
        }
    }

    public class SystemWriter : SystemReader
    {
        internal SystemWriter(World world, Entity entity, EntityId entityId)
            : base(world, entity, entityId)
        {
        }

        public void SendUpdate(System.Update update)
        {
            var component = EntityManager.GetComponentData<System.Component>(Entity);

            EntityManager.SetComponentData(Entity, component);
        }
    }
}
