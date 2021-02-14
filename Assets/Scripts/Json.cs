using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Json : MonoBehaviour
{
    //�ν��Ͻ�ȭ
    private static Json instance;

    public static Json Instance
    {
        get 
        { 
            if(instance == null)
            {
                instance = GameObject.FindObjectOfType<Json>();
                if(instance == null)
                {
                    GameObject container = new GameObject("Json");
                    instance = container.AddComponent<Json>();
                }
            }
            return instance;
        }
    }

    //json ����
    public PlayerData playerData;
    public PlayerDataCost playerDataCost;   //���
    public PlayerMisson playerMisson;
    public SlotSave slotSave;

    //��Ȱ���ϴ� �ε�����
    static string jsonData;
    static string path;

    public void Save()
    {
        jsonData = JsonUtility.ToJson(playerData, true);
        path = Path.Combine(Application.persistentDataPath, "playerData.json");
        File.WriteAllText(path, Encoding(jsonData));
    }

    public void Load()
    {
        path = Path.Combine(Application.persistentDataPath, "playerData.json");
        jsonData = File.ReadAllText(path);
        playerData = JsonUtility.FromJson<PlayerData>(Decoding(jsonData));
    }

    public void SaveCost()
    {
        jsonData = JsonUtility.ToJson(playerDataCost, true);
        path = Path.Combine(Application.persistentDataPath, "playerDataCost.json");
        File.WriteAllText(path, Encoding(jsonData));
    }

    public void LoadCost()
    {
        path = Path.Combine(Application.persistentDataPath, "playerDataCost.json");
        jsonData = File.ReadAllText(path);
        playerDataCost = JsonUtility.FromJson<PlayerDataCost>(Decoding(jsonData));
    }

    public void SaveMisson()
    {
        jsonData = JsonUtility.ToJson(playerMisson, true);
        path = Path.Combine(Application.persistentDataPath, "playerMisson.json");
        File.WriteAllText(path, Encoding(jsonData));
    }

    public void LoadMisson()
    {
        path = Path.Combine(Application.persistentDataPath, "playerMisson.json");
        jsonData = File.ReadAllText(path);
        playerMisson = JsonUtility.FromJson<PlayerMisson>(Decoding(jsonData));
    }

    public void SaveSlot()
    {
        jsonData = JsonUtility.ToJson(slotSave, true);
        path = Path.Combine(Application.persistentDataPath, "SlotSave.json");
        File.WriteAllText(path, Encoding(jsonData));
    }
    public void LoadSlot()
    {
        path = Path.Combine(Application.persistentDataPath, "SlotSave.json");
        jsonData = File.ReadAllText(path);
        slotSave = JsonUtility.FromJson<SlotSave>(Decoding(jsonData));
    }

    private string Encoding(string jsonData)   //��ȣȭ   
    {
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(jsonData);    //����Ʈ�� ��ȯ  
        string code = System.Convert.ToBase64String(bytes);             //�ٽ� ���ڷ� ��ȯ
        return code;
    }
    private string Decoding(string jsonData)   //��ȣȭ
    {
        byte[] bytes = System.Convert.FromBase64String(jsonData);
        string code = System.Text.Encoding.UTF8.GetString(bytes);
        return code;
    }
}
