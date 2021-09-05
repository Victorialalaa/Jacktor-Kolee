using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToClick : MonoBehaviour
{
    public Animator animator;
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
            animator.SetBool("isRunning", true);
        }
        MoveToTarget();

        //locating Player position
        GameObject player = GameObject.Find("Player");
        Transform playerTransform = player.transform;
        Vector3 position = playerTransform.position;

        if (targetPosition == position)
        {
            ReachedDestination();
        }
    }

    private void CalculateTargetPosition()
    {
        var mousePosition = Input.mousePosition;
        var transformedPosition = mainCamera.ScreenToWorldPoint(mousePosition);
        targetPosition = new Vector3(transformedPosition.x, transformedPosition.y, 0);//gets position
    }

    private void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * movementSpeed);
    }

    private void ReachedDestination()
    {
        animator.SetBool("isRunning", false);
    }
}
