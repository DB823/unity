// =====================================================
// DO NOT EDIT - this file is automatically regenerated.
// =====================================================

using Unity.Entities;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using Improbable.Gdk.Debug.WorkerInspector.Codegen;

namespace Improbable.Restricted
{
    public class SystemRenderer : ComponentVisualElement
    {
        public override ComponentType ComponentType { get; } = ComponentType.ReadOnly<System.Component>();



        public SystemRenderer() : base()
        {
            ComponentFoldout.text = "System";

            AuthoritativeToggle.SetEnabled(false);

            InjectComponentIcon("d_TextAsset Icon");
        }

        public override void Update(EntityManager manager, Entity entity)
        {
            AuthoritativeToggle.value = manager.HasComponent<System.HasAuthority>(entity);

            var component = manager.GetComponentData<System.Component>(entity);


        }

        protected override void WriteDebugInfo()
        {
            UnityEngine.Debug.Log("System generated from 'improbable/restricted/system_components.schema' with Component ID '59'");
        }
    }
}
