
using UnityEngine;
using UnityEngine.UI;


public class State : MonoBehaviour
{
    public bool hasGenerateBeenPressed = false;
    public bool hasResetBeenPressed = false;
    public Slider rotation;
    public Text warning;

    [SerializeField] private LSystem TreeSpawner;

    public void Start()
    {

        rotation.gameObject.SetActive(false);
        warning.gameObject.SetActive(false);
    }

    public void TitleUp()
    {
        if (TreeSpawner.title < LSystem.NUM_OF_TREES)
        {
            TreeSpawner.title++;
            TreeSpawner.hasTreeChanged = true;
        }
    }
    public void TitleDown()
    {
        if (TreeSpawner.title > 1)
        {
            TreeSpawner.title--;
            TreeSpawner.hasTreeChanged = true;
        }
    }

    public void GenerateNew()
    {
        hasGenerateBeenPressed = true;
    }

    public void ResetValues()
    {
        hasResetBeenPressed = true;
    }

    public void RotateTree()
    {
        TreeSpawner.Tree.transform.rotation = Quaternion.Euler(0, rotation.value, 0);
    }



}
