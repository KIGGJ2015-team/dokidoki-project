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

    [SerializeField, Tooltip("旋回スピード")]
    private float RotateSpeed;

    [SerializeField, Tooltip("ブースト速度")]
    private float boostSpeed;

    [SerializeField, Tooltip("ロール速度")]
    private float rollSpeed;

    float time = 0;         //時間計測
    Quaternion vec;
    GameObject fighter;

    float horizontalSpeed = 0;
    float verticalSpeed = 0;

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
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;

        if(!Physics.Raycast(ray, out hitInfo))
        {
            Plane hPlane = new Plane(transform.position, transform.right); 
            Plane vPlane = new Plane(transform.position, transform.up);

            Vector3 nextPosition = nextObject.transform.position;

            horizontalSpeed = (hPlane.GetSide(nextPosition)) ? 1 : -1;
            verticalSpeed   = (vPlane.GetSide(nextPosition)) ? 1 : -1;
        }
        else
        {
            if(hitInfo.collider.tag == "Obstacle" ||
               hitInfo.collider.tag == "Player")
            {

            }
            else
            {
                horizontalSpeed = 0;
                verticalSpeed   = 0;
            }
        }

        vec = transform.rotation;
        transform.Rotate(transform.up , RotateSpeed * horizontalSpeed, Space.World);
        transform.Rotate(Vector3.right, RotateSpeed * verticalSpeed  , Space.Self);

        if (Input.GetAxisRaw("Boost") < 1)
        {
            transform.Translate(Vector3.forward * speed      * Time.deltaTime, Space.Self);
        }
        else
        {
            transform.Translate(Vector3.forward * boostSpeed * Time.deltaTime, Space.Self);
        }
        //rolling();
        //keepStability();
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
	#endregion
}