using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// StartCoroutineはオブジェクトにアタッチされているスクリプトからしか呼び出せない。
/// ので、もしアタッチされていなかったら専用のオブジェクトを作ってアタッチする。
///    from:ChatGPT
/// </summary> 
public class CoroutineRunner : MonoBehaviour
{
    private static CoroutineRunner _instance;

    public static CoroutineRunner Instance
    {
        get
        {
            if (_instance == null)
            {
                var go = new GameObject("CoroutineRunner");
                _instance = go.AddComponent<CoroutineRunner>();
                DontDestroyOnLoad(go);
            }
            return _instance;
        }
    }
}