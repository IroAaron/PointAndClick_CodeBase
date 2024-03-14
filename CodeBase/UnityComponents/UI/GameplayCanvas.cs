using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CodeBase.Logic;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UnityComponents.UI
{
    public class GameplayCanvas : MonoBehaviour
    {
        public Camera Camera;
        public FadingScreen FadeScreen;
        public Button OpenJournal;

        public IUIObject injectionGameplayCanvasObjects;

        void Start()
        {
            if(Camera == null)
            {
                Camera = Camera.main;
            }

            if(injectionGameplayCanvasObjects == null)
            {
                injectionGameplayCanvasObjects = GetComponentInChildren<IUIObject>();
            }

            injectionGameplayCanvasObjects.Inject(this);
        }
    }
}