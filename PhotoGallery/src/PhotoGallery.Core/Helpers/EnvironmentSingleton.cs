using System;

namespace PhotoGallery.Core.Helpers
{
    public class EnvironmentSingleton
    {
        private static Models.Environment Instance { get; set; }

        public static void SetEnvironment(Func<Models.Environment> action)
        {
            Instance = action();
        }

        public static Models.Environment GetEnvironment()
        {
            return Instance;
        }
    }
}