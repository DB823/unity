// =====================================================
// DO NOT EDIT - this file is automatically regenerated.
// =====================================================

using Improbable.Gdk.Core;
using Improbable.Gdk.Core.Commands;
using Improbable.Worker.CInterop;

namespace Improbable.Gdk.PlayerLifecycle
{
    public partial class PlayerCreator
    {
        private class CreatePlayerDiffCommandDeserializer : ICommandDiffDeserializer
        {
            public void AddRequestToDiff(CommandRequestOp op, ViewDiff diff)
            {
                var deserializedRequest = global::Improbable.Gdk.PlayerLifecycle.CreatePlayerRequest.Serialization.Deserialize(op.Request.SchemaData.Value.GetObject());

                var request = new CreatePlayer.ReceivedRequest(
                    new EntityId(op.EntityId),
                    op.RequestId,
                    op.CallerWorkerId,
                    op.CallerAttributeSet,
                    deserializedRequest);

                diff.AddCommandRequest(request, ComponentId, 1);
            }

            public void AddResponseToDiff(CommandResponseOp op, ViewDiff diff, CommandMetaData commandMetaData)
            {
                global::Improbable.Gdk.PlayerLifecycle.CreatePlayerResponse? rawResponse = null;
                if (op.StatusCode == StatusCode.Success)
                {
                    rawResponse = global::Improbable.Gdk.PlayerLifecycle.CreatePlayerResponse.Serialization.Deserialize(op.Response.SchemaData.Value.GetObject());
                }

                var internalRequestId = new InternalCommandRequestId(op.RequestId);
                var commandContext = commandMetaData.GetContext<global::Improbable.Gdk.PlayerLifecycle.CreatePlayerRequest>(ComponentId, 1, internalRequestId);
                commandMetaData.RemoveRequest(ComponentId, 1, internalRequestId);

                var response = new CreatePlayer.ReceivedResponse(
                    commandContext.SendingEntity,
                    new EntityId(op.EntityId),
                    op.Message,
                    op.StatusCode,
                    rawResponse,
                    commandContext.Request,
                    commandContext.Context,
                    commandContext.RequestId);

                diff.AddCommandResponse(response, ComponentId, 1);
            }
        }

        private class CreatePlayerCommandSerializer : ICommandSerializer
        {
            public void Serialize(MessagesToSend messages, SerializedMessagesToSend serializedMessages, CommandMetaData commandMetaData)
            {
                var storage = (CreatePlayerCommandsToSendStorage) messages.GetCommandSendStorage(ComponentId, 1);

                var requests = storage.GetRequests();

                for (int i = 0; i < requests.Count; ++i)
                {
                    ref readonly var request = ref requests[i];
                    var context = new CommandContext<global::Improbable.Gdk.PlayerLifecycle.CreatePlayerRequest>(request.SendingEntity, request.Request.Payload, request.Request.Context, request.RequestId);
                    commandMetaData.AddRequest<global::Improbable.Gdk.PlayerLifecycle.CreatePlayerRequest>(ComponentId, 1, in context);

                    var schemaCommandRequest = global::Improbable.Worker.CInterop.SchemaCommandRequest.Create();
                    global::Improbable.Gdk.PlayerLifecycle.CreatePlayerRequest.Serialization.Serialize(request.Request.Payload, schemaCommandRequest.GetObject());
                    var serializedRequest = new global::Improbable.Worker.CInterop.CommandRequest(ComponentId, 1, schemaCommandRequest);

                    serializedMessages.AddRequest(serializedRequest, 1,
                        request.Request.TargetEntityId.Id, request.Request.TimeoutMillis, request.RequestId);
                }

                var responses = storage.GetResponses();
                for (int i = 0; i < responses.Count; ++i)
                {
                    ref readonly var response = ref responses[i];
                    if (response.FailureMessage != null)
                    {
                        // Send a command failure if the string is non-null.

                        serializedMessages.AddFailure(ComponentId, 1, response.FailureMessage, (uint) response.RequestId);
                        continue;
                    }

                    var schemaCommandResponse = global::Improbable.Worker.CInterop.SchemaCommandResponse.Create();
                    global::Improbable.Gdk.PlayerLifecycle.CreatePlayerResponse.Serialization.Serialize(response.Payload.Value, schemaCommandResponse.GetObject());

                    var serializedResponse = new global::Improbable.Worker.CInterop.CommandResponse(ComponentId, 1, schemaCommandResponse);

                    serializedMessages.AddResponse(serializedResponse, (uint) response.RequestId);
                }
            }
        }
    }
}
