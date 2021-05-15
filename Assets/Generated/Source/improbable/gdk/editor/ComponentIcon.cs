// =====================================================
// DO NOT EDIT - this file is automatically regenerated.
// =====================================================

using System.Linq;
using Improbable.Gdk.Core;
using UnityEngine;

namespace Improbable.Gdk.Editor
{
    [global::System.Serializable]
    public struct ComponentIcon
    {
        public string IconName;

        public ComponentIcon(string iconName)
        {
            IconName = iconName;
        }

        public static class Serialization
        {
            public static void Serialize(ComponentIcon instance, global::Improbable.Worker.CInterop.SchemaObject obj)
            {
                {
                    obj.AddString(1, instance.IconName);
                }
            }

            public static ComponentIcon Deserialize(global::Improbable.Worker.CInterop.SchemaObject obj)
            {
                var instance = new ComponentIcon();

                {
                    instance.IconName = obj.GetString(1);
                }

                return instance;
            }
        }
    }
}
