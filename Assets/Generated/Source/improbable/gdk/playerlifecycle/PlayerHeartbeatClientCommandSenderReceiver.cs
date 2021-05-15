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
    public class PlayerHeartbeatClientCommandSenderSubscriptionManager : CommandSenderSubscriptionManagerBase<PlayerHeartbeatClientCommandSender>
    {
        public PlayerHeartbeatClientCommandSenderSubscriptionManager(World world) : base(world)
        {
        }

        protected override PlayerHeartbeatClientCommandSender CreateSender(Entity entity, World world)
        {
            return new PlayerHeartbeatClientCommandSender(entity, world);
        }
    }

    [AutoRegisterSubscriptionManager]
    public class PlayerHeartbeatClientCommandReceiverSubscriptionManager : CommandReceiverSubscriptionManagerBase<PlayerHeartbeatClientCommandReceiver>
    {
        public PlayerHeartbeatClientCommandReceiverSubscriptionManager(World world) : base(world, PlayerHeartbeatClient.ComponentId)
        {
        }

        protected override PlayerHeartbeatClientCommandReceiver CreateReceiver(World world, Entity entity, EntityId entityId)
        {
            return new PlayerHeartbeatClientCommandReceiver(world, entity, entityId);
        }
    }

    public class PlayerHeartbeatClientCommandSender : ICommandSender
    {
        private readonly Entity entity;
        private readonly CommandSystem commandSender;
        private readonly CommandCallbackSystem callbackSystem;
        private int callbackEpoch;

        public bool IsValid { get; set; }

        internal PlayerHeartbeatClientCommandSender(Entity entity, World world)
        {
            this.entity = entity;
            callbackSystem = world.GetOrCreateSystem<CommandCallbackSystem>();
            // todo check that this exists
            commandSender = world.GetExistingSystem<CommandSystem>();

            IsValid = true;
        }

        public void SendPlayerHeartbeatCommand(EntityId targetEntityId, global::Improbable.Gdk.Core.Empty request, Action<global::Improbable.Gdk.PlayerLifecycle.PlayerHeartbeatClient.PlayerHeartbeat.ReceivedResponse> callback = null)
        {
            var commandRequest = new PlayerHeartbeatClient.PlayerHeartbeat.Request(targetEntityId, request);
            SendPlayerHeartbeatCommand(commandRequest, callback);
        }

        public void SendPlayerHeartbeatCommand(global::Improbable.Gdk.PlayerLifecycle.PlayerHeartbeatClient.PlayerHeartbeat.Request request, Action<global::Improbable.Gdk.PlayerLifecycle.PlayerHeartbeatClient.PlayerHeartbeat.ReceivedResponse> callback = null)
        {
            int validCallbackEpoch = callbackEpoch;
            var requestId = commandSender.SendCommand(request, entity);
            if (callback != null)
            {
                Action<global::Improbable.Gdk.PlayerLifecycle.PlayerHeartbeatClient.PlayerHeartbeat.ReceivedResponse> wrappedCallback = response =>
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

    public class PlayerHeartbeatClientCommandReceiver : ICommandReceiver
    {
        private readonly EntityId entityId;
        private readonly CommandCallbackSystem callbackSystem;
        private readonly CommandSystem commandSystem;

        public bool IsValid { get; set; }

        private Dictionary<Action<global::Improbable.Gdk.PlayerLifecycle.PlayerHeartbeatClient.PlayerHeartbeat.ReceivedRequest>, ulong> playerHeartbeatCallbackToCallbackKey;

        public event Action<global::Improbable.Gdk.PlayerLifecycle.PlayerHeartbeatClient.PlayerHeartbeat.ReceivedRequest> OnPlayerHeartbeatRequestReceived
        {
            add
            {
                if (playerHeartbeatCallbackToCallbackKey == null)
                {
                    playerHeartbeatCallbackToCallbackKey = new Dictionary<Action<global::Improbable.Gdk.PlayerLifecycle.PlayerHeartbeatClient.PlayerHeartbeat.ReceivedRequest>, ulong>();
                }

                var key = callbackSystem.RegisterCommandRequestCallback(entityId, value);
                playerHeartbeatCallbackToCallbackKey.Add(value, key);
            }
            remove
            {
                if (!playerHeartbeatCallbackToCallbackKey.TryGetValue(value, out var key))
                {
                    return;
                }

                callbackSystem.UnregisterCommandRequestCallback<global::Improbable.Gdk.PlayerLifecycle.PlayerHeartbeatClient.PlayerHeartbeat.ReceivedRequest>(key);
                playerHeartbeatCallbackToCallbackKey.Remove(value);
            }
        }

        internal PlayerHeartbeatClientCommandReceiver(World world, Entity entity, EntityId entityId)
        {
            this.entityId = entityId;
            callbackSystem = world.GetOrCreateSystem<CommandCallbackSystem>();
            commandSystem = world.GetExistingSystem<CommandSystem>();
            // should check the system actually exists

            IsValid = true;
        }

        public void SendPlayerHeartbeatResponse(global::Improbable.Gdk.PlayerLifecycle.PlayerHeartbeatClient.PlayerHeartbeat.Response response)
        {
            commandSystem.SendResponse(response);
        }

        public void SendPlayerHeartbeatResponse(long requestId, global::Improbable.Gdk.Core.Empty response)
        {
            commandSystem.SendResponse(new global::Improbable.Gdk.PlayerLifecycle.PlayerHeartbeatClient.PlayerHeartbeat.Response(requestId, response));
        }

        public void SendPlayerHeartbeatFailure(long requestId, string failureMessage)
        {
            commandSystem.SendResponse(new global::Improbable.Gdk.PlayerLifecycle.PlayerHeartbeatClient.PlayerHeartbeat.Response(requestId, failureMessage));
        }

        public void RemoveAllCallbacks()
        {
            if (playerHeartbeatCallbackToCallbackKey != null)
            {
                foreach (var callbackToKey in playerHeartbeatCallbackToCallbackKey)
                {
                    callbackSystem.UnregisterCommandRequestCallback<global::Improbable.Gdk.PlayerLifecycle.PlayerHeartbeatClient.PlayerHeartbeat.ReceivedRequest>(callbackToKey.Value);
                }

                playerHeartbeatCallbackToCallbackKey.Clear();
            }
        }
    }
}
