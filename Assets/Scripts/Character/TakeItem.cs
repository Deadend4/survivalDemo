using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using TMPro;

public class TakeItem : MonoBehaviour
{
    [Header("Animation")]
    [SerializeField] Camera MainCamera;
    [SerializeField] Transform headBone;
    [SerializeField] Transform cameraRootParent;
    [SerializeField] GameObject cameraRootObject;
    [SerializeField] GameObject oldCameraPosition;
    [SerializeField] AnimationClip animationInteract;
    private CharacterAnimation characterAnimation;
    private Animator animator;
    [Header("Take Item")]
    [SerializeField] KeyCode Interact;
    [SerializeField] KeyCode Throw;
    [SerializeField] Transform handSocket;
    [SerializeField] TMP_Text textInfo;
    [HideInInspector] public bool isGrabed = false;
    private GameObject tempHandObject;
    [Header("Raycast")]
    [SerializeField] LayerMask interactMask;
    [SerializeField] LayerMask turnMask;
    private Vector3 Ray_start_pos = new Vector3(Screen.width / 2, Screen.height / 2, 0);
    private RaycastHit hit, groundHit;
    private bool isItemFocused = false;
    private bool isPrefabShown = false;
    [Header("Spawn")]
    [SerializeField] Inventory inventory;
    void Start()
    {
        characterAnimation = GetComponent<CharacterAnimation>();
        animator = GetComponent<Animator>();
        CopyTransform(cameraRootObject.transform, oldCameraPosition.transform);
        inventory = GetComponent<Inventory>();
        textInfo.text = "";
    }
    void Update()
    {

        if (hit.collider != null)
        {
            if (!isItemFocused)
            {
                textInfo.text = hit.transform.gameObject.name;
                isItemFocused = true;
            }
            if (Input.GetKeyDown(Interact) && !isGrabed && hit.transform.gameObject.tag != "Turn")
            {
                StartCoroutine("grab");
            }
            if (Input.GetKeyDown(Interact) && hit.transform.gameObject.tag == "Turn")
            {
                hit.transform.gameObject.GetComponent<TurnOn>().startEffect();
            }
        }
        else
        {
            if (isItemFocused)
            {
                textInfo.text = "";
                isItemFocused = false;
            }

        }
        if (isGrabed && Input.GetKeyDown(Throw))
        {
            throwItem();
        }
    }
    private void FixedUpdate()
    {
        releaseRay();
        if (!isGrabed && characterAnimation.isInteracting)
        {
            characterAnimation.isInteracting = false;
        }
    }

    IEnumerator grab()
    {
        characterAnimation.isInteracting = true;
        tempHandObject = hit.transform.gameObject;
        isGrabed = true;
        tempHandObject.GetComponent<Rigidbody>().isKinematic = true;
        yield return new WaitForSeconds(0.15f);
        tempHandObject.transform.SetParent(handSocket);
        tempHandObject.transform.localPosition = Vector3.zero;
        tempHandObject.transform.localRotation = new Quaternion(0, 0, 0, 0);
    }
    private void releaseRay()
    {
        // Сам луч
        Ray ray = MainCamera.ScreenPointToRay(Ray_start_pos);
        Physics.Raycast(ray, out hit, 2, interactMask);
        Physics.Raycast(ray, out groundHit, 3, turnMask);
    }
    public static void CopyTransform(Transform sourceRoot, Transform destRoot)
    {
        Vector3 localPos = sourceRoot.localPosition;
        destRoot.localPosition = localPos;
    }
    public void throwItem()
    {
        if (isGrabed)
        {
            tempHandObject.transform.parent = null;
            tempHandObject.GetComponent<Rigidbody>().isKinematic = false;
            isGrabed = false;
        }
    }
    public void showPrefab(GameObject prefab, RaycastHit castHit)
    {
        prefab.transform.position = castHit.point;
    }
    public GameObject spawnPrefab(GameObject prefab, Vector3 prefabPosition)
    {
        isPrefabShown = true;
        return Instantiate(prefab, prefabPosition, Quaternion.identity);
    }
}
