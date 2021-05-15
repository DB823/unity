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
    public class InterestReaderSubscriptionManager : ReaderSubscriptionManager<Interest.Component, InterestReader>
    {
        public InterestReaderSubscriptionManager(World world) : base(world)
        {
        }

        protected override InterestReader CreateReader(Entity entity, EntityId entityId)
        {
            return new InterestReader(World, entity, entityId);
        }
    }

    [AutoRegisterSubscriptionManager]
    public class InterestWriterSubscriptionManager : WriterSubscriptionManager<Interest.Component, InterestWriter>
    {
        public InterestWriterSubscriptionManager(World world) : base(world)
        {
        }

        protected override InterestWriter CreateWriter(Entity entity, EntityId entityId)
        {
            return new InterestWriter(World, entity, entityId);
        }
    }

    public class InterestReader : Reader<Interest.Component, Interest.Update>
    {
        private Dictionary<Action<global::System.Collections.Generic.Dictionary<uint, global::Improbable.ComponentInterest>>, ulong> componentInterestUpdateCallbackToCallbackKey;

        internal InterestReader(World world, Entity entity, EntityId entityId) : base(world, entity, entityId)
        {
        }

        public event Action<global::System.Collections.Generic.Dictionary<uint, global::Improbable.ComponentInterest>> OnComponentInterestUpdate
        {
            add
            {
                if (!IsValid)
                {
                    throw new InvalidOperationException("Cannot add field update callback when Reader is not valid.");
                }

                if (componentInterestUpdateCallbackToCallbackKey == null)
                {
                    componentInterestUpdateCallbackToCallbackKey = new Dictionary<Action<global::System.Collections.Generic.Dictionary<uint, global::Improbable.ComponentInterest>>, ulong>();
                }

                var key = CallbackSystem.RegisterComponentUpdateCallback<Interest.Update>(EntityId, update =>
                {
                    if (update.ComponentInterest.HasValue)
                    {
                        value(update.ComponentInterest.Value);
                    }
                });
                componentInterestUpdateCallbackToCallbackKey.Add(value, key);
            }
            remove
            {
                if (!componentInterestUpdateCallbackToCallbackKey.TryGetValue(value, out var key))
                {
                    return;
                }

                CallbackSystem.UnregisterCallback(key);
                componentInterestUpdateCallbackToCallbackKey.Remove(value);
            }
        }

        protected override void RemoveFieldCallbacks()
        {
            if (componentInterestUpdateCallbackToCallbackKey != null)
            {
                foreach (var callbackToKey in componentInterestUpdateCallbackToCallbackKey)
                {
                    CallbackSystem.UnregisterCallback(callbackToKey.Value);
                }

                componentInterestUpdateCallbackToCallbackKey.Clear();
            }
        }
    }

    public class InterestWriter : InterestReader
    {
        internal InterestWriter(World world, Entity entity, EntityId entityId)
            : base(world, entity, entityId)
        {
        }

        public void SendUpdate(Interest.Update update)
        {
            var component = EntityManager.GetComponentData<Interest.Component>(Entity);

            if (update.ComponentInterest.HasValue)
            {
                component.ComponentInterest = update.ComponentInterest.Value;
            }

            EntityManager.SetComponentData(Entity, component);
        }
    }
}
