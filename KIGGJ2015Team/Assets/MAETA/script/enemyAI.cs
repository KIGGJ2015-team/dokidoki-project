using UnityEngine;
using System.Collections;

// 以下の属性により、CCがオブジェクトにアタッチされていることを保証し、削除出来ないようになる
// 実際にオブジェクトからCCコンポーネントを削除を試みてどうなるか見ると良い
[RequireComponent(typeof(CharacterController))]
public class enemyAI : MonoBehaviour
{
    CharacterController _controller;
    Transform _transform;
    Vector3 dist0;
    Vector3 dist1;
    Vector3 dist2;
    Vector3 dist3;
    public float speed;
    public float rotMax;
    Vector3 moveDirection;
    Vector3 _target;
    float maxRotSpeed = 200.0f;
    float minTime = 10f;
    float _velocity;
    float gravity = 20f;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _transform = GetComponent<Transform>();
    }

    bool PlayerFind = false;
    bool Check0Find = true;
    bool Check1Find = true;
    bool Check2Find = true;
    GameObject _Player;
    GameObject Check0;
    GameObject Check1;
    GameObject Check2;
    float Playerrange = 100f;
    float Checkrange = 10f;

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "check")
        {
            Check0Find = false; 
        }

        if (coll.gameObject.tag == "check1")
        {
            Check1Find = false;
        }

        if (coll.gameObject.tag == "check2")
        {
            Check2Find = false;
        }

    }
    void Update()
    {

        _Player = GameObject.FindGameObjectWithTag("Player");
        Check0 = GameObject.FindGameObjectWithTag("check");
        Check1 = GameObject.FindGameObjectWithTag("check1");
        Check2 = GameObject.FindGameObjectWithTag("check2");

        if (Check0Find)
        {
           CheckPOINT0();
        }else
         if(!Check0Find){
            moveDirection = _transform.forward;
            moveDirection *= speed;
            moveDirection.y -= gravity * Time.deltaTime;
            _controller.Move(moveDirection * Time.deltaTime);
            Update2();
            Update3();
        }

        if (Check1Find)
        {
            CheckPOINT1();
        }else
        if (!Check1Find)
        {
            moveDirection = _transform.forward;
            moveDirection *= speed;
            moveDirection.y -= gravity * Time.deltaTime;
            _controller.Move(moveDirection * Time.deltaTime);
            Update2();
            Update3();
        }

        if (Check2Find)
        {
            CheckPOINT2();
        }else
        if(!Check2Find){
            moveDirection = _transform.forward;
            moveDirection *= speed;
            moveDirection.y -= gravity * Time.deltaTime;
            _controller.Move(moveDirection * Time.deltaTime);
            Update2();
            Update3();
        }

        if (PlayerFind)
        {
            PlayerwoOU();
        }else
        if (!PlayerFind)
        {
            moveDirection = _transform.forward;
            moveDirection *= speed;
            moveDirection.y -= gravity * Time.deltaTime;
            _controller.Move(moveDirection * Time.deltaTime);
            Update2();
            Update3();
        }
    }




    void PlayerwoOU()
    {
        Debug.Log("player");
        dist0 = _Player.transform.position - _transform.position;
        if (Vector3.Distance(_transform.position, _Player.transform.position) < Playerrange)
        {
            // ターゲットの方向を向く
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(dist0.x, dist0.y, dist0.z)), rotMax);
            // 正面方向に移動
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if (Vector3.Distance(_transform.position, _Player.transform.position) > Playerrange)
        {
            PlayerFind = false;
            moveDirection = _transform.forward;
            moveDirection *= speed;
            moveDirection.y -= gravity * Time.deltaTime;
            _controller.Move(moveDirection * Time.deltaTime);
            Update2();
            Update3();
        }
    }

    void CheckPOINT0()
    {
        Debug.Log("check");
        dist1 = Check0.transform.position - _transform.position;
        if (Vector3.Distance(_transform.position, Check0.transform.position) < Checkrange)
        {

            // ターゲットの方向を向く
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(dist1.x, dist1.y, dist1.z)), rotMax);
            // 正面方向に移動
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            if (Vector3.Distance(_transform.position, _Player.transform.position) < Playerrange)
            {
                Check0Find = false;
                PlayerwoOU();
            }
        }

    }

    void CheckPOINT1()
    {
        Debug.Log("check1");
        dist2 = Check1.transform.position - _transform.position;
        if (Vector3.Distance(_transform.position, Check1.transform.position) < Checkrange)
        {

            // ターゲットの方向を向く
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(dist2.x, dist2.y, dist2.z)), rotMax);
            // 正面方向に移動
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            if (Vector3.Distance(_transform.position, _Player.transform.position) < Playerrange)
            {
                Check1Find = false;
                PlayerwoOU();
            }
        }
    }

    void CheckPOINT2()
    {
        Debug.Log("check2");
        dist3 = Check2.transform.position - _transform.position;
        if (Vector3.Distance(_transform.position, Check2.transform.position) < Checkrange)
        {
            // ターゲットの方向を向く
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(dist3.x, dist3.y, dist3.z)), rotMax);
            // 正面方向に移動
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            if (Vector3.Distance(_transform.position, _Player.transform.position) < Playerrange)
            {
                Check2Find = false;
                PlayerwoOU();
            }
        }

    }

    void Update2()
    {
        //移動のためのコード  
        var newRotation = Quaternion.LookRotation(_target - _transform.position).eulerAngles;
        var angles = _transform.rotation.eulerAngles;
        _transform.rotation = Quaternion.Euler(angles.x,
                                       Mathf.SmoothDampAngle(angles.y, newRotation.y, ref _velocity, minTime, maxRotSpeed),
                                       angles.z);

        if (Vector3.Distance(_transform.position, _Player.transform.position) < Playerrange)
        {
            PlayerFind = true;
        }
        else
        {
            PlayerFind = false;
        }

        if (Vector3.Distance(_transform.position, Check0.transform.position) > Checkrange)
        {
            Check0Find = false;
        }
        else
        {
            return;
        }
    }
    

    //	シンプルなスクリプトでNPCが動きまわれるようにする:
    bool change;
    float range;
    void Start2()
    {
        range = 2f;
        _target = GetTarget();
        InvokeRepeating("NewTarget", 0.01f, 2.0f);
    }
    void Update3()
    {
        if (change) _target = GetTarget();

        if (Vector3.Distance(_transform.position, _target) > range)
        {
         

        }
    }
    Vector3 GetTarget()
    {
        return new Vector3(Random.Range(-300, 300), 0, Random.Range(-300, 300));
    }
    void NewTarget()
    {
        int choice = Random.Range(0, 3);
        switch (choice)
        {
            case 0:
                change = true;
                break;
            case 1:
                change = false;
                break;
            case 2:
                _target = transform.position;
                break;
        }
    }
}