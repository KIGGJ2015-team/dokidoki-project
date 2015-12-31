using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    float time = 2;
    
    //衝突判定
   /* void OnCollisionEnter(Collision collision){
		//衝突したものが箱だったら
		if (collision.gameObject.tag == "Box") {
			//ダメージメッセージを送信する
			collision.gameObject.SendMessage("ApplyDamage");
			//箱を消滅させる
			//Destroy (collision.gameObject);
		}*/

        void Update () {
        time -= Time.deltaTime;

        if (time < 0) 
        {
            Destroy(gameObject);
        }
	
		//弾丸自体の消滅
		
	}
	

}
