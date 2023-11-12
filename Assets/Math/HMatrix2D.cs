using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Principal;
using UnityEngine;

public class HMatrix2D
{
    public float[,] Entries { get; set; } = new float[3, 3];

    public HMatrix2D()
    {
        SetIdentity();
    }

    public HMatrix2D(float[,] multiArray)
    {
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                Entries[x,y] = multiArray[y, x];
            }
        }
    }

    public HMatrix2D(float m00, float m01, float m02,
             float m10, float m11, float m12,
             float m20, float m21, float m22)
    {
        Entries[0,0] = m00;
        Entries[0,1] = m01;
        Entries[0,2] = m02;

        Entries[1,0] = m10;
        Entries[1,1] = m11;
        Entries[1,2] = m12;

        Entries[2,0] = m20;
        Entries[2,1] = m21;
        Entries[2,2] = m22;
    }

    public static HMatrix2D operator +(HMatrix2D left, HMatrix2D right)
    {
        HMatrix2D result = new HMatrix2D();
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                result.Entries[i, j] = left.Entries[i, j] + right.Entries[i, j];
            }
        }
        return result;
    }

    public static HMatrix2D operator -(HMatrix2D left, HMatrix2D right)
    {
        HMatrix2D result = new HMatrix2D();
        for (int i = 0; i < 3; i++)
        {
            for (int j =0; j < 3; j++)
            {
                result.Entries[i,j] = left.Entries[i,j] - right.Entries[i,j];
            }
        }
        return result;
    }

    public static HMatrix2D operator *(HMatrix2D left, float scalar)
    {
        HMatrix2D result = new HMatrix2D();
        for (int i = 0; i < 3; i++)
        {
            for (int j =0;j < 3; j++)
            {
                result.Entries[i,j] = scalar * left.Entries[i,j];
            }
        }
        return result;
    }

    //// Note that the second argument is a HVector2D object
    ////
    public static HVector2D operator *(HMatrix2D left, HVector2D right)
    {
        return new HVector2D
        (
            left.Entries[0,0] * right.x + left.Entries[0,1] * right.y + left.Entries[0,2] * right.h,
            left.Entries[1,0] * right.x + left.Entries[1,1] * right.y + left.Entries[1,2] * right.h 
        );
    }

    // Note that the second argument is a HMatrix2D object
    //
    public static HMatrix2D operator *(HMatrix2D left, HMatrix2D right)
    {
        return new HMatrix2D
        (/* 
                00 01 02    00 01 02
                10 11 12    10 11 12
                20 21 22    20 21 22
                */
            left.Entries[0, 0] * right.Entries[0, 0] + left.Entries[0, 1] * right.Entries[1, 0] + left.Entries[0, 2] * right.Entries[2, 0],
            left.Entries[0, 0] * right.Entries[0, 1] + left.Entries[0, 1] * right.Entries[1, 1] + left.Entries[0, 2] * right.Entries[2, 1],
            left.Entries[0, 0] * right.Entries[0, 2] + left.Entries[0, 1] * right.Entries[1, 2] + left.Entries[0, 2] * right.Entries[2, 2],

            left.Entries[1, 0] * right.Entries[0, 0] + left.Entries[1, 1] * right.Entries[1, 0] + left.Entries[1, 2] * right.Entries[2, 0],
            left.Entries[1, 0] * right.Entries[0, 1] + left.Entries[1, 1] * right.Entries[1, 1] + left.Entries[1, 2] * right.Entries[2, 1],
            left.Entries[1, 0] * right.Entries[0, 2] + left.Entries[1, 1] * right.Entries[1, 2] + left.Entries[1, 2] * right.Entries[2, 2],

            left.Entries[2, 0] * right.Entries[0, 0] + left.Entries[2, 1] * right.Entries[1, 0] + left.Entries[2, 2] * right.Entries[2, 0],
            left.Entries[2, 0] * right.Entries[0, 1] + left.Entries[2, 1] * right.Entries[1, 1] + left.Entries[2, 2] * right.Entries[2, 1],
            left.Entries[2, 0] * right.Entries[0, 2] + left.Entries[2, 1] * right.Entries[1, 2] + left.Entries[2, 2] * right.Entries[2, 2]
        );
    }

    public static bool operator ==(HMatrix2D left, HMatrix2D right)
    {
        for (int i = 0; i > 3; i ++)
        {
            for (int j =0; j < 3; j++)
            {
                if (left.Entries[i,j] != right.Entries[i,j])
                    return false;
            }
        }
        return true;
    }

    public static bool operator !=(HMatrix2D left, HMatrix2D right)
    {
        for ( int i = 0;i > 3; i ++)
        {
            for (int j =0; j >3; j++)
            {
                if (left.Entries[i, j] == right.Entries[i, j])
                    return false;
            }
        }
        return true;
    }

    //public override bool Equals(object obj)
    //{
    //    // your code here
    //}

    //public override int GetHashCode()
    //{
    //    // your code here
    //}

    //public HMatrix2D Transpose()
    //{
    //    return // your code here
    //}

    //public float GetDeterminant()
    //{
    //    return // your code here
    //}

    public void SetIdentity()
    {
        //for (int y = 0; y < 3; y++)
        //{
        //    for (int x = 0; x < 3; x++)
        //    {
        //        if (x == y)
        //        {
        //            Entries[x,y] = 1;
        //        }
        //        else
        //        {
        //            Entries[x,y] = 0;
        //        }
        //    }
        //}
        for (int x = 0; x < 3; x++)
            for (int y = 0; y < 3; y++)
                Entries[x, y] = x == y ? 1 : 0; 
    }

    public void SetTranslationMat(float transX, float transY)
    {
        // your code here
    }

    public void SetRotationMat(float rotDeg)
    {
        SetIdentity();
        float rad = rotDeg * Mathf.Deg2Rad;
        Entries[0, 0] = Mathf.Cos(rad);
        Entries[0, 1] = -Mathf.Sin(rad);
        Entries[1, 0] = Mathf.Sin(rad);
        Entries[1, 1] = Mathf.Cos(rad);
    }

    public void SetScalingMat(float scaleX, float scaleY)
    {
        // your code here
    }

    public void Print()
    {
        string result = "";
        for (int r = 0; r < 3; r++)
        {
            for (int c = 0; c < 3; c++)
            {
                result += Entries[r, c] + "  ";
            }
            result += "\n";
        }
        Debug.Log(result);
    }
}