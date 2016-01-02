// ----- ----- ----- ----- -----
//
// PlayerSelect
//
// 作成日：
// 作成者：
//
// <概要>
// セレクトシーンで使うスクリプト
// プレイヤーを選択します
//
// ----- ----- ----- ----- -----

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("MyScript/PlayerSelect")]
public class PlayerSelect : MonoBehaviour
{
	#region 変数

    [SerializeField,
     Range(0, 3),
     Tooltip("プレイヤーが現在選択している機体の番号" + "\n" +
             "初めに選択されている機体を変えられます")]
    private int state;

    [SerializeField, Tooltip("切り替わるスピード(秒)")]
    private float changeSpeed;

    Hashtable hash;

    Mesh mesh;
    Material[] materials;

    #endregion


    #region プロパティ

    public Mesh PlayerMesh
    {
        get {return mesh; }
    }

    public Material[] PlayerMaterials
    {
        get {return materials; }
    }

    public int State
    {
        get {return state; }
    }

    #endregion


    #region メソッド

	// 初期化処理
    void Awake()
    {
        DontDestroyOnLoad(gameObject);

        hash = new Hashtable();
        hash.Add("easetype", iTween.EaseType.easeOutQuart);
        hash.Add("time", changeSpeed);
    }

    // 更新前処理
    void Start()
    {
        for(int i = 0; i < 4; i++)
        {
            if(i == state)
            {
                transform.GetChild(i).localPosition = new Vector3(0, -1, 0);
                //mesh      = transform.GetChild(i).GetComponent<MeshFilter>().mesh;
                //materials = transform.GetChild(i).GetComponent<MeshRenderer>().materials;
                continue;
            }

            float heightPosition = transform.GetChild(i).position.y;
            transform.GetChild(i).localPosition = new Vector3(20, -1, 0);
        }
    }

    // 更新処理
    void Update()
    {        
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ChangePlayer(false);
        }

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            ChangePlayer(true);
        }
    }

    public void ChangePlayer(bool isRightSide)
    {
        if(isRightSide)
        {
            Change( 1);
        }
        else
        {
            Change(-1);
        }
    }

    private void Change(int direction)
    {
        int nowState  = state;
        int nextState = state + 1 * direction;
        if(nextState < 0)
        {
            nextState = 3;
        }
        else
        if(nextState > 3)
        {
            nextState = 0;
        }
        
        float  nowHeight = transform.GetChild( nowState).position.y;
        float nextHeight = transform.GetChild(nextState).position.y;

        Vector3  nowPosition = new Vector3(0, -1, 0);
        Vector3 nextPosition = new Vector3(20 * direction * -1, -1, 0);

        transform.GetChild( nowState).localPosition =  nowPosition;
        transform.GetChild(nextState).localPosition = nextPosition;

        hash["path"] = new Vector3[] {  nowPosition,  nowPosition + new Vector3(20 * direction, 0, 0)};        

        iTween.MoveTo(transform.GetChild( nowState).gameObject, hash);

        hash["path"] = new Vector3[] { nextPosition, nextPosition + new Vector3(20 * direction, 0, 0)};

        iTween.MoveTo(transform.GetChild(nextState).gameObject, hash);

        state = nextState;
        //mesh      = transform.GetChild(state).GetComponent<MeshFilter>().mesh;
        //materials = transform.GetChild(state).GetComponent<MeshRenderer>().materials;
    }
	#endregion
}