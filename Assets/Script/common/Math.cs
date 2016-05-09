using System.Collections;
using UnityEngine;

    public class MyMath
    {
        private static MyMath m_Math = null;

        public static MyMath GetInstance()
        {
            if(m_Math == null)
            {
                m_Math = new MyMath();
            }
            return m_Math;
        }
        public float GetPtAngle(Vector3 vec1, Vector3 vec2)
        {
            float slope = (vec2.y - vec1.y) / (vec2.x - vec1.x);
            float angle = Mathf.Atan(slope) * 180.0f / Mathf.PI;
            return angle;
        }

        public Vector3 GetPtPath(Vector3 vecStart, Vector3 vecEnd, float Scalear)
        {
            Vector3 vecPos = (vecEnd - vecStart) * Scalear + vecStart;
            return vecPos;
        }

        public Vector3 CubicBezierCurve(Vector3 pt1, Vector3 pt2, Vector3 pt3, Vector3 pt4, float Scalar)
        {
            Vector3 vecOut = pt1 * (1.0f - Scalar) * (1.0f - Scalar) * (1.0f - Scalar) +
                  pt2 * 3.0f * Scalar * (1.0f - Scalar) * (1.0f - Scalar) +
                  pt3 * 3.0f * Scalar * Scalar * (1.0f - Scalar) +
                  pt4 * Scalar * Scalar * Scalar;
            return vecOut;
        }

        public int GetRandom(int rmin, int rmax)
        {
            int step = Random.Range(rmin, rmax);
            return step;
        }
    }


