using Xenko.Core.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Xenko.Core.Mathematics
{
    /// <summary>
    /// Position and orientation together.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Pose
    {
        #region Static Fields
        /// <summary>
        /// 
        /// </summary>
        public static readonly Pose Identity = new Pose { Orientation = Quaternion.Identity };
        #endregion

        #region Properties
        /// <summary>
        /// The orientation
        /// </summary>
        public Quaternion Orientation;
        /// <summary>
        /// The position
        /// </summary>
        public Vector3 Position;
        #endregion

        #region Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        public void GetViewMatrix(out Matrix matrix)
        {
            Matrix.RotationQuaternion(ref Orientation, out matrix);
            matrix.TranslationVector = Position;
            matrix.Invert();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scale"></param>
        /// <param name="matrix"></param>
        public void GetViewMatrix(ref Matrix scale, out Matrix matrix)
        {
            Matrix.RotationQuaternion(ref Orientation, out var view);
            view.TranslationVector = Position;
            view.Invert();

            Matrix.Multiply(ref scale, ref view, out matrix);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matrix"></param>
        public void GetWorldMatrix(out Matrix matrix)
        {
            Matrix.RotationQuaternion(ref Orientation, out matrix);
            matrix.TranslationVector = Position;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scale"></param>
        /// <param name="matrix"></param>
        public void GetWorldMatrix(float scale, out Matrix matrix)
        {
            var scaling = new Vector3(scale);
            Matrix.Transformation(ref scaling, ref Orientation, ref Position, out matrix);
        }
        #endregion

        #region Operators
        public static Pose operator *(Pose left, Pose right)
        {
            Pose result;
            Multiply(ref left, ref right, out result);
            return result;
        }
        #endregion

        #region Static Methods
        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        public static void Multiply(ref Pose left, ref Pose right, out Pose result)
        {
            Quaternion.Multiply(ref left.Orientation, ref right.Orientation, out result.Orientation);
            Vector3.Transform(ref left.Position, ref right.Orientation, out result.Position);
            Vector3.Add(ref result.Position, ref right.Position, out result.Position);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pose"></param>
        /// <param name="result"></param>
        public static void Invert(ref Pose pose, out Pose result)
        {
            Quaternion.Invert(ref pose.Orientation, out result.Orientation);
            Vector3.Multiply(ref pose.Position, -1.0f, out var inversePosition);
            Vector3.Transform(ref inversePosition, ref result.Orientation, out result.Position);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="world"></param>
        /// <param name="result"></param>
        public static void FromMatrix(ref Matrix world, out Pose result)
        {
            Quaternion.RotationMatrix(ref world, out result.Orientation);
            result.Position = world.TranslationVector;
        }
        #endregion
    }
}
