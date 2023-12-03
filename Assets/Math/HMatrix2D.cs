using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Principal;
using UnityEngine;

public class HMatrix2D
{
    public float[,] Entries { get; set; } = new float[3, 3]; //initialises the matrix with 3 rows 3 columns of float numbers
 
    public HMatrix2D()
    {
        SetIdentity();
    }

    public HMatrix2D(float[,] multiArray)
    {
        for (int y = 0; y < 3; y++) //loops through each row and column
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
        HMatrix2D result = new HMatrix2D(); //result matrix is the new matrix from adding the left and right matrices together
        for (int i = 0; i < 3; i++) //loop through each row and column
        {
            for (int j = 0; j < 3; j++)
            {
                result.Entries[i, j] = left.Entries[i, j] + right.Entries[i, j]; //adds elements of the same column and row together
            }
        }
        return result;
    }

    public static HMatrix2D operator -(HMatrix2D left, HMatrix2D right)
    {
        HMatrix2D result = new HMatrix2D(); //result is the new matrix from subtracting right from left
        for (int i = 0; i < 3; i++) //loop through each row and column
        {
            for (int j =0; j < 3; j++)
            {
                result.Entries[i,j] = left.Entries[i,j] - right.Entries[i,j]; //subtract the element from the right matrix with the same row and column from the left matrix
            }
        }
        return result;
    }

    public static HMatrix2D operator *(HMatrix2D left, float scalar)
    {
        HMatrix2D result = new HMatrix2D(); //result is the new matrix from multiplying a matrix and the scalar number
        for (int i = 0; i < 3; i++) //loop through each rown and column
        {
            for (int j =0;j < 3; j++) 
            {
                result.Entries[i,j] = scalar * left.Entries[i,j]; //multipled each element with the scalar number
            }
        }
        return result;
    }

    // Note that the second argument is a HVector2D object
    public static HVector2D operator *(HMatrix2D left, HVector2D right)
    {
        return new HVector2D 
        (
            left.Entries[0,0] * right.x + left.Entries[0,1] * right.y + left.Entries[0,2] * right.h, //multiplies the elements of the first row with the x,y,h values of the vector
            left.Entries[1,0] * right.x + left.Entries[1,1] * right.y + left.Entries[1,2] * right.h  //multiplies the elements of the second row with the x,y,h values of the vector
        );
    }

    // Note that the second argument is a HMatrix2D object 
    public static HMatrix2D operator *(HMatrix2D left, HMatrix2D right)
    {
        return new HMatrix2D
        (/*
                00 01 02    00 01 02
                10 11 12    10 11 12
                20 21 22    20 21 22
                */

            left.Entries[0, 0] * right.Entries[0, 0] + left.Entries[0, 1] * right.Entries[1, 0] + left.Entries[0, 2] * right.Entries[2, 0], //manually multiply each entry
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

    public static bool operator == (HMatrix2D left, HMatrix2D right) //checks if the left matrix is the same as the right matrix
    {
        for (int i = 0; i > 3; i ++) //loops through each row and column
        {
            for (int j =0; j < 3; j++)
            {
                if (left.Entries[i,j] != right.Entries[i,j]) //sees whether the elements with the same row and column number are not equal
                    return false; //if the two elements are not the same return false
            }
        }
        return true; //if all elements are the same, return true 
    }

    public static bool operator != (HMatrix2D left, HMatrix2D right) //checks if the left matrix is not the same as the right matrix
    {
        for ( int i = 0;i > 3; i ++) //loops through each row and column
        {
            for (int j =0; j >3; j++)
            {
                if (left.Entries[i, j] == right.Entries[i, j]) //checks if the elements of the left  and right matrix are the same
                    return false; //if the elements are the same, return false
            }
        }
        return true; //if all the elements are not the same, return true
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
        //for (int y = 0; y < 3; y++)   //nested for loop that goes through each row and column
        //{
        //    for (int x = 0; x < 3; x++)
        //    {
        //        if (x == y) //when x and y are the same, those elements should be 1 so the matrix will be an identity matrix
        //        {
        //            Entries[x,y] = 1;
        //        }
        //        else
        //        {
        //            Entries[x,y] = 0;
        //        }
        //    }
        //}

        for (int x = 0; x < 3; x++) //less long-winded version using ternary operator
            for (int y = 0; y < 3; y++) //loops through rows and columns
                Entries[x, y] = x == y ? 1 : 0; //if boolean x==y is true, the entry is 1, if it's false the entry is zero
    }

    public void SetTranslationMat(float transX, float transY)
    {
        SetIdentity();
        Entries[0,2] = transX; //translation matrix's element 02 is the movement along the x axis the object has to move
        Entries[1,2] = transY; //translation matrix's element 12 is the movement along the y axis the object has tomove
    }

    public void SetRotationMat(float rotDeg)
    {
        SetIdentity();
        float rad = rotDeg * Mathf.Deg2Rad; //convert degrees into radian first because cos and sin take radian
        Entries[0, 0] = Mathf.Cos(rad); //followed from the multiplication matrix from the lecture slides
        Entries[0, 1] = -Mathf.Sin(rad); //manually insert the appropriate sin/cos function into the correct elements
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