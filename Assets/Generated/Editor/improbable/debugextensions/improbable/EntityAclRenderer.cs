// =====================================================
// DO NOT EDIT - this file is automatically regenerated.
// =====================================================

using Unity.Entities;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using Improbable.Gdk.Debug.WorkerInspector.Codegen;

namespace Improbable
{
    public class EntityAclRenderer : ComponentVisualElement
    {
        public override ComponentType ComponentType { get; } = ComponentType.ReadOnly<EntityAcl.Component>();

        private readonly global::Improbable.WorkerRequirementSetRenderer readAclField;
        private readonly PaginatedMapView<TextField, uint, global::Improbable.WorkerRequirementSetRenderer, global::Improbable.WorkerRequirementSet> componentWriteAclField;

        public EntityAclRenderer() : base()
        {
            ComponentFoldout.text = "EntityAcl";

            AuthoritativeToggle.SetEnabled(false);

            readAclField = new global::Improbable.WorkerRequirementSetRenderer("Read Acl", 0 + 1);
            ComponentFoldout.Add(readAclField);

            componentWriteAclField = new PaginatedMapView<TextField, uint, global::Improbable.WorkerRequirementSetRenderer, global::Improbable.WorkerRequirementSet>("Component Write Acl",
            () => {
            var inner = new TextField("Key");
            inner.labelElement.ShiftRightMargin(0 + 1);
            inner.SetEnabled(false);
            return inner; }, (data, element) => { element.value = data.ToString(); },
            () => {
            var inner = new global::Improbable.WorkerRequirementSetRenderer("Value", 0 + 1 + 1);
            return inner; }, (data, element) => { element.Update(data); });
            ComponentFoldout.Add(componentWriteAclField);

            InjectComponentIcon("d_TextAsset Icon");
        }

        public override void Update(EntityManager manager, Entity entity)
        {
            AuthoritativeToggle.value = manager.HasComponent<EntityAcl.HasAuthority>(entity);

            var component = manager.GetComponentData<EntityAcl.Component>(entity);

            readAclField.Update(component.ReadAcl);
            componentWriteAclField.Update(component.ComponentWriteAcl);
        }

        protected override void WriteDebugInfo()
        {
            UnityEngine.Debug.Log("EntityAcl generated from 'improbable/standard_library.schema' with Component ID '50'");
        }
    }
}
