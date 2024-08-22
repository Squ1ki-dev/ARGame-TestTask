using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationFPS : MonoBehaviour
{
    private void Start() => Application.targetFrameRate = 30;
}
