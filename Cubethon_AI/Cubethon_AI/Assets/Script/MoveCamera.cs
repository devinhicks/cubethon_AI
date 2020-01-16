using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public float moveSpeed = 10f; // max translation velocity of camera
    public float rotSpeed = 15f; // max rotation velocity of camera

    // Update is called once per frame
    void Update()
    {
        // Apply rotation to camera with wasd
        if (Input.GetKey(KeyCode.A)) // A key rotates to left
        {
            transform.eulerAngles += 
                new Vector3(0f, -rotSpeed * Time.deltaTime, 0f);
        }

        if (Input.GetKey(KeyCode.D)) // D key rotates to right
        {
            transform.eulerAngles +=
                new Vector3(0f, rotSpeed * Time.deltaTime, 0f);
        }

        if (Input.GetKey(KeyCode.W)) // W key pitches up
        {
            transform.eulerAngles +=
                new Vector3(rotSpeed * Time.deltaTime, 0f, 0f);
        }

        if (Input.GetKey(KeyCode.S)) // S key pitches down
        {
            transform.eulerAngles +=
                new Vector3(-rotSpeed * Time.deltaTime, 0f, 0f);
        }

        // Apply translation to camera with arrow keys
        if (Input.GetKey(KeyCode.LeftArrow)) // Left arrow moves to left
        {
            transform.position += 
                new Vector3(-moveSpeed * Time.deltaTime, 0f, 0f);
        }

        if (Input.GetKey(KeyCode.RightArrow)) // Right arrow moves to right
        {
            transform.position +=
                new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);
        }

        if (Input.GetKey(KeyCode.UpArrow)) // Up arrow moves forward
        {
            transform.position +=
                new Vector3(0f, 0f, moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow)) // Down arrow moves backward
        {
            transform.position +=
                new Vector3(0f, 0f, -moveSpeed * Time.deltaTime);
        }
    }
}

