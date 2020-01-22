using UnityEngine;

public class Wander : MonoBehaviour
{
    public Vector3 lookHere; // point at which object will be facing
    public float maxSpeed = 3f;
    public float maxRotation = 15f; // limits degrees in which character can turn
    private int delay = 0;

    void Update()
    {
        // update object's translation every frame
        transform.position += transform.TransformDirection(Vector3.forward)
            * maxSpeed * Time.deltaTime;

        if (delay == 50) // if 50 frames have passed,
        {
            WanderAbout(); // randomly choose new direction to move in
            this.transform.eulerAngles = lookHere * Time.deltaTime;
            delay = 0;  // and reset
        }
        else
        {
            delay++; // otherwise increment the delay
        }
    }

    void WanderAbout()
    {
        float angle = Random.Range(-maxRotation, maxRotation);
        angle *= Mathf.Rad2Deg;

        lookHere = new Vector3(0, angle, 0);

        // and have object look at that point

    }

    float RandomBinomial()
    {
        return Random.Range(0.0f, 1.0f) - Random.Range(0.0f, 1.0f);
    }
}