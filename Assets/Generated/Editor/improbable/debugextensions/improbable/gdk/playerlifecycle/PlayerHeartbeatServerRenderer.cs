// =====================================================
// DO NOT EDIT - this file is automatically regenerated.
// =====================================================

using Unity.Entities;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using Improbable.Gdk.Debug.WorkerInspector.Codegen;

namespace Improbable.Gdk.PlayerLifecycle
{
    public class PlayerHeartbeatServerRenderer : ComponentVisualElement
    {
        public override ComponentType ComponentType { get; } = ComponentType.ReadOnly<PlayerHeartbeatServer.Component>();



        public PlayerHeartbeatServerRenderer() : base()
        {
            ComponentFoldout.text = "PlayerHeartbeatServer";

            AuthoritativeToggle.SetEnabled(false);

            InjectComponentIcon("d_TextAsset Icon");
        }

        public override void Update(EntityManager manager, Entity entity)
        {
            AuthoritativeToggle.value = manager.HasComponent<PlayerHeartbeatServer.HasAuthority>(entity);

            var component = manager.GetComponentData<PlayerHeartbeatServer.Component>(entity);


        }

        protected override void WriteDebugInfo()
        {
            UnityEngine.Debug.Log("PlayerHeartbeatServer generated from 'improbable/gdk/player_lifecycle/player_heartbeat.schema' with Component ID '13002'");
        }
    }
}
