using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AVR.Utils.SceneManagement
{
    /// <summary>
    /// Utility to switch between scenes in the build index.
    /// This should be part of the main scene with build index 0;
    /// </summary>
    public class SceneSwitcher : Singleton<SceneSwitcher>
    {
        public Action<string> sceneChanged;

        public bool includeMainScene;

        private int totalScenesInBuild;
        private int currentLoadedSceneIndex;

        // Start is called before the first frame update
        protected override void Awake()
        {
            base.Awake();
            totalScenesInBuild = SceneManager.sceneCountInBuildSettings;
            currentLoadedSceneIndex = 0;
        }

        /// <summary>
        /// Loads the next scene
        /// </summary>
        public void NextScene()
        {
            StartCoroutine(NextSceneCoroutine());
        }

        /// <summary>
        /// Loads the previous scene
        /// </summary>
        public void PreviousScene()
        {
            StartCoroutine(PreviousSceneCoroutine());
        }

        private IEnumerator NextSceneCoroutine()
        {
            var sceneIndexToLoad = currentLoadedSceneIndex + 1;
            if (sceneIndexToLoad < totalScenesInBuild)
            {
                yield return LoadSceneCoroutine(sceneIndexToLoad);
            }
        }

        private IEnumerator PreviousSceneCoroutine()
        {
            var sceneIndexToLoad = currentLoadedSceneIndex - 1;
            if (sceneIndexToLoad > 0)
            {
                yield return LoadSceneCoroutine(sceneIndexToLoad);
            }
        }

        private IEnumerator LoadSceneCoroutine(int index)
        {
            if (currentLoadedSceneIndex != index && index != 0)
            {
                Debug.Log($"Loading scene with index {index}");
                yield return SceneManager.UnloadSceneAsync(currentLoadedSceneIndex);
                currentLoadedSceneIndex = index;
                yield return SceneManager.LoadSceneAsync(index, LoadSceneMode.Additive);
                var sceneName = SceneManager.GetSceneByBuildIndex(index).name;
                sceneChanged?.Invoke(sceneName);
            }
            else
            {
                Debug.Log($"Didn't scene with index {index}");
            }
        }
    }
}