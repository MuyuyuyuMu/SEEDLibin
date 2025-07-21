using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonTriger : MonoBehaviour
{
   void OnTriggerEnter2D(Collider2D other)
   {
      if(other.tag == "Player")
      GetComponentInParent<TanHuang>().player =  other.gameObject;
   } 
   void OnTriggerExit2D(Collider2D other)
   {
      if(other.tag == "Player")
      GetComponentInParent<TanHuang>().player =  null;
   }
}
