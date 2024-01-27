using System.IO;
using UnityEngine;
using UnityEngine.Rendering;

public class Paintable : MonoBehaviour
{
    public GameObject brush;
    [SerializeField]
    private float brushSize;
    [SerializeField]
    RenderTexture RTexture;
    private Texture2D savedTexture;
    private float percentage;
    private float totalPixels;

    void Start()
    {
        // Initialize the saved texture
        savedTexture = new Texture2D(RTexture.width, RTexture.height);
        totalPixels = savedTexture.width * savedTexture.height;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            var Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(Ray, out hit))
            {
                var go = Instantiate(brush, hit.point + Vector3.up * 0.1f, Quaternion.identity, transform);
                go.transform.localScale = Vector3.one * brushSize;

                // Update the texture with current brush stroke
                UpdateTexture();
                Debug.Log(percentage);
            }
        }
    }

    private void UpdateTexture()
    {
        float coloredPixels = 0;
        RenderTexture.active = RTexture;
        savedTexture.ReadPixels(new Rect(0, 0, RTexture.width, RTexture.height), 0, 0);
        savedTexture.Apply();

        for (int y = 0; y < savedTexture.height; y++)
        {
            for (int x = 0; x < savedTexture.width; x++)
            {
                Color pixelColor = savedTexture.GetPixel(x, y);
                if (pixelColor != Color.white)
                {
                    coloredPixels++;
                }
            }
        }
        percentage = coloredPixels / totalPixels * 100;
    }

    public void Save()
    {
        var data = savedTexture.EncodeToPNG();
        File.WriteAllBytes(Application.dataPath + "/savedImage.png", data);
        Debug.Log("Saved Image to: " + Application.dataPath + "/savedImage.png");
    }
}
