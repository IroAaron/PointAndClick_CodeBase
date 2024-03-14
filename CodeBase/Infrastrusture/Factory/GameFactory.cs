using CodeBase.Infrastrusture.AssetManagment;
using CodeBase.Logic;
using CodeBase.UnityComponents.UI;
using UnityEngine;

namespace CodeBase.Infrastrusture.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssets _assets;

        public GameFactory(IAssets assets)
        {
            _assets = assets;
        }

        public GameObject CreatePlayer(GameObject at) => 
            _assets.Instantiate(AssetPath.PlayerPath, at: at.transform.position);

        public GameObject CreateInventory(FadingScreen fadingScreen)
        {
            GameObject inventory = _assets.Instantiate(AssetPath.IntentoryPath);
            GameplayCanvas inventoryCanvas = inventory.GetComponent<GameplayCanvas>();
            inventoryCanvas.FadeScreen = fadingScreen;
            inventoryCanvas.injectionGameplayCanvasObjects = inventoryCanvas.GetComponentInChildren<IUIObject>();
            return inventory;
        }

        public GameObject CreateJournal(FadingScreen fadingScreen)
        {
            GameObject journal = _assets.Instantiate(AssetPath.JournalPath);
            GameplayCanvas jounalCanvas =  journal.GetComponent<GameplayCanvas>();
            jounalCanvas.FadeScreen = fadingScreen;
            jounalCanvas.injectionGameplayCanvasObjects = journal.GetComponentInChildren<IUIObject>();
            return journal;
        }
    }
}