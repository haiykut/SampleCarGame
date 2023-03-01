using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
namespace haiykut
{
    public class LoadingManager : MonoBehaviour
    {
        public Slider loadingBar;
        bool loader;
        public float amountValue;
        float progress;
        AsyncOperation operation;
        public GameObject loadingPanel;
        public static LoadingManager instance;
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            if (instance == null)
                instance = this;
            else
                Destroy(gameObject);
        }
        private int sceneIndexFromName(string n)
        {

            for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
            {
                string pivotName = nameFromIndex(i);
                if (pivotName == n)
                {
                    return i;
                }
            }
            return -1;
        }
        public void loadScene(string name)
        {
            loadingPanel.SetActive(true);
            operation = SceneManager.LoadSceneAsync(sceneIndexFromName(name));
            loader = true;
        }
        private static string nameFromIndex(int BuildIndex)
        {
            string path = SceneUtility.GetScenePathByBuildIndex(BuildIndex);
            int slash = path.LastIndexOf('/');
            string name = path.Substring(slash + 1);
            int dot = name.LastIndexOf('.');
            return name.Substring(0, dot);
        }

        private void Update()
        {
            if (loader)
            {
                if (!operation.isDone)
                {
                    progress += Time.deltaTime * amountValue;
                    loadingBar.value = progress;
                }
                else
                {
                    loadingPanel.SetActive(false);
                    loader = false;
                    loadingBar.value = 0;
                    progress = 0f;
                    operation = null;
                }
            }
        }
    }

}
