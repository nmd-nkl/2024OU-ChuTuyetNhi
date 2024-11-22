namespace MJGame
{
    using UnityEditor;
    using UnityEngine;
    using System.IO;

    public class MJGameCreateSingletonComponentEditor : EditorWindow
    {
        private string className = "NewSingletonClass";

        [MenuItem("MJGame/Singleton", false, 50)]
        public static void ShowWindow()
        {
            MJGameCreateSingletonComponentEditor window = GetWindow<MJGameCreateSingletonComponentEditor>("Create Singleton Script");
            window.Show();
        }

        private void OnGUI()
        {
            GUILayout.Label("Enter Class Name for Singleton Script", EditorStyles.boldLabel);

            className = EditorGUILayout.TextField("Class Name", className);

            if (GUILayout.Button("Create Singleton Script"))
            {
                CreateSingletonScript(className);
                this.Close();
            }
        }

        public static void CreateSingletonScript(string className)
        {
            string path = GetSelectedPathOrFallback();
            string fileName = className + ".cs";
            string fullPath = Path.Combine(path, fileName);

            if (File.Exists(fullPath))
            {
                UnityEngine.Debug.LogError("File already exists at: " + fullPath);
                return;
            }

            if (!IsAnySingletonClass())
            {
                UnityEngine.Debug.Log("Create <color=yellow>SingletonComponent.cs</color> complete");
                CreateSingletonBaseClass();
            }

            string content = GetSingletonTemplate(className);

            File.WriteAllText(fullPath, content);
            UnityEngine.Debug.Log("Create <color=yellow>" + className + ".cs</color> complete");
            AssetDatabase.Refresh();
        }

        private static bool IsAnySingletonClass()
        {
            string[] allScripts = Directory.GetFiles("Assets", "*.cs", SearchOption.AllDirectories);

            foreach (string scriptPath in allScripts)
            {
                if (scriptPath.Contains("Editor"))
                {
                    continue;
                }

                try
                {
                    string content = File.ReadAllText(scriptPath);
                    bool canFile = scriptPath.Contains("SingletonComponent.cs");
                    if (content.Contains("SingletonComponent<") && canFile)
                    {
                        return true;
                    }
                }
                catch (IOException e)
                {
                    UnityEngine.Debug.LogWarning($"Error reading file {scriptPath}: {e.Message}");
                }
            }

            return false;
        }

        private static void CreateSingletonBaseClass()
        {
            string commonFolderPath = Path.Combine("Assets", "Scripts", "Common");

            if (!Directory.Exists(commonFolderPath))
            {
                Directory.CreateDirectory(commonFolderPath);
            }

            string singletonBaseClassFile = Path.Combine(commonFolderPath, "SingletonComponent.cs");

            if (!File.Exists(singletonBaseClassFile))
            {
                string baseClassContent = @"
using System;
using UnityEngine;

namespace MJGame
{
    public class SingletonComponent<T> : MonoBehaviour where T : UnityEngine.Object
    {
        private static T instance;

        public static T Instance
        {
            get
            {
                if (SingletonComponent<T>.instance == null)
                {
                    SingletonComponent<T>.instance = UnityEngine.Object.FindObjectOfType<T>();
                }
                if (SingletonComponent<T>.instance == null)
                {
                    UnityEngine.Debug.LogWarningFormat(""[SingletonComponent] Returning null instance for component of type {0}."", new object[] { typeof(T) });
                }
                return SingletonComponent<T>.instance;
            }
        }

        protected virtual void Awake()
        {
            this.SetInstance();
        }

        public static bool Exists()
        {
            return SingletonComponent<T>.instance != null;
        }

        public bool SetInstance()
        {
            if (SingletonComponent<T>.instance != null && SingletonComponent<T>.instance != base.gameObject.GetComponent<T>())
            {
                UnityEngine.Debug.LogWarning(""[SingletonComponent] Instance already set for type "" + typeof(T));
                return false;
            }
            SingletonComponent<T>.instance = base.gameObject.GetComponent<T>();
            return true;
        }
    }
}
";
                File.WriteAllText(singletonBaseClassFile, baseClassContent);
                AssetDatabase.Refresh();
            }
        }

        private static string GetSingletonTemplate(string className)
        {
            return
$@"using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace MJGame
{{
    public class {className}: SingletonComponent<{className}>
    {{
        // Start is called before the first frame update
        void Start()
        {{
                    
        }}

        // Update is called once per frame
        void Update()
        {{
                        
        }}
    }}
}}
";
        }

        private static string GetSelectedPathOrFallback()
        {
            string path = "Assets";
            foreach (Object obj in Selection.GetFiltered(typeof(Object), SelectionMode.Assets))
            {
                path = AssetDatabase.GetAssetPath(obj);
                if (!string.IsNullOrEmpty(path) && File.Exists(path))
                {
                    path = Path.GetDirectoryName(path);
                    break;
                }
            }
            return path;
        }
    }
}
