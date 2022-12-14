using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TAMA01: MonoBehaviour
{
    private const int SPEED = 10; //弾の速さ
    private float _screenTop; // 画面の一番上のy座標。画面外かどうかの判定に使用
    private Rigidbody2D _rb;
    private Transform _tf;

    public  void Awake()
    {
    _rb =this.GetComponent<Rigidbody2D>();
        _tf = this.transform;

       // 画面の一番上のy座標を取得
        _screenTop = Camera.main.ViewportToWorldPoint(new Vector2(1, 0)).x;
        // 弾を上に移動させる
        _rb.velocity = _tf.right.normalized * SPEED;
    }

     private void Update()
     {
         // Rigidbody2Dのsimulatedがfalse(弾が使われていない状態)であれば何もしない
         if (_rb.simulated == false)
             return;

         // ここからはRigidbody2Dのsimulatedがtrueの場合(=弾が動いている場合)
         // 画面外に弾が出ていたらRigidbody2Dのsimulatedをfalseにして物理演算を止める(弾をストップする)
         // ＋１しているのは余裕を持っているだけです。

       if (_tf.position.x > _screenTop+(19f))
         {
             _tf.position=new Vector3(0,0,0);
         }
     }
}

