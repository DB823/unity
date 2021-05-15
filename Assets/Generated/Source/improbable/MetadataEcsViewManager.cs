// =====================================================
// DO NOT EDIT - this file is automatically regenerated.
// =====================================================

using System;
using Unity.Entities;
using Improbable.Worker.CInterop;
using Improbable.Gdk.Core;
using Unity.Collections;

namespace Improbable
{
    public partial class Metadata
    {
        public class EcsViewManager : IEcsViewManager
        {
            private WorkerSystem workerSystem;
            private SpatialOSReceiveSystem spatialOSReceiveSystem;
            private EntityManager entityManager;

            private readonly ComponentType[] initialComponents = new ComponentType[]
            {
                ComponentType.ReadWrite<global::Improbable.Metadata.Component>(),
                ComponentType.ReadOnly<global::Improbable.Metadata.HasAuthority>(),
            };

            public uint GetComponentId()
            {
                return ComponentId;
            }

            public ComponentType[] GetInitialComponents()
            {
                return initialComponents;
            }

            public void ApplyDiff(ViewDiff diff)
            {
                var diffStorage = (DiffComponentStorage) diff.GetComponentDiffStorage(ComponentId);

                foreach (var entityId in diffStorage.GetComponentsAdded())
                {
                    AddComponent(entityId);
                }

                var updates = diffStorage.GetUpdates();
                var dataFromEntity = spatialOSReceiveSystem.GetComponentDataFromEntity<Component>();
                for (int i = 0; i < updates.Count; ++i)
                {
                    ApplyUpdate(in updates[i], dataFromEntity);
                }

                var authChanges = diffStorage.GetAuthorityChanges();
                for (int i = 0; i < authChanges.Count; ++i)
                {
                    ref readonly var change = ref authChanges[i];
                    SetAuthority(change.EntityId, change.Authority);
                }

                foreach (var entityId in diffStorage.GetComponentsRemoved())
                {
                    RemoveComponent(entityId);
                }
            }

            public void Init(World world)
            {
                entityManager = world.EntityManager;

                workerSystem = world.GetExistingSystem<WorkerSystem>();

                if (workerSystem == null)
                {
                    throw new ArgumentException("World instance is not running a valid SpatialOS worker");
                }

                spatialOSReceiveSystem = world.GetExistingSystem<SpatialOSReceiveSystem>();

                if (spatialOSReceiveSystem == null)
                {
                    throw new ArgumentException("Could not find SpatialOS Receive System in the current world instance");
                }
            }

            public void Clean()
            {
                var query = entityManager.CreateEntityQuery(typeof(global::Improbable.Metadata.Component));
                var componentDataArray = query.ToComponentDataArray<global::Improbable.Metadata.Component>(Allocator.TempJob);

                foreach (var component in componentDataArray)
                {
                    component.entityTypeHandle.Dispose();
                }

                componentDataArray.Dispose();
            }

            private void AddComponent(EntityId entityId)
            {
                var entity = workerSystem.GetEntity(entityId);
                var component = new global::Improbable.Metadata.Component();

                component.entityTypeHandle = global::Improbable.Gdk.Core.ReferenceProvider<string>.Create();

                component.MarkDataClean();
                entityManager.AddComponentData(entity, component);
            }

            private void RemoveComponent(EntityId entityId)
            {
                var entity = workerSystem.GetEntity(entityId);
                entityManager.RemoveComponent<global::Improbable.Metadata.HasAuthority>(entity);

                var data = entityManager.GetComponentData<global::Improbable.Metadata.Component>(entity);

                data.entityTypeHandle.Dispose();

                entityManager.RemoveComponent<global::Improbable.Metadata.Component>(entity);
            }

            private void ApplyUpdate(in ComponentUpdateReceived<Update> update, ComponentDataFromEntity<Component> dataFromEntity)
            {
                var entity = workerSystem.GetEntity(update.EntityId);
                if (!dataFromEntity.HasComponent(entity))
                {
                    return;
                }

                var data = dataFromEntity[entity];

                if (update.Update.EntityType.HasValue)
                {
                    data.EntityType = update.Update.EntityType.Value;
                }

                data.MarkDataClean();
                dataFromEntity[entity] = data;
            }

            private void SetAuthority(EntityId entityId, Authority authority)
            {
                switch (authority)
                {
                    case Authority.NotAuthoritative:
                    {
                        var entity = workerSystem.GetEntity(entityId);
                        entityManager.RemoveComponent<global::Improbable.Metadata.HasAuthority>(entity);
                        break;
                    }
                    case Authority.Authoritative:
                    {
                        var entity = workerSystem.GetEntity(entityId);
                        entityManager.AddComponent<global::Improbable.Metadata.HasAuthority>(entity);
                        break;
                    }
                    case Authority.AuthorityLossImminent:
                        break;
                }
            }
        }
    }
}
