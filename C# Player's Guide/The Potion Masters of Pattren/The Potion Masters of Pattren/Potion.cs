namespace The_Potion_Masters_of_Pattren {
    internal enum Ingridient { Stardust, SnakeVenom, DragonBreath, ShadowGlass, EyeshineGem }
    internal enum PotionType { Water, Elixir, Poison, Flying, Invisibility, NightSight, CloudyBrew, Wraith, Ruined }

    internal class Potion {
        public PotionType Type { get; private set; } = PotionType.Water;

        internal void AddIngridient(Ingridient ingridient) {
            Type = (Type, ingridient) switch {
                (PotionType.Water, Ingridient.Stardust) => PotionType.Elixir,
                (PotionType.Elixir, Ingridient.SnakeVenom) => PotionType.Poison,
                (PotionType.Elixir, Ingridient.DragonBreath) => PotionType.Flying,
                (PotionType.Elixir, Ingridient.ShadowGlass) => PotionType.Invisibility,
                (PotionType.Elixir, Ingridient.EyeshineGem) => PotionType.NightSight,
                (PotionType.NightSight, Ingridient.ShadowGlass) => PotionType.CloudyBrew,
                (PotionType.Invisibility, Ingridient.EyeshineGem) => PotionType.CloudyBrew,
                (PotionType.CloudyBrew, Ingridient.Stardust) => PotionType.Wraith,
                _ => PotionType.Ruined
            };
        }

    }
}
