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

    AsyncOperation op;  //�ε� ���� ��Ȳ

    void Start()
    {
        Go = GameObject.Find("Touch");
        StartCoroutine(LoadSceneProcess()); 
    }

    private void FixedUpdate()
    {
        Pertext.text = System.Math.Round(progressBar.fillAmount * 100 ,0) + "%";  //�ۼ�Ʈ

#if UNITY_STANDALONE || UNITY_WEBPLAYER || UNITY_EDITOR         //pc�� ���
        if (isReady && Input.GetKeyDown(KeyCode.Space))
        {
            op.allowSceneActivation = true;
        }
#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE       //phone�� ���
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
            if (!File.Exists(Application.persistentDataPath + "/playerData.json"))    //������ �ε�
            {
                Json.Instance.Save();
                Json.Instance.SaveCost();
                Json.Instance.SaveMisson();
                Json.Instance.SaveSlot();
            }
            yield return null;
            if(op.progress < 0.3f)      //�ε�  
            {
                progressBar.fillAmount = op.progress;
            }
            else                        //����ũ �ε�
            {
                timer += Time.unscaledDeltaTime / 3;
                progressBar.fillAmount = Mathf.Lerp(0.5f, 1f, timer);
                if(progressBar.fillAmount >= 1f)    //�Ϸ��
                {
                    Go.GetComponent<Text>().text = "Touch & Play";
                    isReady = true;
                    yield break;
                }
            }
        }
    }
}
