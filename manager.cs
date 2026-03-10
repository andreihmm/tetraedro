using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager : MonoBehaviour {

    public GameObject tetrahedron; // prefab da camrera
    public GameObject[] vetGameObj = new GameObject[24];
    GameObject pai;
     Vector3 m_Center;
	// Use this for initialization
	void Start () {
		for(int i=0; i < 24; i++)
        {
            if(i == 0)
            {
                vetGameObj[i] = Instantiate(tetrahedron, new Vector3(0, 0, 0), Quaternion.identity); // tetraedro base
            }
            else
                vetGameObj[i]= Instantiate(tetrahedron, new Vector3(vetGameObj[i-1].transform.position.x + 1, 0, 0), vetGameObj[i - 1].transform.rotation);
            //i-1 posicao anterior
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

        vetGameObj[13].transform.position = new Vector3(0.5f * 4, 0.86603f * 2, 0.28868f * 2);
        vetGameObj[13].transform.Rotate(Vector3.right, 36.87f);
        vetGameObj[13].transform.Rotate(Vector3.forward, 180f);


        vetGameObj[14].transform.position = new Vector3(1.5f, 0, Mathf.Sqrt(3) / 2);
        vetGameObj[14].transform.Rotate(Vector3.up, 180f);

        vetGameObj[15].transform.position = new Vector3(2.5f, 0, Mathf.Sqrt(3) / 2);
        vetGameObj[15].transform.Rotate(Vector3.up, 180f);

        vetGameObj[16].transform.position = new Vector3(2f, 0, Mathf.Sqrt(3));
        vetGameObj[16].transform.Rotate(Vector3.up, 180f);


        pai = new GameObject();
        pai.transform.position = new Vector3(0,0,0); //pivo


        pai.transform.position = new Vector3(0.5f, 0.86603f, 0.28868f);
        pai.transform.Rotate(Vector3.forward, 180f);
        pai.transform.Rotate(Vector3.up, 120f);
        pai.transform.Rotate(Vector3.right, 36.87f);
        //vetGameObj[17].transform.Rotate(-162.6f, -305.3f, 33.3f);





        //vetGameObj[3].transform.Rotate(110f,0f,0); // 90f
        // vetGameObj[3].transform.RotateAround(transform.position, Vector3.forward, 5f);

        //pai.transform.position = new Vector3(0,1,0); //pivo
        //pai.transform.position = new Vector3(0, 1, 0); //pivo
        //vetGameObj[3].transform.parent = pai.transform;
        //vetGameObj[3].transform.bounds
    }

	
	// Update is called once per frame
	void Update () {
		//vetGameObj[3].transform.RotateAround(transform.position, Vector3.forward, 5f);
        //cria um gameobject: Pai. Tem eixo de rotacao
        //por o objeto como filho deste gameobject
        //rotaciona o gameObjet(pai): consequencia o filho rotaciona
        //Instantiate(Object original, Vector3 position, Quaternion rotation, Transform parent);
        //pai.transform.Rotate(Vector3.right * 5);




        //vetGameObj[4].transform.Rotate((Vector3.right + Vector3.up) * 5);
	}
}
