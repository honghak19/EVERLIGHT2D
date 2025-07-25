using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public TMP_InputField dk_gmail;
    public TMP_InputField dk_password;
    public TMP_InputField dn_gmail;
    public TMP_InputField dn_password;

    public void Button_DangKy()
    {
        FirebaseManager.fb.DangKi(dk_gmail.text, dk_password.text);
    }

    public void Button_DangNhap()
    {
        FirebaseManager.fb.DangNhap(dn_gmail.text, dn_password.text);
    }

    public void Button_DangXuat()
    {
        FirebaseManager.fb.DangXuat();
    }

    public void Button_Email()
    {
        
    }

    public void Button_Read()
    {
        FirebaseManager.fb.KiemTra();
    }

    public void Button_Update()
    {
        
    }
}
