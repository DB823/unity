// =====================================================
// DO NOT EDIT - this file is automatically regenerated.
// =====================================================

using System;
using System.Collections.Generic;
using Improbable.Gdk.Core;
using Improbable.Gdk.Subscriptions;
using Unity.Entities;
using Entity = Unity.Entities.Entity;

namespace Improbable.Gdk.TransformSynchronization
{
    [AutoRegisterSubscriptionManager]
    public class TransformInternalReaderSubscriptionManager : ReaderSubscriptionManager<TransformInternal.Component, TransformInternalReader>
    {
        public TransformInternalReaderSubscriptionManager(World world) : base(world)
        {
        }

        protected override TransformInternalReader CreateReader(Entity entity, EntityId entityId)
        {
            return new TransformInternalReader(World, entity, entityId);
        }
    }

    [AutoRegisterSubscriptionManager]
    public class TransformInternalWriterSubscriptionManager : WriterSubscriptionManager<TransformInternal.Component, TransformInternalWriter>
    {
        public TransformInternalWriterSubscriptionManager(World world) : base(world)
        {
        }

        protected override TransformInternalWriter CreateWriter(Entity entity, EntityId entityId)
        {
            return new TransformInternalWriter(World, entity, entityId);
        }
    }

    public class TransformInternalReader : Reader<TransformInternal.Component, TransformInternal.Update>
    {
        private Dictionary<Action<global::Improbable.Gdk.TransformSynchronization.FixedPointVector3>, ulong> locationUpdateCallbackToCallbackKey;

        private Dictionary<Action<global::Improbable.Gdk.TransformSynchronization.CompressedQuaternion>, ulong> rotationUpdateCallbackToCallbackKey;

        private Dictionary<Action<global::Improbable.Gdk.TransformSynchronization.FixedPointVector3>, ulong> velocityUpdateCallbackToCallbackKey;

        private Dictionary<Action<uint>, ulong> physicsTickUpdateCallbackToCallbackKey;

        private Dictionary<Action<float>, ulong> ticksPerSecondUpdateCallbackToCallbackKey;

        internal TransformInternalReader(World world, Entity entity, EntityId entityId) : base(world, entity, entityId)
        {
        }

        public event Action<global::Improbable.Gdk.TransformSynchronization.FixedPointVector3> OnLocationUpdate
        {
            add
            {
                if (!IsValid)
                {
                    throw new InvalidOperationException("Cannot add field update callback when Reader is not valid.");
                }

                if (locationUpdateCallbackToCallbackKey == null)
                {
                    locationUpdateCallbackToCallbackKey = new Dictionary<Action<global::Improbable.Gdk.TransformSynchronization.FixedPointVector3>, ulong>();
                }

                var key = CallbackSystem.RegisterComponentUpdateCallback<TransformInternal.Update>(EntityId, update =>
                {
                    if (update.Location.HasValue)
                    {
                        value(update.Location.Value);
                    }
                });
                locationUpdateCallbackToCallbackKey.Add(value, key);
            }
            remove
            {
                if (!locationUpdateCallbackToCallbackKey.TryGetValue(value, out var key))
                {
                    return;
                }

                CallbackSystem.UnregisterCallback(key);
                locationUpdateCallbackToCallbackKey.Remove(value);
            }
        }

        public event Action<global::Improbable.Gdk.TransformSynchronization.CompressedQuaternion> OnRotationUpdate
        {
            add
            {
                if (!IsValid)
                {
                    throw new InvalidOperationException("Cannot add field update callback when Reader is not valid.");
                }

                if (rotationUpdateCallbackToCallbackKey == null)
                {
                    rotationUpdateCallbackToCallbackKey = new Dictionary<Action<global::Improbable.Gdk.TransformSynchronization.CompressedQuaternion>, ulong>();
                }

                var key = CallbackSystem.RegisterComponentUpdateCallback<TransformInternal.Update>(EntityId, update =>
                {
                    if (update.Rotation.HasValue)
                    {
                        value(update.Rotation.Value);
                    }
                });
                rotationUpdateCallbackToCallbackKey.Add(value, key);
            }
            remove
            {
                if (!rotationUpdateCallbackToCallbackKey.TryGetValue(value, out var key))
                {
                    return;
                }

                CallbackSystem.UnregisterCallback(key);
                rotationUpdateCallbackToCallbackKey.Remove(value);
            }
        }

        public event Action<global::Improbable.Gdk.TransformSynchronization.FixedPointVector3> OnVelocityUpdate
        {
            add
            {
                if (!IsValid)
                {
                    throw new InvalidOperationException("Cannot add field update callback when Reader is not valid.");
                }

                if (velocityUpdateCallbackToCallbackKey == null)
                {
                    velocityUpdateCallbackToCallbackKey = new Dictionary<Action<global::Improbable.Gdk.TransformSynchronization.FixedPointVector3>, ulong>();
                }

                var key = CallbackSystem.RegisterComponentUpdateCallback<TransformInternal.Update>(EntityId, update =>
                {
                    if (update.Velocity.HasValue)
                    {
                        value(update.Velocity.Value);
                    }
                });
                velocityUpdateCallbackToCallbackKey.Add(value, key);
            }
            remove
            {
                if (!velocityUpdateCallbackToCallbackKey.TryGetValue(value, out var key))
                {
                    return;
                }

                CallbackSystem.UnregisterCallback(key);
                velocityUpdateCallbackToCallbackKey.Remove(value);
            }
        }

