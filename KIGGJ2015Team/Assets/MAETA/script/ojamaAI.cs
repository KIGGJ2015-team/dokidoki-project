using UnityEngine;
using System.Collections;

public class ojamaAI : MonoBehaviour {

    public float speed;
    private float rotationSmooth = 2f;
    private Vector3 targetPosition;
    private float changeTargetSqrDistance = 40f;
    //[SerializeField]
   // bool PlayerFind = false;
    [SerializeField]
    bool haikai = true;
    [SerializeField]
    private Transform player;

    [SerializeField]
    float time_chara;
    [SerializeField]
    bool isMove = false;
    chara_timer chara_timer;
    timer timer;
    [SerializeField]
    public GameObject bullet;
    public Transform spawn;
    public float speed1;

    private void Start()
    {
        targetPosition = GetRandomPositionOnLevel();
        player = GameObject.FindWithTag("Player").transform;
    
    }
   
    private void Update()
    {
        
        timer = GameObject.Find("GM").GetComponent<timer>();

        if (timer.GetisStart() == true)
        {


            if (haikai)
            {
                Debug.Log("haikai");
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
            
        }
}
    public Vector3 GetRandomPositionOnLevel()
    {
        float levelSize = 55f;
        return new Vector3(Random.Range(-levelSize, levelSize), 0, Random.Range(-levelSize, levelSize));
    }



    void OnTriggerStay(Collider coll)

    {
        
        //chara_timer = GameObject.Find("GM").GetComponent<chara_timer>();
        if (coll.gameObject.tag == "Player")
        {
            //if (chara_timer.GetisStart() == true)
            //{
                Debug.Log("en");
            if (time_chara>0) {
                haikai = false;

                isMove = true;
                Debug.Log("1");
                Quaternion targetRotation = Quaternion.LookRotation(player.position - transform.position);
                Debug.Log("2");
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSmooth);
                Debug.Log("3");
            }
                time_chara -= Time.deltaTime;
                if (time_chara<0) {
                    // 前方に進む
                    transform.Translate(Vector3.forward * speed1 * Time.deltaTime);
                    Debug.Log("4");
                }
            
        }
        }
    void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Debug.Log("en_kaijo");
           // PlayerFind = false;
            haikai = true;
            time_chara = 1;
        }
    }

    }



