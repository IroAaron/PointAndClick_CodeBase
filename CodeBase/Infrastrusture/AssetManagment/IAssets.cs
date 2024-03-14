using CodeBase.Infrastrusture.Services;
using UnityEngine;

namespace CodeBase.Infrastrusture.AssetManagment
{
    public interface IAssets : IService
    {
        GameObject Instantiate(string path);
        GameObject Instantiate(string path, Vector3 at);
    }
}