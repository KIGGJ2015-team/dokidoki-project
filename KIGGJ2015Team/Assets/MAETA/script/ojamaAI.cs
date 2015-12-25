using UnityEngine;
using System.Collections;

public class ojamaAI : MonoBehaviour {

    public float speed;
    private float rotationSmooth = 1f;
    private Vector3 targetPosition;
    private float changeTargetSqrDistance = 40f;
    //[SerializeField]
   // bool PlayerFind = false;
    [SerializeField]
    bool haikai = true;
    [SerializeField]
    private Transform player;
  

    timer timer;


  
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
        if (coll.gameObject.tag == "Player")
        {
            //if (PlayerFind)
            //{
                Debug.Log("en");
                haikai = false;
                Debug.Log("1");
                Quaternion targetRotation = Quaternion.LookRotation(player.position - transform.position);
                Debug.Log("2");
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSmooth);
                Debug.Log("3");
                // 前方に進む
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
                Debug.Log("4");
            //}
        }
              
        }
    void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Debug.Log("en_kaijo");
           // PlayerFind = false;
            haikai = true;
        }
    }

    }



