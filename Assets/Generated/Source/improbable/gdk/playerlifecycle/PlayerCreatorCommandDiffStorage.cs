// =====================================================
// DO NOT EDIT - this file is automatically regenerated.
// =====================================================

using Improbable.Gdk.Core;
using Improbable.Gdk.Core.Commands;

namespace Improbable.Gdk.PlayerLifecycle
{
    public partial class PlayerCreator
    {
        private class DiffCreatePlayerCommandStorage
            : CommandDiffStorageBase<CreatePlayer.ReceivedRequest, CreatePlayer.ReceivedResponse>
        {
            public override uint ComponentId => Improbable.Gdk.PlayerLifecycle.PlayerCreator.ComponentId;
            public override uint CommandId => 1;
        }

        private class CreatePlayerCommandsToSendStorage :
            CommandSendStorage<CreatePlayer.Request, CreatePlayer.Response>,
            IComponentCommandSendStorage
        {
            uint IComponentCommandSendStorage.ComponentId => ComponentId;
            uint IComponentCommandSendStorage.CommandId => 1;
        }
    }
}
