using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change : MonoBehaviour
{
    Color a, b;

    public Vector3 start, end;

    public Vector2 size1, size2;
    // Start is called before the first frame update
    void Start()
    {
        a = Color.red;
        b = Color.black;
        GetComponent<SpriteRenderer>().color = Color.red;
        StartCoroutine(ColorChange(a, b, start, end, size1, size2));
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    IEnumerator ColorChange(Color c1, Color c2, Vector3 s, Vector3 e, Vector2 s1, Vector2 s2)
    {
        bool b = false;
        while (!b)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                b = true;
            }
            yield return null;
        }

        float t = 0.0f;
        while (true)
        {
            t = 0.0f;
            while (t < 1.0f)
            {
                Debug.Log("Go");
                gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(c1, c2, t);
                transform.position = Vector3.Lerp(s, e, t);
                transform.localScale = Vector2.Lerp(s1, s2, t);
                t += Time.deltaTime;
                yield return null;
            }

            transform.position = e;
            transform.localScale = s2;
            gameObject.GetComponent<SpriteRenderer>().color = c2;

            t = 0.0f;

            while (t < 1.0f)
            {
                Debug.Log("Back");
                gameObject.GetComponent<SpriteRenderer>().color = Color.Lerp(c2, c1, t);
                transform.position = Vector3.Lerp(e, s, t);
                transform.localScale = Vector2.Lerp(s2, s1, t);
                t += Time.deltaTime;
                yield return null;
            }

            transform.position = s;
            transform.localScale = s1;
            gameObject.GetComponent<SpriteRenderer>().color = c1;
        }
    }
}
