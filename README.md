# 🎮 DEMO STRATEGY PATTERN - HỆ THỐNG CHIẾN ĐẤU

## 📚 Thông Tin
**Môn học**: Thiết Kế Phần Mềm Hướng Đối Tượng  
**Đề tài**: Strategy Design Pattern  
**Chương trình**: Hệ thống chiến đấu RPG

## 🚀 Cách Chạy
```bash
dotnet build
dotnet run
```

## 📖 Giải Thích Strategy Pattern

### Các thành phần:
- **IAttackStrategy**: Strategy Interface
- **SwordAttack, BowAttack, MagicAttack, FistAttack**: Concrete Strategies
- **Character**: Context Class
- **Enemy**: Đối tượng nhận sát thương

### Ưu điểm:
✅ Thay đổi hành vi linh hoạt tại runtime  
✅ Tránh if-else phức tạp  
✅ Dễ mở rộng (thêm vũ khí mới)  
✅ Code dễ bảo trì
