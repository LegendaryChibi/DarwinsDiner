using System.IO;
using UnityEngine;
using UnityEngine.Rendering;
/*public enum Spread
{
    Peanutbutter,
    Jelly
}*/
public class Paintable : MonoBehaviour
{
    public string spread;
    public GameObject brush;
    [SerializeField]
    private float brushSize;
    [SerializeField]
    RenderTexture RTexture;
    private Texture2D savedTexture;
    [SerializeField]
    private int percentage;
    private int totalPixels;
    private LayerMask mask;

    void Start()
    {
        // Initialize the saved texture
        savedTexture = new Texture2D(RTexture.width, RTexture.height);
        totalPixels = savedTexture.width * savedTexture.height;
        mask = LayerMask.GetMask("Terrain", "IngredientPlane");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && MultiMouse.DogPawFollow.LeftPaw.JamPercent == 100 && spread == "Jelly")
        {

            var Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(Ray, out hit, 10000f, mask) && hit.collider.gameObject == this.gameObject)
            {
                var go = Instantiate(brush, hit.point + Vector3.up * 0.1f, Quaternion.identity, this.transform);
                go.transform.localScale = Vector3.one * brushSize;
                UpdateTexture();
                // Update the texture with current brush stroke
                MultiMouse.instance.JellyPercent(percentage);
            }
        }

        if (Input.GetMouseButton(1) && MultiMouse.DogPawFollow.RightPaw.PeanutPercent == 100 && spread == "Peanutbutter")
        {

            var Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(Ray, out hit, 10000f, mask) && hit.collider.gameObject == this.gameObject)
            {
                var go = Instantiate(brush, hit.point + Vector3.up * 0.1f, Quaternion.identity, this.transform);
                go.transform.localScale = Vector3.one * brushSize;
                UpdateTexture();
                // Update the texture with current brush stroke
                MultiMouse.instance.PeanutButterPercent(percentage);
            }
        }
    }

    private void UpdateTexture()
    {
        float coloredPixels = 0;
        RenderTexture.active = RTexture;
        savedTexture.ReadPixels(new Rect(0, 0, RTexture.width, RTexture.height), 0, 0);
        //savedTexture.Apply(); We don't need to send data back to the GPU

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
        percentage = Mathf.RoundToInt(coloredPixels / totalPixels * 100);
    }

    public void Save()
    {
        var data = savedTexture.EncodeToPNG();
        File.WriteAllBytes(Application.dataPath + "/savedImage.png", data);
        Debug.Log("Saved Image to: " + Application.dataPath + "/savedImage.png");
    }


    public void DestroyChildObjectsWithName(string name)
    {
        // Loop through all child objects
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            Transform child = transform.GetChild(i);
            if (child.name == name)
            {
                // Destroy the child game object
                Destroy(child.gameObject);
            }
        }
        percentage = 0;
    }
}
