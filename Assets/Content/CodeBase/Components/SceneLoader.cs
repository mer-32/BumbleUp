using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Content.CodeBase.Components
{
    public class SceneLoader
    {
        private CoroutineRunner _coroutineRunner;
        
        public SceneLoader(CoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public void Load(string name, Action onLoaded)
        {
            _coroutineRunner.StartCoroutine(LoadScene(name, onLoaded));
        }
        
        private IEnumerator LoadScene(string name, Action onLoaded)
        {
            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(name);

            while (!waitNextScene.isDone) yield return null;
            
            onLoaded?.Invoke();
        }
    }
}