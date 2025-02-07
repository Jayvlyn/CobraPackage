using System.IO;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class CreateFolderUtility : EditorWindow
{
    [MenuItem("Assets/Folder Template Builder")]
    public static void OpenWindow()
    {
        GetWindow<CreateFolderUtility>();
    }

    private static readonly string pathDirectory = "Assets/_Project/Systems";
    private string folderName = "Name";
    
    void OnGUI()
    {
        GUI.SetNextControlName("inputFieldFolder");
        GUILayout.Label("System Name", EditorStyles.boldLabel);
        folderName = EditorGUILayout.TextField(folderName);
        EditorGUI.FocusTextInControl("inputFieldFolder");
        
        if (GUILayout.Button("Create System Template"))
        {
            Build();
        }
    }

    void Build()
    {
        string systemFolderName = folderName + "System";
        string sceneDirectory = pathDirectory + "/" + systemFolderName;
        string assetDirectory = sceneDirectory + "/Tests";
            
        CreateFolders(pathDirectory, systemFolderName);
        CreateScene(sceneDirectory);
        CreateAssets(assetDirectory);
        AssetDatabase.Refresh();
        Close();
    }

    void CreateFolders(string parentDirectory, string systemFolderName)
    {
        AssetDatabase.CreateFolder(parentDirectory, systemFolderName);
        AssetDatabase.CreateFolder(System.IO.Path.Combine(parentDirectory, systemFolderName), "Tests");
    }

    void CreateScene(string parentDirectory)
    {
        var newScene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);

        GameObject go = new GameObject();
        go.name = "Tests";
        EditorSceneManager.MoveGameObjectToScene(go, newScene);

        string scenePath = parentDirectory + "/Example.unity";
        EditorSceneManager.SaveScene(newScene, scenePath);
        EditorSceneManager.OpenScene(scenePath);
    }

    void CreateAssets(string parentDirectory)
    {
        CreateFile(parentDirectory, "UT_" + folderName);
    }

    void CreateFile(string parentDirectory, string scriptName)
    {
        string filePath = parentDirectory + "/" + scriptName + ".cs";
        string scriptContent = 
            "using UnityEngine.Assertions;\n" +
            "using Cobra.UnitTesting;\n" +
            "using UnityEngine;\n\n" +
            "namespace Cobra.UnitTesting" + ".Tests\n" +
            "{\n" +
            "    public class " + scriptName + " : UnitTest\n" +
            "    {\n" +
            "        \n" +
            "    }\n" +
            "}";

        File.WriteAllText(filePath, scriptContent);
    }
}