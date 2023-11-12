using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMatrix : MonoBehaviour
{
    private HMatrix2D mat = new HMatrix2D();
    // Start is called before the first frame update
    void Start()
    {
        mat.SetIdentity();
        mat.Print();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Question2()
    {
        HMatrix2D mat1 = new HMatrix2D();
        HMatrix2D mat2 = new HMatrix2D();
        HMatrix2D resultMat = new HMatrix2D();
        HVector2D vec1 = new HVector2D();
    }

}
