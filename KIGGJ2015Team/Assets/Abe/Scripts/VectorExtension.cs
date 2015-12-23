// ----- ----- ----- ----- -----
//
// VectorExtension
//
// 作成日：
// 作成者：
//
// <概要>
//
//
// ----- ----- ----- ----- -----

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("MyScript/VectorExtension")]
public class VectorExtension
{
	public static float DistanceSquared(Vector3 a, Vector3 b)
    {
        float X = a.x - b.x;
        float Y = a.y - b.y;
        float Z = a.z - b.z;
        return X * X + Y * Y + Z * Z;
    }
}