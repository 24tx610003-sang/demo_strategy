using System;

namespace StrategyPatternDemo
{
    /// <summary>
    /// Concrete Strategy - Tấn công bằng Cung
    /// Đặc điểm: Tấn công tầm xa, chính xác
    /// Phù hợp: Xạ thủ, tấn công từ xa an toàn
    /// </summary>
    public class BowAttack : IAttackStrategy
    {
        private static readonly Random random = new Random();
        private readonly string[] effects = { "🏹 Bắn mũi tên!", "🎯 Đa bắn!", "🔥 Mũi tên lửa!" };

        public int Attack()
        {
            // Sát thương ngẫu nhiên từ 40-60
            int damage = random.Next(40, 61);

            // Hiển thị hiệu ứng tấn công
            string effect = effects[random.Next(effects.Length)];
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"    {effect}");
            Console.WriteLine($"    🎯 Gây {damage} sát thương xuyên!");
            Console.ResetColor();

            return damage;
        }

        public string GetWeaponName()
        {
            return "🏹 Cung Thiên Thần";
        }

        public int GetDamage()
        {
            return 50; // Sát thương trung bình thấp
        }
    }
}
