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

    [SerializeField, Tooltip("ロール速度")]
    private float rollSpeed;

    [SerializeField, Tooltip("弾を出す場所")]
    GameObject spawn;

    [SerializeField, Tooltip("弾のオブジェクト")]
    GameObject bullet;

    [SerializeField, Tooltip("弾のスピード")]
    float bulletSpeed = 1000;

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
        StartCoroutine(Normal());
    }

    void UpdatePosition()
    {
        vec = transform.rotation;
        transform.Rotate(transform.up , RotateSpeed * horizontalSpeed, Space.World);
        transform.Rotate(Vector3.right, RotateSpeed * verticalSpeed  , Space.Self);

        transform.Translate(Vector3.forward * speed      * Time.deltaTime, Space.Self);

        if(verticalSpeed == 0 && horizontalSpeed == 0)
        {
            vec.z = 0;
            vec.x = 0;
            transform.rotation = Quaternion.Lerp(transform.rotation, vec, 0.05f);
            Debug.Log("keep");
        }
    }

    // 更新処理
    IEnumerator Normal()
    {
        while(true)
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hitInfo;

            if(!Physics.Raycast(ray, out hitInfo, 20))
            {
                //どこに目標物があるのかを探し　そっちの方向に旋回
                SearchNextPoint();
            }
            else //当たった場合
            {
                if(hitInfo.collider.tag == "Obstacle" ||
                   hitInfo.collider.tag == "Player")
                {
                    //旋回
                    StartCoroutine(Turning());
                    StopCoroutine(Normal());
                }
                else if(hitInfo.collider.tag == "Barrier")
                {
                    //弾を撃つ
                    GameObject obj = Instantiate(bullet) as GameObject;
                    obj.transform.position = spawn.transform.position;
                    Vector3 force;
                    force = this.gameObject.transform.forward * bulletSpeed;
                    obj.GetComponent<Rigidbody>().AddForce(force);
                }
                else
                {
                    horizontalSpeed = 0;
                    verticalSpeed   = 0;
                }
            }

            UpdatePosition();
            yield return null;
        }
    }

    IEnumerator Turning()
    {
        //どちらかに旋回し　障害物を迂回
        horizontalSpeed = Random.Range(-1.0f, 1.0f);
        verticalSpeed   = Random.Range(-1.0f, 1.0f);

        float time = Random.Range(2.0f, 5.0f);

        while(true)
        {
            time -= Time.deltaTime;
            if(time <= 0)
            {
                StartCoroutine(Normal());
                StopCoroutine(Turning());
            }

            UpdatePosition();
            yield return null;
        }
    }

    void SearchNextPoint()
    {
        //どこに目標物があるのかを探し　そっちの方向に旋回
        Plane hPlane = new Plane(transform.position, transform.right); 
        Plane vPlane = new Plane(transform.position, transform.up);

        Vector3 nextPosition = nextObject.transform.position;

        horizontalSpeed = (hPlane.GetSide(nextPosition)) ? 1 : -1;
        verticalSpeed   = (vPlane.GetSide(nextPosition)) ? 1 : -1;
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