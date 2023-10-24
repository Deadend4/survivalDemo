using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class SprintCameraCorrector : MonoBehaviour
{
    StarterAssetsInputs saInput;
    [SerializeField] GameObject characterCameraRoot;
    [SerializeField] float slideValue;
    [SerializeField] float speedTransition;
    Vector3 basicCameraPosition,
    newCameraPosition;
    // Start is called before the first frame update
    void Start()
    {
        saInput = GetComponent<StarterAssetsInputs>();
        basicCameraPosition = characterCameraRoot.transform.localPosition;
        newCameraPosition = new Vector3(basicCameraPosition.x, basicCameraPosition.y, basicCameraPosition.z + slideValue);
    }

    // Update is called once per frame
    void Update()
    {
        if (saInput.sprint && !(characterCameraRoot.transform.localPosition == newCameraPosition))
        {
            characterCameraRoot.transform.localPosition = Vector3.Lerp(basicCameraPosition, newCameraPosition, speedTransition);
        }
        else if (!saInput.sprint && !(characterCameraRoot.transform.localPosition == basicCameraPosition))
        {
            characterCameraRoot.transform.localPosition = Vector3.Lerp(newCameraPosition, basicCameraPosition, speedTransition);
        }
    }
}
