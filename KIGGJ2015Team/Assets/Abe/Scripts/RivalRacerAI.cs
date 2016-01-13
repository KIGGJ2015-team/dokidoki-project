// ----- ----- ----- ----- -----
//
// RivalRacerAI
//
// 作成日：
// 作成者：
//
// <概要>
//
//
// ----- ----- ----- ----- -----

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("MyScript/RivalRacerAI")]
public class RivalRacerAI : MonoBehaviour
{
    #region 変数

    [SerializeField, Tooltip("前進スピード")]
    private float speed;

    [SerializeField, Tooltip("弾を出す場所")]
    GameObject spawn;

    [SerializeField, Tooltip("弾のオブジェクト")]
    GameObject bullet;

    [SerializeField, Tooltip("弾のスピード")]
    float bulletSpeed = 1000;

    Hashtable  hash;

    [SerializeField]
    bool isControl = false;

    #endregion


    #region プロパティ



    #endregion


    #region メソッド

    // 初期化処理
    void Awake()
    {
        hash = new Hashtable();
    }

    // 更新前処理
    void Start()
    {
        if(isControl)
        {
            Search();
        }
    }

    IEnumerator ForwardMove()
    {
        yield return null;
    }

    void Search()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("CheckPoint");
        GameObject   goal    = GameObject.Find("Goal");
        Vector3[]    path    = new Vector3[(objects.Length) + 2];

        CheckPointManager manager = GetComponent<CheckPointManager>();

        List<GameObject> checkObjects = new List<GameObject>(objects);

        foreach(GameObject checkpoint in manager.KeyItemsData)
        {
            foreach(GameObject search in objects)
            {
                if(checkpoint == search)
                {
                    checkObjects.Remove(search);
                }
            }
        }

        List<int> rand = new List<int>();

        for(int i = 1; i <= checkObjects.Count; i++)
        {
            int r = Random.Range(0, checkObjects.Count);
            foreach(int value in rand)
            {
                if(value == r)
                {
                    goto CONTINUE;
                }
            }

            path[i]   = checkObjects[r].transform.position;
            rand.Add(r);

            continue;

            CONTINUE:
                //乱数が決まるまでループ
                i -= 1;
                continue;
        }

        path[0] = transform.position;
        path[path.Length-1] = goal.transform.position;

        Debug.Log(path);
        hash.Clear();
        hash.Add("path", path);
        hash.Add("speed", speed);
        hash.Add("easetype", iTween.EaseType.linear);
        hash.Add("onupdatetarget", gameObject);
        hash.Add("onupdate", "UpdatePosition");

        iTween.MoveTo(gameObject, hash);
    }

    void UpdatePosition()
    {
        Debug.Log("UpdatePosition");

        if(!isControl)
        {
            StartCoroutine(NoControl());
            iTween.Stop(gameObject);
        }
    }

    IEnumerator NoControl()
    {
        while(true)
        {
            for(float i = 0; i >= 2.0f; i += Time.deltaTime)
            {
                transform.position += Vector3.forward * speed * Time.deltaTime;
                yield return null;
            }

            if(GetComponent<CheckPointManager>().IsGetAllKey)
            {
                continue;
            }

            isControl = true;
            Search();
            yield break;
        }
    }

    void RandomRoot()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "goal")
        {
            isControl = false;
        }
        else if(other.tag == "Bullet")
        {
            isControl = false;
        }
    }
    #endregion
}