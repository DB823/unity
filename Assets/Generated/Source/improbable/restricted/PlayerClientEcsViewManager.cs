// =====================================================
// DO NOT EDIT - this file is automatically regenerated.
// =====================================================

using System;
using Unity.Entities;
using Improbable.Worker.CInterop;
using Improbable.Gdk.Core;
using Unity.Collections;

namespace Improbable.Restricted
{
    public partial class PlayerClient
    {
        public class EcsViewManager : IEcsViewManager
        {
            private WorkerSystem workerSystem;
            private SpatialOSReceiveSystem spatialOSReceiveSystem;
            private EntityManager entityManager;

            private readonly ComponentType[] initialComponents = new ComponentType[]
            {
                ComponentType.ReadWrite<global::Improbable.Restricted.PlayerClient.Component>(),
                ComponentType.ReadOnly<global::Improbable.Restricted.PlayerClient.HasAuthority>(),
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
                var query = entityManager.CreateEntityQuery(typeof(global::Improbable.Restricted.PlayerClient.Component));
                var componentDataArray = query.ToComponentDataArray<global::Improbable.Restricted.PlayerClient.Component>(Allocator.TempJob);

                foreach (var component in componentDataArray)
                {
                    component.playerIdentityHandle.Dispose();
                }

                componentDataArray.Dispose();
            }

            private void AddComponent(EntityId entityId)
            {
                var entity = workerSystem.GetEntity(entityId);
                var component = new global::Improbable.Restricted.PlayerClient.Component();

                component.playerIdentityHandle = global::Improbable.Gdk.Core.ReferenceProvider<global::Improbable.Restricted.PlayerIdentity>.Create();

                component.MarkDataClean();
                entityManager.AddComponentData(entity, component);
            }

            private void RemoveComponent(EntityId entityId)
            {
                var entity = workerSystem.GetEntity(entityId);
                entityManager.RemoveComponent<global::Improbable.Restricted.PlayerClient.HasAuthority>(entity);

                var data = entityManager.GetComponentData<global::Improbable.Restricted.PlayerClient.Component>(entity);

                data.playerIdentityHandle.Dispose();

                entityManager.RemoveComponent<global::Improbable.Restricted.PlayerClient.Component>(entity);
            }

            private void ApplyUpdate(in ComponentUpdateReceived<Update> update, ComponentDataFromEntity<Component> dataFromEntity)
            {
                var entity = workerSystem.GetEntity(update.EntityId);
                if (!dataFromEntity.HasComponent(entity))
                {
                    return;
                }

                var data = dataFromEntity[entity];

                if (update.Update.PlayerIdentity.HasValue)
                {
                    data.PlayerIdentity = update.Update.PlayerIdentity.Value;
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
                        entityManager.RemoveComponent<global::Improbable.Restricted.PlayerClient.HasAuthority>(entity);
                        break;
                    }
                    case Authority.Authoritative:
                    {
                        var entity = workerSystem.GetEntity(entityId);
                        entityManager.AddComponent<global::Improbable.Restricted.PlayerClient.HasAuthority>(entity);
                        break;
                    }
                    case Authority.AuthorityLossImminent:
                        break;
                }
            }
        }
    }
}
