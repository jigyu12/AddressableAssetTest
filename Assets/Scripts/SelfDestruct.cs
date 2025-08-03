using UnityEngine;
using UnityEngine.AddressableAssets;

public class SelfDestruct : MonoBehaviour
{
    public float liftTime = 2f;
    
    private void Start()
    {
        Invoke("Release", liftTime);
    }

    private void Release()
    {
        if(!Addressables.ReleaseInstance(gameObject))
        {
            Destroy(gameObject);
        }
    }
}