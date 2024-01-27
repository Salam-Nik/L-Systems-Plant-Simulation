using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFSW.QC;

public class ConsoleCommands : MonoBehaviour
{   

    public LSystem lSystem;

    [Command("reset")]
    public void Reset()
    {
        lSystem.Reset();
    }
    [Command("set-iterations")]
    public void SetIterations(int iter)
    {
        lSystem.SetIterations(iter);
    }
    [Command("set-angle")]
    public void SetAngle(float newVal)
    {
        lSystem.SetAngle(newVal);
    }
    [Command("add-widths")]
    public void SetWidths(float newVal)
    {
        lSystem.SetWidths(newVal);
    }
    [Command("set-length")]
    public void SetLength(float newVal)
    {
        lSystem.SetLength(newVal);
    }
    [Command("set-axiom")]
    public void SetAxiom(string newVal)
    {
        lSystem.SetAxiom(newVal);
    }
    [Command("add-rule")]
    public void AddRule(char key1, string value1)
    {
        lSystem.AddRule(key1, value1);
    }

    [Command("generate")]
    public void Update()
    {
        lSystem.UpdateTree();
    }
}