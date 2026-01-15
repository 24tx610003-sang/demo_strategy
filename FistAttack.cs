using System;

namespace StrategyPatternDemo
{
    /// <summary>
    /// Concrete Strategy - Tấn công Tay Không
    /// Đặc điểm: Không vũ khí, võ thuật
    /// Phù hợp: Khi không có vũ khí, sát thương thấp
    /// </summary>
    public class FistAttack : IAttackStrategy
    {
        private static readonly Random random = new Random();
        private readonly string[] effects = { "👊 Đấm!", "🦶 Đá xoay!", "🥊 Combo!" };

        public int Attack()
        {
            // Sát thương ngẫu nhiên từ 30-45 (thấp nhất)
            int damage = random.Next(30, 46);

            // Hiển thị hiệu ứng tấn công
            string effect = effects[random.Next(effects.Length)];
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"    {effect}");
            Console.WriteLine($"    👊 Gây {damage} sát thương tay không!");
            Console.ResetColor();

            return damage;
        }

        public string GetWeaponName()
        {
            return "👊 Tay Không";
        }

        public int GetDamage()
        {
            return 37; // Sát thương thấp nhất
        }
    }
}
