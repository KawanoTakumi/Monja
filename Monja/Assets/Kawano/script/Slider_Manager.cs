using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Slider_Manager : MonoBehaviour
{
    public Slider obj;
    public Text Value_Text;
    public static float Music_Volume = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        //ï€éùÇµÇΩêîílÇì«Ç›çûÇﬁ
        obj.value = Music_Volume * 100;
    }

    // Update is called once per frame
    void Update()
    {
        Music_Volume = obj.value / 100;

        if(obj.value == 0)
        {
            Value_Text.text = "(no BGM)";
        }
        else if(obj.value == 50)
        {
            Value_Text.text = "(default)  50";
        }
        else if(obj.value == 100)
        {
            Value_Text.text = "(max)  100";
        }
        else
        {
            Value_Text.text = string.Format("{0}", obj.value);
        }
    }
}
