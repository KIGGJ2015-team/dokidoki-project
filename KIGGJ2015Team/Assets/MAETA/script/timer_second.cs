using UnityEngine;
using System.Collections;

public class timer_second : MonoBehaviour {

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

    [SerializeField]
    float time = 3;

    public bool frag = false;

    private void Start()
    {
        StartCoroutine(GameStart());
        count3 = C3.transform.position;
        C3.transform.position = new Vector3(-10000, -10000, 0);

        count2 = C2.transform.position;
        C2.transform.position = new Vector3(-10000, -10000, 0);

        count1 = C1.transform.position;
        C1.transform.position = new Vector3(-10000, -10000, 0);

        count_GO = C_GO.transform.position;
        C_GO.transform.position = new Vector3(-10000, -10000, 0);
    }

    private IEnumerator GameStart()
    {
        //3
        yield return new WaitForSeconds(time / 3);
        C3.transform.position = count3;

        //2
        yield return new WaitForSeconds(time / 3);
        C3.transform.position = new Vector3(-10000, -10000, 0);
        C2.transform.position = count2;

        //1
        yield return new WaitForSeconds(time / 3);
        C2.transform.position = new Vector3(-10000, -10000, 0);
        C1.transform.position = count1;

        yield return new WaitForSeconds(time / 3);
        C1.transform.position = new Vector3(-10000, -10000, 0);
        C_GO.transform.position = count_GO;

        yield return new WaitForSeconds(time / 3);
        C_GO.transform.position = new Vector3(-10000, -10000, 0);
        frag = true;

        //GO
    }
}
