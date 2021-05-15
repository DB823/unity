// =====================================================
// DO NOT EDIT - this file is automatically regenerated.
// =====================================================

using Unity.Entities;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using Improbable.Gdk.Debug.WorkerInspector.Codegen;

namespace Improbable.Gdk.PlayerLifecycle
{
    public class PlayerHeartbeatClientRenderer : ComponentVisualElement
    {
        public override ComponentType ComponentType { get; } = ComponentType.ReadOnly<PlayerHeartbeatClient.Component>();



        public PlayerHeartbeatClientRenderer() : base()
        {
            ComponentFoldout.text = "PlayerHeartbeatClient";

            AuthoritativeToggle.SetEnabled(false);

            InjectComponentIcon("d_TextAsset Icon");
        }

        public override void Update(EntityManager manager, Entity entity)
        {
            AuthoritativeToggle.value = manager.HasComponent<PlayerHeartbeatClient.HasAuthority>(entity);

            var component = manager.GetComponentData<PlayerHeartbeatClient.Component>(entity);


        }

        protected override void WriteDebugInfo()
        {
            UnityEngine.Debug.Log("PlayerHeartbeatClient generated from 'improbable/gdk/player_lifecycle/player_heartbeat.schema' with Component ID '13001'");
        }
    }
}
