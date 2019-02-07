using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeShader_Sinus : MonoBehaviour
{

    //Visibility押下の判定
    private bool isVisibleButtonDown = false;

    //何回Visibilityボタンが押されたか、記録する
    public float ButtonCount = 0;

    //最後にボタンを押してから何秒(何フレーム)経ったか
    private float lastMovingTime = 0;


    //BoneMaterial
    public Material SinusShader_Transparent0;
    public Material SinusShader_Transparent50;
    public Material SinusShader_Transparent100;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //ボタン連打防止
        if (Time.realtimeSinceStartup - lastMovingTime > 0.2f)
        {
            if (this.isVisibleButtonDown)
            {
                //SetTransparentMaterialでマテリアルを切り替える
                SetTransparentMaterial();
                ButtonCount += 1;

                //ボタンが押されたときに更新
                lastMovingTime = Time.realtimeSinceStartup;
            }
        }
    }

    public void SetTransparentMaterial()
    {
        if (ButtonCount % 3 == 0)
        {
            GetComponent<MeshRenderer>().material = SinusShader_Transparent0;
        }
        else if (ButtonCount % 3 == 1)
        {
            GetComponent<MeshRenderer>().material = SinusShader_Transparent50;
        }
        else if (ButtonCount % 3 == 2)
        {
            GetComponent<MeshRenderer>().material = SinusShader_Transparent100;
        }

    }

    //VisibleButtonを押し続けた場合の処理
    public void GetMyVisibleButtonDown()
    {
        this.isVisibleButtonDown = true;
    }

    public void GetMyVisibleButtonUp()
    {
        this.isVisibleButtonDown = false;
    }
}