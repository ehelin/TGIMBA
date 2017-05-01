namespace AccountDataProvider
{
    public class Constants
    {
        public const int SALT_SIZE = 32;   //arbitrary value read in article

        //Demo user
        public const string DEMO_USER = "demouser";
        public const string DEMO_USER_PASSWORD = "demouserPass123";
    }

    public class MembershipSql
    {
        public const string USER_EXISTS = "SELECT [UserId], [UserName], [Salt], [PassWord], [Email], [Token]   FROM [Bucket].[User] where [UserName] = @userName";
        public const string INSERT_USER = " declare @beforeCount int "
                                        + " declare @afterCount int "
                                        + "  "
                                        + " select @beforeCount = count(*) from [Bucket].[User]  "
                                        + "  "
                                        + " if not exists (select UserName  "
                                        + "                 from [Bucket].[User]  "
                                        + " 				where UserName = @userName) "
                                        + " begin "
                                        + " 	Insert into [Bucket].[User]  "
                                        + " 	select @userName, @salt, @passWord, @email, null, getdate(), 'Website', getdate(), 'Website' "
                                        + " end "
                                        + "    "
                                        + " select @afterCount = count(*) from [Bucket].[User]  "
                                        + "  "
                                        + " if (@afterCount-1 = @beforeCount) "
                                        + " 	select 1 "
                                        + " else "
                                        + " 	select 0 ";
        public const string ADD_USER_TOKEN = "UPDATE [Bucket].[User] SET [Token] = @Token WHERE UserName = @UserName";

        public const string DELETE_USER = "delete from [Bucket].[User] where UserName = @userName and [PassWord] = @passWord and Email = @email";
        public const string LOG_ACTION = "INSERT INTO [Bucket].[Log] select @LogMessage, getdate()";
    }
}
