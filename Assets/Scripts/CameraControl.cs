using System.Collections;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    #region DECLARATIONS
    public static CameraControl instance;
    
    private ControlsManager inputActions; //script mapping game controls
    public bool isRotating { get; private set; }
    private float rotationSpeed;
    public int currentAngle { get; private set; }
    
    //For Camera Sway
    private Vector3 originalpos;
    private Vector3 newpos;
    private float speed = 0.00025f;
    private float x, z;
    #endregion

    private void Awake()
    {
        instance = this;

        inputActions = new ControlsManager();
        //When the input for rotating the camera is detected
        //Call function Rotate90deg()
        inputActions.Controls.RotateCamera.performed += context => Rotate90deg(context.ReadValue<float>());
    }

    private void Start()
    {
        isRotating = false;
        rotationSpeed = 100.0f;
        currentAngle = 90;

        originalpos = transform.localPosition;
        newpos = transform.localPosition + new Vector3(0.1f,0f,0.1f);
    }

    //start the coroutine to rotate the focal point of the camera by 90 degrees
    private void Rotate90deg(float sign)
    {
        if (!isRotating)
        {
            isRotating = true;
            currentAngle = (360+ currentAngle + 90*(int)sign) % 360; // increse/decrease current angle by 90 degrees
            StartCoroutine(RotateCameraCoroutine());
        }
    }

    //rotate the camera 90 degrees about the focal point
    IEnumerator RotateCameraCoroutine()
    {
        Quaternion targetRotation = Quaternion.Euler(0, currentAngle, 0);
        while(targetRotation!=transform.rotation)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            yield return null;
        }
        isRotating = false;
        yield return null;
    }

    public void ToggleCameraRotation(bool disable)
    {
        if (disable)
            inputActions.Controls.Disable();
        else
            inputActions.Controls.Enable();
    }

    private void OnEnable()
    {
        inputActions.Controls.Enable();
    }
    
    private void OnDisable()
    {
        inputActions.Controls.Disable();
    }

    //random drift of the camera
    private void LateUpdate()
    {
        if (Vector3.Distance(transform.position, newpos) < 0.001f)
        {
            x = Random.Range(originalpos.x - 0.2f, originalpos.x + 0.2f);
            z = Random.Range(originalpos.z - 0.2f, originalpos.z + 0.2f);
            newpos = new Vector3(x, 0, z);
        }

        transform.localPosition = Vector3.MoveTowards(transform.localPosition,newpos,speed);
    }
}
