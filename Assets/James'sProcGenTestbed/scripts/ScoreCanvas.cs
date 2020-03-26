using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCanvas : MonoBehaviour
{
    public float moveSpeed;
    public float imageAlphaReductionSpeed;
    public float imageFillSpeed;
    public Image scoreTextImage;
    // Start is called before the first frame update
    void Start()
    {
        scoreTextImage.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(scoreTextImage.color.a <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            if (scoreTextImage.fillAmount < 1)
            {
                scoreTextImage.fillAmount += imageFillSpeed;
                transform.position += new Vector3(0, moveSpeed, 0);
            }
            else
            {
                var colour = scoreTextImage.color;
                colour.a -= imageAlphaReductionSpeed;
                scoreTextImage.color = colour;
                transform.position += new Vector3(0, moveSpeed, 0);
            }
        }
    }
}
