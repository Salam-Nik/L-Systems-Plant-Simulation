
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEditor;

[System.Serializable]
public class LSystemRule
{
    public char key;
    public string value;
}
public class LSystem : MonoBehaviour
{   

    public static int NUM_OF_TREES = 8;
    public static int MAX_ITERATIONS = 7;

    public int title = 1;
    public int iterations = 4;
    public float angle = 30f;
    public float width = 1f;
    public float length = 2f;
    public bool hasTreeChanged = false;
    public GameObject Tree = null;

    [SerializeField] private GameObject treeParent;
    [SerializeField] private GameObject branch;
    [SerializeField] private GameObject leaf;
    [SerializeField] private State state;
    [SerializeField] private string axiom = "X";
    [SerializeField] private List<LSystemRule> rules;

    public List<LSystemRule> Rules => rules;
    private Stack<TransformInfo> transformStack;
    private int titleLastFrame;
    private int iterationsLastFrame;
    private float angleLastFrame;
    private float widthLastFrame;
    private float lengthLastFrame;
    private string currentString = string.Empty;
    private Vector3 initialPosition = Vector3.zero;
    private float[] randomRotationValues = new float[100];
    
    private void Start()
    {
        titleLastFrame = title;
        iterationsLastFrame = iterations;
        angleLastFrame = angle;
        widthLastFrame = width;
        lengthLastFrame = length;

        transformStack = new Stack<TransformInfo>();
     
         rules = new List<LSystemRule>
    {
        new LSystemRule { key = 'X', value = "[-FX]X[+FX][+F-FX]" },
        new LSystemRule { key = 'F', value = "FF" }
    };

    Generate();
    }

    public void UpdateTree()
    {
        if (state.hasGenerateBeenPressed || Input.GetKeyDown(KeyCode.G))
        {
            state.hasGenerateBeenPressed = false;
            Generate();
        }


        if (titleLastFrame != title)
        {
            if (title >= 6)
            {
                state.rotation.gameObject.SetActive(true);
            }
            else
            {
                state.rotation.value = 0;
                state.rotation.gameObject.SetActive(false);
            }

            titleLastFrame = title;
        }



        if (iterationsLastFrame != iterations ||
                angleLastFrame  != angle ||
                widthLastFrame  != width ||
                lengthLastFrame != length)
        {
            ResetFlags();
            Generate();
        }

    }

    public void Reset()
    {

            ResetTreeValues();
            state.hasResetBeenPressed = false;
            Generate();
   
    }
    public void SetIterations(int iter)
    {
        iterations = iter;
        Generate();
    }
    public void SetAngle(float newVal)
    {
        angle = newVal;
        Generate();
    }
    public void SetWidths(float newVal)
    {
        width = newVal;
        Generate();
    }
    public void SetLength(float newVal)
    {
        length = newVal;
        Generate();
    }
    public void SetAxiom(string newVal)
    {
        axiom = newVal;
        Generate();
    }
    public void AddRule(char key1, string value1)
    {
        rules.Add(new LSystemRule{ key = key1, value = value1 });
    }

    public void Generate()
    {
        Destroy(Tree);

        Tree = Instantiate(treeParent);

        currentString = axiom;

        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < iterations; i++)
        {
            foreach (char c in currentString)
            {
                string rule = rules.Find(r => r.key == c)?.value ?? c.ToString();
                sb.Append(rule);
            }

            currentString = sb.ToString();
            sb = new StringBuilder();
        }

        Debug.Log(currentString);
        
        for (int i = 0; i < currentString.Length; i++)
        {
            switch (currentString[i])
            {
                case 'F':                    
                    initialPosition = transform.position;
                    transform.Translate(Vector3.up * 2 * length);                    

                    GameObject fLine = currentString[(i + 1) % currentString.Length] == 'X' || currentString[(i + 3) % currentString.Length] == 'F' && currentString[(i + 4) % currentString.Length] == 'X' ? Instantiate(leaf) : Instantiate(branch);
                    fLine.transform.SetParent(Tree.transform);
                    fLine.GetComponent<LineRenderer>().SetPosition(0, initialPosition);
                    fLine.GetComponent<LineRenderer>().SetPosition(1, transform.position);
                    fLine.GetComponent<LineRenderer>().startWidth = width;
                    fLine.GetComponent<LineRenderer>().endWidth = width;
                    break;

                case 'X':                
                    break;

                case '+':
                    transform.Rotate(Vector3.back * angle);
                    break;

                case '-':                                      
                    transform.Rotate(Vector3.forward * angle);
                    break;

                case '*':
                    transform.Rotate(Vector3.up * 120);
                    break;

                case '/':
                    transform.Rotate(Vector3.down* 120);
                    break;

                case '[':
                    transformStack.Push(new TransformInfo()
                    {
                        position = transform.position,
                        rotation = transform.rotation
                    });
                    break;

                case ']':
                    TransformInfo ti = transformStack.Pop();
                    transform.position = ti.position;
                    transform.rotation = ti.rotation;
                    break;

                default:
                    throw new System.InvalidOperationException("Invalid L-tree operation");
            }
        }

        Tree.transform.rotation = Quaternion.Euler(0, state.rotation.value, 0);
    }

    private void SelectTreeOne()
    {
        Generate();
    }


    private void ResetFlags()
    {
        iterationsLastFrame = iterations;
        angleLastFrame = angle;
        widthLastFrame = width;
        lengthLastFrame = length;
    }

    private void ResetTreeValues()
    {
        iterations = 4;
        angle = 30f;
        width = 1f;
        length = 2f;
    }
}