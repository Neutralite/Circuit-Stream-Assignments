using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LongMethod
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField]
        Camera playerCamera;

        /* 
         * Player camera X rotation lower and upper limits.
         * Note 1: A greater limit value allows the camera to rotate downards more,
         *       while a lesser limit value allows the camera to rotate upwards more.
         * Note 2: camXRotLowLim should have a greater value than camXRotUpLim.
         */
        [SerializeField]
        int camXRotLowLim = 35;
        [SerializeField]
        int camXRotUpLim = 10;

        // cameraTurnSpeed should be greater than camXRotUpLim to enable vertical camera rotation.
        [SerializeField]
        int cameraTurnSpeed = 45;

        // Update is called once per frame
        void Update()
        {
            CameraMovement();
        }

        private void CameraMovement()
        {
            // Vertical camera rotation
            var t = playerCamera.transform;
            var xRot = t.localRotation.eulerAngles.x - (cameraTurnSpeed * Input.GetAxis("Mouse Y") * Time.deltaTime);
            xRot = Mathf.Clamp(xRot, camXRotUpLim, camXRotLowLim);
            t.localRotation = Quaternion.Euler(xRot, 0, 0);
        }
    }
}

