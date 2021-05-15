// =====================================================
// DO NOT EDIT - this file is automatically regenerated.
// =====================================================

using Unity.Entities;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using Improbable.Gdk.Debug.WorkerInspector.Codegen;

namespace Improbable
{
    public class PositionRenderer : ComponentVisualElement
    {
        public override ComponentType ComponentType { get; } = ComponentType.ReadOnly<Position.Component>();

        private readonly global::Improbable.CoordinatesRenderer coordsField;

        public PositionRenderer() : base()
        {
            ComponentFoldout.text = "Position";

            AuthoritativeToggle.SetEnabled(false);

            coordsField = new global::Improbable.CoordinatesRenderer("Coords", 0 + 1);
            ComponentFoldout.Add(coordsField);

            InjectComponentIcon("Transform Icon");
        }

        public override void Update(EntityManager manager, Entity entity)
        {
            AuthoritativeToggle.value = manager.HasComponent<Position.HasAuthority>(entity);

            var component = manager.GetComponentData<Position.Component>(entity);

            coordsField.Update(component.Coords);
        }

        protected override void WriteDebugInfo()
        {
            UnityEngine.Debug.Log("Position generated from 'improbable/standard_library.schema' with Component ID '54'");
        }
    }
}
