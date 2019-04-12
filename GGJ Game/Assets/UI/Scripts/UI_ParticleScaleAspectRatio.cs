using UnityEngine;
using System.Collections;

public class UI_ParticleScaleAspectRatio : MonoBehaviour
{
    //Assume 16:9 (1.777778) is the Aspect Ratio used when developing. 
    //Assume developing Scale at 1,1,1
    //4:3 will become Scale 0.75,0.75,0.75

    void Start()
    {
        float currentAspectRatio = (float)Screen.width / (float)Screen.height;
        float newScale = currentAspectRatio / 1.777778F;
        gameObject.transform.localScale = new Vector3(newScale, newScale, newScale);
    }
}
