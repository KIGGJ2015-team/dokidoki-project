using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class timer : MonoBehaviour {

    Vector3 count3;
    Vector3 count2;
    Vector3 count1;
    Vector3 count_GO;
    [SerializeField]
    private GameObject C3;
    [SerializeField]
    private GameObject C2;
    [SerializeField]
    private GameObject C1;
    [SerializeField]
    private GameObject C_GO;


    float time = 3;
    [SerializeField]
    bool isStart = false;

    Player_Status status;

	// Use this for initialization
	void Start () {
        count3 = C3.transform.position;
        C3.transform.position = new Vector3(-10000, -10000, 0);

        count2 = C2.transform.position;
        C2.transform.position = new Vector3(-10000, -10000, 0);

        count1 = C1.transform.position;
        C1.transform.position = new Vector3(-10000, -10000, 0);

        count_GO = C_GO.transform.position;
        C_GO.transform.position = new Vector3(-10000, -10000, 0);

        status = GameObject.Find("System").GetComponent<Player_Status>();
    }
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;

        if (time < 3)
        {
           C3.transform.position = count3;
        }

        if (time < 2)
        {
            C3.transform.position = new Vector3(-10000, -10000, 0);
            C2.transform.position = count2;

        }

        if (time < 1)
        {
            C2.transform.position = new Vector3(-10000, -10000, 0);
            C1.transform.position = count1;
        }

        if (time < 0)  
        {
            C1.transform.position = new Vector3(-10000, -10000, 0);
            C_GO.transform.position = count_GO;
            
        }

        if(time < -0.5)
        {
            C_GO.transform.position = new Vector3(-10000, -10000, 0);
            isStart = true;
            status.isControl = true;
            List<GameObject> rival = GetComponent<PlayerInfomation>().rival;
            foreach(GameObject r in rival)
            {
                r.GetComponent<RivalRacerAI>().isControl = true;
            }
        }


	}
    public bool GetisStart()
    {
        return isStart;
    }
}
