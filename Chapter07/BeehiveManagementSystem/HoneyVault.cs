namespace BeehiveManagementSystem
{
    static class HoneyVault
    {

        private static float honey = 25f;
        private static float nectar = 100f;

        private const float NECTAR_CONVERSION_RATIO = .19f;
        private const float LOW_LEVEL_WARNING = 10f;

        public static string StatusReport =>
            $"{honey:0.0} units of honey" +
            $"\n{nectar:0.0} units of nectar" +
            $"{(honey < LOW_LEVEL_WARNING ? "\nLOW HONEY - ADD A HONEY MANUFACTURER" : string.Empty)}" +
            $"{(nectar < LOW_LEVEL_WARNING ? "\nLOW NECTAR - ADD A NECTAR COLLECTOR" : string.Empty)}";

        public static void CollectNectar(float amount)
        {
            if (amount > 0f)
            {
                nectar += amount;
            }
        }

        public static void ConvertNectarToHoney(float amount)
        {
            float nectarToConvert = amount;

            if (amount > nectar)
            {
                nectarToConvert = nectar;
                nectar = 0;
            }
            else
            {
                nectar -= amount;
            }

            honey += NECTAR_CONVERSION_RATIO * nectarToConvert;
        }

        public static bool ConsumeHoney(float amount)
        {
            if (amount > honey)
            {
                return false;
            }

            honey -= amount;
            return true;
        }
    }
}
