using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class manager : MonoBehaviour
{

    Vector3 p0 = new Vector3(0, 0, 0);
    Vector3 p1 = new Vector3(1, 0, 0);
    Vector3 p2 = new Vector3(0.5f, 0, Mathf.Sqrt(0.75f));
    Vector3 p3 = new Vector3(0.5f, Mathf.Sqrt(0.75f), Mathf.Sqrt(0.75f) / 3);

    public GameObject tetrahedron; // prefab da camrera
    public GameObject[] vetGameObj = new GameObject[24];
    GameObject pai;
    Vector3 m_Center;
    GameObject v0;
    GameObject v1;
    GameObject v2;
    GameObject v3;
    // Use this for initialization

    /*void RotacionarCamada(Vector3 verticeAlvo, List<GameObject> pecasDacamada,float angulo)
    {
        GameObject pivot = new GameObject("tempPivot");
        pivot.transform.position = m_center;

        Vector3 eixo = (verticeAlvo - m_Center).normalized;

    }*/
    void Start()
    {
        for (int i = 0; i < 24; i++)
        {

            if (i == 0)
            {

                vetGameObj[i] = Instantiate(tetrahedron, new Vector3(0, 0, 0), Quaternion.identity); // tetraedro base
                vetGameObj[i].name = "Tetra_" + i;
                Debug.Log(i + " -> " + vetGameObj[i].transform.position);

            }
            else
            {

                vetGameObj[i] = Instantiate(tetrahedron, new Vector3(vetGameObj[i - 1].transform.position.x + 1, 0, 0), vetGameObj[i - 1].transform.rotation);
                vetGameObj[i].name = "Tetra_" + i;
                Debug.Log(i + " -> " + vetGameObj[i].transform.position);

            }//i-1 posicao anterior
        }



        //pegar tetra da posicao 3 e transladar
        vetGameObj[3].transform.position = new Vector3(0.5f, 0.86603f, 0.28868f);
        vetGameObj[4].transform.position = new Vector3(0.5f * 3, 0.86603f, 0.28868f);
        vetGameObj[5].transform.position = new Vector3(0.5f, 0, Mathf.Sqrt(3) / 2);
        vetGameObj[6].transform.position = new Vector3(0.5f * 3, 0, Mathf.Sqrt(3) / 2);
        vetGameObj[7].transform.position = new Vector3(0.5f * 2, 0, Mathf.Sqrt(3));
        vetGameObj[8].transform.position = new Vector3(0.5f * 2, 0.86603f, 0.28868f + Mathf.Sqrt(3) / 2);
        vetGameObj[9].transform.position = new Vector3(0.5f * 2, 0.86603f * 2, 0.28868f * 2);

        // INVERTIDOS 


        vetGameObj[10].transform.position = new Vector3(0.5f * 3, 0.86603f, 0.28868f);
        vetGameObj[10].transform.Rotate(Vector3.right, 36.87f);
        vetGameObj[10].transform.Rotate(Vector3.forward, 180f);

        vetGameObj[11].transform.position = new Vector3(0.5f * 5, 0.86603f, 0.28868f);
        vetGameObj[11].transform.Rotate(Vector3.right, 36.87f);
        vetGameObj[11].transform.Rotate(Vector3.forward, 180f);

        vetGameObj[12].transform.position = new Vector3(0.5f * 4, 0.86603f * 2, 0.28868f * 2);
        vetGameObj[12].transform.Rotate(Vector3.right, 36.87f);
        vetGameObj[12].transform.Rotate(Vector3.forward, 180f);



        vetGameObj[13].transform.position = new Vector3(1.5f, 0, Mathf.Sqrt(3) / 2);
        vetGameObj[13].transform.Rotate(Vector3.up, 180f);

        vetGameObj[14].transform.position = new Vector3(2.5f, 0, Mathf.Sqrt(3) / 2);
        vetGameObj[14].transform.Rotate(Vector3.up, 180f);

        vetGameObj[15].transform.position = new Vector3(2f, 0, Mathf.Sqrt(3));
        vetGameObj[15].transform.Rotate(Vector3.up, 180f);



        pai = new GameObject();

        vetGameObj[16].transform.position = new Vector3(0.5f, 0.86603f, 0.28868f);
        pai.transform.position = new Vector3(1f, 0.86603f, 0.28868f + Mathf.Sqrt(3) / 2);
        pai.transform.Rotate(Vector3.down, 60f);
        vetGameObj[16].transform.parent = pai.transform;
        pai.transform.Rotate(Vector3.forward, 180f);
        pai.transform.Rotate(Vector3.right, 36.87f);
        vetGameObj[16].transform.parent = null;

        pai.transform.rotation = Quaternion.identity;
        vetGameObj[17].transform.position = new Vector3(0f, 0.86603f, -0.28868f * 2);
        pai.transform.position = new Vector3(0.5f, 0.86603f, 0.28868f);
        pai.transform.Rotate(Vector3.down, 60f);
        vetGameObj[17].transform.parent = pai.transform;
        pai.transform.Rotate(Vector3.forward, 180f);
        pai.transform.Rotate(Vector3.right, 36.87f);
        vetGameObj[17].transform.parent = null;

        pai.transform.rotation = Quaternion.identity;
        vetGameObj[18].transform.position = new Vector3(0.5f, 0.86603f * 2, -0.28868f);
        pai.transform.position = new Vector3(1f, 0.86603f * 2, 0.28868f * 2);
        pai.transform.Rotate(Vector3.down, 60f);
        vetGameObj[18].transform.parent = pai.transform;
        pai.transform.Rotate(Vector3.forward, 180f);
        pai.transform.Rotate(Vector3.right, 36.87f);
        vetGameObj[18].transform.parent = null;

        // OUTRO LADO!!!!!

        pai.transform.rotation = Quaternion.identity;
        vetGameObj[19].transform.position = new Vector3(0.5f * 4, 0.86603f, -0.28868f * 2);
        pai.transform.position = new Vector3(0.5f * 5, 0.86603f, 0.28868f);
        pai.transform.Rotate(Vector3.up, 60f);
        vetGameObj[19].transform.parent = pai.transform;
        pai.transform.Rotate(Vector3.forward, 180f);
        pai.transform.Rotate(Vector3.right, 36.87f);
        vetGameObj[19].transform.parent = null;


        pai.transform.rotation = Quaternion.identity;
        vetGameObj[20].transform.position = new Vector3(0.5f * 3, 0.86603f, 0.28868f);
        pai.transform.position = new Vector3(0.5f * 4, 0.86603f, 0.28868f + Mathf.Sqrt(3) / 2);
        pai.transform.Rotate(Vector3.up, 60f);
        vetGameObj[20].transform.parent = pai.transform;
        pai.transform.Rotate(Vector3.forward, 180f);
        pai.transform.Rotate(Vector3.right, 36.87f);
        vetGameObj[20].transform.parent = null;


        pai.transform.rotation = Quaternion.identity;
        vetGameObj[21].transform.position = new Vector3(0.5f * 3, 0.86603f * 2, -0.28868f);
        pai.transform.position = new Vector3(2f, 0.86603f * 2, 0.28868f * 2);
        pai.transform.Rotate(Vector3.up, 60f);
        vetGameObj[21].transform.parent = pai.transform;
        pai.transform.Rotate(Vector3.forward, 180f);
        pai.transform.Rotate(Vector3.right, 36.87f);
        vetGameObj[21].transform.parent = null;


        pai.transform.rotation = Quaternion.identity;




        Vector3 centro = ((p0 + p1 + p2 + p3) / 4) * 3;

        pai.transform.position = centro;

        v0 = new GameObject();
        v0.transform.position = new Vector3(0, 0, 0);

        v1 = new GameObject();
        v1.transform.position = new Vector3(3, 0, 0);
       

        //vetGameObj[3].transform.Rotate(110f,0f,0); // 90f
        // vetGameObj[3].transform.RotateAround(transform.position, Vector3.forward, 5f);

        //pai.transform.position = new Vector3(0,1,0); //pivo
        //pai.transform.position = new Vector3(0, 1, 0); //pivo
        //vetGameObj[3].transform.parent = pai.transform;
        //vetGameObj[3].transform.bounds

    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            pai.transform.rotation = Quaternion.identity;
            vetGameObj[9].transform.parent = pai.transform;
            pai.transform.Rotate(Vector3.up, 60f);
            vetGameObj[9].transform.parent = null;
        }

        if (Input.GetKeyDown(KeyCode.F1))
        {
            Vector3 direcao = v0.transform.position - pai.transform.position;
            direcao = direcao.normalized;

            // Desenha o vetor na Scene
            Debug.DrawRay(pai.transform.position, direcao * 5f, Color.red, 5f);

            pai.transform.rotation = Quaternion.LookRotation(direcao);
            vetGameObj[0].transform.SetParent(pai.transform);

            pai.transform.Rotate(Vector3.forward, 60f);
            vetGameObj[0].transform.parent = null;

            Debug.Log("f2.");
        }


        if (Input.GetKeyDown(KeyCode.F2))
        {
            Vector3 direcao = v1.transform.position - pai.transform.position;
            direcao = direcao.normalized;

            // Desenha o vetor na Scene
            Debug.DrawRay(pai.transform.position, direcao * 5f, Color.red, 5f);

            pai.transform.rotation = Quaternion.LookRotation(direcao);
            vetGameObj[2].transform.SetParent(pai.transform);

            pai.transform.Rotate(Vector3.forward, 60f);
            vetGameObj[2].transform.parent = null;

            Debug.Log("f2.");
        }


        //vetGameObj[3].transform.RotateAround(transform.position, Vector3.forward, 5f);
        //cria um gameobject: Pai. Tem eixo de rotacao
        //por o objeto como filho deste gameobject
        //rotaciona o gameObjet(pai): consequencia o filho rotaciona
        //Instantiate(Object original, Vector3 position, Quaternion rotation, Transform parent);
        //pai.transform.Rotate(Vector3.right * 5);




        //vetGameObj[4].transform.Rotate((Vector3.right + Vector3.up) * 5);
    }
}