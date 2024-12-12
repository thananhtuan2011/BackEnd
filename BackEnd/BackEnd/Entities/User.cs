

using BackEnd.Server.Entities;

namespace BackEnd.Entities
{
    public class User : BaseGuidEntity
    {
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? email { get; set; }
        public string? username { get; set; }
        public string? role { get; set; }
        public string? password { get; set; }

        // 2FA fields
        public bool? is2FAEnabled { get; set; }
        public string? twoFactorCode { get; set; }
        public DateTime? expireTime { get; set; }

        // Additional fields
        public int? status { get; set; }
        public DateTime? lastLoginTime { get; set; }

    }
}
