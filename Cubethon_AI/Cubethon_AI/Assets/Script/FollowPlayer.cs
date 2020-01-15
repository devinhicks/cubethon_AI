using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset; // distance between player and camera

    void Update()
    {
        // change position of camera to offset behind player
        transform.position = player.position + offset;
    }
}
