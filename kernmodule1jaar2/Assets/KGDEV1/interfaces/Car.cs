using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterfaceTest
{
    public class Car : MonoBehaviour, IControllable
    {
        const float ROTATE_SPEED = 180f;
        const float DRIVE_SPEED = 50f;
        const bool VIEW = false;

        public bool isViewable
        {
            get
            {
                return VIEW;
            }
        }

        public Vector3 Position
        {
            get
            {
                return transform.position;
            }
        }

        public float Zoom
        {
            get
            {
                return 2f;
            }
        }

        public void Enter()
        {

        }

        public void Exit()
        {

        }

        public void HandleInput( float h, float v )
        {
            if ( v < 0 ) h = -h;
            transform.Rotate(0, h * Time.deltaTime * ROTATE_SPEED, 0, Space.Self);
            transform.Translate(v * transform.forward * Time.deltaTime * DRIVE_SPEED, Space.World);
        }
    }
}