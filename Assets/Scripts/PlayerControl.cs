using System.Collections;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    #region DECLARATIONS
    public static PlayerControl instance;

    private ControlsManager inputActions; //script mapping the game control
    public Animator animator {get; private set;}

    public readonly float movementSpeed = 5.0f;
    public readonly float pushingSpeed = 3.5f;
    public readonly float rotationSpeed = 600.0f;
    public float linearSpeed { get; private set; }
    public bool isMoving { get; private set; }
    public bool isPushing { get; private set; }
    public bool isPulling { get; private set; }
    public bool isGrabbing { get; private set; }
    #endregion

    private void Awake()
    {
        instance = this;
        animator = GetComponent<Animator>();
        inputActions = new ControlsManager();
        ControlsSettings.MaskInputBindings(inputActions.Controls);//enable chosen control scheme
        //When the input for the movemet is detected,
        //call the MakeMove() function
        inputActions.Controls.MoveWASD.started += context => MakeMove(context.ReadValue<Vector2>());
        inputActions.Controls.MoveAWEF.started += context => MakeMove(context.ReadValue<Vector2>());
        inputActions.Controls.MoveKeypad.started += context => MakeMove(context.ReadValue<Vector2>());
        //start and cancel grabbing action
        inputActions.Controls.Grab.started += context => SetGrabbing(true);
        inputActions.Controls.Grab.canceled += context => SetGrabbing(false);
        //undo last move
        inputActions.Controls.Undo.started += context => LevelManager.instance.UndoMove();

        linearSpeed = 0f;
        isMoving = false;
        isPushing = false;
        isPulling = false;
        isGrabbing = false;
    }
    private void SetGrabbing(bool _isGrabbing)
    {
        isGrabbing = _isGrabbing;
        animator.SetBool("isGrabbing", _isGrabbing);//play grabbing animation
    }

    private void MakeMove(Vector2 input)
    {
        if (!isMoving && !CameraControl.instance.isRotating)
        {
            if (input.sqrMagnitude != 1)
                return;
            Vector2 movementDirection = CalculateMovementDirection(input);
            Vector2 facingDirection;
            int garbageToMoveIndex;
            //check if there is garbage and if it can be pushed
            bool playerCanMove = LevelManager.instance.TryPlayerMovement(
                new Vector2Int((int)movementDirection.x, (int)movementDirection.y),
                isGrabbing,
                out facingDirection,
                out garbageToMoveIndex);
            StartCoroutine(PlayerMovementCoroutine(movementDirection, facingDirection, playerCanMove, garbageToMoveIndex));
        }
    }

    //return the movement direction of the player based on the input
    //and the rotation of the camera
    private Vector2 CalculateMovementDirection(Vector2 input)
    {
        Vector2[] rotationMatrix90deg = new Vector2[] { new Vector2(0,1), new Vector2(-1,0)}; //rotates input vector by 90 degrees
        Vector2 direction = input;
        for (int i=0; i< CameraControl.instance.currentAngle/90; i++)
        {
            direction = new Vector2(Vector2.Dot(rotationMatrix90deg[0], direction), Vector2.Dot(rotationMatrix90deg[1], direction));
        }
        return direction;
    }

    //1) rotate the player so that they face the facing direction
    //2) move the player alond the movement direction if possible
    public IEnumerator PlayerMovementCoroutine(Vector2 movementDirection, Vector2 facingDirection, bool playerCanMove, int garbageToMoveIndex)
    {
        isMoving = true;
        float angle;
        if (facingDirection.x == 0)
        {
            angle = (1 - facingDirection.y) * 90;
        }
        else
        {
            angle = (2 - facingDirection.x) * 90;
        }
        Quaternion targetRotation = Quaternion.Euler(0, angle, 0);// final rotation
        while (targetRotation != transform.rotation)
        {
            //rotate towards targetRotation
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            yield return null;
        }
        if (playerCanMove)//if there is nothing blocking the way
        {
            if (garbageToMoveIndex != -1)//if the player is pushing/pulling a block of garbage
            {
                linearSpeed = pushingSpeed;
                LevelManager.instance.garbageArray[garbageToMoveIndex].MoveGarbagePiece(new Vector2Int((int)movementDirection.x, (int)movementDirection.y), linearSpeed);
                animator.SetBool("isMovingBlock", true);//play pushing block animation
            }
            else
            {
                linearSpeed = movementSpeed;
                animator.SetBool("isWalking", true);//play moving animation
            }
            AudioManager.instance.Play("botroll");
            Vector3 targetPosition = transform.position + new Vector3(movementDirection.x, 0, movementDirection.y) * LevelManager.instance.cellLength;
            while (targetPosition != transform.position)
            {
                //move towards targetPosition
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, linearSpeed * Time.deltaTime);
                yield return null;
            }
            animator.SetBool("isWalking", false);
            animator.SetBool("isMovingBlock", false);
            isMoving = false;
        }
        else
            isMoving = false;
        yield return null;
    }

    public void TogglePlayerInput(bool disable)
    {
        if (disable)
            inputActions.Controls.Disable();
        else
            inputActions.Controls.Enable();
    }

    private void OnEnable()
    {//enable controls
        inputActions.Controls.Grab.Enable();
        inputActions.Controls.RotateCamera.Enable();
        inputActions.Controls.PauseMenu.Enable();
        inputActions.Controls.Undo.Enable();
    }

    private void OnDisable()
    {//disable controls
        inputActions.Controls.Grab.Disable();
        inputActions.Controls.RotateCamera.Disable();
        inputActions.Controls.PauseMenu.Disable();
        inputActions.Controls.Undo.Disable();
        inputActions.Controls.MoveWASD.Disable();
        inputActions.Controls.MoveAWEF.Disable();
        inputActions.Controls.MoveKeypad.Disable();
    }
}
