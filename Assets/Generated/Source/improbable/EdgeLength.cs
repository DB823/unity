// =====================================================
// DO NOT EDIT - this file is automatically regenerated.
// =====================================================

using System.Linq;
using Improbable.Gdk.Core;
using UnityEngine;

namespace Improbable
{
    [global::System.Serializable]
    public struct EdgeLength
    {
        public double X;
        public double Y;
        public double Z;

        public EdgeLength(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static readonly EdgeLength Zero = new EdgeLength(0, 0, 0);

        public static EdgeLength operator -(EdgeLength v1, EdgeLength v2)
        {
            return new EdgeLength(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
        }

        public static EdgeLength operator +(EdgeLength a, EdgeLength b)
        {
            return new EdgeLength(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        public static EdgeLength operator *(EdgeLength coords, float f)
        {
            return new EdgeLength(coords.X * f, coords.Y * f, coords.Z * f);
        }

        public static EdgeLength operator *(EdgeLength coords, double d)
        {
            return new EdgeLength(coords.X * d, coords.Y * d, coords.Z * d);
        }

        public static EdgeLength operator /(EdgeLength coords, float f)
        {
            return new EdgeLength(coords.X / f, coords.Y / f, coords.Z / f);
        }

        public static EdgeLength operator /(EdgeLength coords, double d)
        {
            return new EdgeLength(coords.X / d, coords.Y / d, coords.Z / d);
        }

        public static bool operator ==(EdgeLength a, EdgeLength b) => a.Equals(b);
        public static bool operator !=(EdgeLength a, EdgeLength b) => !a.Equals(b);

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is EdgeLength other && Equals(other);
        }

        public bool Equals(EdgeLength other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = X.GetHashCode();
                hashCode = (hashCode * 397) ^ Y.GetHashCode();
                hashCode = (hashCode * 397) ^ Z.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        ///     Returns the string representation of the EdgeLength.
        /// </summary>
        public override string ToString()
        {
            return $"EdgeLength({X}, {Y}, {Z})";
        }

        /// <summary>
        ///     Converts from a Unity Vector3.
        /// </summary>
        public static EdgeLength FromUnityVector(Vector3 v)
        {
            return new EdgeLength(v.x, v.y, v.z);
        }

        /// <summary>
        ///     Converts to a Unity Vector3.
        /// </summary>
        public Vector3 ToUnityVector()
        {
            return new Vector3((float) X, (float) Y, (float) Z);
        }

        public static class Serialization
        {
            public static void Serialize(EdgeLength instance, global::Improbable.Worker.CInterop.SchemaObject obj)
            {
                {
                    obj.AddDouble(1, instance.X);
                }

                {
                    obj.AddDouble(2, instance.Y);
                }

                {
                    obj.AddDouble(3, instance.Z);
                }
            }

            public static EdgeLength Deserialize(global::Improbable.Worker.CInterop.SchemaObject obj)
            {
                var instance = new EdgeLength();

                {
                    instance.X = obj.GetDouble(1);
                }

                {
                    instance.Y = obj.GetDouble(2);
                }

                {
                    instance.Z = obj.GetDouble(3);
                }

                return instance;
            }
        }
    }
}
