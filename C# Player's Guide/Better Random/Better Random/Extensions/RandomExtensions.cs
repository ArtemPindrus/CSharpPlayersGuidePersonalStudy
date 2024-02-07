namespace Better_Random.Extensions {
    internal static class RandomExtensions {
        /// <summary>
        /// gives doubles between 0 and maxValue
        /// </summary>
        /// <param name="random"></param>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        public static double NextDouble(this Random random, int maxValue) => random.NextDouble()*maxValue;
        public static string NextString(this Random random, params string[] strings) { 
            int number = random.Next(strings.Length);

            return strings[number];
        }

        /// <summary>
        /// Retuns whether heads up.
        /// </summary>
        /// <param name="random"></param>
        /// <param name="headsUpChance">[0,1]</param>
        /// <returns></returns>
        public static bool CoinFlip(this Random random, float headsUpChance = 0.5f) {
            headsUpChance = Math.Clamp(headsUpChance, 0f, 1f);

            double number = random.NextDouble();
            return number <= headsUpChance;
        }
    }
}
