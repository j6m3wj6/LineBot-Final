using System;
namespace LineBot.Models
{
    public class UsersDatabaseSettings : IUsersDatabaseSettings
    {
        
        public string UsersCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    public interface IUsersDatabaseSettings
    {
        string UsersCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
//上述 BookstoreDatabaseSettings 類別是用來儲存檔案的 appsettings.json BookstoreDatabaseSettings 屬性值。
//JSON 和 C# 屬性名稱以相同方式命名，以簡化對應程序。