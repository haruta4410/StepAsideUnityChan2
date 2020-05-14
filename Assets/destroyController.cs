using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyController : MonoBehaviour {

	//課題用：Unityちゃんのオブジェクト
	private GameObject unitychan;

	//課題用：Unityちゃんと画面消えるまでの距離
	private float diffrenceDisplay = 3.5f;

	// Use this for initialization
	void Start()
	{

		//課題用：Unityちゃんのオブジェクトを取得
		this.unitychan = GameObject.Find("unitychan");
	}

	// Update is called once per frame
	void Update()
	{

		//課題用：画面外でアイテムを消す
		if (this.transform.position.z < unitychan.transform.position.z - diffrenceDisplay)
		{
			Destroy(this.gameObject);
		}

	}

}
