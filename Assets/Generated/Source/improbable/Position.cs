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
    public partial class Position
    {
        public const uint ComponentId = 54;

        public unsafe struct Component : IComponentData, ISpatialComponentData, ISnapshottable<Snapshot>
        {
            // Bit masks for tracking which component properties were changed locally and need to be synced.
            private fixed UInt32 dirtyBits[1];

            private global::Improbable.Coordinates coords;

            public global::Improbable.Coordinates Coords
            {
                get => coords;
                set
                {
                    MarkDataDirty(0);
                    this.coords = value;
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
                var componentDataSchema = new ComponentData(54, SchemaComponentData.Create());
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
            public uint ComponentId => 54;

            public global::Improbable.Coordinates Coords;

            public Snapshot(global::Improbable.Coordinates coords)
            {
                Coords = coords;
            }
        }

        public static class Serialization
        {
            public static void SerializeComponent(global::Improbable.Position.Component component, global::Improbable.Worker.CInterop.SchemaObject obj, global::Unity.Entities.World world)
            {
                global::Improbable.Coordinates.Serialization.Serialize(component.Coords, obj.AddObject(1));
            }

            public static void SerializeUpdate(global::Improbable.Position.Component component, global::Improbable.Worker.CInterop.SchemaComponentUpdate updateObj)
            {
                var obj = updateObj.GetFields();

                if (component.IsDataDirty(0))
                {
                    global::Improbable.Coordinates.Serialization.Serialize(component.Coords, obj.AddObject(1));
                }
            }

            public static void SerializeUpdate(global::Improbable.Position.Update update, global::Improbable.Worker.CInterop.SchemaComponentUpdate updateObj)
            {
                var obj = updateObj.GetFields();

                {
                    if (update.Coords.HasValue)
                    {
                        var field = update.Coords.Value;

                        global::Improbable.Coordinates.Serialization.Serialize(field, obj.AddObject(1));
                    }
                }
            }

            public static void SerializeSnapshot(global::Improbable.Position.Snapshot snapshot, global::Improbable.Worker.CInterop.SchemaObject obj)
            {
                global::Improbable.Coordinates.Serialization.Serialize(snapshot.Coords, obj.AddObject(1));
            }

            public static global::Improbable.Position.Component Deserialize(global::Improbable.Worker.CInterop.SchemaObject obj, global::Unity.Entities.World world)
            {
                var component = new global::Improbable.Position.Component();

                component.Coords = global::Improbable.Coordinates.Serialization.Deserialize(obj.GetObject(1));

                return component;
            }

            public static global::Improbable.Position.Update DeserializeUpdate(global::Improbable.Worker.CInterop.SchemaComponentUpdate updateObj)
            {
                var update = new global::Improbable.Position.Update();
                var obj = updateObj.GetFields();

                if (obj.GetObjectCount(1) == 1)
                {
                    update.Coords = global::Improbable.Coordinates.Serialization.Deserialize(obj.GetObject(1));
                }

                return update;
            }

            public static global::Improbable.Position.Update DeserializeUpdate(global::Improbable.Worker.CInterop.SchemaComponentData data)
            {
                var update = new global::Improbable.Position.Update();
                var obj = data.GetFields();

                update.Coords = global::Improbable.Coordinates.Serialization.Deserialize(obj.GetObject(1));

                return update;
            }

            public static global::Improbable.Position.Snapshot DeserializeSnapshot(global::Improbable.Worker.CInterop.SchemaObject obj)
            {
                var component = new global::Improbable.Position.Snapshot();

                component.Coords = global::Improbable.Coordinates.Serialization.Deserialize(obj.GetObject(1));

                return component;
            }

            public static void ApplyUpdate(global::Improbable.Worker.CInterop.SchemaComponentUpdate updateObj, ref global::Improbable.Position.Component component)
            {
                var obj = updateObj.GetFields();

                if (obj.GetObjectCount(1) == 1)
                {
                    component.Coords = global::Improbable.Coordinates.Serialization.Deserialize(obj.GetObject(1));
                }
            }

            public static void ApplyUpdate(global::Improbable.Worker.CInterop.SchemaComponentUpdate updateObj, ref global::Improbable.Position.Snapshot snapshot)
            {
                var obj = updateObj.GetFields();

                if (obj.GetObjectCount(1) == 1)
                {
                    snapshot.Coords = global::Improbable.Coordinates.Serialization.Deserialize(obj.GetObject(1));
                }
            }
        }

        public struct Update : ISpatialComponentUpdate
        {
            public Option<global::Improbable.Coordinates> Coords;
        }

        internal class PositionDynamic : IDynamicInvokable
        {
            public uint ComponentId => Position.ComponentId;

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
                    Coords = snapshot.Coords
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
