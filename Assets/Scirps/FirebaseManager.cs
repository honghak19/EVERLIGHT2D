using UnityEngine;
using Firebase.Extensions;
using Firebase;
using Firebase.Auth;
using Firebase.Database;

public class FirebaseManager : MonoBehaviour
{ 
    public static FirebaseManager fb;
    
    FirebaseApp app;
    FirebaseAuth auth;
    DatabaseReference db;

    public FirebaseUser user;

    private void Awake()
    {
      fb = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task => {
          var dependencyStatus = task.Result;
          if (dependencyStatus == Firebase.DependencyStatus.Available) {
            // Create and hold a reference to your FirebaseApp,
            // where app is a Firebase.FirebaseApp property of your application class.
               app = Firebase.FirebaseApp.DefaultInstance;
               auth = FirebaseAuth.DefaultInstance;
               db = FirebaseDatabase.DefaultInstance.RootReference;
            // Set a flag here to indicate whether Firebase is ready to use by your app.
          } else {
            UnityEngine.Debug.LogError(System.String.Format(
              "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
            // Firebase Unity SDK is not safe to use here.
          }
        });
    }

    public void DangKi(string email, string password)
    {
      auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
        if (task.IsCanceled) {
          Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
          return;
        }
        if (task.IsFaulted) {
          Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
          return;
        }

        // Firebase user has been created.
        Firebase.Auth.AuthResult result = task.Result;
        Debug.LogFormat("Firebase user created successfully: {0} ({1})",
          result.User.DisplayName, result.User.UserId);
      });
    }

    public void DangNhap(string email, string password)
    {
      auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
        if (task.IsCanceled) {
          Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
          return;
        }
        if (task.IsFaulted) {
          Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
          return;
        }

        user = auth.CurrentUser;
        Firebase.Auth.AuthResult result = task.Result;
        Debug.LogFormat("User signed in successfully: {0} ({1})",
          result.User.DisplayName, result.User.UserId);
      });
    }

    public void DangXuat()
    {
      FirebaseAuth.DefaultInstance.SignOut();
      user = auth.CurrentUser;
      Debug.Log("Dang Xuat Thanh Cong");
    }

    public void KiemTra()
    {
      if (user == null)
      {
        Debug.Log("khong co tai khoan nao dang nhap");
      }
      else
      {
        Debug.Log($"Ban dang dang nhap : {user.Email}");
      }
    }
}
