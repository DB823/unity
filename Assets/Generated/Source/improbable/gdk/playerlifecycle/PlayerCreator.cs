// =====================================================
// DO NOT EDIT - this file is automatically regenerated.
// =====================================================

using Improbable.Gdk.Core;
using Improbable.Worker.CInterop;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.Entities;

namespace Improbable.Gdk.PlayerLifecycle
{
    public partial class PlayerCreator
    {
        public const uint ComponentId = 13000;

        public unsafe struct Component : IComponentData, ISpatialComponentData, ISnapshottable<Snapshot>
        {
            // Bit masks for tracking which component properties were changed locally and need to be synced.
            private fixed UInt32 dirtyBits[1];

            public bool IsDataDirty()
            {
                var isDataDirty = false;

                isDataDirty |= (dirtyBits[0] != 0x0);

                return isDataDirty;
            }

            /*
            The propertyIndex argument counts up from 0 in the order defined in your schema component.
            It is not the schema field number itself. For example:
            component MyComponent
            {
                id = 1337;
                bool val_a = 1;
                bool val_b = 3;
            }
            In that case, val_a corresponds to propertyIndex 0 and val_b corresponds to propertyIndex 1 in this method.
            This method throws an InvalidOperationException in case your component doesn't contain properties.
            */

            public bool IsDataDirty(int propertyIndex)
            {
                throw new InvalidOperationException("IsDataDirty(int propertyIndex) may not be called on components with no properties.");
            }

            // Like the IsDataDirty() method above, the propertyIndex arguments starts counting from 0.
            // This method throws an InvalidOperationException in case your component doesn't contain properties.
            public void MarkDataDirty(int propertyIndex)
            {
                throw new InvalidOperationException("MarkDataDirty(int propertyIndex) may not be called on components with no properties.");
            }

            public void MarkDataClean()
            {
                dirtyBits[0] = 0x0;
            }

            [Conditional("DEBUG")]
            private void ValidateFieldIndex(int propertyIndex)
            {
                if (propertyIndex < 0 || propertyIndex >= 0)
                {
                    throw new ArgumentException("\"propertyIndex\" argument out of range. Valid range is [0, -1]. " +
                        "Unless you are using custom component replication code, this is most likely caused by a code generation bug. " +
                        "Please contact SpatialOS support if you encounter this issue.");
                }
            }

            public Snapshot ToComponentSnapshot(global::Unity.Entities.World world)
            {
                var componentDataSchema = new ComponentData(13000, SchemaComponentData.Create());
                Serialization.SerializeComponent(this, componentDataSchema.SchemaData.Value.GetFields(), world);
                var snapshot = Serialization.DeserializeSnapshot(componentDataSchema.SchemaData.Value.GetFields());

                componentDataSchema.SchemaData?.Destroy();
                componentDataSchema.SchemaData = null;

                return snapshot;
            }
        }

        public struct HasAuthority : IComponentData
        {
        }

        [global::System.Serializable]
        public struct Snapshot : ISpatialComponentSnapshot
        {
            public uint ComponentId => 13000;
        }

        public static class Serialization
        {
            public static void SerializeComponent(global::Improbable.Gdk.PlayerLifecycle.PlayerCreator.Component component, global::Improbable.Worker.CInterop.SchemaObject obj, global::Unity.Entities.World world)
            {
            }

            public static void SerializeUpdate(global::Improbable.Gdk.PlayerLifecycle.PlayerCreator.Component component, global::Improbable.Worker.CInterop.SchemaComponentUpdate updateObj)
            {
                var obj = updateObj.GetFields();
            }

            public static void SerializeUpdate(global::Improbable.Gdk.PlayerLifecycle.PlayerCreator.Update update, global::Improbable.Worker.CInterop.SchemaComponentUpdate updateObj)
            {
                var obj = updateObj.GetFields();
            }

            public static void SerializeSnapshot(global::Improbable.Gdk.PlayerLifecycle.PlayerCreator.Snapshot snapshot, global::Improbable.Worker.CInterop.SchemaObject obj)
            {
            }

            public static global::Improbable.Gdk.PlayerLifecycle.PlayerCreator.Component Deserialize(global::Improbable.Worker.CInterop.SchemaObject obj, global::Unity.Entities.World world)
            {
                var component = new global::Improbable.Gdk.PlayerLifecycle.PlayerCreator.Component();

                return component;
            }

            public static global::Improbable.Gdk.PlayerLifecycle.PlayerCreator.Update DeserializeUpdate(global::Improbable.Worker.CInterop.SchemaComponentUpdate updateObj)
            {
                var update = new global::Improbable.Gdk.PlayerLifecycle.PlayerCreator.Update();
                var obj = updateObj.GetFields();

                return update;
            }

            public static global::Improbable.Gdk.PlayerLifecycle.PlayerCreator.Update DeserializeUpdate(global::Improbable.Worker.CInterop.SchemaComponentData data)
            {
                var update = new global::Improbable.Gdk.PlayerLifecycle.PlayerCreator.Update();
                var obj = data.GetFields();

                return update;
            }

            public static global::Improbable.Gdk.PlayerLifecycle.PlayerCreator.Snapshot DeserializeSnapshot(global::Improbable.Worker.CInterop.SchemaObject obj)
            {
                var component = new global::Improbable.Gdk.PlayerLifecycle.PlayerCreator.Snapshot();

                return component;
            }

            public static void ApplyUpdate(global::Improbable.Worker.CInterop.SchemaComponentUpdate updateObj, ref global::Improbable.Gdk.PlayerLifecycle.PlayerCreator.Component component)
            {
                var obj = updateObj.GetFields();
            }

            public static void ApplyUpdate(global::Improbable.Worker.CInterop.SchemaComponentUpdate updateObj, ref global::Improbable.Gdk.PlayerLifecycle.PlayerCreator.Snapshot snapshot)
            {
                var obj = updateObj.GetFields();
            }
        }

        public struct Update : ISpatialComponentUpdate
        {
        }

        internal class PlayerCreatorDynamic : IDynamicInvokable
        {
            public uint ComponentId => PlayerCreator.ComponentId;

            internal static Dynamic.VTable<Update, Snapshot> VTable = new Dynamic.VTable<Update, Snapshot>
            {
                DeserializeSnapshot = DeserializeSnapshot,
                SerializeSnapshot = SerializeSnapshot,
                DeserializeSnapshotRaw = Serialization.DeserializeSnapshot,
                SerializeSnapshotRaw = Serialization.SerializeSnapshot,
                ConvertSnapshotToUpdate = SnapshotToUpdate
            };

            private static Snapshot DeserializeSnapshot(ComponentData snapshot)
            {
                var schemaDataOpt = snapshot.SchemaData;
                if (!schemaDataOpt.HasValue)
                {
                    throw new ArgumentException($"Can not deserialize an empty {nameof(ComponentData)}");
                }

                return Serialization.DeserializeSnapshot(schemaDataOpt.Value.GetFields());
            }

            private static void SerializeSnapshot(Snapshot snapshot, ComponentData data)
            {
                var schemaDataOpt = data.SchemaData;
                if (!schemaDataOpt.HasValue)
                {
                    throw new ArgumentException($"Can not serialise an empty {nameof(ComponentData)}");
                }

                Serialization.SerializeSnapshot(snapshot, data.SchemaData.Value.GetFields());
            }

            private static Update SnapshotToUpdate(in Snapshot snapshot)
            {
                var update = new Update
                {
                };

                return update;
            }

            public void InvokeHandler(Dynamic.IHandler handler)
            {
                handler.Accept<Update, Snapshot>(ComponentId, VTable);
            }
        }
    }
}
