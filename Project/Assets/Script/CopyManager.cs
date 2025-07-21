using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CopyManager 
{
    public List<Vector2> copy1 = new List<Vector2>();
    public List<Vector2> copy2 = new List<Vector2>();
    public GameObject Copy1;
    public GameObject Copy2;
    public bool isFly = false;
    public bool isPase = false;
    public Vector3 respwan = Vector3.zero;

    bool isPlay1 = false;
    bool isPlay2 = false;
    int playCount1 = 0;
    int playCount2 = 0;
    public  static CopyManager Instance = new CopyManager();

    public void Init()
    {
        Copy1 = GameObject.Find("Copy1");
        Copy2 = GameObject.Find("Copy2");
    }
    public void RecordCopy1(Vector2 pos)
    {
        copy1.Add(pos);
    }
    public void RecordCopy2(Vector2 pos)
    {
        copy2.Add(pos);
    }
    public void OnUpdate()
    {
        if (Input.GetKeyDown(KeyCode.J) && !isPlay1)
        {
            isPlay1 = true;
            Copy1.gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.K) && !isPlay2)
        {
            isPlay2 = true;
            Copy2.gameObject.SetActive(true);
            
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            isPase =!isPase;;
        }
        if (playCount1 < copy1.Count && isPlay1 && !isPase)
        {
            Copy1.transform.position = copy1[playCount1];
            playCount1++;
        }
        if (playCount1 == copy1.Count)
        {
            isPlay1 = false;
            playCount1 = 0;
            Copy1.gameObject.SetActive(false);
        }

        if (playCount2 < copy2.Count && isPlay2 && !isPase)
        {
            Copy2.transform.position = copy2[playCount2];
            playCount2++;
        }
        if (playCount2 == copy2.Count)
        {
            isPlay2 = false;
            playCount2 = 0;
            Copy2.gameObject.SetActive(false);
        }
    }
}
