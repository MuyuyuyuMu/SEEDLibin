using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TanHuang : MonoBehaviour
{
    // Start is called before the first frame update
    private float rotate = 0;
    private  float lastRotation = 0;
    bool canRotate = true;
    bool reback = false;
    public GameObject player;
    public float time = 0f;
    public Vector3 startRotate;
    private Rigidbody2D rb;
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
        }

        if (rotate < 30)
        {
            canRotate = true;
        }

        if (rotate > 80 && !reback)
        {
            reback = true;
            startRotate = gameObject.transform.eulerAngles;
            gameObject.transform.eulerAngles = startRotate;
        }

        if (reback)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = 0;
            time += Time.deltaTime * 10;
            gameObject.transform.eulerAngles = Vector3.Lerp(startRotate, new Vector3(0,0,0), time/3f);
            if (time >= 3f)
            {
                reback = false;
                time = 0;
            }
            Debug.Log(time);
        }
    }
}
