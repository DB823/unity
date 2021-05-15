// =====================================================
// DO NOT EDIT - this file is automatically regenerated.
// =====================================================

using Improbable.Gdk.Core;
using Improbable.Worker.CInterop;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.Entities;

namespace Improbable.Gdk.TransformSynchronization
{
    public partial class TransformInternal
    {
        public const uint ComponentId = 11000;

        public unsafe struct Component : IComponentData, ISpatialComponentData, ISnapshottable<Snapshot>
        {
            // Bit masks for tracking which component properties were changed locally and need to be synced.
            private fixed UInt32 dirtyBits[1];

            private global::Improbable.Gdk.TransformSynchronization.FixedPointVector3 location;

            public global::Improbable.Gdk.TransformSynchronization.FixedPointVector3 Location
            {
                get => location;
                set
                {
                    MarkDataDirty(0);
                    this.location = value;
                }
            }

            private global::Improbable.Gdk.TransformSynchronization.CompressedQuaternion rotation;

            public global::Improbable.Gdk.TransformSynchronization.CompressedQuaternion Rotation
            {
                get => rotation;
                set
                {
                    MarkDataDirty(1);
                    this.rotation = value;
                }
            }

            private global::Improbable.Gdk.TransformSynchronization.FixedPointVector3 velocity;

            public global::Improbable.Gdk.TransformSynchronization.FixedPointVector3 Velocity
            {
                get => velocity;
                set
                {
                    MarkDataDirty(2);
                    this.velocity = value;
                }
            }

            private uint physicsTick;

            public uint PhysicsTick
            {
                get => physicsTick;
                set
                {
                    MarkDataDirty(3);
                    this.physicsTick = value;
                }
            }

            private float ticksPerSecond;

