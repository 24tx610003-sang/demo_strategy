# 📘 HƯỚNG DẪN STRATEGY PATTERN CHI TIẾT

## 🎯 Tổng Quan

Strategy Pattern là một behavioral design pattern cho phép định nghĩa một họ các thuật toán, đóng gói từng thuật toán và làm cho chúng có thể hoán đổi cho nhau. Strategy cho phép thuật toán thay đổi độc lập với client sử dụng nó.

## 🏗️ Cấu Trúc

### 1. Strategy Interface (`IAttackStrategy`)

```csharp
public interface IAttackStrategy
{
    int Attack();
    string GetWeaponName();
    int GetDamage();
}
```

**Vai trò**: Định nghĩa interface chung cho tất cả các Strategy.

**Ý nghĩa**:
- Tất cả các vũ khí (strategies) đều phải implement interface này
- Context chỉ cần biết interface này, không cần biết chi tiết implementation
- Đảm bảo tính thống nhất giữa các strategies

### 2. Concrete Strategies

#### A. SwordAttack (Kiếm)
- **Sát thương**: 50-80 damage
- **Đặc điểm**: Vật lý, cận chiến, cân bằng
- **Khi nào dùng**: Chiến đấu cận chiến, đa năng

#### B. BowAttack (Cung)
- **Sát thương**: 40-60 damage
- **Đặc điểm**: Tầm xa, an toàn
- **Khi nào dùng**: Tấn công từ xa, tránh nguy hiểm

#### C. MagicAttack (Ma thuật)
- **Sát thương**: 60-100 damage (cao nhất)
- **Đặc điểm**: Phép thuật, đa dạng hiệu ứng
- **Khi nào dùng**: Boss fight, cần sát thương cao

#### D. FistAttack (Tay không)
- **Sát thương**: 30-45 damage (thấp nhất)
- **Đặc điểm**: Võ thuật, không vũ khí
- **Khi nào dùng**: Mặc định, không có vũ khí

### 3. Context Class (`Character`)

```csharp
public class Character
{
    private IAttackStrategy currentWeapon;
    
    public void EquipWeapon(IAttackStrategy weapon)
    {
        currentWeapon = weapon;
    }
    
    public int Attack()
    {
        return currentWeapon.Attack();
    }
}
```

**Vai trò**: Sử dụng Strategy để thực hiện hành động.

**Ý nghĩa**:
- Giữ reference đến Strategy hiện tại
- Delegate công việc cho Strategy
- Có thể thay đổi Strategy tại runtime
- Không cần biết chi tiết implementation của Strategy

## 💡 Luồng Hoạt Động

```
1. Character được tạo
   └─> Khởi tạo với FistAttack (default Strategy)

2. EquipWeapon(new SwordAttack())
   └─> Thay đổi currentWeapon sang SwordAttack
   └─> Strategy được thay đổi tại runtime

3. Character.Attack()
   └─> Gọi currentWeapon.Attack()
   └─> SwordAttack.Attack() được thực thi
   └─> Hiển thị hiệu ứng kiếm
   └─> Trả về sát thương

4. EquipWeapon(new BowAttack())
   └─> Thay đổi Strategy sang BowAttack
   
5. Character.Attack()
   └─> Gọi currentWeapon.Attack()
   └─> BowAttack.Attack() được thực thi
   └─> Hiển thị hiệu ứng cung
   └─> Trả về sát thương khác
```

## ✅ Ưu Điểm

### 1. Open/Closed Principle
```csharp
// Thêm vũ khí mới mà KHÔNG sửa code cũ
public class HammerAttack : IAttackStrategy
{
    public int Attack() { /* Logic búa */ }
    // ...
}

// Sử dụng ngay lập tức
character.EquipWeapon(new HammerAttack());
```

### 2. Tránh If-Else/Switch-Case Phức Tạp

**❌ Không dùng Strategy Pattern:**
```csharp
public int Attack(WeaponType weaponType)
{
    if (weaponType == WeaponType.Sword)
    {
        // Logic kiếm
        return 50 + random.Next(30);
    }
    else if (weaponType == WeaponType.Bow)
    {
        // Logic cung
        return 40 + random.Next(20);
    }
    else if (weaponType == WeaponType.Magic)
    {
        // Logic magic
        return 60 + random.Next(40);
    }
    // Thêm vũ khí mới? Phải sửa code này!
}
```

**✅ Dùng Strategy Pattern:**
```csharp
public int Attack()
{
    return currentWeapon.Attack(); // Đơn giản, rõ ràng!
}
```

### 3. Thay Đổi Hành Vi Tại Runtime
```csharp
// Ban đầu dùng kiếm
character.EquipWeapon(new SwordAttack());
character.Attack(); // Tấn công bằng kiếm

// Thay sang cung ngay lập tức
character.EquipWeapon(new BowAttack());
character.Attack(); // Tấn công bằng cung

// Không cần restart, không cần compile lại
```

