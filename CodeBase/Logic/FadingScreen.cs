using System;
using System.Collections;
using DG.Tweening;
using Fungus;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Logic
{
    public class FadingScreen : MonoBehaviour
    {
        public CanvasGroup FageScreen;
        public float EndAlpha;
        public float FadeDuration;

        void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public void Show()
        {
            FageScreen.DOFade(EndAlpha, FadeDuration);
        }

        public void Show(float fadeDuration)
        {
            FageScreen.DOFade(EndAlpha, fadeDuration);
        }

        public void Show(float endAlpha, float fadeDuration)
        {
            FageScreen.DOFade(endAlpha, fadeDuration);
        }

        public void Show(float endAlpha, float fadeDuration, TweenCallback action)
        {
            FageScreen.DOFade(endAlpha, fadeDuration).OnComplete(action);
        }

        public void Hide()
        {
            FageScreen.DOFade(0, FadeDuration);
        }

        public void Hide(float fadeDuration)
        {
            FageScreen.DOFade(0, fadeDuration);
        }

        public void Hide(float fadeDuration, TweenCallback action)
        {
            FageScreen.DOFade(0, fadeDuration).OnComplete(action);
        }
    }
}