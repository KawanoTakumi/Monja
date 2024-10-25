using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class num_cnt : MonoBehaviour
{
    public PlayerController player;
    public Text attack_Text;
    public Text diffence_Text;
    public Text magic_Text;
    public Text magic_diffence_Text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        attack_Text.text = string.Format("{0}",player.Attack);
        diffence_Text.text = string.Format("{0}",player.Diffence);
        magic_Text.text = string.Format("{0}",player.Magic);
        magic_diffence_Text.text = string.Format("{0}",player.Magic_Diffence);
    }
}
