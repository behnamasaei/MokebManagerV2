namespace MokebManagerV2.Permissions;

public static class MokebManagerV2Permissions
{
    public const string GroupName = "MokebManagerV2";

    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";

    public static class MokebsPermissions
    {
        public const string Default = GroupName + ".Mokebs";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }

    public static class PilgrimsPermissions
    {
        public const string Default = GroupName + ".Pilgrims";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
}
