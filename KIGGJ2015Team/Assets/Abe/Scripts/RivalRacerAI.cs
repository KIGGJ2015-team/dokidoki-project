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

    }

    // 更新前処理
    void Start()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("CheckPoint");

        int rand = Random.Range(0, objects.Length - 1);

        Vector3 destination = objects[rand].transform.position;

        Vector3[] path = new Vector3[6];
        path[0] = transform.position;
        path[5] = destination;
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
        
    }
	#endregion
}