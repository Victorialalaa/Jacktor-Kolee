using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float rotateSpeed; //weapon rotation speed
    [SerializeField] private bool isRotating; // If we throw the weapon, the AXE will self rotate. Otherwise, the axe should stop.

    [SerializeField] private float moveSpeed; //Axe throw speed
    private Vector3 targetPos;
    private bool isClicked;
    private bool isDamaged;
    private bool canCallBack;
    private bool returnWeapon;

    private Transform playerTrans;

    private void Start()
    {
        playerTrans = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        SelfRotation();

        if (Input.GetMouseButtonDown(0) && isClicked == false)
        {
            isClicked = true;
            targetPos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                                        Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0); //Mouse Position
        }

        if (isClicked)
        {
            ThrowWeapon();
        }

        if (Input.GetMouseButtonDown(0) && canCallBack)
        {
            isDamaged = true;
            returnWeapon = true;
        }

        if (returnWeapon)
        {
            BackWeapon();
        }

        if (Vector2.Distance(transform.position, targetPos) <= 0.01f)
        {
            isRotating = false;

            isDamaged = false;

            canCallBack = true;

        }

        if(Vector2.Distance(transform.position, playerTrans.position) <= 0.01f)
        {
            isRotating = false;
            canCallBack = false;
            returnWeapon = false;
            isDamaged = false;
            isClicked = false;
        }
    }

    private void ThrowWeapon()
    {
        isRotating = true;
        transform.position = Vector2.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
        isDamaged = true;
    }

    private void BackWeapon()
    {
        isRotating = true;
        transform.position = Vector2.MoveTowards(transform.position, playerTrans.position, moveSpeed * 5 * Time.deltaTime);
    }

    private void SelfRotation()
    {
        if (isRotating)
        {
            transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
        }
        else
        {
            transform.Rotate(0, 0, 0);
        }
    }

/*
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.GetComponent<HealthBar>().hp -= 25;
        }
    }
*/
}