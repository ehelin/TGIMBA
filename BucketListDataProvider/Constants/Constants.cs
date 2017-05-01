namespace BucketListDataProvider.Constants
{
    public class Constants
    {

    }

    public class BucketListSql
    {
        public const string GET_BUCKET_LIST = "select bli.ListItemName, "
                                                       + " bli.Created, "
                                                       + " bli.Category, "
                                                       + " bli.Achieved, "
                                                       + " bli.BucketListItemId "
                                                + " from Bucket.BucketListItem bli "
                                                + " inner join Bucket.BucketListUser blu on bli.BucketListItemId = blu.BucketListItemId "
                                                + " inner join [Bucket].[User] u on blu.UserId = u.UserId "
                                                + " where u.UserName = @userName  ";

        public const string DELETE_BUCKET_LIST_ITEM = "delete from Bucket.BucketListUser "
                                                    + " where BucketListItemId = @BucketListItemId "
                                                    + "  "
                                                    + " delete from Bucket.BucketListItem  "
                                                    + " where BucketListItemId = @BucketListItemId ";

        public const string UPSERT_BUCKET_LIST_ITEM = " declare @InsertDbId int "
                                                    + " declare @UserDbId int "
                                                    + " declare @CategorySortOrder int "
                                                    + "  "
                                                    + " if (select count(*)  "
                                                    + "           from [Bucket].[BucketListItem]  "
                                                    + " 		  where BucketListItemId = @BucketListItemId) > 0 "
                                                    + " begin  "
                                                    + " 	update [Bucket].[BucketListItem] "
                                                    + " 	set ListItemName = @ListItemName, "
                                                    + " 		Created = @Created, "
                                                    + " 		Category = @Category, "
                                                    + " 		Achieved = @Achieved "
                                                    + " 	where BucketListItemId = @BucketListItemId "
                                                    + " end "
                                                    + " else "
                                                    + " begin "
                                                    + " if @Category = 'Hot' "
                                                    + "     set @CategorySortOrder = 1 "
                                                    + "  else if @Category = 'Warm' "
                                                    + "     set @CategorySortOrder = 2 "
                                                    + "  else  "
                                                    + "      set @CategorySortOrder = 3 "
                                                    + "        "
                                                    + "  INSERT INTO[Bucket].[BucketListItem] "
                                                    + "       ([ListItemName], "
                                                    + "        [Created], "
                                                    + "        [Category], "
                                                    + "        [Achieved], "
                                                    + "        [CategorySortOrder]) "
                                                    + "   VALUES "
                                                    + "        (@ListItemName, "
                                                    + "         @Created, "
                                                    + "         @Category, "
                                                    + "         @Achieved, "
                                                    + "         @CategorySortOrder) "
                                                    + "      "
                                                    + "     select @UserDbId = UserId "
                                                    + "     from [Bucket].[User] "
                                                    + "     where UserName = @UserName "
                                                    + "      "
                                                    + " 	SELECT @InsertDbId = SCOPE_IDENTITY()     "
                                                    + " 	insert into Bucket.BucketListUser "
                                                    + " 	select @InsertDbId, @UserDbId "
                                                    + " end ";

        public const string LOG_ACTION = "INSERT INTO [Bucket].[Log] select @LogMessage, getdate()";
        public const string LOG_BROWSER_CAPABIILITY = "INSERT INTO [Bucket].[BrowserCapability] "
                                                           + " ([BrowserLogId] "
                                                           + " ,[Key] "
                                                           + " ,[Value]) "
                                                     + " VALUES "
                                                           + " (@BrowserLogId, "
                                                           + "  @Key,"
                                                           + "  @Value) ";

        public const string SP_LOG_BROWSER = "[Bucket].[InsertBrowser]";

        public const string DELETE_USER = "delete from [Bucket].[User] where UserName = @userName";
        public const string DELETE_TEST_USER = "delete from [Bucket].[BucketListItem]   "
                                                + " where bucketlistitemid in (select bucketListItemId   "
                                                + "                            from [Bucket].[BucketListUser]   "
                                                + " 						   where userid in (select userid   "
                                                + " 						                    from [Bucket].[User]   "
                                                + " 										    where UserName = 'testUser')   "
                                                + " 						   )   "
                                                + "    "
                                                + " delete from [Bucket].[BucketListUser]   "
                                                + " where userid in (select userid   "
                                                + " 				from [Bucket].[User]   "
                                                + " 				where UserName = 'testUser')   "
                                                + "    "
                                                + " delete from [Bucket].[User]   "
                                                + " where UserName = 'testUser' ";
    }

    public class DashboardSql
    {
        public const string DASHBOARD_USER_SQL = " select count(distinct username) UserCount, 'Total Users' Label "
                                               + " from Bucket.[User] ";

        public const string DASHBOARD_CATEGORY_SQL = "  select distinct bli.Category Category, "
                                                    + " 	   count(bli.Category) CategoryCount "
                                                    + " from Bucket.[User] u "
                                                    + " inner join Bucket.BucketListUser blu on u.UserId = blu.UserId "
                                                    + " inner join Bucket.BucketListItem bli on blu.BucketListItemId = bli.BucketListItemId "
                                                    + " where bli.Category in ('Hot','Warm','Cool') "
                                                    + " group by bli.Category ";

        public const string DASHBOARD_ACHIEVED_SQL = "  select distinct  "
                                                    + " 	   case  "
                                                    + " 			when bli.Achieved = 1 then 'True' "
                                                    + " 			else 'False' "
                                                    + " 	   end Achieved, "
                                                    + " 	   count(bli.Achieved) AchievedCount "
                                                    + " from Bucket.[User] u "
                                                    + " inner join Bucket.BucketListUser blu on u.UserId = blu.UserId "
                                                    + " inner join Bucket.BucketListItem bli on blu.BucketListItemId = bli.BucketListItemId "
                                                    + " group by bli.Achieved "
                                                    + " order by Achieved desc ";

        public const string DASHBOARD_CREATED_SQL = "  select distinct DatePart(yyyy, bli.Created) CreatedYear,  "
                                                    + " 	   count(bli.Created) CreatedCount  "
                                                    + " from Bucket.[User] u  "
                                                    + " inner join Bucket.BucketListUser blu on u.UserId = blu.UserId  "
                                                    + " inner join Bucket.BucketListItem bli on blu.BucketListItemId = bli.BucketListItemId  "
                                                    + " group by DatePart(yyyy, bli.Created) ";
    }
}
