using UnityEngine;
using System.Collections;

public class enemyAI_second : MonoBehaviour {
    #region 変数
    public float speed ;
    private float rotationSmooth = 1f;
    private Vector3 targetPosition;
    private float changeTargetSqrDistance = 40f;
    bool PlayerFind = false;
    bool Check0Find = false;
    bool Check1Find = false;
    bool Check2Find = false;
    [SerializeField]
    bool urochoro = true;
    [SerializeField]
    private Transform player;
    [SerializeField]
    private Transform Check0;
    [SerializeField]
    private Transform Check1;
    [SerializeField]
    private Transform Check2;
    [SerializeField]
    float Playerrange = 10f;
    [SerializeField]
    float Checkrange = 10f;
    //CharacterController _controller;
   // Transform _transform;
    Vector3 dist0;
    Vector3 dist1;
    Vector3 dist2;
    Vector3 dist3;
  
  
    #endregion

    #region インスタンス
    private void Start()
    {
        
        targetPosition = GetRandomPositionOnLevel();
        player = GameObject.FindWithTag("Player").transform;
        Check0 = GameObject.FindWithTag("check").transform;
        Check1 = GameObject.FindWithTag("check1").transform;
        Check2 = GameObject.FindWithTag("check2").transform;
       // _controller = GetComponent<CharacterController>();
        //_transform = GetComponent<Transform>();
    }
    #endregion
    private void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < Playerrange)
        {
            PlayerFind = true;
        }

            if (urochoro)
        {
                Debug.Log("urochoro");
                // 目標地点との距離が小さければ、次のランダムな目標地点を設定する
                float sqrDistanceToTarget = Vector3.SqrMagnitude(transform.position - targetPosition);
                if (sqrDistanceToTarget < changeTargetSqrDistance)
                {
                    targetPosition = GetRandomPositionOnLevel();
                }        
                           // 目標地点の方向を向く
                Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSmooth);

                // 前方に進む
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
             
            
        }
        else
        if (!urochoro)
        {
            Debug.Log("urochoroPPPPP");
            if (Check0Find)
            {
                CheckPOINT0();
            }
            else
             if (!Check0Find)
            {
                return;
            }

            if (Check1Find)
            {
                CheckPOINT1();
            }
            else
            if (!Check1Find)
            {
                return;
            }

            if (Check2Find)
            {
                CheckPOINT2();
            }
            else
            if (!Check2Find)
            {
                return;
            }

            if (PlayerFind)
            {
                PlayerwoOU();
            }
            else
            if (!PlayerFind)
            {
                return;
            }
        }
    }




    void PlayerwoOU()
    {
        Debug.Log("player");
        dist0 = player.transform.position - transform.position;
        if (Vector3.Distance(transform.position, player.transform.position) < Playerrange)
        {
            urochoro = false;
            Quaternion targetRotation = Quaternion.LookRotation(player.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSmooth);

            // 前方に進む
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if (Vector3.Distance(transform.position, player.transform.position) > Playerrange)
        {
            PlayerFind = false;
          
        }
    }

    void CheckPOINT0()
    {
        Debug.Log("check");
        dist1 = Check0.transform.position - transform.position;
        if (Vector3.Distance(transform.position, Check0.transform.position) < Checkrange)
        {
            urochoro = false;
            Quaternion targetRotation = Quaternion.LookRotation(Check0.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSmooth);

            // 前方に進む
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, Check0.transform.position) < Playerrange)
            {
                Check0Find = false;
                
            }
        }

    }

    void CheckPOINT1()
    {
        Debug.Log("check1");
        dist2 = Check1.transform.position - transform.position;
        if (Vector3.Distance(transform.position, Check1.transform.position) < Checkrange)
        {
            urochoro = false;
            Quaternion targetRotation = Quaternion.LookRotation(Check1.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSmooth);

            // 前方に進む
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, Check1.transform.position) < Playerrange)
            {
                Check1Find = false;
                PlayerwoOU();
            }
        }
    }

    void CheckPOINT2()
    {
        Debug.Log("check2");
        dist3 = Check2.transform.position - transform.position;
        if (Vector3.Distance(transform.position, Check2.transform.position) < Checkrange)
        {
            urochoro = false;
            Quaternion targetRotation = Quaternion.LookRotation(Check2.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSmooth);

            // 前方に進む
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, Check2.transform.position) < Playerrange)
            {
                Check2Find = false;
                PlayerwoOU();
            }
        }

    }

    

    public Vector3 GetRandomPositionOnLevel()
    {
        float levelSize = 55f;
        return new Vector3(Random.Range(-levelSize, levelSize), 0, Random.Range(-levelSize, levelSize));
    }



    void OnTriggerEnter(Collider coll)
    //void OnControllerColliderHit(ControllerColliderHit coll)
    {
        if (coll.gameObject.tag == "check")
        {
            Check0Find = false;
            Debug.Log("false000");
        }

        if (coll.gameObject.tag == "check1")
        {
            Check1Find = false;
            Debug.Log("false111");
        }

        if (coll.gameObject.tag == "check2")
        {
            Check2Find = false;
            Debug.Log("false222");
        }

    }

   
}
