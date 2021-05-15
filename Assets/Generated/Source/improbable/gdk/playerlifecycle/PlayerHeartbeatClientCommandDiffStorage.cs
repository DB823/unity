// =====================================================
// DO NOT EDIT - this file is automatically regenerated.
// =====================================================

using Improbable.Gdk.Core;
using Improbable.Gdk.Core.Commands;

namespace Improbable.Gdk.PlayerLifecycle
{
    public partial class PlayerHeartbeatClient
    {
        private class DiffPlayerHeartbeatCommandStorage
            : CommandDiffStorageBase<PlayerHeartbeat.ReceivedRequest, PlayerHeartbeat.ReceivedResponse>
        {
            public override uint ComponentId => Improbable.Gdk.PlayerLifecycle.PlayerHeartbeatClient.ComponentId;
            public override uint CommandId => 1;
        }

        private class PlayerHeartbeatCommandsToSendStorage :
            CommandSendStorage<PlayerHeartbeat.Request, PlayerHeartbeat.Response>,
            IComponentCommandSendStorage
        {
            uint IComponentCommandSendStorage.ComponentId => ComponentId;
            uint IComponentCommandSendStorage.CommandId => 1;
        }
    }
}
