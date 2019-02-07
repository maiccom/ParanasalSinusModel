using UnityEngine;
using UnityEngine.UI;

public class CheckButton : MonoBehaviour
{
    //ボタンをキャッシュする変数
    Button btn;
    bool btnChangeFlag = true;

    //ここでカラーを設定
    static readonly Color btnVisible = Color.red;


    static readonly Color btnInvisible = Color.blue;

    void Awake()
    {
        //何度もアクセスするのでこの変数にキャッシュ
        btn = gameObject.GetComponent<Button>();
        btn.image.color = btnVisible;
    }

    void Start()
    {
        btn.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        btnChangeFlag = !btnChangeFlag;
        btn.image.color = btnChangeFlag ? btnVisible : btnInvisible;
    }
}