using System;

namespace StrategyPatternDemo
{
    /// <summary>
    /// Strategy Interface - Định nghĩa hợp đồng chung cho tất cả các kiểu tấn công
    /// Vai trò: Đảm bảo tất cả vũ khí đều có cùng interface
    /// </summary>
    public interface IAttackStrategy
    {
        /// <summary>
        /// Thực hiện tấn công và trả về sát thương gây ra
        /// </summary>
        int Attack();

        /// <summary>
        /// Lấy tên vũ khí
        /// </summary>
        string GetWeaponName();

        /// <summary>
        /// Lấy sát thương cơ bản của vũ khí
        /// </summary>
        int GetDamage();
    }
}
