using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

public class Multithreading : MonoBehaviour
{
    Quaternion rotate = Quaternion.Euler(1, 1, 1);
    Quaternion rotate2 = Quaternion.Euler(1, 1, 1);
    [SerializeField] Transform[] cubes;
    [SerializeField] Transform[] spheres;
    private void Start()
    {
        Thread t1 = new Thread(RotateCube);
        t1.Start();
        Thread t2 = new Thread(RotateSpheres);
        t2.Start();
    }

    private void Update()
    {
        for (int i = 0; i < cubes.Length; i++)
        {
            cubes[i].rotation = rotate;
            spheres[i].rotation = rotate2;
        }
    }

    void RotateCube()
    {
        while (true)
        {
            rotate *= Quaternion.Euler(0, 1, 0);
            Thread.Sleep(10);
        }
    }
    void RotateSpheres()
    {
        while (true)
        {
            rotate2 *= Quaternion.Euler(0, 1, 0);
            Thread.Sleep(10);
        }
    }
}
