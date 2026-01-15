using System;

namespace StrategyPatternDemo
{
    /// <summary>
    /// Lớp Enemy - Kẻ địch trong game
    /// Vai trò: Đối tượng nhận sát thương từ Character
    /// </summary>
    public class Enemy
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        public int MaxHealth { get; private set; }
        public int Defense { get; private set; }

        public Enemy(string name, int health, int defense)
        {
            Name = name;
            MaxHealth = health;
            Health = health;
            Defense = defense;
        }

        /// <summary>
        /// Nhận sát thương từ tấn công
        /// </summary>
        public void TakeDamage(int damage)
        {
            // Tính toán sát thương sau khi trừ giáp
            int actualDamage = Math.Max(damage - Defense, 0);
            Health -= actualDamage;

            if (Health < 0) Health = 0;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"    🛡️ {Name} chống đỡ {Defense} sát thương!");
            Console.WriteLine($"    💔 {Name} nhận {actualDamage} sát thương! ({Health}/{MaxHealth} HP) {GetHealthBar()}");

            if (!IsAlive())
            {
                Console.WriteLine($"    ☠️  {Name} đã bị đánh bại!");
            }
            Console.ResetColor();
        }

        /// <summary>
        /// Kiểm tra còn sống không
        /// </summary>
        public bool IsAlive()
        {
            return Health > 0;
        }

        /// <summary>
        /// Hiển thị thông tin enemy
        /// </summary>
        public void ShowInfo()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n👹 {Name} xuất hiện!");
            Console.WriteLine($"   ❤️  Máu: {Health}/{MaxHealth}");
            Console.WriteLine($"   🛡️  Giáp: {Defense}");
            Console.ResetColor();
        }

        /// <summary>
        /// Tạo thanh máu dạng ASCII
        /// </summary>
        private string GetHealthBar()
        {
            int barLength = 15;
            int filledLength = (int)((double)Health / MaxHealth * barLength);
            string bar = "[" + new string('█', filledLength) + new string('░', barLength - filledLength) + "]";
            return bar;
        }

        /// <summary>
        /// Tạo các loại enemy khác nhau
        /// </summary>
        public static Enemy CreateGoblin()
        {
            return new Enemy("👺 Goblin", 100, 5);
        }

        public static Enemy CreateOrc()
        {
            return new Enemy("🧟 Orc", 200, 10);
        }

        public static Enemy CreateDragon()
        {
            return new Enemy("🐉 Dragon", 500, 20);
        }
    }
}
