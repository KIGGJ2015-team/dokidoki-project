using UnityEngine;
using System.Collections;

public class timer_second : MonoBehaviour {

    [SerializeField]
    float time = 5;

    public bool frag = false;

    private void Start()
    {
        StartCoroutine(GameStart());
    }

    private IEnumerator GameStart()
    {
        //3
        yield return new WaitForSeconds(time / 3);
        //2
        yield return new WaitForSeconds(time / 3);
        //1
        yield return new WaitForSeconds(time / 3);
        frag = true;
        //GO
    }
}
