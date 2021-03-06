using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class LoadingManager : MonoBehaviour
{
    [SerializeField]
    string nextScene;
    [SerializeField]
    Text Pertext;

    [SerializeField]
    Image progressBar;

    GameObject Go;
    bool isReady = false;

    AsyncOperation op;  //로딩 진행 상황

    void Start()
    {
        Go = GameObject.Find("Touch");
        StartCoroutine(LoadSceneProcess()); 
    }

    private void FixedUpdate()
    {
        Pertext.text = System.Math.Round(progressBar.fillAmount * 100 ,0) + "%";  //퍼센트

#if UNITY_STANDALONE || UNITY_WEBPLAYER || UNITY_EDITOR         //pc의 경우
        if (isReady && Input.GetKeyDown(KeyCode.Space))
        {
            op.allowSceneActivation = true;
        }
#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE       //phone의 경우
        if (isReady && Input.touchCount != 0)
        {
            op.allowSceneActivation = true;
        }
#endif

    }

    IEnumerator LoadSceneProcess()
    {
        op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;

        float timer = 0f;
        while (!op.isDone)
        {
            if (!File.Exists(Application.persistentDataPath + "/playerData.json"))    //파일의 로드
            {
                Json.Instance.Save();
                Json.Instance.SaveCost();
                Json.Instance.SaveMisson();
                Json.Instance.SaveSlot();
            }
            yield return null;
            if(op.progress < 0.3f)      //로딩  
            {
                progressBar.fillAmount = op.progress;
            }
            else                        //페이크 로딩
            {
                timer += Time.unscaledDeltaTime / 3;
                progressBar.fillAmount = Mathf.Lerp(0.5f, 1f, timer);
                if(progressBar.fillAmount >= 1f)    //완료시
                {
                    Go.GetComponent<Text>().text = "Touch & Play";
                    isReady = true;
                    yield break;
                }
            }
        }
    }
}
