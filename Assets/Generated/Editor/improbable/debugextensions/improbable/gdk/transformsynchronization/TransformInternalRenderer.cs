// =====================================================
// DO NOT EDIT - this file is automatically regenerated.
// =====================================================

using Unity.Entities;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using Improbable.Gdk.Debug.WorkerInspector.Codegen;

namespace Improbable.Gdk.TransformSynchronization
{
    public class TransformInternalRenderer : ComponentVisualElement
    {
        public override ComponentType ComponentType { get; } = ComponentType.ReadOnly<TransformInternal.Component>();

        private readonly global::Improbable.Gdk.TransformSynchronization.FixedPointVector3Renderer locationField;
        private readonly global::Improbable.Gdk.TransformSynchronization.CompressedQuaternionRenderer rotationField;
        private readonly global::Improbable.Gdk.TransformSynchronization.FixedPointVector3Renderer velocityField;
        private readonly TextField physicsTickField;
        private readonly TextField ticksPerSecondField;

        public TransformInternalRenderer() : base()
        {
            ComponentFoldout.text = "TransformInternal";

            AuthoritativeToggle.SetEnabled(false);

            locationField = new global::Improbable.Gdk.TransformSynchronization.FixedPointVector3Renderer("Location", 0 + 1);
            ComponentFoldout.Add(locationField);

            rotationField = new global::Improbable.Gdk.TransformSynchronization.CompressedQuaternionRenderer("Rotation", 0 + 1);
            ComponentFoldout.Add(rotationField);

            velocityField = new global::Improbable.Gdk.TransformSynchronization.FixedPointVector3Renderer("Velocity", 0 + 1);
            ComponentFoldout.Add(velocityField);

            physicsTickField = new TextField("Physics Tick");
            physicsTickField.labelElement.ShiftRightMargin(0);
            physicsTickField.SetEnabled(false);
            ComponentFoldout.Add(physicsTickField);

            ticksPerSecondField = new TextField("Ticks Per Second");
            ticksPerSecondField.labelElement.ShiftRightMargin(0);
            ticksPerSecondField.SetEnabled(false);
            ComponentFoldout.Add(ticksPerSecondField);

            InjectComponentIcon("Transform Icon");
        }

        public override void Update(EntityManager manager, Entity entity)
        {
            AuthoritativeToggle.value = manager.HasComponent<TransformInternal.HasAuthority>(entity);

            var component = manager.GetComponentData<TransformInternal.Component>(entity);

            locationField.Update(component.Location);
            rotationField.Update(component.Rotation);
            velocityField.Update(component.Velocity);
            physicsTickField.value = component.PhysicsTick.ToString();
            ticksPerSecondField.value = component.TicksPerSecond.ToString();
        }

        protected override void WriteDebugInfo()
        {
            UnityEngine.Debug.Log("TransformInternal generated from 'improbable/gdk/transform_synchronization/transform_internal.schema' with Component ID '11000'");
        }
    }
}
