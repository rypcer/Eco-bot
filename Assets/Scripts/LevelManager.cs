using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    #region DECLARATIONS
    public static LevelManager instance;

    public Vector2Int levelSize; //width and height of the level
    public readonly float cellLength=1.0f;
    private Vector3 levelWorldPosition; //position of the level origin in the world

    public Garbage[] garbageArray; //array of all Garbage pieces in the level
    private GameObject[] plants;
    private Vector2Int playerCell; //coordinates of the cell occupied by the player
    private Vector2Int startCell; //coordinates of the starting/finishing cell
    private int[,] levelLayout; //state of each cell (-2=plant, -1=empty, other int= index of the garbage piece occupying the cell)
    public int plantsCollected { get; private set; }

    private List<Move> moves; //store all moves so that they can be undone
    public int numberOfMoves { get; private set; }
    #endregion

    private void Awake()
    {
        instance = this;

        levelWorldPosition = transform.position;

        GameObject[] tempGarbageArray = GameObject.FindGameObjectsWithTag("Garbage");
        garbageArray = new Garbage[tempGarbageArray.Length];
        for (int i=0; i< tempGarbageArray.Length; i++)
        {
            garbageArray[i] = tempGarbageArray[i].GetComponent<Garbage>();
        }

        plants = GameObject.FindGameObjectsWithTag("Plant");
        plantsCollected = 0;

        moves = new List<Move>();
        numberOfMoves = 0;
    }

    void Start()
    {
        Vector3 playerPosition = PlayerControl.instance.transform.position;
        playerCell = new Vector2Int(
            (int)((playerPosition.x - levelWorldPosition.x) / cellLength+0.5f),
            (int)((playerPosition.z - levelWorldPosition.z) / cellLength+0.5f)
            );

        GameObject levelStart = GameObject.FindGameObjectWithTag("Base");
        startCell= new Vector2Int(
            (int)((levelStart.transform.position.x - levelWorldPosition.x) / cellLength+0.5f),
            (int)((levelStart.transform.position.z - levelWorldPosition.z) / cellLength+0.5f)
            );

        CreateLevelLayout();
    }

    //fill the levelLayout array with integers representing the index of the garbage occupying a certain cell.
    //Empty cells are represented with -1;
    private void CreateLevelLayout()
    {
        levelLayout = new int[levelSize.x, levelSize.y];
        //fill the levelLayout array with -1
        for (int col = 0; col < levelSize.x; col++)
        {
            for (int row = 0; row < levelSize.y; row++)
                levelLayout[col, row] = -1;
        }
        //specify the coverage of each piece of garbage by inserting
        //their index in the corresponding cells of the array
        for (int count = 0; count < garbageArray.Length; count++)
        {
            int[,] cellsOccupiedByGarbage = garbageArray[count].CellsOccupied(levelWorldPosition, cellLength);
            for (int units = 0; units < cellsOccupiedByGarbage.GetLength(0); units++)
            {
                levelLayout[cellsOccupiedByGarbage[units, 0], cellsOccupiedByGarbage[units, 1]] = count;
            }
        }
        //specify the position of each plant by inserting
        //-2 in the corresponding cells of the array
        for (int count = 0; count < plants.Length; count++)
        {
            int col = (int)((plants[count].transform.position.x - levelWorldPosition.x) / cellLength+0.5f);
            int row = (int)((plants[count].transform.position.z - levelWorldPosition.z) / cellLength+0.5f);
            levelLayout[col, row] = -2;
        }
    }

    //function called when the player is trying to move.
    //Check whether there is garbage in the way and whether it can be pushed
    public bool TryPlayerMovement(Vector2Int movementDirection, bool grabbingActionTriggered, out Vector2 facingDirection, out int garbageToMoveIndex)
    {
        Vector2Int newPlayerCell = playerCell + movementDirection;
        int indexCellFront = levelLayout[newPlayerCell.x, newPlayerCell.y];

        if (indexCellFront == -2)  // Collect plant 
        {
            PlayerControl.instance.animator.SetBool("plantCollected", true);
            AudioManager.instance.Play("plantgrab");
            plantsCollected++;
            levelLayout[newPlayerCell.x, newPlayerCell.y] = -1;
            playerCell = newPlayerCell;
            //check which plant was collected
            foreach (GameObject plant in plants)
            {
                if (Mathf.Abs(plant.transform.position.x -( newPlayerCell.x * cellLength + levelWorldPosition.x))<0.5f &&
                    Mathf.Abs(plant.transform.position.z - (newPlayerCell.y * cellLength + levelWorldPosition.z))<0.5f)
                {
                    plant.SetActive(false);
                    break;
                }
            }
            if (plantsCollected==plants.Length)
            {
                //if all plant collected, change the particle effect of the starting point
                StartingPoint.instance.FinalParticleEffect();
            }
            facingDirection = movementDirection;
            garbageToMoveIndex = -1;
            //->Store this move in the list moves
            if (moves.Count == 100)
                moves.RemoveAt(0);
            moves.Add(new Move(movementDirection, garbageToMoveIndex, true));
            numberOfMoves++;
            CurrentScore.instance.UpdateCurrentScore(numberOfMoves);
            //<-
            return true;
        }
        
        int indexCellBack= levelLayout[playerCell.x-movementDirection.x, playerCell.y - movementDirection.y];

        if (!grabbingActionTriggered || plantsCollected>0)
        {
            //if the player ends up in an empty cell, go ahead and move
            if (indexCellFront ==-1)
            {
                playerCell = newPlayerCell;
                facingDirection = movementDirection;
                garbageToMoveIndex = -1;
                //->Store this move in the list moves
                if (moves.Count == 100)
                    moves.RemoveAt(0);
                moves.Add(new Move(movementDirection, garbageToMoveIndex, false));
                numberOfMoves++;
                CurrentScore.instance.UpdateCurrentScore(numberOfMoves);
                //<-
                if (playerCell == startCell && plantsCollected == plants.Length)
                {
                    StartCoroutine(TriggerEndOfLevel());
                }
                return true;
            }
            facingDirection = movementDirection;
            garbageToMoveIndex = -1;
            return false;
        }
        else
        {
            if (indexCellFront >=0)//cell in front is occupied by a block
            {
                if (TryGarbageMovement(indexCellFront, movementDirection))
                {
                    //update player position
                    playerCell = newPlayerCell;
                    //trigger garbage movement
                    garbageToMoveIndex = indexCellFront;
                    facingDirection = movementDirection;
                    //->Store this move in the list moves
                    if (moves.Count == 100)
                        moves.RemoveAt(0);
                    moves.Add(new Move(movementDirection, garbageToMoveIndex, false));
                    numberOfMoves++;
                    CurrentScore.instance.UpdateCurrentScore(numberOfMoves);
                    //<-
                    if (playerCell == startCell && plantsCollected == plants.Length)
                    {
                        StartCoroutine(TriggerEndOfLevel());
                    }
                    return true;
                }
                facingDirection = movementDirection;
                garbageToMoveIndex = -1;
                return false;
            }
            else if (indexCellBack >=0)//cell behind has a block
            {
                if (TryGarbageMovement(indexCellBack, movementDirection))
                {
                    //update player position
                    playerCell = newPlayerCell;
                    //trigger garbage movement
                    garbageToMoveIndex = indexCellBack;
                    facingDirection = -movementDirection;//since the robot is pulling a block, it moves facing backwords
                    //->Store this move in the list moves
                    if (moves.Count == 100)
                        moves.RemoveAt(0);
                    moves.Add(new Move(movementDirection, garbageToMoveIndex, false));
                    numberOfMoves++;
                    CurrentScore.instance.UpdateCurrentScore(numberOfMoves);
                    //<-
                    if (playerCell == startCell && plantsCollected == plants.Length)
                    {
                        StartCoroutine(TriggerEndOfLevel());
                    }
                    return true;
                }
                facingDirection = movementDirection;
                garbageToMoveIndex = -1;
                playerCell = newPlayerCell;
                //->Store this move in the list moves
                if (moves.Count == 100)
                    moves.RemoveAt(0);
                moves.Add(new Move(movementDirection, garbageToMoveIndex, false));
                numberOfMoves++;
                CurrentScore.instance.UpdateCurrentScore(numberOfMoves);
                //<-
                if (playerCell == startCell && plantsCollected == plants.Length)
                {
                    StartCoroutine(TriggerEndOfLevel());
                }
                return true;
            }
            else //cell in front is empty
            {
                //update player position
                playerCell = newPlayerCell;
                facingDirection = movementDirection;
                garbageToMoveIndex = -1;
                //->Store this move in the list moves
                if (moves.Count == 100)
                    moves.RemoveAt(0);
                moves.Add(new Move(movementDirection, garbageToMoveIndex, false));
                numberOfMoves++;
                CurrentScore.instance.UpdateCurrentScore(numberOfMoves);
                //<-
                if (playerCell == startCell && plantsCollected == plants.Length)
                {
                    StartCoroutine(TriggerEndOfLevel());
                }
                return true;
            }
        }
    }

    //check if all the cells in which the garbage would end up after moving are empty or
    //occupied buy the same garbage itself. If not, the garbage cannot be pushed and the
    //player cannot move.
    private bool TryGarbageMovement(int garbageIndex, Vector2Int movementDirection)
    {
        if (!garbageArray[garbageIndex].isMovable)
            return false;
        int[,] newGarbageCoverage = garbageArray[garbageIndex].CellsOccupiedAfterMoving(levelWorldPosition, cellLength, movementDirection);
        for (int units = 0; units < newGarbageCoverage.GetLength(0); units++)
        {
            if (levelLayout[newGarbageCoverage[units, 0], newGarbageCoverage[units, 1]] != garbageIndex &&
                levelLayout[newGarbageCoverage[units, 0], newGarbageCoverage[units, 1]] != -1)
                return false;
        }
        //update the map layout with the new position for the moved garbage
        int[,] oldGarbageCoverage = garbageArray[garbageIndex].CellsOccupied(levelWorldPosition, cellLength);
        for (int units = 0; units < oldGarbageCoverage.GetLength(0); units++)
        {
            levelLayout[oldGarbageCoverage[units, 0], oldGarbageCoverage[units, 1]] = -1;
        }
        for (int units = 0; units < newGarbageCoverage.GetLength(0); units++)
        {
            levelLayout[newGarbageCoverage[units, 0], newGarbageCoverage[units, 1]] = garbageIndex;
        }
        return true;
    }

    private IEnumerator TriggerEndOfLevel()
    {
        GameProgress.instance.UpdateGameProgression(SceneManager.GetActiveScene().buildIndex);
        if (numberOfMoves < BestScore.instance.bestScore || BestScore.instance.bestScore == 0)
        {
            int previousBest = PlayerPrefs.GetInt("movesLevel" + SceneManager.GetActiveScene().buildIndex);
            PlayerPrefs.SetInt("movesLevel" + SceneManager.GetActiveScene().buildIndex, numberOfMoves);
            //update best score for the current level
            if (numberOfMoves <= MinimumMoves.maxMovesForAchiement[SceneManager.GetActiveScene().buildIndex - 1] &&
                previousBest > MinimumMoves.maxMovesForAchiement[SceneManager.GetActiveScene().buildIndex - 1])
                PlayerPrefs.SetInt("Achievements", PlayerPrefs.GetInt("Achievements", 0) + 1);
        }
        yield return new WaitForSeconds(0.1f);
        AudioManager.instance.Play("cleared");
        Gui.instance.ActivateLevelClearedMenu();
    }

    public void UndoMove()
    {
        if (moves.Count == 0 || PlayerControl.instance.isMoving)
            return;

        Vector2Int movementDirection = -moves[moves.Count - 1].movementDirection;
        Vector2Int facingDirection =
            (levelLayout[(playerCell.x + movementDirection.x), (playerCell.y + movementDirection.y)] != -1)
            ? movementDirection
            : -movementDirection;

        if (moves[moves.Count - 1].garbageMovedIndex != -1)
        { 
            TryGarbageMovement(moves[moves.Count - 1].garbageMovedIndex, movementDirection); 
        }

        if (moves[moves.Count - 1].plantCollected)//a plant was collected during this move
        {
            levelLayout[playerCell.x, playerCell.y] = -2;
            if (plantsCollected == plants.Length)
                StartingPoint.instance.InitialParticleEffect();//Revert particle effect on starting point
            //check which plant was collected
            foreach (GameObject plant in plants)
            {
                if (Mathf.Abs(plant.transform.position.x - (playerCell.x * cellLength + levelWorldPosition.x)) < 0.5f &&
                    Mathf.Abs(plant.transform.position.z - (playerCell.y * cellLength + levelWorldPosition.z)) < 0.5f)
                {
                    plant.SetActive(true);
                    plantsCollected--;
                    break;
                }
            }
        }

        playerCell += movementDirection;
        //move player and garbage in scene
        StartCoroutine(PlayerControl.instance.PlayerMovementCoroutine(movementDirection, facingDirection, true, moves[moves.Count - 1].garbageMovedIndex));
        numberOfMoves--;
        CurrentScore.instance.UpdateCurrentScore(numberOfMoves);
        
        moves.RemoveAt(moves.Count - 1);
    }
}