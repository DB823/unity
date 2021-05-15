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
    public class EntityAclReaderSubscriptionManager : ReaderSubscriptionManager<EntityAcl.Component, EntityAclReader>
    {
        public EntityAclReaderSubscriptionManager(World world) : base(world)
        {
        }

        protected override EntityAclReader CreateReader(Entity entity, EntityId entityId)
        {
            return new EntityAclReader(World, entity, entityId);
        }
    }

    [AutoRegisterSubscriptionManager]
    public class EntityAclWriterSubscriptionManager : WriterSubscriptionManager<EntityAcl.Component, EntityAclWriter>
    {
        public EntityAclWriterSubscriptionManager(World world) : base(world)
        {
        }

        protected override EntityAclWriter CreateWriter(Entity entity, EntityId entityId)
        {
            return new EntityAclWriter(World, entity, entityId);
        }
    }

    public class EntityAclReader : Reader<EntityAcl.Component, EntityAcl.Update>
    {
        private Dictionary<Action<global::Improbable.WorkerRequirementSet>, ulong> readAclUpdateCallbackToCallbackKey;

        private Dictionary<Action<global::System.Collections.Generic.Dictionary<uint, global::Improbable.WorkerRequirementSet>>, ulong> componentWriteAclUpdateCallbackToCallbackKey;

        internal EntityAclReader(World world, Entity entity, EntityId entityId) : base(world, entity, entityId)
        {
        }

        public event Action<global::Improbable.WorkerRequirementSet> OnReadAclUpdate
        {
            add
            {
                if (!IsValid)
                {
                    throw new InvalidOperationException("Cannot add field update callback when Reader is not valid.");
                }

                if (readAclUpdateCallbackToCallbackKey == null)
                {
                    readAclUpdateCallbackToCallbackKey = new Dictionary<Action<global::Improbable.WorkerRequirementSet>, ulong>();
                }

                var key = CallbackSystem.RegisterComponentUpdateCallback<EntityAcl.Update>(EntityId, update =>
                {
                    if (update.ReadAcl.HasValue)
                    {
                        value(update.ReadAcl.Value);
                    }
                });
                readAclUpdateCallbackToCallbackKey.Add(value, key);
            }
            remove
            {
                if (!readAclUpdateCallbackToCallbackKey.TryGetValue(value, out var key))
                {
                    return;
                }

                CallbackSystem.UnregisterCallback(key);
                readAclUpdateCallbackToCallbackKey.Remove(value);
            }
        }

        public event Action<global::System.Collections.Generic.Dictionary<uint, global::Improbable.WorkerRequirementSet>> OnComponentWriteAclUpdate
        {
            add
            {
                if (!IsValid)
                {
                    throw new InvalidOperationException("Cannot add field update callback when Reader is not valid.");
                }

                if (componentWriteAclUpdateCallbackToCallbackKey == null)
                {
                    componentWriteAclUpdateCallbackToCallbackKey = new Dictionary<Action<global::System.Collections.Generic.Dictionary<uint, global::Improbable.WorkerRequirementSet>>, ulong>();
                }

                var key = CallbackSystem.RegisterComponentUpdateCallback<EntityAcl.Update>(EntityId, update =>
                {
                    if (update.ComponentWriteAcl.HasValue)
                    {
                        value(update.ComponentWriteAcl.Value);
                    }
                });
                componentWriteAclUpdateCallbackToCallbackKey.Add(value, key);
            }
            remove
            {
                if (!componentWriteAclUpdateCallbackToCallbackKey.TryGetValue(value, out var key))
                {
                    return;
                }

                CallbackSystem.UnregisterCallback(key);
                componentWriteAclUpdateCallbackToCallbackKey.Remove(value);
            }
        }

        protected override void RemoveFieldCallbacks()
        {
            if (readAclUpdateCallbackToCallbackKey != null)
            {
                foreach (var callbackToKey in readAclUpdateCallbackToCallbackKey)
                {
                    CallbackSystem.UnregisterCallback(callbackToKey.Value);
                }

                readAclUpdateCallbackToCallbackKey.Clear();
            }

            if (componentWriteAclUpdateCallbackToCallbackKey != null)
            {
                foreach (var callbackToKey in componentWriteAclUpdateCallbackToCallbackKey)
                {
                    CallbackSystem.UnregisterCallback(callbackToKey.Value);
                }

                componentWriteAclUpdateCallbackToCallbackKey.Clear();
            }
        }
    }

    public class EntityAclWriter : EntityAclReader
    {
        internal EntityAclWriter(World world, Entity entity, EntityId entityId)
            : base(world, entity, entityId)
        {
        }

        public void SendUpdate(EntityAcl.Update update)
        {
            var component = EntityManager.GetComponentData<EntityAcl.Component>(Entity);

            if (update.ReadAcl.HasValue)
            {
                component.ReadAcl = update.ReadAcl.Value;
            }

            if (update.ComponentWriteAcl.HasValue)
            {
                component.ComponentWriteAcl = update.ComponentWriteAcl.Value;
            }

            EntityManager.SetComponentData(Entity, component);
        }
    }
}
