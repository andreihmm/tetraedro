using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager : MonoBehaviour
{

    public GameObject tetrahedron; // prefab da camrera
    public GameObject[] vetGameObj = new GameObject[24];
    GameObject pai;
    Vector3 m_Center;

    /// FORMULAS MATEMATICAS:
    /// 
    float h = Mathf.Sqrt(6) / 3;


    float eixoX = .5f;
    float eixoY = Mathf.Sqrt(6) / 3;
    float eixoZ = Mathf.Sqrt(3) / 6;


    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 24; i++)
        {
            if (i == 0)
            {
                vetGameObj[i] = Instantiate(tetrahedron, new Vector3(0, 0, 0), Quaternion.identity); // tetraedro base
            }
            else
                vetGameObj[i] = Instantiate(tetrahedron, new Vector3(vetGameObj[i - 1].transform.position.x + 1, 0, 0), vetGameObj[i - 1].transform.rotation);
            //i-1 posicao anterior
        }

        pai = new GameObject();
        pai.transform.position = new Vector3(eixoX, eixoY, eixoZ);


        for (int i = 3; i < 5; i++)
        {
            vetGameObj[i].transform.position = new Vector3(
                pai.transform.position.x + 4 - i,
                pai.transform.position.y,
                pai.transform.position.z
            );
        }

        vetGameObj[5].transform.position = new Vector3(
                1,
                pai.transform.position.y * 2,
                pai.transform.position.z * 2
            );


        vetGameObj[6].transform.position = new Vector3(
            pai.transform.position.x * 3,
            0,
            Mathf.Sqrt(0.75f)
        );

        vetGameObj[7].transform.position = new Vector3(
            pai.transform.position.x * 2,
            0,
            Mathf.Sqrt(0.75f) * 2
        );

        vetGameObj[8].transform.position = new Vector3(
            pai.transform.position.x,
            0,
            Mathf.Sqrt(0.75f)
        );

        vetGameObj[9].transform.position = new Vector3(
            pai.transform.position.x * 2,
            pai.transform.position.y,
            Mathf.Sqrt(0.75f) + (1f / 6f) * Mathf.Sqrt(3)
        );

        vetGameObj[10].transform.position = new Vector3(
            pai.transform.position.x * 2,
            pai.transform.position.y,
            Mathf.Sqrt(0.75f) + (1f / 6f) * Mathf.Sqrt(3)
        );

        vetGameObj[11].transform.position = new Vector3(
            1.5f,
            0.822f,
            0.3f
         );
        vetGameObj[11].transform.Rotate(39f,0,180f); // 90f

        vetGameObj[12].transform.position = new Vector3(
            2.5f,
            0.822f,
            0.3f
         );
        vetGameObj[12].transform.Rotate(39f,0,180f); // 90f


        vetGameObj[13].transform.position = new Vector3(
            2.0f,
            0.822f + eixoY,
            0.59f
         );
        vetGameObj[13].transform.Rotate(39f,0,180f); // 90f

        vetGameObj[14].transform.position = new Vector3(
            1.5f,
            0,
            Mathf.Sqrt(0.75f)

         );
        vetGameObj[14].transform.Rotate(0,0180f,0); // 90f

        vetGameObj[15].transform.position = new Vector3(
            2.5f,
            0,
            Mathf.Sqrt(0.75f)

         );
        vetGameObj[15].transform.Rotate(0,0180f,0); // 90f

        vetGameObj[16].transform.position = new Vector3(
            2.0f,
            0,
            Mathf.Sqrt(0.75f) * 2
         );
        vetGameObj[16].transform.Rotate(0,0180f,0); // 90f

        vetGameObj[17].transform.position = new Vector3(
            1.664f,
            0.277f,
            0.388f
         );
        vetGameObj[17].transform.Rotate(-162f , -53.8f, -35.68f); // 90f

        vetGameObj[18].transform.position = new Vector3(
            1.664f - eixoX,
            0.277f,
            1.26f
         );
        vetGameObj[18].transform.Rotate(-162f , -53.8f, -35.68f); // 90f

        vetGameObj[19].transform.position = new Vector3(
            1.17f,
            0.277f + eixoY,
            0.67f
         );
        vetGameObj[19].transform.Rotate(-162f , -53.8f, -35.68f); // 90f

        vetGameObj[20].transform.position = new Vector3(
            1.0f,
            0.82f,
            1.16f
         );
        vetGameObj[20].transform.Rotate(-162f , 53.8f, 35.68f); // 90f

        vetGameObj[21].transform.position = new Vector3(
            1.5f,
            0.82f,
            2.032f
         );
        vetGameObj[21].transform.Rotate(-162f , 53.8f, 35.68f); // 90f

        vetGameObj[22].transform.position = new Vector3(
            1.5f,
            0.82f + eixoY,
            1.43f
         );
        vetGameObj[22].transform.Rotate(-162f , 53.8f, 35.68f); // 90f


        //vetGameObj[11].transform.Rotate(0, 0, 60f);




        //vetGameObj[3].transform.Rotate(110f,0f,0); // 90f


        //vetGameObj[3].transform.position = pai.transform.position;


        //vetGameObj[3].transform.bounds
    }


    // Update is called once per frame
    void Update()
    {
        //vetGameObj[3].transform.RotateAround(transform.position, Vector3.forward, 5f);
        //cria um gameobject: Pai. Tem eixo de rotacao
        //por o objeto como filho deste gameobject
        //rotaciona o gameObjet(pai): consequencia o filho rotaciona
        //Instantiate(Object original, Vector3 position, Quaternion rotation, Transform parent);
        //pai.transform.Rotate(Vector3.right * 5);


        // TETRAEDRO RODANDO:

        //vetGameObj[4].transform.Rotate((Vector3.right + Vector3.up) * 5);
    }
}