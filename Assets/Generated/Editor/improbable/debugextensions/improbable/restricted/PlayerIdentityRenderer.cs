// =====================================================
// DO NOT EDIT - this file is automatically regenerated.
// =====================================================

using UnityEngine.UIElements;
using UnityEditor.UIElements;
using Improbable.Gdk.Debug.WorkerInspector.Codegen;

namespace Improbable.Restricted
{
    public class PlayerIdentityRenderer : SchemaTypeVisualElement<global::Improbable.Restricted.PlayerIdentity>
    {
        private readonly TextField playerIdentifierField;
        private readonly TextField providerField;
        private readonly TextField metadataField;

        public PlayerIdentityRenderer(string label, uint nest) : base(label)
        {
            playerIdentifierField = new TextField("Player Identifier");
            playerIdentifierField.labelElement.ShiftRightMargin(nest);
            playerIdentifierField.SetEnabled(false);
            Container.Add(playerIdentifierField);

            providerField = new TextField("Provider");
            providerField.labelElement.ShiftRightMargin(nest);
            providerField.SetEnabled(false);
            Container.Add(providerField);

            metadataField = new TextField("Metadata");
            metadataField.labelElement.ShiftRightMargin(nest);
            metadataField.SetEnabled(false);
            Container.Add(metadataField);
        }

        public override void Update(global::Improbable.Restricted.PlayerIdentity data)
        {
            playerIdentifierField.value = data.PlayerIdentifier.ToString();
            providerField.value = data.Provider.ToString();
            metadataField.value = global::System.Text.Encoding.Default.GetString(data.Metadata);
        }
    }
}
