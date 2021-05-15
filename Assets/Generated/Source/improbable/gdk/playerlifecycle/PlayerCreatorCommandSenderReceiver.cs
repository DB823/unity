// =====================================================
// DO NOT EDIT - this file is automatically regenerated.
// =====================================================

using System;
using System.Collections.Generic;
using Unity.Entities;
using Improbable.Gdk.Core;
using Improbable.Gdk.Subscriptions;
using Entity = Unity.Entities.Entity;

namespace Improbable.Gdk.PlayerLifecycle
{
    [AutoRegisterSubscriptionManager]
    public class PlayerCreatorCommandSenderSubscriptionManager : CommandSenderSubscriptionManagerBase<PlayerCreatorCommandSender>
    {
        public PlayerCreatorCommandSenderSubscriptionManager(World world) : base(world)
        {
        }

        protected override PlayerCreatorCommandSender CreateSender(Entity entity, World world)
        {
            return new PlayerCreatorCommandSender(entity, world);
        }
    }

    [AutoRegisterSubscriptionManager]
    public class PlayerCreatorCommandReceiverSubscriptionManager : CommandReceiverSubscriptionManagerBase<PlayerCreatorCommandReceiver>
    {
        public PlayerCreatorCommandReceiverSubscriptionManager(World world) : base(world, PlayerCreator.ComponentId)
        {
        }

        protected override PlayerCreatorCommandReceiver CreateReceiver(World world, Entity entity, EntityId entityId)
        {
            return new PlayerCreatorCommandReceiver(world, entity, entityId);
        }
    }

    public class PlayerCreatorCommandSender : ICommandSender
    {
        private readonly Entity entity;
        private readonly CommandSystem commandSender;
        private readonly CommandCallbackSystem callbackSystem;
        private int callbackEpoch;

        public bool IsValid { get; set; }

        internal PlayerCreatorCommandSender(Entity entity, World world)
        {
            this.entity = entity;
            callbackSystem = world.GetOrCreateSystem<CommandCallbackSystem>();
            // todo check that this exists
            commandSender = world.GetExistingSystem<CommandSystem>();

            IsValid = true;
        }

        public void SendCreatePlayerCommand(EntityId targetEntityId, global::Improbable.Gdk.PlayerLifecycle.CreatePlayerRequest request, Action<global::Improbable.Gdk.PlayerLifecycle.PlayerCreator.CreatePlayer.ReceivedResponse> callback = null)
        {
            var commandRequest = new PlayerCreator.CreatePlayer.Request(targetEntityId, request);
            SendCreatePlayerCommand(commandRequest, callback);
        }

        public void SendCreatePlayerCommand(global::Improbable.Gdk.PlayerLifecycle.PlayerCreator.CreatePlayer.Request request, Action<global::Improbable.Gdk.PlayerLifecycle.PlayerCreator.CreatePlayer.ReceivedResponse> callback = null)
        {
            int validCallbackEpoch = callbackEpoch;
            var requestId = commandSender.SendCommand(request, entity);
            if (callback != null)
            {
                Action<global::Improbable.Gdk.PlayerLifecycle.PlayerCreator.CreatePlayer.ReceivedResponse> wrappedCallback = response =>
                {
                    if (!this.IsValid || validCallbackEpoch != this.callbackEpoch)
                    {
                        return;
                    }

                    callback(response);
                };
                callbackSystem.RegisterCommandResponseCallback(requestId, wrappedCallback);
            }
        }

        public void RemoveAllCallbacks()
        {
            ++callbackEpoch;
        }
    }

    public class PlayerCreatorCommandReceiver : ICommandReceiver
    {
        private readonly EntityId entityId;
        private readonly CommandCallbackSystem callbackSystem;
        private readonly CommandSystem commandSystem;

        public bool IsValid { get; set; }

        private Dictionary<Action<global::Improbable.Gdk.PlayerLifecycle.PlayerCreator.CreatePlayer.ReceivedRequest>, ulong> createPlayerCallbackToCallbackKey;

        public event Action<global::Improbable.Gdk.PlayerLifecycle.PlayerCreator.CreatePlayer.ReceivedRequest> OnCreatePlayerRequestReceived
        {
            add
            {
                if (createPlayerCallbackToCallbackKey == null)
                {
                    createPlayerCallbackToCallbackKey = new Dictionary<Action<global::Improbable.Gdk.PlayerLifecycle.PlayerCreator.CreatePlayer.ReceivedRequest>, ulong>();
                }

                var key = callbackSystem.RegisterCommandRequestCallback(entityId, value);
                createPlayerCallbackToCallbackKey.Add(value, key);
            }
            remove
            {
                if (!createPlayerCallbackToCallbackKey.TryGetValue(value, out var key))
                {
                    return;
                }

                callbackSystem.UnregisterCommandRequestCallback<global::Improbable.Gdk.PlayerLifecycle.PlayerCreator.CreatePlayer.ReceivedRequest>(key);
                createPlayerCallbackToCallbackKey.Remove(value);
            }
        }

        internal PlayerCreatorCommandReceiver(World world, Entity entity, EntityId entityId)
        {
            this.entityId = entityId;
            callbackSystem = world.GetOrCreateSystem<CommandCallbackSystem>();
            commandSystem = world.GetExistingSystem<CommandSystem>();
            // should check the system actually exists

            IsValid = true;
        }

        public void SendCreatePlayerResponse(global::Improbable.Gdk.PlayerLifecycle.PlayerCreator.CreatePlayer.Response response)
        {
            commandSystem.SendResponse(response);
        }

        public void SendCreatePlayerResponse(long requestId, global::Improbable.Gdk.PlayerLifecycle.CreatePlayerResponse response)
        {
            commandSystem.SendResponse(new global::Improbable.Gdk.PlayerLifecycle.PlayerCreator.CreatePlayer.Response(requestId, response));
        }

        public void SendCreatePlayerFailure(long requestId, string failureMessage)
        {
            commandSystem.SendResponse(new global::Improbable.Gdk.PlayerLifecycle.PlayerCreator.CreatePlayer.Response(requestId, failureMessage));
        }

        public void RemoveAllCallbacks()
        {
            if (createPlayerCallbackToCallbackKey != null)
            {
                foreach (var callbackToKey in createPlayerCallbackToCallbackKey)
                {
                    callbackSystem.UnregisterCommandRequestCallback<global::Improbable.Gdk.PlayerLifecycle.PlayerCreator.CreatePlayer.ReceivedRequest>(callbackToKey.Value);
                }

                createPlayerCallbackToCallbackKey.Clear();
            }
        }
    }
}
