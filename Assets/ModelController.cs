using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ModelController : MonoBehaviour {


    private Vector3 OBJG_pos;
    private Vector3 OBJG_Scale;

    //HomeButton押下の判定
    private bool isHomeButtonDown = false;

	// Use this for initialization
	void Start ()
    {
    
    }

    // Update is called once per frame
    void Update ()
    {

        //Hキー、又はHomeButtonが押された場合、OBJGroupを初期位置に戻す
        if (Input.GetKeyDown(KeyCode.Space) || this.isHomeButtonDown)
        {
            //OBJGroupが初期位置に戻る
            transform.position = new Vector3(0, 0, 0);
            transform.rotation = new Quaternion(0,0,0,0);
            transform.localScale = new Vector3(1, 1, 1);

        }

        //OBJGroupの移動制限
        OBJG_pos = transform.position;
        OBJG_pos.x = Mathf.Clamp(OBJG_pos.x, -250f, 250f);
        OBJG_pos.y = Mathf.Clamp(OBJG_pos.y, -150f, 150f);
        OBJG_pos.z = Mathf.Clamp(OBJG_pos.z, 0f, 250f);
        transform.position = new Vector3(OBJG_pos.x, OBJG_pos.y, OBJG_pos.z);

        //OBJGroupの拡大・縮小制限
        OBJG_Scale = transform.localScale;
        OBJG_Scale.x = Mathf.Clamp(OBJG_Scale.x, 0.8f, 250f);
        OBJG_Scale.y = Mathf.Clamp(OBJG_Scale.y, 0.8f, 150f);
        OBJG_Scale.z = Mathf.Clamp(OBJG_Scale.z, 0.8f, 250f);
        transform.localScale = new Vector3(OBJG_Scale.x, OBJG_Scale.y, OBJG_Scale.z);

    }

    //HomeButtonを押し続けた場合の処理
    public void GetMyHomeButtonDown()
    {
        this.isHomeButtonDown = true;
    }

    public void GetMyHomeButtonUp()
    {
        this.isHomeButtonDown = false;
    }
}
