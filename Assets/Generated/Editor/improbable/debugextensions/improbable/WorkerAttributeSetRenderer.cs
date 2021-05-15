// =====================================================
// DO NOT EDIT - this file is automatically regenerated.
// =====================================================

using UnityEngine.UIElements;
using UnityEditor.UIElements;
using Improbable.Gdk.Debug.WorkerInspector.Codegen;

namespace Improbable
{
    public class WorkerAttributeSetRenderer : SchemaTypeVisualElement<global::Improbable.WorkerAttributeSet>
    {
        private readonly PaginatedListView<TextField, string> attributeField;

        public WorkerAttributeSetRenderer(string label, uint nest) : base(label)
        {
            attributeField = new PaginatedListView<TextField, string>("Attribute", () => {
            var inner = new TextField("");
            inner.labelElement.ShiftRightMargin(nest + 1);
            inner.SetEnabled(false);
            return inner; }, (index, data, element) => {
            element.label = $"Item {index + 1}";
            element.value = data.ToString();
            });
            Container.Add(attributeField);
        }

        public override void Update(global::Improbable.WorkerAttributeSet data)
        {
            attributeField.Update(data.Attribute);
        }
    }
}
