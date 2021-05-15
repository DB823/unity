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
    public class MetadataReaderSubscriptionManager : ReaderSubscriptionManager<Metadata.Component, MetadataReader>
    {
        public MetadataReaderSubscriptionManager(World world) : base(world)
        {
        }

        protected override MetadataReader CreateReader(Entity entity, EntityId entityId)
        {
            return new MetadataReader(World, entity, entityId);
        }
    }

    [AutoRegisterSubscriptionManager]
    public class MetadataWriterSubscriptionManager : WriterSubscriptionManager<Metadata.Component, MetadataWriter>
    {
        public MetadataWriterSubscriptionManager(World world) : base(world)
        {
        }

        protected override MetadataWriter CreateWriter(Entity entity, EntityId entityId)
        {
            return new MetadataWriter(World, entity, entityId);
        }
    }

    public class MetadataReader : Reader<Metadata.Component, Metadata.Update>
    {
        private Dictionary<Action<string>, ulong> entityTypeUpdateCallbackToCallbackKey;

        internal MetadataReader(World world, Entity entity, EntityId entityId) : base(world, entity, entityId)
        {
        }

        public event Action<string> OnEntityTypeUpdate
        {
            add
            {
                if (!IsValid)
                {
                    throw new InvalidOperationException("Cannot add field update callback when Reader is not valid.");
                }

                if (entityTypeUpdateCallbackToCallbackKey == null)
                {
                    entityTypeUpdateCallbackToCallbackKey = new Dictionary<Action<string>, ulong>();
                }

                var key = CallbackSystem.RegisterComponentUpdateCallback<Metadata.Update>(EntityId, update =>
                {
                    if (update.EntityType.HasValue)
                    {
                        value(update.EntityType.Value);
                    }
                });
                entityTypeUpdateCallbackToCallbackKey.Add(value, key);
            }
            remove
            {
                if (!entityTypeUpdateCallbackToCallbackKey.TryGetValue(value, out var key))
                {
                    return;
                }

                CallbackSystem.UnregisterCallback(key);
                entityTypeUpdateCallbackToCallbackKey.Remove(value);
            }
        }

        protected override void RemoveFieldCallbacks()
        {
            if (entityTypeUpdateCallbackToCallbackKey != null)
            {
                foreach (var callbackToKey in entityTypeUpdateCallbackToCallbackKey)
                {
                    CallbackSystem.UnregisterCallback(callbackToKey.Value);
                }

                entityTypeUpdateCallbackToCallbackKey.Clear();
            }
        }
    }

    public class MetadataWriter : MetadataReader
    {
        internal MetadataWriter(World world, Entity entity, EntityId entityId)
            : base(world, entity, entityId)
        {
        }

        public void SendUpdate(Metadata.Update update)
        {
            var component = EntityManager.GetComponentData<Metadata.Component>(Entity);

            if (update.EntityType.HasValue)
            {
                component.EntityType = update.EntityType.Value;
            }

            EntityManager.SetComponentData(Entity, component);
        }
    }
}
