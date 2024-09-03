using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
     public Transform target;
      public Vector3 offset = new Vector3(0, 2, -10);

      private void LateUpdate()
      {
          transform.position = target.position + offset;
      }
    /*
          //xây dựng camera
             public Transform target;
             public Vector3 offset;
             [Range(1,10)]
             public float smoothSpeed = 0.125f;
             public Vector3 min, max;
             private void FixedUpdate()
             {
                 Follow();
             }
             void Follow()
             {
                 Vector3 playerPosition = target.position + offset;

                 Vector3 boundPosition = new Vector3(
                     Mathf.Clamp(playerPosition.x, min.x, max.x),
                     Mathf.Clamp(playerPosition.y, min.y, max.y),
                     Mathf.Clamp(playerPosition.z, min.z, max.z));

                 Vector3 smoothedPosition = Vector3.Lerp(transform.position,boundPosition, smoothSpeed*Time.fixedDeltaTime);
                  transform.position = smoothedPosition;
                // transform.position = playerTransform.position + offset;
             }
          */
}
