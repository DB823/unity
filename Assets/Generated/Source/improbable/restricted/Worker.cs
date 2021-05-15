// =====================================================
// DO NOT EDIT - this file is automatically regenerated.
// =====================================================

using Improbable.Gdk.Core;
using Improbable.Worker.CInterop;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.Entities;

namespace Improbable.Restricted
{
    public partial class Worker
    {
        public const uint ComponentId = 60;

        public unsafe struct Component : IComponentData, ISpatialComponentData, ISnapshottable<Snapshot>
        {
            // Bit masks for tracking which component properties were changed locally and need to be synced.
            private fixed UInt32 dirtyBits[1];

            internal global::Improbable.Gdk.Core.ReferenceProvider<string>.ReferenceHandle workerIdHandle;

            public string WorkerId
            {
                get => workerIdHandle.Get();
                set
                {
                    MarkDataDirty(0);
                    workerIdHandle.Set(value);
                }
            }

            internal global::Improbable.Gdk.Core.ReferenceProvider<string>.ReferenceHandle workerTypeHandle;

            public string WorkerType
            {
                get => workerTypeHandle.Get();
                set
                {
                    MarkDataDirty(1);
                    workerTypeHandle.Set(value);
                }
            }

            private global::Improbable.Restricted.Connection connection;

