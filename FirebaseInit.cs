using Firebase;
using Firebase.Analytics;
using UnityEngine;


public class FirebaseInit : MonoBehaviour
{
    private FirebaseApp app;
    

    // Start is called before the first frame update
    void Start()
    {
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                //create and hold a reference to your Firebase App,
                //where app is a Firebase.FirebaseApp property of your application class.
                app = Firebase.FirebaseApp.DefaultInstance;

                //Set a flag here to introduce wheather Firebase is ready to use by your app.
            }
            else 
            {
                UnityEngine.Debug.LogError(System.String.Format(
                    "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
            }
            //FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
        });
    }

    
}
