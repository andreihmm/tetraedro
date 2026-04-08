using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PRECISA DESATIVAR O GAME OBJECT DA SCENE PARA SUMIR O TETRAEDRO FANTASMA
// COMO DETECTAR QUAL TETRAEDRO ESTÁ EM QUAL POSIÇAO?
// IDEIA => SUBSTITUIR NUMEROS HARD-CODED POR VARIAVEIS!!!
public class manager : MonoBehaviour
{

    Vector3 p0 = new Vector3(0, 0, 0);
    Vector3 p1 = new Vector3(1, 0, 0);
    Vector3 p2 = new Vector3(0.5f, 0, Mathf.Sqrt(0.75f));
    Vector3 p3 = new Vector3(0.5f, Mathf.Sqrt(0.75f), Mathf.Sqrt(0.75f) / 3);

    public GameObject tetrahedron; // prefab da camrera
    public GameObject[] vetGameObj = new GameObject[24];
    public GameObject[] gameObjBaricentro = new GameObject[24];
    GameObject pai;
    Vector3 m_Center;
    GameObject v0;
    GameObject v1;
    GameObject v2;
    GameObject v3;
    int[] tetraNoBaricentro;

    // Use this for initialization

    /*void RotacionarCamada(Vector3 verticeAlvo, List<GameObject> pecasDacamada,float angulo)
    {
        GameObject pivot = new GameObject("tempPivot");
        pivot.transform.position = m_center;

        Vector3 eixo = (verticeAlvo - m_Center).normalized;

    }*/
    void Start()
    {
        pai = new GameObject();
        pai.name = "pai";
        for (int i = 0; i < 24; i++)
        {

            if (i == 0)
            {

                vetGameObj[i] = Instantiate(tetrahedron, new Vector3(0, 0, 0), Quaternion.identity); // tetraedro base
                vetGameObj[i].name = "Tetra_" + i;
                gameObjBaricentro[i] = new GameObject();
                gameObjBaricentro[i].name = "Bari_" + i;
                gameObjBaricentro[i].transform.position = baricentro(vetGameObj[i]);

            }
            else
            {
                vetGameObj[i] = Instantiate(tetrahedron, new Vector3(vetGameObj[i - 1].transform.position.x + 1, 0, 0), vetGameObj[i - 1].transform.rotation);
                vetGameObj[i].name = "Tetra_" + i;
                gameObjBaricentro[i] = new GameObject();
                gameObjBaricentro[i].name = "Bari_" + i;
                gameObjBaricentro[i].transform.position = baricentro(vetGameObj[i]);
            }//i-1 posicao anterior
        }

        vetGameObj[0].transform.parent = gameObjBaricentro[0].transform;
        vetGameObj[1].transform.parent = gameObjBaricentro[1].transform;
        vetGameObj[2].transform.parent = gameObjBaricentro[2].transform;


        //pegar tetra da posicao 3 e transladar
        vetGameObj[3].transform.position = new Vector3(0.5f, 0.86603f, 0.28868f);
        gameObjBaricentro[3].transform.position = baricentro(vetGameObj[3]);
        vetGameObj[3].transform.parent = gameObjBaricentro[3].transform;

        vetGameObj[4].transform.position = new Vector3(0.5f * 3, 0.86603f, 0.28868f);
        gameObjBaricentro[4].transform.position = baricentro(vetGameObj[4]);
        vetGameObj[4].transform.parent = gameObjBaricentro[4].transform;

        vetGameObj[5].transform.position = new Vector3(0.5f, 0, Mathf.Sqrt(3) / 2);
        gameObjBaricentro[5].transform.position = baricentro(vetGameObj[5]);
        vetGameObj[5].transform.parent = gameObjBaricentro[5].transform;

        vetGameObj[6].transform.position = new Vector3(0.5f * 3, 0, Mathf.Sqrt(3) / 2);
        gameObjBaricentro[6].transform.position = baricentro(vetGameObj[6]);
        vetGameObj[6].transform.parent = gameObjBaricentro[6].transform;

        vetGameObj[7].transform.position = new Vector3(0.5f * 2, 0, Mathf.Sqrt(3));
        gameObjBaricentro[7].transform.position = baricentro(vetGameObj[7]);
        vetGameObj[7].transform.parent = gameObjBaricentro[7].transform;

        vetGameObj[8].transform.position = new Vector3(0.5f * 2, 0.86603f, 0.28868f + Mathf.Sqrt(3) / 2);
        gameObjBaricentro[8].transform.position = baricentro(vetGameObj[8]);
        vetGameObj[8].transform.parent = gameObjBaricentro[8].transform;

        vetGameObj[9].transform.position = new Vector3(0.5f * 2, 0.86603f * 2, 0.28868f * 2);
        gameObjBaricentro[9].transform.position = baricentro(vetGameObj[9]);
        vetGameObj[9].transform.parent = gameObjBaricentro[9].transform;


        // INVERTIDOS 

        vetGameObj[10].transform.position = new Vector3(0.5f * 3, 0.86603f, 0.28868f);
        vetGameObj[10].transform.Rotate(Vector3.right, 36.87f);
        vetGameObj[10].transform.Rotate(Vector3.forward, 180f);
        gameObjBaricentro[10].transform.position = baricentro(vetGameObj[10]);
        vetGameObj[10].transform.parent = gameObjBaricentro[10].transform;

        vetGameObj[11].transform.position = new Vector3(0.5f * 5, 0.86603f, 0.28868f);
        vetGameObj[11].transform.Rotate(Vector3.right, 36.87f);
        vetGameObj[11].transform.Rotate(Vector3.forward, 180f);
        gameObjBaricentro[11].transform.position = baricentro(vetGameObj[11]);
        vetGameObj[11].transform.parent = gameObjBaricentro[11].transform;

        vetGameObj[12].transform.position = new Vector3(0.5f * 4, 0.86603f * 2, 0.28868f * 2);
        vetGameObj[12].transform.Rotate(Vector3.right, 36.87f);
        vetGameObj[12].transform.Rotate(Vector3.forward, 180f);
        gameObjBaricentro[12].transform.position = baricentro(vetGameObj[12]);
        vetGameObj[12].transform.parent = gameObjBaricentro[12].transform;

        vetGameObj[13].transform.position = new Vector3(1.5f, 0, Mathf.Sqrt(3) / 2);
        vetGameObj[13].transform.Rotate(Vector3.up, 180f);
        gameObjBaricentro[13].transform.position = baricentro(vetGameObj[13]);
        vetGameObj[13].transform.parent = gameObjBaricentro[13].transform;

        vetGameObj[14].transform.position = new Vector3(2.5f, 0, Mathf.Sqrt(3) / 2);
        vetGameObj[14].transform.Rotate(Vector3.up, 180f);
        gameObjBaricentro[14].transform.position = baricentro(vetGameObj[14]);
        vetGameObj[14].transform.parent = gameObjBaricentro[14].transform;

        vetGameObj[15].transform.position = new Vector3(2f, 0, Mathf.Sqrt(3));
        vetGameObj[15].transform.Rotate(Vector3.up, 180f);
        gameObjBaricentro[15].transform.position = baricentro(vetGameObj[15]);
        vetGameObj[15].transform.parent = gameObjBaricentro[15].transform;

        vetGameObj[16].transform.position = new Vector3(0.5f, 0.86603f, 0.28868f);
        pai.transform.position = new Vector3(1f, 0.86603f, 0.28868f + Mathf.Sqrt(3) / 2);
        pai.transform.Rotate(Vector3.down, 60f);
        vetGameObj[16].transform.parent = pai.transform;
        pai.transform.Rotate(Vector3.forward, 180f);
        pai.transform.Rotate(Vector3.right, 36.87f);
        vetGameObj[16].transform.parent = null;
        gameObjBaricentro[16].transform.position = baricentro(vetGameObj[16]);
        vetGameObj[16].transform.parent = gameObjBaricentro[16].transform;

        pai.transform.rotation = Quaternion.identity;
        vetGameObj[17].transform.position = new Vector3(0f, 0.86603f, -0.28868f * 2);
        pai.transform.position = new Vector3(0.5f, 0.86603f, 0.28868f);
        pai.transform.Rotate(Vector3.down, 60f);
        vetGameObj[17].transform.parent = pai.transform;
        pai.transform.Rotate(Vector3.forward, 180f);
        pai.transform.Rotate(Vector3.right, 36.87f);
        vetGameObj[17].transform.parent = null;
        gameObjBaricentro[17].transform.position = baricentro(vetGameObj[17]);
        vetGameObj[17].transform.parent = gameObjBaricentro[17].transform;

        pai.transform.rotation = Quaternion.identity;
        vetGameObj[18].transform.position = new Vector3(0.5f, 0.86603f * 2, -0.28868f);
        pai.transform.position = new Vector3(1f, 0.86603f * 2, 0.28868f * 2);
        pai.transform.Rotate(Vector3.down, 60f);
        vetGameObj[18].transform.parent = pai.transform;
        pai.transform.Rotate(Vector3.forward, 180f);
        pai.transform.Rotate(Vector3.right, 36.87f);
        vetGameObj[18].transform.parent = null;
        gameObjBaricentro[18].transform.position = baricentro(vetGameObj[18]);
        vetGameObj[18].transform.parent = gameObjBaricentro[18].transform;

        // OUTRO LADO!!!!!

        pai.transform.rotation = Quaternion.identity;
        vetGameObj[19].transform.position = new Vector3(0.5f * 4, 0.86603f, -0.28868f * 2);
        pai.transform.position = new Vector3(0.5f * 5, 0.86603f, 0.28868f);
        pai.transform.Rotate(Vector3.up, 60f);
        vetGameObj[19].transform.parent = pai.transform;
        pai.transform.Rotate(Vector3.forward, 180f);
        pai.transform.Rotate(Vector3.right, 36.87f);
        vetGameObj[19].transform.parent = null;
        gameObjBaricentro[19].transform.position = baricentro(vetGameObj[19]);
        vetGameObj[19].transform.parent = gameObjBaricentro[19].transform;

        pai.transform.rotation = Quaternion.identity;
        vetGameObj[20].transform.position = new Vector3(0.5f * 3, 0.86603f, 0.28868f);
        pai.transform.position = new Vector3(0.5f * 4, 0.86603f, 0.28868f + Mathf.Sqrt(3) / 2);
        pai.transform.Rotate(Vector3.up, 60f);
        vetGameObj[20].transform.parent = pai.transform;
        pai.transform.Rotate(Vector3.forward, 180f);
        pai.transform.Rotate(Vector3.right, 36.87f);
        vetGameObj[20].transform.parent = null;
        gameObjBaricentro[20].transform.position = baricentro(vetGameObj[20]);
        vetGameObj[20].transform.parent = gameObjBaricentro[20].transform;

        pai.transform.rotation = Quaternion.identity;
        vetGameObj[21].transform.position = new Vector3(0.5f * 3, 0.86603f * 2, -0.28868f);
        pai.transform.position = new Vector3(2f, 0.86603f * 2, 0.28868f * 2);
        pai.transform.Rotate(Vector3.up, 60f);
        vetGameObj[21].transform.parent = pai.transform;
        pai.transform.Rotate(Vector3.forward, 180f);
        pai.transform.Rotate(Vector3.right, 36.87f);
        vetGameObj[21].transform.parent = null;
        gameObjBaricentro[21].transform.position = baricentro(vetGameObj[21]);
        vetGameObj[21].transform.parent = gameObjBaricentro[21].transform;

        pai.transform.rotation = Quaternion.identity;




        Vector3 centro = ((p0 + p1 + p2 + p3) / 4) * 3;

        pai.transform.position = centro;

        v0 = new GameObject();
        v0.transform.position = new Vector3(0, 0, 0);

        v1 = new GameObject();
        v1.transform.position = new Vector3(3, 0, 0);

        v2 = new GameObject();
        v2.transform.position = new Vector3(1.5f, 0, Mathf.Sqrt(0.75f) * 3);


        //vetGameObj[3].transform.Rotate(110f,0f,0); // 90f
        // vetGameObj[3].transform.RotateAround(transform.position, Vector3.forward, 5f);

        //pai.transform.position = new Vector3(0,1,0); //pivo
        //pai.transform.position = new Vector3(0, 1, 0); //pivo
        //vetGameObj[3].transform.parent = pai.transform;
        //vetGameObj[3].transform.bounds

        tetraNoBaricentro = new int[gameObjBaricentro.Length];

        for (int i = 0; i < gameObjBaricentro.Length; i++)
        {
            tetraNoBaricentro[i] = i;
        }

    }

