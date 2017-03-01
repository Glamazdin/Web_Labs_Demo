namespace WebLabs_V2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nickName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "NickName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "NickName");
        }
    }
}
