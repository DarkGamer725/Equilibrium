using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class FloorBehaviour : MonoBehaviour
{
    [SerializeField] float rotationLimit;
    [SerializeField] float rotationValue;

    [SerializeField] PauseMenu pauseMenu;

    float rotationX = 0.0f;
    float rotationZ = 0.0f;

    bool gamePaused;

    private void Start()
    {
        pauseMenu.RegisterOnPause(OnPause);
        gamePaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gamePaused)
        {
            if (Input.GetKey(KeyCode.W))
            {
                RotateZ(true);
            }
            if (Input.GetKey(KeyCode.S))
            {
                RotateZ(false);
            }
            if (Input.GetKey(KeyCode.D))
            {
                RotateX(true);
            }
            if (Input.GetKey(KeyCode.A))
            {
                RotateX(false);
            }
        }
    }

    void RotateX(bool positive)
    {
        rotationX = transform.eulerAngles.x;
        rotationZ = transform.eulerAngles.z;
        if (positive) // Que funcione la W
        {
            if (rotationX > 270 || rotationX < rotationLimit)
            {
                transform.eulerAngles = new Vector3(rotationX + rotationValue, 0, rotationZ);
            }
        }
        else // Que funcione la S
        {
            if (rotationX < 90 || rotationX > 360 - rotationLimit)
            {
                transform.eulerAngles = new Vector3(rotationX - rotationValue, 0, rotationZ);
            }
        }
    }

    void RotateZ(bool positive)
    {
        rotationX = transform.eulerAngles.x;
        rotationZ = transform.eulerAngles.z;
        if (positive) // Que funcione la A
        {
            if (rotationZ > 270 || rotationZ < rotationLimit)
            {
                transform.eulerAngles = new Vector3(rotationX, 0, rotationZ + rotationValue);
            }
        }
        else // Que funcione la D
        {
            if (rotationZ < 90 || rotationZ > 360 - rotationLimit )
            {
                transform.eulerAngles = new Vector3(rotationX, 0, rotationZ - rotationValue);
            }
        }
        
    }

    private void OnPause(bool pause)
    {
        gamePaused = pause;
        transform.eulerAngles = new Vector3 (0, 0, 0);
    }
}
