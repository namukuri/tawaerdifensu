using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq; //<=　宣言を追加します。


public class EnemyController : MonoBehaviour
{
    [SerializeField, Header("移動経路の情報")]
    private PathData pathData;

    [SerializeField, Header("移動速度")]
    private float moveSpeed;

    [SerializeField, Header("最大HP")]
    private int maxHp;

    [SerializeField]
    private int hp;

    private Tween tween;

    private Vector3[] paths; // 移動する各地点を代入するための配列

    private Animator anim; // Animator コンポーネントの取得用

    //private Vector3 currentPos; // 敵キャラの現在の位置情報

    // Start is called before the first frame update
    void Start()
    {

        hp = maxHp;

        // Animator コンポーネントを取得して anim 変数に代入
        TryGetComponent(out anim);

        // 移動する地点を取得
        paths = pathData.pathTranArray.Select(pathTran => pathTran.position).ToArray();

        // 各地点に向けて移動。今後この処理を制御するため、Tween 型の変数に DOPath メソッドの処理を代入しておく
        tween = transform.DOPath(paths, 1000 / moveSpeed).SetEase(Ease.Linear).OnWaypointChange(ChangeAnimeDirection); //<= DOPath の処理を tween 変数に代入します

        // 移動する地点を取得するための配列の初期化
        // paths = new Vector3[pathData.pathTranArray.Length];

        // 移動する位置情報を順番に配列に取得
        //for (int i = 0; i < pathData.pathTranArray.Length; i++)
        //{
        //  paths[i] = pathData.pathTranArray[i].position;
        //}

        // 各地点に向けて移動
        //transform.DOPath(paths, 1000 /  moveSpeed).SetEase(Ease.Linear).OnWaypointChange(ChangeAnimeDirection); //<=  ３つ目のメソッドを追加します。

    }

    //private void Update()
    //{
        // 敵の進行方向を取得
        //ChangeAnimeDirection();

    //}

    // 敵の進行方向を取得して、移動アニメと同期
    private void ChangeAnimeDirection(int index) //引数を追加します
    {
        Debug.Log(index); //　<=　☆①　最終的な確認が終了したら、あとでコメントアウトしておきましょう

        // 次の移動先の地点がない場合には、ここで処理を終了する
        if (index >= paths.Length)
        {
            return;
        }

        // 目標の位置と現在の位置との距離と方向を取得し、正規化処理を行い、単位ベクトルとする(方向の情報は持ちつつ、距離による速度差をなくして一定値にする)
        Vector3 direction = (transform.position - paths[index]).normalized;
        Debug.Log(direction);

        // アニメーションの Palameter の値を更新し、移動アニメの BlendTree を制御して移動の方向と移動アニメを同期
        anim.SetFloat("X", direction.x);
        anim.SetFloat("Y", direction.y);

       // if (transform.position.pathTran > paths[index].pathTran) //条件式の右辺を変更します。演算子の方向に注意してください
        //{
            //anim.SetFloat("Y", 0f);
            //anim.SetFloat("X", -1.0f);

            //Debug.Log("左方向");
        //}
        //else if (transform.position.y < paths[index].y) //条件式の右辺を変更します。演算子の方向に注意してください
        //{
            //anim.SetFloat("X", 0f);
            //anim.SetFloat("Y", 1.0f);

            //Debug.Log("上方向");
        //}
        //else if (transform.position.y > paths[index].y) //条件式の右辺を変更します。演算子の方向に注意してください
        //{
            //anim.SetFloat("X", 0f);
            //anim.SetFloat("Y", -1.0f);
            //Debug.Log("下方向");
        //}
        //else
        //{
            //anim.SetFloat("Y", 0f);
            //anim.SetFloat("X", 1.0f);

            //Debug.Log("右方向");
        //}

        // 現在の位置情報を保持
        //currentPos = transform.position;
    }

    // ダメージ計算

    public void CulcDamage(int amount)
    {
        // Hp の値を減算した結果値を、最低値と最大値の範囲内に収まるようにして更新
        hp = Mathf.Clamp(hp -= amount, 0, maxHp);

        Debug.Log("残りHP : " + hp);

        // Hp が 0 以下になった場合
        if (hp <= 0)
        {
            // 破壊処理を実行するメソッドを呼び出す
            DestroyEnemy();
        }

        // TODO 演出用のエフェクト生成

        // TODO ヒットストップ演出
    }

    // 敵破壊処理
    public void DestroyEnemy()
    {
        // Kill メソッドを実行し、tween 変数に代入されている処理(DOPath の処理)を終了する
        tween.Kill();

        // TODO SEの処理

        // TODO 破壊時のエフェクトの生成や関連する処理

        // 敵キャラの破壊
        Destroy(gameObject);

    }



}
