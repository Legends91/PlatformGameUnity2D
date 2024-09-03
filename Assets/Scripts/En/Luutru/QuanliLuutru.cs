using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class QuanliLuutru : MonoBehaviour
{
    [Header("Gỡ lỗi")]
    [SerializeField] public bool disableDataPersistence = false;
    [SerializeField] public bool initializeDataIfNull = false;
    [SerializeField] public bool overrideSelectedProfileId = false;
    [SerializeField] public string testSelectedProfileId = "test";

    [Header("Lưu trữ")]
    [SerializeField] public string fileName;
    [SerializeField] public bool useEncryption;

    [Header("Tự động lưu")]
    [SerializeField] public float autoSaveTimeSeconds = 60f;

    private GameData gameData;
    private List<IQuanliLuutru> dataPersistenceObjects;
    private FileDataHandler dataHandler;

    private string selectedProfileId = "";

    private Coroutine autoSaveCoroutine;

    public static QuanliLuutru instance { get; private set; }

    private void Awake() 
    {
        if (instance != null) 
        {
            Debug.Log("Found more than one Data Persistence Manager in the scene. Destroying the newest one.");
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);

        if (disableDataPersistence) 
        {
            Debug.LogWarning("Data Persistence is currently disabled!");
        }

        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName, useEncryption);

        InitializeSelectedProfileId();
    }

    private void OnEnable() 
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable() 
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode) 
    {
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();

        if (autoSaveCoroutine != null) 
        {
            StopCoroutine(autoSaveCoroutine);
        }
        autoSaveCoroutine = StartCoroutine(AutoSave());
    }

    public void ChangeSelectedProfileId(string newProfileId) 
    {
        this.selectedProfileId = newProfileId;
        LoadGame();
    }

    public void DeleteProfileData(string profileId) 
    {
        dataHandler.Delete(profileId);
        InitializeSelectedProfileId();
        LoadGame();
    }

    private void InitializeSelectedProfileId() 
    {
        this.selectedProfileId = dataHandler.GetMostRecentlyUpdatedProfileId();
        if (overrideSelectedProfileId) 
        {
            this.selectedProfileId = testSelectedProfileId;
            Debug.LogWarning("Overrode selected profile id with test id: " + testSelectedProfileId);
        }
    }

    public void NewGame() 
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        if (disableDataPersistence) 
        {
            return;
        }

        this.gameData = dataHandler.Load(selectedProfileId);

        if (this.gameData == null && initializeDataIfNull) 
        {
            NewGame();
        }

        if (this.gameData == null) 
        {
            Debug.Log("Khong co du lieu");
            return;
        }

        foreach (IQuanliLuutru dataPersistenceObj in dataPersistenceObjects) 
        {
            dataPersistenceObj.LoadData(gameData);
        }
    }

    public void SaveGame()
    {
        if (disableDataPersistence) 
        {
            return;
        }

        if (this.gameData == null) 
        {
            Debug.LogWarning("Khong co du lieu");
            return;
        }

        foreach (IQuanliLuutru dataPersistenceObj in dataPersistenceObjects) 
        {
            dataPersistenceObj.SaveData(gameData);
        }

        gameData.lastUpdated = System.DateTime.Now.ToBinary();

        dataHandler.Save(gameData, selectedProfileId);
    }

    private void OnApplicationQuit() 
    {
        SaveGame();
    }

    private List<IQuanliLuutru> FindAllDataPersistenceObjects() 
    {
        IEnumerable<IQuanliLuutru> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>(true)
            .OfType<IQuanliLuutru>();

        return new List<IQuanliLuutru>(dataPersistenceObjects);
    }

    public bool HasGameData() 
    {
        return gameData != null;
    }

    public Dictionary<string, GameData> GetAllProfilesGameData() 
    {
        return dataHandler.LoadAllProfiles();
    }

    private IEnumerator AutoSave() 
    {
        while (true) 
        {
            yield return new WaitForSeconds(autoSaveTimeSeconds);
            SaveGame();
            Debug.Log("Auto Saved Game");
        }
    }
}
