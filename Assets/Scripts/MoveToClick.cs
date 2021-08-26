using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToClick : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    private Vector3 targetPosition;
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetMouseButtonDown(1))
        {
            CalculateTargetPosition();
            Debug.Log(targetPosition);
        }

        MoveToTarget();
    }

    private void CalculateTargetPosition()
    {
        var mousePosition = Input.mousePosition;
        var transformedPosition = mainCamera.ScreenToWorldPoint(mousePosition);
        targetPosition = new Vector3(transformedPosition.x, transformedPosition.y, 0);
    }

    private void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * movementSpeed);
    }

    public void ReachedDestination()
    {
    }
}
