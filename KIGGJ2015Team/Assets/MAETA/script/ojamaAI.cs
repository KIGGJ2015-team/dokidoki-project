using UnityEngine;
using System.Collections;

public class ojamaAI : MonoBehaviour {

    public float speed;
    private float rotationSmooth = 1f;
    private Vector3 targetPosition;
    private float changeTargetSqrDistance = 40f;
    [SerializeField]
    bool PlayerFind = false;
    [SerializeField]
    bool urochoro = true;
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

            }else
                if (!urochoro)
            {

            }
        }
}
    public Vector3 GetRandomPositionOnLevel()
    {
        float levelSize = 55f;
        return new Vector3(Random.Range(-levelSize, levelSize), 0, Random.Range(-levelSize, levelSize));
    }



    void OnTriggerEnter(Collider coll)

    {
        if (coll.gameObject.tag == "Player")
        {
            Debug.Log("en");
            PlayerFind = true;
            urochoro = false;
            Quaternion targetRotation = Quaternion.LookRotation(player.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSmooth);

                  // 前方に進む
                  transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
              
        }
    void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Debug.Log("en_kaijo");
            PlayerFind = false;
            urochoro = true;
        }
    }

    }



