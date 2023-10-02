using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public Vector3[] BoardSpaces;

    private void OnDrawGizmos()
    {
        //View where the board spaces currently are.
        Gizmos.color = Color.blue;
        foreach (Vector3 BoardSpace in BoardSpaces)
        {
            Gizmos.DrawSphere(BoardSpace, 0.2f);
        }
    }
}
