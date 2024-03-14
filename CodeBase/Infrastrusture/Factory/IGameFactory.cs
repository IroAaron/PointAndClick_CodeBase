using CodeBase.Infrastrusture.Services;
using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Infrastrusture.Factory
{
    public interface IGameFactory : IService
    {
        GameObject CreatePlayer(GameObject at);
        GameObject CreateInventory(FadingScreen fadingScreen);
        GameObject CreateJournal(FadingScreen fadingScreen);
    }
}