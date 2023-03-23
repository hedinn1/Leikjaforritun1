using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player; // Skilgreinir hlut sem vísar til leikmannsins sem myndavélin fylgir
    private Vector3 offset; // Breyta sem heldur utanum fjarlægðina milli myndavélar og leikmanns
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // LateUpdate er kallað einu sinni á hverjum ramma
    void LateUpdate()
    {
        transform.position = player.transform.position + offset; // Uppfærir staðsetningu myndavélarinnar
    }
}
