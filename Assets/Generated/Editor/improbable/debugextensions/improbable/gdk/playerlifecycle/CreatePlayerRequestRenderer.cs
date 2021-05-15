// =====================================================
// DO NOT EDIT - this file is automatically regenerated.
// =====================================================

using UnityEngine.UIElements;
using UnityEditor.UIElements;
using Improbable.Gdk.Debug.WorkerInspector.Codegen;

namespace Improbable.Gdk.PlayerLifecycle
{
    public class CreatePlayerRequestRenderer : SchemaTypeVisualElement<global::Improbable.Gdk.PlayerLifecycle.CreatePlayerRequest>
    {
        private readonly TextField serializedArgumentsField;

        public CreatePlayerRequestRenderer(string label, uint nest) : base(label)
        {
            serializedArgumentsField = new TextField("Serialized Arguments");
            serializedArgumentsField.labelElement.ShiftRightMargin(nest);
            serializedArgumentsField.SetEnabled(false);
            Container.Add(serializedArgumentsField);
        }

        public override void Update(global::Improbable.Gdk.PlayerLifecycle.CreatePlayerRequest data)
        {
            serializedArgumentsField.value = global::System.Text.Encoding.Default.GetString(data.SerializedArguments);
        }
    }
}
