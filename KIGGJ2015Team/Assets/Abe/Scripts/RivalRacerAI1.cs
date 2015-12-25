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
public class RivalRacerAI1 : MonoBehaviour
{
    #region 変数

    //[Header("タイトル")]

    [SerializeField, Tooltip("動くスピード")]
    float moveSpeed;

    private List<GameObject> checkPoints = new List<GameObject>();
    GameObject nextObject;
    

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
        checkPoints.AddRange(objects);

        SearchNearCheckPoint();
    }

    // 更新処理
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, nextObject.transform.position, moveSpeed);
        Physics.Raycast(transform.position, transform.forward, 40.0f, LayerMask.GetMask(new string[] { "Obstacle" , "ojama"}));
    }

    void SearchNearCheckPoint()
    {
        float distance = float.MaxValue;
        foreach(var checkPoint in checkPoints)
        {
            float dis = Vector3.Distance(transform.position, checkPoint.transform.position);
            if(dis < distance)
            {
                distance = dis;
                nextObject = checkPoint;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag != "CheckPoint")
        {
            return;
        }

        foreach(var checkPoint in checkPoints)
        {
            if(checkPoint == other.gameObject)
            {
                checkPoints.Remove(checkPoint);
                if(checkPoints.Count == 0)
                {
                    nextObject = GameObject.Find("Goal");
                    return;
                }

                SearchNearCheckPoint();
                return;
            }
        }
    }

    public void Remove(GameObject key)
    {
        checkPoints.Remove(key);
    }
	#endregion
}