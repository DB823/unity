// =====================================================
// DO NOT EDIT - this file is automatically regenerated.
// =====================================================

using Improbable.Gdk.Core;
using Improbable.Worker.CInterop;
using Unity.Profiling;

namespace Improbable
{
    public partial class Persistence
    {
        public class DiffComponentDeserializer : IComponentDiffDeserializer
        {
            public uint GetComponentId()
            {
                return ComponentId;
            }

            public void AddUpdateToDiff(ComponentUpdateOp op, ViewDiff diff, uint updateId)
            {
                if (op.Update.SchemaData.Value.GetFields().GetUniqueFieldIdCount() + op.Update.SchemaData.Value.GetClearedFieldCount() > 0)
                {
                    var update = global::Improbable.Persistence.Serialization.DeserializeUpdate(op.Update.SchemaData.Value);
                    diff.AddComponentUpdate(update, op.EntityId, op.Update.ComponentId, updateId);
                }
            }

            public void AddComponentToDiff(AddComponentOp op, ViewDiff diff)
            {
                var data = Serialization.DeserializeUpdate(op.Data.SchemaData.Value);
                diff.AddComponent(data, op.EntityId, op.Data.ComponentId);
            }
        }

        public class ComponentSerializer : IComponentSerializer
        {
            private ProfilerMarker serializeMarker = new ProfilerMarker("Persistence.ComponentSerializer.Serialize");

            public uint GetComponentId()
            {
                return ComponentId;
            }

            public void Serialize(MessagesToSend messages, SerializedMessagesToSend serializedMessages)
            {
                using (serializeMarker.Auto())
                {
                    var storage = messages.GetComponentDiffStorage(ComponentId);
                }
            }
        }
    }
}
