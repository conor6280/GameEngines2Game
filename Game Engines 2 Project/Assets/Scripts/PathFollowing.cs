using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollowing : MonoBehaviour
{
    public GameObject Player;
    const float MAX_MOVE_DISTANCE = 200.0f;
    const float DECELERATION_FACTOR = 0.6f;
    float moveDistance;
    Vector3 source;
    Vector3 target;
    Vector3 outputVelocity;
    Vector3 directionToTarget;
    Vector3 velocityToTarget;
    float distanceToTarget;
    float speed;

    void FixedUpdate()
    {
        moveDistance = MAX_MOVE_DISTANCE * Time.deltaTime;
        source = transform.position;
        if (Player != null)
        {
            target = Player.transform.position;
        }
        else
        {
            target = Vector3.zero;
        }
        outputVelocity = Arrive(source, target);
        GetComponent<Rigidbody>().AddForce(outputVelocity, ForceMode.VelocityChange);
    }

    private Vector3 Seek(Vector3 source, Vector3 target, float moveDistance)
    {
        directionToTarget = Vector3.Normalize(target - source);
        velocityToTarget = moveDistance * directionToTarget;
        return velocityToTarget - GetComponent<Rigidbody>().velocity;
    }

    private Vector3 Arrive(Vector3 source, Vector3 target)
    {
        distanceToTarget = Vector3.Distance(source, target);
        directionToTarget = Vector3.Normalize(target - source);
        speed = (distanceToTarget / DECELERATION_FACTOR / 5) * 5;
        velocityToTarget = speed * directionToTarget;
        return velocityToTarget - GetComponent<Rigidbody>().velocity;
    }
}
