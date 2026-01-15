using System;

namespace StrategyPatternDemo
{
    /// <summary>
    /// Concrete Strategy - Tấn công bằng Ma Thuật
    /// Đặc điểm: Năng lượng phép thuật, đa dạng hiệu ứng
    /// Phù hợp: Phù thủy, sát thương cao nhất
    /// </summary>
    public class MagicAttack : IAttackStrategy
    {
        private static readonly Random random = new Random();
        private readonly string[] effects = { "🔥 Cầu lửa!", "⚡ Tia sét!", "❄️ Băng phong!" };

        public int Attack()
        {
            // Sát thương ngẫu nhiên từ 60-100 (cao nhất)
            int damage = random.Next(60, 101);

            // Hiển thị hiệu ứng tấn công
            string effect = effects[random.Next(effects.Length)];
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"    ✨ {effect}");
            Console.WriteLine($"    🔮 Gây {damage} sát thương phép thuật!");
            Console.ResetColor();

            return damage;
        }

        public string GetWeaponName()
        {
            return "🔮 Ma Trượng Cổ Đại";
        }

        public int GetDamage()
        {
            return 80; // Sát thương cao nhất
        }
    }
}
