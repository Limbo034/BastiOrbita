using System.Collections;
using UnityEngine;

public class ColorTowerLogic : MonoBehaviour
{
    [SerializeField] private Color[] playerColors;
    [SerializeField] private new Renderer renderer;

    IEnumerator ColorRandom()
    {
        renderer = GetComponent<Renderer>();

        while (true)
        {
            Color randomColor = playerColors[Random.Range(0, playerColors.Length)];

            // Конвертируем в HSV
            Color.RGBToHSV(randomColor, out float h, out float s, out float v);

            Color modifiedColor = Color.HSVToRGB(h, s, v);

            renderer.material.color = modifiedColor;

            yield return new WaitForSeconds(8f);
        }
    }

    private void Start()
    {
        StartCoroutine(ColorRandom());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
}
