// =====================================================
// DO NOT EDIT - this file is automatically regenerated.
// =====================================================

using Unity.Entities;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using Improbable.Gdk.Debug.WorkerInspector.Codegen;

namespace Improbable.Restricted
{
    public class PlayerClientRenderer : ComponentVisualElement
    {
        public override ComponentType ComponentType { get; } = ComponentType.ReadOnly<PlayerClient.Component>();

        private readonly global::Improbable.Restricted.PlayerIdentityRenderer playerIdentityField;

        public PlayerClientRenderer() : base()
        {
            ComponentFoldout.text = "PlayerClient";

            AuthoritativeToggle.SetEnabled(false);

            playerIdentityField = new global::Improbable.Restricted.PlayerIdentityRenderer("Player Identity", 0 + 1);
            ComponentFoldout.Add(playerIdentityField);

            InjectComponentIcon("d_TextAsset Icon");
        }

        public override void Update(EntityManager manager, Entity entity)
        {
            AuthoritativeToggle.value = manager.HasComponent<PlayerClient.HasAuthority>(entity);

            var component = manager.GetComponentData<PlayerClient.Component>(entity);

            playerIdentityField.Update(component.PlayerIdentity);
        }

        protected override void WriteDebugInfo()
        {
            UnityEngine.Debug.Log("PlayerClient generated from 'improbable/restricted/system_components.schema' with Component ID '61'");
        }
    }
}