### 4. Code Dễ Test
```csharp
// Test riêng từng Strategy
[Test]
public void TestSwordAttack()
{
    var sword = new SwordAttack();
    int damage = sword.Attack();
    Assert.IsTrue(damage >= 50 && damage <= 80);
}

// Test Character với Mock Strategy
[Test]
public void TestCharacterWithMockWeapon()
{
    var mockWeapon = new Mock<IAttackStrategy>();
    mockWeapon.Setup(w => w.Attack()).Returns(100);
    
    var character = new Character("Test");
    character.EquipWeapon(mockWeapon.Object);
    
    Assert.AreEqual(100, character.Attack());
}
```

## 📋 Khi Nào Sử Dụng Strategy Pattern?

### ✅ Nên Dùng Khi:
1. Có nhiều cách thực hiện một hành vi
2. Muốn tránh if-else/switch-case dài
3. Cần thay đổi algorithm tại runtime
4. Các algorithm có thể tái sử dụng ở nhiều nơi
5. Muốn tách biệt logic của từng algorithm

### ❌ Không Nên Dùng Khi:
1. Chỉ có 1-2 cách thực hiện đơn giản
2. Logic không thay đổi
3. Không cần thay đổi tại runtime
4. Overhead phức tạp hơn lợi ích

## 🌟 Ví Dụ Thực Tế

### 1. Hệ Thống Thanh Toán
```csharp
interface IPaymentStrategy
{
    void Pay(decimal amount);
}

class CreditCardPayment : IPaymentStrategy { }
class PayPalPayment : IPaymentStrategy { }
class BitcoinPayment : IPaymentStrategy { }

// Sử dụng
checkout.SetPaymentMethod(new CreditCardPayment());
checkout.ProcessPayment(100);
```

### 2. Hệ Thống Di Chuyển
```csharp
interface IMovementStrategy
{
    void Move(Point destination);
}

class WalkStrategy : IMovementStrategy { }
class CarStrategy : IMovementStrategy { }
class FlyStrategy : IMovementStrategy { }
```

### 3. Xử Lý File
```csharp
interface ICompressionStrategy
{
    void Compress(string file);
}

class ZipCompression : ICompressionStrategy { }
class RarCompression : ICompressionStrategy { }
class SevenZipCompression : ICompressionStrategy { }
```

### 4. Sắp Xếp Dữ Liệu
```csharp
interface ISortStrategy
{
    void Sort(int[] array);
}

class QuickSort : ISortStrategy { }
class MergeSort : ISortStrategy { }
class BubbleSort : ISortStrategy { }
```

## 🎓 So Sánh Với Các Pattern Khác

### Strategy vs State Pattern
- **Strategy**: Tập trung vào algorithm, thay đổi bởi client
- **State**: Tập trung vào state, tự động thay đổi state

### Strategy vs Template Method
- **Strategy**: Sử dụng composition (has-a)
- **Template Method**: Sử dụng inheritance (is-a)

### Strategy vs Command Pattern
- **Strategy**: Tập trung vào algorithm
- **Command**: Tập trung vào encapsulate request

## 🚀 Cách Mở Rộng

### Thêm Vũ Khí Mới

```csharp
// 1. Tạo class mới implement IAttackStrategy
public class AxeAttack : IAttackStrategy
{
    public int Attack()
    {
        // Logic của búa
        return random.Next(55, 90);
    }
    
    public string GetWeaponName()
    {
        return "🪓 Búa Chiến";
    }
    
    public int GetDamage()
    {
        return 72;
    }
}

// 2. Sử dụng ngay
character.EquipWeapon(new AxeAttack());
character.Attack(); // Tấn công bằng búa!
```

### Thêm Tính Năng Mới

```csharp
// Thêm phương thức vào interface
public interface IAttackStrategy
{
    int Attack();
    string GetWeaponName();
    int GetDamage();
    string GetSpecialAbility(); // Mới
}

// Implement trong các Concrete Strategy
public class SwordAttack : IAttackStrategy
{
    public string GetSpecialAbility()
    {
        return "⚡ Chém xoay 360 độ!";
    }
}
```

## 📝 Best Practices

1. **Giữ Strategy nhỏ gọn**: Mỗi Strategy chỉ làm một việc
2. **Immutable Strategy**: Strategy không nên thay đổi state
3. **Dependency Injection**: Inject Strategy qua constructor
4. **Factory Pattern**: Sử dụng Factory để tạo Strategy
5. **Naming Convention**: Đặt tên rõ ràng (SomethingStrategy)

## 🎯 Kết Luận

Strategy Pattern là một pattern mạnh mẽ giúp:
- ✅ Code linh hoạt, dễ mở rộng
- ✅ Tách biệt logic rõ ràng
- ✅ Dễ test, dễ maintain
- ✅ Tuân thủ SOLID principles
- ✅ Thay đổi hành vi tại runtime

**Hãy sử dụng Strategy Pattern khi bạn cần nhiều cách thực hiện một hành vi và muốn code dễ mở rộng!**