        public event Action<uint> OnPhysicsTickUpdate
        {
            add
            {
                if (!IsValid)
                {
                    throw new InvalidOperationException("Cannot add field update callback when Reader is not valid.");
                }

                if (physicsTickUpdateCallbackToCallbackKey == null)
                {
                    physicsTickUpdateCallbackToCallbackKey = new Dictionary<Action<uint>, ulong>();
                }

                var key = CallbackSystem.RegisterComponentUpdateCallback<TransformInternal.Update>(EntityId, update =>
                {
                    if (update.PhysicsTick.HasValue)
                    {
                        value(update.PhysicsTick.Value);
                    }
                });
                physicsTickUpdateCallbackToCallbackKey.Add(value, key);
            }
            remove
            {
                if (!physicsTickUpdateCallbackToCallbackKey.TryGetValue(value, out var key))
                {
                    return;
                }

                CallbackSystem.UnregisterCallback(key);
                physicsTickUpdateCallbackToCallbackKey.Remove(value);
            }
        }

        public event Action<float> OnTicksPerSecondUpdate
        {
            add
            {
                if (!IsValid)
                {
                    throw new InvalidOperationException("Cannot add field update callback when Reader is not valid.");
                }

                if (ticksPerSecondUpdateCallbackToCallbackKey == null)
                {
                    ticksPerSecondUpdateCallbackToCallbackKey = new Dictionary<Action<float>, ulong>();
                }

                var key = CallbackSystem.RegisterComponentUpdateCallback<TransformInternal.Update>(EntityId, update =>
                {
                    if (update.TicksPerSecond.HasValue)
                    {
                        value(update.TicksPerSecond.Value);
                    }
                });
                ticksPerSecondUpdateCallbackToCallbackKey.Add(value, key);
            }
            remove
            {
                if (!ticksPerSecondUpdateCallbackToCallbackKey.TryGetValue(value, out var key))
                {
                    return;
                }

                CallbackSystem.UnregisterCallback(key);
                ticksPerSecondUpdateCallbackToCallbackKey.Remove(value);
            }
        }

        protected override void RemoveFieldCallbacks()
        {
            if (locationUpdateCallbackToCallbackKey != null)
            {
                foreach (var callbackToKey in locationUpdateCallbackToCallbackKey)
                {
                    CallbackSystem.UnregisterCallback(callbackToKey.Value);
                }

                locationUpdateCallbackToCallbackKey.Clear();
            }

            if (rotationUpdateCallbackToCallbackKey != null)
            {
                foreach (var callbackToKey in rotationUpdateCallbackToCallbackKey)
                {
                    CallbackSystem.UnregisterCallback(callbackToKey.Value);
                }

                rotationUpdateCallbackToCallbackKey.Clear();
            }

            if (velocityUpdateCallbackToCallbackKey != null)
            {
                foreach (var callbackToKey in velocityUpdateCallbackToCallbackKey)
                {
                    CallbackSystem.UnregisterCallback(callbackToKey.Value);
                }

                velocityUpdateCallbackToCallbackKey.Clear();
            }

            if (physicsTickUpdateCallbackToCallbackKey != null)
            {
                foreach (var callbackToKey in physicsTickUpdateCallbackToCallbackKey)
                {
                    CallbackSystem.UnregisterCallback(callbackToKey.Value);
                }

                physicsTickUpdateCallbackToCallbackKey.Clear();
            }

            if (ticksPerSecondUpdateCallbackToCallbackKey != null)
            {
                foreach (var callbackToKey in ticksPerSecondUpdateCallbackToCallbackKey)
                {
                    CallbackSystem.UnregisterCallback(callbackToKey.Value);
                }

                ticksPerSecondUpdateCallbackToCallbackKey.Clear();
            }
        }
    }

    public class TransformInternalWriter : TransformInternalReader
    {
        internal TransformInternalWriter(World world, Entity entity, EntityId entityId)
            : base(world, entity, entityId)
        {
        }

        public void SendUpdate(TransformInternal.Update update)
        {
            var component = EntityManager.GetComponentData<TransformInternal.Component>(Entity);

            if (update.Location.HasValue)
            {
                component.Location = update.Location.Value;
            }

            if (update.Rotation.HasValue)
            {
                component.Rotation = update.Rotation.Value;
            }

            if (update.Velocity.HasValue)
            {
                component.Velocity = update.Velocity.Value;
            }

            if (update.PhysicsTick.HasValue)
            {
                component.PhysicsTick = update.PhysicsTick.Value;
            }

            if (update.TicksPerSecond.HasValue)
            {
                component.TicksPerSecond = update.TicksPerSecond.Value;
            }

            EntityManager.SetComponentData(Entity, component);
        }
    }
}
