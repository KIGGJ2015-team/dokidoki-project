// ----- ----- ----- ----- -----
//
// PlayerImporter
//
// 作成日：
// 作成者：
//
// <概要>
//
//
// ----- ----- ----- ----- -----

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("MyScript/PlayerImporter")]
public class PlayerImporter : MonoBehaviour
{
	#region 変数

    [SerializeField, Tooltip("プレイヤーとライバルのレーサー")]
    private List<GameObject> importObjects;

    struct Import
    {
        public Mesh mesh;
        public Material[] materials;

        Import(Mesh mesh_ = null, Material[] material_ = null)
        {
            mesh = mesh_;
            materials = material_;
        }
    }

    #endregion


    #region プロパティ
    #endregion


    #region メソッド

	// 初期化処理
    void Awake()
    {
        GameObject selectManager = GameObject.Find("SelectManager");

        List<Import> import = new List<Import>();

        for(int i = 0; i < 4; i++)
        {
            var temp = new Import();
            temp.mesh      = selectManager.transform.GetChild(i).GetComponent<MeshFilter>().mesh;
            temp.materials = selectManager.transform.GetChild(i).GetComponent<Renderer  >().materials;
            import.Add(temp);
        }

        PlayerSelect select = selectManager.GetComponent<PlayerSelect>();
        importObjects[0].GetComponent<MeshFilter>().mesh      = import[select.State].mesh;
        importObjects[0].GetComponent<Renderer  >().materials = import[select.State].materials;

        import.RemoveAt(select.State);

        System.Random rng = new System.Random();
        int n = import.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            var tmp   = import[k];
            import[k] = import[n];
            import[n] = tmp;
        }

        for(int i = 1; i < 4; i++)
        {
            importObjects[i].GetComponent<MeshFilter>().mesh      = import[0].mesh;
            importObjects[i].GetComponent<Renderer  >().materials = import[0].materials;
            import.RemoveAt(0);
        }

        Destroy(selectManager);
    }

    // 更新前処理
    void Start() { }

    // 更新処理
    void Update() { }
	#endregion
}