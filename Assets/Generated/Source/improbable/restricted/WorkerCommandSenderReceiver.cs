// =====================================================
// DO NOT EDIT - this file is automatically regenerated.
// =====================================================

using System;
using System.Collections.Generic;
using Unity.Entities;
using Improbable.Gdk.Core;
using Improbable.Gdk.Subscriptions;
using Entity = Unity.Entities.Entity;

namespace Improbable.Restricted
{
    [AutoRegisterSubscriptionManager]
    public class WorkerCommandSenderSubscriptionManager : CommandSenderSubscriptionManagerBase<WorkerCommandSender>
    {
        public WorkerCommandSenderSubscriptionManager(World world) : base(world)
        {
        }

        protected override WorkerCommandSender CreateSender(Entity entity, World world)
        {
            return new WorkerCommandSender(entity, world);
        }
    }

    [AutoRegisterSubscriptionManager]
    public class WorkerCommandReceiverSubscriptionManager : CommandReceiverSubscriptionManagerBase<WorkerCommandReceiver>
    {
        public WorkerCommandReceiverSubscriptionManager(World world) : base(world, Worker.ComponentId)
        {
        }

        protected override WorkerCommandReceiver CreateReceiver(World world, Entity entity, EntityId entityId)
        {
            return new WorkerCommandReceiver(world, entity, entityId);
        }
    }

    public class WorkerCommandSender : ICommandSender
    {
        private readonly Entity entity;
        private readonly CommandSystem commandSender;
        private readonly CommandCallbackSystem callbackSystem;
        private int callbackEpoch;

        public bool IsValid { get; set; }

        internal WorkerCommandSender(Entity entity, World world)
        {
            this.entity = entity;
            callbackSystem = world.GetOrCreateSystem<CommandCallbackSystem>();
            // todo check that this exists
            commandSender = world.GetExistingSystem<CommandSystem>();

            IsValid = true;
        }

        public void SendDisconnectCommand(EntityId targetEntityId, global::Improbable.Restricted.DisconnectRequest request, Action<global::Improbable.Restricted.Worker.Disconnect.ReceivedResponse> callback = null)
        {
            var commandRequest = new Worker.Disconnect.Request(targetEntityId, request);
            SendDisconnectCommand(commandRequest, callback);
        }

        public void SendDisconnectCommand(global::Improbable.Restricted.Worker.Disconnect.Request request, Action<global::Improbable.Restricted.Worker.Disconnect.ReceivedResponse> callback = null)
        {
            int validCallbackEpoch = callbackEpoch;
            var requestId = commandSender.SendCommand(request, entity);
            if (callback != null)
            {
                Action<global::Improbable.Restricted.Worker.Disconnect.ReceivedResponse> wrappedCallback = response =>
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

    public class WorkerCommandReceiver : ICommandReceiver
    {
        private readonly EntityId entityId;
        private readonly CommandCallbackSystem callbackSystem;
        private readonly CommandSystem commandSystem;

        public bool IsValid { get; set; }

        private Dictionary<Action<global::Improbable.Restricted.Worker.Disconnect.ReceivedRequest>, ulong> disconnectCallbackToCallbackKey;

        public event Action<global::Improbable.Restricted.Worker.Disconnect.ReceivedRequest> OnDisconnectRequestReceived
        {
            add
            {
                if (disconnectCallbackToCallbackKey == null)
                {
                    disconnectCallbackToCallbackKey = new Dictionary<Action<global::Improbable.Restricted.Worker.Disconnect.ReceivedRequest>, ulong>();
                }

                var key = callbackSystem.RegisterCommandRequestCallback(entityId, value);
                disconnectCallbackToCallbackKey.Add(value, key);
            }
            remove
            {
                if (!disconnectCallbackToCallbackKey.TryGetValue(value, out var key))
                {
                    return;
                }

                callbackSystem.UnregisterCommandRequestCallback<global::Improbable.Restricted.Worker.Disconnect.ReceivedRequest>(key);
                disconnectCallbackToCallbackKey.Remove(value);
            }
        }

        internal WorkerCommandReceiver(World world, Entity entity, EntityId entityId)
        {
            this.entityId = entityId;
            callbackSystem = world.GetOrCreateSystem<CommandCallbackSystem>();
            commandSystem = world.GetExistingSystem<CommandSystem>();
            // should check the system actually exists

            IsValid = true;
        }

        public void SendDisconnectResponse(global::Improbable.Restricted.Worker.Disconnect.Response response)
        {
            commandSystem.SendResponse(response);
        }

        public void SendDisconnectResponse(long requestId, global::Improbable.Restricted.DisconnectResponse response)
        {
            commandSystem.SendResponse(new global::Improbable.Restricted.Worker.Disconnect.Response(requestId, response));
        }

        public void SendDisconnectFailure(long requestId, string failureMessage)
        {
            commandSystem.SendResponse(new global::Improbable.Restricted.Worker.Disconnect.Response(requestId, failureMessage));
        }

        public void RemoveAllCallbacks()
        {
            if (disconnectCallbackToCallbackKey != null)
            {
                foreach (var callbackToKey in disconnectCallbackToCallbackKey)
                {
                    callbackSystem.UnregisterCommandRequestCallback<global::Improbable.Restricted.Worker.Disconnect.ReceivedRequest>(callbackToKey.Value);
                }

                disconnectCallbackToCallbackKey.Clear();
            }
        }
    }
}
