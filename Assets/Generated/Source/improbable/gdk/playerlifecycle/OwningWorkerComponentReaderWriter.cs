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
    public class OwningWorkerReaderSubscriptionManager : ReaderSubscriptionManager<OwningWorker.Component, OwningWorkerReader>
    {
        public OwningWorkerReaderSubscriptionManager(World world) : base(world)
        {
        }

        protected override OwningWorkerReader CreateReader(Entity entity, EntityId entityId)
        {
            return new OwningWorkerReader(World, entity, entityId);
        }
    }

    [AutoRegisterSubscriptionManager]
    public class OwningWorkerWriterSubscriptionManager : WriterSubscriptionManager<OwningWorker.Component, OwningWorkerWriter>
    {
        public OwningWorkerWriterSubscriptionManager(World world) : base(world)
        {
        }

        protected override OwningWorkerWriter CreateWriter(Entity entity, EntityId entityId)
        {
            return new OwningWorkerWriter(World, entity, entityId);
        }
    }

    public class OwningWorkerReader : Reader<OwningWorker.Component, OwningWorker.Update>
    {
        private Dictionary<Action<string>, ulong> workerIdUpdateCallbackToCallbackKey;

        internal OwningWorkerReader(World world, Entity entity, EntityId entityId) : base(world, entity, entityId)
        {
        }

        public event Action<string> OnWorkerIdUpdate
        {
            add
            {
                if (!IsValid)
                {
                    throw new InvalidOperationException("Cannot add field update callback when Reader is not valid.");
                }

                if (workerIdUpdateCallbackToCallbackKey == null)
                {
                    workerIdUpdateCallbackToCallbackKey = new Dictionary<Action<string>, ulong>();
                }

                var key = CallbackSystem.RegisterComponentUpdateCallback<OwningWorker.Update>(EntityId, update =>
                {
                    if (update.WorkerId.HasValue)
                    {
                        value(update.WorkerId.Value);
                    }
                });
                workerIdUpdateCallbackToCallbackKey.Add(value, key);
            }
            remove
            {
                if (!workerIdUpdateCallbackToCallbackKey.TryGetValue(value, out var key))
                {
                    return;
                }

                CallbackSystem.UnregisterCallback(key);
                workerIdUpdateCallbackToCallbackKey.Remove(value);
            }
        }

        protected override void RemoveFieldCallbacks()
        {
            if (workerIdUpdateCallbackToCallbackKey != null)
            {
                foreach (var callbackToKey in workerIdUpdateCallbackToCallbackKey)
                {
                    CallbackSystem.UnregisterCallback(callbackToKey.Value);
                }

                workerIdUpdateCallbackToCallbackKey.Clear();
            }
        }
    }

    public class OwningWorkerWriter : OwningWorkerReader
    {
        internal OwningWorkerWriter(World world, Entity entity, EntityId entityId)
            : base(world, entity, entityId)
        {
        }

        public void SendUpdate(OwningWorker.Update update)
        {
            var component = EntityManager.GetComponentData<OwningWorker.Component>(Entity);

            if (update.WorkerId.HasValue)
            {
                component.WorkerId = update.WorkerId.Value;
            }

            EntityManager.SetComponentData(Entity, component);
        }
    }
}
