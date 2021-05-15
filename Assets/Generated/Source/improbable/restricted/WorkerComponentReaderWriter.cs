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
    public class WorkerReaderSubscriptionManager : ReaderSubscriptionManager<Worker.Component, WorkerReader>
    {
        public WorkerReaderSubscriptionManager(World world) : base(world)
        {
        }

        protected override WorkerReader CreateReader(Entity entity, EntityId entityId)
        {
            return new WorkerReader(World, entity, entityId);
        }
    }

    [AutoRegisterSubscriptionManager]
    public class WorkerWriterSubscriptionManager : WriterSubscriptionManager<Worker.Component, WorkerWriter>
    {
        public WorkerWriterSubscriptionManager(World world) : base(world)
        {
        }

        protected override WorkerWriter CreateWriter(Entity entity, EntityId entityId)
        {
            return new WorkerWriter(World, entity, entityId);
        }
    }

    public class WorkerReader : Reader<Worker.Component, Worker.Update>
    {
        private Dictionary<Action<string>, ulong> workerIdUpdateCallbackToCallbackKey;

        private Dictionary<Action<string>, ulong> workerTypeUpdateCallbackToCallbackKey;

        private Dictionary<Action<global::Improbable.Restricted.Connection>, ulong> connectionUpdateCallbackToCallbackKey;

        internal WorkerReader(World world, Entity entity, EntityId entityId) : base(world, entity, entityId)
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

                var key = CallbackSystem.RegisterComponentUpdateCallback<Worker.Update>(EntityId, update =>
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

        public event Action<string> OnWorkerTypeUpdate
        {
            add
            {
                if (!IsValid)
                {
                    throw new InvalidOperationException("Cannot add field update callback when Reader is not valid.");
                }

                if (workerTypeUpdateCallbackToCallbackKey == null)
                {
                    workerTypeUpdateCallbackToCallbackKey = new Dictionary<Action<string>, ulong>();
                }

                var key = CallbackSystem.RegisterComponentUpdateCallback<Worker.Update>(EntityId, update =>
                {
                    if (update.WorkerType.HasValue)
                    {
                        value(update.WorkerType.Value);
                    }
                });
                workerTypeUpdateCallbackToCallbackKey.Add(value, key);
            }
            remove
            {
                if (!workerTypeUpdateCallbackToCallbackKey.TryGetValue(value, out var key))
                {
                    return;
                }

                CallbackSystem.UnregisterCallback(key);
                workerTypeUpdateCallbackToCallbackKey.Remove(value);
            }
        }

        public event Action<global::Improbable.Restricted.Connection> OnConnectionUpdate
        {
            add
            {
                if (!IsValid)
                {
                    throw new InvalidOperationException("Cannot add field update callback when Reader is not valid.");
                }

                if (connectionUpdateCallbackToCallbackKey == null)
                {
                    connectionUpdateCallbackToCallbackKey = new Dictionary<Action<global::Improbable.Restricted.Connection>, ulong>();
                }

                var key = CallbackSystem.RegisterComponentUpdateCallback<Worker.Update>(EntityId, update =>
                {
                    if (update.Connection.HasValue)
                    {
                        value(update.Connection.Value);
                    }
                });
                connectionUpdateCallbackToCallbackKey.Add(value, key);
            }
            remove
            {
                if (!connectionUpdateCallbackToCallbackKey.TryGetValue(value, out var key))
                {
                    return;
                }

                CallbackSystem.UnregisterCallback(key);
                connectionUpdateCallbackToCallbackKey.Remove(value);
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

            if (workerTypeUpdateCallbackToCallbackKey != null)
            {
                foreach (var callbackToKey in workerTypeUpdateCallbackToCallbackKey)
                {
                    CallbackSystem.UnregisterCallback(callbackToKey.Value);
                }

                workerTypeUpdateCallbackToCallbackKey.Clear();
            }

            if (connectionUpdateCallbackToCallbackKey != null)
            {
                foreach (var callbackToKey in connectionUpdateCallbackToCallbackKey)
                {
                    CallbackSystem.UnregisterCallback(callbackToKey.Value);
                }

                connectionUpdateCallbackToCallbackKey.Clear();
            }
        }
    }

    public class WorkerWriter : WorkerReader
    {
        internal WorkerWriter(World world, Entity entity, EntityId entityId)
            : base(world, entity, entityId)
        {
        }

        public void SendUpdate(Worker.Update update)
        {
            var component = EntityManager.GetComponentData<Worker.Component>(Entity);

            if (update.WorkerId.HasValue)
            {
                component.WorkerId = update.WorkerId.Value;
            }

            if (update.WorkerType.HasValue)
            {
                component.WorkerType = update.WorkerType.Value;
            }

            if (update.Connection.HasValue)
            {
                component.Connection = update.Connection.Value;
            }

            EntityManager.SetComponentData(Entity, component);
        }
    }
}
