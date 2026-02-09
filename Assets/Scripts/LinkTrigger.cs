using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkTrigger : MonoBehaviour
{
    public void LinkK()
    {
        Application.OpenURL("https://www.linkedin.com/in/kaanerayakay/");
    }

    public void LinkN()
    {
        Application.OpenURL("https://www.linkedin.com/in/nilüfer-yýlmaz-8805691b9/");
    }

    public void LinkB()
    {
        Application.OpenURL("https://www.linkedin.com/in/berkan-cenan-demirer-37637923b/");
    }

    public void LinkV()
    {
        Application.OpenURL("https://www.linkedin.com/in/volkan-güneþ-93bab81b1/");
    }

    public void Quit()
    {
        Application.Quit();
    }

}