    Vector3 baricentro(GameObject tetraedro)
    {
        Vector3 centroLocal = (p0 + p1 + p2 + p3) / 4;
        return tetraedro.transform.TransformPoint(centroLocal);
    }

    void ReatribuirBaricentros(int[] origem, int[] destino)
    {
        int[] temp = new int[origem.Length];

        // guarda quais tetraedros estavam nas posições de origem
        for (int i = 0; i < origem.Length; i++)
        {
            temp[i] = tetraNoBaricentro[origem[i]];
        }

        // move logicamente os tetraedros para os novos baricentros
        for (int i = 0; i < destino.Length; i++)
        {
            tetraNoBaricentro[destino[i]] = temp[i];
        }

        // atualiza a hierarquia real no Unity
        for (int i = 0; i < destino.Length; i++)
        {
            int tetra = temp[i];
            int baricentroDestino = destino[i];

            vetGameObj[tetra].transform.SetParent(gameObjBaricentro[baricentroDestino].transform, true);
        }
    }


    void RotacaoLogica(int[] origem, int[] destino)
    {
        if (origem.Length != destino.Length)
        {
            Debug.LogError("origem e destino precisam ter o mesmo tamanho.");
            return;
        }

        int[] ocupantesAntigos = new int[destino.Length];

        // agora lê quem está no destino
        for (int i = 0; i < destino.Length; i++)
        {
            ocupantesAntigos[i] = tetraNoBaricentro[destino[i]];
        }

        // e coloca na origem
        for (int i = 0; i < origem.Length; i++)
        {
            tetraNoBaricentro[origem[i]] = ocupantesAntigos[i];
        }

        // atualiza a hierarquia
        for (int i = 0; i < origem.Length; i++)
        {
            int tetra = ocupantesAntigos[i];
            int novoBaricentro = origem[i];

            vetGameObj[tetra].transform.SetParent(gameObjBaricentro[novoBaricentro].transform, true);
        }
    }
    // Update is called once per frame
    void Update()
    {

        // GIRAR AS PONTAS

        if (Input.GetKeyDown(KeyCode.F1))
        {
            int indiceBaricentro = 0;
            int tetra = tetraNoBaricentro[indiceBaricentro];

            Vector3 direcao = baricentro(vetGameObj[tetra]) - pai.transform.position;
            direcao = direcao.normalized;

            Debug.Log(direcao);
            Debug.DrawRay(pai.transform.position, direcao * 5f, Color.red, 5f);

            pai.transform.rotation = Quaternion.LookRotation(direcao);
            vetGameObj[tetra].transform.SetParent(pai.transform, true);

            pai.transform.Rotate(Vector3.forward, 120f, Space.Self);
            vetGameObj[tetra].transform.SetParent(gameObjBaricentro[indiceBaricentro].transform, true);

            Debug.Log("f1.");
        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            int indiceBaricentro = 2;
            int tetra = tetraNoBaricentro[indiceBaricentro];

            Vector3 direcao = baricentro(vetGameObj[tetra]) - pai.transform.position;
            direcao = direcao.normalized;

            Debug.DrawRay(pai.transform.position, direcao * 5f, Color.red, 5f);

            pai.transform.rotation = Quaternion.LookRotation(direcao);
            vetGameObj[tetra].transform.SetParent(pai.transform, true);

            pai.transform.Rotate(Vector3.forward, 120f, Space.Self);
            vetGameObj[tetra].transform.SetParent(gameObjBaricentro[indiceBaricentro].transform, true);

            Debug.Log("f2.");
        }

        if (Input.GetKeyDown(KeyCode.F3))
        {
            int indiceBaricentro = 9;
            int tetra = tetraNoBaricentro[indiceBaricentro];

            pai.transform.rotation = Quaternion.identity;
            vetGameObj[tetra].transform.SetParent(pai.transform, true);

            pai.transform.Rotate(Vector3.up, 120f, Space.Self);
            vetGameObj[tetra].transform.SetParent(gameObjBaricentro[indiceBaricentro].transform, true);

            Debug.Log("f3.");
        }

        if (Input.GetKeyDown(KeyCode.F4))
        {
            int indiceBaricentro = 7;
            int tetra = tetraNoBaricentro[indiceBaricentro];

            Vector3 direcao = baricentro(vetGameObj[tetra]) - pai.transform.position;
            direcao = direcao.normalized;

            Debug.DrawRay(pai.transform.position, direcao * 5f, Color.red, 5f);

            pai.transform.rotation = Quaternion.LookRotation(direcao);
            vetGameObj[tetra].transform.SetParent(pai.transform, true);

            pai.transform.Rotate(Vector3.forward, 120f, Space.Self);
            vetGameObj[tetra].transform.SetParent(gameObjBaricentro[indiceBaricentro].transform, true);

            Debug.Log("f4.");
        }
        // ROTACIONAR BASE

        if (Input.GetKeyDown(KeyCode.F5))
        {
            int[] tetraedros_base = { 0, 1, 2, 5, 6, 7, 10, 11, 13, 14, 15, 16, 17, 19, 20 };

            pai.transform.rotation = Quaternion.identity;

            for (int i = 0; i < tetraedros_base.Length; i++)
            {
                int tetra = tetraNoBaricentro[tetraedros_base[i]];
                vetGameObj[tetra].transform.SetParent(pai.transform, true);
            }

            pai.transform.Rotate(Vector3.up, 120f, Space.Self);

            // exemplo de mapeamento entre baricentros
            int[] origem = { 0, 1, 2, 5, 6, 7, 10, 11, 13, 14, 15, 16, 17, 19, 20 };
            int[] destino = { 2, 6, 7, 1, 5, 0, 19, 20, 14, 15, 13, 10, 11, 16, 17};

            RotacaoLogica(origem, destino);
        }

        // ROTACIONAR 7 TETRAEDRINHOS

        if (Input.GetKeyDown(KeyCode.F6))
        {
            int[] origem = { 1, 2, 4, 6, 11, 14, 19 };
            int[] destino = { 6, 2, 1, 4, 14, 19, 11 }; // ajuste manualmente como quiser

            Vector3 direcao = baricentro(vetGameObj[tetraNoBaricentro[2]]) - pai.transform.position;
            direcao = direcao.normalized;

            Debug.DrawRay(pai.transform.position, direcao * 5f, Color.red, 5f);

            pai.transform.rotation = Quaternion.LookRotation(direcao);

            // parentear no objeto "pai" os tetraedros que atualmente ocupam esses baricentros
            for (int i = 0; i < origem.Length; i++)
            {
                int tetra = tetraNoBaricentro[origem[i]];
                vetGameObj[tetra].transform.SetParent(pai.transform, true);
            }

            pai.transform.Rotate(Vector3.forward, 120f, Space.Self);

            // lógica invertida: conteúdo de destino vai para origem
            int[] ocupantesAntigos = new int[destino.Length];

            for (int i = 0; i < destino.Length; i++)
            {
                ocupantesAntigos[i] = tetraNoBaricentro[destino[i]];
            }

            for (int i = 0; i < origem.Length; i++)
            {
                tetraNoBaricentro[origem[i]] = ocupantesAntigos[i];
            }

            for (int i = 0; i < origem.Length; i++)
            {
                int tetra = ocupantesAntigos[i];
                int novoBaricentro = origem[i];

                vetGameObj[tetra].transform.SetParent(gameObjBaricentro[novoBaricentro].transform, true);
            }
        }
        if (Input.GetKeyDown(KeyCode.F7))
        {
            int[] origem = { 0, 1, 3, 5, 10, 13, 17 };
            int[] destino = { 0, 3, 5, 1, 17, 10, 13 }; // ajuste manualmente como desejar

            Vector3 direcao = baricentro(vetGameObj[tetraNoBaricentro[0]]) - pai.transform.position;
            direcao = direcao.normalized;

            Debug.DrawRay(pai.transform.position, direcao * 5f, Color.red, 5f);

            pai.transform.rotation = Quaternion.LookRotation(direcao);

            // coloca no pai os tetraedros que atualmente ocupam esses baricentros
            for (int i = 0; i < origem.Length; i++)
            {
                int tetra = tetraNoBaricentro[origem[i]];
                vetGameObj[tetra].transform.SetParent(pai.transform, true);
            }

            pai.transform.Rotate(Vector3.forward, 120f, Space.Self);

            // lógica invertida: conteúdo de destino vai para origem
            int[] ocupantesAntigos = new int[destino.Length];

            for (int i = 0; i < destino.Length; i++)
            {
                ocupantesAntigos[i] = tetraNoBaricentro[destino[i]];
            }

            for (int i = 0; i < origem.Length; i++)
            {
                tetraNoBaricentro[origem[i]] = ocupantesAntigos[i];
            }

            for (int i = 0; i < origem.Length; i++)
            {
                int tetra = ocupantesAntigos[i];
                int novoBaricentro = origem[i];

                vetGameObj[tetra].transform.SetParent(gameObjBaricentro[novoBaricentro].transform, true);
            }
        }

        if (Input.GetKeyDown(KeyCode.F8))
        {
            int[] origem = { 5, 6, 7, 8, 15, 16, 20 };
            int[] destino = { 8, 5, 7, 6, 16, 20, 15 }; // ajuste manualmente como desejar

            Vector3 direcao = baricentro(vetGameObj[tetraNoBaricentro[7]]) - pai.transform.position;
            direcao = direcao.normalized;

            Debug.DrawRay(pai.transform.position, direcao * 5f, Color.red, 5f);

            pai.transform.rotation = Quaternion.LookRotation(direcao);

            // coloca no pai os tetraedros que atualmente ocupam esses baricentros
            for (int i = 0; i < origem.Length; i++)
            {
                int tetra = tetraNoBaricentro[origem[i]];
                vetGameObj[tetra].transform.SetParent(pai.transform, true);
            }

            pai.transform.Rotate(Vector3.forward, 120f, Space.Self);

            // lógica invertida: conteúdo de destino vai para origem
            int[] ocupantesAntigos = new int[destino.Length];

            for (int i = 0; i < destino.Length; i++)
            {
                ocupantesAntigos[i] = tetraNoBaricentro[destino[i]];
            }

            for (int i = 0; i < origem.Length; i++)
            {
                tetraNoBaricentro[origem[i]] = ocupantesAntigos[i];
            }

            for (int i = 0; i < origem.Length; i++)
            {
                int tetra = ocupantesAntigos[i];
                int novoBaricentro = origem[i];

                vetGameObj[tetra].transform.SetParent(gameObjBaricentro[novoBaricentro].transform, true);
            }
        }

        // GAME OBJECT NO BARICENTRO DE CADA TETRAEDRO PARA DEFINIR QUAL ESTÁ EM QUAL POSIÇÃO

        //vetGameObj[3].transform.RotateAround(transform.position, Vector3.forward, 5f);
        //cria um gameobject: Pai. Tem eixo de rotacao
        //por o objeto como filho deste gameobject
        //rotaciona o gameObjet(pai): consequencia o filho rotaciona
        //Instantiate(Object original, Vector3 position, Quaternion rotation, Transform parent);
        //pai.transform.Rotate(Vector3.right * 5);




        //vetGameObj[4].transform.Rotate((Vector3.right + Vector3.up) * 5);
    }
}