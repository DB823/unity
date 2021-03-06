// =====================================================
// DO NOT EDIT - this file is automatically regenerated.
// =====================================================

using System.Linq;
using Improbable.Gdk.Core;
using UnityEngine;

namespace Improbable.Gdk.TransformSynchronization
{
    [global::System.Serializable]
    public struct FixedPointVector3
    {
        public int X;
        public int Y;
        public int Z;

        public FixedPointVector3(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static readonly FixedPointVector3 Zero = new FixedPointVector3(0, 0, 0);

        public static bool operator ==(FixedPointVector3 a, FixedPointVector3 b) => a.Equals(b);
        public static bool operator !=(FixedPointVector3 a, FixedPointVector3 b) => !a.Equals(b);

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is FixedPointVector3 other && Equals(other);
        }

        public bool Equals(FixedPointVector3 other)
        {
            return X == other.X && Y == other.Y && Z == other.Z;
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
        ///     Returns the string representation of the FixedPointVector3.
        /// </summary>
        public override string ToString()
        {
            return $"FixedPointVector3({X}, {Y}, {Z})";
        }

        /// <summary>
        ///     Converts a Unity Vector3 to a FixedPointVector3 value.
        /// </summary>
        /// <remarks>
        ///     Converts each component from a float to a Q21.10 fixed point value.
        /// </remarks>
        public static FixedPointVector3 FromUnityVector(Vector3 v)
        {
            return new FixedPointVector3
            {
                X = FloatToFixed(v.x),
                Y = FloatToFixed(v.y),
                Z = FloatToFixed(v.z)
            };
        }

        /// <summary>
        ///     Converts a FixedPointVector3 to a Unity Vector3.
        /// </summary>
        /// <remarks>
        ///     Converts each component from a Q21.10 fixed point value to a float.
        /// </remarks>
        public Vector3 ToUnityVector()
        {
            return new Vector3
            {
                x = FixedToFloat(X),
                y = FixedToFloat(Y),
                z = FixedToFloat(Z)
            };
        }

        /// <summary>
        ///     Converts a FixedPointVector3 to a Coordinates value.
        /// </summary>
        /// <remarks>
        ///     Converts each component from a Q21.10 fixed point value to a double.
        /// </remarks>
        public Coordinates ToCoordinates()
        {
            return new Coordinates
            {
                X = FixedToFloat(X),
                Y = FixedToFloat(Y),
                Z = FixedToFloat(Z)
            };
        }

        // 2^-10 => 0.0009765625 precision
        private const int FixedPointOne = (int) (1u << 10);

        private static int FloatToFixed(float a)
        {
            return (int) (a * FixedPointOne);
        }

        private static float FixedToFloat(int a)
        {
            return (float) a / FixedPointOne;
        }

        public static class Serialization
        {
            public static void Serialize(FixedPointVector3 instance, global::Improbable.Worker.CInterop.SchemaObject obj)
            {
                {
                    obj.AddSint32(1, instance.X);
                }

                {
                    obj.AddSint32(2, instance.Y);
                }

                {
                    obj.AddSint32(3, instance.Z);
                }
            }

            public static FixedPointVector3 Deserialize(global::Improbable.Worker.CInterop.SchemaObject obj)
            {
                var instance = new FixedPointVector3();

                {
                    instance.X = obj.GetSint32(1);
                }

                {
                    instance.Y = obj.GetSint32(2);
                }

                {
                    instance.Z = obj.GetSint32(3);
                }

                return instance;
            }
        }
    }
}
