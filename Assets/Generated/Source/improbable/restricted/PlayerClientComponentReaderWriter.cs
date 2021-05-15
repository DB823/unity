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
    public class PlayerClientReaderSubscriptionManager : ReaderSubscriptionManager<PlayerClient.Component, PlayerClientReader>
    {
        public PlayerClientReaderSubscriptionManager(World world) : base(world)
        {
        }

        protected override PlayerClientReader CreateReader(Entity entity, EntityId entityId)
        {
            return new PlayerClientReader(World, entity, entityId);
        }
    }

    [AutoRegisterSubscriptionManager]
    public class PlayerClientWriterSubscriptionManager : WriterSubscriptionManager<PlayerClient.Component, PlayerClientWriter>
    {
        public PlayerClientWriterSubscriptionManager(World world) : base(world)
        {
        }

        protected override PlayerClientWriter CreateWriter(Entity entity, EntityId entityId)
        {
            return new PlayerClientWriter(World, entity, entityId);
        }
    }

    public class PlayerClientReader : Reader<PlayerClient.Component, PlayerClient.Update>
    {
        private Dictionary<Action<global::Improbable.Restricted.PlayerIdentity>, ulong> playerIdentityUpdateCallbackToCallbackKey;

        internal PlayerClientReader(World world, Entity entity, EntityId entityId) : base(world, entity, entityId)
        {
        }

        public event Action<global::Improbable.Restricted.PlayerIdentity> OnPlayerIdentityUpdate
        {
            add
            {
                if (!IsValid)
                {
                    throw new InvalidOperationException("Cannot add field update callback when Reader is not valid.");
                }

                if (playerIdentityUpdateCallbackToCallbackKey == null)
                {
                    playerIdentityUpdateCallbackToCallbackKey = new Dictionary<Action<global::Improbable.Restricted.PlayerIdentity>, ulong>();
                }

                var key = CallbackSystem.RegisterComponentUpdateCallback<PlayerClient.Update>(EntityId, update =>
                {
                    if (update.PlayerIdentity.HasValue)
                    {
                        value(update.PlayerIdentity.Value);
                    }
                });
                playerIdentityUpdateCallbackToCallbackKey.Add(value, key);
            }
            remove
            {
                if (!playerIdentityUpdateCallbackToCallbackKey.TryGetValue(value, out var key))
                {
                    return;
                }

                CallbackSystem.UnregisterCallback(key);
                playerIdentityUpdateCallbackToCallbackKey.Remove(value);
            }
        }

        protected override void RemoveFieldCallbacks()
        {
            if (playerIdentityUpdateCallbackToCallbackKey != null)
            {
                foreach (var callbackToKey in playerIdentityUpdateCallbackToCallbackKey)
                {
                    CallbackSystem.UnregisterCallback(callbackToKey.Value);
                }

                playerIdentityUpdateCallbackToCallbackKey.Clear();
            }
        }
    }

    public class PlayerClientWriter : PlayerClientReader
    {
        internal PlayerClientWriter(World world, Entity entity, EntityId entityId)
            : base(world, entity, entityId)
        {
        }

        public void SendUpdate(PlayerClient.Update update)
        {
            var component = EntityManager.GetComponentData<PlayerClient.Component>(Entity);

            if (update.PlayerIdentity.HasValue)
            {
                component.PlayerIdentity = update.PlayerIdentity.Value;
            }

            EntityManager.SetComponentData(Entity, component);
        }
    }
}
