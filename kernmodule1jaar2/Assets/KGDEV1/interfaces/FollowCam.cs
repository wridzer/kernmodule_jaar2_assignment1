using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterfaceTest
{
    [RequireComponent(typeof(Camera))]
    public class FollowCam : MonoBehaviour
    {
        private Camera cameraComponent;
        private IViewable target;

        private float currentZoom = 1f;
        private float startZoom = 1f;
        private float targetZoom = 1f;
        private float zoomTimer = 1f;

        void Awake()
        {
            cameraComponent = GetComponent<Camera>();
        }

        void LateUpdate() {
            IViewable newTarget = Player.GetEntity();
            if ( target != newTarget )
            {
                target = newTarget;
                UpdateZoom(target.Zoom);
            }

            if ( target != null)
            {
                Vector3 position = transform.position;
                position.x = target.Position.x;
                position.z = target.Position.z;
                transform.position = position;

                if ( zoomTimer < 1 )
                {
                    zoomTimer = Mathf.Clamp01(zoomTimer + Time.deltaTime);
                    currentZoom = Mathf.Lerp(startZoom, targetZoom, zoomTimer);

                    cameraComponent.orthographicSize = 10f * currentZoom;
                }
            }
        }

        void UpdateZoom( float newZoom )
        {
            startZoom = currentZoom;
            targetZoom = newZoom;
            zoomTimer = 0;
        }
    }
}