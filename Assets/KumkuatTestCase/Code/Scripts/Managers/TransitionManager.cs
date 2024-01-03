using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// This is a namespace from my own code base.
namespace HappyTroll
{
    public class TransitionManager : SerializedPersistentSingleton<TransitionManager>
    {
        #region Private-Variables

        private ITransitionHandler _transitionHandler;
        private bool _canAnimateTransition;
        private string _nextScene;
        private string _postLoadingScene;
        private AsyncOperation _loadingOp;
        private Action<float> _progressCallback;
        private bool _allowFadeIn;

        #endregion

        protected override void Awake()
        {
            base.Awake();

            _transitionHandler = GetComponentInChildren<ITransitionHandler>();
            _canAnimateTransition = (_transitionHandler != null);
        }

        private void OnEnable()
        {
            SceneManager.sceneLoaded += HandleSceneLoaded;
            EventManager.OnSceneTransitionComplete += HandleFadeoutComplete;
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= HandleSceneLoaded;
            EventManager.OnSceneTransitionComplete -= HandleFadeoutComplete;
        }

        private void HandleFadeoutComplete()
        {
            _allowFadeIn = true;
            // This should be moved to ResourceManager in a better, future implementation
            Resources.UnloadUnusedAssets();
        }

        private void HandleSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
        {
            Time.timeScale = 1;
            
            if (loadSceneMode == LoadSceneMode.Additive)
                return;

            if (!_canAnimateTransition) return;
            
            _allowFadeIn = false;
            _transitionHandler.FadeOut(EventManager.SceneTransitionCompleteEvent);
        }

        /// <summary>
        /// Scene change request used to transition between scenes.
        ///
        /// A loading scene can be used as an intermediate scene to avoid loading 2 very large scenes simultaneously.
        /// </summary>
        /// <param name="sceneType"></param>
        /// <param name="useLoadingScene"></param>
        public void ChangeScene(Enums.SceneType sceneType, bool useLoadingScene = false)
        {
            string sceneName = NameFromIndex((int) sceneType);
            
            if (!useLoadingScene)
            {
                _nextScene = sceneName;
            }
            else
            {
                _postLoadingScene = sceneName;
                _nextScene = NameFromIndex((int) sceneType);
            }

            LoadScene(_canAnimateTransition);
        }

        private void LoadScene(bool isAnimated)
        {
            _loadingOp = SceneManager.LoadSceneAsync(_nextScene);
            _loadingOp.allowSceneActivation = false;
            StartCoroutine(WaitForLoading(isAnimated));
        }

        private IEnumerator WaitForLoading(bool isAnimated)
        {
            while (_loadingOp.progress < 0.9f)
            {
                _progressCallback?.Invoke(_loadingOp.progress);
                yield return null;
            }
    
            _progressCallback?.Invoke(1f);
            
            // Wait for fadeOut animation to complete to avoid bad transitions
            while (isAnimated && !_allowFadeIn)
                yield return null;
            
            _transitionHandler.FadeIn(AllowSceneChange);
        }

        private void AllowSceneChange()
        {
            _loadingOp.allowSceneActivation = true;
            _progressCallback = null;
        }

        /// <summary>
        /// Start the loading process.
        ///
        /// Triggered by the loading scene handler to get updates about loading progress for loading bar display.
        /// </summary>
        /// <param name="progressCallback">Handler method for progress updates.</param>
        public void StartLoading(Action<float> progressCallback)
        {
            _nextScene = _postLoadingScene;
            _postLoadingScene = "";
            _progressCallback = progressCallback;
            LoadScene(_canAnimateTransition);
        }
    
        private static string NameFromIndex(int BuildIndex)
        {
            string path = SceneUtility.GetScenePathByBuildIndex(BuildIndex);
            int slash = path.LastIndexOf('/');
            string name = path.Substring(slash + 1);
            int dot = name.LastIndexOf('.');
            return name.Substring(0, dot);
        }
    }
}