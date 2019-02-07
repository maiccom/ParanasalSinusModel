using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ChangeShader : MonoBehaviour {

    //Visibility押下の判定
    private bool isVisibleButtonDown = false;

    //何回Visibilityボタンが押されたか、記録する
    public float ButtonCount = 0;

    //最後にボタンを押してから何秒(何フレーム)経ったか
    private float lastMovingTime = 0;

    //FaceMaterial
    public Material Transparent0;
    public Material Transparent50;
    public Material Transparent100;

    //HairMaterial
    public Material HairShader_Transparent0;
    public Material HairShader_Transparent50;
    public Material HairShader_Transparent100;

    //EyelashとEyebrowを宣言
    public GameObject Eyelash;
    public GameObject Eyebrow;

    // Use this for initialization
    void Start()
    {
        //シーン中のEyelashとEyebrowのオブジェクトを取得
        Eyelash = GameObject.Find("EyelashPoly");
        Eyebrow = GameObject.Find("EyebrowPoly");

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
            GetComponent<MeshRenderer>().material = Transparent0;
            Eyebrow.GetComponent<MeshRenderer>().material = HairShader_Transparent0;
            Eyelash.GetComponent<MeshRenderer>().material = HairShader_Transparent0;
        }
        else if (ButtonCount % 3 == 1)
        {
            GetComponent<MeshRenderer>().material = Transparent50;
            Eyebrow.GetComponent<MeshRenderer>().material = HairShader_Transparent50;
            Eyelash.GetComponent<MeshRenderer>().material = HairShader_Transparent50;
        }
        else if (ButtonCount % 3 == 2)
        {
            GetComponent<MeshRenderer>().material = Transparent100;
            Eyebrow.GetComponent<MeshRenderer>().material = HairShader_Transparent100;
            Eyelash.GetComponent<MeshRenderer>().material = HairShader_Transparent100;
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
