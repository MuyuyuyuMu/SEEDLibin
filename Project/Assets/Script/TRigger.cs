using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TRigger : MonoBehaviour
{
   public GameObject player;
   public bool isMove;
   private float time = 0;
   private float y;
   private float x;
   public void OnTriggerEnter2D(Collider2D other)
   {
      if (Vector2.Distance(player.transform.position, new Vector2(-2.9f, 6.7f)) <= 2)
      {
         isMove = true;
         y = player.transform.position.y;
         x = player.transform.position.x;
      }
   }

   private void Update()
   {
      if (isMove)
      {
         time+=Time.deltaTime;
         player.transform.position = new Vector2(Mathf.Lerp(x, 31f, time/3f),y);
         if (time >= 3f)
         {
            isMove = false;
         }
      }
   }
}
