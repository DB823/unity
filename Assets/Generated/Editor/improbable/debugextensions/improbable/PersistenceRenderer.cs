// =====================================================
// DO NOT EDIT - this file is automatically regenerated.
// =====================================================

using Unity.Entities;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using Improbable.Gdk.Debug.WorkerInspector.Codegen;

namespace Improbable
{
    public class PersistenceRenderer : ComponentVisualElement
    {
        public override ComponentType ComponentType { get; } = ComponentType.ReadOnly<Persistence.Component>();



        public PersistenceRenderer() : base()
        {
            ComponentFoldout.text = "Persistence";

            AuthoritativeToggle.SetEnabled(false);

            InjectComponentIcon("d_TextAsset Icon");
        }

        public override void Update(EntityManager manager, Entity entity)
        {
            AuthoritativeToggle.value = manager.HasComponent<Persistence.HasAuthority>(entity);

            var component = manager.GetComponentData<Persistence.Component>(entity);


        }

        protected override void WriteDebugInfo()
        {
            UnityEngine.Debug.Log("Persistence generated from 'improbable/standard_library.schema' with Component ID '55'");
        }
    }
}
