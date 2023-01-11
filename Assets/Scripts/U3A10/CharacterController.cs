using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LongMethod
{
    public class CharacterController : MonoBehaviour
    {
        [SerializeField]
        Rigidbody rigidBody;

        [SerializeField]
        int movementSpeed = 7;
        [SerializeField]
        int turnSpeed = 45;
        [SerializeField]
        int jumpModifier = 10;

        void Start() {
            // Keeps cursor locked in game window
            Cursor.lockState = CursorLockMode.Locked;
        }
        void Update()
        {
            PlayerMovement();
            SpecialActions();
        }

        private void PlayerMovement()
        {
            // Horizontal player movement
            var mov = (Input.GetAxis("Horizontal") * transform.right + Input.GetAxis("Vertical") * transform.forward).normalized;
            transform.position += movementSpeed * Time.deltaTime * mov;

            // Horizontal player rotation
            float yRot = transform.rotation.eulerAngles.y + (turnSpeed * Input.GetAxis("Mouse X") * Time.deltaTime);
            transform.localRotation = Quaternion.Euler(0, yRot, 0);
        }

        private void SpecialActions()
        {
            if (Input.GetButtonDown("Jump"))
                rigidBody.velocity = Vector3.up * jumpModifier;
        }
    }
}
