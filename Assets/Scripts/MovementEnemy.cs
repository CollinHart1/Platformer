using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEnemy : MonoBehaviour
{
   public Vector3 position1;
   public Vector3 position2;
   public float speed;
   void Update()
    {
        float time = Mathf.PingPong(Time.time * speed, 1);
        transform.position = Vector3.Lerp(position1, position2, time);
        transform.Rotate (new Vector3 (0, 0, 45) * Time.deltaTime);
    }
}
