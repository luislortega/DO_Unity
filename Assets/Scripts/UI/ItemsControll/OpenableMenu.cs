using UnityEngine;
using UnityEngine.UI;

//Clasa care permite deschiderea celor 10 meniuri cu Iteme\\
public class OpenableMenu : MonoBehaviour {

    public Sprite normalButton;
    public Sprite highlightedButton;

    //Deschide un meniu cu iteme din cele 10 disponibile\\
    RectTransform _previosMenu;
    public void OpenMenu(RectTransform menu)
    {
        if (menu == _previosMenu) _previosMenu = null;
        menu.gameObject.SetActive(true);
        if (_previosMenu != null) _previosMenu.gameObject.SetActive(false);
        _previosMenu = menu;
    }

    //Schimba aspectul butonului atunci cand este selectat\\
    RectTransform _previosButton;
    public void HighlightButton(RectTransform button)
    {
        if (button == _previosButton) _previosButton = null;
        button.GetComponent<Image>().sprite = highlightedButton;
        if (_previosButton != null) _previosButton.GetComponent<Image>().sprite = normalButton;
        _previosButton = button;
    }
}
