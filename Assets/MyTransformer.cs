using UnityEngine;

using TouchScript.Gestures.TransformGestures;



public class MyTransformer : MonoBehaviour
{



    void OnEnable()

    {

        // Transform Gestureのdelegateに登録

        GetComponent<TransformGesture>().TransformStarted += TransformStartedHandle; // 変形開始

        GetComponent<TransformGesture>().StateChanged += StateChangedHandle; //　状態変化

        GetComponent<TransformGesture>().TransformCompleted += TransformCompletedHandle; // 変形終了

        GetComponent<TransformGesture>().Cancelled += CancelledHandle; // キャンセル

    }



    void OnDisable()

    {

        UnsubscribeEvent();

    }



    void OnDestroy()

    {

        UnsubscribeEvent();

    }



    void UnsubscribeEvent()

    {

        // 登録を解除

        GetComponent<TransformGesture>().TransformStarted -= TransformStartedHandle;

        GetComponent<TransformGesture>().StateChanged -= StateChangedHandle;

        GetComponent<TransformGesture>().TransformCompleted -= TransformCompletedHandle;

        GetComponent<TransformGesture>().Cancelled -= CancelledHandle;

    }



    void TransformStartedHandle(object sender, System.EventArgs e)

    {

        // Debug.Log("変形開始のタッチ時の処理");

    }



    void StateChangedHandle(object sender, System.EventArgs e)

    {

        //Debug.Log(" 変形中のタッチ時の処理");

        TransformGesture gesture = sender as TransformGesture;



        //1本指でタッチ

        if (gesture.NumPointers == 1)
        {
            Vector3 rotateAmount = new Vector3(-gesture.DeltaPosition.y, gesture.DeltaPosition.x, 0);

            transform.Rotate(rotateAmount, Space.World);
        }

        //2本指でタッチ
        if (gesture.NumPointers == 2)
        {
            transform.localScale*= gesture.DeltaScale;

        }

    }



    void TransformCompletedHandle(object sender, System.EventArgs e)

    {

        //  Debug.Log("// 変形終了のタッチ時の処理");

    }



    void CancelledHandle(object sender, System.EventArgs e)

    {

        //  Debug.Log("// 変形終了のタッチ時の処理");

    }

}