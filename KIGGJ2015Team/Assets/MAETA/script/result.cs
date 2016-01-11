using UnityEngine;
using System.Collections;

public class result : MonoBehaviour {

    [SerializeField]
    private GameObject one;
    [SerializeField]
    private GameObject two;
    [SerializeField]
    private GameObject three;
    [SerializeField]
    private GameObject four;
    Vector3 ONE;
    Vector3 TWO;
    Vector3 THREE;
    Vector3 FOUR;
    [SerializeField]
    public bool goal = false;
    [SerializeField]
    bool iti = false;
    [SerializeField]
    bool ni = false;
    [SerializeField]
    bool san = false;
    [SerializeField]
    bool yon = false;

    
    // Use this for initialization
    void Start () {
        ONE = one.transform.position;
        one.transform.position = new Vector3(-10000, -10000, 0);

        TWO = two.transform.position;
        two.transform.position = new Vector3(-10000, -10000, 0);

        THREE = three.transform.position;
        three.transform.position = new Vector3(-10000, -10000, 0);

        FOUR = four.transform.position;
        four.transform.position = new Vector3(-10000, -10000, 0);
    }
	
	// Update is called once per frame
	void Update () {

        if (goal)
        {
            if (iti)
            {
              one.transform.position = ONE;
            }

            if (ni)
            {
                two.transform.position = TWO;
            }

            if (san)
            {
                three.transform.position = THREE;
            }

            if (yon)
            {
                four.transform.position = FOUR;
            }
        }
    }
}
