// Uncomment this whole file.

using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformMesh : MonoBehaviour
{
    [HideInInspector]
    public Vector3[] vertices { get; private set; }
    private HMatrix2D transformMatrix = new HMatrix2D();
    private MeshManager meshManager;
    HVector2D pos = new HVector2D();

    HMatrix2D toOriginMatrix = new HMatrix2D();
    HMatrix2D fromOriginMatrix = new HMatrix2D();
    HMatrix2D rotateMatrix = new HMatrix2D();

    void Start()
    {
        meshManager = GetComponent<MeshManager>();
        pos = new HVector2D(gameObject.transform.position.x, gameObject.transform.position.y);
        //Translate(1, 1);
        Rotate(45);
    }


    void Translate(float x, float y)
    {
        transformMatrix.SetIdentity(); //calls the setidentity function from transformmatrix/hmatrix2d script
        transformMatrix.SetTranslationMat(x, y); //calls the settranslationmatrix from hmatrix2d script and passes x,y vairables into the function 
        Transform();

        pos = transformMatrix * pos; //new position is the current position multiplied by the translation matrix
    }

    void Rotate(float angle)
    {
        HMatrix2D toOriginMatrix = new HMatrix2D();
        HMatrix2D fromOriginMatrix = new HMatrix2D(); //the matrix that will bring the object back form the origin to the original place
        HMatrix2D rotateMatrix = new HMatrix2D(); //the matrix that will rotate the object

        toOriginMatrix.SetTranslationMat(-pos.x, -pos.y); //to move the object to the origin, take the coords of the object and set it to minus so it moves to 0,0
        fromOriginMatrix.SetTranslationMat(pos.x, pos.y); //to move it back to its original position, add its x and y coords to the object's position

        rotateMatrix.SetRotationMat(angle); //call the rotation matrix and pass in the angle to rotate it by

        transformMatrix.SetIdentity(); 
        transformMatrix = fromOriginMatrix * rotateMatrix * toOriginMatrix; //since unity's system is right to left, to calculate the rotation, multiply the from, rotate, then to matrix

        Transform();
    }

    private void Transform()
    {
        vertices = meshManager.clonedMesh.vertices; //accesses the vertices of the clonedmesh

        for (int i = 0; i < vertices.Length; i++) //loops through the vertices of the mesh
        {
            HVector2D vert = new HVector2D(vertices[i].x, vertices[i].y); //creates a new hvector2d from the x and y coordinates of the mesh
            vert = transformMatrix * vert; //transforms the vertices by multiplying it with the transformation matrix
            vertices[i].x = vert.x; //updates the x and y values of the vertices
            vertices[i].y = vert.y;
        }
        meshManager.clonedMesh.vertices = vertices; //updates the clonedmesh vertices with the new vertices
    }
}
