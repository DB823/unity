// =====================================================
// DO NOT EDIT - this file is automatically regenerated.
// =====================================================

using Unity.Entities;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using Improbable.Gdk.Debug.WorkerInspector.Codegen;

namespace Improbable.Restricted
{
    public class WorkerRenderer : ComponentVisualElement
    {
        public override ComponentType ComponentType { get; } = ComponentType.ReadOnly<Worker.Component>();

        private readonly TextField workerIdField;
        private readonly TextField workerTypeField;
        private readonly global::Improbable.Restricted.ConnectionRenderer connectionField;

        public WorkerRenderer() : base()
        {
            ComponentFoldout.text = "Worker";

            AuthoritativeToggle.SetEnabled(false);

            workerIdField = new TextField("Worker Id");
            workerIdField.labelElement.ShiftRightMargin(0);
            workerIdField.SetEnabled(false);
            ComponentFoldout.Add(workerIdField);

            workerTypeField = new TextField("Worker Type");
            workerTypeField.labelElement.ShiftRightMargin(0);
            workerTypeField.SetEnabled(false);
            ComponentFoldout.Add(workerTypeField);

            connectionField = new global::Improbable.Restricted.ConnectionRenderer("Connection", 0 + 1);
            ComponentFoldout.Add(connectionField);

            InjectComponentIcon("d_TextAsset Icon");
        }

        public override void Update(EntityManager manager, Entity entity)
        {
            AuthoritativeToggle.value = manager.HasComponent<Worker.HasAuthority>(entity);

            var component = manager.GetComponentData<Worker.Component>(entity);

            workerIdField.value = component.WorkerId.ToString();
            workerTypeField.value = component.WorkerType.ToString();
            connectionField.Update(component.Connection);
        }

        protected override void WriteDebugInfo()
        {
            UnityEngine.Debug.Log("Worker generated from 'improbable/restricted/system_components.schema' with Component ID '60'");
        }
    }
}
