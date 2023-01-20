using System;
using UnityEngine;



[Serializable]
public struct SVect3
{
    public float X;
    public float Y;
    public float Z;

    public SVect3(float x, float y, float z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public static implicit operator SVect3(Vector3 vect)
    {
        return new SVect3(vect.x, vect.y, vect.z);
    }
    public static implicit operator Vector3(SVect3 val)
    {
        return new SVect3(val.X, val.Y, val.Z);
    }
}
