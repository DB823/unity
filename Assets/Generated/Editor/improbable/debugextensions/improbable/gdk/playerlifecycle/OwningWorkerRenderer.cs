// =====================================================
// DO NOT EDIT - this file is automatically regenerated.
// =====================================================

using Unity.Entities;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using Improbable.Gdk.Debug.WorkerInspector.Codegen;

namespace Improbable.Gdk.PlayerLifecycle
{
    public class OwningWorkerRenderer : ComponentVisualElement
    {
        public override ComponentType ComponentType { get; } = ComponentType.ReadOnly<OwningWorker.Component>();

        private readonly TextField workerIdField;

        public OwningWorkerRenderer() : base()
        {
            ComponentFoldout.text = "OwningWorker";

            AuthoritativeToggle.SetEnabled(false);

            workerIdField = new TextField("Worker Id");
            workerIdField.labelElement.ShiftRightMargin(0);
            workerIdField.SetEnabled(false);
            ComponentFoldout.Add(workerIdField);

            InjectComponentIcon("d_TextAsset Icon");
        }

        public override void Update(EntityManager manager, Entity entity)
        {
            AuthoritativeToggle.value = manager.HasComponent<OwningWorker.HasAuthority>(entity);

            var component = manager.GetComponentData<OwningWorker.Component>(entity);

            workerIdField.value = component.WorkerId.ToString();
        }

        protected override void WriteDebugInfo()
        {
            UnityEngine.Debug.Log("OwningWorker generated from 'improbable/gdk/player_lifecycle/owning_worker.schema' with Component ID '13003'");
        }
    }
}
