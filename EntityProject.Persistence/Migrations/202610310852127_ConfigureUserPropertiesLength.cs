namespace EntityProject.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConfigureUserPropertiesLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "FirstName", c => c.String(maxLength: 20));
            AlterColumn("dbo.Users", "LastName", c => c.String(maxLength: 20));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Password", c => c.String());
            AlterColumn("dbo.Users", "LastName", c => c.String());
            AlterColumn("dbo.Users", "FirstName", c => c.String());
        }
    }
}
