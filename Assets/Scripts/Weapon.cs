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

        private void Update()
        {
            SelfRotation();

            if (Input.GetMouseButtonDown(0))
            {
                isClicked = true;
                targetPos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                                            Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0); //Mouse Position
            }

            if (isClicked)
            {
                ThrowWeapon();
            }

            if (Vector2.Distance(transform.position, targetPos) <= 0.01f)
            {
                isRotating = false;
            }
        }

        private void ThrowWeapon()
        {
            isRotating = true;
            transform.position = Vector2.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
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
    }
