using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResolutionManager : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resolutionDropdown;
    private Resolution[] availableResolutions;
    private List<Resolution> uniqueResolutions = new List<Resolution>();
    private int currentResolutionIndex = 0;

    void Start()
    {
        availableResolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        // Filter and remove duplicates from available resolutions
        FilterResolutions();

        List<string> options = new List<string>();

        for (int i = 0; i < uniqueResolutions.Count; i++)
        {
            string resolutionOption = uniqueResolutions[i].width + "x" + uniqueResolutions[i].height;
            options.Add(resolutionOption);

            // Check if this resolution matches the current screen resolution
            if (uniqueResolutions[i].width == Screen.width && uniqueResolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        // Add listener for when the dropdown value changes
        resolutionDropdown.onValueChanged.AddListener(SetResolution);
    }

    private void FilterResolutions()
    {
        // Use a HashSet to track unique resolutions by width and height
        HashSet<string> resolutionSet = new HashSet<string>();

        foreach (Resolution res in availableResolutions)
        {
            string resolutionKey = res.width + "x" + res.height;
            if (!resolutionSet.Contains(resolutionKey))
            {
                resolutionSet.Add(resolutionKey);
                uniqueResolutions.Add(res);
            }
        }
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = uniqueResolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    private void OnDestroy()
    {
        // Remove the listener when the object is destroyed
        resolutionDropdown.onValueChanged.RemoveListener(SetResolution);
    }
}
