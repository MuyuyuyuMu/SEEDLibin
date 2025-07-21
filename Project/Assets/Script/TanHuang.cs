using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TanHuang : MonoBehaviour
{
    // Start is called before the first frame update
    private float rotate = 0;
    private  float lastRotation = 0;
    bool canRotate = true;
    public GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotate = gameObject.transform.eulerAngles.z;
        if (rotate > 30 && canRotate)
        {
            if (player != null && player.tag == "Player")
            {
                player.GetComponent<Rigidbody2D>().AddForce(new Vector2(-9f, 12f), ForceMode2D.Impulse);
                CopyManager.Instance.isFly = true;
            }
            canRotate = false;
        }

        if (rotate < 10)
        {
            canRotate = true;
        }
    }
}
