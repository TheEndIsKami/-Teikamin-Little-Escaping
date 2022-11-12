using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager instance;
    public enum ItemCode { FireStaff, SnipeGun, BootsOfSpeed, WeakBranch, WindWhisper, BowOfDevil, MaskOfLife, IceBall, 
        OldRibcage, FallenSky, BookOfKnowledge, MaskOfTears, SwordOfLight }
    public Sprite[] itemSprite;

    private void Awake()
    {
        instance = this;
    }

    public Item ReturnItemType(int itemID)
    {
        Item item = itemID switch
        {
            0 => new ItemFireStaff(),
            1 => new ItemSnipeGun(),
            2 => new ItemBootsOfSpeed(),
            3 => new ItemWeakBranch(),
            4 => new ItemWindWhisper(),
            5 => new ItemBowOfDevil(),
            6 => new ItemMaskOfLife(),
            7 => new ItemIceBall(),
            8 => new ItemOldRibcage(),
            9 => new ItemFallenSky(),
            10 => new ItemBookOfKnowledge(),
            11 => new ItemMaskOfTears(),
            12 => new ItemSwordOfLight(),
            _ => new ItemFireStaff(),
        };
        return item;
    }

    public string ReturnItemTextDes(int itemID, int level)
    {
        string itemDes = null;
        if (itemID == (int)ItemCode.FireStaff)
        {
            switch (level)
            {
                case 1: itemDes = "[5s] Bắn 1 cầu lửa gây 100%atk"; break;
                case 2: itemDes = "Tăng sát thương cầu lửa thêm +50%atk"; break;
                case 3: itemDes = "Bắn được thêm 1 cầu lửa nữa"; break;
                case 4: itemDes = "Tăng sát thương cầu lửa thêm +50%atk"; break;
                case 5: itemDes = "Cầu lửa vỡ ra 3 hạt lửa nhỏ hơn, gây 20%atk ea."; break;
                case 6: itemDes = "Bắn được thêm 1 cầu lửa nữa"; break;
                case 7: itemDes = "Tăng sát thương cầu lửa thêm +50%atk"; break;
                case 8: itemDes = "Tăng sát thương các hạt lửa thêm +30%atk"; break;
                case 9: itemDes = "Bắn được thêm 1 cầu lửa nữa"; break;
                case 10: itemDes = "Giảm thời gian CD của cầu lửa 2s"; break;

            }
        }
        if (itemID == (int)ItemCode.SnipeGun)
        {
            switch (level)
            {
                case 1: itemDes = "Đòn đánh thường có 7% đánh thêm 1 lần"; break;
                case 2: itemDes = "Tăng thêm +3% kích hoạt (10%) đánh thêm 1 lần"; break;
                case 3: itemDes = "[10s] Trong 5s tăng 25% tốc độ đánh"; break;
                case 4: itemDes = "Tăng thêm +7% kích hoạt (17%) đánh thêm 1 lần"; break;
                case 5: itemDes = "Khi bắn thêm 1 lần, giảm count down của súng 1s"; break;
                case 6: itemDes = "Tăng 5% kích hoạt (22%) đánh thêm 1 lần"; break;
                case 7: itemDes = "[10s] Trong 7s tăng 25% tốc độ đánh"; break;
                case 8: itemDes = "[10s] Trong 7s tăng 45% tốc độ đánh"; break;
                case 9: itemDes = "Tăng 5% kích hoạt (27%) đánh thêm 1 lần"; break;
                case 10: itemDes = "Tăng 5% kích hoạt (32%) đánh thêm 1 lần"; break;

            }
        }
        if (itemID == (int)ItemCode.BootsOfSpeed)
        {
            switch (level)
            {
                case 1: itemDes = "Tăng 0.1 tốc độ chạy "; break;
                case 2: itemDes = "[30s] Tốc độ chạy được tăng 25% trong 2s"; break;
                case 3: itemDes = "Tăng thêm +0.1 tốc độ chạy (tổng cộng 0.2)"; break;
                case 4: itemDes = "Tăng thêm +0.1 tốc độ chạy (tổng cộng 0.3)"; break;
                case 5: itemDes = "[30s] Tốc độ chạy được tăng 25% trong 3s"; break;
                case 6: itemDes = "Tăng thêm +0.1 tốc độ chạy (tổng cộng 0.4)"; break;
                case 7: itemDes = "Khi chạy, để lại một dải lửa, gây 20%atk khi dẫm lên"; break;
                case 8: itemDes = "[30s] Tốc độ chạy được tăng 40% trong 3s"; break;
                case 9: itemDes = "[30s] Tốc độ chạy được tăng 40% trong 5s"; break;
                case 10: itemDes = "Tăng sát thương dải lửa lên 50%atk"; break;

            }
        }
        if (itemID == (int)ItemCode.WeakBranch)
        {
            switch (level)
            {
                case 1: itemDes = "Tăng 2 ATK"; break;
                case 2: itemDes = "Tăng thêm +5 ATK (Tổng cộng 7 ATK)"; break;
                case 3: itemDes = "Tăng thêm +5 ATK (Tổng cộng 12 ATK)"; break;
                case 4: itemDes = "[20s] Trong 5s tăng 20% ATK"; break;
                case 5: itemDes = "Tăng thêm +5 ATK (Tổng cộng 17 ATK)"; break;
                case 6: itemDes = "Tăng 5 ATK"; break;
                case 7: itemDes = "[20s] Trong 5s tăng 50% ATK"; break;
                case 8: itemDes = "Tăng 5 ATK"; break;
                case 9: itemDes = "[20s] Trong 10s tăng 50% ATK"; break;
                case 10: itemDes = "Tăng 10% ATK"; break;

            }
        }
        if (itemID == (int)ItemCode.WindWhisper)
        {
            switch (level)
            {
                case 1: itemDes = "[5s] Tạo ra xung quanh bản thân một vùng gió cắt, gây 50%atk"; break;
                case 2: itemDes = "Tăng sát thương gió cắt thêm +25%atk"; break;
                case 3: itemDes = "Tăng sát thương gió cắt thêm +25%atk"; break;
                case 4: itemDes = "Gió cắt có thể đẩy lùi mọi kẻ địch"; break;
                case 5: itemDes = "Tăng sát thương gió cắt thêm +50%atk"; break;
                case 6: itemDes = "Tăng sát thương gió cắt thêm +50%atk"; break;
                case 7: itemDes = "Tăng bán kính gió cắt thêm 20%"; break;
                case 8: itemDes = "Tăng sát thương gió cắt thêm +50%atk"; break;
                case 9: itemDes = "Tăng sát thương gió cắt thêm +50%atk"; break;
                case 10: itemDes = "Tăng sát thương gió cắt thêm +100%atk"; break;

            }
        }
        if (itemID == (int)ItemCode.BowOfDevil)
        {
            switch (level)
            {
                case 1: itemDes = "[40s] Bắn một mũi tên xuyên thấu mọi kẻ địch và lấy 10%hp của chúng"; break;
                case 2: itemDes = "Giảm 5s count down kĩ năng"; break;
                case 3: itemDes = "Giảm thêm 5s count down nữa"; break;
                case 4: itemDes = "Cung Ác Ma có thể đẩy lùi mọi kẻ địch"; break;
                case 5: itemDes = "Cung xuyên thấu mạnh hơn, kẻ địch mất thêm +5%hp của chúng"; break;
                case 6: itemDes = "Giảm thêm 5s count down nữa"; break;
                case 7: itemDes = "Giảm thêm 5s count down nữa"; break;
                case 8: itemDes = "Giảm thêm 5s count down nữa"; break;
                case 9: itemDes = "Giảm thêm 5s count down nữa"; break;
                case 10: itemDes = "Giảm thêm 5s count down nữa"; break;
            }
        }
        if (itemID == (int)ItemCode.MaskOfLife)
        {
            switch (level)
            {
                case 1: itemDes = "Đòn đánh thường hồi 0.5 HP"; break;
                case 2: itemDes = "Đòn đánh thường hồi thêm +0.5 HP"; break;
                case 3: itemDes = "Nếu HP dưới 20%, đòn đánh thường hồi thêm +5%atk HP"; break;
                case 4: itemDes = "Mỗi lần hút máu, 25% kẻ địch xung quanh mất 10 máu."; break;
                case 5: itemDes = "[60s] Trong 3s, với mỗi kẻ địch bị hạ gục, tăng 1HP MAX."; break;
                case 6: itemDes = "Đòn đánh thường hồi thêm +0.5 HP"; break;
                case 7: itemDes = "Đòn đánh thường hồi thêm +0.5 HP"; break;
                case 8: itemDes = "Đòn đánh thường hồi thêm 5%atk HP"; break;
                case 9: itemDes = "Mỗi lần hút máu, 50% kẻ địch xung quanh mất 10 máu."; break;
                case 10: itemDes = "Mỗi lần hút máu, 50% kẻ địch xung quanh mất 15 máu."; break;

            }
        }
        if (itemID == (int)ItemCode.IceBall)
        {
            switch (level)
            {
                case 1: itemDes = "Mỗi 5 hit, tạo một cầu băng gây 50%atk làm chậm kẻ địch trong 2s"; break;
                case 2: itemDes = "[20s] Bắn ra xung quanh một loạt mảnh băng, gây 50%atk và làm chậm 2s"; break;
                case 3: itemDes = "Cầu Băng gây thêm +50%atk"; break;
                case 4: itemDes = "Giảm số hit kích hoạt còn 4."; break;
                case 5: itemDes = "Tăng sát thương các mảnh băng thêm +50%atk"; break;
                case 6: itemDes = "Giảm số hit kích hoạt còn 3."; break;
                case 7: itemDes = "Cầu Băng gây thêm +50%atk"; break;
                case 8: itemDes = "Tăng sát thương các mảnh băng thêm +50%atk"; break;
                case 9: itemDes = "Cầu Băng gây thêm +100%atk"; break;
                case 10: itemDes = "Tăng sát thương các mảnh băng thêm +100%atk"; break;

            }
        }
        if (itemID == (int)ItemCode.OldRibcage)
        {
            switch (level)
            {
                case 1: itemDes = "Tăng 10%HP"; break;
                case 2: itemDes = "Tăng thêm +10%HP"; break;
                case 3: itemDes = "[60s] Nếu HP dưới 20%, hồi lại 10% HPMax"; break;
                case 4: itemDes = "[60s] Nếu HP dưới 30%, hồi lại 10% HPMax"; break;
                case 5: itemDes = "Tăng thêm +10%HP Max"; break;
                case 6: itemDes = "Tăng thêm +10%HP Max"; break;
                case 7: itemDes = "Tăng thêm +10%HP Max"; break;
                case 8: itemDes = "[40s] Nếu HP dưới 30%, hồi lại 10% HPMax"; break;
                case 9: itemDes = "Tăng thêm +10%HP Max"; break;
                case 10: itemDes = "[30s] Nếu HP dưới 30%, hồi lại 10% HPMax"; break;
            }
        }
        if (itemID == (int)ItemCode.FallenSky)
        {
            switch (level)
            {
                case 1: itemDes = "[30s] Gọi xuống 1 thiên thạch ngẫu nhiên và gây 400%atk"; break;
                case 2: itemDes = "Tăng bán kính thiên thạch thêm 10%"; break;
                case 3: itemDes = "Nhiệt độ tăng cao, thiên thạch gây thêm 100%atk"; break;
                case 4: itemDes = "Thiên thạch vỡ ra để lại một vùng dung nham trong 5s, 50%atk"; break;
                case 5: itemDes = "Tăng bán kính thiên thạch thêm 10%"; break;
                case 6: itemDes = "Tăng bán kính thiên thạch thêm 10%"; break;
                case 7: itemDes = "Thiên thạch vỡ ra để lại một vùng dung nham trong 7s, 50%atk"; break;
                case 8: itemDes = "Tăng bán kính thiên thạch thêm 10%"; break;
                case 9: itemDes = "Thiên thạch vỡ ra để lại một vùng dung nham trong 10s, 50%atk"; break;
                case 10: itemDes = "Giảm CD của thiên thạch còn 10s"; break;

            }
        }
        if (itemID == (int)ItemCode.BookOfKnowledge)
        {
            switch (level)
            {
                case 1: itemDes = "[60s] Reset tất cả các Item khác"; break;
                case 2: itemDes = "Giảm CD 5s"; break;
                case 3: itemDes = "Giảm CD 5s"; break;
                case 4: itemDes = "Giảm CD 5s"; break;
                case 5: itemDes = "Giảm CD 5s"; break;
                case 6: itemDes = "Giảm CD 5s"; break;
                case 7: itemDes = "Giảm CD 5s"; break;
                case 8: itemDes = "Giảm CD 5s"; break;
                case 9: itemDes = "Giảm CD 5s"; break;
                case 10: itemDes = "Giảm CD 5s"; break;
            }
        }
        if (itemID == (int)ItemCode.MaskOfTears)
        {
            switch (level)
            {
                case 1: itemDes = "Mỗi giây mất 5HP nhưng đổi lại tăng 2ATK. Không thể chết do mất máu."; break;
                case 2: itemDes = "Tăng 10% tốc độ đánh"; break;
                case 3: itemDes = "Tăng 5% tốc độ đánh, 2ATK"; break;
                case 4: itemDes = "Tăng 5ATK"; break;
                case 5: itemDes = "[20s] Trong 5s, phá bỏ cực hạn, tăng 10% tốc đánh, 10%ATK"; break;
                case 6: itemDes = "Mỗi giây mất thêm 2 HP nữa nhưng thêm 2ATK"; break;
                case 7: itemDes = "[20s] Trong 7s, phá bỏ cực hạn, tăng 10% tốc đánh, 10%ATK"; break;
                case 8: itemDes = "Mỗi giây mất thêm 2 HP nữa nhưng thêm 5% Tốc đánh"; break;
                case 9: itemDes = "[15s] Trong 7s, phá bỏ cực hạn, tăng 10% tốc đánh, 10%ATK"; break;
                case 10: itemDes = "[10s] Trong 7s, phá bỏ cực hạn, tăng 10% tốc đánh, 10%ATK"; break;

            }
        }
        if (itemID == (int)ItemCode.SwordOfLight)
        {
            switch (level)
            {
                case 1: itemDes = "Đòn đánh thường gây hiệu ứng Thanh Tẩy, mỗi giây kẻ địch mất 3HP"; break;
                case 2: itemDes = "Thanh tẩy có thể cộng dồn 2 tầng"; break;
                case 3: itemDes = "[60s] Tạo ra một thanh kiếm thánh chém xung quanh bản thân, gây 5%tổng linh hồn thu thập được"; break;
                case 4: itemDes = "Thanh Tẩy có thể cộng dồn 3 tầng"; break;
                case 5: itemDes = "Thanh Tẩy có thể cộng dồn 5 tầng"; break;
                case 6: itemDes = "Thanh Tẩy có thể cộng dồn 7 tầng"; break;
                case 7: itemDes = "Sát thương thánh kiếm tăng gấp đôi (10% tổng linh hồn thu thập được)"; break;
                case 8: itemDes = "Thanh Tẩy có thể cộng dồn 9 tầng"; break;
                case 9: itemDes = "Thanh Tẩy có thể cộng dồn 11 tầng"; break;
                case 10: itemDes = "Sát thương thánh kiếm tăng, 15% tổng linh hồn thu thập được"; break;
            }
        }
        return itemDes;
    }
}
