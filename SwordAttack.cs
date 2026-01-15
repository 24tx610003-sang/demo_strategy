using System;

namespace StrategyPatternDemo
{
    /// <summary>
    /// Concrete Strategy - Tấn công bằng Kiếm
    /// Đặc điểm: Sát thương vật lý cao, cận chiến
    /// Phù hợp: Chiến binh cận chiến
    /// </summary>
    public class SwordAttack : IAttackStrategy
    {
        private static readonly Random random = new Random();
        private readonly string[] effects = { "⚔️ Chém mạnh!", "🗡️ Đòn chí mạng!", "⚔️ Phản đòn!" };

        public int Attack()
        {
            // Sát thương ngẫu nhiên từ 50-80
            int damage = random.Next(50, 81);

            // Hiển thị hiệu ứng tấn công
            string effect = effects[random.Next(effects.Length)];
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"    {effect}");
            Console.WriteLine($"    💥 Gây {damage} sát thương vật lý!");
            Console.ResetColor();

            return damage;
        }

        public string GetWeaponName()
        {
            return "⚔️ Kiếm Thần";
        }

        public int GetDamage()
        {
            return 65; // Sát thương trung bình
        }
    }
}
