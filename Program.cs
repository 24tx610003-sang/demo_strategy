using System;
using System.Threading;

namespace StrategyPatternDemo
{
    class Program
    {
        static Character warrior;

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            ShowTitle();
            Scene1_Introduction();
            Scene2_FightGoblin();
            Scene3_FightOrc();
            Scene4_FightDragon();
            Scene5_TestFist();
            Scene6_Summary();

            Console.WriteLine("\n\nNhấn phím bất kỳ để thoát...");
            Console.ReadKey();
        }

        static void ShowTitle()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
╔═══════════════════════════════════════════════════════════════╗
║                                                               ║
║        🎮 DEMO STRATEGY PATTERN - HỆ THỐNG CHIẾN ĐẤU 🎮       ║
║                                                               ║
║         Môn: Thiết Kế Phần Mềm Hướng Đối Tượng               ║
║              Đề tài: Strategy Design Pattern                 ║
║                                                               ║
╚═══════════════════════════════════════════════════════════════╝
");
            Console.ResetColor();
            Thread.Sleep(2000);
        }

        static void Scene1_Introduction()
        {
            ShowSceneHeader("SCENE 1: GIỚI THIỆU NHÂN VẬT");
            Console.WriteLine("Tạo nhân vật mới...\n");
            warrior = new Character("⚔️ Warrior", 1);
            warrior.ShowStatus();

            Console.WriteLine("\n💡 Giải thích:");
            Console.WriteLine("   - Character là Context Class trong Strategy Pattern");
            Console.WriteLine("   - Character có thể thay đổi vũ khí (Strategy) bất cứ lúc nào");
            Console.WriteLine("   - Mặc định nhân vật dùng Tay Không (FistAttack Strategy)");
            WaitForUser();
        }

        static void Scene2_FightGoblin()
        {
            ShowSceneHeader("SCENE 2: CHIẾN ĐẤU VỚI GOBLIN - SỬ DỤNG KIẾM");
            warrior.EquipWeapon(new SwordAttack());

            Console.WriteLine("\n💡 Giải thích:");
            Console.WriteLine("   - EquipWeapon() thay đổi Strategy từ FistAttack sang SwordAttack");
            Console.WriteLine("   - Character không cần biết chi tiết cách kiếm tấn công");
            Console.WriteLine("   - Chỉ cần gọi Attack(), Strategy sẽ tự xử lý\n");
            Thread.Sleep(2000);

            Enemy goblin = Enemy.CreateGoblin();
            goblin.ShowInfo();
            Console.WriteLine("\n⚔️ BẮT ĐẦU CHIẾN ĐẤU!");
            Thread.Sleep(1000);

            while (goblin.IsAlive())
            {
                int damage = warrior.Attack();
                goblin.TakeDamage(damage);
                Thread.Sleep(1500);
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n🎉 CHIẾN THẮNG! Goblin đã bị đánh bại!");
            Console.ResetColor();
            WaitForUser();
        }

        static void Scene3_FightOrc()
        {
            ShowSceneHeader("SCENE 3: CHIẾN ĐẤU VỚI ORC - CHUYỂN SANG DÙNG CUNG");
            warrior.EquipWeapon(new BowAttack());

            Console.WriteLine("\n💡 Giải thích:");
            Console.WriteLine("   - Thay đổi Strategy từ SwordAttack sang BowAttack");
            Console.WriteLine("   - Không cần sửa code của Character class");
            Console.WriteLine("   - Chỉ cần truyền Strategy mới vào EquipWeapon()");
            Console.WriteLine("   - Cung có sát thương thấp hơn kiếm nhưng an toàn hơn\n");
            Thread.Sleep(2000);

            Enemy orc = Enemy.CreateOrc();
            orc.ShowInfo();
            Console.WriteLine("\n🏹 BẮT ĐẦU CHIẾN ĐẤU!");
            Thread.Sleep(1000);

            while (orc.IsAlive())
            {
                int damage = warrior.Attack();
                orc.TakeDamage(damage);
                Thread.Sleep(1500);
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n🎉 CHIẾN THẮNG! Orc đã bị đánh bại!");
            Console.ResetColor();
            WaitForUser();
        }

        static void Scene4_FightDragon()
        {
            ShowSceneHeader("SCENE 4: BOSS FIGHT - DRAGON VỚI MA THUẬT");
            warrior.LevelUp();
            warrior.LevelUp();
            warrior.EquipWeapon(new MagicAttack());

            Console.WriteLine("\n💡 Giải thích:");
            Console.WriteLine("   - MagicAttack là Strategy mạnh nhất (60-100 damage)");
            Console.WriteLine("   - Nhân vật đã lên level 3, sát thương tăng thêm 15 điểm");
            Console.WriteLine("   - Tổng sát thương = Damage từ Strategy + Level bonus");
            Console.WriteLine("   - Dragon có giáp cao (20), cần vũ khí mạnh\n");
            Thread.Sleep(2000);

            Enemy dragon = Enemy.CreateDragon();
            dragon.ShowInfo();
            Console.WriteLine("\n🐉 BOSS FIGHT - BẮT ĐẦU!");
            Thread.Sleep(1000);

            while (dragon.IsAlive())
            {
                int damage = warrior.Attack();
                dragon.TakeDamage(damage);
                Thread.Sleep(1500);
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n🎊 CHIẾN THẮNG HOÀNH TRÁNG! Dragon đã bị đánh bại!");
            Console.ResetColor();
            WaitForUser();
        }

        static void Scene5_TestFist()
        {
            ShowSceneHeader("SCENE 5: THỬ NGHIỆM TAY KHÔNG");
            warrior.EquipWeapon(new FistAttack());

            Console.WriteLine("\n💡 Giải thích:");
            Console.WriteLine("   - FistAttack là Strategy yếu nhất (30-45 damage)");
            Console.WriteLine("   - Dùng khi không có vũ khí hoặc muốn thử thách");
            Console.WriteLine("   - Vẫn có thể chiến đấu nhờ level cao\n");
            Thread.Sleep(2000);

            Enemy testGoblin = Enemy.CreateGoblin();
            testGoblin.ShowInfo();
            Console.WriteLine("\n👊 THỬ NGHIỆM TAY KHÔNG!");
            Thread.Sleep(1000);

            for (int i = 0; i < 3 && testGoblin.IsAlive(); i++)
            {
                int damage = warrior.Attack();
                testGoblin.TakeDamage(damage);
                Thread.Sleep(1500);
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n✅ Hoàn thành thử nghiệm!");
            Console.ResetColor();
            WaitForUser();
        }

        static void Scene6_Summary()
        {
            ShowSceneHeader("SCENE 6: TỔNG KẾT & GIẢI THÍCH STRATEGY PATTERN");
            warrior.ShowStatus();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n📊 SO SÁNH CÁC VŨ KHÍ (STRATEGIES):");
            Console.WriteLine(new string('=', 60));
            Console.WriteLine("Vũ khí         │ Sát thương │ Đặc điểm");
            Console.WriteLine(new string('-', 60));
            Console.WriteLine("👊 Tay Không   │  30-45     │ Yếu nhất, không vũ khí");
            Console.WriteLine("🏹 Cung        │  40-60     │ Tầm xa, an toàn");
            Console.WriteLine("⚔️ Kiếm        │  50-80     │ Cân bằng, cận chiến");
            Console.WriteLine("🔮 Ma Thuật    │  60-100    │ Mạnh nhất, đa dạng");
            Console.WriteLine(new string('=', 60));
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\n🎓 GIẢI THÍCH STRATEGY PATTERN:");
            Console.WriteLine(new string('=', 60));

            Console.WriteLine("\n1️⃣ VẤN ĐỀ:");
            Console.WriteLine("   - Làm thế nào để nhân vật có thể thay đổi cách tấn công?");
            Console.WriteLine("   - Không muốn dùng if-else hoặc switch-case phức tạp");
            Console.WriteLine("   - Dễ dàng thêm vũ khí mới mà không sửa code cũ");

            Console.WriteLine("\n2️⃣ GIẢI PHÁP - STRATEGY PATTERN:");
            Console.WriteLine("   - Tạo interface IAttackStrategy cho tất cả vũ khí");
            Console.WriteLine("   - Mỗi vũ khí là một Concrete Strategy");
            Console.WriteLine("   - Character giữ reference đến Strategy hiện tại");
            Console.WriteLine("   - Thay đổi Strategy = Thay đổi hành vi");

            Console.WriteLine("\n3️⃣ CÁC THÀNH PHẦN:");
            Console.WriteLine("   📋 Strategy Interface (IAttackStrategy):");
            Console.WriteLine("      • Định nghĩa hợp đồng chung");
            Console.WriteLine("      • Attack(), GetWeaponName(), GetDamage()");

            Console.WriteLine("\n   🗡️ Concrete Strategies (SwordAttack, BowAttack, ...):");
            Console.WriteLine("      • Implement IAttackStrategy");
            Console.WriteLine("      • Mỗi Strategy có logic riêng");
            Console.WriteLine("      • Sát thương, hiệu ứng khác nhau");

            Console.WriteLine("\n   👤 Context (Character):");
            Console.WriteLine("      • Giữ reference đến Strategy hiện tại");
            Console.WriteLine("      • EquipWeapon() để thay đổi Strategy");
            Console.WriteLine("      • Attack() gọi strategy.Attack()");

            Console.WriteLine("\n4️⃣ ƯU ĐIỂM:");
            Console.WriteLine("   ✅ Dễ dàng thay đổi hành vi tại runtime");
            Console.WriteLine("   ✅ Loại bỏ if-else/switch-case phức tạp");
            Console.WriteLine("   ✅ Dễ dàng thêm Strategy mới (Open/Closed Principle)");
            Console.WriteLine("   ✅ Code dễ test, dễ maintain");
            Console.WriteLine("   ✅ Tách biệt logic của từng Strategy");

            Console.WriteLine("\n5️⃣ KHI NÀO SỬ DỤNG:");
            Console.WriteLine("   🎯 Khi có nhiều cách thực hiện một hành vi");
            Console.WriteLine("   🎯 Muốn tránh if-else/switch-case dài");
            Console.WriteLine("   🎯 Cần thay đổi algorithm tại runtime");
            Console.WriteLine("   🎯 Các thuật toán có thể tái sử dụng");

            Console.WriteLine("\n6️⃣ VÍ DỤ THỰC TẾ KHÁC:");
            Console.WriteLine("   💳 Thanh toán: Credit Card, PayPal, Bitcoin");
            Console.WriteLine("   🚗 Di chuyển: Đi bộ, Xe bus, Xe máy, Ô tô");
            Console.WriteLine("   📦 Giao hàng: Nhanh, Tiêu chuẩn, Tiết kiệm");
            Console.WriteLine("   🎨 Vẽ: Bút chì, Bút màu, Sơn dầu");

            Console.WriteLine("\n" + new string('=', 60));
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n✨ KẾT LUẬN:");
            Console.WriteLine("Strategy Pattern giúp code linh hoạt, dễ mở rộng và bảo trì.");
            Console.WriteLine("Trong demo này, chúng ta đã thấy cách nhân vật thay đổi vũ khí");
            Console.WriteLine("(thay đổi Strategy) một cách dễ dàng mà không cần sửa code!");
            Console.ResetColor();
        }

        static void ShowSceneHeader(string title)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n\n" + new string('═', 70));
            Console.WriteLine($"  {title}");
            Console.WriteLine(new string('═', 70));
            Console.ResetColor();
            Thread.Sleep(1000);
        }

        static void WaitForUser()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\n[Nhấn phím bất kỳ để tiếp tục...]");
            Console.ResetColor();
            Console.ReadKey(true);
        }
    }
}
