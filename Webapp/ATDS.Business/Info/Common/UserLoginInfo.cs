using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATDS.Business.Info
{
    /// <summary>
    /// ユーザーログイン情報クラス（基本情報＋権限情報）
    /// </summary>
    public class UserLoginInfo : UserItemInfo
    {
        public UserLoginInfo()
        { 
        }
        /// <summary>
        /// UserItemInfo から情報をコピーするコンストラクタ
        /// </summary>
        /// <param name="userInfo">ユーザー基本情報</param>
        public UserLoginInfo(UserItemInfo? userInfo)
        { 
            if (userInfo != null)
            {
                this.Id = userInfo.Id;
                this.Code = userInfo.Code;
                this.Name = userInfo.Name;
                this.Email = userInfo.Email;
                this.Username = userInfo.Username;
                this.Language = userInfo.Language;
                this.Password = userInfo.Password;
                this.PasswordHash = userInfo.PasswordHash;
                this.RoleId = userInfo.RoleId;
                this.CreatedAt = userInfo.CreatedAt;
                this.UpdatedAt = userInfo.UpdatedAt;
                this.YukoFlag = userInfo.YukoFlag;
                this.CreatedUser = userInfo.CreatedUser;
            }
            
        }

        /// <summary>
        /// ユーザーが持つ権限の一覧
        /// </summary>
        public List<UserPermissonAction> Permissions { get; set; } = new List<UserPermissonAction>();
    }
}
