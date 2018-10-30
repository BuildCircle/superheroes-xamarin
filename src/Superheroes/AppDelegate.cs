using Foundation;
using UIKit;

namespace Superheroes
{
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        public override UIWindow Window { get; set; }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
#if ENABLE_TEST_CLOUD
            Xamarin.Calabash.Start();
#endif

            DependenciesRegister.Initialise();

            return true;
        }
    }
}