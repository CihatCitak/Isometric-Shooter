using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] Transform startPositionTransform;
    [SerializeField] Transform endPositionTransform;

    private Vector3 lastGetPatrolPos;

    private Vector3 startPatronPos;
    private Vector3 endPatronPos;

    private void Awake()
    {
        startPatronPos = startPositionTransform.position;
        endPatronPos = endPositionTransform.position;
    }

    public Vector3 GetPatrolPosition()
    {
        lastGetPatrolPos = (lastGetPatrolPos != startPatronPos) ? startPatronPos : endPatronPos;

        return lastGetPatrolPos;
    }
}
