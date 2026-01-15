using System;

namespace StrategyPatternDemo
{
    /// <summary>
    /// Context Class - Nhân vật trong game
    /// Vai trò: Sử dụng Strategy để thực hiện tấn công
    /// Ý nghĩa: Character không cần biết chi tiết cách tấn công của từng vũ khí
    /// </summary>
    public class Character
    {
        public string Name { get; private set; }
        public int Level { get; private set; }
        public int Health { get; private set; }
        public int MaxHealth { get; private set; }

        // Strategy Pattern: Vũ khí hiện tại là một Strategy
        private IAttackStrategy currentWeapon;

        // Thống kê
        public int TotalDamageDealt { get; private set; }
        private int attackCount;

        public Character(string name, int level = 1)
        {
            Name = name;
            Level = level;
            MaxHealth = 100 + (level * 20);
            Health = MaxHealth;
            TotalDamageDealt = 0;
            attackCount = 0;

            // Mặc định dùng tay không
            currentWeapon = new FistAttack();
        }

        /// <summary>
        /// Trang bị vũ khí mới - Thay đổi Strategy tại runtime
        /// Đây là điểm mạnh của Strategy Pattern: Thay đổi hành vi linh hoạt
        /// </summary>
        public void EquipWeapon(IAttackStrategy weapon)
        {
            currentWeapon = weapon;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n🎒 {Name} trang bị {weapon.GetWeaponName()}!");
            Console.WriteLine($"   📊 Sát thương cơ bản: {weapon.GetDamage()}");
            Console.ResetColor();
        }

        /// <summary>
        /// Thực hiện tấn công - Sử dụng Strategy hiện tại
        /// Character không cần biết chi tiết cách tấn công
        /// </summary>
        public int Attack()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n⚡ {Name} (Lv.{Level}) tấn công bằng {currentWeapon.GetWeaponName()}:");
            Console.ResetColor();

            // Gọi strategy để thực hiện tấn công
            int baseDamage = currentWeapon.Attack();

            // Tính toán sát thương dựa trên level
            int finalDamage = baseDamage + (Level * 5);

            // Cập nhật thống kê
            TotalDamageDealt += finalDamage;
            attackCount++;

            // Animation
            System.Threading.Thread.Sleep(500);

            return finalDamage;
        }

        /// <summary>
        /// Hiển thị trạng thái nhân vật
        /// </summary>
        public void ShowStatus()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n" + new string('=', 50));
            Console.WriteLine($"👤 THÔNG TIN NHÂN VẬT: {Name}");
            Console.WriteLine(new string('=', 50));
            Console.WriteLine($"⭐ Cấp độ: {Level}");
            Console.WriteLine($"❤️  Máu: {Health}/{MaxHealth} {GetHealthBar()}");
            Console.WriteLine($"🗡️  Vũ khí: {currentWeapon.GetWeaponName()}");
            Console.WriteLine($"💪 Sát thương cơ bản: {currentWeapon.GetDamage() + (Level * 5)}");
            Console.WriteLine($"📊 Tổng sát thương đã gây: {TotalDamageDealt}");
            Console.WriteLine($"🎯 Số lần tấn công: {attackCount}");
            if (attackCount > 0)
            {
                Console.WriteLine($"📈 Sát thương trung bình: {TotalDamageDealt / attackCount}");
            }
            Console.WriteLine(new string('=', 50));
            Console.ResetColor();
        }

        /// <summary>
        /// Tăng cấp độ
        /// </summary>
        public void LevelUp()
        {
            Level++;
            MaxHealth += 20;
            Health = MaxHealth;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n✨ LEVEL UP! {Name} đạt cấp {Level}!");
            Console.WriteLine($"   ❤️  Máu tối đa tăng lên {MaxHealth}");
            Console.WriteLine($"   💪 Sát thương tăng thêm 5 điểm!");
            Console.ResetColor();
            System.Threading.Thread.Sleep(1000);
        }

        /// <summary>
        /// Tạo thanh máu dạng ASCII
        /// </summary>
        private string GetHealthBar()
        {
            int barLength = 20;
            int filledLength = (int)((double)Health / MaxHealth * barLength);
            string bar = "[" + new string('█', filledLength) + new string('░', barLength - filledLength) + "]";
            return bar;
        }

        public string GetCurrentWeaponName()
        {
            return currentWeapon.GetWeaponName();
        }
    }
}
