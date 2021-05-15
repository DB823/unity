// =====================================================
// DO NOT EDIT - this file is automatically regenerated.
// =====================================================

using UnityEngine.UIElements;
using UnityEditor.UIElements;
using Improbable.Gdk.Debug.WorkerInspector.Codegen;

namespace Improbable.Gdk.PlayerLifecycle
{
    public class CreatePlayerResponseRenderer : SchemaTypeVisualElement<global::Improbable.Gdk.PlayerLifecycle.CreatePlayerResponse>
    {
        private readonly TextField createdEntityIdField;

        public CreatePlayerResponseRenderer(string label, uint nest) : base(label)
        {
            createdEntityIdField = new TextField("Created Entity Id");
            createdEntityIdField.labelElement.ShiftRightMargin(nest);
            createdEntityIdField.SetEnabled(false);
            Container.Add(createdEntityIdField);
        }

        public override void Update(global::Improbable.Gdk.PlayerLifecycle.CreatePlayerResponse data)
        {
            createdEntityIdField.value = data.CreatedEntityId.ToString();
        }
    }
}
