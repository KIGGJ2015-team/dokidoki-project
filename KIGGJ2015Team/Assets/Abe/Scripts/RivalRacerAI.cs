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
        GameObject[] objects = GameObject.FindGameObjectsWithTag("CheckPoint");
        GameObject   goal    = GameObject.Find("Goal");
        Vector3[]    path    = new Vector3[(objects.Length) * 2 + 3];

        List<int> rand = new List<int>();

        for(int i = 1; i <= objects.Length; i++)
        {
            int r = Random.Range(0, objects.Length);
            foreach(int value in rand)
            {
                if(value == r)
                {
                    goto CONTINUE;
                }
            }

            path[i]   = objects[r].transform.position;
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
        hash.Add("path", path);
        hash.Add("speed", speed);
        hash.Add("easetype", iTween.EaseType.linear);

        iTween.MoveTo(gameObject, hash);
    }

    void UpdatePosition()
    {

    }

    IEnumerator Turning()
    {
        //どちらかに旋回し　障害物を迂回

        float time = Random.Range(2.0f, 5.0f);

        while(true)
        {
            Debug.Log("turn");
            time -= Time.deltaTime;
            if(time <= 0)
            {
                yield break;
            }

            UpdatePosition();
            yield return null;
        }
    }

    void RandomRoot()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "goal")
        {

        }
    }
    #endregion
}