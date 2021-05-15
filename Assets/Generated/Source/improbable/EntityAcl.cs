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
    public partial class EntityAcl
    {
        public const uint ComponentId = 50;

        public unsafe struct Component : IComponentData, ISpatialComponentData, ISnapshottable<Snapshot>
        {
            // Bit masks for tracking which component properties were changed locally and need to be synced.
            private fixed UInt32 dirtyBits[1];

            internal global::Improbable.Gdk.Core.ReferenceProvider<global::Improbable.WorkerRequirementSet>.ReferenceHandle readAclHandle;

            public global::Improbable.WorkerRequirementSet ReadAcl
            {
                get => readAclHandle.Get();
                set
                {
                    MarkDataDirty(0);
                    readAclHandle.Set(value);
                }
            }

            internal global::Improbable.Gdk.Core.ReferenceProvider<global::System.Collections.Generic.Dictionary<uint, global::Improbable.WorkerRequirementSet>>.ReferenceHandle componentWriteAclHandle;

            public global::System.Collections.Generic.Dictionary<uint, global::Improbable.WorkerRequirementSet> ComponentWriteAcl
            {
                get => componentWriteAclHandle.Get();
                set
                {
                    MarkDataDirty(1);
                    componentWriteAclHandle.Set(value);
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
                if (propertyIndex < 0 || propertyIndex >= 2)
                {
                    throw new ArgumentException("\"propertyIndex\" argument out of range. Valid range is [0, 1]. " +
                        "Unless you are using custom component replication code, this is most likely caused by a code generation bug. " +
                        "Please contact SpatialOS support if you encounter this issue.");
                }
            }

            public Snapshot ToComponentSnapshot(global::Unity.Entities.World world)
            {
                var componentDataSchema = new ComponentData(50, SchemaComponentData.Create());
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
            public uint ComponentId => 50;

            public global::Improbable.WorkerRequirementSet ReadAcl;
            public global::System.Collections.Generic.Dictionary<uint, global::Improbable.WorkerRequirementSet> ComponentWriteAcl;

            public Snapshot(global::Improbable.WorkerRequirementSet readAcl, global::System.Collections.Generic.Dictionary<uint, global::Improbable.WorkerRequirementSet> componentWriteAcl)
            {
                ReadAcl = readAcl;
                ComponentWriteAcl = componentWriteAcl;
            }
        }

        public static class Serialization
        {
            public static void SerializeComponent(global::Improbable.EntityAcl.Component component, global::Improbable.Worker.CInterop.SchemaObject obj, global::Unity.Entities.World world)
            {
                global::Improbable.WorkerRequirementSet.Serialization.Serialize(component.ReadAcl, obj.AddObject(1));

                foreach (var keyValuePair in component.ComponentWriteAcl)
                {
                    var mapObj = obj.AddObject(2);
                    mapObj.AddUint32(1, keyValuePair.Key);
                    global::Improbable.WorkerRequirementSet.Serialization.Serialize(keyValuePair.Value, mapObj.AddObject(2));
                }
            }

            public static void SerializeUpdate(global::Improbable.EntityAcl.Component component, global::Improbable.Worker.CInterop.SchemaComponentUpdate updateObj)
            {
                var obj = updateObj.GetFields();

                if (component.IsDataDirty(0))
                {
                    global::Improbable.WorkerRequirementSet.Serialization.Serialize(component.ReadAcl, obj.AddObject(1));

                    
                }

                if (component.IsDataDirty(1))
                {
                    foreach (var keyValuePair in component.ComponentWriteAcl)
                    {
                        var mapObj = obj.AddObject(2);
                        mapObj.AddUint32(1, keyValuePair.Key);
                        global::Improbable.WorkerRequirementSet.Serialization.Serialize(keyValuePair.Value, mapObj.AddObject(2));
                    }

                    if (component.ComponentWriteAcl.Count == 0)
                    {
                        updateObj.AddClearedField(2);
                    }
                }
            }

            public static void SerializeUpdate(global::Improbable.EntityAcl.Update update, global::Improbable.Worker.CInterop.SchemaComponentUpdate updateObj)
            {
                var obj = updateObj.GetFields();

                {
                    if (update.ReadAcl.HasValue)
                    {
                        var field = update.ReadAcl.Value;

                        global::Improbable.WorkerRequirementSet.Serialization.Serialize(field, obj.AddObject(1));

                        
                    }
                }

                {
                    if (update.ComponentWriteAcl.HasValue)
                    {
                        var field = update.ComponentWriteAcl.Value;

                        foreach (var keyValuePair in field)
                        {
                            var mapObj = obj.AddObject(2);
                            mapObj.AddUint32(1, keyValuePair.Key);
                            global::Improbable.WorkerRequirementSet.Serialization.Serialize(keyValuePair.Value, mapObj.AddObject(2));
                        }

                        if (field.Count == 0)
                        {
                            updateObj.AddClearedField(2);
                        }
                    }
                }
            }

            public static void SerializeSnapshot(global::Improbable.EntityAcl.Snapshot snapshot, global::Improbable.Worker.CInterop.SchemaObject obj)
            {
                global::Improbable.WorkerRequirementSet.Serialization.Serialize(snapshot.ReadAcl, obj.AddObject(1));

                foreach (var keyValuePair in snapshot.ComponentWriteAcl)
                {
                    var mapObj = obj.AddObject(2);
                    mapObj.AddUint32(1, keyValuePair.Key);
                    global::Improbable.WorkerRequirementSet.Serialization.Serialize(keyValuePair.Value, mapObj.AddObject(2));
                }
            }

            public static global::Improbable.EntityAcl.Component Deserialize(global::Improbable.Worker.CInterop.SchemaObject obj, global::Unity.Entities.World world)
            {
                var component = new global::Improbable.EntityAcl.Component();

                component.readAclHandle = global::Improbable.Gdk.Core.ReferenceProvider<global::Improbable.WorkerRequirementSet>.Create();

                component.ReadAcl = global::Improbable.WorkerRequirementSet.Serialization.Deserialize(obj.GetObject(1));

                component.componentWriteAclHandle = global::Improbable.Gdk.Core.ReferenceProvider<global::System.Collections.Generic.Dictionary<uint, global::Improbable.WorkerRequirementSet>>.Create();

                {
                    var map = new global::System.Collections.Generic.Dictionary<uint, global::Improbable.WorkerRequirementSet>();
                    var mapSize = obj.GetObjectCount(2);
                    component.ComponentWriteAcl = map;

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(2, (uint) i);
                        var key = mapObj.GetUint32(1);
                        var value = global::Improbable.WorkerRequirementSet.Serialization.Deserialize(mapObj.GetObject(2));
                        map.Add(key, value);
                    }
                }

                return component;
            }

            public static global::Improbable.EntityAcl.Update DeserializeUpdate(global::Improbable.Worker.CInterop.SchemaComponentUpdate updateObj)
            {
                var update = new global::Improbable.EntityAcl.Update();
                var obj = updateObj.GetFields();

                if (obj.GetObjectCount(1) == 1)
                {
                    update.ReadAcl = global::Improbable.WorkerRequirementSet.Serialization.Deserialize(obj.GetObject(1));
                }

                {
                    var mapSize = obj.GetObjectCount(2);

                    var isCleared = updateObj.IsFieldCleared(2);

                    if (mapSize > 0 || isCleared)
                    {
                        update.ComponentWriteAcl = new global::Improbable.Gdk.Core.Option<global::System.Collections.Generic.Dictionary<uint, global::Improbable.WorkerRequirementSet>>(new global::System.Collections.Generic.Dictionary<uint, global::Improbable.WorkerRequirementSet>());
                    }

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(2, (uint) i);
                        var key = mapObj.GetUint32(1);
                        var value = global::Improbable.WorkerRequirementSet.Serialization.Deserialize(mapObj.GetObject(2));
                        update.ComponentWriteAcl.Value.Add(key, value);
                    }
                }

                return update;
            }

            public static global::Improbable.EntityAcl.Update DeserializeUpdate(global::Improbable.Worker.CInterop.SchemaComponentData data)
            {
                var update = new global::Improbable.EntityAcl.Update();
                var obj = data.GetFields();

                update.ReadAcl = global::Improbable.WorkerRequirementSet.Serialization.Deserialize(obj.GetObject(1));

                {
                    var map = new global::System.Collections.Generic.Dictionary<uint, global::Improbable.WorkerRequirementSet>();
                    var mapSize = obj.GetObjectCount(2);
                    update.ComponentWriteAcl = map;

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(2, (uint) i);
                        var key = mapObj.GetUint32(1);
                        var value = global::Improbable.WorkerRequirementSet.Serialization.Deserialize(mapObj.GetObject(2));
                        map.Add(key, value);
                    }
                }

                return update;
            }

            public static global::Improbable.EntityAcl.Snapshot DeserializeSnapshot(global::Improbable.Worker.CInterop.SchemaObject obj)
            {
                var component = new global::Improbable.EntityAcl.Snapshot();

                component.ReadAcl = global::Improbable.WorkerRequirementSet.Serialization.Deserialize(obj.GetObject(1));

                {
                    var map = new global::System.Collections.Generic.Dictionary<uint, global::Improbable.WorkerRequirementSet>();
                    var mapSize = obj.GetObjectCount(2);
                    component.ComponentWriteAcl = map;

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(2, (uint) i);
                        var key = mapObj.GetUint32(1);
                        var value = global::Improbable.WorkerRequirementSet.Serialization.Deserialize(mapObj.GetObject(2));
                        map.Add(key, value);
                    }
                }

                return component;
            }

            public static void ApplyUpdate(global::Improbable.Worker.CInterop.SchemaComponentUpdate updateObj, ref global::Improbable.EntityAcl.Component component)
            {
                var obj = updateObj.GetFields();

                if (obj.GetObjectCount(1) == 1)
                {
                    component.ReadAcl = global::Improbable.WorkerRequirementSet.Serialization.Deserialize(obj.GetObject(1));
                }

                {
                    var mapSize = obj.GetObjectCount(2);

                    var isCleared = updateObj.IsFieldCleared(2);

                    if (mapSize > 0 || isCleared)
                    {
                        component.ComponentWriteAcl.Clear();
                    }

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(2, (uint) i);
                        var key = mapObj.GetUint32(1);
                        var value = global::Improbable.WorkerRequirementSet.Serialization.Deserialize(mapObj.GetObject(2));
                        component.ComponentWriteAcl.Add(key, value);
                    }
                }
            }

            public static void ApplyUpdate(global::Improbable.Worker.CInterop.SchemaComponentUpdate updateObj, ref global::Improbable.EntityAcl.Snapshot snapshot)
            {
                var obj = updateObj.GetFields();

                if (obj.GetObjectCount(1) == 1)
                {
                    snapshot.ReadAcl = global::Improbable.WorkerRequirementSet.Serialization.Deserialize(obj.GetObject(1));
                }

                {
                    var mapSize = obj.GetObjectCount(2);

                    var isCleared = updateObj.IsFieldCleared(2);

                    if (mapSize > 0 || isCleared)
                    {
                        snapshot.ComponentWriteAcl.Clear();
                    }

                    for (var i = 0; i < mapSize; i++)
                    {
                        var mapObj = obj.IndexObject(2, (uint) i);
                        var key = mapObj.GetUint32(1);
                        var value = global::Improbable.WorkerRequirementSet.Serialization.Deserialize(mapObj.GetObject(2));
                        snapshot.ComponentWriteAcl.Add(key, value);
                    }
                }
            }
        }

        public struct Update : ISpatialComponentUpdate
        {
            public Option<global::Improbable.WorkerRequirementSet> ReadAcl;
            public Option<global::System.Collections.Generic.Dictionary<uint, global::Improbable.WorkerRequirementSet>> ComponentWriteAcl;
        }

        internal class EntityAclDynamic : IDynamicInvokable
        {
            public uint ComponentId => EntityAcl.ComponentId;

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
                    ReadAcl = snapshot.ReadAcl,
                    ComponentWriteAcl = snapshot.ComponentWriteAcl
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
