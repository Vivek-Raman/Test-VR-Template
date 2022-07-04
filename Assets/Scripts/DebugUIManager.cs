using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DebugUIManager : MonoBehaviour
{
    private string selectedScenePath = "";
    
    private void Start()
    {
        int sceneCount = SceneManager.sceneCountInBuildSettings;
        for (int i = 0; i < sceneCount; ++i)
        {
            string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
            DebugUIBuilder.instance.AddRadio(scenePath, "sceneList", (Toggle t) =>
            {
                if (!t.isOn) return;
                selectedScenePath = scenePath;
            });
        }

        DebugUIBuilder.instance.AddButton("Load Scene", () =>
        {
            SceneManager.LoadScene(SceneUtility.GetBuildIndexByScenePath(selectedScenePath));
        });

        DebugUIBuilder.instance.Show();
    }
}
