using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class A4SignUpPage : MonoBehaviour
{
    private readonly string saveKey = "Profiles";

    [SerializeField]
    Profiles profiles = new Profiles();

    [SerializeField]
    private TMP_Dropdown profileDropdown;

    [SerializeField]
    private TMP_InputField nameInputField, cityInputField, yobInputField;

    [SerializeField]
    private TMP_Text warningText;

    
    // Start is called before the first frame update
    private void Start()
    {
        LoadProfiles();
        foreach (var profile in profiles.profilesList)
        {
            profileDropdown.options.Add(new(profile.profileID + ": " + profile.name));
        }
    }
    public void OpenProfile()
    {
        if (profileDropdown.value!=0)
        {
            var profileData = profiles.profilesList[profileDropdown.value - 1];
            nameInputField.text = profileData.name;
            cityInputField.text = profileData.city;
            yobInputField.text = profileData.yearOfBirth.ToString();
        }
    }

    public void RenameProfile()
    {
        if (profileDropdown.value != 0)
        {
            
            string temp = profileDropdown.value + ": " + nameInputField.text;
            profileDropdown.captionText.text = temp;
            profileDropdown.options[profileDropdown.value].text = temp;

            var profileData = profiles.profilesList[profileDropdown.value - 1];
            
            profileData.name = nameInputField.text;

            SaveProfiles();
        }
    }
    public void ValidateYear()
    {

    }

    public void SubmitProfile()
    {
        int temp;
        if (Int32.TryParse(yobInputField.text, out temp))
        {
            warningText.text = "";
        }
        else
        {
            warningText.text = "Please enter a valid year.";
            return;
        }

        if (profileDropdown.value == 0)
        {
            var profileData = new ProfileData();
            profileData.profileID = profiles.profilesList.Count + 1;
            profileData.name = nameInputField.text;
            profileData.city = cityInputField.text;
            
            profileData.yearOfBirth = temp;

            profiles.profilesList.Add(profileData);

            profileDropdown.options.Add(new(profileData.profileID + ": " + profileData.name));

            profileDropdown.value = profileData.profileID;
        }
        else
        {
            var profileData = profiles.profilesList[profileDropdown.value - 1];
            profileData.name = nameInputField.text;
            profileData.city = cityInputField.text;
            profileData.yearOfBirth = temp;
        }
        SaveProfiles();
    }
    private void LoadProfiles()
    {
        if (PlayerPrefs.HasKey(saveKey))
        {
            string serializedSaveData = PlayerPrefs.GetString(saveKey);
            profiles = JsonUtility.FromJson<Profiles>(serializedSaveData);
            Debug.Log("Loaded: " + serializedSaveData);

            return;
        }
        profiles = new Profiles();
    }
    private void SaveProfiles()
    {
        string serializedSaveData = JsonUtility.ToJson(profiles);
        PlayerPrefs.SetString(saveKey, serializedSaveData);
        Debug.Log("Saved: " + serializedSaveData);
    }
}


[Serializable]
public class Profiles
{
    public List<ProfileData> profilesList = new List<ProfileData>();
}

[Serializable]
public class ProfileData
{
    public int profileID;
    public string name;
    public string city;
    public int yearOfBirth;
}