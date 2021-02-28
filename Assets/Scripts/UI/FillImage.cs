using UnityEngine;
using UnityEngine.UI;

public class FillImage : MonoBehaviour
{
    public float timer;
    public float maxTimer;
    bool empty = false;
    public Image image;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (empty)
        {
            timer += 1 * Time.deltaTime;
            var ratio = timer / maxTimer;
            image.fillAmount = ratio;

            if (timer >= maxTimer)
            {
                empty = !empty;
                timer = 0;
            }
        }
    }

    public void Activate()
    {
        empty = true;
        image.fillAmount = 0;
    }
}