            public float TicksPerSecond
            {
                get => ticksPerSecond;
                set
                {
                    MarkDataDirty(4);
                    this.ticksPerSecond = value;
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
                if (propertyIndex < 0 || propertyIndex >= 5)
                {
                    throw new ArgumentException("\"propertyIndex\" argument out of range. Valid range is [0, 4]. " +
                        "Unless you are using custom component replication code, this is most likely caused by a code generation bug. " +
                        "Please contact SpatialOS support if you encounter this issue.");
                }
            }

            public Snapshot ToComponentSnapshot(global::Unity.Entities.World world)
            {
                var componentDataSchema = new ComponentData(11000, SchemaComponentData.Create());
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
            public uint ComponentId => 11000;

            public global::Improbable.Gdk.TransformSynchronization.FixedPointVector3 Location;
            public global::Improbable.Gdk.TransformSynchronization.CompressedQuaternion Rotation;
            public global::Improbable.Gdk.TransformSynchronization.FixedPointVector3 Velocity;
            public uint PhysicsTick;
            public float TicksPerSecond;

            public Snapshot(global::Improbable.Gdk.TransformSynchronization.FixedPointVector3 location, global::Improbable.Gdk.TransformSynchronization.CompressedQuaternion rotation, global::Improbable.Gdk.TransformSynchronization.FixedPointVector3 velocity, uint physicsTick, float ticksPerSecond)
            {
                Location = location;
                Rotation = rotation;
                Velocity = velocity;
                PhysicsTick = physicsTick;
                TicksPerSecond = ticksPerSecond;
            }
        }

        public static class Serialization
        {
            public static void SerializeComponent(global::Improbable.Gdk.TransformSynchronization.TransformInternal.Component component, global::Improbable.Worker.CInterop.SchemaObject obj, global::Unity.Entities.World world)
            {
                global::Improbable.Gdk.TransformSynchronization.FixedPointVector3.Serialization.Serialize(component.Location, obj.AddObject(1));

                global::Improbable.Gdk.TransformSynchronization.CompressedQuaternion.Serialization.Serialize(component.Rotation, obj.AddObject(2));

                global::Improbable.Gdk.TransformSynchronization.FixedPointVector3.Serialization.Serialize(component.Velocity, obj.AddObject(3));

                obj.AddUint32(4, component.PhysicsTick);

                obj.AddFloat(5, component.TicksPerSecond);
            }

            public static void SerializeUpdate(global::Improbable.Gdk.TransformSynchronization.TransformInternal.Component component, global::Improbable.Worker.CInterop.SchemaComponentUpdate updateObj)
            {
                var obj = updateObj.GetFields();

                if (component.IsDataDirty(0))
                {
                    global::Improbable.Gdk.TransformSynchronization.FixedPointVector3.Serialization.Serialize(component.Location, obj.AddObject(1));
                }

                if (component.IsDataDirty(1))
                {
                    global::Improbable.Gdk.TransformSynchronization.CompressedQuaternion.Serialization.Serialize(component.Rotation, obj.AddObject(2));
                }

                if (component.IsDataDirty(2))
                {
                    global::Improbable.Gdk.TransformSynchronization.FixedPointVector3.Serialization.Serialize(component.Velocity, obj.AddObject(3));
                }

                if (component.IsDataDirty(3))
                {
                    obj.AddUint32(4, component.PhysicsTick);
                }

                if (component.IsDataDirty(4))
                {
                    obj.AddFloat(5, component.TicksPerSecond);
                }
            }

            public static void SerializeUpdate(global::Improbable.Gdk.TransformSynchronization.TransformInternal.Update update, global::Improbable.Worker.CInterop.SchemaComponentUpdate updateObj)
            {
                var obj = updateObj.GetFields();

                {
                    if (update.Location.HasValue)
                    {
                        var field = update.Location.Value;

                        global::Improbable.Gdk.TransformSynchronization.FixedPointVector3.Serialization.Serialize(field, obj.AddObject(1));
                    }
                }

                {
                    if (update.Rotation.HasValue)
                    {
                        var field = update.Rotation.Value;

                        global::Improbable.Gdk.TransformSynchronization.CompressedQuaternion.Serialization.Serialize(field, obj.AddObject(2));
                    }
                }

                {
                    if (update.Velocity.HasValue)
                    {
                        var field = update.Velocity.Value;

                        global::Improbable.Gdk.TransformSynchronization.FixedPointVector3.Serialization.Serialize(field, obj.AddObject(3));
                    }
                }

                {
                    if (update.PhysicsTick.HasValue)
                    {
                        var field = update.PhysicsTick.Value;

                        obj.AddUint32(4, field);
                    }
                }

                {
                    if (update.TicksPerSecond.HasValue)
                    {
                        var field = update.TicksPerSecond.Value;

                        obj.AddFloat(5, field);
                    }
                }
            }

            public static void SerializeSnapshot(global::Improbable.Gdk.TransformSynchronization.TransformInternal.Snapshot snapshot, global::Improbable.Worker.CInterop.SchemaObject obj)
            {
                global::Improbable.Gdk.TransformSynchronization.FixedPointVector3.Serialization.Serialize(snapshot.Location, obj.AddObject(1));

                global::Improbable.Gdk.TransformSynchronization.CompressedQuaternion.Serialization.Serialize(snapshot.Rotation, obj.AddObject(2));

                global::Improbable.Gdk.TransformSynchronization.FixedPointVector3.Serialization.Serialize(snapshot.Velocity, obj.AddObject(3));

                obj.AddUint32(4, snapshot.PhysicsTick);

                obj.AddFloat(5, snapshot.TicksPerSecond);
            }

            public static global::Improbable.Gdk.TransformSynchronization.TransformInternal.Component Deserialize(global::Improbable.Worker.CInterop.SchemaObject obj, global::Unity.Entities.World world)
            {
                var component = new global::Improbable.Gdk.TransformSynchronization.TransformInternal.Component();

                component.Location = global::Improbable.Gdk.TransformSynchronization.FixedPointVector3.Serialization.Deserialize(obj.GetObject(1));

                component.Rotation = global::Improbable.Gdk.TransformSynchronization.CompressedQuaternion.Serialization.Deserialize(obj.GetObject(2));

                component.Velocity = global::Improbable.Gdk.TransformSynchronization.FixedPointVector3.Serialization.Deserialize(obj.GetObject(3));

                component.PhysicsTick = obj.GetUint32(4);

                component.TicksPerSecond = obj.GetFloat(5);

                return component;
            }

            public static global::Improbable.Gdk.TransformSynchronization.TransformInternal.Update DeserializeUpdate(global::Improbable.Worker.CInterop.SchemaComponentUpdate updateObj)
            {
                var update = new global::Improbable.Gdk.TransformSynchronization.TransformInternal.Update();
                var obj = updateObj.GetFields();

                if (obj.GetObjectCount(1) == 1)
                {
                    update.Location = global::Improbable.Gdk.TransformSynchronization.FixedPointVector3.Serialization.Deserialize(obj.GetObject(1));
                }

                if (obj.GetObjectCount(2) == 1)
                {
                    update.Rotation = global::Improbable.Gdk.TransformSynchronization.CompressedQuaternion.Serialization.Deserialize(obj.GetObject(2));
                }

                if (obj.GetObjectCount(3) == 1)
                {
                    update.Velocity = global::Improbable.Gdk.TransformSynchronization.FixedPointVector3.Serialization.Deserialize(obj.GetObject(3));
                }

                if (obj.GetUint32Count(4) == 1)
                {
                    update.PhysicsTick = obj.GetUint32(4);
                }

                if (obj.GetFloatCount(5) == 1)
                {
                    update.TicksPerSecond = obj.GetFloat(5);
                }

                return update;
            }

            public static global::Improbable.Gdk.TransformSynchronization.TransformInternal.Update DeserializeUpdate(global::Improbable.Worker.CInterop.SchemaComponentData data)
            {
                var update = new global::Improbable.Gdk.TransformSynchronization.TransformInternal.Update();
                var obj = data.GetFields();

                update.Location = global::Improbable.Gdk.TransformSynchronization.FixedPointVector3.Serialization.Deserialize(obj.GetObject(1));

                update.Rotation = global::Improbable.Gdk.TransformSynchronization.CompressedQuaternion.Serialization.Deserialize(obj.GetObject(2));

                update.Velocity = global::Improbable.Gdk.TransformSynchronization.FixedPointVector3.Serialization.Deserialize(obj.GetObject(3));

                update.PhysicsTick = obj.GetUint32(4);

                update.TicksPerSecond = obj.GetFloat(5);

                return update;
            }

            public static global::Improbable.Gdk.TransformSynchronization.TransformInternal.Snapshot DeserializeSnapshot(global::Improbable.Worker.CInterop.SchemaObject obj)
            {
                var component = new global::Improbable.Gdk.TransformSynchronization.TransformInternal.Snapshot();

                component.Location = global::Improbable.Gdk.TransformSynchronization.FixedPointVector3.Serialization.Deserialize(obj.GetObject(1));

                component.Rotation = global::Improbable.Gdk.TransformSynchronization.CompressedQuaternion.Serialization.Deserialize(obj.GetObject(2));

                component.Velocity = global::Improbable.Gdk.TransformSynchronization.FixedPointVector3.Serialization.Deserialize(obj.GetObject(3));

                component.PhysicsTick = obj.GetUint32(4);

                component.TicksPerSecond = obj.GetFloat(5);

                return component;
            }

            public static void ApplyUpdate(global::Improbable.Worker.CInterop.SchemaComponentUpdate updateObj, ref global::Improbable.Gdk.TransformSynchronization.TransformInternal.Component component)
            {
                var obj = updateObj.GetFields();

                if (obj.GetObjectCount(1) == 1)
                {
                    component.Location = global::Improbable.Gdk.TransformSynchronization.FixedPointVector3.Serialization.Deserialize(obj.GetObject(1));
                }

                if (obj.GetObjectCount(2) == 1)
                {
                    component.Rotation = global::Improbable.Gdk.TransformSynchronization.CompressedQuaternion.Serialization.Deserialize(obj.GetObject(2));
                }

                if (obj.GetObjectCount(3) == 1)
                {
                    component.Velocity = global::Improbable.Gdk.TransformSynchronization.FixedPointVector3.Serialization.Deserialize(obj.GetObject(3));
                }

                if (obj.GetUint32Count(4) == 1)
                {
                    component.PhysicsTick = obj.GetUint32(4);
                }

                if (obj.GetFloatCount(5) == 1)
                {
                    component.TicksPerSecond = obj.GetFloat(5);
                }
            }

            public static void ApplyUpdate(global::Improbable.Worker.CInterop.SchemaComponentUpdate updateObj, ref global::Improbable.Gdk.TransformSynchronization.TransformInternal.Snapshot snapshot)
            {
                var obj = updateObj.GetFields();

                if (obj.GetObjectCount(1) == 1)
                {
                    snapshot.Location = global::Improbable.Gdk.TransformSynchronization.FixedPointVector3.Serialization.Deserialize(obj.GetObject(1));
                }

                if (obj.GetObjectCount(2) == 1)
                {
                    snapshot.Rotation = global::Improbable.Gdk.TransformSynchronization.CompressedQuaternion.Serialization.Deserialize(obj.GetObject(2));
                }

                if (obj.GetObjectCount(3) == 1)
                {
                    snapshot.Velocity = global::Improbable.Gdk.TransformSynchronization.FixedPointVector3.Serialization.Deserialize(obj.GetObject(3));
                }

                if (obj.GetUint32Count(4) == 1)
                {
                    snapshot.PhysicsTick = obj.GetUint32(4);
                }

                if (obj.GetFloatCount(5) == 1)
                {
                    snapshot.TicksPerSecond = obj.GetFloat(5);
                }
            }
        }

        public struct Update : ISpatialComponentUpdate
        {
            public Option<global::Improbable.Gdk.TransformSynchronization.FixedPointVector3> Location;
            public Option<global::Improbable.Gdk.TransformSynchronization.CompressedQuaternion> Rotation;
            public Option<global::Improbable.Gdk.TransformSynchronization.FixedPointVector3> Velocity;
            public Option<uint> PhysicsTick;
            public Option<float> TicksPerSecond;
        }

        internal class TransformInternalDynamic : IDynamicInvokable
        {
            public uint ComponentId => TransformInternal.ComponentId;

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
                    Location = snapshot.Location,
                    Rotation = snapshot.Rotation,
                    Velocity = snapshot.Velocity,
                    PhysicsTick = snapshot.PhysicsTick,
                    TicksPerSecond = snapshot.TicksPerSecond
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
