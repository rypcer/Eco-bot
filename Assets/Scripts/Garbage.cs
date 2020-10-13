using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garbage : MonoBehaviour
{
    #region DECLARATIONS
    private List<GameObject> garbageUnits; //list of all the 1x1 units making up the whole garbage block
    public bool isMovable;
    #endregion

    private void Awake()
    {
        garbageUnits = new List<GameObject>();
        foreach (Transform child in transform)
            if (child.gameObject.CompareTag("GarbageUnit"))
                garbageUnits.Add(child.gameObject);
    }

    //return the coordinates of all the cells uccupied by this garbage piece
    public int[,] CellsOccupied(Vector3 levelWorldPosition, float cellLength)
    {
        int[,] cellsOccupied = new int[garbageUnits.Count, 2];
        for (int count = 0; count < garbageUnits.Count; count++)
        {
            Vector3 relativeUnitPosition = garbageUnits[count].transform.position - levelWorldPosition;
            cellsOccupied[count, 0] = (int)(relativeUnitPosition.x / cellLength+0.5f);
            cellsOccupied[count, 1] = (int)(relativeUnitPosition.z / cellLength+0.5f);
        }
        return cellsOccupied;
    }

    //return the coordinates of all the cells uccupied by this garbage piece after moving in the specified direction
    public int[,] CellsOccupiedAfterMoving(Vector3 levelWorldPosition, float cellLength, Vector2Int direction)
    {
        int[,] cellsOccupied = new int[garbageUnits.Count, 2];
        for (int count = 0; count < garbageUnits.Count; count++)
        {
            Vector3 relativeUnitPosition = garbageUnits[count].transform.position - levelWorldPosition;
            cellsOccupied[count, 0] = (int)(relativeUnitPosition.x / cellLength +0.5f)+direction.x;
            cellsOccupied[count, 1] = (int)(relativeUnitPosition.z / cellLength +0.5f)+direction.y;
        }
        return cellsOccupied;
    }

    //initiate the coroutine to move the garbage piece one cell in a particular direction
    public void MoveGarbagePiece(Vector2Int direction, float speed)
    {
        StartCoroutine(MoveGarbageCoroutine(direction, speed));
    }

    //Coroutine to translate the piece of garbage one unit in the specified direction
    private IEnumerator MoveGarbageCoroutine(Vector2Int direction, float speed)
    {
        Vector3 targetPosition = transform.position + new Vector3(direction.x, 0, direction.y);
        AudioManager.instance.Play("blockmove");
        while (transform.position!=targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }
        yield return null;
    }
}
