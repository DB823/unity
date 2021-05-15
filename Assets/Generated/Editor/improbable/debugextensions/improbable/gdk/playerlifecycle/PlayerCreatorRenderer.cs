// =====================================================
// DO NOT EDIT - this file is automatically regenerated.
// =====================================================

using Unity.Entities;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using Improbable.Gdk.Debug.WorkerInspector.Codegen;

namespace Improbable.Gdk.PlayerLifecycle
{
    public class PlayerCreatorRenderer : ComponentVisualElement
    {
        public override ComponentType ComponentType { get; } = ComponentType.ReadOnly<PlayerCreator.Component>();



        public PlayerCreatorRenderer() : base()
        {
            ComponentFoldout.text = "PlayerCreator";

            AuthoritativeToggle.SetEnabled(false);

            InjectComponentIcon("d_TextAsset Icon");
        }

        public override void Update(EntityManager manager, Entity entity)
        {
            AuthoritativeToggle.value = manager.HasComponent<PlayerCreator.HasAuthority>(entity);

            var component = manager.GetComponentData<PlayerCreator.Component>(entity);


        }

        protected override void WriteDebugInfo()
        {
            UnityEngine.Debug.Log("PlayerCreator generated from 'improbable/gdk/player_lifecycle/player_creator.schema' with Component ID '13000'");
        }
    }
}
