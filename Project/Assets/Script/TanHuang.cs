using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TanHuang : MonoBehaviour
{
    // Start is called before the first frame update
    private float rotate = 0;
    bool canRotate = true;
    public GameObject player;
    private Rigidbody2D rb;
    private Vector3 rotateStart;
    private float time;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
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
            rotateStart = gameObject.transform.eulerAngles;
        }
        if (!canRotate)
        {
            time+=Time.deltaTime;
            gameObject.transform.eulerAngles = Vector3.Lerp(rotateStart, new Vector3(0,0,180f), time/0.5f);
            if (time >= 0.5f)
            {
                time = 0;
                canRotate = true;
                gameObject.transform.eulerAngles = new Vector3(0,0,0);
                rotate = 0;
                rb.angularVelocity = 0;
                rb.velocity = Vector2.zero;;
            }
        }
    }
}
