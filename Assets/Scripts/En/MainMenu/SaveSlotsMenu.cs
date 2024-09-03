using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveSlotsMenu : Menu
{
    [Header("Menu")]
    [SerializeField] private MenuSave mainMenu;

    [Header("Nút")]
    [SerializeField] private Button backButton;

    [Header("Xác nhận")]
    [SerializeField] private MenuXacnhan confirmationPopupMenu;

    private SaveSlot[] saveSlots;

    private bool isLoadingGame = false;

    private void Awake() 
    {
        saveSlots = this.GetComponentsInChildren<SaveSlot>();
    }

    public void OnSaveSlotClicked(SaveSlot saveSlot) 
    {
        DisableMenuButtons();

        if (isLoadingGame) 
        {
            QuanliLuutru.instance.ChangeSelectedProfileId(saveSlot.GetProfileId());
            SaveGameAndLoadScene();
        }
        else if (saveSlot.hasData) 
        {
            confirmationPopupMenu.ActivateMenu(
                "Bắt đầu game mới với tiến độ này sẽ làm mất tiến độ hiện tại. Bạn có chắc chắn?",
               
                () => {
                    QuanliLuutru.instance.ChangeSelectedProfileId(saveSlot.GetProfileId());
                    QuanliLuutru.instance.NewGame();
                    SaveGameAndLoadScene();
                },
                () => {
                    this.ActivateMenu(isLoadingGame);
                }
            );
        }
        else 
        {
            QuanliLuutru.instance.ChangeSelectedProfileId(saveSlot.GetProfileId());
            QuanliLuutru.instance.NewGame();
            SaveGameAndLoadScene();
        }
    }

    private void SaveGameAndLoadScene() 
    {
        QuanliLuutru.instance.SaveGame();
        SceneManager.LoadSceneAsync(2);
    }

    public void OnClearClicked(SaveSlot saveSlot) 
    {
        DisableMenuButtons();

        confirmationPopupMenu.ActivateMenu(
            "Bạn có chắc muốn xóa tiến độ này?",
            () => {
                QuanliLuutru.instance.DeleteProfileData(saveSlot.GetProfileId());
                ActivateMenu(isLoadingGame);
            },
            () => {
                ActivateMenu(isLoadingGame);
            }
        );
    }

    public void OnBackClicked() 
    {
        mainMenu.ActivateMenu();
        this.DeactivateMenu();
    }

    public void ActivateMenu(bool isLoadingGame) 
    {
        this.gameObject.SetActive(true);

        this.isLoadingGame = isLoadingGame;

        Dictionary<string, GameData> profilesGameData = QuanliLuutru.instance.GetAllProfilesGameData();

        backButton.interactable = true;

        GameObject firstSelected = backButton.gameObject;
        foreach (SaveSlot saveSlot in saveSlots) 
        {
            GameData profileData = null;
            profilesGameData.TryGetValue(saveSlot.GetProfileId(), out profileData);
            saveSlot.SetData(profileData);
            if (profileData == null && isLoadingGame) 
            {
                saveSlot.SetInteractable(false);
            }
            else 
            {
                saveSlot.SetInteractable(true);
                if (firstSelected.Equals(backButton.gameObject))
                {
                    firstSelected = saveSlot.gameObject;
                }
            }
        }

        Button firstSelectedButton = firstSelected.GetComponent<Button>();
        this.SetFirstSelected(firstSelectedButton);
    }

    public void DeactivateMenu() 
    {
        this.gameObject.SetActive(false);
    }

    private void DisableMenuButtons() 
    {
        foreach (SaveSlot saveSlot in saveSlots) 
        {
            saveSlot.SetInteractable(false);
        }
        backButton.interactable = false;
    }
}
