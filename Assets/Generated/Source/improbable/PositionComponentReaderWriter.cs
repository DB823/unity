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
    public class PositionReaderSubscriptionManager : ReaderSubscriptionManager<Position.Component, PositionReader>
    {
        public PositionReaderSubscriptionManager(World world) : base(world)
        {
        }

        protected override PositionReader CreateReader(Entity entity, EntityId entityId)
        {
            return new PositionReader(World, entity, entityId);
        }
    }

    [AutoRegisterSubscriptionManager]
    public class PositionWriterSubscriptionManager : WriterSubscriptionManager<Position.Component, PositionWriter>
    {
        public PositionWriterSubscriptionManager(World world) : base(world)
        {
        }

        protected override PositionWriter CreateWriter(Entity entity, EntityId entityId)
        {
            return new PositionWriter(World, entity, entityId);
        }
    }

    public class PositionReader : Reader<Position.Component, Position.Update>
    {
        private Dictionary<Action<global::Improbable.Coordinates>, ulong> coordsUpdateCallbackToCallbackKey;

        internal PositionReader(World world, Entity entity, EntityId entityId) : base(world, entity, entityId)
        {
        }

        public event Action<global::Improbable.Coordinates> OnCoordsUpdate
        {
            add
            {
                if (!IsValid)
                {
                    throw new InvalidOperationException("Cannot add field update callback when Reader is not valid.");
                }

                if (coordsUpdateCallbackToCallbackKey == null)
                {
                    coordsUpdateCallbackToCallbackKey = new Dictionary<Action<global::Improbable.Coordinates>, ulong>();
                }

                var key = CallbackSystem.RegisterComponentUpdateCallback<Position.Update>(EntityId, update =>
                {
                    if (update.Coords.HasValue)
                    {
                        value(update.Coords.Value);
                    }
                });
                coordsUpdateCallbackToCallbackKey.Add(value, key);
            }
            remove
            {
                if (!coordsUpdateCallbackToCallbackKey.TryGetValue(value, out var key))
                {
                    return;
                }

                CallbackSystem.UnregisterCallback(key);
                coordsUpdateCallbackToCallbackKey.Remove(value);
            }
        }

        protected override void RemoveFieldCallbacks()
        {
            if (coordsUpdateCallbackToCallbackKey != null)
            {
                foreach (var callbackToKey in coordsUpdateCallbackToCallbackKey)
                {
                    CallbackSystem.UnregisterCallback(callbackToKey.Value);
                }

                coordsUpdateCallbackToCallbackKey.Clear();
            }
        }
    }

    public class PositionWriter : PositionReader
    {
        internal PositionWriter(World world, Entity entity, EntityId entityId)
            : base(world, entity, entityId)
        {
        }

        public void SendUpdate(Position.Update update)
        {
            var component = EntityManager.GetComponentData<Position.Component>(Entity);

            if (update.Coords.HasValue)
            {
                component.Coords = update.Coords.Value;
            }

            EntityManager.SetComponentData(Entity, component);
        }
    }
}
