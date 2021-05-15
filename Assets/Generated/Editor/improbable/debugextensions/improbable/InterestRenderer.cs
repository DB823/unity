// =====================================================
// DO NOT EDIT - this file is automatically regenerated.
// =====================================================

using Unity.Entities;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using Improbable.Gdk.Debug.WorkerInspector.Codegen;

namespace Improbable
{
    public class InterestRenderer : ComponentVisualElement
    {
        public override ComponentType ComponentType { get; } = ComponentType.ReadOnly<Interest.Component>();

        private readonly PaginatedMapView<TextField, uint, global::Improbable.ComponentInterestRenderer, global::Improbable.ComponentInterest> componentInterestField;

        public InterestRenderer() : base()
        {
            ComponentFoldout.text = "Interest";

            AuthoritativeToggle.SetEnabled(false);

            componentInterestField = new PaginatedMapView<TextField, uint, global::Improbable.ComponentInterestRenderer, global::Improbable.ComponentInterest>("Component Interest",
            () => {
            var inner = new TextField("Key");
            inner.labelElement.ShiftRightMargin(0 + 1);
            inner.SetEnabled(false);
            return inner; }, (data, element) => { element.value = data.ToString(); },
            () => {
            var inner = new global::Improbable.ComponentInterestRenderer("Value", 0 + 1 + 1);
            return inner; }, (data, element) => { element.Update(data); });
            ComponentFoldout.Add(componentInterestField);

            InjectComponentIcon("d_ViewToolOrbit");
        }

        public override void Update(EntityManager manager, Entity entity)
        {
            AuthoritativeToggle.value = manager.HasComponent<Interest.HasAuthority>(entity);

            var component = manager.GetComponentData<Interest.Component>(entity);

            componentInterestField.Update(component.ComponentInterest);
        }

        protected override void WriteDebugInfo()
        {
            UnityEngine.Debug.Log("Interest generated from 'improbable/standard_library.schema' with Component ID '58'");
        }
    }
}
