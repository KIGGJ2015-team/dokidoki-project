using UnityEngine;
using System.Collections;

public class ObjectChaser : MonoBehaviour
{

    /***********************************************
     *                                             
     *  ObjectChaser                              
     *  指定したオブジェクトを追跡します           
     *  カメラに付けるとスクロールとして機能します 
     *                                             
     ***********************************************/

    public enum ChaseType
    {
        None  = 0,
        X     = 1,
        Y     = 2,
        XandY = 3,
        Z     = 4,
        ZandX = 5,
        ZandY = 6,
        ALL   = 7,
    }

    public GameObject chaseObject;
    public ChaseType  chaseType;
    public Vector3 offset;

    void LateUpdate()
    {
        if (chaseObject != null)
        {
            Chase();
        }
    }

    private void Chase () 
    {
        Vector3 position = transform.position;

        //ChaseType
        if (((int)chaseType & 1) > 0)
        {
            position.x = chaseObject.transform.position.x + offset.x;
        }

        if (((int)chaseType & 2) > 0)
        {
            position.y = chaseObject.transform.position.y + offset.y;
        }

        if (((int)chaseType & 4) > 0)
        {
            position.z = chaseObject.transform.position.z + offset.z;
        }
        
        transform.position = position;
    }
}
