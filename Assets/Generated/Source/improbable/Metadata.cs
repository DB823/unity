// =====================================================
// DO NOT EDIT - this file is automatically regenerated.
// =====================================================

using Improbable.Gdk.Core;
using Improbable.Worker.CInterop;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.Entities;

namespace Improbable
{
    public partial class Metadata
    {
        public const uint ComponentId = 53;

        public unsafe struct Component : IComponentData, ISpatialComponentData, ISnapshottable<Snapshot>
        {
            // Bit masks for tracking which component properties were changed locally and need to be synced.
            private fixed UInt32 dirtyBits[1];

            internal global::Improbable.Gdk.Core.ReferenceProvider<string>.ReferenceHandle entityTypeHandle;

            public string EntityType
            {
                get => entityTypeHandle.Get();
                set
                {
                    MarkDataDirty(0);
                    entityTypeHandle.Set(value);
                }
            }

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
                ValidateFieldIndex(propertyIndex);

                // Retrieve the dirtyBits[0-n] field that tracks this property.
                var dirtyBitsByteIndex = propertyIndex >> 5;
                return (dirtyBits[dirtyBitsByteIndex] & (0x1 << (propertyIndex & 31))) != 0x0;
            }

            // Like the IsDataDirty() method above, the propertyIndex arguments starts counting from 0.
            // This method throws an InvalidOperationException in case your component doesn't contain properties.
            public void MarkDataDirty(int propertyIndex)
            {
                ValidateFieldIndex(propertyIndex);

                // Retrieve the dirtyBits[0-n] field that tracks this property.
                var dirtyBitsByteIndex = propertyIndex >> 5;
                dirtyBits[dirtyBitsByteIndex] |= (UInt32) (0x1 << (propertyIndex & 31));
            }

            public void MarkDataClean()
            {
                dirtyBits[0] = 0x0;
            }

            [Conditional("DEBUG")]
            private void ValidateFieldIndex(int propertyIndex)
            {
                if (propertyIndex < 0 || propertyIndex >= 1)
                {
                    throw new ArgumentException("\"propertyIndex\" argument out of range. Valid range is [0, 0]. " +
                        "Unless you are using custom component replication code, this is most likely caused by a code generation bug. " +
                        "Please contact SpatialOS support if you encounter this issue.");
                }
            }

            public Snapshot ToComponentSnapshot(global::Unity.Entities.World world)
            {
                var componentDataSchema = new ComponentData(53, SchemaComponentData.Create());
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
            public uint ComponentId => 53;

            public string EntityType;

            public Snapshot(string entityType)
            {
                EntityType = entityType;
            }
        }

        public static class Serialization
        {
            public static void SerializeComponent(global::Improbable.Metadata.Component component, global::Improbable.Worker.CInterop.SchemaObject obj, global::Unity.Entities.World world)
            {
                obj.AddString(1, component.EntityType);
            }

            public static void SerializeUpdate(global::Improbable.Metadata.Component component, global::Improbable.Worker.CInterop.SchemaComponentUpdate updateObj)
            {
                var obj = updateObj.GetFields();

                if (component.IsDataDirty(0))
                {
                    obj.AddString(1, component.EntityType);
                }
            }

            public static void SerializeUpdate(global::Improbable.Metadata.Update update, global::Improbable.Worker.CInterop.SchemaComponentUpdate updateObj)
            {
                var obj = updateObj.GetFields();

                {
                    if (update.EntityType.HasValue)
                    {
                        var field = update.EntityType.Value;

                        obj.AddString(1, field);
                    }
                }
            }

            public static void SerializeSnapshot(global::Improbable.Metadata.Snapshot snapshot, global::Improbable.Worker.CInterop.SchemaObject obj)
            {
                obj.AddString(1, snapshot.EntityType);
            }

            public static global::Improbable.Metadata.Component Deserialize(global::Improbable.Worker.CInterop.SchemaObject obj, global::Unity.Entities.World world)
            {
                var component = new global::Improbable.Metadata.Component();

                component.entityTypeHandle = global::Improbable.Gdk.Core.ReferenceProvider<string>.Create();

                component.EntityType = obj.GetString(1);

                return component;
            }

            public static global::Improbable.Metadata.Update DeserializeUpdate(global::Improbable.Worker.CInterop.SchemaComponentUpdate updateObj)
            {
                var update = new global::Improbable.Metadata.Update();
                var obj = updateObj.GetFields();

                if (obj.GetStringCount(1) == 1)
                {
                    update.EntityType = obj.GetString(1);
                }

                return update;
            }

            public static global::Improbable.Metadata.Update DeserializeUpdate(global::Improbable.Worker.CInterop.SchemaComponentData data)
            {
                var update = new global::Improbable.Metadata.Update();
                var obj = data.GetFields();

                update.EntityType = obj.GetString(1);

                return update;
            }

            public static global::Improbable.Metadata.Snapshot DeserializeSnapshot(global::Improbable.Worker.CInterop.SchemaObject obj)
            {
                var component = new global::Improbable.Metadata.Snapshot();

                component.EntityType = obj.GetString(1);

                return component;
            }

            public static void ApplyUpdate(global::Improbable.Worker.CInterop.SchemaComponentUpdate updateObj, ref global::Improbable.Metadata.Component component)
            {
                var obj = updateObj.GetFields();

                if (obj.GetStringCount(1) == 1)
                {
                    component.EntityType = obj.GetString(1);
                }
            }

            public static void ApplyUpdate(global::Improbable.Worker.CInterop.SchemaComponentUpdate updateObj, ref global::Improbable.Metadata.Snapshot snapshot)
            {
                var obj = updateObj.GetFields();

                if (obj.GetStringCount(1) == 1)
                {
                    snapshot.EntityType = obj.GetString(1);
                }
            }
        }

        public struct Update : ISpatialComponentUpdate
        {
            public Option<string> EntityType;
        }

        internal class MetadataDynamic : IDynamicInvokable
        {
            public uint ComponentId => Metadata.ComponentId;

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
                    EntityType = snapshot.EntityType
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