            public global::Improbable.Restricted.Connection Connection
            {
                get => connection;
                set
                {
                    MarkDataDirty(2);
                    this.connection = value;
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
                if (propertyIndex < 0 || propertyIndex >= 3)
                {
                    throw new ArgumentException("\"propertyIndex\" argument out of range. Valid range is [0, 2]. " +
                        "Unless you are using custom component replication code, this is most likely caused by a code generation bug. " +
                        "Please contact SpatialOS support if you encounter this issue.");
                }
            }

            public Snapshot ToComponentSnapshot(global::Unity.Entities.World world)
            {
                var componentDataSchema = new ComponentData(60, SchemaComponentData.Create());
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
            public uint ComponentId => 60;

            public string WorkerId;
            public string WorkerType;
            public global::Improbable.Restricted.Connection Connection;

            public Snapshot(string workerId, string workerType, global::Improbable.Restricted.Connection connection)
            {
                WorkerId = workerId;
                WorkerType = workerType;
                Connection = connection;
            }
        }

        public static class Serialization
        {
            public static void SerializeComponent(global::Improbable.Restricted.Worker.Component component, global::Improbable.Worker.CInterop.SchemaObject obj, global::Unity.Entities.World world)
            {
                obj.AddString(1, component.WorkerId);

                obj.AddString(2, component.WorkerType);

                global::Improbable.Restricted.Connection.Serialization.Serialize(component.Connection, obj.AddObject(3));
            }

            public static void SerializeUpdate(global::Improbable.Restricted.Worker.Component component, global::Improbable.Worker.CInterop.SchemaComponentUpdate updateObj)
            {
                var obj = updateObj.GetFields();

                if (component.IsDataDirty(0))
                {
                    obj.AddString(1, component.WorkerId);
                }

                if (component.IsDataDirty(1))
                {
                    obj.AddString(2, component.WorkerType);
                }

                if (component.IsDataDirty(2))
                {
                    global::Improbable.Restricted.Connection.Serialization.Serialize(component.Connection, obj.AddObject(3));
                }
            }

            public static void SerializeUpdate(global::Improbable.Restricted.Worker.Update update, global::Improbable.Worker.CInterop.SchemaComponentUpdate updateObj)
            {
                var obj = updateObj.GetFields();

                {
                    if (update.WorkerId.HasValue)
                    {
                        var field = update.WorkerId.Value;

                        obj.AddString(1, field);
                    }
                }

                {
                    if (update.WorkerType.HasValue)
                    {
                        var field = update.WorkerType.Value;

                        obj.AddString(2, field);
                    }
                }

                {
                    if (update.Connection.HasValue)
                    {
                        var field = update.Connection.Value;

                        global::Improbable.Restricted.Connection.Serialization.Serialize(field, obj.AddObject(3));
                    }
                }
            }

            public static void SerializeSnapshot(global::Improbable.Restricted.Worker.Snapshot snapshot, global::Improbable.Worker.CInterop.SchemaObject obj)
            {
                obj.AddString(1, snapshot.WorkerId);

                obj.AddString(2, snapshot.WorkerType);

                global::Improbable.Restricted.Connection.Serialization.Serialize(snapshot.Connection, obj.AddObject(3));
            }

            public static global::Improbable.Restricted.Worker.Component Deserialize(global::Improbable.Worker.CInterop.SchemaObject obj, global::Unity.Entities.World world)
            {
                var component = new global::Improbable.Restricted.Worker.Component();

                component.workerIdHandle = global::Improbable.Gdk.Core.ReferenceProvider<string>.Create();

                component.WorkerId = obj.GetString(1);

                component.workerTypeHandle = global::Improbable.Gdk.Core.ReferenceProvider<string>.Create();

                component.WorkerType = obj.GetString(2);

                component.Connection = global::Improbable.Restricted.Connection.Serialization.Deserialize(obj.GetObject(3));

                return component;
            }

            public static global::Improbable.Restricted.Worker.Update DeserializeUpdate(global::Improbable.Worker.CInterop.SchemaComponentUpdate updateObj)
            {
                var update = new global::Improbable.Restricted.Worker.Update();
                var obj = updateObj.GetFields();

                if (obj.GetStringCount(1) == 1)
                {
                    update.WorkerId = obj.GetString(1);
                }

                if (obj.GetStringCount(2) == 1)
                {
                    update.WorkerType = obj.GetString(2);
                }

                if (obj.GetObjectCount(3) == 1)
                {
                    update.Connection = global::Improbable.Restricted.Connection.Serialization.Deserialize(obj.GetObject(3));
                }

                return update;
            }

            public static global::Improbable.Restricted.Worker.Update DeserializeUpdate(global::Improbable.Worker.CInterop.SchemaComponentData data)
            {
                var update = new global::Improbable.Restricted.Worker.Update();
                var obj = data.GetFields();

                update.WorkerId = obj.GetString(1);

                update.WorkerType = obj.GetString(2);

                update.Connection = global::Improbable.Restricted.Connection.Serialization.Deserialize(obj.GetObject(3));

                return update;
            }

            public static global::Improbable.Restricted.Worker.Snapshot DeserializeSnapshot(global::Improbable.Worker.CInterop.SchemaObject obj)
            {
                var component = new global::Improbable.Restricted.Worker.Snapshot();

                component.WorkerId = obj.GetString(1);

                component.WorkerType = obj.GetString(2);

                component.Connection = global::Improbable.Restricted.Connection.Serialization.Deserialize(obj.GetObject(3));

                return component;
            }

            public static void ApplyUpdate(global::Improbable.Worker.CInterop.SchemaComponentUpdate updateObj, ref global::Improbable.Restricted.Worker.Component component)
            {
                var obj = updateObj.GetFields();

                if (obj.GetStringCount(1) == 1)
                {
                    component.WorkerId = obj.GetString(1);
                }

                if (obj.GetStringCount(2) == 1)
                {
                    component.WorkerType = obj.GetString(2);
                }

                if (obj.GetObjectCount(3) == 1)
                {
                    component.Connection = global::Improbable.Restricted.Connection.Serialization.Deserialize(obj.GetObject(3));
                }
            }

            public static void ApplyUpdate(global::Improbable.Worker.CInterop.SchemaComponentUpdate updateObj, ref global::Improbable.Restricted.Worker.Snapshot snapshot)
            {
                var obj = updateObj.GetFields();

                if (obj.GetStringCount(1) == 1)
                {
                    snapshot.WorkerId = obj.GetString(1);
                }

                if (obj.GetStringCount(2) == 1)
                {
                    snapshot.WorkerType = obj.GetString(2);
                }

                if (obj.GetObjectCount(3) == 1)
                {
                    snapshot.Connection = global::Improbable.Restricted.Connection.Serialization.Deserialize(obj.GetObject(3));
                }
            }
        }

        public struct Update : ISpatialComponentUpdate
        {
            public Option<string> WorkerId;
            public Option<string> WorkerType;
            public Option<global::Improbable.Restricted.Connection> Connection;
        }

        internal class WorkerDynamic : IDynamicInvokable
        {
            public uint ComponentId => Worker.ComponentId;

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
                    WorkerId = snapshot.WorkerId,
                    WorkerType = snapshot.WorkerType,
                    Connection = snapshot.Connection
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
