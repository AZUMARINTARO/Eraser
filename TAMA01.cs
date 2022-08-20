using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TAMA01: MonoBehaviour
{
    private const int SPEED = 10; //�e�̑���
    private float _screenTop; // ��ʂ̈�ԏ��y���W�B��ʊO���ǂ����̔���Ɏg�p
    private Rigidbody2D _rb;
    private Transform _tf;

    public  void Awake()
    {
    _rb =this.GetComponent<Rigidbody2D>();
        _tf = this.transform;

       // ��ʂ̈�ԏ��y���W���擾
        _screenTop = Camera.main.ViewportToWorldPoint(new Vector2(1, 0)).x;
        // �e����Ɉړ�������
        _rb.velocity = _tf.right.normalized * SPEED;
    }

     private void Update()
     {
         // Rigidbody2D��simulated��false(�e���g���Ă��Ȃ����)�ł���Ή������Ȃ�
         if (_rb.simulated == false)
             return;

         // ���������Rigidbody2D��simulated��true�̏ꍇ(=�e�������Ă���ꍇ)
         // ��ʊO�ɒe���o�Ă�����Rigidbody2D��simulated��false�ɂ��ĕ������Z���~�߂�(�e���X�g�b�v����)
         // �{�P���Ă���̂͗]�T�������Ă��邾���ł��B

       if (_tf.position.x > _screenTop+(19f))
         {
             _tf.position=new Vector3(0,0,0);
         }
     }
}

