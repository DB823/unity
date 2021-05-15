// =====================================================
// DO NOT EDIT - this file is automatically regenerated.
// =====================================================

using Improbable.Gdk.Core;
using Improbable.Worker.CInterop;
using Unity.Collections;
using Unity.Entities;
using Unity.Profiling;

namespace Improbable.Gdk.PlayerLifecycle
{
    public partial class OwningWorker
    {
        [DisableAutoCreation, UpdateInGroup(typeof(SpatialOSSendGroup)), UpdateBefore(typeof(SpatialOSSendGroup.InternalSpatialOSSendGroup))]
        internal class ReplicationSystem : SystemBase
        {
            private NativeQueue<SerializedMessagesToSend.UpdateToSend> dirtyComponents;
            private SpatialOSSendSystem spatialOsSendSystem;

            private ProfilerMarker foreachMarker = new ProfilerMarker("OwningWorkerSerializationJob");

            protected override void OnCreate()
            {
                spatialOsSendSystem = World.GetExistingSystem<SpatialOSSendSystem>();
            }

            protected override void OnUpdate()
            {
                dirtyComponents = new NativeQueue<SerializedMessagesToSend.UpdateToSend>(Allocator.TempJob);
                var dirtyComponentsWriter = dirtyComponents.AsParallelWriter();
                var marker = foreachMarker;

                Dependency = Entities.WithName("OwningWorkerReplication")

                .WithoutBurst()

                .WithAll<HasAuthority>()
                    .WithChangeFilter<Component>()
                    .ForEach((ref Component component, in SpatialEntityId entity) =>
                    {
                        marker.Begin();
                        if (!component.IsDataDirty())
                        {
                            marker.End();
                            return;
                        }

                        // Serialize component
                        var schemaUpdate = SchemaComponentUpdate.Create();
                        Serialization.SerializeUpdate(component, schemaUpdate);

                        component.MarkDataClean();

                        // Schedule update
                        var componentUpdate = new ComponentUpdate(ComponentId, schemaUpdate);
                        var update = new SerializedMessagesToSend.UpdateToSend(componentUpdate, entity.EntityId.Id);
                        dirtyComponentsWriter.Enqueue(update);
                        marker.End();
                    })
                    .ScheduleParallel(Dependency);

                spatialOsSendSystem.AddReplicationJobProducer(Dependency, dirtyComponents);
                dirtyComponents = default;
            }
        }
    }
}
