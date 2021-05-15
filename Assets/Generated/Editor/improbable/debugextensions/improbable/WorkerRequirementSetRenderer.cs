// =====================================================
// DO NOT EDIT - this file is automatically regenerated.
// =====================================================

using UnityEngine.UIElements;
using UnityEditor.UIElements;
using Improbable.Gdk.Debug.WorkerInspector.Codegen;

namespace Improbable
{
    public class WorkerRequirementSetRenderer : SchemaTypeVisualElement<global::Improbable.WorkerRequirementSet>
    {
        private readonly PaginatedListView<global::Improbable.WorkerAttributeSetRenderer, global::Improbable.WorkerAttributeSet> attributeSetField;

        public WorkerRequirementSetRenderer(string label, uint nest) : base(label)
        {
            attributeSetField = new PaginatedListView<global::Improbable.WorkerAttributeSetRenderer, global::Improbable.WorkerAttributeSet>("Attribute Set", () => {
            var inner = new global::Improbable.WorkerAttributeSetRenderer("", nest + 1 + 1);
            return inner; }, (index, data, element) => {
            element.Label = $"Item {index + 1}";
            element.Update(data);
            });
            Container.Add(attributeSetField);
        }

        public override void Update(global::Improbable.WorkerRequirementSet data)
        {
            attributeSetField.Update(data.AttributeSet);
        }
    }
}
