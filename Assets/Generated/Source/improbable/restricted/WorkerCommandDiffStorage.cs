// =====================================================
// DO NOT EDIT - this file is automatically regenerated.
// =====================================================

using Improbable.Gdk.Core;
using Improbable.Gdk.Core.Commands;

namespace Improbable.Restricted
{
    public partial class Worker
    {
        private class DiffDisconnectCommandStorage
            : CommandDiffStorageBase<Disconnect.ReceivedRequest, Disconnect.ReceivedResponse>
        {
            public override uint ComponentId => Improbable.Restricted.Worker.ComponentId;
            public override uint CommandId => 1;
        }

        private class DisconnectCommandsToSendStorage :
            CommandSendStorage<Disconnect.Request, Disconnect.Response>,
            IComponentCommandSendStorage
        {
            uint IComponentCommandSendStorage.ComponentId => ComponentId;
            uint IComponentCommandSendStorage.CommandId => 1;
        }
    }
}
