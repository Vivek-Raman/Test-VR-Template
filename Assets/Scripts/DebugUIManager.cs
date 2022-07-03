using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DebugUIManager : MonoBehaviour
{
    private string selectedScene = "";
    
    private void Start()
    {
        int sceneCount = SceneManager.sceneCount;
        for (int i = 0; i < sceneCount; ++i)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            DebugUIBuilder.instance.AddRadio(scene.name, "sceneList", (Toggle t) =>
            {
                OnSceneSelectionChanged(scene.name, t.isOn);
            });
        }

        DebugUIBuilder.instance.AddButton("Load Scene", () =>
        {
            if (SceneManager.GetSceneByName(selectedScene).name == selectedScene)
            {
                SceneManager.LoadScene(selectedScene);
            }
        });
    }

    private void OnSceneSelectionChanged(string radioLabel, bool selected)
    {
        if (!selected) return;
        selectedScene = radioLabel;
    }
}
