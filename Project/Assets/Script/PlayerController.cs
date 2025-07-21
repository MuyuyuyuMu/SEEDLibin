using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private Animator animator;
    bool isRecord1 = false;
    bool isRecord2 = false;
    private float time = 5f;
    private float check = 0.5f;
    private float check1 = 0.5f;
    private bool isLanding = false;
    void Start()
    { 
        rb = GetComponent<Rigidbody2D>(); 
        animator = GetComponent<Animator>();
        CopyManager.Instance.Init();
    }

    // Update is called once per frame
    void Update()
    {
        
        RaycastHit2D hit =  Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 0.6f), Vector2.zero);
        if (hit.collider != null &&hit.collider.tag != "Trigger")
        {
            CopyManager.Instance.respwan = gameObject.transform.position;
        }
        if (CopyManager.Instance.isFly)
        {
            check -= Time.deltaTime;
        }
        if (hit.collider != null && CopyManager.Instance.isFly && check < 0)
        {
            CopyManager.Instance.isFly = false;
            check = 0.5f;
            check1 = 0.5f;
            isLanding = true;
        }
        check1 -= Time.deltaTime;
        if (check1 < 0)
        {
            isLanding = false;
            check1 = 0.5f;
        }
        if (isLanding)
        {
            return;
        }
        if (CopyManager.Instance.isFly)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.1f)
        {
            rb.AddForce( Vector2.up*9,ForceMode2D.Impulse);
        }
        float x =Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(x*2, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.U) && !isRecord1)
        {
            isRecord1 = true;
            CopyManager.Instance.copy1.Clear();
        }
     
        if (Input.GetKeyDown(KeyCode.I) && !isRecord2)
        {
           isRecord2 = true;
            CopyManager.Instance.copy2.Clear();
           
        }

        
        if (isRecord1)
        {
            CopyManager.Instance.RecordCopy1(gameObject.transform.position);
        }
        if (isRecord2)
        {
            CopyManager.Instance.RecordCopy2(gameObject.transform.position);
        }
        time -= Time.deltaTime;
        if (time <= 0)
        {
            isRecord1 = false;
            isRecord2 = false;
            time = 5f;
        }
        CopyManager.Instance.OnUpdate();
    }
}
