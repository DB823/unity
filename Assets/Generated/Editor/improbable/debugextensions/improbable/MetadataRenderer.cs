// =====================================================
// DO NOT EDIT - this file is automatically regenerated.
// =====================================================

using Unity.Entities;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using Improbable.Gdk.Debug.WorkerInspector.Codegen;

namespace Improbable
{
    public class MetadataRenderer : ComponentVisualElement
    {
        public override ComponentType ComponentType { get; } = ComponentType.ReadOnly<Metadata.Component>();

        private readonly TextField entityTypeField;

        public MetadataRenderer() : base()
        {
            ComponentFoldout.text = "Metadata";

            AuthoritativeToggle.SetEnabled(false);

            entityTypeField = new TextField("Entity Type");
            entityTypeField.labelElement.ShiftRightMargin(0);
            entityTypeField.SetEnabled(false);
            ComponentFoldout.Add(entityTypeField);

            InjectComponentIcon("d_FilterByLabel");
        }

        public override void Update(EntityManager manager, Entity entity)
        {
            AuthoritativeToggle.value = manager.HasComponent<Metadata.HasAuthority>(entity);

            var component = manager.GetComponentData<Metadata.Component>(entity);

            entityTypeField.value = component.EntityType.ToString();
        }

        protected override void WriteDebugInfo()
        {
            UnityEngine.Debug.Log("Metadata generated from 'improbable/standard_library.schema' with Component ID '53'");
        }
    }
}
