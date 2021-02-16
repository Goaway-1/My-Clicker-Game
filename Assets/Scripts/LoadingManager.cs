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

    Slider slider;

    [SerializeField]
    Text Statetext;

    [SerializeField]
    Text Percenttext;
    bool isReady = false;

    AsyncOperation op;  //�ε� ���� ��Ȳ

    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
        StartCoroutine(LoadSceneProcess());
    }

    private void FixedUpdate()
    {

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
            if (op.progress < 0.1f)      //�ε�  
            {
                slider.value = op.progress;
                Percenttext.text = System.Math.Round((slider.value * 100),0).ToString() + "%";
            }
            else                        //����ũ �ε�
            {
                timer += Time.unscaledDeltaTime / 5;
                slider.value = Mathf.Lerp(0.5f, 1f, timer);
                Percenttext.text = System.Math.Round((slider.value * 100), 0).ToString() + "%";
                if (slider.value >= 1f)    //�Ϸ��
                {
                    Statetext.text = "Touch And Play";
                    isReady = true;
                    yield break;
                }
            }
        }
    }
}
