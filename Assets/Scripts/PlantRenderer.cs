//using System.Collections.Generic;
//using UnityEngine;

//public class PlantRenderer : MonoBehaviour
//{
//    public int iterations = 4;
//    public float angle = 30f;
//    public float width = 1f;
//    public float length = 2f;
//    public GameObject Tree = null;

//    [SerializeField] private GameObject treeParent;
//    [SerializeField] private GameObject branch;
//    [SerializeField] private GameObject leaf;

//    private LSystem lSystem;

//    private int titleLastFrame;
//    private int iterationsLastFrame;
//    private float angleLastFrame;
//    private float widthLastFrame;
//    private float lengthLastFrame;
//    private string CurrentString = string.Empty;
//    private Vector3 initialPosition = Vector3.zero;
//    private float[] randomRotationValues = new float[100];

//    void Start()
//    {   

//        lSystem = GetComponent<LSystem>();
//        RenderPlant();
//    }
//    // void Update()
//    //{
//    //    if (iterationsLastFrame != iterations ||
//    //        angleLastFrame != angle ||
//    //    widthLastFrame != width ||
//    //        lengthLastFrame != length)
//    //    {
          
//    //        RenderPlant();
//    //    }

//    //}
//    void RenderPlant()
//    {
//        Stack<State> savedStates = new Stack<State>();
//        int i = 0;
//        Debug.Log(lSystem.CurrentString);
//        foreach (char c in lSystem.CurrentString)
//        {
//              if (c == 'F') { 
//                initialPosition = transform.position;
//                transform.Translate(Vector3.up * 2 * length);

//                GameObject fLine =  lSystem.CurrentString[(i + 1) %  lSystem.CurrentString.Length] == 'X' ||  lSystem.CurrentString[(i + 3) %  lSystem.CurrentString.Length] == 'F' &&  lSystem.CurrentString[(i + 4) %  lSystem.CurrentString.Length] == 'X' ? Instantiate(leaf) : Instantiate(branch);
//                fLine.transform.SetParent(Tree.transform);
//                fLine.GetComponent<LineRenderer>().SetPosition(0, initialPosition);
//                fLine.GetComponent<LineRenderer>().SetPosition(1, transform.position);
//                fLine.GetComponent<LineRenderer>().startWidth = width;
//                fLine.GetComponent<LineRenderer>().endWidth = width;

//            }
//            else if (c == '+')
//            {
//                // Rotate right
//                transform.Rotate(Vector3.forward * angle);
//            }
//            else if (c == '-')
//            {
//                // Rotate left
//                transform.Rotate(Vector3.back * angle);
//            }
//            else if (c == '[')
//            {
//                // Save current position and rotation
//                savedStates.Push(new State { position = transform.position, rotation = transform.rotation });
//            }
//            else if (c == ']')
//            {
//                // Restore previous position and rotation
//                State state = savedStates.Pop();
//                transform.position = state.position;
//                transform.rotation = state.rotation;
//            }
//            //else if (c == 'L')
//            //{
//            //    // Create a leaf
//            //    Instantiate(leafPrefab, transform.position, Quaternion.identity);
//            //}
//            //else if (c == 'F')
//            //{
//            //    // Create a flower
//            //    Instantiate(flowerPrefab, transform.position, Quaternion.identity);
//            //}
//            i++;
//        }
//    }
//}
