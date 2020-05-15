using UnityEngine;
using System.Collections;

public class ItemGenerator : MonoBehaviour
{
    //carPrefabを入れる
    public GameObject carPrefab;
    //coinPrefabを入れる
    public GameObject coinPrefab;
    //cornPrefabを入れる
    public GameObject conePrefab;
    //ゴール地点
    private int goalPos = 100;
    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;
    //発展課題用：Unityちゃんオブジェクトの変数
    private GameObject unitychan;
    //発展課題用：Unityちゃんから一定前方位置をいれる変数
    private float checkPoint;

    // Use this for initialization
    void Start()
    {
        //発展課題用：Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");

        //発展課題用：アイテム生成するタイミングの変数
        this.checkPoint = unitychan.transform.position.z + 20;

    }

    // Update is called once per frame
    void Update()
    {
        //発展課題用：アイテム生成の条件
        if (unitychan.transform.position.z > this.checkPoint && this.checkPoint < this.goalPos)
        {
            //発展課題用：アイテム生成する関数を呼び出す
            generateItem();

            //発展課題用：次のチェックポイントを作る
            this.checkPoint += 20;
        }
    }


    //発展課題用：アイテム生成用関数
    void generateItem()
    {
        //どのアイテムを出すのかをランダムに設定
        int num = Random.Range(0, 10);
        if (num <= 1)
        {
            //コーンをx軸方向に一直線に生成
            for (float j = -1; j <= 1; j += 0.4f)
            {
                GameObject cone = Instantiate(conePrefab) as GameObject;
                cone.transform.position = new Vector3(4 * j, cone.transform.position.y, unitychan.transform.position.z + 20);
            }
        }
        else
        {
            //レーンごとにアイテムを生成
            for (int j = -1; j < 2; j++)
            {
                //アイテムの種類を決める
                int item = Random.Range(1, 11);
                //アイテムを置くZ座標のオフセットをランダムに設定
                int offsetZ = Random.Range(-5, 6);
                //60%コイン配置:30%車配置:10%何もなし
                if (1 <= item && item <= 6)
                {
                    //コインを生成
                    GameObject coin = Instantiate(coinPrefab) as GameObject;
                    coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, unitychan.transform.position.z + offsetZ + 20);
                }
                else if (7 <= item && item <= 9)
                {
                    //車を生成
                    GameObject car = Instantiate(carPrefab) as GameObject;
                    car.transform.position = new Vector3(posRange * j, car.transform.position.y, unitychan.transform.position.z + offsetZ + 20);
                }
            }
        }
    }
}