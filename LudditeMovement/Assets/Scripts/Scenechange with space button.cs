using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class SceneSwitcher : MonoBehaviour
{
    public SceneAsset targetScene;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoadTargetScene();
        }
    }

    void LoadTargetScene()
    {
#if UNITY_EDITOR
        if (targetScene != null)
        {
            string scenePath = AssetDatabase.GetAssetPath(targetScene);
            string sceneName = System.IO.Path.GetFileNameWithoutExtension(scenePath);

            // 빌드 설정에 씬이 추가되어 있는지 확인합니다.
            if (IsSceneInBuildSettings(sceneName))
            {
                SceneManager.LoadScene(sceneName);
            }
            else
            {
                Debug.LogError("Scene '" + sceneName + "' is not added to the build settings.");
            }
        }
        else
        {
            Debug.LogWarning("Target scene is not set.");
        }
#else
        Debug.LogWarning("Scene switching is only supported in the editor.");
#endif
    }

    bool IsSceneInBuildSettings(string sceneName)
    {
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            string path = SceneUtility.GetScenePathByBuildIndex(i);
            string name = System.IO.Path.GetFileNameWithoutExtension(path);
            if (name == sceneName)
            {
                return true;
            }
        }
        return false;
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(SceneSwitcher))]
public class SceneSwitcherEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        SceneSwitcher script = (SceneSwitcher)target;
        if (script.targetScene != null)
        {
            EditorGUILayout.LabelField("Scene Name:", script.targetScene.name);
        }
    }
}
#endif
